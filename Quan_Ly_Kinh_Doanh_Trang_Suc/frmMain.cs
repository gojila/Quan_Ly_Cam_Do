using Quan_Ly_Kinh_Doanh_Trang_Suc.Business.Sale;
using Quan_Ly_Kinh_Doanh_Trang_Suc.Dictionary.Item;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh_Trang_Suc
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();

            bbiSale_ItemClick(this, null);
        }

        private frmSaleList _frmSaleList;
        private void bbiSale_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmSaleList == null)
            {
                _frmSaleList = new frmSaleList();
                _frmSaleList.FormClosing += (ss, ex) =>
                {
                    _frmSaleList = null;
                };
                _frmSaleList.MdiParent = this;
                _frmSaleList.Show();
            }
            else
            {
                tabMdi.Pages[_frmSaleList].MdiChild.Activate();
            }
        }

        private frmItemList _frmItemList;
        private void bbiItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmItemList == null)
            {
                _frmItemList = new frmItemList();
                _frmItemList.FormClosing += (ss, ex) =>
                {
                    _frmItemList = null;
                };
                _frmItemList.MdiParent = this;
                _frmItemList.Show();
            }
            else
            {
                tabMdi.Pages[_frmItemList].MdiChild.Activate();
            }
        }
    }
}
