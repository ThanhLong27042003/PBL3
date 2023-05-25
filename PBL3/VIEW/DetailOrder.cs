using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PBL3.VIEW
{
    public partial class DetailOrder : Form
    {
        private string mba;
        private string mnv;
        private string mhd;
        private Order.MyDel d1;
        public DetailOrder(string mhd,string mnv, string mba, Order.MyDel d1)
        {
            InitializeComponent();
            this.d1 = d1;
            this.mba = mba;
            this.mnv = mnv;
            this.mhd = mhd;
            LoadGUI();
            LoadCBBLOAI();
            LoadCBBBAN();
          
        }
        public void LoadCBBBAN()
        {
            QLOrderBLL bll=new QLOrderBLL();
            comboBox3.Items.AddRange(bll.SetCBBChangeTable().ToArray());
        }
        public void LoadGUI()
        {
            QLOrderBLL bll=new QLOrderBLL();
            dataGridView1.DataSource = bll.ShowHoaDonByMaHoaDon(mhd);          
            textBox1.Text = bll.Total(mhd);
        }

        public void LoadCBBSANPHAM(string ml)
        {
            QLOrderBLL bll = new QLOrderBLL();
            comboBox2.Items.AddRange(bll.SetCBBSanPham(ml).ToArray());
        }

        public void LoadCBBLOAI()
        {
            QLOrderBLL bll = new QLOrderBLL();
            comboBox1.Items.AddRange(bll.SetCBBLoai().ToArray());
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            LoadCBBSANPHAM(((CBBItems)comboBox1.SelectedItem).Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null && numericUpDown1.Value > 0)
            {
                QLOrderBLL bll = new QLOrderBLL();
                string msp = ((CBBItems)comboBox2.SelectedItem).Value;
                int SL = Convert.ToInt32(numericUpDown1.Value);
                bll.ShowChiTietHoaDon(mhd, msp, SL, false);
                dataGridView1.DataSource = bll.ShowHoaDonByMaHoaDon(mhd);
                textBox1.Text = bll.Total(mhd);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đúng thông tin!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLOrderBLL bll=new QLOrderBLL();
            if(dataGridView1.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow r in dataGridView1.SelectedRows)
                {
                    bll.DeleteChiTietHoaDonByMaHoaDonAndMaSanPham(mhd,r.Cells[0].Value.ToString());
                }
                dataGridView1.DataSource = bll.ShowHoaDonByMaHoaDon(mhd);
                textBox1.Text = bll.Total(mhd);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            QLOrderBLL bll=new QLOrderBLL();
            bll.CanCellOrder(mhd,mba);
            Order f = new Order();
            f.d = d1;
            d1(f);
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Order f = new Order();
            f.d = d1;
            d1(f);
           Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                QLOrderBLL bll = new QLOrderBLL();
                bll.UpDateStatusHoaDon(mhd, true);
                bll.UpDateStatusBanAo(mba, true);
                bll.UpdateMergeStatusAndMaBanAoIntoBan(mba);
                Order f = new Order();
                f.d = d1;
                d1(f);
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng đặt món rồi hãy thanh toán!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem != null)
            {
                QLOrderBLL bll = new QLOrderBLL();
                bll.ChangeTable(mhd, mba, ((CBBItems)comboBox3.SelectedItem).Value);
                MessageBox.Show("Chuyen ban thanh cong!!!");
                Order f = new Order();
                f.d = d1;
                d1(f);
                this.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MergeTable f=new MergeTable(mba,mhd);
            f.d+=new MergeTable.MyDel(LoadGUI);
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SplitTable f = new SplitTable(mba, mhd,d1);
            f.d += new SplitTable.MyDel(LoadGUI);
            f.Show();
        }

      
    }
}
