using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using OnBarcode.Barcode;
using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.Diagnostics;
using DevExpress.BarCodes;
using Phan_Mem_Quan_Ly_Cam_Do.InMaVach;
using DevExpress.XtraReports.UI;
using System.Data.OleDb;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Preview;
using System.IO.Ports;

namespace quanlykho_quang_make
{
    public partial class frDanhSachMatHang : Form
    {
        public frDanhSachMatHang()
        {
            InitializeComponent();

            txtNgay.DateTime = DateTime.Now;

            //dsDanhSachHangHoa.InMaVach.AddInMaVachRow(
            //    "M" + DateTime.Now.ToShortDateString(),
            //    "Mặt đá màu",
            //    Convert.ToDecimal(0.040),
            //    Convert.ToDecimal(0.026),
            //    300000,
            //    Convert.ToDecimal(0.014),
            //    "24k",
            //    "CL",
            //    "600",
            //    1
            //    );

            var dt = new DataTable("CauHinhCSDL");
            dt.Columns.Add("TenTiem");
            dt.Columns.Add("DiaChi");

            var fi = new FileInfo(Application.StartupPath + "\\CauHinhCSDL.xml");
            if (!fi.Exists) return;

            dt.ReadXml(Application.StartupPath + "\\CauHinhCSDL.xml");
            try
            {
                if (dt.Rows.Count > 0)
                {
                    txtTenDoanhNghiep.Text = dt.Rows[0]["TenTiem"].ToString();
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cbCongCom.Items.Clear();
            string[] port = SerialPort.GetPortNames();
            foreach (string item in port)
            {
                cbCongCom.Items.Add(item);
            }
            if (port.Length > 0)
            {
                cbCongCom.SelectedIndex = 0;
            }

            bbiXem_ItemClick(this, null);
        }

        private void gbList_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }

        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //QRCode qrcode = new QRCode();

            //// Barcode data to encode
            //qrcode.Data = "ONBARCODE";
            //// QR-Code data mode
            //qrcode.DataMode = QRCodeDataMode.AlphaNumeric;
            //// QR-Code format mode
            ////qrcode.Version = QRCodeVersion.V10;

            ///*
            //* Barcode Image Related Settings
            //*/
            //// Unit of meature for all size related setting in the library. 
            //qrcode.UOM = UnitOfMeasure.PIXEL;
            //// Bar module size (X), default is 3 pixel;
            //qrcode.X = 3;
            //// Barcode image left, right, top, bottom margins. Defaults are 0.
            //qrcode.LeftMargin = 0;
            //qrcode.RightMargin = 0;
            //qrcode.TopMargin = 0;
            //qrcode.BottomMargin = 0;
            //// Image resolution in dpi, default is 72 dpi.
            //qrcode.Resolution = 72;
            //// Created barcode orientation.
            ////4 options are: facing left, facing right, facing bottom, and facing top
            //qrcode.Rotate = Rotate.Rotate0;

            //// Generate QR-Code and encode barcode to gif format
            //qrcode.ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
            //qrcode.drawBarcode("C:\\qrcode.png");

            ///*
            //You can also call other drawing methods to generate barcodes
             
            //public void drawBarcode(Graphics graphics);
    
            //public void drawBarcode(string filename);
    
            //public Bitmap drawBarcode();
    
            //public void drawBarcode(Stream stream);
             
            //*/


            //---------------------------------------------------------------------------
            //QRBarCode

            /*
            BarCode barcode = new BarCode();
            barcode.Symbology = Symbology.QRCode;
            barcode.CodeText = 
            @"
                mã hàng
                tên hàng
                đơn vị
                màu sắc
                kích thước
                lô hàng
                hạn sử dụng
                đơn giá
            ";

            //barcode.CodeBinaryData = Encoding.Default.GetBytes(barcode.CodeText);
            barcode.CodeBinaryData = Encoding.UTF8.GetBytes(barcode.CodeText);
            //Encoding.UTF8.GetBytes
            barcode.Options.QRCode.CompactionMode = QRCodeCompactionMode.Byte;
            barcode.Options.QRCode.ErrorLevel = QRCodeErrorLevel.Q;
            barcode.Options.QRCode.ShowCodeText = false;
            barcode.DpiX = 72;
            barcode.DpiY = 72;

            barcode.BarCodeImage.Save("C:\\qrcode.png", System.Drawing.Imaging.ImageFormat.Png);
            Process.Start("C:\\qrcode.png");
            */
            //-------------------------------------------------------------------------------

        }

