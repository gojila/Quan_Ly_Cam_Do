using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Common
{
    public static class Common
    {
        public static void OpenErrorMessage(string message) 
        {
            XtraMessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void OpenSuccessMessage(string message)
        {
            XtraMessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void OpenActionSuccessMessage()
        {
            XtraMessageBox.Show("Thao tác thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult OpenConfirmDeleteMessage()
        {
            return XtraMessageBox.Show("Bạn có chắc là muốn xóa không ?", "Xóa dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
