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
    public partial class frmDanhSachPhieuCanXe : XtraForm
    {
        public delegate void AddNewEventHander(object sender);
        public event AddNewEventHander AddNew;
        private void RaiseAddNewEventHander()
        {
            if (AddNew != null)
            {
                AddNew(this);
            }
        }

        public delegate void EditEventHander(object sender, long Id);
        public event EditEventHander Edit;
        private void RaiseEditEventHander(long Id)
        {
            if (Edit != null)
            {
                Edit(this, Id);
            }
        }

        public frmDanhSachPhieuCanXe()
        {
            InitializeComponent();
        }

        private void frmCanXe_Load(object sender, EventArgs e)
        {
            gbList.CustomDrawRowIndicator += (_s, _e) =>
            {
                int rowIndex = _e.RowHandle;
                if (rowIndex >= 0)
                {
                    rowIndex++;
                    _e.Info.DisplayText = rowIndex.ToString();
                }
            };
            cbOption_SelectedIndexChanged(this, null);
            this.Reload();
        }

        private void cbOption_SelectedIndexChanged(object sender, EventArgs e)
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
                case "Tất cả":
                    dtFromDate.DateTime = (DateTime)SqlDateTime.MinValue;
                    dtToDate.DateTime = (DateTime)SqlDateTime.MaxValue;
                    break;
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

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                                    CommonAction.SetReport(this, phieuCan, ref _rptCanXe_Master);
                                    _rptCanXe_Master.CreateDocument();

                                    isSetMaster = true;
                                }
                                else
                                {
                                    var _rptCanXe = new rptCanXe();
                                    CommonAction.SetReport(this, phieuCan, ref _rptCanXe);
                                    _rptCanXe.CreateDocument();

                                    _rptCanXe_Master.Pages.AddRange(_rptCanXe.Pages);
                                }

                                _rptCanXe_Master.PrintingSystem.ContinuousPageNumbering = true;
                            }
                        }
                    }
                    ReportPrintTool printTool = new ReportPrintTool(_rptCanXe_Master);
                    printTool.ShowPreview();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiScaleTruck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                RaiseAddNewEventHander();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Reload();
        }

        private void Reload()
        {
            try
            {
                this.phieuCanTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
                this.phieuCanTableAdapter.ClearBeforeFill = true;
                this.phieuCanTableAdapter.Fill(this.dsCanXe.PhieuCan, dtFromDate.DateTime, dtToDate.DateTime);
                gbList.BestFitColumns();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selectedRows = gbList.GetSelectedRows();

                if (selectedRows.Length > 0)
                {
                    if (XtraMessageBox.Show(this, "Bạn có chắc là muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return;

                    var db = new PhanMemCanXeTaiEntities1();
                    db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;

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
                                phieuCan.IsDeleted = true;
                                phieuCan.UpatedUser = 1;
                                phieuCan.UpdatedDate = DateTime.Now;
                            }
                        }
                    }

                    db.SaveChanges();
                    bbiView_ItemClick(this, null);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        var Id = Convert.ToInt64(arg);
                        RaiseEditEventHander(Id);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
