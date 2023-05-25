using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Windows.Forms;

namespace PBL3.VIEW
{
    public partial class Order : Form
    {
        public delegate void MyDel(Form f);
        public MyDel d { get; set; }
        public Order()
        {
            InitializeComponent();
            LoadTableList();
        }
        public void LoadTableList()
        {
            QLOrderBLL bll = new QLOrderBLL();
            foreach (BAN i in bll.GetAllTable())
            {
                Button btn;
                if (i.Trạng_thái_ghép == false)
                {
                     btn = new Button() { Width = 90, Height = 90, Text = i.Tên_bàn, Name = i.Tên_bàn };
                    btn.BackColor = bll.StatusColor(i.BANAO.Trạng_thái);
                }
                else
                {
                     btn = new Button() { Width = 90, Height = 90, Text = i.BANAO.Tên_bàn_ảo, Name = i.Tên_bàn };
                    btn.BackColor =System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                }
                btn.Tag = i;
                btn.Click += button_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            QLOrderBLL bll = new QLOrderBLL();
            Button b1 = sender as Button;
            BAN b = b1.Tag as BAN;
            BANAO ba = bll.GetBanAoByMaBanAo(b.BANAO.Mã_bàn_ảo);
            if (ba.Trạng_thái == true)
            {
                CreateBill f = new CreateBill(ba.Mã_bàn_ảo,d);            
                f.Show();
            }
            else
            {
                d(new DetailOrder(bll.GetHoaDonByMaBanAo(ba.Mã_bàn_ảo)[0].Mã_hóa_đơn, null, ba.Mã_bàn_ảo,d));
            }
        }
    }
}
