using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using DevExpress.XtraPrinting;
using System.Linq;
using Phan_Mem_Quan_Ly_In_Tem.XuLy;
using Newtonsoft.Json;
using Phan_Mem_Quan_Ly_In_Tem.ModelEF;

namespace Phan_Mem_Quan_Ly_In_Tem
{
    public partial class rptInTemNuTrang : DevExpress.XtraReports.UI.XtraReport
    {
        public rptInTemNuTrang()
        {
            InitializeComponent();
            
            RequestParameters = false;
        }
        public rptInTemNuTrang(DataTable dt, string tenTiem, string diaChi)
        {
            InitializeComponent();
            
            if (dt != null)
            {
                dsDanhSachHangHoa1.InMaVach.Merge(dt);
            }

            //TenTiem.Value = tenTiem;
            //DiaChi.Value = diaChi;

            RequestParameters = false;
        }

        public rptInTemNuTrang(string tenTiem, string diaChi, string tenTiemNCC, string diaChiNCC, string maVach, string tenHang, decimal tongTrongLuong, decimal trongLuong, decimal tienCong, decimal hot, string loaiVang, string nhaCungCap, string hamLuongPho, int soLuongTem, string tongTrongLuongChu, string trongLuongChu, string hotChu, int soNi, string kyHieuVang)
        {
            InitializeComponent();
            
            dsDanhSachHangHoa1.InMaVach.Rows.Clear();

            for(int i=0; i<soLuongTem; i++)
            {
                DataRow drDongIn = dsDanhSachHangHoa1.InMaVach.NewRow();

                drDongIn["MaVach"] = maVach;
                //drDongIn["TenHang"] = tenHang + (soNi > 0 ? ("-Ni:" + soNi.ToString()) : "");
                drDongIn["TenHang"] = tenHang;
                drDongIn["TongTrongLuong"] = tongTrongLuong;
                drDongIn["TrongLuong"] = trongLuong;
                drDongIn["TienCong"] = tienCong;
                drDongIn["Hot"] = hot;
                drDongIn["NhaCungCap"] = nhaCungCap;
                drDongIn["HamLuongPho"] = hamLuongPho;
                drDongIn["SoLuongTem"] = soLuongTem;

                drDongIn["TongTrongLuongChu"] = tongTrongLuongChu;
                drDongIn["TrongLuongChu"] = trongLuongChu;
                drDongIn["HotChu"] = hotChu;
                drDongIn["SoNi"] = soNi;
                drDongIn["KyHieuVang"] = kyHieuVang;

                drDongIn["TenTiem"] = tenTiemNCC;
                drDongIn["DiaChi"] = diaChiNCC;

                drDongIn["NhaCungCapDiaChi"] = "";
                drDongIn["NhaCungCapTCCS"] = "";

                drDongIn["NhaPhanPhoi"] = "";
                drDongIn["NhaPhanPhoiDiaChi"] = "";
                drDongIn["NhaPhanPhoiTCCS"] = "";
                drDongIn["XuatXu"] = "";

                dsDanhSachHangHoa1.InMaVach.Rows.Add(drDongIn);
                dsDanhSachHangHoa1.InMaVach.AcceptChanges();
            }

            //TenTiem.Value = tenTiem;
            //DiaChi.Value = diaChi;
            RequestParameters = false;
        }

        public rptInTemNuTrang(ModelEF.BarcodeDetail barcodeDetail, int soLuongTem) 
        {
            InitializeComponent();
            try 
            {
                if (barcodeDetail != null)
                {
                    clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();
                    for (int i = 0; i < soLuongTem; i++)
                    {
                        DataRow drDongIn = dsDanhSachHangHoa1.InMaVach.NewRow();

                        drDongIn["MaVach"] = barcodeDetail.BarcodeString;
                        drDongIn["BarcodeUnique"] = barcodeDetail.BarcodeUnique;

                        //drDongIn["TenHang"] = tenHang + (soNi > 0 ? ("-Ni:" + soNi.ToString()) : "");
                        drDongIn["TenHang"] = barcodeDetail.ItemName;
                        drDongIn["TongTrongLuong"] = barcodeDetail.TotalWeight;
                        drDongIn["TrongLuong"] = barcodeDetail.GoldWeight;
                        drDongIn["TienCong"] = barcodeDetail.Expense;
                        drDongIn["Hot"] = barcodeDetail.StoneWeight;
                        drDongIn["NhaCungCap"] = barcodeDetail.SupplierName;
                        drDongIn["HamLuongPho"] = barcodeDetail.GoldType;
                        drDongIn["SoLuongTem"] = soLuongTem;


                        drDongIn["TongTrongLuongChu"] = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(barcodeDetail.TotalWeight ?? 0, barcodeDetail.WeightDisplayFormat);
                        drDongIn["TrongLuongChu"] = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(barcodeDetail.GoldWeight ?? 0, barcodeDetail.WeightDisplayFormat); ;
                        drDongIn["HotChu"] = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(barcodeDetail.StoneWeight ?? 0, barcodeDetail.WeightDisplayFormat); ;
                        drDongIn["SoNi"] = barcodeDetail.Size;
                        drDongIn["KyHieuVang"] = barcodeDetail.GoldSign;

                        drDongIn["TenTiem"] = barcodeDetail.SupplierName;
                        drDongIn["DiaChi"] = barcodeDetail.SupplierAddress;

                        drDongIn["NhaCungCapDiaChi"] = barcodeDetail.SupplierAddress;
                        drDongIn["NhaCungCapTCCS"] = barcodeDetail.SupplierStandardNo;

                        drDongIn["NhaPhanPhoi"] = barcodeDetail.CompanyName;
                        drDongIn["NhaPhanPhoiDiaChi"] = barcodeDetail.CompanyAddress;
                        drDongIn["NhaPhanPhoiTCCS"] = barcodeDetail.CompanyStandardNo;
                        drDongIn["XuatXu"] = barcodeDetail.Origin;
                        drDongIn["BarcodeFullString"] = barcodeDetail.BarcodeUnique;
                        drDongIn["BarcodeID"] = barcodeDetail.BarcodeID;

                        dsDanhSachHangHoa1.InMaVach.Rows.Add(drDongIn);
                        dsDanhSachHangHoa1.InMaVach.AcceptChanges();
                    }
                }
            }
            catch (Exception ex) 
            { 
            }
            RequestParameters = false;
        }

