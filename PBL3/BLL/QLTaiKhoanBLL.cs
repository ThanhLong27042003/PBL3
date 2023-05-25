using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace PBL3.BLL
{
    internal class QLTaiKhoanBLL
    {
        public bool CheckMaNhanVien(string MSNV1 , string MSNV2)
        {
            foreach(THONGTINTAIKHOAN i in GetAllTaiKhoan())
            {
                if (MSNV1 == MSNV2)
                {
                    return true;
                }
                else if (MSNV1 == i.Mã_nhân_viên )
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!!!");
                    return false;
                }
            }
            MessageBox.Show("Lưu thành công!!!");
            return true;         
            }
        public void CheckTaiKhoanAndShowMainForm(string tk, string mk)
        {
            PBL3Entities db = new PBL3Entities();
            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("vui long nhap day du thong tin");
            }
            else
            {
                foreach (TAIKHOAN i in db.TAIKHOAN)
                {
                    if (i.Tên_tài_khoản == tk && i.Mật_khẩu == mk)
                    {
                        if (i.Khóa == false)
                        {
                            MessageBox.Show("Đăng nhập thành công!!!");
                            MainForm f = new MainForm(i.Mã_tài_khoản, Convert.ToBoolean(i.PQ));
                            f.Show();
                        }
                        else MessageBox.Show("Tài khoản của bạn đã bị khóa !!!");
                        return;

                    }

                }
                        MessageBox.Show("Tài khoản hoặc mật khẩu không tồn tại!!!");
                        return;
                    
                
            }
        }                                 
        public List<THONGTINTAIKHOAN> GetAllTaiKhoan()
        {
            List<THONGTINTAIKHOAN> tttk = new List<THONGTINTAIKHOAN>();
            using (PBL3Entities db = new PBL3Entities())
            {
                tttk = db.THONGTINTAIKHOAN.Select(p => p).ToList();
            }
            return tttk;
        }
        public object ShowAllTaiKhoan()
        {
            object tttk = new object();
            using (PBL3Entities db = new PBL3Entities())
            {
                tttk = db.THONGTINTAIKHOAN.Select(p => new {p.Mã_nhân_viên , p.Tên_nhân_viên ,p.CMND , p.SĐT ,p.Địa_chỉ , p.TAIKHOAN.Khóa}).ToList();
            }
            return tttk;
        }
        public object getalltttkbyname(string name)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.THONGTINTAIKHOAN.Where(tttk => tttk.Tên_nhân_viên.Contains(name)).Select(p => new { p.Mã_nhân_viên, p.Tên_nhân_viên, p.CMND, p.SĐT, p.Địa_chỉ, p.TAIKHOAN.Khóa }).ToList();
            };
        }
        public THONGTINTAIKHOAN GetThongTinTaiKHoanByID(string id)
        {
            THONGTINTAIKHOAN tttk = new THONGTINTAIKHOAN();
            using (PBL3Entities db = new PBL3Entities())
            {
                tttk = db.THONGTINTAIKHOAN.Find(id);
            }
            return tttk;
        }
        public TAIKHOAN GetTaiKHoanByID(string id)
        {
            TAIKHOAN tk = new TAIKHOAN();
            using (PBL3Entities db = new PBL3Entities())
            {
                tk = db.TAIKHOAN.Find(id);
            }
            return tk;
        }

        public void KhoaTaiKhoan(string id,bool k)
        {
            using (PBL3Entities db = new PBL3Entities())
            {             
                var s = db.TAIKHOAN.Find(id);              
                    s.Khóa = k;          
                db.SaveChanges();
            }
        }
        public void ThemTaiKhoan(THONGTINTAIKHOAN tttk, TAIKHOAN tk)
        {

            using (PBL3Entities db = new PBL3Entities())
            {
                TAIKHOAN tk1 = db.TAIKHOAN.Find(tk.Mã_tài_khoản);
                db.THONGTINTAIKHOAN.Add(tttk);
                db.TAIKHOAN.Add(tk);
                db.SaveChanges();
            }                          
                }
               
            
     
        public void UpdateTaiKhoan(THONGTINTAIKHOAN tttk, TAIKHOAN tk)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                var tmp1 = db.THONGTINTAIKHOAN.Find(tttk.Mã_nhân_viên);
                var tmp2 = db.TAIKHOAN.Find(tk.Mã_tài_khoản);
                tmp1.Mã_nhân_viên = tttk.Mã_nhân_viên;
                tmp1.Tên_nhân_viên = tttk.Tên_nhân_viên;
                tmp1.CMND = tttk.CMND;
                tmp1.SĐT = tttk.SĐT;
                tmp1.Địa_chỉ = tttk.Địa_chỉ;
                tmp2.Mã_tài_khoản = tk.Mã_tài_khoản;
                tmp2.Tên_tài_khoản = tk.Tên_tài_khoản;
                tmp2.Mật_khẩu = tk.Mật_khẩu;
                tmp2.PQ = tk.PQ;
                db.SaveChanges();
            }
        }
      
       
    }
}
