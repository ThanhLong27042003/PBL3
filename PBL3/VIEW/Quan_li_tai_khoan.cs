using PBL3.BLL;
using PBL3.DAL;
using PBL3.VIEW;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3
{
    public partial class Quan_li_tai_khoan : Form
    {
       
        private bool PQ;
        public Quan_li_tai_khoan(bool PQ)
        {
            InitializeComponent();
            ShowDGV();
            this.PQ = PQ;
            if (PQ == false)
            {
                button2.Visible = false;
                button4.Visible = false;
                dataGridView1.CellDoubleClick -= dataGridView1_CellDoubleClick;
            }
        }
        public void ShowDGV()
        {
            QLTaiKhoanBLL bll=new QLTaiKhoanBLL();
            dataGridView1.DataSource= bll.ShowAllTaiKhoan();
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            QLTaiKhoanBLL bll = new QLTaiKhoanBLL();
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                ShowDGV();
            }
            else
            {
                dataGridView1.DataSource = bll.getalltttkbyname(maskedTextBox1.Text);
                  
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            QLTaiKhoanBLL bll = new QLTaiKhoanBLL();
            string MSNV = dataGridView1.SelectedRows[0].Cells["Mã_nhân_viên"].Value.ToString();
            TAIKHOAN tk=bll.GetTaiKHoanByID(MSNV);
            
            DetailFormTaiKhoan f=new DetailFormTaiKhoan(MSNV,tk.Tên_tài_khoản,tk.Mật_khẩu);
            f.d += new DetailFormTaiKhoan.MyDel(ShowDGV);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                QLTaiKhoanBLL bll = new QLTaiKhoanBLL();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    bll.KhoaTaiKhoan(i.Cells["mã_nhân_viên"].Value.ToString(),true);
                dataGridView1.DataSource = bll.ShowAllTaiKhoan();
                        }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            DetailFormTaiKhoan f = new DetailFormTaiKhoan(null,null,null);
            f.d += new DetailFormTaiKhoan.MyDel(ShowDGV);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                QLTaiKhoanBLL bll = new QLTaiKhoanBLL();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                    bll.KhoaTaiKhoan(i.Cells["mã_nhân_viên"].Value.ToString(), false);
                dataGridView1.DataSource = bll.ShowAllTaiKhoan();
            }
        }
    }
}
