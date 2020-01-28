using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe.Report
{
    public partial class rptCanXe : DevExpress.XtraReports.UI.XtraReport
    {
        private long STT;
        public rptCanXe()
        {
            InitializeComponent();
        }

        public rptCanXe(long STT)
        {
            InitializeComponent();
            this.STT = STT;
        }

    }
}
