using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
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
            New();
        }

        private void bbiRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Reload();
        }

        private void bbiEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Edit();
        }

        private void bbiDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Delete();
        }

        private void bbiPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gbList_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void gbList_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;
                if (menu != null)
                {
                    menu.Items.Clear(); // Clear the default menu items
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleList));

                    DXMenuItem newItem = new DXMenuItem("Thêm mới", OnCustomMenuNewItemClick);
                    newItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAdd.ImageOptions.Image")));
                    menu.Items.Add(newItem); // Add a custom menu item

                    DXMenuItem editItem = new DXMenuItem("Chỉnh sửa", OnCustomMenuEditItemClick);
                    editItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEdit.ImageOptions.Image")));
                    menu.Items.Add(editItem); // Add a custom menu item

                    DXMenuItem delItem = new DXMenuItem("Xóa", OnCustomMenuDelItemClick);
                    delItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDelete.ImageOptions.Image")));
                    menu.Items.Add(delItem); // Add a custom menu item

                    DXMenuItem printItem = new DXMenuItem("In", OnCustomMenuPrintItemClick);
                    printItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiPrint.ImageOptions.Image")));
                    menu.Items.Add(printItem); // Add a custom menu item

                    DXMenuItem refreshItem = new DXMenuItem("Làm mới", OnCustomMenuRefreshItemClick);
                    refreshItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
                    menu.Items.Add(refreshItem); // Add a custom menu item

                    e.Menu = menu; // Set the context menu
                }
            }
        }

        // event click popup menu
        private void OnCustomMenuNewItemClick(object sender, EventArgs e)
        {
            New();
        }

        private void OnCustomMenuEditItemClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void OnCustomMenuDelItemClick(object sender, EventArgs e)
        {
            Delete();
        }

        private void OnCustomMenuPrintItemClick(object sender, EventArgs e)
        {
            
        }

        private void OnCustomMenuRefreshItemClick(object sender, EventArgs e)
        {
            Reload();
        }

        private void frmSaleList_Load(object sender, EventArgs e)
        {            
            Reload();
        }

        private void Reload()
        {
            // TODO: This line of code loads data into the 'dsSale.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.dsSale.Sale);
        }

        private void New()
        {
            _frmSale = new frmSale(Common.ActionType.AddNew, 0);
            _frmSale.SaveEvent += (ss) =>
            {
                Reload();
            };
            _frmSale.FormClosing += (ss, ee) =>
            {
                _frmSale = null;
            };
            _frmSale.ShowDialog();
        }

        private void Edit()
        {
            int rowIndex = gbList.FocusedRowHandle;
            var arg = gbList.GetRowCellValue(rowIndex, colSaleID);
            var saleID = Convert.ToInt64(arg);
            _frmSale = new frmSale(Common.ActionType.Update, saleID);
            _frmSale.SaveEvent += (ss) =>
            {
                Reload();
            };
            _frmSale.FormClosing += (ss, ee) =>
            {
                _frmSale = null;
            };
            _frmSale.ShowDialog();
        }

        private void Delete()
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
                            var arg = gbList.GetRowCellValue(selectedRows[i], colSaleID);
                            if (arg != null)
                            {
                                var tempId = Convert.ToInt32(arg);
                                var sale = (from _sale in db.Sales
                                            where _sale.SaleID == tempId && !(_sale.IsDeleted ?? false)
                                            select _sale).FirstOrDefault();
                                if (sale != null)
                                {
                                    sale.IsDeleted = true;
                                    sale.DeletedDate = DateTime.Now;
                                    var saleDetails = (from _saleDetails in db.Sale_Detail
                                                       where _saleDetails.SaleID == tempId && !(_saleDetails.IsDeleted ?? false)
                                                       select _saleDetails).ToList();
                                    if(saleDetails != null && saleDetails.Count > 0)
                                    {
                                        foreach(var sd in saleDetails)
                                        {
                                            sd.IsDeleted = true;
                                            sd.DeletedDate = DateTime.Now;
                                        }
                                    }    
                                }
                            }
                        }
                        db.SaveChanges();
                        Common.Common.OpenActionSuccessMessage();
                        Reload();
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }
    }
}
