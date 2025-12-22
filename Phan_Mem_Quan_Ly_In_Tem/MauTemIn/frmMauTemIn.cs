using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmMauTemIn : XtraForm
    {
        public delegate void SelectEventHander(object sender, string path);

        public event SelectEventHander Select;
        private void RaiseSelectEventHander(string path)
        {
            if (Select != null)
            {
                Select(this, path);
            }
        }
        private string path;
        private bool isSelectState = false;
        public frmMauTemIn()
        {
            InitializeComponent();
        }

        public frmMauTemIn(string path)
        {
            this.path = path;
            InitializeComponent();
        }

        public void SetSelectState() 
        {
            this.isSelectState = true;
            bbiSelect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmThemMauTemIn _frmAdd = new frmThemMauTemIn(this.path);
            _frmAdd.Reload += (ss) =>
            {
                bbiView_ItemClick(this, null);
            };
            _frmAdd.ShowDialog();
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                //clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();
                //DataTable dtMauTemInExcel = new DataTable();
                //dtMauTemInExcel = _clsXuLyDuLieu.docDanhSachMauTemInFileExcel(path, Path.GetExtension(path), "Yes");
                //napDuLieuVaoLuoiTuFileExcel(dtMauTemInExcel);

                var db = new ModelEF.PrintBarcodeEntities();
                gcList.DataSource = db.BarcodeTemplates.Where(bt => !(bt.IsDeleted ?? false)).ToList();

                gbList.BestFitColumns();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void napDuLieuVaoLuoiTuFileExcel(DataTable dtMauTemInExcel)
        //{
        //    dsMauTemIn.MauTemIn.Rows.Clear();
        //    if (dtMauTemInExcel != null && dtMauTemInExcel.Rows.Count > 0) 
        //    {
        //        foreach (DataRow dr in dtMauTemInExcel.Rows)
        //        {
        //            string ID = dr["ID"] == DBNull.Value || dr["ID"] == null ? "" : dr["ID"].ToString();
        //            string TenTemIn = dr["Tên Mẫu Tem"] == DBNull.Value || dr["Tên Mẫu Tem"] == null ? "" : dr["Tên Mẫu Tem"].ToString();
        //            string DuongDan = dr["Đường Dẫn"] == DBNull.Value || dr["Đường Dẫn"] == null ? "" : dr["Đường Dẫn"].ToString();
        //            string GhiChu = dr["Ghi Chú"] == DBNull.Value || dr["Ghi Chú"] == null ? "" : dr["Ghi Chú"].ToString();
        //            string LaMacDinh = dr["Mặc Định"] == DBNull.Value || dr["Mặc Định"] == null ? "" : dr["Mặc Định"].ToString();

        //            dsMauTemIn.MauTemIn.AddMauTemInRow(ID, TenTemIn, DuongDan, LaMacDinh, GhiChu);
        //        }
        //        gbList.BestFitColumns();
        //    }
        //}

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var id = gbList.GetFocusedRowCellValue(colBarcodeTemplateID.FieldName);
                if (id != null) 
                {
                    frmThemMauTemIn _frmAdd = new frmThemMauTemIn(this.path, id.ToString());
                    _frmAdd.Reload += (ss) => 
                    {
                        bbiView_ItemClick(this, null);
                    };
                    _frmAdd.ShowDialog();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmMauTemIn_Load(object sender, EventArgs e)
        {
            bbiView_ItemClick(this, null);
            gbList.CustomDrawRowIndicator += (ss, ee)=> 
            {
                int rowIndex = ee.RowHandle;
                if (rowIndex >= 0)
                {
                    rowIndex++;
                    ee.Info.DisplayText = rowIndex.ToString();
                }
            };

            gbList.ShownEditor += (ss, ee) =>
            {
                var view = ss as GridView;
                view.ActiveEditor.DoubleClick += (ss1,ee1)=> 
                {
                    if (isSelectState)
                    {
                        bbiSelect_ItemClick(this, null);
                    }
                    else 
                    {
                        bbiEdit_ItemClick(this, null);
                    }
                    
                };
            };
            bm.SetPopupContextMenu(gcList, pm);
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int[] selectedRows = gbList.GetSelectedRows();
                string ids = "";
                if (selectedRows.Length > 0) 
                {
                    //clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();
                    for (int i = selectedRows.Length; i > 0; i--)
                    {
                        var arg = gbList.GetRowCellValue(selectedRows[i - 1], colBarcodeTemplateID);
                        if (arg == null)
                            continue;

                        if (!string.IsNullOrEmpty(ids)) 
                        {
                            ids += ",";
                        }
                        ids += arg.ToString();
                        //_clsXuLyDuLieu.xoaMauTemIn(this.path, arg.ToString());
                    }
                    if (!string.IsNullOrEmpty(ids)) 
                    {
                        using (var db = new ModelEF.PrintBarcodeEntities()) 
                        {
                            db.Database.ExecuteSqlCommand("UPDATE [BarcodeTemplate] SET [IsDeleted] = 1, [DeletedDate] = GETDATE() WHERE BarcodeTemplateID IN (" + ids + ")");
                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show(this, "Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bbiView_ItemClick(this, null);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiSelect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                int[] selectedRows = gbList.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    var arg = gbList.GetRowCellValue(selectedRows[selectedRows.Length - 1], colBarcodeTemplatePath);
                    if (arg == null)
                    {
                        MessageBox.Show(this, "Không có dữ liệu đường dẫn vui lòng chọn dòng khác !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else 
                    {
                        if (isSelectState)
                        {
                            RaiseSelectEventHander(arg.ToString());
                            this.Close();
                        }
                        else 
                        {
                            bbiEdit_ItemClick(this, null);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rptSelect_Click(object sender, EventArgs e)
        {
            bbiSelect_ItemClick(this, null);
        }
    }
}
