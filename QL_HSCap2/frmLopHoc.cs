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
    public partial class frmLopHoc : Form
    {
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmLopHoc_Load(object sender, EventArgs e)
        {
            hienLopHoc();
        }

        private void hienLopHoc(string search = "")
        {
            using (DataTable tbl_LopHoc = getLopHoc())
            {
                DataView dvNhomMon = new DataView(tbl_LopHoc);
                if (!string.IsNullOrEmpty(search))
                    dvNhomMon.RowFilter = search;
                dgrLopHoc.AutoGenerateColumns = false;
                dgrLopHoc.DataSource = dvNhomMon;

                btnSua.Enabled = btnXoa.Enabled = (dgrLopHoc.Rows.Count > 0);
            }

        }
        private DataTable getLopHoc()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("LopHoc_Get", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tbl_LopHoc");
                        Da.Fill(tbl);
                        return tbl;
                    }   
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập mã LỚP!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLop.Focus();
            }

            else if (string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên Lớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLop.Focus();
            }
            else if (string.IsNullOrEmpty(txtKhoaHoc.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Khóa Học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKhoaHoc.Focus();
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    if (btnThem.Text == "Thêm")
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_InsertLopHoc", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maLop", txtMaLop.Text);
                            Cmd.Parameters.AddWithValue("@tenLop", txtTenLop.Text);
                            Cmd.Parameters.AddWithValue("@khoahoc", txtKhoaHoc.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienLopHoc();
                        }
                    }
                    else
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_UpdateLopHoc", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maLop", txtMaLop.Text);
                            Cmd.Parameters.AddWithValue("@tenLop", txtTenLop.Text);
                            Cmd.Parameters.AddWithValue("@khoahoc", txtKhoaHoc.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienLopHoc();

                            btnThem.Text = "Thêm";
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có muốn xóa", "Có", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.No) return;

            try
            {
                DataView dvLopHoc = (DataView)dgrLopHoc.DataSource;
                DataRowView drvLopHoc = dvLopHoc[dgrLopHoc.CurrentRow.Index];
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;

                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("sp_DeleteLopHoc", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@maLop", drvLopHoc["sMaLop"]);

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                        hienLopHoc();
                    }
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("REFERENCE"))
                    MessageBox.Show("Môn học có liên kết", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lỗi kỹ thuật", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvMon = (DataView)dgrLopHoc.DataSource;
            DataRowView drvMon = dvMon[dgrLopHoc.CurrentRow.Index];

            txtMaLop.Text = Convert.ToString(drvMon["sMaLop"]);
            txtTenLop.Text = Convert.ToString(drvMon["sTenLop"]);
            txtKhoaHoc.Text = Convert.ToString(drvMon["sKhoaHoc"]);

            btnThem.Text = "Cập nhật";

            btnThem.Tag = drvMon["sMaLop"].ToString();
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string search = "";
            int check = 0;
            if (!string.IsNullOrEmpty(txtMaLop.Text.Trim()))
            {
                check = 1;
                search += string.Format("sMaLop LIKE '%{0}%'", txtMaLop.Text);
            }

            if (!string.IsNullOrEmpty(txtTenLop.Text.Trim()))
            {
                if (check == 1) search += string.Format(" AND ");
                check = 1;
                search += string.Format("sTenLop LIKE '%{0}%'", txtTenLop.Text);
            }

            if (!string.IsNullOrEmpty(txtKhoaHoc.Text.Trim()))
            {
                if (check == 1) search += string.Format(" AND ");
                search += string.Format("sKhoaHoc LIKE '%{0}%'", txtKhoaHoc.Text);
            }

            hienLopHoc(search);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaLop.Text = txtTenLop.Text = txtKhoaHoc.Text = "";
            btnSua.Enabled = btnXoa.Enabled = true;
            btnThem.Text = "Thêm";
            frmLopHoc_Load(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DataView dvLopHoc = (DataView)dgrLopHoc.DataSource;
            DataRowView drvLopHoc = dvLopHoc[dgrLopHoc.CurrentRow.Index];

            string ma = (string)drvLopHoc["sMaLop"];

            string search = string.Format("{0} = '{1}'", "{tbl_LopHoc.sMaLop}", ma);
            
            frmBaoCaocs frCrytal = new frmBaoCaocs();
            frCrytal.Show();
            frCrytal.ShowReport("dshocsinh.rpt", search, "DANH SÁCH LỚP");
            frCrytal.Activate();
        }
    }
}
