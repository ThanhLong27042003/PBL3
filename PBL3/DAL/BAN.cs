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
    
    public partial class BAN
    {
        public string Mã_bàn { get; set; }
        public string Tên_bàn { get; set; }
        public string Mã_bàn_ảo { get; set; }
        public string Mã_bàn_ảo_chính { get; set; }
        public bool Trạng_thái_ghép { get; set; }
    
        public virtual BANAO BANAO { get; set; }
    }
}