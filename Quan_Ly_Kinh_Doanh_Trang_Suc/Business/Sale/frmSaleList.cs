using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Business.Sale
{
    public partial class frmSaleList : XtraForm
    {
        public frmSaleList()
        {
            InitializeComponent();
        }

        private frmSale _frmSale;
        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _frmSale = new frmSale();
            _frmSale.FormClosing += (ss, ee) =>
            {
                _frmSale = null;
            };
            _frmSale.ShowDialog();
        }
    }
}
