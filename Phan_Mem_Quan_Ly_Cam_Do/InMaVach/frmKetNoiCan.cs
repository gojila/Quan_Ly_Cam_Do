using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Cam_Do.InMaVach
{
    public partial class frmKetNoiCan : Form
    {
        public delegate void ChoInEventHander(object sender, string mavach, string tenhang, decimal tongtrongluong, decimal trongluong, decimal hot, string nhacungcap, string hamluongpho, decimal tiencong, int soluongtem);

        public event ChoInEventHander ChoIn;
        private void RaiseChoInEventHander(string mavach, string tenhang, decimal tongtrongluong, decimal trongluong, decimal hot, string nhacungcap, string hamluongpho, decimal tiencong, int soluongtem)
        {
            if (ChoIn != null)
            {
                ChoIn(this, mavach, tenhang, tongtrongluong, trongluong, hot, nhacungcap, hamluongpho, tiencong, soluongtem);
            }
        }

        string tenTiem = "";
        string diaChi = "";
        public frmKetNoiCan()
        {
            InitializeComponent();
            TaoMoi();
        }

        public frmKetNoiCan(string tenCongCOM, string _tenTiem, string _diaChi)
        {
            InitializeComponent();
            TaoMoi();
            tenTiem = _tenTiem;
            diaChi = _diaChi;

            if (!Com.IsOpen)
            {
                try
                {
                    Com.PortName = tenCongCOM;
                    Com.Open();
                    Com.DataReceived += Com_DataReceived;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void TaoMoi()
        {
            txtMaVach.Text = "M" + String.Format("{0:ddMMyyyy}", DateTime.Now);
        }

        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string canNang = "";
            if (Com.IsOpen)
            {
                canNang = Com.ReadExisting();
                txtCanNang.Text = canNang;
                rdgTuyChonCanNang_SelectedIndexChanged(this, null);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            if(Com.IsOpen)
            {
                Com.Close();
            }
            this.Close();
        }

        private void frmKetNoiCan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Com.IsOpen)
            {
                Com.Close();
            }
        }

        private void rdgTuyChonCanNang_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal canNang = 0;
            if(Decimal.TryParse(txtCanNang.Text, out canNang))
            {
                if (rdgTuyChonCanNang.SelectedIndex == 0)
                {
                    txtTongTrongLuong.Value = canNang;
                }
                else if (rdgTuyChonCanNang.SelectedIndex == 1)
                {
                    txtTrongLuong.Value = canNang;
                }
                else if (rdgTuyChonCanNang.SelectedIndex == 2)
                {
                    txtHot.Value = canNang;
                }
            }
            
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            //DataTable dtInMaVach = new DataTable();

            //for (int i = 0; i < Convert.ToInt32(txtSoLuongTem.Value); i++)
            //{
            //    DataRow drDongIn = dtInMaVach.NewRow();

            //    drDongIn["MaVach"] = txtMaVach.Text;
            //    drDongIn["TenHang"] = txtTenHang.Text;
            //    drDongIn["TongTrongLuong"] = txtTongTrongLuong.Value;
            //    drDongIn["TrongLuong"] = txtTrongLuong.Value; ;
            //    drDongIn["TienCong"] = txtTienCong.Value;
            //    drDongIn["Hot"] = txtHot.Value;
            //    drDongIn["LoaiVang"] = "";
            //    drDongIn["NhaCungCap"] = txtNhaCungCap.Text;
            //    drDongIn["HamLuongPho"] = txtHamLuongPho.Text;
            //    drDongIn["SoLuongTem"] = txtSoLuongTem.Value;

            //    dtInMaVach.Rows.Add(drDongIn);
            //    dtInMaVach.AcceptChanges();
            //}

            //var rptMaVach = new rptInMaVach(dtInMaVach, tenTiem);
            var rptMaVach = new rptInMaVach(tenTiem, diaChi, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTongTrongLuong.Value, txtTienCong.Value, txtHot.Value, "", txtNhaCungCap.Text, txtHamLuongPho.Text, Convert.ToInt32(txtSoLuongTem.Value));
            rptMaVach.AssignPrintTool(new ReportPrintTool(rptMaVach));
            rptMaVach.CreateDocument();
            rptMaVach.ShowPreview();
        }

        private void btnTuyChinh_Click(object sender, EventArgs e)
        {
            //DataTable dtInMaVach = new DataTable();

            //for (int i = 0; i < Convert.ToInt32(txtSoLuongTem.Value); i++)
            //{
            //    DataRow drDongIn = dtInMaVach.NewRow();

            //    drDongIn["MaVach"] = txtMaVach.Text;
            //    drDongIn["TenHang"] = txtTenHang.Text;
            //    drDongIn["TongTrongLuong"] = txtTongTrongLuong.Value;
            //    drDongIn["TrongLuong"] = txtTrongLuong.Value; ;
            //    drDongIn["TienCong"] = txtTienCong.Value;
            //    drDongIn["Hot"] = txtHot.Value;
            //    drDongIn["LoaiVang"] = "";
            //    drDongIn["NhaCungCap"] = txtNhaCungCap.Text;
            //    drDongIn["HamLuongPho"] = txtHamLuongPho.Text;
            //    drDongIn["SoLuongTem"] = txtSoLuongTem.Value;

            //    dtInMaVach.Rows.Add(drDongIn);
            //    dtInMaVach.AcceptChanges();
            //}

            var rptMaVach = new rptInMaVach(tenTiem, diaChi, txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTongTrongLuong.Value, txtTienCong.Value, txtHot.Value, "", txtNhaCungCap.Text, txtHamLuongPho.Text, Convert.ToInt32(txtSoLuongTem.Value));
            rptMaVach.ShowDesigner();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaVach.Text = "";
            txtTenHang.Text = "";
            txtTongTrongLuong.Value = 0;
            txtTrongLuong.Value = 0;
            txtHot.Value = 0;
            txtNhaCungCap.Text = "";
            txtHamLuongPho.Text = "";
            txtTienCong.Value = 0;
            txtSoLuongTem.Value = 1;
        }

        private void btnChoIn_Click(object sender, EventArgs e)
        {
            RaiseChoInEventHander(txtMaVach.Text, txtTenHang.Text, txtTongTrongLuong.Value, txtTrongLuong.Value, txtHot.Value, txtNhaCungCap.Text, txtHamLuongPho.Text, txtTienCong.Value, Convert.ToInt32(txtSoLuongTem.Value));
            btnTaoMoi_Click(this, null);
        }

        
    }
}
