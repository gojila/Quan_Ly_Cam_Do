using DevExpress.XtraEditors;
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

        }

        private void bbiScaleTruck_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
