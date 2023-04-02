
namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Business.Sale
{
    partial class frmSaleList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSaleList));
            this.bm = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.bbiAdd = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.frmSaleListlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.gcList = new DevExpress.XtraGrid.GridControl();
            this.saleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSale = new Quan_Ly_Kinh_Doanh_Trang_Suc.DataSet.Sale.dsSale();
            this.gbList = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSaleID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompanyID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaleCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalePeople = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLaborFee = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rptCal = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colDocumentAmountBF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiscountRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rptCalPercent = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colDiscountAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxRate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDocumentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescriptions = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colModifiedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.saleTableAdapter = new Quan_Ly_Kinh_Doanh_Trang_Suc.DataSet.Sale.dsSaleTableAdapters.SaleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmSaleListlayoutControl1ConvertedLayout)).BeginInit();
            this.frmSaleListlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCalPercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // bm
            // 
            this.bm.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bm.DockControls.Add(this.barDockControlTop);
            this.bm.DockControls.Add(this.barDockControlBottom);
            this.bm.DockControls.Add(this.barDockControlLeft);
            this.bm.DockControls.Add(this.barDockControlRight);
            this.bm.Form = this;
            this.bm.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAdd,
            this.bbiEdit,
            this.bbiDelete,
            this.bbiPrint,
            this.bbiClose,
            this.bbiRefresh});
            this.bm.MainMenu = this.bar2;
            this.bm.MaxItemId = 6;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiAdd),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiPrint),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbiClose)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiRefresh
            // 
            this.bbiRefresh.Caption = "Xem";
            this.bbiRefresh.Id = 5;
            this.bbiRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.Image")));
            this.bbiRefresh.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiRefresh.ImageOptions.LargeImage")));
            this.bbiRefresh.Name = "bbiRefresh";
            this.bbiRefresh.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefresh_ItemClick);
            // 
            // bbiAdd
            // 
            this.bbiAdd.Caption = "Thêm";
            this.bbiAdd.Id = 0;
            this.bbiAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiAdd.ImageOptions.Image")));
            this.bbiAdd.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiAdd.ImageOptions.LargeImage")));
            this.bbiAdd.Name = "bbiAdd";
            this.bbiAdd.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAdd_ItemClick);
            // 
            // bbiEdit
            // 
            this.bbiEdit.Caption = "Sửa";
            this.bbiEdit.Id = 1;
            this.bbiEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiEdit.ImageOptions.Image")));
            this.bbiEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiEdit.ImageOptions.LargeImage")));
            this.bbiEdit.Name = "bbiEdit";
            this.bbiEdit.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEdit_ItemClick);
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Xóa";
            this.bbiDelete.Id = 2;
            this.bbiDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiDelete.ImageOptions.Image")));
            this.bbiDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiDelete.ImageOptions.LargeImage")));
            this.bbiDelete.Name = "bbiDelete";
            this.bbiDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDelete_ItemClick);
            // 
            // bbiPrint
            // 
            this.bbiPrint.Caption = "In";
            this.bbiPrint.Id = 3;
            this.bbiPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiPrint.ImageOptions.Image")));
            this.bbiPrint.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiPrint.ImageOptions.LargeImage")));
            this.bbiPrint.Name = "bbiPrint";
            this.bbiPrint.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPrint_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Đóng";
            this.bbiClose.Id = 4;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bm;
            this.barDockControlTop.Size = new System.Drawing.Size(800, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.bm;
            this.barDockControlBottom.Size = new System.Drawing.Size(800, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.bm;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 426);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(800, 24);
            this.barDockControlRight.Manager = this.bm;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 426);
            // 
            // frmSaleListlayoutControl1ConvertedLayout
            // 
            this.frmSaleListlayoutControl1ConvertedLayout.Controls.Add(this.gcList);
            this.frmSaleListlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmSaleListlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 24);
            this.frmSaleListlayoutControl1ConvertedLayout.Name = "frmSaleListlayoutControl1ConvertedLayout";
            this.frmSaleListlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(716, 209, 650, 400);
            this.frmSaleListlayoutControl1ConvertedLayout.Root = this.Root;
            this.frmSaleListlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(800, 426);
            this.frmSaleListlayoutControl1ConvertedLayout.TabIndex = 4;
            // 
            // gcList
            // 
            this.gcList.DataSource = this.saleBindingSource;
            this.gcList.Location = new System.Drawing.Point(12, 12);
            this.gcList.MainView = this.gbList;
            this.gcList.MenuManager = this.bm;
            this.gcList.Name = "gcList";
            this.gcList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rptCal,
            this.rptCalPercent});
            this.gcList.Size = new System.Drawing.Size(776, 402);
            this.gcList.TabIndex = 4;
            this.gcList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gbList});
            // 
            // saleBindingSource
            // 
            this.saleBindingSource.DataMember = "Sale";
            this.saleBindingSource.DataSource = this.dsSale;
            // 
            // dsSale
            // 
            this.dsSale.DataSetName = "dsSale";
            this.dsSale.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbList
            // 
            this.gbList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSaleID,
            this.colCompanyID,
            this.colSaleCode,
            this.colSalePeople,
            this.colDocumentDate,
            this.colLaborFee,
            this.colDocumentAmountBF,
            this.colDiscountRate,
            this.colDiscountAmount,
            this.colTaxRate,
            this.colTaxAmount,
            this.colDocumentAmount,
            this.colDescriptions,
            this.colCreatedDate,
            this.colModifiedDate});
            this.gbList.GridControl = this.gcList;
            this.gbList.Name = "gbList";
            this.gbList.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.gbList.OptionsBehavior.Editable = false;
            this.gbList.OptionsView.ShowFooter = true;
            this.gbList.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gbList_PopupMenuShowing);
            this.gbList.DoubleClick += new System.EventHandler(this.gbList_DoubleClick);
            // 
            // colSaleID
            // 
            this.colSaleID.FieldName = "SaleID";
            this.colSaleID.Name = "colSaleID";
            // 
            // colCompanyID
            // 
            this.colCompanyID.FieldName = "CompanyID";
            this.colCompanyID.Name = "colCompanyID";
            // 
            // colSaleCode
            // 
            this.colSaleCode.Caption = "Số hóa đơn";
            this.colSaleCode.FieldName = "SaleCode";
            this.colSaleCode.Name = "colSaleCode";
            this.colSaleCode.Visible = true;
            this.colSaleCode.VisibleIndex = 0;
            // 
            // colSalePeople
            // 
            this.colSalePeople.Caption = "Người bán";
            this.colSalePeople.FieldName = "Sale";
            this.colSalePeople.Name = "colSalePeople";
            this.colSalePeople.Visible = true;
            this.colSalePeople.VisibleIndex = 1;
            // 
            // colDocumentDate
            // 
            this.colDocumentDate.Caption = "Ngày bán";
            this.colDocumentDate.FieldName = "DocumentDate";
            this.colDocumentDate.Name = "colDocumentDate";
            this.colDocumentDate.Visible = true;
            this.colDocumentDate.VisibleIndex = 2;
            // 
            // colLaborFee
            // 
            this.colLaborFee.Caption = "Tiền công";
            this.colLaborFee.ColumnEdit = this.rptCal;
            this.colLaborFee.FieldName = "LaborFee";
            this.colLaborFee.Name = "colLaborFee";
            this.colLaborFee.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "LaborFee", "{0:##,##0.###}")});
            this.colLaborFee.Visible = true;
            this.colLaborFee.VisibleIndex = 3;
            // 
            // rptCal
            // 
            this.rptCal.AutoHeight = false;
            this.rptCal.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rptCal.DisplayFormat.FormatString = "{0:##,##0.###}";
            this.rptCal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rptCal.Name = "rptCal";
            // 
            // colDocumentAmountBF
            // 
            this.colDocumentAmountBF.ColumnEdit = this.rptCal;
            this.colDocumentAmountBF.FieldName = "DocumentAmountBF";
            this.colDocumentAmountBF.Name = "colDocumentAmountBF";
            this.colDocumentAmountBF.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DocumentAmountBF", "{0:##,##0.###}")});
            // 
            // colDiscountRate
            // 
            this.colDiscountRate.Caption = "Chiết khấu (%)";
            this.colDiscountRate.ColumnEdit = this.rptCalPercent;
            this.colDiscountRate.FieldName = "DiscountRate";
            this.colDiscountRate.Name = "colDiscountRate";
            this.colDiscountRate.Visible = true;
            this.colDiscountRate.VisibleIndex = 4;
            // 
            // rptCalPercent
            // 
            this.rptCalPercent.AutoHeight = false;
            this.rptCalPercent.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rptCalPercent.DisplayFormat.FormatString = "{0:##,##0.###}%";
            this.rptCalPercent.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.rptCalPercent.Name = "rptCalPercent";
            // 
            // colDiscountAmount
            // 
            this.colDiscountAmount.Caption = "Chiết khấu";
            this.colDiscountAmount.ColumnEdit = this.rptCal;
            this.colDiscountAmount.FieldName = "DiscountAmount";
            this.colDiscountAmount.Name = "colDiscountAmount";
            this.colDiscountAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DiscountAmount", "{0:##,##0.###}")});
            this.colDiscountAmount.Visible = true;
            this.colDiscountAmount.VisibleIndex = 5;
            // 
            // colTaxRate
            // 
            this.colTaxRate.Caption = "Thuế (%)";
            this.colTaxRate.ColumnEdit = this.rptCalPercent;
            this.colTaxRate.FieldName = "TaxRate";
            this.colTaxRate.Name = "colTaxRate";
            this.colTaxRate.Visible = true;
            this.colTaxRate.VisibleIndex = 6;
            // 
            // colTaxAmount
            // 
            this.colTaxAmount.Caption = "Thuế";
            this.colTaxAmount.ColumnEdit = this.rptCal;
            this.colTaxAmount.FieldName = "TaxAmount";
            this.colTaxAmount.Name = "colTaxAmount";
            this.colTaxAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TaxAmount", "{0:##,##0.###}")});
            this.colTaxAmount.Visible = true;
            this.colTaxAmount.VisibleIndex = 7;
            // 
            // colDocumentAmount
            // 
            this.colDocumentAmount.Caption = "Thành tiền";
            this.colDocumentAmount.ColumnEdit = this.rptCal;
            this.colDocumentAmount.FieldName = "DocumentAmount";
            this.colDocumentAmount.Name = "colDocumentAmount";
            this.colDocumentAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DocumentAmount", "{0:##,##0.###}")});
            this.colDocumentAmount.Visible = true;
            this.colDocumentAmount.VisibleIndex = 8;
            // 
            // colDescriptions
            // 
            this.colDescriptions.Caption = "Ghi chú";
            this.colDescriptions.FieldName = "Descriptions";
            this.colDescriptions.Name = "colDescriptions";
            this.colDescriptions.Visible = true;
            this.colDescriptions.VisibleIndex = 9;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // colModifiedDate
            // 
            this.colModifiedDate.FieldName = "ModifiedDate";
            this.colModifiedDate.Name = "colModifiedDate";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 426);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gcList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 406);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // saleTableAdapter
            // 
            this.saleTableAdapter.ClearBeforeFill = true;
            // 
            // frmSaleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.frmSaleListlayoutControl1ConvertedLayout);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmSaleList";
            this.Text = "Bán Hàng - Danh Sách Chứng Từ";
            this.Load += new System.EventHandler(this.frmSaleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmSaleListlayoutControl1ConvertedLayout)).EndInit();
            this.frmSaleListlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptCalPercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bm;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiAdd;
        private DevExpress.XtraBars.BarButtonItem bbiEdit;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiPrint;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraLayout.LayoutControl frmSaleListlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraGrid.GridControl gcList;
        private DevExpress.XtraGrid.Views.Grid.GridView gbList;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraBars.BarButtonItem bbiRefresh;
        private System.Windows.Forms.BindingSource saleBindingSource;
        private DataSet.Sale.dsSale dsSale;
        private DataSet.Sale.dsSaleTableAdapters.SaleTableAdapter saleTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleID;
        private DevExpress.XtraGrid.Columns.GridColumn colSaleCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCompanyID;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLaborFee;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentAmountBF;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountRate;
        private DevExpress.XtraGrid.Columns.GridColumn colDiscountAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxRate;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDocumentAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colDescriptions;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colModifiedDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit rptCal;
        private DevExpress.XtraGrid.Columns.GridColumn colSalePeople;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit rptCalPercent;
    }
}