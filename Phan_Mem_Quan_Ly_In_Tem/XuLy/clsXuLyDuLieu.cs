using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_In_Tem.XuLy
{
    public class clsXuLyDuLieu
    {
        public clsXuLyDuLieu()
        { 
        
        }

        public DataTable docFileExcel(string FilePath, string Extension, string isHDR)
        {
            if (!File.Exists(FilePath))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return null;
            }
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                    case ".xlsx": //Excel 07
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public DataTable docDanhSachNhaCungCapFileExcel(string FilePath, string Extension, string isHDR)
        {
            if (!File.Exists(FilePath))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return null;
            }
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                    case ".xlsx": //Excel 07
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT DISTINCT [Nhà Cung Cấp], [Tên Tiệm], [Địa Chỉ] From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void luuDuLieuExcel(string duongDanFileExcel, string maVach, string tenHang, decimal tongTrongLuong, decimal trongLuong, decimal hot, decimal tienCong, string loaiVang, string nhaCungCap, string hamLuongPho, string tenTiem, string diaChi, int soLuongTem, int soni, string kyHieuVang)
        {
            if (!File.Exists(duongDanFileExcel))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return;
            }
            
                string conStr = "";
                string Extension = Path.GetExtension(duongDanFileExcel); 
                string isHDR = "Yes";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                    case ".xlsx": //Excel 07
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                }
                conStr = String.Format(conStr, duongDanFileExcel, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;
            try
            {
                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                //cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                cmdExcel.CommandText = @"INSERT INTO [" + SheetName + @"] ([Mã Vạch], [Tên Hàng], [Tổng Trọng Lượng], [Trọng Lượng], [Hột],  [Tiền Công], [Nhà Cung Cấp], [Hàm Lượng Phổ], [Tên Tiệm], [Địa Chỉ], [Số Lượng Tem], [Số Ni], [Ký Hiệu Vàng]) VALUES(@MaVach, @TenHang, @TongTrongLuong, @TrongLuong, @Hot, @TienCong, @NhaCungCap, @HamLuongPho, @TenTiem, @DiaChi, @SoLuongTem, @SoNi, @KyHieuVang)";

                //cmdExcel.CommandText = "INSERT INTO [" + SheetName + "] ([Mã Vạch], [Tên Hàng], [Tổng Trọng Lượng], [Trọng Lượng], [Hột], [Tiền Công], [Loại Vàng], [Nhà Cung Cấp], [Hàm Lượng Phổ], [Số Lượng Tem]) VALUES(@MaVach, @TenHang, @TongTrongLuong, @TrongLuong, @Hot, @TienCong, @LoaiVang, @NhaCungCap, @HamLuongPho, @SoLuongTem)";
                cmdExcel.Parameters.AddWithValue("@MaVach", "" + maVach.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@TenHang", "" + tenHang.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@TongTrongLuong", "" + tongTrongLuong.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@TrongLuong", "" + trongLuong.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@Hot", "" + hot.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@TienCong", "" + tienCong.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@NhaCungCap", "" + nhaCungCap.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@HamLuongPho", "" + hamLuongPho.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@TenTiem", "" + tenTiem.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@DiaChi", "" + diaChi.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@SoLuongTem", "" + soLuongTem.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@SoNi", "" + soni.ToString() + "");
                cmdExcel.Parameters.AddWithValue("@KyHieuVang", "" + kyHieuVang + "");
                //oda.SelectCommand = cmdExcel;
                //oda.Fill(dt);
                cmdExcel.ExecuteNonQuery();
                connExcel.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connExcel.Close();
                if(connExcel.State == ConnectionState.Open)
                {
                    connExcel.Close();
                }
            }
            
        }

        public string chuyenGiaTriSangNoiDung(decimal giaTriCanNang)
        {
            //decimal canNang = Math.Round(giaTriCanNang, 3);

            decimal phanChi = (int)giaTriCanNang;
            decimal phanLe_PhanLy = (decimal)((int)((giaTriCanNang - (int)giaTriCanNang) * 100)) / 100;
            decimal phanLe_TieuLy = Math.Round((giaTriCanNang - (phanChi + phanLe_PhanLy)), 4);

            //if (phanLe_TieuLy >= 0 && phanLe_TieuLy < 0.0030m)
            //{
            //    phanLe_TieuLy = 0;
            //}
            //else if (phanLe_TieuLy >= 0.0030m && phanLe_TieuLy < 0.0080m)
            //{
            //    phanLe_TieuLy = 0.005m;
            //}
            //else if (phanLe_TieuLy >= 0.0080m && phanLe_TieuLy < 0.01m)
            //{
            //    phanLe_TieuLy = 0.01m;
            //}

            decimal canNang = phanChi + phanLe_PhanLy + phanLe_TieuLy;
            //MessageBox.Show(canNang.ToString());

            decimal phanNguyen = (int)canNang;
            decimal phanLe = canNang - (int)canNang;

            //MessageBox.Show(phanLe.ToString());

            //decimal tam = phanLe;

            //int luong = (int)(canNang);
            int chi = (int)(canNang);
            //tam = (phanLe * 10);
            int phan = ((int)(phanLe * 10)) % 10;
            int ly = ((int)(phanLe * 100)) % 10;
            int dem = ((int)(phanLe * 1000)) % 10;
            int tieudem = ((int)(phanLe * 10000)) % 10;

            //if (luong != 0)
            //{
            //    return ((luong * 10) + chi).ToString() + "C" + phan.ToString() + ly.ToString() + dem.ToString() + tieudem.ToString();
            //}
            //else 
            if (chi != 0)
            {
                //return chi.ToString() + "c" + ((phan == 0 && ly == 0 && dem == 0 && tieudem == 0) ? "" : phan.ToString()) + ((ly == 0 && dem == 0 && tieudem == 0) ? "" : ly.ToString()) + ((dem == 0 && tieudem == 0) ? "" : dem.ToString()) + (tieudem == 0 ? "" : tieudem.ToString());
                //return chi.ToString() + "c" + phan.ToString() + ly.ToString() + dem.ToString() + tieudem.ToString();
                return chi.ToString() + "c" + phan.ToString() + "p" + ly.ToString() + dem.ToString() + tieudem.ToString();
            }
            else if (phan != 0)
            {
                //return phan.ToString() + "p" + ((ly == 0 && dem == 0 && tieudem == 0) ? "" : ly.ToString()) + ((dem == 0 && tieudem == 0) ? "" : dem.ToString()) + (tieudem == 0 ? "" : tieudem.ToString());
                //return phan.ToString() + "p" + ly.ToString() + dem.ToString() + tieudem.ToString();
                return phan.ToString() + "p" + ly.ToString() + "l" + dem.ToString() + tieudem.ToString();
            }
            else if (ly != 0)
            {
                //return ly.ToString() + "ly" + tieuly.ToString() + "0";
                //26 toi 74 là 50
                //dem = (dem * 10) + tieudem;

                //if(dem < 25)
                //{
                //    dem = 0;
                //}
                //else if(dem >= 25 && dem <= 74)
                //{
                //    dem = 5;
                //}
                //else
                //{
                //    ly += 1;
                //}

                //return ly.ToString() + "ly" + ((dem == 0 && tieudem == 0) ? "" : dem.ToString()) + (tieudem == 0 ? "" : tieudem.ToString());
                return ly.ToString() + "ly" + dem.ToString() + tieudem.ToString();
            }
            else if (dem != 0)
            {
                return "0ly" + dem.ToString();
            }
            else
            {
                return "0,0000";
            }


            //return ((luong * 10) + chi).ToString() + "C" + phan + "P" + ly + "L" + tieuly;
        }

        public bool luuThongTin(string tenTiem, string diaChi, string tenCongCOM, string duongDanDuLieu, string tenMayIn)
        {
            try
            {
                var ds = new DataSet();
                var dt = new DataTable("ThongTinTiem");

                dt.Columns.Add("TenTiem");
                dt.Columns.Add("DiaChi");
                dt.Columns.Add("CongCOM");
                dt.Columns.Add("FileExcel");
                dt.Columns.Add("MayIn");

                dt.Rows.Clear();
                dt.Rows.Add(
                    new object[] 
                    { 
                        tenTiem,
                        diaChi,
                        tenCongCOM,
                        duongDanDuLieu,
                        tenMayIn
                    }
                    );

                ds.Tables.Add(dt);
                ds.WriteXml("ThongTinTiem.xml");
                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public DataTable docDanhSachMauTemInFileExcel(string FilePath, string Extension, string isHDR)
        {
            if (!File.Exists(FilePath))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return null;
            }
            try
            {
                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                    case ".xlsx": //Excel 07
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "] WHERE ([Xóa] = '' AND [Xóa] IS NOT NULL) OR [Xóa] = 'N'";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void xoaMauTemIn(string duongDanFileExcel, string ID)
        {
            if (!File.Exists(duongDanFileExcel))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return;
            }

            string conStr = "";
            string Extension = Path.GetExtension(duongDanFileExcel);
            string isHDR = "Yes";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                    break;
                case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                    break;
            }
            conStr = String.Format(conStr, duongDanFileExcel, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;
            try
            {
                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                //cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                cmdExcel.CommandText = @"UPDATE [" + SheetName + @"] SET [Xóa] = 'Y' WHERE [ID] = @ID;";
                cmdExcel.Parameters.AddWithValue("@ID", "" + ID + "");
                //oda.SelectCommand = cmdExcel;
                //oda.Fill(dt);
                cmdExcel.ExecuteNonQuery();
                connExcel.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connExcel.Close();
                if (connExcel.State == ConnectionState.Open)
                {
                    connExcel.Close();
                }
            }

        }
        public DataRow getMauTemIn(string duongDanFileExcel, string ID)
        {
            if (!File.Exists(duongDanFileExcel))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return null;
            }
            try
            {
                string conStr = "";
                string Extension = Path.GetExtension(duongDanFileExcel);
                string isHDR = "Yes";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                    case ".xlsx": //Excel 07
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                }
                conStr = String.Format(conStr, duongDanFileExcel, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "] WHERE [ID] = @ID";
                cmdExcel.Parameters.AddWithValue("@ID", "" + ID + "");
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);
                connExcel.Close();
                if (dt != null && dt.Rows.Count > 0) 
                {
                    return dt.Rows[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool luuMauTemIn(string duongDanFileExcel, string ID, string tenMauTem, string duongDan, string ghiChu, string macDinh)
        {
            if (!File.Exists(duongDanFileExcel))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return false;
            }

            string conStr = "";
            string Extension = Path.GetExtension(duongDanFileExcel);
            string isHDR = "Yes";
            switch (Extension)
            {
                case ".xls": //Excel 97-03
                    conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                    break;
                case ".xlsx": //Excel 07
                    conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                    break;
            }
            conStr = String.Format(conStr, duongDanFileExcel, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();
            cmdExcel.Connection = connExcel;
            try
            {
                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                //cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                if (macDinh == "Y") 
                {
                    cmdExcel.CommandText = @"UPDATE [" + SheetName + @"] SET [Mặc Định] = 'N'";
                    cmdExcel.ExecuteNonQuery();
                }
                if (string.IsNullOrEmpty(ID))
                {
                    cmdExcel.CommandText = @"INSERT INTO [" + SheetName + @"] ([ID], [Tên Mẫu Tem], [Đường Dẫn], [Mặc Định], [Ghi Chú], [Xóa]) VALUES(@ID, @TenMauTem, @DuongDan, @MacDinh, @GhiChu, 'N')";

                    cmdExcel.Parameters.AddWithValue("@ID", "" + Guid.NewGuid().ToString() + "");
                    cmdExcel.Parameters.AddWithValue("@TenMauTem", "" + tenMauTem + "");
                    cmdExcel.Parameters.AddWithValue("@DuongDan", "" + duongDan + "");
                    cmdExcel.Parameters.AddWithValue("@MacDinh", "" + macDinh + "");
                    cmdExcel.Parameters.AddWithValue("@GhiChu", "" + ghiChu + "");
                }
                else 
                {
                    cmdExcel.CommandText = @"UPDATE [" + SheetName + @"] SET [Tên Mẫu Tem] = @TenMauTem, [Đường Dẫn] = @DuongDan, [Mặc Định] = @MacDinh, [Ghi Chú] = @GhiChu WHERE ID = @ID";

                    cmdExcel.Parameters.AddWithValue("@TenMauTem", "" + tenMauTem + "");
                    cmdExcel.Parameters.AddWithValue("@DuongDan", "" + duongDan + "");
                    cmdExcel.Parameters.AddWithValue("@MacDinh", "" + macDinh + "");
                    cmdExcel.Parameters.AddWithValue("@GhiChu", "" + ghiChu + "");
                    cmdExcel.Parameters.AddWithValue("@ID", "" + ID + "");
                }
                

                //oda.SelectCommand = cmdExcel;
                //oda.Fill(dt);
                cmdExcel.ExecuteNonQuery();
                connExcel.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                connExcel.Close();
                if (connExcel.State == ConnectionState.Open)
                {
                    connExcel.Close();
                }
            }
        }

        public string getMauTemInMacDinh(string duongDanFileExcel)
        {
            if (!File.Exists(duongDanFileExcel))
            {
                MessageBox.Show("Không tìm thấy file dữ liệu.");
                return "";
            }
            try
            {
                string conStr = "";
                string Extension = Path.GetExtension(duongDanFileExcel);
                string isHDR = "Yes";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                    case ".xlsx": //Excel 07
                        conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
                        break;
                }
                conStr = String.Format(conStr, duongDanFileExcel, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string SheetName = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT TOP 1 [Đường Dẫn] From [" + SheetName + "] WHERE [Đường Dẫn] <> '' AND [Đường Dẫn] IS NOT NULL ORDER BY [Mặc Định] DESC,[ID];";
                object objDuongDan = cmdExcel.ExecuteScalar();
                if (objDuongDan != null) 
                {
                    return objDuongDan.ToString();
                }
                //oda.SelectCommand = cmdExcel;
                //oda.Fill(dt);
                cmdExcel.Dispose();
                connExcel.Close();
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        public string generateUniqueIDByDateTime(string tenSanPham)
        {
            try 
            {
                string masanpham = tenSanPham[0].ToString() + DateTime.Now.Ticks.ToString().Substring(0, 5);
                return masanpham;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
    }
}
