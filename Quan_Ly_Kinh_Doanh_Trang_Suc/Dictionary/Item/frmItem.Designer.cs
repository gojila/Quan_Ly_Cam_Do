
namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Dictionary.Item
{
    partial class frmItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItem));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtItemName = new DevExpress.XtraEditors.TextEdit();
            this.bm = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiSaveNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveEdit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtItemCode = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtItemName);
            this.layoutControl1.Controls.Add(this.txtItemCode);
            this.layoutControl1.Controls.Add(this.txtDescription);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(533, 226);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtItemName
            // 
            this.txtItemName.Location = new System.Drawing.Point(132, 30);
            this.txtItemName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtItemName.MenuManager = this.bm;
            this.txtItemName.Name = "txtItemName";
            this.txtItemName.Size = new System.Drawing.Size(393, 20);
            this.txtItemName.StyleController = this.layoutControl1;
            this.txtItemName.TabIndex = 5;
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
            this.bbiSaveClose,
            this.bbiSaveEdit,
            this.bbiClose,
            this.bbiSaveNew});
            this.bm.MainMenu = this.bar2;
            this.bm.MaxItemId = 4;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSaveNew, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSaveClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSaveEdit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiSaveNew
            // 
            this.bbiSaveNew.Caption = "Lưu && Tạo";
            this.bbiSaveNew.Id = 3;
            this.bbiSaveNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSaveNew.ImageOptions.Image")));
            this.bbiSaveNew.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSaveNew.ImageOptions.LargeImage")));
            this.bbiSaveNew.Name = "bbiSaveNew";
            this.bbiSaveNew.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveNew_ItemClick);
            // 
            // bbiSaveClose
            // 
            this.bbiSaveClose.Caption = "Lưu && Đóng";
            this.bbiSaveClose.Id = 0;
            this.bbiSaveClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSaveClose.ImageOptions.Image")));
            this.bbiSaveClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSaveClose.ImageOptions.LargeImage")));
            this.bbiSaveClose.Name = "bbiSaveClose";
            this.bbiSaveClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveClose_ItemClick);
            // 
            // bbiSaveEdit
            // 
            this.bbiSaveEdit.Caption = "Lưu && Sửa";
            this.bbiSaveEdit.Id = 1;
            this.bbiSaveEdit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSaveEdit.ImageOptions.Image")));
            this.bbiSaveEdit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSaveEdit.ImageOptions.LargeImage")));
            this.bbiSaveEdit.Name = "bbiSaveEdit";
            this.bbiSaveEdit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSaveEdit_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Đóng";
            this.bbiClose.Id = 2;
            this.bbiClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.Image")));
            this.bbiClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiClose.ImageOptions.LargeImage")));
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bm;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(533, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 250);
            this.barDockControlBottom.Manager = this.bm;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(533, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.bm;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 226);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(533, 24);
            this.barDockControlRight.Manager = this.bm;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 226);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(132, 8);
            this.txtItemCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtItemCode.MenuManager = this.bm;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(393, 20);
            this.txtItemCode.StyleController = this.layoutControl1;
            this.txtItemCode.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(132, 52);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescription.MenuManager = this.bm;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(393, 166);
            this.txtDescription.StyleController = this.layoutControl1;
            this.txtDescription.TabIndex = 6;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(533, 226);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AllowHtmlStringInCaption = true;
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtItemCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(519, 22);
            this.layoutControlItem1.Text = "Mã Sản Phẩm: <color=\"red\">(*)</color>";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(122, 16);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AllowHtmlStringInCaption = true;
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txtItemName;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 22);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(519, 22);
            this.layoutControlItem2.Text = "Sản Phẩm:  <color=\"red\">(*)</color>";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(122, 16);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AllowHtmlStringInCaption = true;
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txtDescription;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(519, 168);
            this.layoutControlItem3.Text = "Ghi Chú:";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(122, 16);
            // 
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 250);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sản Phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtItemName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtItemCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraBars.BarManager bm;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem bbiSaveClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveEdit;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.TextEdit txtItemName;
        private DevExpress.XtraEditors.TextEdit txtItemCode;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraBars.BarButtonItem bbiSaveNew;
    }
}