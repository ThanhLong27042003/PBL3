//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBL3.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TAIKHOAN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TAIKHOAN()
        {
            this.HOADON = new HashSet<HOADON>();
        }
    
        public int Mã_tài_khoản { get; set; }
        public string Tên_tài_khoản { get; set; }
        public string Mật_khẩu { get; set; }
        public Nullable<bool> PQ { get; set; }
        public Nullable<bool> Khóa { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADON { get; set; }
        public virtual THONGTINTAIKHOAN THONGTINTAIKHOAN { get; set; }
    }
}
