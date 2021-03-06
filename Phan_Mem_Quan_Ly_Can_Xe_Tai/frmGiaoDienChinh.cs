﻿using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai
{
    public partial class frmGiaoDienChinh : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool dangnhapthanhcong = false;
        public frmGiaoDienChinh()
        {
            
            var cauhinhCSDL = new frmConfig();

            if (!cauhinhCSDL.Kiem_Tra_Ket_Noi(SqlHelper.ConnectionString))
            {
                dangnhapthanhcong = false;
                cauhinhCSDL.ThanhCong += cauhinhCSDL_ThanhCong;
                cauhinhCSDL.Bo += cauhinhCSDL_Bo;
                cauhinhCSDL.FormClosed += (s, e) =>
                {
                    if (!dangnhapthanhcong)
                    {
                        Application.Exit();
                    }
                };
                cauhinhCSDL.ShowDialog(this);
            }
            else
            {
                InitializeComponent();
                LoadConfigInfo();
                bbiCanXe_ItemClick(this, null);
            }
        }
        private void cauhinhCSDL_ThanhCong(object sender)
        {
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("vi-VN");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("vi-VN");

            InitializeComponent();
            bbiCanXe_ItemClick(this, null);

            //lblDatabase.Caption += SqlHelper.Database;
            //lblServer.Caption += SqlHelper.Server;

            //bbiCamDo_ItemClick(this, null);
            dangnhapthanhcong = true;
            LoadConfigInfo();
            this.WindowState = FormWindowState.Maximized;
        }

        private void cauhinhCSDL_Bo(object sender)
        {
            Application.Exit();
        }

        private frmPhieuCanXe _frmPhieuCanXe;
        private void bbiCanXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmPhieuCanXe == null)
            {
                _frmPhieuCanXe = new frmPhieuCanXe();
                _frmPhieuCanXe.FormClosing += (ss, ex) =>
                {
                    _frmPhieuCanXe = null;
                };
                _frmPhieuCanXe.MdiParent = this;
                _frmPhieuCanXe.Show();
            }
            else
            {
                tabMdi.Pages[_frmPhieuCanXe].MdiChild.Activate();
            }
        }

        private frmDanhSachPhieuCanXe _frmDanhSachPhieuCanXe;
        private void bbiPhieuCan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_frmDanhSachPhieuCanXe == null)
            {
                _frmDanhSachPhieuCanXe = new frmDanhSachPhieuCanXe();
                _frmDanhSachPhieuCanXe.FormClosing += (ss, ex) =>
                {
                    _frmDanhSachPhieuCanXe = null;
                };

                _frmDanhSachPhieuCanXe.AddNew += (ss) => 
                {
                    bbiCanXe_ItemClick(this, null);
                    _frmPhieuCanXe.AddNew();
                };

                _frmDanhSachPhieuCanXe.Edit += (ss, id)=> 
                {
                    bbiCanXe_ItemClick(this, null);
                    _frmPhieuCanXe.SetEdit(id);
                };
                _frmDanhSachPhieuCanXe.MdiParent = this;
                _frmDanhSachPhieuCanXe.Show();
            }
            else
            {
                tabMdi.Pages[_frmDanhSachPhieuCanXe].MdiChild.Activate();
            }
        }

        private void bbiConfig_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var _frmConfig = new frmConfig();
                _frmConfig.isRestart = true;
                _frmConfig.ShowDialog();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadConfigInfo()
        {
            try
            {
                lblComPort.Caption += SqlHelper.ComPort;
                lblBaudRate.Caption += SqlHelper.BaudRate.ToString();
                lblSQL.Caption += SqlHelper.Server;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bbiBackUp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var _xfmSaoLuu = new xfmSaoLuu();
                _xfmSaoLuu.ShowDialog();
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiRestore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var _xfmPhucHoi = new xfmPhucHoi();
                _xfmPhucHoi.ShowDialog();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblSQL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiConfig_ItemClick(this, null);
        }

        private void lblComPort_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiConfig_ItemClick(this, null);
        }

        private void lblBaudRate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bbiConfig_ItemClick(this, null);
        }

        private void bbiContact_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var _frmContact = new frmContact();
                _frmContact.ShowDialog();

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiGuide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                string fileName = Application.StartupPath + @"\Huong_dan_su_dung.docx";
                var process = new System.Diagnostics.Process();
                process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = fileName };
                process.Start();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
