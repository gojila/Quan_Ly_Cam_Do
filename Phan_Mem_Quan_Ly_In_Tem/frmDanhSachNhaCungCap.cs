using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using Phan_Mem_Quan_Ly_In_Tem.XuLy;
using DevExpress.XtraEditors;

namespace Phan_Mem_Quan_Ly_In_Tem
{
    public partial class frmDanhSachNhaCungCap : XtraForm
    {
        private string opentype = "";
        private string duongDanFileExcel = "";

        public delegate void ChonNhaCungCapEventHander(string nhacungcap, string tentiem, string diachi);

        public event ChonNhaCungCapEventHander ChonNhaCungCap;
        private void RaiseChonNhaCungCapEventHander(string nhacungcap, string tentiem, string diachi)
        {
            if (ChonNhaCungCap != null)
            {
                ChonNhaCungCap(nhacungcap, tentiem, diachi);
            }
        }

        public frmDanhSachNhaCungCap()
        {
            InitializeComponent();

            //DateTime tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //DateTime den = tu.AddMonths(1).AddDays(-1);

            //dtTu.DateTime = tu;
            //dtDen.DateTime = den;

            bbiXem_ItemClick(this, null);

            gbList.ShownEditor += (s, e) => 
            {
                var view = s as GridView;
                view.ActiveEditor.DoubleClick += ActiveEditor_DoubleClick;
            };
        }

        public frmDanhSachNhaCungCap(string _duongDanFileExcel)
        {
            InitializeComponent();

            //DateTime tu = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //DateTime den = tu.AddMonths(1).AddDays(-1);

            //dtTu.DateTime = tu;
            //dtDen.DateTime = den;

            duongDanFileExcel = _duongDanFileExcel;

            bbiXem_ItemClick(this, null);

            gbList.ShownEditor += (s, e) =>
            {
                var view = s as GridView;
                view.ActiveEditor.DoubleClick += ActiveEditor_DoubleClick;
            };
        }

        public void setOpenType(string _opentype) 
        {
            this.opentype = _opentype;
        }

        private void ActiveEditor_DoubleClick(object sender, EventArgs e)
        {
            if (opentype == "")
            {
                var nhaCungCap = gbList.GetFocusedRowCellValue(colSupplierBaseStandardNo);
                var tenTiem = gbList.GetFocusedRowCellValue(colSupplierName);
                var diaChi = gbList.GetFocusedRowCellValue(colSupplierAddress);
                //var noicap = gbList.GetFocusedRowCellValue(colNoi_Cap);
                //var diachi = gbList.GetFocusedRowCellValue(colDia_Chi);
                //var sodienthoai = gbList.GetFocusedRowCellValue(colSo_Dien_Thoai); 

                RaiseChonNhaCungCapEventHander(
                    nhaCungCap.ToString(),
                    tenTiem.ToString(),
                    diaChi.ToString()
                    );

                this.Close();
            }
            else if (opentype == "edit") 
            {
                bbiSua_ItemClick(this, null);
            }   
        }

        private void bbiDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void DanhSachKhachHang_Load(object sender, EventArgs e)
        {

        }

        //clsXuLyDuLieu _xuLy = new clsXuLyDuLieu();
        private void bbiXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //dANH_SACH_KHACH_HANGTableAdapter.Connection.ConnectionString = SqlHelper.ConnectionString;
            //dANH_SACH_KHACH_HANGTableAdapter.ClearBeforeFill = true;
            //dANH_SACH_KHACH_HANGTableAdapter.Fill(dsCamDo.DANH_SACH_KHACH_HANG);

            //var fileThongTinTiem = new FileInfo(Application.StartupPath + "\\ThongTinTiem.xml");
            //if (!fileThongTinTiem.Exists)
            //{
            //    string duongDanFileExcelMacDinh = Application.StartupPath + "\\InMaVach.xlsx";
            //    if (File.Exists(duongDanFileExcelMacDinh))
            //    {
            //        //bbiChonFileDuLieu.EditValue = duongDanFileExcelMacDinh;
            //        DataTable dtMaVachExcel = new DataTable();
            //        dtMaVachExcel = _xuLy.docDanhSachNhaCungCapFileExcel(duongDanFileExcelMacDinh, Path.GetExtension(duongDanFileExcelMacDinh), "Yes");
            //        MessageBox.Show(dtMaVachExcel.Rows.Count.ToString());
            //        napDuLieuVaoLuoiTuFileExcel(dtMaVachExcel);
            //    }
            //}

            //if (File.Exists(duongDanFileExcel))
            //{
            //    //bbiChonFileDuLieu.EditValue = duongDanFileExcelMacDinh;
            //    //DataTable dtMaVachExcel = new DataTable();
            //    //dtMaVachExcel = _xuLy.docDanhSachNhaCungCapFileExcel(duongDanFileExcel, Path.GetExtension(duongDanFileExcel), "Yes");
            //    //MessageBox.Show(dtMaVachExcel.Rows.Count.ToString());
            //    //napDuLieuVaoLuoiTuFileExcel(dtMaVachExcel);
            //}


