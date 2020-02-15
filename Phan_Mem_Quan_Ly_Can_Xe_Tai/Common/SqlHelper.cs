using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.Common
{
    public class SqlHelper
    {
        public static string Server { get; set; }
        public static bool IsWindowsAuthentication { get; set; }
        public static string User { get; set; }
        public static string Password { get; set; }
        public static string Database { get; set; }
        public static string CompanyName { get; set; } = "";
        public static string Address { get; set; } = "";
        public static string Phone { get; set; } = "";
        public static string Fax { get; set; } = "";
        public static string ComPort { get; set; } = "";
        public static int BaudRate { get; set; } = 9600;
        public static string ConnectionString { get; set; } = "";
        public static string GenCode(string tableName, string columnName, string fKey, int length)
        {
            string Result;

            string sql =
            @"
                SELECT MAX(CAST(REPLACE([" + columnName + @"], '" + fKey + @"', '') AS BIGINT))
                FROM   [" + tableName + @"]
                WHERE  [" + columnName + @"] LIKE N'" + @fKey + @"%'
                       AND ISNUMERIC(REPLACE([" + columnName + "], '" + fKey + @"', '')) = 1
            ";

            object ob = ExecuteScalar(sql);
            Result = ob == null ? "0" : ob.ToString();
            if (fKey.Length != 0) Result = Result.Replace(fKey, "").Trim();
            int num = 0;
            if (Int32.TryParse(Result, out num))
            {
                num = Convert.ToInt32(Result);
            }
            num++;
            string format = num.ToString();
            if (format.Length < length)
            {
                while (format.Length < length)
                {
                    format = "0" + format;
                }
            }

            return fKey + format;
        }
        public static string ExecuteScalar(string sql)
        {
            string value = "";

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                try
                {
                    conn.Open();
                    value = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return value;
        }
        public DataTable ExecuteDataTable(string sql, string[] mypara, object[] myvalue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                try
                {
                    if (mypara != null && myvalue != null)
                    {
                        for (int i = 0; i < mypara.Length; i++)
                        {
                            cmd.Parameters.Add(new SqlParameter(mypara[i], myvalue[i]));
                        }
                    }

                    conn.Open();
                    dt.Load(cmd.ExecuteReader());
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return dt;
        }
        public string ExecuteNonQuery(string sql, string[] mypara, object[] myvalue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    for (int i = 0; i < mypara.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(mypara[i], myvalue[i]));
                    }
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return "NOT OK";
                }
            }
        }
        public string ExecuteNonQuery(SqlTransaction transaction, string sql, string[] mypara, object[] myvalue)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;

                try
                {
                    for (int i = 0; i < mypara.Length; i++)
                    {
                        cmd.Parameters.Add(new SqlParameter(mypara[i], myvalue[i]));
                    }
                    conn.Open();
                    cmd.Transaction = transaction;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    conn.Close();

                    return "OK";
                }
                catch (Exception ex)
                {
                    cmd.Transaction.Rollback();
                    MessageBox.Show(ex.Message);
                    return "NOT OK";
                }
            }
        }
    }
}
