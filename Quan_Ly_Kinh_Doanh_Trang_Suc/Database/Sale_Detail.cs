//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_Ly_Kinh_Doanh_Trang_Suc.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale_Detail
    {
        public long SaleDetailID { get; set; }
        public long SaleID { get; set; }
        public string SaleCode { get; set; }
        public Nullable<long> ItemID { get; set; }
        public Nullable<long> ItemCode { get; set; }
        public string ItemName { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public Nullable<decimal> GoldWeight { get; set; }
        public Nullable<decimal> StoneWeight { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> LaborFee { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string Descriptions { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<int> CreatedUserID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedUserID { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string GoldType { get; set; }
        public string ItemBarcode { get; set; }
    }
}
