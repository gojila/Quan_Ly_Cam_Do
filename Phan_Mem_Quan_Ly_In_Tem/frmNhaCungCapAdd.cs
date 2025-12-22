using DevExpress.XtraEditors;
using Phan_Mem_Quan_Ly_In_Tem.XuLy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_In_Tem
{
    public partial class frmNhaCungCapAdd : XtraForm
    {
        public delegate void NapLaiEventHander();

        public event NapLaiEventHander NapLai;
        private void RaiseNapLaiEventHander()
        {
            if (NapLai != null)
            {
                NapLai();
            }
        }

        private string duongDanFileExcel = "";
        private string ID = "";
        public frmNhaCungCapAdd(string _duongDanFileExcel)
        {
            this.duongDanFileExcel = _duongDanFileExcel;
            InitializeComponent();
        }

        public frmNhaCungCapAdd(string _duongDanFileExcel, string _ID)
        {
            this.duongDanFileExcel = _duongDanFileExcel;
            this.ID = _ID;
            InitializeComponent();

        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                ValidateForm();

                //var _xuLyDuLieu = new clsXuLyDuLieu();
                //bool result = _xuLyDuLieu.luuNhaCungCapTCCS(duongDanFileExcel, ID, txtTCCS.Text, txtTenTiem.Text, txtDiaChi.Text, txtGhiChu.Text);
                //if (result) 
                //{
                //    MessageBox.Show(this, "Thao tác thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    RaiseNapLaiEventHander();
                //    this.Close();
                //}

                string result = Save();
                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(this, "Thao tác thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RaiseNapLaiEventHander();
                    this.Close();
                }
                else 
                {
                    XtraMessageBox.Show(this, result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateForm()
        {
            try 
            {
                if (string.IsNullOrEmpty(txtTCCS.Text)) 
                {
                    txtTCCS.Focus();
                    XtraMessageBox.Show(this, "Vui lòng nhập TCCS !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(txtTenTiem.Text))
                {
                    txtTenTiem.Focus();
                    XtraMessageBox.Show(this, "Vui lòng nhập Tên Tiệm !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrEmpty(txtDiaChi.Text))
                {
                    txtDiaChi.Focus();
                    XtraMessageBox.Show(this, "Vui lòng nhập Địa Chỉ !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmNhaCungCapAdd_Load(object sender, EventArgs e)
        {
            try 
            {
                if (!string.IsNullOrEmpty(this.ID))
                {
                    var SupplierID = Convert.ToInt64(ID);
                    var db = new ModelEF.PrintBarcodeEntities();
                    var supplier = db.Suppliers.Where(s => s.SupplierID == SupplierID && !(s.IsDeleted ?? false)).FirstOrDefault();

                    if (supplier != null) 
                    {
                        txtTCCS.Text = supplier.SupplierBaseStandardNo; //dr["Nhà Cung Cấp"] != DBNull.Value ? dr["Nhà Cung Cấp"].ToString() : "";
                        txtTenTiem.Text = supplier.SupplierName; //dr["Tên Tiệm"] != DBNull.Value ? dr["Tên Tiệm"].ToString() : "";
                        txtDiaChi.Text = supplier.SupplierAddress; //dr["Địa Chỉ"] != DBNull.Value ? dr["Địa Chỉ"].ToString() : "";
                        txtGhiChu.Text = supplier.Remark; //dr["Ghi Chú"] != DBNull.Value ? dr["Ghi Chú"].ToString() : "";
                    }

                    //var _clsXulyDuLieu = new clsXuLyDuLieu();
                    //var dr = _clsXulyDuLieu.getNhaCungCap(this.duongDanFileExcel, ID.ToString());
                    //if (dr != null)
                    //{
                    //    txtTCCS.Text = dr["Nhà Cung Cấp"] != DBNull.Value ? dr["Nhà Cung Cấp"].ToString() : "";
                    //    txtTenTiem.Text = dr["Tên Tiệm"] != DBNull.Value ? dr["Tên Tiệm"].ToString() : "";
                    //    txtDiaChi.Text = dr["Địa Chỉ"] != DBNull.Value ? dr["Địa Chỉ"].ToString() : "";
                    //    txtGhiChu.Text = dr["Ghi Chú"] != DBNull.Value ? dr["Ghi Chú"].ToString() : "";   
                    //}
                }
            }
            catch (Exception ex) 
            {
                XtraMessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string Save() 
        {
            try 
            {
                var db = new ModelEF.PrintBarcodeEntities();

                ModelEF.Supplier supplier = null;
                if (!string.IsNullOrEmpty(ID))
                {
                    var supplierId = Convert.ToInt64(ID);
                    supplier = db.Suppliers.Where(s => s.SupplierID == supplierId && !(s.IsDeleted ?? false)).FirstOrDefault();
                    if (supplier == null) 
                    {
                        supplier = new ModelEF.Supplier();
                    }
                }
                else 
                {
                    supplier = new ModelEF.Supplier();
                }

                supplier.CreatedDate = DateTime.Now;
                supplier.CreatedUserID = 0;
                //supplier.DeletedDate = null;
                //supplier.DeletedUserID = 0;
                supplier.IsDeleted = false;
                supplier.Remark = txtGhiChu.Text;

                supplier.SupplierAddress = txtDiaChi.Text;
                supplier.SupplierBaseStandardNo = txtTCCS.Text;
                //supplier.SupplierID = 0;
                supplier.SupplierName = txtTenTiem.Text;
                
                supplier.UpdatedDate = DateTime.Now;
                supplier.UpdatedUserID = 0;

                if (string.IsNullOrEmpty(ID))
                {
                    db.Suppliers.Add(supplier);
                }
                db.SaveChanges();

                return "";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
