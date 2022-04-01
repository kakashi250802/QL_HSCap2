using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HSCap2
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void giaoDiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLopHoc frm = (frmLopHoc)Program.FindOpenedForm("frmLopHoc");
            if (frm == null)
            {
                frm = new frmLopHoc();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void nhómMônToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhomMon frm = (frmNhomMon)Program.FindOpenedForm("frmNhomMon");
            if (frm == null)
            {
                frm = new frmNhomMon();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMonhoc frm = (frmMonhoc)Program.FindOpenedForm("frmMonhoc");
            if (frm == null)
            {
                frm = new frmMonhoc();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void họcSinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHocSinh frm = (frmHocSinh)Program.FindOpenedForm("frmHocSinh");
            if (frm == null)
            {
                frm = new frmHocSinh();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void hệSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoaiDiem frm = (frmLoaiDiem)Program.FindOpenedForm("frmLoaiDiem");
            if (frm == null)
            {
                frm = new frmLoaiDiem();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bảngĐiểmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDiem frm = (frmDiem)Program.FindOpenedForm("frmDiem");
            if (frm == null)
            {
                frm = new frmDiem();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
