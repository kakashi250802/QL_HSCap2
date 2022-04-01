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
    public partial class frmDiem : Form
    {
        public frmDiem()
        {
            InitializeComponent();
        }

        private void frmDiem_Load(object sender, EventArgs e)
        {
            hienDiem();
        }
        private void hienDiem(string search = "")
        {
            using (DataTable tbl_Diem = getDiem())
            {
                DataView dvDiem = new DataView(tbl_Diem);
                if (!string.IsNullOrEmpty(search))
                    dvDiem.RowFilter = search;
                gridviewDiemSo.AutoGenerateColumns = false;
                gridviewDiemSo.DataSource = dvDiem;
                btnSua.Enabled = btnXoa.Enabled = (gridviewDiemSo.Rows.Count > 0);
            }

        }
        private DataTable getDiem()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("sp_getDiem", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tbl_Diem");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }
        public Boolean check() {
            if (string.IsNullOrEmpty(txtMaHS.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập mã HS!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHS.Focus();
                return false;

            }

            else if (string.IsNullOrEmpty(txtMaDiem.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên Mã loại điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaDiem.Focus();
                return false;

            }
            else if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên Mã Môn Học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaMon.Focus();
                return false;

            }
            else if (string.IsNullOrEmpty(txtNamHoc.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập năm học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNamHoc.Focus();
                return false;
            }
            else if (string.IsNullOrEmpty(txtHocKy.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Học Kỳ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHocKy.Focus();
                return false;
            }
            return true;
    }
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            if (check())
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    if (btnThem.Text == "Thêm Mới")
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_insertDiem", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@sMaHS", txtMaHS.Text);
                            Cmd.Parameters.AddWithValue("@sMaMon", txtMaMon.Text);
                            Cmd.Parameters.AddWithValue("@sMaDiem", txtMaDiem.Text);
                            Cmd.Parameters.AddWithValue("@fDiem", txtDiem.Text);
                            Cmd.Parameters.AddWithValue("@sNamHoc", txtNamHoc.Text);
                            Cmd.Parameters.AddWithValue("@sHocKi", txtHocKy.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();
                            hienDiem();
                        }
                    }
                    else
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_updateDiem", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@sMaHS", txtMaHS.Text);
                            Cmd.Parameters.AddWithValue("@sMaMon", txtMaMon.Text);
                            Cmd.Parameters.AddWithValue("@sMaDiem", txtMaDiem.Text);
                            Cmd.Parameters.AddWithValue("@fDiem", txtDiem.Text);
                            Cmd.Parameters.AddWithValue("@sNamHoc", txtNamHoc.Text);
                            Cmd.Parameters.AddWithValue("@sHocKi", txtHocKy.Text);
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienDiem();
                            resetForm();
                            btnThem.Text = "Thêm Mới";
                        }
                    }
                }
            }
        }
        private void chuyenTrangThaiSuaDiem(DataRowView drvDiem)
        {
            txtMaHS.Text = drvDiem["sMaHS"].ToString();
            txtMaMon.Text = drvDiem["sMaMon"].ToString();
            txtMaDiem.Text = drvDiem["sMaDiem"].ToString();
            txtDiem.Text = drvDiem["fDiem"].ToString();
            txtNamHoc.Text = drvDiem["sNamHoc"].ToString();
            txtHocKy.Text = drvDiem["sHocKi"].ToString();
            btnThem.Text = "Cập Nhật";
            txtMaMon.Enabled= txtMaDiem.Enabled=
            txtMaHS.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTimKiem.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvDiem = (DataView)gridviewDiemSo.DataSource;
            DataRowView drvDiem = dvDiem[gridviewDiemSo.CurrentRow.Index];
            chuyenTrangThaiSuaDiem(drvDiem);
        }
        public void resetForm()
        {
            txtMaMon.Enabled = txtMaDiem.Enabled =
            txtMaHS.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTimKiem.Enabled = true;
            txtMaHS.Text = txtMaMon.Text = txtMaDiem.Text = txtDiem.Text =
            txtNamHoc.Text = txtHocKy.Text = "";
            btnThem.Text = "Thêm Mới";
        }
        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
