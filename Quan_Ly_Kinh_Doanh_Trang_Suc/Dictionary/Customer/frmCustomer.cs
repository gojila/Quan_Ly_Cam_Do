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
    public partial class frmCustomer : XtraForm
    {

        private long _customerID = 0;
        public delegate void SaveEventHander(object sender);
        public event SaveEventHander SaveEvent;
        private void RaiseSaveEventHander()
        {
            if (SaveEvent != null)
            {
                SaveEvent(this);
            }
        }

        public frmCustomer()
        {
            InitializeComponent();
        }

        public frmCustomer(long customerID)
        {        
            InitializeComponent();
            _customerID = customerID;
            SetData();
        }

        private void bbiSaveNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this._customerID = 0;
                SetData();
            }
        }

        private void bbiSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        private void bbiSaveEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                SetData();
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void SetData() 
        {
            try
            {
                if (this._customerID != 0)
                {
                    var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities();
                    var customer = db.Customers.Where(c => c.CustomerID == this._customerID && !(c.IsDeleted ?? false)).FirstOrDefault();
                    if (customer != null)
                    {                        
                        txtCustomerCode.Text = customer.CustomerCode;
                        txtCustomerName.Text = customer.CustomerName;
                        txtPhoneNo.Text = customer.PhoneNo;
                        txtAddress.Text = customer.Address;
                        txtDescription.Text = customer.Description;
                    }
                }
                else
                {
                    txtCustomerCode.Text = "";
                    txtCustomerName.Text = "";
                    txtPhoneNo.Text = "";
                    txtAddress.Text = "";
                    txtDescription.Text = "";
                }
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCustomerCode.Text))
            {
                Common.Common.OpenErrorMessage("Vui lòng nhập mã khách hàng !");
                return false;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                Common.Common.OpenErrorMessage("Vui lòng nhập tên khách hàng !");
                return false;
            }
            return true;
        }

        private bool Save()
        {
            try
            {
                if (!ValidateInput())
                    return false;

                var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities();
                var customer = new Database.Customer();
                customer.CustomerCode = txtCustomerCode.Text;
                customer.CustomerName = txtCustomerName.Text;
                customer.Address = txtAddress.Text;
                customer.PhoneNo = txtPhoneNo.Text;
                customer.Description = txtDescription.Text;

                if (this._customerID == 0) // add new
                {
                    customer.IsDeleted = false;
                    customer.CreatedDate = DateTime.Now;

                    db.Customers.Add(customer);
                    db.SaveChanges();
                    this._customerID = customer.CustomerID;
                }
                else // update
                {
                    customer.CustomerID = this._customerID;
                    customer.ModifiedDate = DateTime.Now;
                    db.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                RaiseSaveEventHander();
                Common.Common.OpenActionSuccessMessage();
                return true;
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
                return false;
            }
        }
    }
}
