using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.Bussiness;
using Phan_Mem_Quan_Ly_Can_Xe_Tai.CanXe.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai.Common
{
    class CommonEnum
    {
    }

    public enum ScaleTypeSaveEnum
    {
        Save = 1,
        Scale = 2,
        Scale_1 = 3,
        Scale_2 = 4
    }

    public class CommonAction
    {
        public static void SetReport(IWin32Window owner, PhieuCan phieuCan, ref rptCanXe _rptCanXe)
        {
            try
            {
                _rptCanXe.Parameters["TenCongTy"].Value = SqlHelper.CompanyName;
                _rptCanXe.Parameters["DiaChi"].Value = SqlHelper.Address;
                _rptCanXe.Parameters["DienThoai"].Value = SqlHelper.Phone;
                _rptCanXe.Parameters["Fax"].Value = SqlHelper.Fax;

                _rptCanXe.Parameters["SoPhieu"].Value = phieuCan.SoPhieu;
                _rptCanXe.Parameters["Ngay"].Value = phieuCan.Ngay.Value.ToString("dd/MM/yyyy");
                _rptCanXe.Parameters["KhachHang_TenKhachHang"].Value = phieuCan.KhachHang;
                _rptCanXe.Parameters["KhachHang_DiaChi"].Value = "";
                _rptCanXe.Parameters["BienSoXe"].Value = phieuCan.SoXe;
                _rptCanXe.Parameters["LoaiHang"].Value = phieuCan.Loaihang;

                _rptCanXe.Parameters["XuatNhap"].Value = phieuCan.XuatNhap;
                _rptCanXe.Parameters["ThoiGianCanLan1"].Value = phieuCan.NgayCan1 == null ? "" : phieuCan.NgayCan1.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                _rptCanXe.Parameters["ThoiGianCanLan2"].Value = phieuCan.NgayCan2 == null ? "" : phieuCan.NgayCan2.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                _rptCanXe.Parameters["TrongLuongCanLan1"].Value = phieuCan.TrongLuongCan1 == null ? "" : phieuCan.TrongLuongCan1.Value.ToString("##,##0.###");
                _rptCanXe.Parameters["TrongLuongCanLan2"].Value = phieuCan.TrongLuongCan2 == null ? "" : phieuCan.TrongLuongCan2.Value.ToString("##,##0.###");

                _rptCanXe.Parameters["TrongLuongHangHoa"].Value = phieuCan.TrongLuongHang == null ? "" : phieuCan.TrongLuongHang.Value.ToString("##,##0.###");

                _rptCanXe.Parameters["BarCode"].Value = JsonConvert.SerializeObject(phieuCan);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(owner, JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
