﻿using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Common;
using System.IO.Ports;
using Newtonsoft.Json;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai
{
    public partial class frmConfig : XtraForm
    {
        public delegate void ThanhCongEventHander(object sender);

        public event ThanhCongEventHander ThanhCong;
        private void KetThucThanhCongEventHander()
        {
            if (ThanhCong != null)
            {
                ThanhCong(this);
            }
        }

        public delegate void BoEventHander(object sender);

        public event BoEventHander Bo;
        private void KetThucBoEventHander()
        {
            if (Bo != null)
            {
                Bo(this);
            }
        }

        public bool isRestart = false;

        public frmConfig()
        {
            InitializeComponent();

            var dt = new DataTable("CauHinhCSDL");
            dt.Columns.Add("MayChu");
            dt.Columns.Add("SuDungTaiKhoanWindows");
            dt.Columns.Add("TaiKhoanSQL");
            dt.Columns.Add("Password");
            dt.Columns.Add("CSDL");

            dt.Columns.Add("TenCongTy");
            dt.Columns.Add("DiaChi");
            dt.Columns.Add("DienThoai");
            dt.Columns.Add("Fax");

            dt.Columns.Add("ComPort");
            dt.Columns.Add("BaudRate");

            LoadComPortList();

            var fi = new FileInfo(Application.StartupPath + "\\CauHinhCSDL.xml");
            if (!fi.Exists) return;
            
            dt.ReadXml(Application.StartupPath + "\\CauHinhCSDL.xml");
            try
            {
                if (dt.Rows.Count > 0)
                {
                    //txtUserName.Text = MyEncryption.Decrypt(dt.Rows[0]["user"].ToString(), "963147", true);
                    //txtPassword.Text = MyEncryption.Decrypt(dt.Rows[0]["pass"].ToString(), "963147", true);

                    txtMayChuSQL.Text = dt.Rows[0]["MayChu"].ToString();
                    cbSuDungTaiKhoanWindows.Checked = (dt.Rows[0]["SuDungTaiKhoanWindows"] == DBNull.Value ? "" : dt.Rows[0]["SuDungTaiKhoanWindows"]).ToString().ToLower() == "true" ? true : false;
                    txtTaiKhoanSQL.Text = dt.Rows[0]["TaiKhoanSQL"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtTenCSDL.Text = dt.Rows[0]["CSDL"].ToString();

                    txtCongTy.Text = dt.Rows[0]["TenCongTy"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    txtDienThoai.Text = dt.Rows[0]["DienThoai"].ToString();
                    txtFax.Text = dt.Rows[0]["Fax"].ToString();
                    
                    cbComPort.Text = dt.Rows[0]["ComPort"].ToString();
                    calBaudRate.EditValue = Convert.ToInt32(dt.Rows[0]["BaudRate"]);

                    if (!cbSuDungTaiKhoanWindows.Checked)
                    {
                        SqlHelper.ConnectionString = "Data Source=" + txtMayChuSQL.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";User ID=" + txtTaiKhoanSQL.Text + ";Password=" + txtPassword.Text + ";";
                    }
                    else
                    {
                        SqlHelper.ConnectionString = "Data Source=" + txtMayChuSQL.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";Integrated Security=True;";
                    }

                    //var mySql = new SqlHelper();

                    SqlHelper.CompanyName = txtCongTy.Text;
                    SqlHelper.Address = txtDiaChi.Text;
                    SqlHelper.Phone = txtDienThoai.Text;
                    SqlHelper.Fax = txtFax.Text;

                    SqlHelper.Server = txtMayChuSQL.Text;
                    SqlHelper.IsWindowsAuthentication = cbSuDungTaiKhoanWindows.Checked;
                    SqlHelper.User = txtTaiKhoanSQL.Text;
                    SqlHelper.Password = txtPassword.Text;
                    SqlHelper.Database = txtTenCSDL.Text;

                    SqlHelper.ComPort = cbComPort.Text;
                    SqlHelper.BaudRate = Convert.ToInt32(calBaudRate.EditValue);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (!isRestart)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            //Data Source=.\SQLEXPRESS;Initial Catalog=QLK_quang_make;User ID=sa
            //Data Source=.\SQLEXPRESS;Initial Catalog=QLK_quang_make;Integrated Security=True

            if (!cbSuDungTaiKhoanWindows.Checked)
            {
                SqlHelper.ConnectionString = "Data Source=" + txtMayChuSQL.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";User ID=" + txtTaiKhoanSQL.Text + ";Password=" + txtPassword.Text + ";";
            }
            else
            {
                SqlHelper.ConnectionString = "Data Source=" + txtMayChuSQL.Text + ";Initial Catalog=" + txtTenCSDL.Text + ";Integrated Security=True;";
            }

            //var mySql = new SqlHelper();

            SqlHelper.CompanyName = txtCongTy.Text;
            SqlHelper.Address = txtDiaChi.Text;
            SqlHelper.Phone = txtDienThoai.Text;
            SqlHelper.Fax = txtFax.Text;
            
            SqlHelper.Server = txtMayChuSQL.Text;
            SqlHelper.IsWindowsAuthentication = cbSuDungTaiKhoanWindows.Checked;
            SqlHelper.User = txtTaiKhoanSQL.Text;
            SqlHelper.Password = txtPassword.Text;
            SqlHelper.Database = txtTenCSDL.Text;

            SqlHelper.ComPort = cbComPort.Text;
            SqlHelper.BaudRate = Convert.ToInt32(calBaudRate.EditValue);

            //this.Close();

            //FrmMain main = new FrmMain();
            //main.WindowState = FormWindowState.Maximized;
            //main.Show();

            if (Kiem_Tra_Ket_Noi(SqlHelper.ConnectionString))
            {
                KetThucThanhCongEventHander();
                Luu_Cau_Hinh();
                if (isRestart)
                {
                    Application.Restart();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                return;
            }
        }

        private void cbSuDungTaiKhoanWindows_CheckedChanged(object sender, EventArgs e)
        {
            txtTaiKhoanSQL.Properties.ReadOnly = cbSuDungTaiKhoanWindows.Checked;
            txtPassword.Properties.ReadOnly = cbSuDungTaiKhoanWindows.Checked;
        }

        public bool Kiem_Tra_Ket_Noi(string ConnectionString)
        {
            var connection = new SqlConnection(ConnectionString);
            
            try
            {
                connection.Open();
                connection.Close();
            }
            catch
            {
                MessageBox.Show(this, "Không thể kết nối với máy chủ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            
            return true;
        }

        public void Luu_Cau_Hinh()
        {
            try 
            {
                var ds = new DataSet();
                var dt = new DataTable("CauHinhCSDL");

                dt.Columns.Add("MayChu");
                dt.Columns.Add("SuDungTaiKhoanWindows");
                dt.Columns.Add("TaiKhoanSQL");
                dt.Columns.Add("Password");
                dt.Columns.Add("CSDL");
                
                dt.Columns.Add("TenCongTy");
                dt.Columns.Add("DiaChi");
                dt.Columns.Add("DienThoai");
                dt.Columns.Add("Fax");

                dt.Columns.Add("ComPort");
                dt.Columns.Add("BaudRate");

                dt.Rows.Clear();
                dt.Rows.Add(
                    new object[] 
                    { 
                        txtMayChuSQL.Text,
                        cbSuDungTaiKhoanWindows.Checked.ToString(),
                        txtTaiKhoanSQL.Text,
                        txtPassword.Text,
                        txtTenCSDL.Text,

                        txtCongTy.Text,
                        txtDiaChi.Text,
                        txtDienThoai.Text,
                        txtFax.Text,

                        cbComPort.Text,
                        calBaudRate.EditValue.ToString()
                    }
                    );

                ds.Tables.Add(dt);
                ds.WriteXml("CauHinhCSDL.xml");

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CauHinhCSDL_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void LoadComPortList()
        {
            try
            {
                cbComPort.Properties.Items.Clear();
                string[] port = SerialPort.GetPortNames();
                foreach (string item in port)
                {
                    cbComPort.Properties.Items.Add(item);
                }
                if (port.Length > 0)
                {
                    cbComPort.EditValue = port[0];
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiGuide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileName = Application.StartupPath + @"\Huong_dan_su_dung.docx";
                var process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = fileName };
                process.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiContact_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var _frmContact = new frmContact();
                _frmContact.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
