using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3.VIEW
{
    public partial class CreateBill : Form
    {
        private string mba;
        private Order.MyDel d1;
        List<ShowHoaDon> HDs;
        public CreateBill(string mba, Order.MyDel d1)
        {
            InitializeComponent();
            this.mba = mba;
            this.d1 = d1;
        }

        public CreateBill(string mba, Order.MyDel d1, List<ShowHoaDon> HDs)
        {
            InitializeComponent();
            this.mba = mba;
            this.d1 = d1;
            this.HDs = HDs;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("vui long nhap du thong tin");
            }
            else
            {
                QLOrderBLL bll = new QLOrderBLL();
                if (bll.CheckMHDCreateBill(textBox1.Text) && bll.CheckMNVCreateBill(textBox2.Text))
                {
                    bll.AddHoaDon(textBox1.Text, textBox2.Text, mba);
                    bll.UpDateStatusBanAo(mba, false);
                    if (HDs != null)
                    {
                        foreach (ShowHoaDon i in HDs)
                        {

                            bll.AddChiTietHoaDon(i.Mã_sản_phẩm, textBox1.Text, i.Số_lượng);
                        }
                    }
                    d1(new DetailOrder(textBox1.Text, textBox2.Text, mba, d1));
                }
                Close();
            }
        }
    }
}
