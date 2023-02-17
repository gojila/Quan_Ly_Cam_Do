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

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Business.Sale
{
    public partial class frmSale : XtraForm
    {
        public frmSale()
        {
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
            ReloadItem();
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

        private void gbList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                decimal price = 0;
                decimal goldWeight = 0;
                decimal laborFee = 0;
                decimal amount = 0;
                decimal totalWeight = 0;

                gbList.ClearColumnErrors();
                gbList.UpdateCurrentRow();
                if (_mColumn == Column.Lock) return;

                if (_mColumn == Column.None)
                {
                    if (e.Column.FieldName == colItemCode.FieldName)
                    {
                        _mColumn = Column.ItemName;
                    }
                    else if (e.Column.FieldName == colGoldType.FieldName)
                    {
                        _mColumn = Column.GoldType;
                    }
                    else if (e.Column.FieldName == colGoldType.FieldName)
                    {
                        _mColumn = Column.TotalWeight;
                    }
                    else if (e.Column.FieldName == colTotalWeight.FieldName)
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
                        _mColumn = Column.None;
                        break;
                    case Column.GoldWeight:
                        _mColumn = Column.Lock;

                        _mColumn = Column.None;
                        break;
                    case Column.StoneWeight:
                        _mColumn = Column.Lock;

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

                gbList.ClearColumnErrors();
                _mColumn = Column.None;
            }
            catch (Exception ex)
            {
                Common.Common.OpenErrorMessage(ex.Message);
            }
        }
    }
}
