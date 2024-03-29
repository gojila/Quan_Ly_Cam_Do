﻿namespace Phan_Mem_Quan_Ly_Can_Xe_Tai
{
    partial class frmGiaoDienChinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiaoDienChinh));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.img = new DevExpress.Utils.ImageCollection(this.components);
            this.bbiCanXe = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPhieuCan = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConfig = new DevExpress.XtraBars.BarButtonItem();
            this.lblSQL = new DevExpress.XtraBars.BarHeaderItem();
            this.lblComPort = new DevExpress.XtraBars.BarStaticItem();
            this.lblBaudRate = new DevExpress.XtraBars.BarStaticItem();
            this.bbiBackUp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRestore = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.tabMdi = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.bbiGuide = new DevExpress.XtraBars.BarButtonItem();
            this.bbiContact = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Images = this.img;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiCanXe,
            this.bbiPhieuCan,
            this.bbiConfig,
            this.lblSQL,
            this.lblComPort,
            this.lblBaudRate,
            this.bbiBackUp,
            this.bbiRestore,
            this.bbiClose,
            this.bbiGuide,
            this.bbiContact});
            this.ribbonControl1.LargeImages = this.img;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 14;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.lblSQL);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.lblComPort);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.lblBaudRate);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1224, 143);
            // 
            // img
            // 
            this.img.ImageSize = new System.Drawing.Size(32, 32);
            this.img.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("img.ImageStream")));
            this.img.Images.SetKeyName(0, "iconfinder_21_4698594 - Copy.png");
            this.img.Images.SetKeyName(1, "iconfinder_497_pen_calculator_scale_education_4212917 - Copy.png");
            this.img.Images.SetKeyName(2, "iconfinder_constr_settings_1267297.png");
            this.img.Images.SetKeyName(3, "iconfinder_checklist_3583297 - Copy.png");
            this.img.Images.SetKeyName(4, "iconfinder_Data-20_4203024.png");
            this.img.Images.SetKeyName(5, "iconfinder_finance-scale_532643.png");
            this.img.Images.SetKeyName(6, "iconfinder_gear_1055051.png");
            this.img.Images.SetKeyName(7, "iconfinder_hot-dogs-truck-food-delivery-street_3558109.png");
            this.img.Images.SetKeyName(8, "iconfinder_Item_li_list_list_item_ul_1886963.png");
            this.img.Images.SetKeyName(9, "iconfinder_wish-list_3583302.png");
            this.img.Images.SetKeyName(10, "iconfinder_Database_Cloud-01_1222657.png");
            this.img.Images.SetKeyName(11, "iconfinder_Database-01_1222656.png");
            this.img.Images.SetKeyName(12, "iconfinder_storagedatabackupfiledocument_4904826.png");
            this.img.Images.SetKeyName(13, "iconfinder_close_red_619539.png");
            // 
            // bbiCanXe
            // 
            this.bbiCanXe.Caption = "Cân Xe";
            this.bbiCanXe.Hint = "Cân Xe";
            this.bbiCanXe.Id = 2;
            this.bbiCanXe.ImageOptions.LargeImageIndex = 5;
            this.bbiCanXe.Name = "bbiCanXe";
            this.bbiCanXe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiCanXe_ItemClick);
            // 
            // bbiPhieuCan
            // 
            this.bbiPhieuCan.Caption = "Danh Sách";
            this.bbiPhieuCan.Hint = "Danh Sách";
            this.bbiPhieuCan.Id = 3;
            this.bbiPhieuCan.ImageOptions.LargeImageIndex = 3;
            this.bbiPhieuCan.Name = "bbiPhieuCan";
            this.bbiPhieuCan.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.bbiPhieuCan.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.bbiPhieuCan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiPhieuCan_ItemClick);
            // 
            // bbiConfig
            // 
            this.bbiConfig.Caption = "Cấu Hình";
            this.bbiConfig.Id = 4;
            this.bbiConfig.ImageOptions.ImageIndex = 0;
            this.bbiConfig.ImageOptions.LargeImageIndex = 0;
            this.bbiConfig.Name = "bbiConfig";
            this.bbiConfig.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiConfig_ItemClick);
            // 
            // lblSQL
            // 
            this.lblSQL.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblSQL.Caption = "<color=\"red\">Máy chủ SQL:</color>";
            this.lblSQL.Id = 5;
            this.lblSQL.Name = "lblSQL";
            this.lblSQL.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lblSQL_ItemClick);
            // 
            // lblComPort
            // 
            this.lblComPort.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblComPort.Caption = "<color=\"red\">Com Port:</color>";
            this.lblComPort.Id = 6;
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lblComPort_ItemClick);
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AllowHtmlText = DevExpress.Utils.DefaultBoolean.True;
            this.lblBaudRate.Caption = "<color=\"red\">Baud Rate:</color>";
            this.lblBaudRate.Id = 8;
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.lblBaudRate_ItemClick);
            // 
            // bbiBackUp
            // 
            this.bbiBackUp.Caption = "Sao Lưu";
            this.bbiBackUp.Id = 9;
            this.bbiBackUp.ImageOptions.LargeImageIndex = 10;
            this.bbiBackUp.Name = "bbiBackUp";
            this.bbiBackUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiBackUp_ItemClick);
            // 
            // bbiRestore
            // 
            this.bbiRestore.Caption = "Phục Hồi";
            this.bbiRestore.Id = 10;
            this.bbiRestore.ImageOptions.LargeImageIndex = 11;
            this.bbiRestore.Name = "bbiRestore";
            this.bbiRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRestore_ItemClick);
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Đóng";
            this.bbiClose.Id = 11;
            this.bbiClose.ImageOptions.LargeImageIndex = 13;
            this.bbiClose.Name = "bbiClose";
            this.bbiClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiClose_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiCanXe);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiPhieuCan);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Chức Năng";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiConfig);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiBackUp);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiRestore);
            this.ribbonPageGroup2.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Hệ Thống";
            // 
            // tabMdi
            // 
            this.tabMdi.MdiParent = this;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiGuide);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiContact);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Trợ Giúp";
            // 
            // bbiGuide
            // 
            this.bbiGuide.Caption = "Hướng Dẫn";
            this.bbiGuide.Id = 12;
            this.bbiGuide.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiGuide.ImageOptions.Image")));
            this.bbiGuide.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiGuide.ImageOptions.LargeImage")));
            this.bbiGuide.Name = "bbiGuide";
            this.bbiGuide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiGuide_ItemClick);
            // 
            // bbiContact
            // 
            this.bbiContact.Caption = "Liên Hệ";
            this.bbiContact.Id = 13;
            this.bbiContact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbiContact.ImageOptions.Image")));
            this.bbiContact.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbiContact.ImageOptions.LargeImage")));
            this.bbiContact.Name = "bbiContact";
            this.bbiContact.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiContact_ItemClick);
            // 
            // frmGiaoDienChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 450);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmGiaoDienChinh";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Phần Mềm Cân Xe Tải";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMdi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiCanXe;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabMdi;
        private DevExpress.Utils.ImageCollection img;
        private DevExpress.XtraBars.BarButtonItem bbiPhieuCan;
        private DevExpress.XtraBars.BarButtonItem bbiConfig;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarHeaderItem lblSQL;
        private DevExpress.XtraBars.BarStaticItem lblComPort;
        private DevExpress.XtraBars.BarStaticItem lblBaudRate;
        private DevExpress.XtraBars.BarButtonItem bbiBackUp;
        private DevExpress.XtraBars.BarButtonItem bbiRestore;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.BarButtonItem bbiGuide;
        private DevExpress.XtraBars.BarButtonItem bbiContact;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}