            var db = new ModelEF.PrintBarcodeEntities();
            gcList.DataSource = db.Suppliers.Where(s => !(s.IsDeleted ?? false)).ToList();
            gbList.BestFitColumns();

        }
        /*
        private void napDuLieuVaoLuoiTuFileExcel(DataTable dtMaVachExcel)
        {
            dsDanhSachNhaCungCap.DanhSachNhaCungCap.Rows.Clear();
            if (dtMaVachExcel != null && dtMaVachExcel.Rows.Count > 0) 
            {
                foreach (DataRow dr in dtMaVachExcel.Rows)
                {
                    //AddInMaVachRow(string MaVach, string TenHang, decimal TongTrongLuong, decimal TrongLuong, decimal TienCong, decimal Hot, string LoaiVang, string NhaCungCap, string HamLuongPho, int SoLuongTem, string TongTrongLuongChu, string TrongLuongChu, string HotChu)
                    dsDanhSachNhaCungCap.DanhSachNhaCungCap.AddDanhSachNhaCungCapRow(
                        dr["Nhà Cung Cấp"].ToString(),
                        dr["Tên Tiệm"].ToString(),
                        dr["Địa Chỉ"].ToString(),
                        dr["ID"].ToString()
                        );
                    //dsDanhSachHangHoa.InMaVach.AddInMaVachRow
                    //    (
                    //    dr["Mã Vạch"].ToString(),
                    //    dr["Tên Hàng"].ToString(),
                    //    Convert.ToDecimal(dr["Tổng Trọng Lượng"] == DBNull.Value ? 0 : dr["Tổng Trọng Lượng"]),
                    //    Convert.ToDecimal(dr["Trọng Lượng"] == DBNull.Value ? 0 : dr["Trọng Lượng"]),
                    //    Convert.ToDecimal(dr["Tiền Công"] == DBNull.Value ? 0 : dr["Tiền Công"]),
                    //    Convert.ToDecimal(dr["Hột"] == DBNull.Value ? 0 : dr["Hột"]),
                    //    dr["Nhà Cung Cấp"].ToString(),
                    //    dr["Hàm Lượng Phổ"].ToString(),
                    //    Convert.ToInt32(dr["Số Lượng Tem"] == DBNull.Value ? 0 : dr["Số Lượng Tem"]),
                    //    _xuLy.chuyenGiaTriSangNoiDung(Convert.ToDecimal(dr["Tổng Trọng Lượng"] == DBNull.Value ? 0 : dr["Tổng Trọng Lượng"])),
                    //    _xuLy.chuyenGiaTriSangNoiDung(Convert.ToDecimal(dr["Trọng Lượng"] == DBNull.Value ? 0 : dr["Trọng Lượng"])),
                    //    _xuLy.chuyenGiaTriSangNoiDung(Convert.ToDecimal(dr["Hột"] == DBNull.Value ? 0 : dr["Hột"]))
                    //    );
                }
                gbList.BestFitColumns();
            }
        }
        */
        private void bbiChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ActiveEditor_DoubleClick(this, null);
        }

        private void gbList_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
            }
        }

        private void rptChon_Click(object sender, EventArgs e)
        {
            bbiChon_ItemClick(this, null);
        }

        private void bbiSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var id = gbList.GetFocusedRowCellValue(colSupplierID.FieldName);
                if (id != null)
                {
                    var _frmAdd = new frmNhaCungCapAdd(duongDanFileExcel, id.ToString());
                    _frmAdd.NapLai += () =>
                    {
                        bbiXem_ItemClick(this, null);
                    };
                    _frmAdd.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                var _frmAdd = new frmNhaCungCapAdd(duongDanFileExcel);
                _frmAdd.NapLai += () => 
                {
                    bbiXem_ItemClick(this, null);
                };
                _frmAdd.ShowDialog();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bbiXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try 
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                int[] selectedRows = gbList.GetSelectedRows();
                string ids = "";
                if (selectedRows.Length > 0)
                {
                    //clsXuLyDuLieu _clsXuLyDuLieu = new clsXuLyDuLieu();
                    for (int i = selectedRows.Length; i > 0; i--)
                    {
                        var arg = gbList.GetRowCellValue(selectedRows[i - 1], colSupplierID);
                        if (arg == null)
                            continue;

                        if (!string.IsNullOrEmpty(ids))
                        {
                            ids += ",";
                        }
                        ids += arg.ToString();
                        //_clsXuLyDuLieu.xoaMauTemIn(this.path, arg.ToString());
                    }
                    if (!string.IsNullOrEmpty(ids))
                    {
                        using (var db = new ModelEF.PrintBarcodeEntities())
                        {
                            db.Database.ExecuteSqlCommand("UPDATE [Supplier] SET [IsDeleted] = 1, [DeletedDate] = GETDATE() WHERE [SupplierID] IN (" + ids + ")");
                            db.SaveChanges();
                        }
                    }
                    MessageBox.Show(this, "Xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bbiXem_ItemClick(this, null);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(this, ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
