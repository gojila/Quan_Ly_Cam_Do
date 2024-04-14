using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using Phan_Mem_Quan_Ly_In_Tem.MauTemIn;
using Phan_Mem_Quan_Ly_In_Tem.XuLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Phan_Mem_Quan_Ly_In_Tem
{
    public partial class frmInTem : XtraForm
    {

        public delegate void ChoInEventHander(object sender, string mavach, string tenhang, decimal tongtrongluong, decimal trongluong, decimal hot, string nhacungcap, string hamluongpho, decimal tiencong, int soluongtem);

        public event ChoInEventHander ChoIn;
        private void RaiseChoInEventHander(string mavach, string tenhang, decimal tongtrongluong, decimal trongluong, decimal hot, string nhacungcap, string hamluongpho, decimal tiencong, int soluongtem)
        {
            if (ChoIn != null)
            {
                ChoIn(this, mavach, tenhang, tongtrongluong, trongluong, hot, nhacungcap, hamluongpho, tiencong, soluongtem);
            }
        }

        public delegate void XemEventHander();

        public event XemEventHander Xem;
        private void RaiseXemEventHander()
        {
            if (Xem != null)
            {
                Xem();
            }
        }

        string duongDanFileExcel = "";
        string tenMayIn = "";
        string tenTiem = "";
        string diaChiTiem = "";
        string dinhDang = "";
        clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();

        public frmInTem()
        {
            InitializeComponent();
            TaoMoi();
        }

        public frmInTem(string _tenTiemNCC, string _diaChiNCC, string tenCongCOM, string _duongDanFileExcel, string _tenMayIn, string _dinhDang)
        {
            InitializeComponent();
            duongDanFileExcel = _duongDanFileExcel;

            txtTenTiemNCC.Text = _tenTiemNCC;
            txtDiaChiNCC.Text = _diaChiNCC;
            txtDinhDang.Text = _dinhDang;

            tenMayIn = _tenMayIn;
            tenTiem = _tenTiemNCC;
            diaChiTiem = _diaChiNCC;
            dinhDang = _dinhDang;

            TaoMoi();

            if (!Com.IsOpen && !string.IsNullOrEmpty(tenCongCOM))
            {
                try
                {
                    Com.PortName = tenCongCOM;
                    Com.Open();
                    Com.DataReceived += Com_DataReceived;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //txtCanNang.EditValueChanged += txtCanNang_EditValueChanged;
        }

        //void txtCanNang_EditValueChanged(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
            
        //}

        public frmInTem(string _tenTiem, string _diaChi, string _tenTiemNCC, string _diaChiNCC, string tenCongCOM, string _tenMayIn, string _duongDanFileExcel, string maVach, string tenHang, decimal tongTrongLuong, decimal trongLuong, decimal hot, decimal tienCong, string nhaCungCap, string hamLuongPho, int soLuongTem, string dinhDang)
        {
            InitializeComponent();
            duongDanFileExcel = _duongDanFileExcel;
            txtTenTiemNCC.Text = _tenTiemNCC;
            txtDiaChiNCC.Text = _diaChiNCC;
            tenMayIn = _tenMayIn;
            tenTiem = _tenTiem;
            diaChiTiem = _diaChi;
            TaoMoi();

            if (!Com.IsOpen && !string.IsNullOrEmpty(tenCongCOM))
            {
                try
                {
                    Com.PortName = tenCongCOM;
                    Com.Open();
                    Com.DataReceived += Com_DataReceived;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            txtMaVach.Text = maVach;
            txtTenHang.Text = tenHang;
            txtTongTrongLuong.Value = tongTrongLuong;
            txtTrongLuong.Value = trongLuong;
            txtHot.Value = hot;
            txtTienCong.Value = tienCong;
            txtNhaCungCapCode.Text = nhaCungCap;
            txtHamLuongPho.Text = hamLuongPho;
            txtSoLuongTem.Value = soLuongTem;
            txtDinhDang.Text = dinhDang;
        }

        private void TaoMoi()
        {
            txtMaVach.Text = "M" + String.Format("{0:ddMMyyyy}", DateTime.Now);
            napDanhSachTenTiemVaDiaChi();
            var dt = new DataTable("ThongTinTiem");
            
            //dt.Columns.Add("TenTiem");
            //dt.Columns.Add("DiaChi");
            


            //var fi = new FileInfo(Application.StartupPath + "\\ThongTinTiem.xml");
            //if (!fi.Exists) return;

            //dt.ReadXml(Application.StartupPath + "\\ThongTinTiem.xml");
            //try
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        //txtUserName.Text = MyEncryption.Decrypt(dt.Rows[0]["user"].ToString(), "963147", true);
            //        //txtPassword.Text = MyEncryption.Decrypt(dt.Rows[0]["pass"].ToString(), "963147", true);

            //        txtTenTiem.Text = dt.Rows[0]["TenTiem"].ToString();
            //        txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void napDanhSachTenTiemVaDiaChi()
        {

            if (File.Exists(duongDanFileExcel))
            {
                clsXuLyDuLieu _xuLy = new clsXuLyDuLieu();
                //bbiChonFileDuLieu.EditValue = duongDanFileExcelMacDinh;
                DataTable dtDanhSachNhaCungCap = new DataTable();
                dtDanhSachNhaCungCap = _xuLy.docDanhSachNhaCungCapFileExcel(duongDanFileExcel, Path.GetExtension(duongDanFileExcel), "Yes");
                //MessageBox.Show(dtMaVachExcel.Rows.Count.ToString());
                //napDuLieuVaoLuoiTuFileExcel(dtMaVachExcel);

                //var adapterDiaChi = new DANH_SACH_DIA_CHITableAdapter();
                //adapterDiaChi.Connection.ConnectionString = SqlHelper.ConnectionString;
                //adapterDiaChi.ClearBeforeFill = true;
                //adapterDiaChi.Fill(dtDanhSachDiaChi);

                AutoCompleteStringCollection mangDanhSachNhaCungCap = new AutoCompleteStringCollection();
                AutoCompleteStringCollection mangDanhSachDiaChi = new AutoCompleteStringCollection();
                AutoCompleteStringCollection mangDanhSachTenTiem = new AutoCompleteStringCollection();

                if (dtDanhSachNhaCungCap != null && dtDanhSachNhaCungCap.Rows.Count > 0) 
                {
                    foreach (DataRow dr in dtDanhSachNhaCungCap.Rows)
                    {
                        mangDanhSachNhaCungCap.Add(dr["Nhà Cung Cấp"].ToString());
                        mangDanhSachDiaChi.Add(dr["Địa Chỉ"].ToString());
                        mangDanhSachTenTiem.Add(dr["Tên Tiệm"].ToString());
                    }
                }

                var txtNhaCungCap_AutoComplete = txtNhaCungCapCode.MaskBox;
                txtNhaCungCap_AutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtNhaCungCap_AutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtNhaCungCap_AutoComplete.AutoCompleteCustomSource = mangDanhSachNhaCungCap;

                var txtDiaChi_AutoComplete = txtDiaChiNCC.MaskBox;
                txtDiaChi_AutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtDiaChi_AutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtDiaChi_AutoComplete.AutoCompleteCustomSource = mangDanhSachDiaChi;

                var txtTenTiem_AutoComplete = txtTenTiemNCC.MaskBox;
                txtTenTiem_AutoComplete.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtTenTiem_AutoComplete.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtTenTiem_AutoComplete.AutoCompleteCustomSource = mangDanhSachTenTiem;
            }
            
        }
        private void DisplayText(string canNang)
        {
            BeginInvoke(new EventHandler(delegate
            {
                txtCanNang.Text = canNang;
                txtTongTrongLuong.Value = chuyenCanNang(canNang);
            }));
        }
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string canNang = "";
            try 
            {
                if (!Com.IsOpen)
                    return;

                if (Com != null && Com.IsOpen)
                {
                    canNang = Com.ReadLine();
                    //canNang = Com.ReadExisting();
                    //txtCanNang.Text = canNang;
                    //txtTongTrongLuong.Value = chuyenCanNang(canNang);
                    DisplayText(canNang);
                }
            }
            catch (System.IO.IOException error)
            {
                return;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            try 
            {
                if (Com != null && Com.IsOpen)
                {
                    Com.Close();
                    Com.Dispose();
                }
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmKetNoiCan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Com.IsOpen)
            {
                Com.Close();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (!kiemTraTruocKhiIn())
            {
                return;
            }
            var _clsXuLyDuLieu = new clsXuLyDuLieu();
            txtMaVach.Text = _clsXuLyDuLieu.generateUniqueIDByDateTime(txtTenHang.Text);
            var rptMaVach = new rptInTemNuTrang(tenTiem, diaChiTiem, txtTenTiemNCC.Text, txtDiaChiNCC.Text, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTongTrongLuong.Value, txtTienCong.Value, txtHot.Value, "", txtNhaCungCapCode.Text, txtHamLuongPho.Text, Convert.ToInt32(txtSoLuongTem.Value), txtTongTrongLuongChu.Text, txtTrongLuongChu.Text, txtHotChu.Text, Convert.ToInt32(txtSoNi.Value), txtKyHieuVang.Text);
            string filePath = @"rptInTemNuTrang.repx";
            if (!string.IsNullOrEmpty(txtMauTem.Text))
            {
                filePath = txtMauTem.Text;
            }
            if (File.Exists(filePath))
            {
                rptMaVach.LoadLayout(filePath);
                rptMaVach.Parameters["TenTiem"].Value = tenTiem;
                rptMaVach.Parameters["DiaChi"].Value = diaChiTiem;
            }

            rptMaVach.AssignPrintTool(new ReportPrintTool(rptMaVach));
            rptMaVach.CreateDocument();
            
            if(rdTuyChonIn.SelectedIndex == 0)
            {
                if(string.IsNullOrEmpty(tenMayIn))
                {
                    rptMaVach.ShowPreview();
                }
                else
                {
                    rptMaVach.Print(tenMayIn);
                }
            }
            else if (rdTuyChonIn.SelectedIndex == 1) 
            {
                rptMaVach.ShowPreview();
            }
            else if(rdTuyChonIn.SelectedIndex == 2)
            {
                rptMaVach.ShowDesigner();
            }

            try 
            {
                if (cbLuuSauKhiIn.Checked)
                {
                    _clsXuLyDuLieu.luuDuLieuExcel(duongDanFileExcel, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTrongLuong.Value, txtHot.Value, txtTienCong.Value, "", txtNhaCungCapCode.Text, txtHamLuongPho.Text, txtTenTiemNCC.Text, txtDiaChiNCC.Text, Convert.ToInt32(txtSoLuongTem.Value), Convert.ToInt32(txtSoNi.Value), txtKyHieuVang.Text);
                    RaiseXemEventHander();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (cbXoaTrongLuong.Checked)
            {
                txtTongTrongLuong.Value = 0;
                txtTrongLuong.Value = 0;
                txtHot.Value = 0;
            }
        }

        private void btnTuyChinh_Click(object sender, EventArgs e)
        {
            if(!kiemTraTruocKhiIn())
            {
                return;
            }
            var _clsXuLyDuLieu = new clsXuLyDuLieu();
            txtMaVach.Text = _clsXuLyDuLieu.generateUniqueIDByDateTime(txtTenHang.Text);
            var report = new rptInTemNuTrang(tenTiem, diaChiTiem, txtTenTiemNCC.Text, txtDiaChiNCC.Text, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTongTrongLuong.Value, txtTienCong.Value, txtHot.Value, "", txtNhaCungCapCode.Text, txtHamLuongPho.Text, Convert.ToInt32(txtSoLuongTem.Value), txtTongTrongLuongChu.Text, txtTrongLuongChu.Text, txtHotChu.Text, Convert.ToInt32(txtSoNi.Value), txtKyHieuVang.Text);
            string filePath = @"rptInTemNuTrang.repx";
            if (!string.IsNullOrEmpty(txtMauTem.Text)) 
            {
                filePath = txtMauTem.Text;
            }
            if (File.Exists(filePath))
            {
                report.LoadLayout(filePath);
                report.Parameters["TenTiem"].Value = tenTiem;
                report.Parameters["DiaChi"].Value = diaChiTiem;
            }
            ReportDesignTool dt = new ReportDesignTool(report);
            //ReportDesignTool dt = new ReportDesignTool(new rptInTemNuTrang(txtTenTiem.Text, txtDiaChi.Text, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTongTrongLuong.Value, txtTienCong.Value, txtHot.Value, "", txtNhaCungCap.Text, txtHamLuongPho.Text, Convert.ToInt32(txtSoLuongTem.Value), txtTongTrongLuongChu.Text, txtTrongLuongChu.Text, txtHotChu.Text));

            // Access the report's properties.
            dt.Report.DrawGrid = false;

            // Access the Designer form's properties.
            dt.DesignForm.SetWindowVisibility(DesignDockPanelType.FieldList | DesignDockPanelType.PropertyGrid, false);

            // Show the Designer form, modally.
            dt.ShowDesignerDialog();

            //var rptMaVach = new rptInTemNuTrang(txtTenTiem.Text, txtDiaChi.Text, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTongTrongLuong.Value, txtTienCong.Value, txtHot.Value, "", txtNhaCungCap.Text, txtHamLuongPho.Text, Convert.ToInt32(txtSoLuongTem.Value), txtTongTrongLuongChu.Text, txtTrongLuongChu.Text, txtHotChu.Text);
            //rptMaVach.AssignPrintTool(new ReportPrintTool(rptMaVach));
            //rptMaVach.CreateDocument();
            //rptMaVach.ShowDesigner();
            try
            {
                if (cbLuuSauKhiIn.Checked)
                {
                    _clsXuLyDuLieu.luuDuLieuExcel(duongDanFileExcel, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTrongLuong.Value, txtHot.Value, txtTienCong.Value, "", txtNhaCungCapCode.Text, txtHamLuongPho.Text, txtTenTiemNCC.Text, txtDiaChiNCC.Text, Convert.ToInt32(txtSoLuongTem.Value), Convert.ToInt32(txtSoNi.Value), txtKyHieuVang.Text);
                    RaiseXemEventHander();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaVach.Text = "M" + String.Format("{0:ddMMyyyy}", DateTime.Now);
            txtTenHang.Text = "";
            txtTongTrongLuong.Value = 0;
            txtTrongLuong.Value = 0;
            txtHot.Value = 0;
            txtNhaCungCapCode.Text = "";
            txtHamLuongPho.Text = "";
            txtTienCong.Value = 0;
            txtSoLuongTem.Value = 1;
            txtCanNang.Text = "0";
            cbLuuSauKhiIn.Checked = true;
        }

        //private void btnChoIn_Click(object sender, EventArgs e)
        //{
        //    RaiseChoInEventHander(txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTrongLuong.Value, txtHot.Value, txtNhaCungCap.Text, txtHamLuongPho.Text, txtTienCong.Value, Convert.ToInt32(txtSoLuongTem.Value));
        //    btnTaoMoi_Click(this, null);
        //}

        private void txtHot_EditValueChanged(object sender, EventArgs e)
        {
            txtTrongLuong.Value = txtTongTrongLuong.Value - txtHot.Value;
            docCanNangRaChu();
        }

        private void txtTongTrongLuong_EditValueChanged(object sender, EventArgs e)
        {
            txtTrongLuong.Value = txtTongTrongLuong.Value - txtHot.Value;
            docCanNangRaChu();
        }

        public decimal chuyenCanNang(string giaTriCan)
        {
            //  0.014785TT
            giaTriCan = giaTriCan.Replace(System.Environment.NewLine, "");
            string chuoi = giaTriCan;
            var laySo = (from t in chuoi
                         where char.IsDigit(t) || t.Equals('.')
                         select t).ToArray();

            decimal phanNguyen = 0;
            decimal phanThapPhan = 0;

            string[] mangChuSo = (new string(laySo)).Split('.');

            if (mangChuSo.Length > 0) 
            {
                phanNguyen = Convert.ToDecimal(mangChuSo[0]);
            }
            if (mangChuSo.Length > 1) 
            {
                phanThapPhan = Convert.ToDecimal(mangChuSo[1]) / Convert.ToDecimal(Math.Pow(10, mangChuSo[1].ToString().Length));
            }
            decimal giaTri = 0;
            giaTri = phanNguyen + phanThapPhan;

            return (giaTri * 10);

            //string chuoiGiaTri = giaTriCan.Replace("TT", "").Trim();
            //chuoiGiaTri = chuoiGiaTri.Replace(".", ",");
            //chuoiGiaTri = chuoiGiaTri.Replace(" ", "");
            //MessageBox.Show(chuoiGiaTri);
            //decimal giaTri = 0;
            //if (!decimal.TryParse(chuoiGiaTri, out giaTri))
            //{
            //    MessageBox.Show("Giá trị cân không hợp lệ. " + giaTriCan + " ... " + chuoiGiaTri);
            //}

            //return (giaTri * 10);
        }

        

        private void txtTrongLuong_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            docCanNangRaChu();
        }

        private void docCanNangRaChu()
        {
            txtTongTrongLuongChu.Text = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(txtTongTrongLuong.Value, txtDinhDang.Text);
            txtTrongLuongChu.Text = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(txtTrongLuong.Value, txtDinhDang.Text);
            txtHotChu.Text = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(txtHot.Value, txtDinhDang.Text);
        }

        private bool kiemTraTruocKhiIn()
        {
            if (txtTienCong.Value <= 0)
            {
                MessageBox.Show("Chưa nhập tiền công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTienCong.Focus();
                return false;
            }

            if(string.IsNullOrEmpty(txtTenHang.Text.Trim()))
            {
                MessageBox.Show("Chưa nhập tên hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHang.Focus();
                return false;
            }

            if (txtTongTrongLuong.Value <= 0)
            {
                if (MessageBox.Show("Chưa nhập tổng trọng lượng. Bạn có muốn in hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No) 
                {
                    txtTongTrongLuong.Focus();
                    return false;
                }
            }

            if (txtTrongLuong.Value <= 0)
            {
                if (MessageBox.Show("Chưa nhập trọng lượng. Bạn có muốn in hay không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                {
                    txtTrongLuong.Focus();
                    return false;
                }
            }

            return true;
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(textEdit1.Text);
            ////0.014785TT
            //string canNang = "";
            //canNang = textEdit1.Text;
            //txtCanNang.Text = canNang;
            //txtTongTrongLuong.Value = chuyenCanNang(canNang);
        }

        private void txtTrongLuong_EditValueChanged(object sender, EventArgs e)
        {
            txtTrongLuongChu.Text = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(txtTrongLuong.Value, txtDinhDang.Text);
        }

        private void txtHot_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try 
            {
                if (e.Button.Tag.ToString() == "Xoa")
                {
                    txtHot.Value = 0;
                }
            }
            catch (Exception ex) 
            {
                return;
            }
        }

        private void txtTienCong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try 
            {
                if (e.Button.Tag.ToString() == "Xoa")
                {
                    txtTienCong.Value = 0;
                }
            }
            catch (Exception ex) 
            {
                return;
            }
        }

        private void txtTrongLuong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try 
            {
                if (e.Button.Tag.ToString() == "Xoa")
                {
                    txtTrongLuong.Value = 0;
                }
            }
            catch (Exception ex) 
            {
                return;
            }
        }

        private void txtTongTrongLuong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Tag.ToString() == "Xoa")
                {
                    txtTongTrongLuong.Value = 0;
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnXoaTrongLuong_Click(object sender, EventArgs e)
        {
            txtTongTrongLuong.Value = 0;
            txtTrongLuong.Value = 0;
            txtHot.Value = 0;
        }

        private void txtNhaCungCap_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Chon")
            {
                var frmChonNhaCungCap = new frmDanhSachNhaCungCap(duongDanFileExcel);
                frmChonNhaCungCap.StartPosition = FormStartPosition.CenterParent;
                frmChonNhaCungCap.ChonNhaCungCap += (nhacungcap, tentiem, diachi) => 
                {
                    txtNhaCungCapCode.Text = nhacungcap;
                    txtTenTiemNCC.Text = tentiem;
                    txtDiaChiNCC.Text = diachi;
                };
                frmChonNhaCungCap.ShowDialog();   
            }
        }

        private void txtDiaChi_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Chon")
            {
                var frmChonNhaCungCap = new frmDanhSachNhaCungCap(duongDanFileExcel);
                frmChonNhaCungCap.StartPosition = FormStartPosition.CenterParent;
                frmChonNhaCungCap.ChonNhaCungCap += (nhacungcap, tentiem, diachi) =>
                {
                    txtNhaCungCapCode.Text = nhacungcap;
                    txtTenTiemNCC.Text = tentiem;
                    txtDiaChiNCC.Text = diachi;
                };
                frmChonNhaCungCap.ShowDialog();
            }
        }

        private void txtTenTiem_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag.ToString() == "Chon")
            {
                var frmChonNhaCungCap = new frmDanhSachNhaCungCap(duongDanFileExcel);
                frmChonNhaCungCap.StartPosition = FormStartPosition.CenterParent;
                frmChonNhaCungCap.ChonNhaCungCap += (nhacungcap, tentiem, diachi) =>
                {
                    txtNhaCungCapCode.Text = nhacungcap;
                    txtTenTiemNCC.Text = tentiem;
                    txtDiaChiNCC.Text = diachi;
                };
                frmChonNhaCungCap.ShowDialog();
            }
        }

        private void txtMauTem_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                var _frmMauTemIn = new frmMauTemIn(duongDanFileExcel);
                _frmMauTemIn.SetSelectState();
                _frmMauTemIn.Select += (ss, path) => 
                {
                    txtMauTem.Text = path;
                };
                _frmMauTemIn.ShowDialog();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmInTem_Load(object sender, EventArgs e)
        {
            try 
            {
                clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();
                txtMauTem.Text = _clsXuLyDuLieu.getMauTemInMacDinh(duongDanFileExcel);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDinhDang_EditValueChanged(object sender, EventArgs e)
        {
            try 
            {
                docCanNangRaChu();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
