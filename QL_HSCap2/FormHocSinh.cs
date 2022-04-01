using BaiTapLonQLDIEMHS;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_FORM_MDI
{
    public partial class FormHocSinh : MaterialForm
    {
        HocSinhBLL bllHS;
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public FormHocSinh()
        {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            InitializeComponent();
            bllHS = new HocSinhBLL();

        }
        public void showAllHocSinh(string filter="")
        {
            DataTable dt = bllHS.getAllHocSinh();
            DataView view = new DataView(dt);
            if (!string.IsNullOrEmpty(filter))
            {
                view.RowFilter = filter;
            }
            gridviewHS.DataSource = view;
            gridviewHS.AutoGenerateColumns = false;

            btnXoaHS.Enabled = btnSuaHS.Enabled = btnTimKiemHS.Enabled = (gridviewHS.Rows.Count > 0);
        }

        private void FormHocSinh_Load(object sender, EventArgs e)
        {
            showAllHocSinh();
        }
        private bool checkDataHS()
        {
            if (string.IsNullOrEmpty(txtMaHS.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập mã học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtTenHS.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mktNgaySinh.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập ngày sinh của học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mktNgaySinh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(mktSDTPhuHuynh.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập số điện thoại phụ huynh của học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mktSDTPhuHuynh.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtMaLopHS.Text))
            {
                MessageBox.Show("Bạn Chưa nhập mã lớp của học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLopHS.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Bạn Chưa địa chỉ của học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChi.Focus();
                return false;
            }
            if (!rdbNam.Checked && !rdbNu.Checked)
            {
                MessageBox.Show("Bạn Chưa chọn giới tính của học sinh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rdbNam.Focus();
                return false;
            }
            return true;
        }
        private void resetFormHocSinh()
        {
            txtDiaChi.Text = txtMaHS.Text = txtTenHS.Text = txtMaLopHS.Text = mktNgaySinh.Text = mktSDTPhuHuynh.Text = "";
            btnThemHS.Text = "Thêm mới";
            btnThemHS.Tag = String.Empty;
            btnSuaHS.Enabled = btnXoaHS.Enabled = btnThemHS.Enabled = btnTimKiemHS.Enabled = true;
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            showAllHocSinh();
        }

        private void btnThemHS_Click(object sender, EventArgs e)
        {
            if (checkDataHS())
            {
                string procName = (btnThemHS.Text == "Cập Nhật") ? "update" : "insert";
                tbl_HocSinh hs = new tbl_HocSinh();
                hs.sMaHocSinh = txtMaHS.Text;
                hs.sTenHocSinh = txtTenHS.Text;
                hs.dNgaySinh = DateTime.ParseExact(mktNgaySinh.Text, "ddMMyyyy", null);
                hs.sDiaChi = txtDiaChi.Text;
                hs.sMaLop = txtMaLopHS.Text;
                hs.bGioiTinh = rdbNam.Checked;
                hs.sSDTPhuHuynh = mktSDTPhuHuynh.Text.Trim();
                if (procName == "insert")
                {
                    if (bllHS.insertHocSinh(hs))
                    {
                        MessageBox.Show("Thêm Học sinh mới mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showAllHocSinh();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi xảy ra, xin vui lòng thử lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show("Bạn muốn cập nhập thông tin học sinh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (bllHS.upateHocsinh(hs))
                        {
                            MessageBox.Show("cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            showAllHocSinh();
                            resetFormHocSinh();//
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra, xin vui lòng thử lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                            resetFormHocSinh();
                    }

                }

            }
        }
        private void chuyenTrangThaiSuaHocsinh(DataRowView drvHS)
        {
            txtMaHS.Text = drvHS["Mã HS"].ToString();
            txtTenHS.Text = drvHS["Tên HS"].ToString();
            if (drvHS["Giới tính"].ToString() == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
            txtMaLopHS.Text = drvHS["Mã lớp"].ToString();
            mktNgaySinh.Text = drvHS["Ngày sinh"].ToString();
            txtDiaChi.Text = drvHS["Địa chỉ"].ToString();
            mktSDTPhuHuynh.Text = drvHS["SĐT Phụ Huynh"].ToString();

            btnThemHS.Text = "Cập Nhật";
            //btnThemHS.Tag = drvHS["Mã lớp"].ToString();
            btnSuaHS.Enabled = btnXoaHS.Enabled = btnTimKiemHS.Enabled = false;
        }
        private void btnSuaHS_Click(object sender, EventArgs e)
        {
            DataView dvHS = (DataView)gridviewHS.DataSource;
            DataRowView drvHS = dvHS[gridviewHS.CurrentRow.Index];
            chuyenTrangThaiSuaHocsinh(drvHS);
        }

        private void btnBoQuaHS_Click(object sender, EventArgs e)
        {
            resetFormHocSinh();
        }

        private void btnXoaHS_Click(object sender, EventArgs e)
        {
            DataView dvHS = (DataView)gridviewHS.DataSource;
            DataRowView drvHS = dvHS[gridviewHS.CurrentRow.Index];
            tbl_HocSinh hs = new tbl_HocSinh();
            hs.sMaHocSinh = drvHS["Mã HS"].ToString();

            DialogResult dialogResult = MessageBox.Show("Bạn muốn Xoá thông tin học sinh có mã " + hs.sMaHocSinh, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                if (bllHS.deleteHocSinh(hs))
                {
                    MessageBox.Show("Xóa học sinh thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showAllHocSinh();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra, xin vui lòng thử lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void btnTimKiemHS_Click(object sender, EventArgs e)
        {
            string filter = "";
            if (!string.IsNullOrEmpty(txtMaHS.Text))
            {
                filter += string.Format("sMaHS LIKE '%{0}%'", txtMaHS.Text.Trim());

            }
            if (!string.IsNullOrEmpty(txtTenHS.Text))
            {
                //filter += txtTenHS.Text;
                filter += string.IsNullOrEmpty(filter) ?  string.Format(" sTenHS LIKE '%{0}%'", txtTenHS.Text) : string.Format(" AND sTenHS LIKE '%{0}%'", txtTenHS.Text);

            }
            if (!string.IsNullOrEmpty(mktNgaySinh.Text))
            {
                //filter += string.Format(" AND dNgaySinh = '%{0}%'", DateTime.ParseExact(mktNgaySinh.Text, "ddMMyyyy", null));
                    //;
            }
            if (!string.IsNullOrEmpty(mktSDTPhuHuynh.Text))
            {
                //filter += string.Format(@" AND sSDTPhuHuynh LIKE '%{0}%'", mktSDTPhuHuynh.Text.Replace("()-", string.Empty).Trim());
                ///  filter += mktSDTPhuHuynh.Text.Trim();

            }
            if (!string.IsNullOrEmpty(txtMaLopHS.Text))
            {
                filter += string.IsNullOrEmpty(filter) ? string.Format(" sMaLop LIKE '%{0}%'", txtMaLopHS.Text) : string.Format(" AND sMaLop LIKE '%{0}%'", txtMaLopHS.Text);

            }
            if (!string.IsNullOrEmpty(txtDiaChi.Text))
            {
                //  filter += txtDiaChi.Text;
                filter += string.IsNullOrEmpty(filter) ? string.Format(" sDiaChi LIKE '%{0}%'", txtDiaChi.Text) : string.Format(" AND sDiaChi LIKE '%{0}%'", txtDiaChi.Text);

            }
            if (!rdbNam.Checked && !rdbNu.Checked)
            {
            }
            // = rdbNam.Checked;
           showAllHocSinh(filter);
        }
    }
}
