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
    
    public partial class CHITIETHOADON
    {
        public int Mã_sản_phẩm { get; set; }
        public int Mã_hóa_đơn { get; set; }
        public int Số_lượng { get; set; }
        public double Giá_tiền { get; set; }
    
        public virtual HOADON HOADON { get; set; }
        public virtual SANPHAM SANPHAM { get; set; }
    }
}
