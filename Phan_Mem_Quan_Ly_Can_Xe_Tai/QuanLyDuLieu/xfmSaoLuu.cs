using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
//using Phan_Mem_Quan_Ly_Cam_Do.DoiTuong;
using System.IO;
//using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Common;
using Newtonsoft.Json;

//using Microsoft.SqlServer.Management.Common;
//using SQLDMO;


namespace Phan_Mem_Quan_Ly_Cam_Do.QuanLyDuLieu
{
    public partial class xfmSaoLuu : XtraForm
    {
        public xfmSaoLuu()
        {
            InitializeComponent();
            
            txtDuongDan.Text = GetLastDrive() + @"Backup";
            txtTenFile.Text = SqlHelper.Database + @"." + String.Format("{0:dd_MM_yy_hh_mm}.bak", DateTime.Now);
        }

        private string GetLastDrive()
        {
            var dList = Environment.GetLogicalDrives();
            var result = "C:";

            for (int z = dList.Length - 1; z > 0; z--)
            {
                var drv = new DriveInfo(dList[z]);
                if (drv.DriveType == DriveType.Fixed)
                {
                    result = drv.Name;
                    return result;
                }
            }
            return result;
        }

        private void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnPathClick(object sender, EventArgs e)
        {
            var folderBrowserDialog=new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void TxtBackupFolderPropertiesButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtDuongDan.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtDuongDan.Text))
            {
                Directory.CreateDirectory(txtDuongDan.Text);
            }
            var newThread = new Thread(() => SaoLuuDuLieu());
            newThread.Start();
        }

        private void bak_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            Bar.EditValue = e.Percent;
            Bar.Refresh();

            //progressBar1.Value = e.Percent;
            //progressBar1.Refresh();
        }

        private void bkp_Complete(object sender, ServerMessageEventHandler e)
        {
            //Bar.EditValue = e.Percent;
            //Bar.Refresh();

            //progressBar1.Value = e.Percent;
            //progressBar1.Refresh();

        }
        

        private void SaoLuuDuLieu()
        {
            btnThucHien.Invoke((Action)delegate
            {
                btnThucHien.Enabled = false;
            });
            //btnThucHien.Enabled = false;
            SqlConnection sqlConnection = new SqlConnection(SqlHelper.ConnectionString);
            Server srv = new Server(new ServerConnection(sqlConnection));

            Backup bkp = new Backup();

            //this.Cursor = Cursors.WaitCursor;
            try
            {
                string fileName = txtDuongDan.Text + "\\" + this.txtTenFile.Text;
                string databaseName = SqlHelper.Database;

                bkp.Action = BackupActionType.Database;
                bkp.Database = databaseName;
                bkp.Devices.AddDevice(fileName, DeviceType.File);
                //bkp.Incremental = true;
                Bar.Invoke((Action)delegate
                {
                    Bar.EditValue = 0;
                    Bar.Refresh();
                });
                

                bkp.PercentCompleteNotification = 10;
                bkp.PercentComplete += bak_PercentComplete;
                //bkp.Complete += bkp_Complete;
                bkp.SqlBackup(srv);

                Bar.Invoke((Action)delegate
                {
                    Bar.EditValue = 0;
                    Bar.Refresh();
                });

                //progressBar1.Value = 0;
                //progressBar1.Refresh();

                XtraMessageBox.Show(this, "Sao lưu dữ liệu thành công: " + fileName, "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThucHien.Enabled = true;
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show(ex.ToString());
                //btnThucHien.Enabled = true;
                btnThucHien.Invoke((Action)delegate
                {
                    btnThucHien.Enabled = true;
                });
            }
        }
    }
}