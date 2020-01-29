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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe
{
    public partial class frmPhieuCanXe : XtraForm
    {
        public frmPhieuCanXe()
        {
            InitializeComponent();
            bbiNew_ItemClick(this, null);
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
                txtGio.Text = DateTime.Now.ToString("HH:mm:ss");

                txtSoPhieu.Text = SqlHelper.GenCode("PhieuCan", "SoPhieu", "CAN", 6);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiScale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                decimal tempDec = 0;
                var item = new PhieuCan();

                item.CreatedDate = DateTime.Now;
                item.CreatedUser = 1;
                item.GhiChu = txtGhiChu.Text;
                item.IsDeleted = false;
                item.KhachHang = txtKhachHang.Text;
                item.Loaihang = txtLoaiHang.Text;
                item.Ngay = dtNgay.DateTime;
                //item.NgayCan1 = dtNgay.DateTime;
                //item.NgayCan2 = dtNgay.DateTime;
                item.SoPhieu = txtSoPhieu.Text;
                item.SoXe = txtSoXe.Text;
                item.Status = 1;
                //item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                //item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                item.TrongLuongHang = 0;
                item.UpatedUser = 1;
                item.UpdatedDate = DateTime.Now;
                item.XuatNhap = cbXuatNhap.SelectedText;

                if (item.NgayCan1 != null)
                {
                    item.NgayCan1 = dtNgay.DateTime;
                    item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                }
                else
                {
                    item.NgayCan2 = dtNgay.DateTime;
                    item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                }



                db.PhieuCan.Add(item);
                db.SaveChanges();

                XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bbiNew_ItemClick(this, null);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiScale1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                decimal tempDec = 0;
                var item = new PhieuCan();

                item.CreatedDate = DateTime.Now;
                item.CreatedUser = 1;
                item.GhiChu = txtGhiChu.Text;
                item.IsDeleted = false;
                item.KhachHang = txtKhachHang.Text;
                item.Loaihang = txtLoaiHang.Text;
                item.Ngay = dtNgay.DateTime;
                item.NgayCan1 = dtNgay.DateTime;
                item.NgayCan2 = dtNgay.DateTime;
                item.SoPhieu = txtSoPhieu.Text;
                item.SoXe = txtSoXe.Text;
                item.Status = 1;
                item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                item.TrongLuongHang = 0;
                item.UpatedUser = 1;
                item.UpdatedDate = DateTime.Now;
                item.XuatNhap = cbXuatNhap.SelectedText;

                db.PhieuCan.Add(item);
                db.SaveChanges();

                XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bbiNew_ItemClick(this, null);

            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiScale2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var db = new PhanMemCanXeTaiEntities1();
                db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

                decimal tempDec = 0;
                var item = new PhieuCan();

                item.CreatedDate = DateTime.Now;
                item.CreatedUser = 1;
                item.GhiChu = txtGhiChu.Text;
                item.IsDeleted = false;
                item.KhachHang = txtKhachHang.Text;
                item.Loaihang = txtLoaiHang.Text;
                item.Ngay = dtNgay.DateTime;
                item.NgayCan1 = dtNgay.DateTime;
                item.NgayCan2 = dtNgay.DateTime;
                item.SoPhieu = txtSoPhieu.Text;
                item.SoXe = txtSoXe.Text;
                item.Status = 1;
                item.TrongLuongCan1 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                item.TrongLuongCan2 = Decimal.TryParse(txtCanNang.Text, out tempDec) ? Convert.ToDecimal(txtCanNang.Text) : 0;
                item.TrongLuongHang = 0;
                item.UpatedUser = 1;
                item.UpdatedDate = DateTime.Now;
                item.XuatNhap = cbXuatNhap.SelectedText;

                db.PhieuCan.Add(item);
                db.SaveChanges();

                XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bbiNew_ItemClick(this, null);

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
                txtGio.Text = String.Format("{0:HH:mm:ss tt}", DateTime.Now);
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
