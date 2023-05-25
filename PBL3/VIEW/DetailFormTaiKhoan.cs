using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBL3.VIEW
{
    public partial class DetailFormTaiKhoan : Form
    {
        private string MSNV;
        private string ttk;
        private string mk;
        public delegate void MyDel();
        public MyDel d;
        public DetailFormTaiKhoan(string MSNV,string ttk,string mk)
        {
            InitializeComponent();
            this.MSNV = MSNV;
            this.ttk = ttk;
            this.mk = mk;
            if (MSNV != null)
            {
                SETDetailForm(MSNV);
              textBox1.ReadOnly = true;
                
            }
        }
        public void SETDetailForm(string id)
        {
            QLTaiKhoanBLL bll=new QLTaiKhoanBLL();
            THONGTINTAIKHOAN tttk=bll.GetThongTinTaiKHoanByID(id);
            TAIKHOAN tk = bll.GetTaiKHoanByID(id);
            textBox1.Text = tttk.Mã_nhân_viên;
            textBox2.Text= tttk.Tên_nhân_viên;
            textBox3.Text = tttk.CMND;
            textBox4.Text = tttk.SĐT;
            textBox5.Text = tttk.Địa_chỉ;
            textBox6.Text = tk.Tên_tài_khoản;
            tbmk.Text = tk.Mật_khẩu;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(tbmk.Text)) MessageBox.Show("vui long nhap du thong tin");
            else
            {
                QLTaiKhoanBLL data = new QLTaiKhoanBLL();
                if (data.CheckMaNhanVien(textBox1.Text,MSNV))
                {
                    
                    THONGTINTAIKHOAN tttk = new THONGTINTAIKHOAN();
                    TAIKHOAN tk = new TAIKHOAN();
                    tttk.Mã_nhân_viên = textBox1.Text;
                    tttk.Tên_nhân_viên = textBox2.Text;
                    tttk.CMND = textBox3.Text;
                    tttk.SĐT = textBox4.Text;
                    tttk.Địa_chỉ = textBox5.Text;
                    tk.Mã_tài_khoản = textBox1.Text;
                    tk.Tên_tài_khoản = textBox6.Text;
                    tk.Mật_khẩu = tbmk.Text;
                    tk.PQ = false;
                    tk.Khóa = false;
                     if (MSNV == null)
                    {
                        data.ThemTaiKhoan(tttk, tk);
                        
                    }
                    else
                    {
                        data.UpdateTaiKhoan(tttk, tk);
                        
                    }
                    d();
                    this.Close();
                }
                
            }
        }
             
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttrue_Click(object sender, EventArgs e)
        {
            bttrue.Visible = false;
            btfalse.Visible = true;
            tbmk.PasswordChar = '*';
        }

        private void btfalse_Click(object sender, EventArgs e)
        {
            btfalse.Visible = false;
            bttrue.Visible = true;
            tbmk.PasswordChar = '\0';
        }
    }
}
