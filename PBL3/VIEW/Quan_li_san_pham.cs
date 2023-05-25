using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace PBL3.VIEW
{
    public partial class Quan_li_san_pham : Form
    {
        private bool PQ;
        public Quan_li_san_pham(bool PQ)
        {
            InitializeComponent();
            LoadDGV();
            LoadCBBLoai();
            this.PQ = PQ;
            if (PQ == false)
            {
                button2.Visible = false;
                button4.Visible = false;
                dataGridView1.CellDoubleClick -= dataGridView1_CellDoubleClick;
            }
        }
        public void LoadDGV()
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            dataGridView1.DataSource =data.getallsanpham();
            dataGridView1.Columns["CHITIETHOADON"].Visible= false;
            dataGridView1.Columns["LOAISANPHAM"].Visible = false;
            dataGridView1.Columns["Mã_loại"].Visible = false;
        }

      public void LoadCBBLoai()
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            comboBox1.Items.AddRange(data.SetCBBLoai().ToArray());
        }

        public void LoadCBBSanPham(string ml)
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(data.SetCBBSanPham(ml).ToArray());
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            string ml = ((CBBItems)comboBox1.SelectedItem).Value;
            if (ml == "0")
            {
                comboBox2.Items.Clear();
                comboBox2.Text = null;
                dataGridView1.DataSource = data.getallsanpham();
                
            }
            else
            {
                LoadCBBSanPham(ml);
                comboBox2.Text = null;
                dataGridView1.DataSource = data.getsanphambyml(ml);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            string msp = ((CBBItems)comboBox2.SelectedItem).Value;
            dataGridView1.DataSource = data.getsanphambymsp(msp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string msp = null;
            DetailFormSanPham f=new DetailFormSanPham(msp);
            f.d += new DetailFormSanPham.MyDel(LoadDGV);
            f.Show();
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string msp =dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            DetailFormSanPham f=new DetailFormSanPham(msp);
            f.d += new DetailFormSanPham.MyDel(LoadDGV);
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QLSanPhamBLL data = new QLSanPhamBLL();
            int msp= Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);
            foreach(DataGridViewRow i in dataGridView1.SelectedRows)
            {
                data.xoasanpham(i.Cells[0].Value.ToString());
            }          
            LoadDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