        public rptInTemNuTrang(long BarcodeID, int soLuongTem)
        {
            InitializeComponent();

            try 
            {
                dsDanhSachHangHoa1.InMaVach.Rows.Clear();
                clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();

                var db = new ModelEF.PrintBarcodeEntities();
                var barcodeDetail = db.BarcodeDetails.Where(bd => bd.BarcodeID == BarcodeID).FirstOrDefault();
                if (barcodeDetail != null) 
                {
                    for (int i = 0; i < soLuongTem; i++)
                    {
                        DataRow drDongIn = dsDanhSachHangHoa1.InMaVach.NewRow();

                        drDongIn["MaVach"] = barcodeDetail.BarcodeString;
                        drDongIn["BarcodeUnique"] = barcodeDetail.BarcodeUnique;

                        //drDongIn["TenHang"] = tenHang + (soNi > 0 ? ("-Ni:" + soNi.ToString()) : "");
                        drDongIn["TenHang"] = barcodeDetail.ItemName;
                        drDongIn["TongTrongLuong"] = barcodeDetail.TotalWeight;
                        drDongIn["TrongLuong"] = barcodeDetail.GoldWeight;
                        drDongIn["TienCong"] = barcodeDetail.Expense;
                        drDongIn["Hot"] = barcodeDetail.StoneWeight;
                        drDongIn["NhaCungCap"] = barcodeDetail.SupplierName;
                        drDongIn["HamLuongPho"] = barcodeDetail.GoldType;
                        drDongIn["SoLuongTem"] = soLuongTem;

                        
                        drDongIn["TongTrongLuongChu"] = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(barcodeDetail.TotalWeight ?? 0, barcodeDetail.WeightDisplayFormat);
                        drDongIn["TrongLuongChu"] = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(barcodeDetail.GoldWeight ?? 0, barcodeDetail.WeightDisplayFormat); ;
                        drDongIn["HotChu"] = _clsXuLyDuLieu.chuyenGiaTriSangNoiDung(barcodeDetail.StoneWeight ?? 0, barcodeDetail.WeightDisplayFormat); ;
                        drDongIn["SoNi"] = barcodeDetail.Size;
                        drDongIn["KyHieuVang"] = barcodeDetail.GoldSign;

                        drDongIn["TenTiem"] = barcodeDetail.SupplierName;
                        drDongIn["DiaChi"] = barcodeDetail.SupplierAddress;

                        drDongIn["NhaCungCapDiaChi"] = barcodeDetail.SupplierAddress;
                        drDongIn["NhaCungCapTCCS"] = barcodeDetail.SupplierStandardNo;

                        drDongIn["NhaPhanPhoi"] = barcodeDetail.CompanyName;
                        drDongIn["NhaPhanPhoiDiaChi"] = barcodeDetail.CompanyAddress;
                        drDongIn["NhaPhanPhoiTCCS"] = barcodeDetail.CompanyStandardNo;
                        drDongIn["XuatXu"] = barcodeDetail.Origin;
                        drDongIn["BarcodeFullString"] = barcodeDetail.BarcodeUnique;
                        drDongIn["BarcodeID"] = barcodeDetail.BarcodeID;

                        //drDongIn["BarcodeFullString"] = clsXuLyDuLieu.EncryptString(JsonConvert.SerializeObject(barcodeDetail, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));

                        //var _clsBarcodeDetailShort = new clsBarcodeShort();

                        //_clsBarcodeDetailShort.BarcodeUnique = barcodeDetail.BarcodeUnique;
                        //_clsBarcodeDetailShort.ItemName = barcodeDetail.ItemName;
                        //_clsBarcodeDetailShort.Expense = barcodeDetail.Expense;
                        //_clsBarcodeDetailShort.GoldWeight = barcodeDetail.GoldWeight;
                        //_clsBarcodeDetailShort.StoneWeight = barcodeDetail.StoneWeight;
                        //_clsBarcodeDetailShort.TotalWeight = barcodeDetail.TotalWeight;

                        //drDongIn["BarcodeFullString"] = clsXuLyDuLieu.CompressString(JsonConvert.SerializeObject(_clsBarcodeDetailShort, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
                        dsDanhSachHangHoa1.InMaVach.Rows.Add(drDongIn);
                        dsDanhSachHangHoa1.InMaVach.AcceptChanges();
                    }
                }
            }
            catch (Exception ex) 
            { 
            
            }
            RequestParameters = false;
        }


        private void rptInMaVach_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            base.OnAfterPrint(e);
        }

    }
}
