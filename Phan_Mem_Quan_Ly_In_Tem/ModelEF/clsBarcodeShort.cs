using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_In_Tem.ModelEF
{
    public class clsBarcodeShort
    {
        public Nullable<System.Guid> BarcodeUnique { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public Nullable<decimal> StoneWeight { get; set; }
        public Nullable<decimal> GoldWeight { get; set; }
        public Nullable<decimal> Expense { get; set; }
    }
}
