using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_HSCap2
{
    public partial class frmHocSinh : Form
    {
        public frmHocSinh()
        {
            InitializeComponent();
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
            hienHocSinh();
        }
        private void btnThemHS_Click(object sender, EventArgs e)
        {
            if (checkDataHS())
            {
                string procName = (btnThemHS.Text == "Cập Nhật") ? "update" : "insert";

                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    if (procName == "insert")
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_InsertHocSinh", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cnn.Open();
                            Cmd.Parameters.AddWithValue("@maHS", txtMaHS.Text);
                            Cmd.Parameters.AddWithValue("@tenHS", txtTenHS.Text);
                            Cmd.Parameters.AddWithValue("@gtHS", rdbNam.Checked);
                            Cmd.Parameters.AddWithValue("@ngaySinh", DateTime.ParseExact(mktNgaySinh.Text, "ddMMyyyy", null));
                            Cmd.Parameters.AddWithValue("@sdt", mktSDTPhuHuynh.Text.Trim());
                            Cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                            Cmd.Parameters.AddWithValue("@maLop", txtMaLopHS.Text);
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();
                        }
                        MessageBox.Show("Thêm Học sinh mới mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hienHocSinh();
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Bạn muốn cập nhập thông tin học sinh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult == DialogResult.Yes)
                        {
                            using (SqlCommand Cmd = new SqlCommand("sp_UpdateHocSinh", Cnn))
                            {
                                Cmd.CommandType = CommandType.StoredProcedure;
                                Cnn.Open();
                                Cmd.Parameters.AddWithValue("@maHS", txtMaHS.Text);
                                Cmd.Parameters.AddWithValue("@tenHS", txtTenHS.Text);
                                Cmd.Parameters.AddWithValue("@gtHS", rdbNam.Checked);
                                Cmd.Parameters.AddWithValue("@ngaySinh", DateTime.ParseExact(mktNgaySinh.Text, "ddMMyyyy", null));
                                Cmd.Parameters.AddWithValue("@sdt", mktSDTPhuHuynh.Text.Trim());
                                Cmd.Parameters.AddWithValue("@diaChi", txtDiaChi.Text);
                                Cmd.Parameters.AddWithValue("@maLop", txtMaLopHS.Text);
                                Cmd.ExecuteNonQuery();
                                Cnn.Close();
                            }
                            MessageBox.Show("cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            hienHocSinh();
                        }
                        else
                        {
                            resetFormHocSinh();
                        }
                    }
                }

            }
        }

        private void frmHocSinh_Load(object sender, EventArgs e)
        {
            hienHocSinh();
            frmLogin frm = new frmLogin();

        }
        private void hienHocSinh(string search = "")
        {
            using (DataTable tbl_HocSinh = getHocSinh())
            {
                DataView dvHS = new DataView(tbl_HocSinh);
                if (!string.IsNullOrEmpty(search))
                    dvHS.RowFilter = search;
                gridviewHS.AutoGenerateColumns = false;
                gridviewHS.DataSource = dvHS;

                btnXoaHS.Enabled = btnSuaHS.Enabled = btnTimKiemHS.Enabled = (gridviewHS.Rows.Count > 0);
            }

        }
        private DataTable getHocSinh()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("HocSinhGet", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tbl_HocSinh");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }
        private void chuyenTrangThaiSuaHocsinh(DataRowView drvHS)
        {
            txtMaHS.Text = drvHS["sMaHS"].ToString();
            txtTenHS.Text = drvHS["sTenHS"].ToString();
            if (drvHS["iGioiTinh"].ToString() == "Nam")
            {
                rdbNam.Checked = true;
            }
            else
            {
                rdbNu.Checked = true;
            }
            txtMaLopHS.Text = drvHS["sMaLop"].ToString();
            mktNgaySinh.Text = drvHS["dNgaySinh"].ToString();
            txtDiaChi.Text = drvHS["sDiaChi"].ToString();
            mktSDTPhuHuynh.Text = drvHS["sSDTPhuHuynh"].ToString();

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
                filter += string.IsNullOrEmpty(filter) ? string.Format(" sTenHS LIKE '%{0}%'", txtTenHS.Text) : string.Format(" AND sTenHS LIKE '%{0}%'", txtTenHS.Text);

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
            hienHocSinh(filter);
        }

        private void btnXoaHS_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có muốn xóa", "Có", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.No) return;
            else
            {
                try
                {

                DataView dvLopHoc = (DataView)gridviewHS.DataSource;
                DataRowView drvLopHoc = dvLopHoc[gridviewHS.CurrentRow.Index];
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;

                    using (SqlConnection Cnn = new SqlConnection(connectionString))
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_DeleteHocSinh", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.Parameters.AddWithValue("@maHS", drvLopHoc["sMaHS"]);
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();
                        }
                    }
                } catch (Exception ex){

                    if (ex.Message.Contains("REFERENCE"))
                        MessageBox.Show("Học sinh có liên kết", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Lỗi kỹ thuật", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                hienHocSinh();
                }
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataView dvLopHoc = (DataView)gridviewHS.DataSource;
            DataRowView drvLopHoc = dvLopHoc[gridviewHS.CurrentRow.Index];

            string ma = (string)drvLopHoc["sMaHS"];


            frmBaoCaocs f = new frmBaoCaocs();
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;

            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("sp_DiemTheoHS", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@maHS", ma);
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable();
                        Da.Fill(tbl);
                        rptDiemSinhVien r = new rptDiemSinhVien();
                        r.SetDataSource(tbl);
                        f.crystalReportViewer1.ReportSource = r;
                        f.ShowDialog();
                    }
                }
            }
     

        }
    }
    }
