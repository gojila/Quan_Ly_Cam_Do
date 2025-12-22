using DevExpress.XtraEditors;
using Phan_Mem_Quan_Ly_In_Tem.XuLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_In_Tem.MauTemIn
{
    public partial class frmThemMauTemIn : XtraForm
    {
        public delegate void ReloadEventHander(object sender);

        public event ReloadEventHander Reload;
        private void RaiseReloadEventHander()
        {
            if (Reload != null)
            {
                Reload(this);
            }
        }

        private string path;
        private string id = "";
        public frmThemMauTemIn()
        {
            InitializeComponent();
        }
        public frmThemMauTemIn(string path)
        {
            this.path = path;
            InitializeComponent();
        }
        public frmThemMauTemIn(string path, string id)
        {
            this.id = id;
            this.path = path;
            InitializeComponent();
        }
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                this.Close();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                //clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();
                //var result = _clsXuLyDuLieu.luuMauTemIn(path, this.id, txtTenMauTem.Text, txtDuongDan.Text, txtGhiChu.Text, (cbMacDinh.Checked ? "Y" : "N"));
                //if (result) 
                //{
                //    MessageBox.Show(this, "Lưu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    RaiseReloadEventHander();
                //    this.Close();
                //}

                string result = Save();
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(this, "Lưu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RaiseReloadEventHander();
                    this.Close();
                }
                else 
                {
                    MessageBox.Show(this, result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmThemMauTemIn_Load(object sender, EventArgs e)
        {
            try 
            {
                if (!string.IsNullOrEmpty(this.id)) 
                {
                    //var _clsXulyDuLieu = new clsXuLyDuLieu();
                    //var dr = _clsXulyDuLieu.getMauTemIn(this.path, id.ToString());
                    //if (dr != null) 
                    //{
                    //    txtTenMauTem.Text = dr["Tên Mẫu Tem"] != DBNull.Value ? dr["Tên Mẫu Tem"].ToString() : "";
                    //    txtDuongDan.Text = dr["Đường Dẫn"] != DBNull.Value ? dr["Đường Dẫn"].ToString() : "";
                    //    txtGhiChu.Text = dr["Ghi Chú"] != DBNull.Value ? dr["Ghi Chú"].ToString() : "";
                    //    cbMacDinh.Checked = dr["Mặc Định"] != DBNull.Value ? (dr["Mặc Định"].ToString() == "Y" ? true: false) : false;
                    //}
                    var BarcodeTemplateID = Convert.ToInt32(this.id);
                    using (var db = new ModelEF.PrintBarcodeEntities()) 
                    {
                        var barcodeTemplate = db.BarcodeTemplates.Where(bt => bt.BarcodeTemplateID == BarcodeTemplateID &&!(bt.IsDeleted ?? false)).FirstOrDefault();
                        if (barcodeTemplate != null) 
                        {
                            txtTenMauTem.Text = barcodeTemplate.BarcodeTemplateName;
                            txtDuongDan.Text = barcodeTemplate.BarcodeTemplatePath;
                            txtGhiChu.Text = barcodeTemplate.Remark;
                            cbMacDinh.Checked = barcodeTemplate.IsDefault ?? false;
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDuongDan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try 
            {
                if (e.Button.Tag.ToString() == "Chon")
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "(*.repx)|*.repx;|All files (*.*)|*.*";
                    openFileDialog1.FilterIndex = 1;

                    openFileDialog1.Multiselect = false;

                    // Call the ShowDialog method to show the dialog box.
                    if (openFileDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    string path = openFileDialog1.FileName;
                    txtDuongDan.Text = path;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Save() 
        {
            string result = "";
            using (var db = new ModelEF.PrintBarcodeEntities()) 
            {
                using (var dbTransaction = db.Database.BeginTransaction())
                {
                    try 
                    {
                        if (cbMacDinh.Checked) 
                        {
                            db.Database.ExecuteSqlCommand(@"UPDATE [BarcodeTemplate] SET IsDefault = 0");
                            db.SaveChanges();
                        }

                        var barcodeTemplate = new ModelEF.BarcodeTemplate();

                        if (string.IsNullOrEmpty(this.id))
                        {
                            barcodeTemplate = new ModelEF.BarcodeTemplate();
                        }
                        else
                        {
                            var barcodeTemplateID = Convert.ToInt64(this.id);
                            barcodeTemplate = db.BarcodeTemplates.Where(b => b.BarcodeTemplateID == barcodeTemplateID && !(b.IsDeleted ?? false)).FirstOrDefault();
                            if (barcodeTemplate == null)
                            {
                                barcodeTemplate = new ModelEF.BarcodeTemplate();
                            }
                        }

                        //barcodeTemplate.BarcodeTemplateID = 0;
                        barcodeTemplate.BarcodeTemplateName = txtTenMauTem.Text;
                        barcodeTemplate.BarcodeTemplatePath = txtDuongDan.Text;
                        barcodeTemplate.CreatedDate = DateTime.Now;
                        barcodeTemplate.CreatedUserID = 0;

                        //barcodeTemplate.DeletedDate = null;
                        //barcodeTemplate.DeletedUserID = 0;
                        barcodeTemplate.IsDefault = cbMacDinh.Checked;
                        barcodeTemplate.IsDeleted = false;
                        barcodeTemplate.Remark = txtGhiChu.Text;
                        barcodeTemplate.UpdatedDate = DateTime.Now;

                        barcodeTemplate.UpdatedUserID = 0;

                        if (barcodeTemplate.BarcodeTemplateID == 0)
                        {
                            db.BarcodeTemplates.Add(barcodeTemplate);
                        }

                        db.SaveChanges();
                        dbTransaction.Commit();
                    }
                    catch (Exception ex) 
                    {
                        dbTransaction.Rollback();
                        result = ex.Message;
                    }
                }
            }
            return result;
        }
    }
}
