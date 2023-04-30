
namespace Phan_Mem_Quan_Ly_In_Tem.MauTemIn
{
    partial class frmThemMauTemIn
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemMauTemIn));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.cbMacDinh = new DevExpress.XtraEditors.CheckEdit();
            this.txtDuongDan = new DevExpress.XtraEditors.ButtonEdit();
            this.txtTenMauTem = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bm = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMacDinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuongDan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMauTem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtGhiChu);
            this.layoutControl1.Controls.Add(this.cbMacDinh);
            this.layoutControl1.Controls.Add(this.txtDuongDan);
            this.layoutControl1.Controls.Add(this.txtTenMauTem);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 24);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(616, 198);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(83, 84);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(521, 102);
            this.txtGhiChu.StyleController = this.layoutControl1;
            this.txtGhiChu.TabIndex = 7;
            // 
            // cbMacDinh
            // 
            this.cbMacDinh.Location = new System.Drawing.Point(12, 60);
            this.cbMacDinh.Name = "cbMacDinh";
            this.cbMacDinh.Properties.Caption = "Mặc Định";
            this.cbMacDinh.Size = new System.Drawing.Size(592, 20);
            this.cbMacDinh.StyleController = this.layoutControl1;
            this.cbMacDinh.TabIndex = 6;
            // 
            // txtDuongDan
            // 
            this.txtDuongDan.Location = new System.Drawing.Point(83, 36);
            this.txtDuongDan.Name = "txtDuongDan";
            this.txtDuongDan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", "Chon", null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtDuongDan.Size = new System.Drawing.Size(521, 20);
            this.txtDuongDan.StyleController = this.layoutControl1;
            this.txtDuongDan.TabIndex = 5;
            this.txtDuongDan.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtDuongDan_ButtonClick);
            // 
            // txtTenMauTem
            // 
            this.txtTenMauTem.Location = new System.Drawing.Point(83, 12);
            this.txtTenMauTem.Name = "txtTenMauTem";
            this.txtTenMauTem.Size = new System.Drawing.Size(521, 20);
            this.txtTenMauTem.StyleController = this.layoutControl1;
            this.txtTenMauTem.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(616, 198);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtTenMauTem;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(596, 24);
            this.layoutControlItem1.Text = "Tên Mẫu Tem:";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtDuongDan;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(596, 24);
            this.layoutControlItem2.Text = "Đường Dẫn";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.cbMacDinh;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(596, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtGhiChu;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 72);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(596, 106);
            this.layoutControlItem4.Text = "Ghi Chú:";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 13);
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
            this.bbiSave,
            this.bbiClose});
            this.bm.MainMenu = this.bar2;
            this.bm.MaxItemId = 2;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiSave, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiClose, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Lưu";
            this.bbiSave.Id = 0;
            this.bbiSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.Image")));
            this.bbiSave.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiSave.ImageOptions.LargeImage")));
            this.bbiSave.Name = "bbiSave";
            this.bbiSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiSave_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Đóng";
            this.bbiClose.Id = 1;
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
            this.barDockControlTop.Size = new System.Drawing.Size(616, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 222);
            this.barDockControlBottom.Manager = this.bm;
            this.barDockControlBottom.Size = new System.Drawing.Size(616, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.bm;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 198);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(616, 24);
            this.barDockControlRight.Manager = this.bm;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 198);
            // 
            // frmThemMauTemIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 222);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmThemMauTemIn.IconOptions.Image")));
            this.Name = "frmThemMauTemIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mẫu Tem In";
            this.Load += new System.EventHandler(this.frmThemMauTemIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbMacDinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuongDan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenMauTem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.TextEdit txtTenMauTem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraEditors.CheckEdit cbMacDinh;
        private DevExpress.XtraEditors.ButtonEdit txtDuongDan;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraBars.BarManager bm;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
    }
}