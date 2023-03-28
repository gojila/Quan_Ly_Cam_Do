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

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Dictionary.Item
{
    public partial class frmItem : XtraForm
    {
        public delegate void SaveEventHander(object sender);
        public event SaveEventHander SaveEvent;
        private void RaiseSaveEventHander()
        {
            if (SaveEvent != null)
            {
                SaveEvent(this);
            }
        }

        private long ItemID = 0;
        public frmItem()
        {
            InitializeComponent();
        }

        public frmItem(long ItemID)
        {
            InitializeComponent();

            this.ItemID = ItemID;
            SetData();
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSaveEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
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

        private bool Save()
        {
            try 
            {
                if (!ValidateInput()) 
                {
                    return false;
                }
                var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities();
                
                var item = new Database.Item();

                item.ItemCode = txtItemCode.Text;
                item.ItemName = txtItemName.Text;
                item.Descriptions = txtDescription.Text;
                item.ModifiedDate = DateTime.Now;

                if (this.ItemID == 0)
                {
                    item.IsDeleted = false;
                    item.CreatedDate = DateTime.Now;

                    db.Items.Add(item);
                    db.SaveChanges();
                    this.ItemID = item.ItemID;
                }
                else 
                {
                    item.ItemID = this.ItemID;
                    db.Entry(item).State = System.Data.Entity.EntityState.Modified;
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

        private bool ValidateInput() 
        {
            if (string.IsNullOrEmpty(txtItemCode.Text)) 
            {
                Common.Common.OpenErrorMessage("Vui lòng nhập mã sản phẩm !");
                return false;
            }
            if (string.IsNullOrEmpty(txtItemName.Text))
            {
                Common.Common.OpenErrorMessage("Vui lòng nhập tên sản phẩm !");
                return false;
            }
            return true;
        }

        private void SetData() 
        {
            try 
            {
                if (this.ItemID != 0)
                {
                    var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities();
                    var item = db.Items.Where(i => i.ItemID == this.ItemID && !(i.IsDeleted ?? false)).FirstOrDefault();
                    if (item != null)
                    {
                        txtDescription.Text = item.Descriptions;
                        txtItemCode.Text = item.ItemCode;
                        txtItemName.Text = item.ItemName;
                    }
                }
                else 
                {
                    txtDescription.Text = "";
                    txtItemCode.Text = "";
                    txtItemName.Text = "";
                }
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void bbiSaveNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this.ItemID = 0;
                SetData();
            }
        }
    }
}
