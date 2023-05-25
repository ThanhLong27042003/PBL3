using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PBL3.VIEW
{
    public partial class DetailFormSanPham : Form
    {
        private string msp ;
        public delegate void MyDel();
        public MyDel d;
        public DetailFormSanPham(string msp)
        {
            InitializeComponent();
            this.msp = msp;
            
            LoadCBBLoai();
            
            if (msp != null)
            {
                textBox1.ReadOnly = true;
                LoadDetailForm(msp);
            }
                
        }
        
        public void LoadDetailForm(string msp)
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            List<SANPHAM> sp= data.getsanphambymsp(msp);
            textBox1.Text = sp[0].Mã_sản_phẩm.ToString();
            textBox2.Text = sp[0].Tên_sản_phẩm;
            textBox3.Text = sp[0].Mã_loại.ToString();
            textBox4.Text = sp[0].Giá.ToString();
            comboBox1.Text = sp[0].LOAISANPHAM.Tên_loại;
        }
        public void LoadCBBLoai()
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            comboBox1.Items.AddRange(data.SetCBBLoaifdt().ToArray());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = ((CBBItems)comboBox1.SelectedItem).Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("vui long nhap du thong tin");
            }
            else
            {
                if (data.CheckMaSanPham(textBox1.Text, msp))
                {
                    SANPHAM sp = new SANPHAM
                    {
                        Mã_sản_phẩm = textBox1.Text,
                        Tên_sản_phẩm = textBox2.Text,
                        Mã_loại = textBox3.Text,
                        Giá = Convert.ToDouble(textBox4.Text),
                    };

                    if (msp == null)
                    {
                        data.themsanpham(sp);
                    }
                    else
                    {
                        data.capnhatsanpham(sp);

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
    }
}
