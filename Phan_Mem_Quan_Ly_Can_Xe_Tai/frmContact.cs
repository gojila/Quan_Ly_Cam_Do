using DevExpress.XtraEditors;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Can_Xe_Tai
{
    public partial class frmContact : XtraForm
    {
        public frmContact()
        {
            InitializeComponent();
        }

        private void hplFacebook_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(hplFacebook.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(JsonConvert.SerializeObject(ex), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
