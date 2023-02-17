using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class frmItemList : XtraForm
    {
        public frmItemList()
        {
            InitializeComponent();
        }

        private void frmItemList_Load(object sender, EventArgs e)
        {
            gbList.CustomDrawRowIndicator += (_s, _e) =>
            {
                int rowIndex = _e.RowHandle;
                if (rowIndex >= 0)
                {
                    rowIndex++;
                    _e.Info.DisplayText = rowIndex.ToString();
                }
            };
            gbList.ShownEditor += (ss, ee) =>
            {
                var view = ss as GridView;
                view.ActiveEditor.DoubleClick += (_ss, _ee) =>
                {
                    bbiEdit_ItemClick(this, null);
                };
            };
            Reload();
        }

        private void bbiAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                var _frmItem = new frmItem();
                _frmItem.SaveEvent += (ss) =>
                {
                    bbiView_ItemClick(this, null);
                };
                _frmItem.ShowDialog();
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                int[] selectedRows = gbList.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    var arg = gbList.GetRowCellValue(selectedRows[selectedRows.Length - 1], colItemID);
                    if (arg != null)
                    {
                        var Id = Convert.ToInt64(arg);
                        var _frmItem = new frmItem(Id);
                        _frmItem.SaveEvent += (ss) => 
                        {
                            bbiView_ItemClick(this, null);
                        };
                        _frmItem.ShowDialog();
                    }
                }
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                int[] selectedRows = gbList.GetSelectedRows();
                if (selectedRows.Length > 0)
                {
                    if (Common.Common.OpenConfirmDeleteMessage() == DialogResult.Yes)
                    {
                        var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities();

                        for (int i = 0; i < selectedRows.Length; i++)
                        {
                            var arg = gbList.GetRowCellValue(selectedRows[i], colItemID);
                            if (arg != null)
                            {
                                var tempId = Convert.ToInt32(arg);
                                var item = (from _item in db.Items
                                            where _item.ItemID == tempId && !(_item.IsDeleted ?? false)
                                            select _item).FirstOrDefault();
                                if (item != null)
                                {
                                    item.IsDeleted = true;
                                    item.DeletedDate = DateTime.Now;
                                }
                            }
                        }
                        db.SaveChanges();
                        Common.Common.OpenActionSuccessMessage();
                        bbiView_ItemClick(this, null);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbiView_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            try 
            {
                this.itemTableAdapter.Fill(this.dsItem.Item);
                gbList.BestFitColumns();
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }
    }
}
