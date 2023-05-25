using PBL3.BLL;
using PBL3.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBL3.VIEW
{
    public partial class MergeTable : Form
    {
        private string mba;
        private string mhd;
        public delegate void MyDel();
        public MyDel d;
        public MergeTable(string mba, string mhd)
        {
            InitializeComponent();
            this.mhd = mhd;
            this.mba = mba;
            LoadCBBTable();

        }
        public void LoadCBBTable()
        {
            QLOrderBLL bll = new QLOrderBLL();
            comboBox1.Items.AddRange(bll.SetCBBMergeTable(mba).ToArray());
        }



        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QLOrderBLL bll = new QLOrderBLL();
            BAN b = bll.GetBanByMaBan(((CBBItems)comboBox1.SelectedItem).Value);
            List<HOADON> hd = bll.GetHoaDonByMaBanAo(b.Mã_bàn_ảo);
            if (hd.Count > 0)
            {
                dataGridView1.DataSource = bll.ShowHoaDonByMaHoaDon(hd[0].Mã_hóa_đơn);
            }
            else dataGridView1.DataSource = bll.ShowHoaDonByMaHoaDon(null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                QLOrderBLL bll = new QLOrderBLL();
                foreach (DataGridViewRow i in dataGridView1.Rows)
                {
                    string msp = i.Cells["mã_sản_phẩm"].Value.ToString();
                    int SL = Convert.ToInt32(i.Cells["số_lượng"].Value);
                    bll.ShowChiTietHoaDon(mhd, msp, SL, true);

                }
                bll.DeleteChiTietHoaDon(bll.GetMaHoaDonByBan(((CBBItems)comboBox1.SelectedItem).Value));
                bll.DeleteHoaDon(bll.GetMaHoaDonByBan(((CBBItems)comboBox1.SelectedItem).Value));
                bll.UpdateMaBanAoAndStatusIntoBan(((CBBItems)comboBox1.SelectedItem).Value, mba);
                d();
                Close();
            }
        }
    }
}