        private void bbiXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var xuly = new XuLy();
            xuly.Export(gbList);
        }

        private void bbiInMaVach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dsDanhSachHangHoa.InMaVach.Rows.Count <= 0)
            {
                XtraMessageBox.Show("Không có dữ liệu để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dtInMaVach = new DataTable();

            dtInMaVach = dsDanhSachHangHoa.InMaVach.Copy();
            dtInMaVach.Rows.Clear();

            foreach (DataRow drDong in dsDanhSachHangHoa.InMaVach)
            {
                for(int i = 0; i < Convert.ToInt32(drDong[colSoLuongTem.FieldName]); i++)
                {
                    DataRow drDongIn = dtInMaVach.NewRow();

                    drDongIn[colMaVach.FieldName] = drDong[colMaVach.FieldName];
                    drDongIn[colTenHang.FieldName] = drDong[colTenHang.FieldName];
                    drDongIn[colTongTrongLuong.FieldName] = drDong[colTongTrongLuong.FieldName];
                    drDongIn[colTrongLuong.FieldName] = drDong[colTrongLuong.FieldName];
                    drDongIn[colTienCong.FieldName] = drDong[colTienCong.FieldName];
                    drDongIn[colHot.FieldName] = drDong[colHot.FieldName];
                    drDongIn[colLoaiVang.FieldName] = drDong[colLoaiVang.FieldName];
                    drDongIn[colNhaCungCap.FieldName] = drDong[colNhaCungCap.FieldName];
                    drDongIn[colHamLuongPho.FieldName] = drDong[colHamLuongPho.FieldName];
                    drDongIn[colSoLuongTem.FieldName] = drDong[colSoLuongTem.FieldName];

                    dtInMaVach.Rows.Add(drDongIn);
                    dtInMaVach.AcceptChanges();
                }
            }

            var rpt = new rptInMaVach(dtInMaVach, txtTenDoanhNghiep.Text, txtDiaChi.Text);

            if (XtraMessageBox.Show("Bạn có muốn nạp lại vị trí từ file vị trí không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "(*.repx)|*.pepx;|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = false;

                // Call the ShowDialog method to show the dialog box.
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                string path = openFileDialog1.FileName;

                //PrintingSystem ps = new PrintingSystem();
                //// Load the document from a file.
                //ps.LoadDocument(path);
                //// Create an instance of the preview dialog.
                //PrintPreviewFormEx preview = new PrintPreviewFormEx();
                //// Load the report document into it.
                //preview.PrintingSystem = ps;
                //// Show the preview dialog.
                //preview.Show();

                rpt.LoadLayout(path);
            }

            rpt.AssignPrintTool(new ReportPrintTool(rpt));
            rpt.CreateDocument();
            rpt.ShowPreview();
        }

        private void bbiDocExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.xls, *.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            // Call the ShowDialog method to show the dialog box.
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;

            string path = openFileDialog1.FileName;
            Import_To_Grid(path, Path.GetExtension(path), "Yes");

        }

        private void Import_To_Grid(string FilePath, string Extension, string isHDR)
        {
            /*
  
  
       "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};
                         Extended Properties='Excel 8.0;HDR={1}'"
  
       "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};
                         Extended Properties='Excel 8.0;HDR={1}'"

             */

            

            
            

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

            //Bind Data to GridView
            //gbList.Caption = Path.GetFileName(FilePath);
            //GridView1.DataSource = dt;
            //GridView1.DataBind();

            foreach (DataRow dr in dt.Rows)
            {
                dsDanhSachHangHoa.InMaVach.AddInMaVachRow
                    (
                    string.IsNullOrEmpty(dr[0].ToString()) ? "M" + DateTime.Now.ToShortDateString() : dr[0].ToString(),
                    dr[1].ToString(),
                    Convert.ToDecimal(dr[2]),
                    Convert.ToDecimal(dr[3]),
                    Convert.ToDecimal(dr[4]),
                    Convert.ToDecimal(dr[5]),
                    dr[6].ToString(),
                    dr[7].ToString(),
                    dr[8].ToString(),
                    Convert.ToInt32(dr[9])
                    );
            }

            //dsDanhSachHangHoa.InMaVach.Merge(dt);
        }

        private void bbiTaoMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtNgay.DateTime = DateTime.Now;
            dsDanhSachHangHoa.InMaVach.Rows.Clear();
        }

        private void bbiCanhMaVach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dtInMaVach = new DataTable();

            dtInMaVach = dsDanhSachHangHoa.InMaVach.Copy();
            dtInMaVach.Rows.Clear();

            foreach (DataRow drDong in dsDanhSachHangHoa.InMaVach)
            {
                for (int i = 0; i < Convert.ToInt32(drDong[colSoLuongTem.FieldName]); i++)
                {
                    DataRow drDongIn = dtInMaVach.NewRow();

                    drDongIn[colMaVach.FieldName] = drDong[colMaVach.FieldName];
                    drDongIn[colTenHang.FieldName] = drDong[colTenHang.FieldName];
                    drDongIn[colTongTrongLuong.FieldName] = drDong[colTongTrongLuong.FieldName];
                    drDongIn[colTrongLuong.FieldName] = drDong[colTrongLuong.FieldName];
                    drDongIn[colTienCong.FieldName] = drDong[colTienCong.FieldName];
                    drDongIn[colHot.FieldName] = drDong[colHot.FieldName];
                    drDongIn[colLoaiVang.FieldName] = drDong[colLoaiVang.FieldName];
                    drDongIn[colNhaCungCap.FieldName] = drDong[colNhaCungCap.FieldName];
                    drDongIn[colHamLuongPho.FieldName] = drDong[colHamLuongPho.FieldName];
                    drDongIn[colSoLuongTem.FieldName] = drDong[colSoLuongTem.FieldName];

                    dtInMaVach.Rows.Add(drDongIn);
                    dtInMaVach.AcceptChanges();
                }
            }

            var rpt = new rptInMaVach(dtInMaVach, txtTenDoanhNghiep.Text, txtDiaChi.Text);

            if (XtraMessageBox.Show("Bạn có muốn nạp lại vị trí từ file vị trí không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "(*.repx)|*.repx;|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 1;
                openFileDialog1.Multiselect = false;

                // Call the ShowDialog method to show the dialog box.
                if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                string path = openFileDialog1.FileName;


                //var report = new rptInMaVach(dtInMaVach, txtTenDoanhNghiep.Text);
                //report.PrintingSystem.LoadDocument(path);
                rpt.LoadLayout(path);
                //rpt.CreateDocument();
                //rpt.ShowDesigner();

                //PrintingSystem ps = new PrintingSystem();
                //// Load the document from a file.
                //ps.LoadDocument(path);
                //// Create an instance of the preview dialog.
                //PrintPreviewFormEx preview = new PrintPreviewFormEx();
                //// Load the report document into it.
                //preview.PrintingSystem = ps;
                //// Show the preview dialog.
                //preview.ShowDialog();

                //rpt.PrintingSystem.LoadDocument(path);
            }
            //rpt.AssignPrintTool(new ReportPrintTool(rpt));
            //rpt.CreateDocument();
            //rpt.ShowPreview();
            rpt.ShowDesigner();
        }

        private void bbiKetNoiCan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var _frmKetNoiCan = new frmKetNoiCan(cbCongCom.Text, txtTenDoanhNghiep.Text, txtDiaChi.Text);
            _frmKetNoiCan.ChoIn += _frmKetNoiCan_ChoIn;
            _frmKetNoiCan.ShowDialog();
        }

        private void _frmKetNoiCan_ChoIn(object sender, string mavach, string tenhang, decimal tongtrongluong, decimal trongluong, decimal hot, string nhacungcap, string hamluongpho, decimal tiencong, int soluongtem)
        {
            dsDanhSachHangHoa.InMaVach.AddInMaVachRow(mavach, tenhang, tongtrongluong, trongluong, tiencong, hot, "", nhacungcap, hamluongpho, soluongtem);
        }
    }
}
