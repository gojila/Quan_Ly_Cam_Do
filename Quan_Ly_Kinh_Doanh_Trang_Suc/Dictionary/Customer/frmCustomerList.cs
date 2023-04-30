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

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Dictionary.Customer
{
    public partial class frmCustomerList : XtraForm
    {
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var _frmCustomer = new frmCustomer();
                //_frmCustomer.SaveEvent += (ss) =>
                //{
                //    bbiView_ItemClick(this, null);
                //};
                _frmCustomer.ShowDialog();
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }
    }
}
