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
    
    public partial class THONGTINTAIKHOAN
    {
        public string Mã_nhân_viên { get; set; }
        public string Tên_nhân_viên { get; set; }
        public string CMND { get; set; }
        public string SĐT { get; set; }
        public string Địa_chỉ { get; set; }
    
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}
