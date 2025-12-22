using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_In_Tem.Company
{
    public partial class frmCompanyAdd : XtraForm
    {
        public delegate void ReloadEventHander();

        public event ReloadEventHander Reload;
        private void RaiseReloadEventHander()
        {
            if (Reload != null)
            {
                Reload();
            }
        }
        private string id = ""; 
        public frmCompanyAdd()
        {
            InitializeComponent();
        }

        public frmCompanyAdd(string _id)
        {
            this.id = _id;
            InitializeComponent();
        }

        private string Save()
        {
            try 
            {
                using (var db = new ModelEF.PrintBarcodeEntities())
                {
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            if (cbIsDefault.Checked)
                            {
                                db.Database.ExecuteSqlCommand(@"UPDATE [Company] SET [IsDefault] = 0");
                                db.SaveChanges();
                            }

                            ModelEF.Company company = null;

                            if (string.IsNullOrEmpty(this.id))
                            {
                                company = new ModelEF.Company();
                            }
                            else
                            {
                                var companyID = Convert.ToInt64(this.id);
                                company = db.Companies.Where(c => c.CompanyID == companyID && !(c.IsDeleted ?? false)).FirstOrDefault();
                                if (company == null)
                                {
                                    company = new ModelEF.Company();
                                }
                            }

                            company.CompanyAddress = txtAddress.Text;
                            //company.CompanyID = 0;
                            company.CompanyName = txtCompanyName.Text;
                            company.CompanyStandardCode = txtCompanyStandardCode.Text;
                            company.CreatedDate = DateTime.Now;
                            company.CreatedUserID = 0;

                            //company.DeletedDate = null;
                            //company.DeletedUserID = 0;
                            company.Email = txtEmail.Text;
                            company.Fax = txtFax.Text;
                            company.IsDeleted = false;

                            company.Phone = txtPhone.Text;
                            company.Remark = txtRemark.Text;
                            company.UpdatedDate = DateTime.Now;
                            company.UpdatedUserID = 0;
                            company.TaxCode = txtTaxCode.Text;
                            company.IsDefault = cbIsDefault.Checked;

                            company.FormatStringDefault = txtFormatStringDefault.Text;

                            if (company.CompanyID == 0)
                            {
                                db.Companies.Add(company);
                            }
                            db.SaveChanges();
                            dbTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            dbTransaction.Rollback();
                            throw ex;
                        }
                        
                    }
                }
                return "";
            }
            catch (Exception ex) 
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        private string Validate() 
        {
            try 
            {
                if (string.IsNullOrEmpty(txtCompanyName.Text.Trim())) 
                {
                    txtCompanyName.Focus();
                    return "Vui lòng nhập tên nhà phân phối";
                }
                if (string.IsNullOrEmpty(txtAddress.Text.Trim()))
                {
                    txtAddress.Focus();
                    return "Vui lòng nhập địa chỉ";
                }
                return "";
            }
            catch (Exception ex) 
            {
                return JsonConvert.SerializeObject(ex);
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                string result = Validate();
                if (!string.IsNullOrEmpty(result)) 
                {
                    MessageBox.Show(this, result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                result = Save();
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(this, result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show(this, "Thao tác thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RaiseReloadEventHander();
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmCompanyAdd_Load(object sender, EventArgs e)
        {
            try 
            {
                if (!string.IsNullOrEmpty(this.id)) 
                {
                    using (var db = new ModelEF.PrintBarcodeEntities()) 
                    {
                        var companyID = Convert.ToInt64(this.id);
                        var company = db.Companies.Where(c => c.CompanyID == companyID && !(c.IsDeleted ?? false)).FirstOrDefault();
                        if (company != null)
                        {
                            txtAddress.Text = company.CompanyAddress;
                            txtCompanyName.Text = company.CompanyName;
                            txtCompanyStandardCode.Text = company.CompanyStandardCode;
                            txtEmail.Text = company.Email;
                            txtFax.Text = company.Fax;
                            txtPhone.Text = company.Phone;
                            txtRemark.Text = company.Remark;
                            txtTaxCode.Text = company.TaxCode;
                            cbIsDefault.Checked = company.IsDefault ?? false;
                            txtFormatStringDefault.Text = company.FormatStringDefault;
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
