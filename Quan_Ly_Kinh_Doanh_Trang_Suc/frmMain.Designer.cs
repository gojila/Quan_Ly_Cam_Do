
namespace Quan_Ly_Kinh_Doanh_Trang_Suc
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSale = new DevExpress.XtraBars.BarButtonItem();
            this.bbiItem = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.tabMdi = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.bbiCategory = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.bbiSale,
            this.bbiItem,
            this.bbiCategory});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonControl1.MaxItemId = 4;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1254, 231);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // bbiSale
            // 
            this.bbiSale.Caption = "Bán Hàng";
            this.bbiSale.Id = 1;
            this.bbiSale.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSale.ImageOptions.Image")));
            this.bbiSale.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSale.ImageOptions.LargeImage")));
            this.bbiSale.Name = "bbiSale";
            this.bbiSale.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSale_ItemClick);
            // 
            // bbiItem
            // 
            this.bbiItem.Caption = "Sản Phẩm";
            this.bbiItem.Id = 2;
            this.bbiItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiItem.ImageOptions.Image")));
            this.bbiItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiItem.ImageOptions.LargeImage")));
            this.bbiItem.Name = "bbiItem";
            this.bbiItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiItem_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức Năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSale);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Bán Hàng";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiCategory);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiItem);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Danh Mục";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 758);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1254, 36);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // tabMdi
            // 
            this.tabMdi.MdiParent = this;
            // 
            // bbiCategory
            // 
            this.bbiCategory.Caption = "Loại Sản Phẩm";
            this.bbiCategory.Id = 3;
            this.bbiCategory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiCategory.ImageOptions.Image")));
            this.bbiCategory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiCategory.ImageOptions.LargeImage")));
            this.bbiCategory.Name = "bbiCategory";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 794);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Phần Mềm Quản Lý Kinh Doanh Trang Sức";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem bbiSale;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdi;
        private DevExpress.XtraBars.BarButtonItem bbiItem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bbiCategory;
    }
}

