using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Common;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Bussiness;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe.Report
{
    public partial class rptCanXe : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCanXe()
        {
            InitializeComponent();
        }

        public rptCanXe(long Id)
        {
            InitializeComponent();

            var db = new PhanMemCanXeTaiEntities1();
            db.Database.Connection.ConnectionString = SqlHelper.ConnectionString;


        }
    }
}
