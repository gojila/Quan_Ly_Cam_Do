using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Newtonsoft.Json;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Bussiness;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe.Report;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe
{
    public partial class frmPhieuCanXe : XtraForm
    {
        public long Id = 0;
        public frmPhieuCanXe()
        {
            InitializeComponent();
            bbiNew_ItemClick(this, null);

            bm.SetPopupContextMenu(gcList, pm);
        }

        private void bbiNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                txtKhachHang.Text = "";
                txtSoXe.Text = "";
                txtSoPhieu.Text = "";
                dtNgay.DateTime = DateTime.Now;
                txtLoaiHang.Text = "";
                txtGhiChu.Text = "";
                cbXuatNhap.SelectedText = "";
                txtGio.Time = DateTime.Now;

                dtNgayCan1.EditValue = DateTime.Now;
                dtNgayCan2.EditValue = null;

                calCanLan1.Value = 0;
                calCanLan2.Value = 0;
                calTrongLuongHang.Value = 0;

                cbXuatNhap.SelectedIndex = 0;

                txtSoPhieu.Text = SqlHelper.GenCode("PhieuCan", "SoPhieu", "CAN", 6);

                this.Id = 0;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiScale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Scale);
        }

        private void bbiScale1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Scale_1);
        }

        private void bbiScale2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Scale_2);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Save);
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string item = cbOption.SelectedItem.ToString();
                switch (item)
                {
                    case "Tháng 1":
                        Set_Date(1);
                        break;
                    case "Tháng 2":
                        Set_Date(2);
                        break;
                    case "Tháng 3":
                        Set_Date(3);
                        break;
                    case "Tháng 4":
                        Set_Date(4);
                        break;
                    case "Tháng 5":
                        Set_Date(5);
                        break;
                    case "Tháng 6":
                        Set_Date(6);
                        break;
                    case "Tháng 7":
                        Set_Date(7);
                        break;
                    case "Tháng 8":
                        Set_Date(8);
                        break;
                    case "Tháng 9":
                        Set_Date(9);
                        break;
                    case "Tháng 10":
                        Set_Date(10);
                        break;
                    case "Tháng 11":
                        Set_Date(11);
                        break;
                    case "Tháng 12":
                        Set_Date(12);
                        break;
                    case "Tháng này":
                        Set_Current_Month();
                        break;
                    case "Quý này":
                        Set_Current_Quater();
                        break;
                    case "Quý 1":
                        Set_Quater(1);
                        break;
                    case "Quý 2":
                        Set_Quater(2);
                        break;
                    case "Quý 3":
                        Set_Quater(3);
                        break;
                    case "Quý 4":
                        Set_Quater(4);
                        break;
                    case "Năm nay":
                        Set_Current_Year();
                        break;
                    case "Hôm nay":
                        dtFromDate.DateTime = DateTime.Now;
                        dtToDate.DateTime = DateTime.Now;
                        break;
                    case "Tất cả":
                        dtFromDate.DateTime = (DateTime)SqlDateTime.MinValue;
                        dtToDate.DateTime = (DateTime)SqlDateTime.MaxValue;
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPhieuCanXe_Load(object sender, EventArgs e)
        {
            try
            {
                this.cbOption.Properties.Items.AddRange(new object[] {
                    "Tất cả",
                    "Hôm nay",
                    "Tháng này",
                    "Quý này",
                    "Năm nay",
                    "Quý 1",
                    "Quý 2",
                    "Quý 3",
                    "Quý 4",
                    "Tháng 1",
                    "Tháng 2",
                    "Tháng 3",
                    "Tháng 4",
                    "Tháng 5",
                    "Tháng 6",
                    "Tháng 7",
                    "Tháng 8",
                    "Tháng 9",
                    "Tháng 10",
                    "Tháng 11",
                    "Tháng 12"});

                this.cbOption.SelectedIndex = 1;

                comboBoxEdit1_SelectedIndexChanged(this, null);

                btnTim_Click(this, null);

                if (!serialPort1.IsOpen)
                {
                    //serialPort1.PortName = cbCongCOM.Text;
                    //serialPort1.BaudRate = 1200;
                    serialPort1.Open();
                    txtCanNang.EditValue = 0;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Set_Date(int month)
        {
            DateTime tu = new DateTime(DateTime.Now.Year, month, 1);
            DateTime den = tu.AddMonths(1).AddDays(-1);

            dtFromDate.DateTime = tu;
            dtToDate.DateTime = den;
        }

        void Set_Current_Month()
        {
            DateTime tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime den = tu.AddMonths(1).AddDays(-1);

            dtFromDate.DateTime = tu;
            dtToDate.DateTime = den;
        }

        void Set_Current_Quater()
        {
            var currentMonth = DateTime.Now.Month;
            Set_Quater(currentMonth);
        }

        void Set_Quater(int month)
        {
            //var currentMonth = DateTime.Now.Month;
            int quater = month / 3;

            DateTime tu = new DateTime(DateTime.Now.Year, ((quater * 3) + 1), 1);
            DateTime den = tu.AddMonths(3).AddDays(-1);

            dtFromDate.DateTime = tu;
            dtToDate.DateTime = den;
        }

        void Set_Current_Year()
        {
            DateTime tu = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime den = tu.AddYears(1).AddDays(-1);

            dtFromDate.DateTime = tu;
            dtToDate.DateTime = den;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                phieuCanTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
                phieuCanTableAdapter.ClearBeforeFill = true;
                phieuCanTableAdapter.Fill(dsCanXe.PhieuCan, dtFromDate.DateTime, dtToDate.DateTime);

                gbList.BestFitColumns();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                int[] selectedRows = gbList.GetSelectedRows();

                if (selectedRows.Length > 0)
                {
                    var db = new PhanMemCanXeTaiEntities1();
                    db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                    for (int i = 0; i < selectedRows.Length; i++)
                    {
                        var arg = gbList.GetRowCellValue(i, colId);
                        if (arg != null)
                        {
                            var tempId = Convert.ToInt32(arg);
                            var phieuCan = (from item in db.PhieuCan
                                            where item.Id == tempId && !item.IsDeleted.Value
                                            select item).FirstOrDefault();
                            if (phieuCan != null)
                            {
                                var _rptCanXe_Master = new rptCanXe();

                                _rptCanXe_Master.Parameters["TenCongTy"].Value = SqlHelper.CompanyName;
                                _rptCanXe_Master.Parameters["DiaChi"].Value = SqlHelper.Address;
                                _rptCanXe_Master.Parameters["DienThoai"].Value = SqlHelper.Phone;
                                _rptCanXe_Master.Parameters["Fax"].Value = SqlHelper.Fax;

                                _rptCanXe_Master.Parameters["SoPhieu"].Value = phieuCan.SoPhieu;
                                _rptCanXe_Master.Parameters["Ngay"].Value = phieuCan.Ngay.Value.ToString("dd/MM/yyyy");
                                _rptCanXe_Master.Parameters["KhachHang_TenKhachHang"].Value = phieuCan.KhachHang;
                                _rptCanXe_Master.Parameters["KhachHang_DiaChi"].Value = "";
                                _rptCanXe_Master.Parameters["BienSoXe"].Value = phieuCan.SoXe;
                                _rptCanXe_Master.Parameters["LoaiHang"].Value = phieuCan.Loaihang;

                                _rptCanXe_Master.Parameters["XuatNhap"].Value = phieuCan.XuatNhap;
                                _rptCanXe_Master.Parameters["ThoiGianCanLan1"].Value = phieuCan.NgayCan1.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                                _rptCanXe_Master.Parameters["ThoiGianCanLan2"].Value = phieuCan.NgayCan2.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                                _rptCanXe_Master.Parameters["TrongLuongCanLan1"].Value = phieuCan.TrongLuongCan1.Value.ToString("##,##0.###");
                                _rptCanXe_Master.Parameters["TrongLuongCanLan2"].Value = phieuCan.TrongLuongCan2.Value.ToString("##,##0.###");

                                _rptCanXe_Master.Parameters["TrongLuongHangHoa"].Value = phieuCan.TrongLuongHang.Value.ToString("##,##0.###");

                                _rptCanXe_Master.Parameters["BarCode"].Value = JsonConvert.SerializeObject(phieuCan);
                                
                                _rptCanXe_Master.AssignPrintTool(new ReportPrintTool(_rptCanXe_Master));
                                _rptCanXe_Master.CreateDocument();
                                ReportPrintTool printTool = new ReportPrintTool(_rptCanXe_Master);
                                printTool.ShowPreview();
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc là muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    return;

                gbList.Focus();

                int[] selectedRows = gbList.GetSelectedRows();

                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                for (int i = selectedRows.Length; i > 0; i--)
                {
                    var arg = gbList.GetRowCellValue(selectedRows[i - 1], colId);
                    if (arg == null)
                        continue;
                    var IdPhieuCan = Convert.ToInt64(arg);
                    var items = (from item in db.PhieuCan
                                 where item.Id == IdPhieuCan && !item.IsDeleted.Value
                                 select item).FirstOrDefault();
                    if (items != null)
                    {
                        items.IsDeleted = true;
                        items.UpdatedDate = DateTime.Now;

                        db.SaveChanges();
                    }
                }

                btnTim_Click(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //txtGio.Text = String.Format("{0:HH:mm:ss tt}", DateTime.Now);
                txtGio.Time = DateTime.Now;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Save(int ScaleTypeSave)
        {
            try
            {
                if (!Validate())
                {
                    return false;
                }

                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                decimal tempDec = 0;
                var now = DateTime.Now;

                if (this.Id == 0)
                {
                    var item = new PhieuCan();

                    item.CreatedDate = DateTime.Now;
                    item.CreatedUser = 1;
                    item.GhiChu = txtGhiChu.Text;
                    item.IsDeleted = false;
                    item.KhachHang = txtKhachHang.Text;

                    item.Loaihang = txtLoaiHang.Text;
                    item.Ngay = dtNgay.DateTime;
                    item.SoPhieu = txtSoPhieu.Text;
                    item.SoXe = txtSoXe.Text;
                    item.Status = 1;

                    item.UpatedUser = 1;
                    item.UpdatedDate = DateTime.Now;
                    item.XuatNhap = cbXuatNhap.SelectedText;

                    if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_1)
                    {
                        item.NgayCan1 = dtNgay.DateTime;
                        item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                        item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                    }
                    else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_2)
                    {
                        item.NgayCan2 = dtNgay.DateTime;
                        item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                        item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                    }
                    else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale)
                    {
                        if (item.NgayCan1 == null || item.TrongLuongCan1 == null)
                        {
                            item.NgayCan1 = new DateTime(dtNgay.DateTime.Year, dtNgay.DateTime.Month, dtNgay.DateTime.Day, now.Hour, now.Minute, now.Second);
                            item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                            item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                        }
                        else if (item.NgayCan2 == null || item.TrongLuongCan2 == null)
                        {
                            item.NgayCan2 = new DateTime(dtNgay.DateTime.Year, dtNgay.DateTime.Month, dtNgay.DateTime.Day, now.Hour, now.Minute, now.Second); ;
                            item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                            item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                        }
                    }
                    else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Save)
                    {
                        item.NgayCan1 = dtNgay.DateTime;
                        item.NgayCan2 = dtNgay.DateTime;

                        item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                        item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                        item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                    }

                    db.PhieuCan.Add(item);
                }
                else
                {
                    var item = (from pc in db.PhieuCan
                                where pc.Id == this.Id && !pc.IsDeleted.Value
                                select pc).FirstOrDefault();
                    if (item != null)
                    {
                        item.GhiChu = txtGhiChu.Text;
                        item.KhachHang = txtKhachHang.Text;
                        item.Loaihang = txtLoaiHang.Text;
                        item.Ngay = dtNgay.DateTime;
                        item.SoPhieu = txtSoPhieu.Text;

                        item.SoXe = txtSoXe.Text;
                        item.Status = 1;
                        item.UpatedUser = 1;
                        item.UpdatedDate = DateTime.Now;
                        item.XuatNhap = cbXuatNhap.SelectedText;

                        if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_1)
                        {
                            item.NgayCan1 = new DateTime(dtNgay.DateTime.Year, dtNgay.DateTime.Month, dtNgay.DateTime.Day, now.Hour, now.Minute, now.Second);
                            item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                            item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                        }
                        else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_2)
                        {
                            item.NgayCan2 = new DateTime(dtNgay.DateTime.Year, dtNgay.DateTime.Month, dtNgay.DateTime.Day, now.Hour, now.Minute, now.Second); ;
                            item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                            item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                        }
                        else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale)
                        {
                            if (item.NgayCan1 == null || item.TrongLuongCan1 == null)
                            {
                                item.NgayCan1 = new DateTime(dtNgay.DateTime.Year, dtNgay.DateTime.Month, dtNgay.DateTime.Day, now.Hour, now.Minute, now.Second); ;
                                item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                            }
                            else if (item.NgayCan2 == null || item.TrongLuongCan2 == null)
                            {
                                item.NgayCan2 = new DateTime(dtNgay.DateTime.Year, dtNgay.DateTime.Month, dtNgay.DateTime.Day, now.Hour, now.Minute, now.Second); ;
                                item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                            }
                        }
                        else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Save)
                        {
                            item.NgayCan1 = dtNgayCan1.DateTime;
                            item.NgayCan2 = dtNgayCan2.DateTime;

                            item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                            item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                            item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Không tìm thấy phiếu cân này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                
                db.SaveChanges();

                XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bbiNew_ItemClick(this, null);
                btnTim_Click(this, null);

                return true;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private new bool Validate()
        {
            try
            {
                if (string.IsNullOrEmpty(txtKhachHang.Text))
                {
                    XtraMessageBox.Show(this, "Vui lòng nhập tên khách hàng !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKhachHang.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtSoXe.Text))
                {
                    XtraMessageBox.Show(this, "Vui lòng nhập số xe !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoXe.Focus();
                    return false;
                }

                if (string.IsNullOrEmpty(txtSoPhieu.Text))
                {
                    XtraMessageBox.Show(this, "Vui lòng nhập số phiếu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSoPhieu.Focus();
                    return false;
                }

                if (dtNgay.EditValue == null)
                {
                    XtraMessageBox.Show(this, "Vui lòng chọn ngày !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtNgay.Focus();
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selectedRows = gbList.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    var db = new PhanMemCanXeTaiEntities1();
                    db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;
                    var arg = gbList.GetRowCellValue(selectedRows[0], colId);
                    if (arg != null)
                    {
                        var IdPhieuCan = Convert.ToInt64(arg);
                        var item = (from pc in db.PhieuCan
                                    where pc.Id == IdPhieuCan && !pc.IsDeleted.Value
                                    select pc).FirstOrDefault();
                        if (item != null)
                        {
                            txtKhachHang.Text = item.KhachHang;
                            txtLoaiHang.Text = item.Loaihang;
                            cbXuatNhap.SelectedText = item.XuatNhap;
                            txtSoXe.Text = item.SoXe;

                            dtNgayCan1.EditValue = item.NgayCan1;
                            dtNgayCan2.EditValue = item.NgayCan2;
                            calCanLan1.EditValue = item.TrongLuongCan1;
                            calCanLan2.EditValue = item.TrongLuongCan2;
                            calTrongLuongHang.EditValue = item.TrongLuongHang;
                            txtGhiChu.Text = item.GhiChu;

                            txtSoPhieu.Text = item.SoPhieu;
                            dtNgay.EditValue = item.Ngay;

                        }
                        else
                        {
                            XtraMessageBox.Show(this, "Không tìm thấy phiếu cân này !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            btnTim_Click(this, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiScale2_Grid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ScaleGrid((int)ScaleTypeSaveEnum.Scale_2);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bbiScale1_Grid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ScaleGrid((int)ScaleTypeSaveEnum.Scale_1);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiScale_Grid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.ScaleGrid((int)ScaleTypeSaveEnum.Scale);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnDelete_Click(this, null);
        }

        private bool ScaleGrid(int ScaleTypeSave)
        {
            try
            {
                int[] selectedRows = gbList.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    var db = new PhanMemCanXeTaiEntities1();
                    db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                    var arg = gbList.GetRowCellValue(selectedRows[0], colId);
                    if (arg != null)
                    {
                        var IdPhieuCan = Convert.ToInt64(arg);
                        var item = (from pc in db.PhieuCan
                                    where pc.Id == IdPhieuCan && !pc.IsDeleted.Value
                                    select pc).FirstOrDefault();
                        if (item != null)
                        {
                            decimal tempDec = 0;
                            if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_1)
                            {
                                item.NgayCan1 = dtNgay.DateTime;
                                //item.NgayCan2 = dtNgay.DateTime;

                                item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                //item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                            }
                            else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_2)
                            {
                                //item.NgayCan1 = dtNgay.DateTime;
                                item.NgayCan2 = dtNgay.DateTime;

                                //item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                            }
                            else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale)
                            {
                                if (item.NgayCan1 == null || item.TrongLuongCan1 == null)
                                {
                                    item.NgayCan1 = dtNgay.DateTime;
                                    //item.NgayCan2 = dtNgay.DateTime;

                                    item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                    //item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                    item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                                }
                                else if (item.NgayCan2 == null || item.TrongLuongCan2 == null)
                                {
                                    //item.NgayCan1 = dtNgay.DateTime;
                                    item.NgayCan2 = dtNgay.DateTime;

                                    //item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                    item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                    item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                                }
                            }

                            item.UpdatedDate = DateTime.Now;
                            item.UpatedUser = 1;

                            db.SaveChanges();

                            XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnTim_Click(this, null);
                        }
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadExisting();
                decimal tempDec = 0;
                decimal canNang = Decimal.TryParse(indata, out tempDec) ? Convert.ToDecimal(indata) : 0;
                txtCanNang.EditValue = canNang;
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPhieuCanXe_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void calCanLan2_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                calTrongLuongHang.EditValue = Math.Abs(Convert.ToDecimal(calCanLan1.EditValue) - Convert.ToDecimal(calCanLan2.EditValue));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calCanLan1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                calTrongLuongHang.EditValue = Math.Abs(Convert.ToDecimal(calCanLan1.EditValue) - Convert.ToDecimal(calCanLan2.EditValue));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiTim_Grid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btnTim_Click(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiIn_Grid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                btnPrint_Click(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
