using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using Quan_Ly_Kinh_Doanh_Trang_Suc.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Business.Sale
{
    public partial class frmSale : XtraForm
    {
        private ActionType _actionType;
        private long _saleID = 0;

        public delegate void SaveEventHander(object sender);
        public event SaveEventHander SaveEvent;
        private void RaiseSaveEventHander()
        {
            if (SaveEvent != null)
            {
                SaveEvent(this);
            }
        }

        public frmSale()
        {
            InitializeComponent();
        }

        public frmSale(ActionType actionType, long saleID)
        {
            _actionType = actionType;
            _saleID = saleID;
            InitializeComponent();
        }

        private void frmSale_Load(object sender, EventArgs e)
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
                    //bbiEdit_ItemClick(this, null);
                };
            };

            gbListItem.CustomDrawRowIndicator += (_s, _e) =>
            {
                int rowIndex = _e.RowHandle;
                if (rowIndex >= 0)
                {
                    rowIndex++;
                    _e.Info.DisplayText = rowIndex.ToString();
                }
            };
            gbListItem.ShownEditor += (ss, ee) =>
            {
                var view = ss as GridView;
                view.ActiveEditor.DoubleClick += (_ss, _ee) =>
                {
                    //bbiEdit_ItemClick(this, null);
                };
            };

            gbList_ChangeItem.CustomDrawRowIndicator += (_s, _e) =>
            {
                int rowIndex = _e.RowHandle;
                if (rowIndex >= 0)
                {
                    rowIndex++;
                    _e.Info.DisplayText = rowIndex.ToString();
                }
            };

            ReloadItem();
            Init();
        }

        private void ReloadItem()
        {
            try 
            {
                this.itemTableAdapter.Fill(this.dsItem.Item);
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void Init()
        {
            switch(_actionType)
            {
                case ActionType.AddNew:
                    txtSaleNo.Text = "";
                    txtSaleMan.Text = "";
                    dtDocumentDate.DateTime = DateTime.Now;
                    EmptyRow();
                    break;
                case ActionType.Update:
                    using (var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities())
                    {
                        var sale = db.Sales.Where(s => s.SaleID == this._saleID && !(s.IsDeleted ?? false)).FirstOrDefault();
                        if (sale != null)
                        {
                            txtSaleNo.Text = sale.SaleCode;
                            txtSaleMan.Text = sale.Sale1;
                            dtDocumentDate.DateTime = sale.DocumentDate ?? DateTime.Now;
                            this.sale_DetailTableAdapter.Fill(this.dsSaleDetail.Sale_Detail, this._saleID);
                            sale_Change_Item_DetailTableAdapter.Fill(this.dsSaleDetail.Sale_Change_Item_Detail, _saleID);
                        }
                    }
                    break;
            }
        }

        private void EmptyRow()
        {           
            var rowCount = gbList.DataRowCount;
            for (var i = rowCount; i >= 0; i--)
                gbList.DeleteRow(i);

            var rowCountChangeItem = gbList_ChangeItem.DataRowCount;
            for (var i = rowCountChangeItem; i >= 0; i--)
                gbList_ChangeItem.DeleteRow(i);
        }

        private enum Column
        {
            None = 0,
            Lock = 1,
            ItemName = 2,
            GoldType = 3,
            TotalWeight = 4,
            GoldWeight = 5,
            StoneWeight = 6,
            Price = 7,
            LaborFee = 8,
            Amount = 9,
        }

        Column _mColumn;
        Column _mColumn_ChangeItem;

        private void gbList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal price = 0;
                decimal goldWeight = 0;
                decimal laborFee = 0;
                decimal amount = 0;
                decimal totalWeight = 0;
                decimal stoneWeight = 0;

                gbList.ClearColumnErrors();
                gbList.UpdateCurrentRow();
                if (_mColumn == Column.Lock) return;

                if (_mColumn == Column.None)
                {
                    if (e.Column.FieldName == colItemName.FieldName)
                    {
                        _mColumn = Column.ItemName;
                    }
                    else if (e.Column.FieldName == colGoldType.FieldName)
                    {
                        _mColumn = Column.GoldType;
                    }
                    else if (e.Column.FieldName == colTotalWeight.FieldName)
                    {
                        _mColumn = Column.TotalWeight;
                    }
                    else if (e.Column.FieldName == colGoldWeight.FieldName)
                    {
                        _mColumn = Column.GoldWeight;
                    }
                    else if (e.Column.FieldName == colStoneWeight.FieldName)
                    {
                        _mColumn = Column.StoneWeight;
                    }
                    else if (e.Column.FieldName == colPrice.FieldName)
                    {
                        _mColumn = Column.Price;
                    }
                    else if (e.Column.FieldName == colLaborFee.FieldName)
                    {
                        _mColumn = Column.LaborFee;
                    }
                    else if (e.Column.FieldName == colAmount.FieldName)
                    {
                        _mColumn = Column.Amount;
                    }
                }

                switch (_mColumn) 
                {
                    case Column.None:
                        return;
                    case Column.ItemName:
                        _mColumn = Column.Lock;
                        gbList.SetFocusedRowCellValue(colTotalWeight, 0);
                        gbList.SetFocusedRowCellValue(colGoldWeight, 0);
                        gbList.SetFocusedRowCellValue(colStoneWeight, 0);
                        gbList.SetFocusedRowCellValue(colPrice, 0);
                        gbList.SetFocusedRowCellValue(colLaborFee, 0);
                        gbList.SetFocusedRowCellValue(colAmount, 0);
                        _mColumn = Column.None;
                        break;
                    case Column.GoldType:
                        _mColumn = Column.Lock;

                        _mColumn = Column.None;
                        break;
                    case Column.TotalWeight:
                        _mColumn = Column.Lock;
                        totalWeight = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        goldWeight = totalWeight;
                        gbList.SetFocusedRowCellValue(colGoldWeight, goldWeight);
                        gbList.SetFocusedRowCellValue(colStoneWeight, 0);

                        price = gbList.GetFocusedRowCellValue(colPrice) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colPrice));
                        amount = (price * goldWeight) + laborFee;
                        laborFee = gbList.GetFocusedRowCellValue(colLaborFee) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colLaborFee));

                        amount = (price * goldWeight) + laborFee;
                        gbList.SetFocusedRowCellValue(colAmount, amount);
                        _mColumn = Column.None;
                        break;
                    case Column.GoldWeight:
                        _mColumn = Column.Lock;
                        goldWeight = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        price = gbList.GetFocusedRowCellValue(colPrice) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colPrice));
                        totalWeight = gbList.GetFocusedRowCellValue(colTotalWeight) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colTotalWeight));
                        stoneWeight = totalWeight - goldWeight;
                        gbList.SetFocusedRowCellValue(colStoneWeight, stoneWeight);
                        laborFee = gbList.GetFocusedRowCellValue(colLaborFee) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colLaborFee));
                        amount = (price * goldWeight) + laborFee;
                        gbList.SetFocusedRowCellValue(colAmount, amount);
                        _mColumn = Column.None;
                        break;
                    case Column.StoneWeight:
                        _mColumn = Column.Lock;
                        stoneWeight = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        totalWeight = gbList.GetFocusedRowCellValue(colTotalWeight) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colTotalWeight));
                        goldWeight = totalWeight - stoneWeight;
                        gbList.SetFocusedRowCellValue(colGoldWeight, goldWeight);
                        price = gbList.GetFocusedRowCellValue(colPrice) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colPrice));
                        laborFee = gbList.GetFocusedRowCellValue(colLaborFee) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colLaborFee));
                        amount = (price * goldWeight) + laborFee;
                        gbList.SetFocusedRowCellValue(colAmount, amount);
                        _mColumn = Column.None;
                        break;
                    case Column.Price:
                        _mColumn = Column.Lock;
                        price = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        goldWeight = gbList.GetFocusedRowCellValue(colGoldWeight) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colGoldWeight));
                        laborFee = gbList.GetFocusedRowCellValue(colLaborFee) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colLaborFee));
                        amount = (price * goldWeight) + laborFee;
                        gbList.SetFocusedRowCellValue(colAmount, amount);
                        _mColumn = Column.None;
                        break;
                    case Column.LaborFee:
                        _mColumn = Column.Lock;
                        price = gbList.GetFocusedRowCellValue(colPrice) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colPrice));
                        goldWeight = gbList.GetFocusedRowCellValue(colGoldWeight) == null ? 0 : Convert.ToDecimal(gbList.GetFocusedRowCellValue(colGoldWeight));
                        laborFee = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        amount = (price * goldWeight) + laborFee;
                        gbList.SetFocusedRowCellValue(colAmount, amount);
                        _mColumn = Column.None;
                        break;
                    case Column.Amount:
                        _mColumn = Column.Lock;

                        _mColumn = Column.None;
                        break;
                }

                CalculateDocumentAmt();
                gbList.ClearColumnErrors();
                _mColumn = Column.None;
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }


        private bool ValidateInput()
        {
            if(string.IsNullOrEmpty(txtSaleNo.Text))
            {
                Common.Common.OpenErrorMessage("Vui lòng nhập số hóa đơn !");
                return false;
            }
            if(string.IsNullOrEmpty(txtSaleMan.Text))
            {
                Common.Common.OpenErrorMessage("Vui lòng nhập người bán !");
                return false;
            }
            if(gbList.DataRowCount <= 0)
            {
                Common.Common.OpenErrorMessage("Vui lòng chọn sản phẩm !");
                return false;
            }    
            return true;
        }

        private bool Save()
        {
            try {
                if (!ValidateInput())
                    return false;
                switch (_actionType)
                {
                    case ActionType.AddNew:
                        using (var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities())
                        {
                            using (DbContextTransaction transaction = db.Database.BeginTransaction())
                            {
                                try
                                {
                                    // -----
                                    // Sale
                                    var sale = new Database.Sale();

                                    sale.SaleCode = txtSaleNo.Text;
                                    sale.CompanyID = 0;
                                    sale.DocumentDate = dtDocumentDate.DateTime;
                                    sale.LaborFee = 0;
                                    sale.LaborFee = colLaborFee.SummaryItem.HasValue ? (decimal)colLaborFee.SummaryItem.SummaryValue : 0;
                                    
                                    sale.DocumentAmountBF = colPrice.SummaryItem.HasValue ? (decimal)colPrice.SummaryItem.SummaryValue : 0;
                                    sale.DiscountRate = 0;
                                    sale.DiscountAmount = 0;
                                    sale.TaxRate = 0;
                                    sale.TaxAmount = 0;
                                    
                                    sale.DocumentAmount = colAmount.SummaryItem.HasValue ? (decimal)colAmount.SummaryItem.SummaryValue : 0;
                                    sale.Sale1 = txtSaleMan.Text;
                                    sale.Descriptions = "";
                                    sale.IsDeleted = false;
                                    
                                    sale.CreatedDate = DateTime.Now;
                                    db.Sales.Add(sale);
                                    db.SaveChanges();
                                    // ---------
                                    // Sales detail
                                    for (var i = 0; i < gbList.DataRowCount; i++)
                                    {
                                        var saleDetail = new Database.Sale_Detail();
                                        saleDetail.SaleID = sale.SaleID;
                                        saleDetail.SaleCode = sale.SaleCode;
                                        var itemID = Convert.ToInt64(gbList.GetRowCellValue(i, colItemName));
                                        saleDetail.ItemID = itemID;
                                        saleDetail.ItemCode = itemID;
                                        saleDetail.ItemName = gbList.GetRowCellDisplayText(i, colItemName);
                                        saleDetail.GoldType = gbList.GetRowCellValue(i, colGoldType).ToString();
                                        var totalWeight = gbList.GetRowCellValue(i, colTotalWeight);
                                        saleDetail.TotalWeight = totalWeight == null ? 0 : (decimal)totalWeight;
                                        var goldWeight = gbList.GetRowCellValue(i, colGoldWeight);
                                        saleDetail.GoldWeight = goldWeight == null ? 0 : (decimal)goldWeight;
                                        var stoneWeight = gbList.GetRowCellValue(i, colStoneWeight);
                                        saleDetail.StoneWeight = stoneWeight == null ? 0 : (decimal)stoneWeight;
                                        var price = gbList.GetRowCellValue(i, colPrice);
                                        saleDetail.Price = price == null ? 0 : (decimal)price;
                                        var laborFee = gbList.GetRowCellValue(i, colLaborFee);
                                        saleDetail.LaborFee = laborFee == null ? 0 : (decimal)laborFee;
                                        var amount = gbList.GetRowCellValue(i, colAmount);
                                        saleDetail.Amount = amount == null ? 0 : (decimal)amount;
                                        saleDetail.Descriptions = gbList.GetRowCellValue(i, colDescriptions.FieldName).ToString();
                                        saleDetail.IsDeleted = false;
                                        saleDetail.CreatedDate = DateTime.Now;
                                        db.Sale_Detail.Add(saleDetail);
                                    }
                                    // ---------
                                    // Change item
                                    for(var i = 0; i < gbList_ChangeItem.DataRowCount; i++)
                                    {
                                        var changeItem = new Database.Sale_Change_Item_Detail();
                                        changeItem.SaleID = sale.SaleID;
                                        changeItem.SaleCode = sale.SaleCode;
                                        var itemID = Convert.ToInt64(gbList_ChangeItem.GetRowCellValue(i, colItemID3));
                                        changeItem.ItemID = itemID;
                                        changeItem.ItemCode = itemID;
                                        changeItem.ItemName = gbList_ChangeItem.GetRowCellDisplayText(i, colItemID3);
                                        changeItem.GoldType = gbList_ChangeItem.GetRowCellValue(i, colGoldType1).ToString();
                                        var totalWeight = gbList_ChangeItem.GetRowCellValue(i, colTotalWeight1);
                                        changeItem.TotalWeight = totalWeight == null ? 0 : (decimal)totalWeight;
                                        var goldWeight = gbList_ChangeItem.GetRowCellValue(i, colGoldWeight1);
                                        changeItem.GoldWeight = goldWeight == null ? 0 : (decimal)goldWeight;
                                        var stoneWeight = gbList_ChangeItem.GetRowCellValue(i, colStoneWeight1);
                                        changeItem.StoneWeight = stoneWeight == null ? 0 : (decimal)stoneWeight;
                                        var price = gbList_ChangeItem.GetRowCellValue(i, colPrice1);
                                        changeItem.Price = price == null ? 0 : (decimal)price;                                        
                                        var amount = gbList_ChangeItem.GetRowCellValue(i, colAmount1);
                                        changeItem.Amount = amount == null ? 0 : (decimal)amount;
                                        changeItem.Descriptions = gbList_ChangeItem.GetRowCellValue(i, colDescriptions3.FieldName).ToString();
                                        changeItem.IsDeleted = false;
                                        changeItem.CreatedDate = DateTime.Now;
                                        db.Sale_Change_Item_Detail.Add(changeItem);
                                    }
                                    db.SaveChanges();
                                    transaction.Commit();
                                    RaiseSaveEventHander();
                                    Common.Common.OpenSuccessMessage("Lưu thành công");
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    Common.Common.OpenErrorMessage(ex.Message);
                                    return false;
                                }
                            }
                        };
                    case ActionType.Update:
                        using (var db = new Database.Quan_Ly_Kinh_Doanh_Trang_SucEntities())
                        {
                            using (DbContextTransaction transaction = db.Database.BeginTransaction())
                            {
                                try
                                {
                                    // ----- 
                                    // Update Sale
                                    var sale = db.Sales.Where(s => s.SaleID == this._saleID).FirstOrDefault();
                                    
                                    sale.SaleID = this._saleID;
                                    sale.SaleCode = txtSaleNo.Text;
                                    sale.CompanyID = 0;
                                    sale.DocumentDate = dtDocumentDate.DateTime;
                                    sale.LaborFee = 0;
                                    
                                    sale.LaborFee = colLaborFee.SummaryItem.HasValue ? (decimal)colLaborFee.SummaryItem.SummaryValue : 0;
                                    sale.DocumentAmountBF = colPrice.SummaryItem.HasValue ? (decimal)colPrice.SummaryItem.SummaryValue : 0;
                                    sale.DiscountRate = 0;
                                    sale.DiscountAmount = 0;
                                    sale.TaxRate = 0;
                                    
                                    sale.TaxAmount = 0;
                                    sale.DocumentAmount = colAmount.SummaryItem.HasValue ? (decimal)colAmount.SummaryItem.SummaryValue : 0;
                                    sale.Sale1 = txtSaleMan.Text;
                                    sale.Descriptions = "";                                    
                                    sale.ModifiedDate = DateTime.Now;
                                    
                                    db.Entry(sale).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();

                                    // ----------
                                    // Process Sales detail
                                    var listDetails = db.Sale_Detail.Where(sd => sd.SaleID == sale.SaleID && !(sd.IsDeleted ?? false)).ToList();
                                    var listSaleDetailIds = new List<long>();
                                    // Add or update sale detail
                                    for (var i = 0; i < gbList.DataRowCount; i++)
                                    {
                                        var saleDetailID = Convert.ToInt64(gbList.GetRowCellValue(i, colSaleDetailID));
                                        listSaleDetailIds.Add(saleDetailID);
                                        var saleDetail = listDetails.Find(sd => sd.SaleDetailID == saleDetailID);
                                        if(saleDetail == null)
                                        {
                                            saleDetail = new Database.Sale_Detail();
                                            saleDetail.IsDeleted = false;
                                            saleDetail.CreatedDate = DateTime.Now;
                                            db.Entry(saleDetail).State = EntityState.Added;
                                        }
                                        else
                                        {
                                            saleDetail.ModifiedDate = DateTime.Now;
                                            db.Entry(saleDetail).State = EntityState.Modified;
                                        }
                                        saleDetail.SaleID = sale.SaleID;
                                        saleDetail.SaleCode = sale.SaleCode;
                                        var itemIDObj = gbList.GetRowCellValue(i, colItemName);
                                        var itemID = Convert.ToInt64(itemIDObj);
                                        saleDetail.ItemID = itemID;
                                        saleDetail.ItemCode = itemID;
                                        saleDetail.ItemName = gbList.GetRowCellDisplayText(i, colItemName);
                                        saleDetail.GoldType = gbList.GetRowCellValue(i, colGoldType).ToString();
                                        var totalWeight = gbList.GetRowCellValue(i, colTotalWeight);
                                        saleDetail.TotalWeight = totalWeight == null ? 0 : (decimal)totalWeight;
                                        var goldWeight = gbList.GetRowCellValue(i, colGoldWeight);
                                        saleDetail.GoldWeight = goldWeight == null ? 0 : (decimal)goldWeight;
                                        var stoneWeight = gbList.GetRowCellValue(i, colStoneWeight);
                                        saleDetail.StoneWeight = stoneWeight == null ? 0 : (decimal)stoneWeight;
                                        var price = gbList.GetRowCellValue(i, colPrice);
                                        saleDetail.Price = price == null ? 0 : (decimal)price;
                                        var laborFee = gbList.GetRowCellValue(i, colLaborFee);
                                        saleDetail.LaborFee = laborFee == null ? 0 : (decimal)laborFee;
                                        var amount = gbList.GetRowCellValue(i, colAmount);
                                        saleDetail.Amount = amount == null ? 0 : (decimal)amount;
                                        saleDetail.Descriptions = gbList.GetRowCellValue(i, colDescriptions.FieldName).ToString();                                                                        
                                        //db.Sale_Detail.Add(saleDetail);
                                    }
                                    // Delete sale detail
                                    var listDeleteSaleDetails = listDetails.Where(sd => !listSaleDetailIds.Contains(sd.SaleDetailID)).ToList();
                                    if(listDeleteSaleDetails.Count > 0)
                                    {
                                        foreach(var saleDetailDel in listDeleteSaleDetails)
                                        {
                                            saleDetailDel.IsDeleted = true;
                                            saleDetailDel.DeletedDate = DateTime.Now;
                                            db.Entry(saleDetailDel).State = EntityState.Modified;
                                        }
                                    }

                                    // --------
                                    // Process change item detail
                                    var listChangeItemDetails = db.Sale_Change_Item_Detail.Where(ci => ci.SaleID == sale.SaleID && !(ci.IsDeleted ?? false)).ToList();
                                    var listChangeItemDetailIds = new List<long>();
                                    // Add or update change item detail
                                    for (var i = 0; i < gbList_ChangeItem.DataRowCount; i++)
                                    {
                                        var changeItemDetailID = Convert.ToInt64(gbList_ChangeItem.GetRowCellValue(i, colChangeItemDetailID));
                                        listChangeItemDetailIds.Add(changeItemDetailID);
                                        var changeItemDetail = listChangeItemDetails.Find(ci => ci.SaleChangeItemDetailID == changeItemDetailID);
                                        if (changeItemDetail == null)
                                        {
                                            changeItemDetail = new Database.Sale_Change_Item_Detail();
                                            changeItemDetail.IsDeleted = false;
                                            changeItemDetail.CreatedDate = DateTime.Now;
                                            db.Entry(changeItemDetail).State = EntityState.Added;
                                        }
                                        else
                                        {
                                            changeItemDetail.ModifiedDate = DateTime.Now;
                                            db.Entry(changeItemDetail).State = EntityState.Modified;
                                        }
                                        changeItemDetail.SaleID = sale.SaleID;
                                        changeItemDetail.SaleCode = sale.SaleCode;
                                        var itemIDObj = gbList_ChangeItem.GetRowCellValue(i, colItemID3);
                                        var itemID = Convert.ToInt64(itemIDObj);
                                        changeItemDetail.ItemID = itemID;
                                        changeItemDetail.ItemCode = itemID;
                                        changeItemDetail.ItemName = gbList_ChangeItem.GetRowCellDisplayText(i, colItemID3);
                                        changeItemDetail.GoldType = gbList_ChangeItem.GetRowCellValue(i, colGoldType).ToString();
                                        var totalWeight = gbList_ChangeItem.GetRowCellValue(i, colTotalWeight1);
                                        changeItemDetail.TotalWeight = totalWeight == null ? 0 : (decimal)totalWeight;
                                        var goldWeight = gbList_ChangeItem.GetRowCellValue(i, colGoldWeight1);
                                        changeItemDetail.GoldWeight = goldWeight == null ? 0 : (decimal)goldWeight;
                                        var stoneWeight = gbList_ChangeItem.GetRowCellValue(i, colStoneWeight1);
                                        changeItemDetail.StoneWeight = stoneWeight == null ? 0 : (decimal)stoneWeight;
                                        var price = gbList_ChangeItem.GetRowCellValue(i, colPrice1);
                                        changeItemDetail.Price = price == null ? 0 : (decimal)price;
                                        
                                        var amount = gbList_ChangeItem.GetRowCellValue(i, colAmount1);
                                        changeItemDetail.Amount = amount == null ? 0 : (decimal)amount;
                                        changeItemDetail.Descriptions = gbList_ChangeItem.GetRowCellValue(i, colDescriptions3.FieldName).ToString();
                                        //db.Sale_Detail.Add(saleDetail);
                                    }
                                    // Delete sale change item details
                                    var listDeleteChangeItemDetails = listChangeItemDetails.Where(ci => !listChangeItemDetailIds.Contains(ci.SaleChangeItemDetailID)).ToList();
                                    if (listDeleteChangeItemDetails.Count > 0)
                                    {
                                        foreach (var changeItemDetailDel in listDeleteChangeItemDetails)
                                        {
                                            changeItemDetailDel.IsDeleted = true;
                                            changeItemDetailDel.DeletedDate = DateTime.Now;
                                            db.Entry(changeItemDetailDel).State = EntityState.Modified;
                                        }
                                    }

                                    db.SaveChanges();
                                    transaction.Commit();
                                    RaiseSaveEventHander();
                                    Common.Common.OpenSuccessMessage("Lưu thành công");
                                    return true;
                                }
                                catch (Exception ex)
                                {
                                    transaction.Rollback();
                                    Common.Common.OpenErrorMessage(ex.Message);
                                    return false;
                                }
                            }                                
                        }
                            
                    default:
                        return true;
                }
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
                return false;
            }            
        }
        
        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gbListItem_DoubleClick(object sender, EventArgs e)
        {
            var gridView = sender as GridView;
            if (gridView == null)
                return;

            DataRow row = gridView.GetDataRow(gridView.FocusedRowHandle);
            if (row == null) 
                return;

            var itemID = Convert.ToInt64(row[0]);
            //var itemName = row[2];
            gbList.ClearSelection();
            for (var i = 0; i < gbList.DataRowCount; i++)
            {
                var arg = gbList.GetRowCellValue(i, colItemName);
                var oldItemID = Convert.ToInt64(arg);
                if(oldItemID == itemID)
                {                    
                    gbList.FocusedRowHandle = i;
                    gbList.SelectRow(i);
                    return;
                }
            }
            gbList.AddNewRow();
            gbList.ShowEditor();
            gbList.SetFocusedRowCellValue(colItemName, itemID);
        }

        private void bbiSaveNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this._actionType = ActionType.AddNew;
                this._saleID = 0;
                Init();
            }
        }

        private void bbiSaveClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        private void bbiSavePrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        private void gbList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;
                if (menu != null)
                {
                    menu.Items.Clear(); // Clear the default menu items

                    DXMenuItem item = new DXMenuItem("Xóa sản phẩm", OnCustomMenuItemClick);
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
                    item.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
                    menu.Items.Add(item); // Add a custom menu item

                    e.Menu = menu; // Set the context menu
                }
            }
        }

        // event click popup menu gb_List
        private void OnCustomMenuItemClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa sản phẩm này không ?", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                gbList.DeleteSelectedRows();
                gbList.UpdateCurrentRow();
            }
        }

        private void gbList_ChangeItem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try 
            {
                decimal price = 0;
                decimal goldWeight = 0;
                decimal amount = 0;
                decimal totalWeight = 0;

                gbList_ChangeItem.ClearColumnErrors();
                gbList_ChangeItem.UpdateCurrentRow();
                if (_mColumn_ChangeItem == Column.Lock) return;

                if (_mColumn_ChangeItem == Column.None)
                {
                    if (e.Column.FieldName == colItemID3.FieldName)
                    {
                        _mColumn_ChangeItem = Column.ItemName;
                    }
                    else if (e.Column.FieldName == colGoldType1.FieldName)
                    {
                        _mColumn_ChangeItem = Column.GoldType;
                    }
                    else if (e.Column.FieldName == colTotalWeight1.FieldName)
                    {
                        _mColumn_ChangeItem = Column.TotalWeight;
                    }
                    else if (e.Column.FieldName == colGoldWeight1.FieldName)
                    {
                        _mColumn_ChangeItem = Column.GoldWeight;
                    }
                    else if (e.Column.FieldName == colStoneWeight.FieldName)
                    {
                        _mColumn_ChangeItem = Column.StoneWeight;
                    }
                    else if (e.Column.FieldName == colPrice.FieldName)
                    {
                        _mColumn_ChangeItem = Column.Price;
                    }
                    else if (e.Column.FieldName == colAmount.FieldName)
                    {
                        _mColumn_ChangeItem = Column.Amount;
                    }
                }

                switch (_mColumn_ChangeItem)
                {
                    case Column.None:
                        return;
                    case Column.ItemName:
                        _mColumn_ChangeItem = Column.Lock;
                        gbList_ChangeItem.SetFocusedRowCellValue(colTotalWeight1, 0);
                        gbList_ChangeItem.SetFocusedRowCellValue(colGoldWeight1, 0);
                        gbList_ChangeItem.SetFocusedRowCellValue(colStoneWeight1, 0);
                        gbList_ChangeItem.SetFocusedRowCellValue(colPrice1, 0);
                        gbList_ChangeItem.SetFocusedRowCellValue(colAmount1, 0);
                        _mColumn_ChangeItem = Column.None;
                        break;
                    case Column.GoldType:
                        _mColumn_ChangeItem = Column.Lock;

                        _mColumn_ChangeItem = Column.None;
                        break;
                    case Column.TotalWeight:
                        _mColumn_ChangeItem = Column.Lock;
                        totalWeight = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        _mColumn_ChangeItem = Column.None;
                        break;
                    case Column.GoldWeight:
                        _mColumn_ChangeItem = Column.Lock;
                        goldWeight = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        price = gbList_ChangeItem.GetFocusedRowCellValue(colPrice1) == null ? 0 : Convert.ToDecimal(gbList_ChangeItem.GetFocusedRowCellValue(colPrice1));
                        amount = (price * goldWeight);
                        gbList_ChangeItem.SetFocusedRowCellValue(colAmount1, amount);
                        _mColumn_ChangeItem = Column.None;
                        break;
                    case Column.StoneWeight:
                        _mColumn_ChangeItem = Column.Lock;

                        _mColumn_ChangeItem = Column.None;
                        break;
                    case Column.Price:
                        _mColumn_ChangeItem = Column.Lock;
                        price = Convert.ToDecimal(e.Value == DBNull.Value ? 0 : e.Value);
                        goldWeight = gbList_ChangeItem.GetFocusedRowCellValue(colGoldWeight1) == null ? 0 : Convert.ToDecimal(gbList_ChangeItem.GetFocusedRowCellValue(colGoldWeight1));
                        amount = (price * goldWeight);
                        gbList_ChangeItem.SetFocusedRowCellValue(colAmount1, amount);
                        _mColumn_ChangeItem = Column.None;
                        break;
                    case Column.Amount:
                        _mColumn_ChangeItem = Column.Lock;

                        _mColumn_ChangeItem = Column.None;
                        break;
                }

                CalculateDocumentAmt();
                gbList_ChangeItem.ClearColumnErrors();
                _mColumn_ChangeItem = Column.None;
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void gbList_ChangeItem_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == GridMenuType.Row)
            {
                GridViewMenu menu = e.Menu as GridViewMenu;
                if (menu != null)
                {
                    menu.Items.Clear(); // Clear the default menu items

                    DXMenuItem item = new DXMenuItem("Xóa sản phẩm", OnCustomChangeItemMenuItemClick);
                    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSale));
                    item.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
                    menu.Items.Add(item); // Add a custom menu item

                    e.Menu = menu; // Set the context menu
                }
            }
        }

        // event click popup menu gbList_ChangeItem
        private void OnCustomChangeItemMenuItemClick(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có chắc là muốn xóa sản phẩm này không ?", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gbList_ChangeItem.DeleteSelectedRows();
                gbList_ChangeItem.UpdateCurrentRow();
            }
        }

        private decimal GetTotalAmountBf()
        {
            try
            {
                decimal discountAmt = txtDiscountAmount.Value;
                decimal taxAmt = txtTaxAmount.Value;
                decimal saleDetailTotalAmt = 0;
                decimal saleChangeDetailTotalAmt = 0;
                decimal documentAmountBF = 0;
                foreach (DataRow dr in dsSaleDetail.Sale_Detail.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        saleDetailTotalAmt += dr["Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Amount"]);
                    }
                }

                foreach (DataRow dr in dsSaleDetail.Sale_Change_Item_Detail.Rows)
                {
                    if (dr.RowState != DataRowState.Deleted)
                    {
                        saleChangeDetailTotalAmt += dr["Amount"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["Amount"]);
                    }
                }

                documentAmountBF = saleDetailTotalAmt - saleChangeDetailTotalAmt;
                return documentAmountBF;
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
                return 0;
            }
        }

        private void CalculateDocumentAmount()
        {
            try 
            {
                decimal discountAmt = txtDiscountAmount.Value;
                decimal taxAmt = txtTaxAmount.Value;
                decimal documentAmountBF = GetTotalAmountBf();
                decimal documentAmount = 0;

                documentAmount = documentAmountBF - discountAmt + taxAmt;
                txtDocumentAmount.Value = documentAmount;
            }
            catch (Exception ex) 
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        DiscountUpdateStatus _discountStatus;
        private enum DiscountUpdateStatus 
        {
            None = 0,
            Lock = 1,
        }

        TaxUpdateStatus _taxStatus;
        private enum TaxUpdateStatus
        {
            None = 0,
            Lock = 1,
        }

        private void txtDiscountRate_EditValueChanged(object sender, EventArgs e)
        {
            try 
            {
                if (_discountStatus == DiscountUpdateStatus.None) 
                {
                    decimal discountRate = txtDiscountRate.Value;
                    decimal documentAmountBF = GetTotalAmountBf();
                    decimal discountAmt = discountRate == 0 ? 0 : (documentAmountBF / 100 * discountRate);

                    _discountStatus = DiscountUpdateStatus.Lock;
                    txtDiscountAmount.Value = discountAmt;
                    CalculateDocumentAmt();
                    _discountStatus = DiscountUpdateStatus.None;
                }
            }
            catch (Exception ex) 
            {
                _discountStatus = DiscountUpdateStatus.None;
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void txtDiscountAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_discountStatus == DiscountUpdateStatus.None)
                {
                    decimal discountAmt = txtDiscountAmount.Value;
                    decimal documentAmountBF = GetTotalAmountBf();
                    decimal discountRate = documentAmountBF == 0 ? 0 : (discountAmt / documentAmountBF * 100);

                    _discountStatus = DiscountUpdateStatus.Lock;
                    txtDiscountRate.Value = discountRate;
                    CalculateDocumentAmt();
                    _discountStatus = DiscountUpdateStatus.None;
                }
            }
            catch (Exception ex)
            {
                _discountStatus = DiscountUpdateStatus.None;
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void txtTaxRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_taxStatus == TaxUpdateStatus.None)
                {
                    decimal taxRate = txtTaxRate.Value;
                    decimal documentAmountBF = GetTotalAmountBf();
                    decimal discountAmt = txtDiscountAmount.Value;
                    decimal documentAmountBFTax = documentAmountBF - discountAmt;
                    decimal taxAmt = documentAmountBFTax / 100 * taxRate;
                    _taxStatus = TaxUpdateStatus.Lock;
                    txtTaxAmount.Value = taxAmt;
                    CalculateDocumentAmt();
                    _taxStatus = TaxUpdateStatus.None;
                }
            }
            catch (Exception ex)
            {
                _taxStatus = TaxUpdateStatus.None;
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void txtTaxAmount_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (_taxStatus == TaxUpdateStatus.None)
                {
                    decimal documentAmountBF = GetTotalAmountBf();
                    decimal discountAmt = txtDiscountAmount.Value;
                    decimal documentAmountBFTax = documentAmountBF - discountAmt;
                    decimal taxAmt = txtTaxAmount.Value;
                    decimal taxRate = documentAmountBFTax == 0 ? 0 : (taxAmt / documentAmountBFTax * 100);
                    _taxStatus = TaxUpdateStatus.Lock;
                    txtTaxRate.Value = taxRate;
                    CalculateDocumentAmt();
                    _taxStatus = TaxUpdateStatus.None;
                }
            }
            catch (Exception ex)
            {
                _taxStatus = TaxUpdateStatus.None;
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }

        private void CalculateDocumentAmt() 
        {
            try
            {
                decimal documentAmountBF = GetTotalAmountBf();
                decimal discountAmt = txtDiscountAmount.Value;
                decimal taxAmt = txtTaxAmount.Value;
                decimal documentAmt = documentAmountBF - discountAmt + taxAmt;
                txtDocumentAmount.Value = documentAmt;
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }
    }
}
