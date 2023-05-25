using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace PBL3.BLL
{
    internal class QLSanPhamBLL
    {
        public bool CheckMaSanPham(string msp1, string msp2)
        {
            foreach (SANPHAM i in getallsanpham())
            {
                if(msp1 == msp2)
                {
                    return true;
                }
               else if (msp1 == i.Mã_sản_phẩm )
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại!!!");
                    return false;
                }
            }
            MessageBox.Show("Lưu thành công!!!");
            return true;


        }

        public List<SANPHAM> getallsanpham()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.SANPHAM.Select(s => s).ToList();

            };

        }



        public List<SANPHAM> getsanphambyml(string ml)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.SANPHAM.Where(p => p.Mã_loại == ml).Select(p => p).ToList();


            }
        }
        public List<SANPHAM> getsanphambymsp(string msp)
        {
            PBL3Entities db = new PBL3Entities();

            return db.SANPHAM.Where(p => p.Mã_sản_phẩm == msp).Select(p => p).ToList();

        }
        public LOAISANPHAM getlspbyml(string ml)
        {
            using (PBL3Entities db = new PBL3Entities())
            {

                return db.LOAISANPHAM.Find(ml);


            }
        }
        public List<LOAISANPHAM> getallloaisanpham()
        {
            List<LOAISANPHAM> lsp = new List<LOAISANPHAM>();
            using (PBL3Entities db = new PBL3Entities())
            {
                lsp = db.LOAISANPHAM.Select(p => p).ToList();

            }
            return lsp;
        }
        public void xoasanpham(string msp)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                var tmp = db.SANPHAM.Find(msp);
                db.SANPHAM.Remove(tmp);
                db.SaveChanges();
            }
        }
        public void themsanpham(SANPHAM sp)
        {

        
               
                using (PBL3Entities db = new PBL3Entities())
                {                                 
                        db.SANPHAM.Add(sp);
                        db.SaveChanges();                 
                  
                }
                
               
            }
          

        
        public void capnhatsanpham(SANPHAM sp)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                var tmp = db.SANPHAM.Find(sp.Mã_sản_phẩm);
                db.Entry(tmp).CurrentValues.SetValues(sp);
                db.SaveChanges();
            }
        }
        public List<CBBItems> SetCBBLoai()
        {
            List<CBBItems> cbb=new List<CBBItems> ();
            cbb.Add(new CBBItems
            {
                Value = "0",
                Text = "All"
            }) ;
            foreach (LOAISANPHAM i in getallloaisanpham())
            {
                cbb.Add(new CBBItems
                {
                    Value=i.Mã_loại.ToString(),Text=i.Tên_loại
                });
            }
            return cbb;
        }
        public List<CBBItems> SetCBBLoaifdt()
        {
            List<CBBItems> cbb = new List<CBBItems>();
            foreach (LOAISANPHAM i in getallloaisanpham())
            {
                cbb.Add(new CBBItems
                {
                    Value = i.Mã_loại.ToString(),
                    Text = i.Tên_loại
                });
            }
            return cbb;
        }
        public List<CBBItems> SetCBBSanPham(string ml)
        {
            List<CBBItems> cbb = new List<CBBItems>();
            foreach (SANPHAM i in getsanphambyml(ml))
            {
                cbb.Add(new CBBItems
                {
                    Value = i.Mã_sản_phẩm.ToString(),
                    Text = i.Tên_sản_phẩm
                });
            }
            return cbb;
        }
    }
}
