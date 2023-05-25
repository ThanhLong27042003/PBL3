using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL3.VIEW
{
    public partial class SplitTable : Form
    {
        private string mba;
        private string mhd;
        private Button btn;
        private Order.MyDel d1;
        public delegate void MyDel();
        public MyDel d;
        public SplitTable(string mba, string mhd, Order.MyDel d1)
        {
            InitializeComponent();
            this.mhd = mhd;
            this.mba = mba;
            LoadCBBTable();
            LoadDGV();
            this.d1 = d1;
        }
        public void LoadCBBTable()
        {
            QLOrderBLL bll = new QLOrderBLL();
            comboBox1.Items.AddRange(bll.SetCBBSplitTable(mba).ToArray());
        }

        public void LoadDGV()
        {
            QLOrderBLL bll = new QLOrderBLL();
            dataGridView1.DataSource = bll.ShowHoaDonByMaHoaDon(mhd);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                QLOrderBLL bll = new QLOrderBLL();
                List<ShowHoaDon> HDs = new List<ShowHoaDon>();
                foreach (DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    bll.DeleteChiTietHoaDonByMaHoaDonAndMaSanPham(mhd, i.Cells["Mã_sản_phẩm"].Value.ToString());
                    HDs.Add(new ShowHoaDon
                    {
                        Mã_sản_phẩm = i.Cells[0].Value.ToString(),
                        Tên_loại = i.Cells[1].Value.ToString(),
                        Tên_sản_phẩm = i.Cells[2].Value.ToString(),
                        Số_lượng = Convert.ToInt32(i.Cells[3].Value),
                        Giá_tiền = Convert.ToDouble(i.Cells[4].Value)

                    });
                }
                CreateBill f = new CreateBill(bll.GetBanByMaBan(((CBBItems)comboBox1.SelectedItem).Value).Mã_bàn_ảo, d1, HDs);
                f.Show();

            }
        }
    }
}
