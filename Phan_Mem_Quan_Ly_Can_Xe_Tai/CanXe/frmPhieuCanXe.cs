using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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

        public void SetEdit(long Id)
        {
            try
            {
                this.Id = Id;
                if (this.Id != 0)
                {
                    var db = new PhanMemCanXeTaiEntities1();
                    db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;
                    var item = (from pc in db.PhieuCan
                                where pc.Id == this.Id && !pc.IsDeleted.Value
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
                else
                {
                    XtraMessageBox.Show(this, "Không tìm thấy mã" +
                        " phiếu cân này !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnTim_Click(this, null);
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddNew()
        {
            try
            {
                bbiNew_ItemClick(this, null);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                LoadAutoComplete();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiScale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Scale, false);
        }

        private void bbiScale1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Scale_1, false);
        }

        private void bbiScale2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Scale_2, false);
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save((int)ScaleTypeSaveEnum.Save, false);
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
                    serialPort1.PortName = SqlHelper.ComPort;
                    serialPort1.BaudRate = SqlHelper.BaudRate;
                    serialPort1.Open();
                    txtCanNang.EditValue = 0;
                }

                gbList.ShownEditor += (ss, ee) =>
                {
                    var view = ss as GridView;
                    view.ActiveEditor.DoubleClick += (_ss, _ee)=> 
                    {
                        bbiEdit_ItemClick(this, null);
                    };
                };
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

                    var _rptCanXe_Master = new rptCanXe();
                    bool isSetMaster = false;

                    for (int i = 0; i < selectedRows.Length; i++)
                    {
                        var arg = gbList.GetRowCellValue(selectedRows[i], colId);
                        if (arg != null)
                        {
                            var tempId = Convert.ToInt32(arg);
                            var phieuCan = (from item in db.PhieuCan
                                            where item.Id == tempId && !item.IsDeleted.Value
                                            select item).FirstOrDefault();
                            if (phieuCan != null)
                            {
                                if (!isSetMaster)
                                {
                                    SetReport(phieuCan, ref _rptCanXe_Master);
                                    _rptCanXe_Master.CreateDocument();

                                    isSetMaster = true;
                                }
                                else
                                {
                                    var _rptCanXe = new rptCanXe();
                                    SetReport(phieuCan, ref _rptCanXe);
                                    _rptCanXe.CreateDocument();

                                    _rptCanXe_Master.Pages.AddRange(_rptCanXe.Pages);
                                }

                                _rptCanXe_Master.PrintingSystem.ContinuousPageNumbering = true;
                                //_rptCanXe_Master.AssignPrintTool(new ReportPrintTool(_rptCanXe_Master));
                            }
                        }
                    }
                    ReportPrintTool printTool = new ReportPrintTool(_rptCanXe_Master);
                    printTool.ShowPreview();
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetReport(PhieuCan phieuCan, ref rptCanXe _rptCanXe)
        {
            try
            {
                _rptCanXe.Parameters["TenCongTy"].Value = SqlHelper.CompanyName;
                _rptCanXe.Parameters["DiaChi"].Value = SqlHelper.Address;
                _rptCanXe.Parameters["DienThoai"].Value = SqlHelper.Phone;
                _rptCanXe.Parameters["Fax"].Value = SqlHelper.Fax;

                _rptCanXe.Parameters["SoPhieu"].Value = phieuCan.SoPhieu;
                _rptCanXe.Parameters["Ngay"].Value = phieuCan.Ngay.Value.ToString("dd/MM/yyyy");
                _rptCanXe.Parameters["KhachHang_TenKhachHang"].Value = phieuCan.KhachHang;
                _rptCanXe.Parameters["KhachHang_DiaChi"].Value = "";
                _rptCanXe.Parameters["BienSoXe"].Value = phieuCan.SoXe;
                _rptCanXe.Parameters["LoaiHang"].Value = phieuCan.Loaihang;

                _rptCanXe.Parameters["XuatNhap"].Value = phieuCan.XuatNhap;
                _rptCanXe.Parameters["ThoiGianCanLan1"].Value = phieuCan.NgayCan1.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                _rptCanXe.Parameters["ThoiGianCanLan2"].Value = phieuCan.NgayCan2.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                _rptCanXe.Parameters["TrongLuongCanLan1"].Value = phieuCan.TrongLuongCan1.Value.ToString("##,##0.###");
                _rptCanXe.Parameters["TrongLuongCanLan2"].Value = phieuCan.TrongLuongCan2.Value.ToString("##,##0.###");

                _rptCanXe.Parameters["TrongLuongHangHoa"].Value = phieuCan.TrongLuongHang.Value.ToString("##,##0.###");

                _rptCanXe.Parameters["BarCode"].Value = JsonConvert.SerializeObject(phieuCan);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (XtraMessageBox.Show(this, "Bạn có chắc là muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
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

        private bool Save(int ScaleTypeSave, bool isPrint)
        {
            try
            {
                if (!ValidateSaveData(ScaleTypeSave))
                {
                    return false;
                }

                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                decimal tempDec = 0;
                var now = DateTime.Now;

                var phieuCan_Print = new PhieuCan();

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
                    item.XuatNhap = cbXuatNhap.Text;

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

                        item.TrongLuongCan1 = calCanLan1.Value;
                        item.TrongLuongCan2 = calCanLan2.Value;
                        item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                    }

                    db.PhieuCan.Add(item);

                    phieuCan_Print = item;
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
                        item.XuatNhap = cbXuatNhap.Text;

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

                            item.TrongLuongCan1 = calCanLan1.Value;
                            item.TrongLuongCan2 = calCanLan2.Value;
                            item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                        }

                        phieuCan_Print = item;
                    }
                    else
                    {
                        XtraMessageBox.Show("Không tìm thấy phiếu cân này !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                
                db.SaveChanges();
                XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (isPrint)
                {
                    var _rptCanXe = new rptCanXe();
                    SetReport(phieuCan_Print, ref _rptCanXe);
                    ReportPrintTool printTool = new ReportPrintTool(_rptCanXe);
                    printTool.ShowPreview();
                }

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

        private bool ValidateSaveData(int ScaleTypeSave)
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

                if (calCanLan1.Value > 0 && dtNgayCan1.EditValue == null)
                {
                    XtraMessageBox.Show(this, "Vui lòng chọn ngày cân 1 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtNgayCan1.Focus();
                    return false;
                }

                if (calCanLan2.Value > 0 && dtNgayCan2.EditValue == null)
                {
                    XtraMessageBox.Show(this, "Vui lòng chọn ngày cân 2 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtNgayCan2.Focus();
                    return false;
                }

                decimal tempDec = 0;
                var can = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Save)
                {
                    if (calCanLan1.Value == 0 && calCanLan2.Value == 0)
                    {
                        XtraMessageBox.Show(this, "Không có dữ liệu cân lần 1 hoặc lần 2 !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
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

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selectedRows = gbList.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    var arg = gbList.GetRowCellValue(selectedRows[selectedRows.Length - 1], colId);
                    if (arg != null)
                    {
                        var IdPhieuCan = Convert.ToInt64(arg);
                        SetEdit(IdPhieuCan);
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

                    var arg = gbList.GetRowCellValue(selectedRows[selectedRows.Length - 1], colId);
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
                                if (calCanLan1.Value > 0)
                                {
                                    if (XtraMessageBox.Show(this, "Bạn có chắc là muốn thay đổi cân lần 1 ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        return false;
                                    }
                                }
                                item.NgayCan1 = dtNgay.DateTime;
                                //item.NgayCan2 = dtNgay.DateTime;

                                item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                //item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                            }
                            else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale_2)
                            {
                                if (calCanLan2.Value > 0)
                                {
                                    if (XtraMessageBox.Show(this, "Bạn có chắc là muốn thay đổi cân lần 2 ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                    {
                                        return false;
                                    }
                                }
                                //item.NgayCan1 = dtNgay.DateTime;
                                item.NgayCan2 = dtNgay.DateTime;

                                //item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                                item.TrongLuongHang = (item.TrongLuongCan1.Value > 0 && item.TrongLuongCan2.Value > 0) ? Math.Abs(item.TrongLuongCan1.Value - item.TrongLuongCan2.Value) : 0;
                            }
                            else if (ScaleTypeSave == (int)ScaleTypeSaveEnum.Scale)
                            {
                                if (calCanLan1.Value > 0 && calCanLan2.Value > 0)
                                {
                                    XtraMessageBox.Show(this, "Lần cân 1 và 2 đã có giá trị. Không thể thực hiện thao tác này !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                    return false;
                                }
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
                if (calCanLan1.Value > 0 && calCanLan2.Value > 0)
                {
                    calTrongLuongHang.EditValue = Math.Abs(Convert.ToDecimal(calCanLan1.EditValue) - Convert.ToDecimal(calCanLan2.EditValue));
                }
                else
                {
                    calTrongLuongHang.EditValue = 0;
                }
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
                if (calCanLan1.Value > 0 && calCanLan2.Value > 0)
                {
                    calTrongLuongHang.EditValue = Math.Abs(Convert.ToDecimal(calCanLan1.EditValue) - Convert.ToDecimal(calCanLan2.EditValue));
                }
                else
                {
                    calTrongLuongHang.EditValue = 0;
                }   
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

        private void bbiSaveAndPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.Save((int)ScaleTypeSaveEnum.Save, true);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAutoComplete()
        {
            try
            {
                AutoCompleteStringCollection mangDanhSachKhachHang = new AutoCompleteStringCollection();
                AutoCompleteStringCollection mangDanhSachSoXe = new AutoCompleteStringCollection();
                AutoCompleteStringCollection mangDanhSachLoaiHang = new AutoCompleteStringCollection();

                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                var phieuCan = from pc in db.PhieuCan
                               where !pc.IsDeleted.Value
                               select pc;

                mangDanhSachKhachHang.AddRange(phieuCan.Select(pc => pc.KhachHang).Distinct<string>().ToArray<string>());
                mangDanhSachSoXe.AddRange(phieuCan.Select(pc => pc.SoXe).Distinct<string>().ToArray<string>());
                mangDanhSachLoaiHang.AddRange(phieuCan.Select(pc => pc.Loaihang).Distinct<string>().ToArray<string>());

                var txtKhacHang_AutoComplete = txtKhachHang.MaskBox;
                var txtSoXe_AutoComplete = txtSoXe.MaskBox;
                var txtLoaiHang_AutoComplete = txtLoaiHang.MaskBox;

                SetAutoComplete(ref txtKhacHang_AutoComplete, mangDanhSachKhachHang);
                SetAutoComplete(ref txtSoXe_AutoComplete, mangDanhSachSoXe);
                SetAutoComplete(ref txtLoaiHang_AutoComplete, mangDanhSachLoaiHang);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAutoComplete(ref TextBoxMaskBox textBoxMaskBox, AutoCompleteStringCollection autoCompleteStringCollection)
        {
            try
            {
                textBoxMaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                textBoxMaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBoxMaskBox.AutoCompleteCustomSource = autoCompleteStringCollection;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyCan1_Click(object sender, EventArgs e)
        {
            try
            {
                var canNang = txtCanNang.Value;
                if (canNang != 0 && canNang != -1)
                {
                    if (calCanLan1.Value > 0)
                    {

                        if (XtraMessageBox.Show(this, "Bạn có chắc là muốn copy dữ liệu từ cân sang cân lần 1 không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    calCanLan1.EditValue = canNang;
                }
                
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyCan2_Click(object sender, EventArgs e)
        {
            try
            {
                var canNang = txtCanNang.Value;
                if (canNang != 0 && canNang != -1)
                {
                    if (calCanLan2.Value > 0)
                    {

                        if (XtraMessageBox.Show(this, "Bạn có chắc là muốn copy dữ liệu từ cân sang cân lần 2 không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    calCanLan2.EditValue = canNang;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                bbiEdit_ItemClick(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScale_Click(object sender, EventArgs e)
        {
            try
            {
                bbiScale_Grid_ItemClick(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScale1_Click(object sender, EventArgs e)
        {
            try
            {
                bbiScale1_Grid_ItemClick(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnScale2_Click(object sender, EventArgs e)
        {
            try
            {
                bbiScale2_Grid_ItemClick(this, null);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
