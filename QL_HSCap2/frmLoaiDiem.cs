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
    public partial class frmLoaiDiem : Form
    {
        public frmLoaiDiem()
        {
            InitializeComponent();
        }

        private void frmLoaiDiem_Load(object sender, EventArgs e)
        {
            hienLoaiDiem();
        }
        private void hienLoaiDiem(string search = "")
        {
            using (DataTable tbl_LoaiDiem = getLoaiDiem())
            {
                DataView dvLoaiDiem = new DataView(tbl_LoaiDiem);
                if (!string.IsNullOrEmpty(search))
                    dvLoaiDiem.RowFilter = search;
                gridviewLoaiDiem.AutoGenerateColumns = false;
                gridviewLoaiDiem.DataSource = dvLoaiDiem;

                btnSuaLoaiDiem.Enabled = btnXoaLoaiDiem.Enabled = (gridviewLoaiDiem.Rows.Count > 0);
            }

        }
        private DataTable getLoaiDiem()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("sp_GetAllLoaiDiem", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tbl_LoaiDiem");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }
        public Boolean check()
        {
            if (string.IsNullOrEmpty(txtMaLoaiDiem.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập mã Loại Điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoaiDiem.Focus();
                return false;

            }

            else if (string.IsNullOrEmpty(txtTenLoaiDiem.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên loại điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoaiDiem.Focus();
                return false;

            }
            else if (string.IsNullOrEmpty(txtHeSoDiem.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Hệ số điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHeSoDiem.Focus();
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
                        using (SqlCommand Cmd = new SqlCommand("sp_InsertLoaiDiem", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maDiem", txtMaLoaiDiem.Text);
                            Cmd.Parameters.AddWithValue("@tenDiem", txtTenLoaiDiem.Text);
                            Cmd.Parameters.AddWithValue("@heSo", txtHeSoDiem.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();
                            hienLoaiDiem();
                        }
                    }
                    else
                 {
                using (SqlCommand Cmd = new SqlCommand("sp_UpdateLoaiDiem", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maDiem", txtMaLoaiDiem.Text);
                            Cmd.Parameters.AddWithValue("@tenDiem", txtTenLoaiDiem.Text);
                            Cmd.Parameters.AddWithValue("@heSo", txtHeSoDiem.Text);
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();
                            hienLoaiDiem();
                    
                    }
                }
                }

            }
        }
        private void chuyenTrangThaiSuaLoaiDiem(DataRowView drvLDiem)
        {
            txtMaLoaiDiem.Text = drvLDiem["sMaDiem"].ToString();
            txtTenLoaiDiem.Text = drvLDiem["sTenDiem"].ToString();
            txtHeSoDiem.Text = drvLDiem["sHeSo"].ToString();
            btnThem.Text = "Cập Nhật";
            txtMaLoaiDiem.Enabled = btnSuaLoaiDiem.Enabled = btnXoaLoaiDiem.Enabled = btnTimKiemLoaiDiem.Enabled = false;
        }
        private void btnSuaLoaiDiem_Click(object sender, EventArgs e)
        {
            DataView dvLDiem = (DataView)gridviewLoaiDiem.DataSource;
            DataRowView drvLDiem = dvLDiem[gridviewLoaiDiem.CurrentRow.Index];
            chuyenTrangThaiSuaLoaiDiem(drvLDiem);
        }
        private void resetFormLoaiDiem()
        {
            txtMaLoaiDiem.Text = txtTenLoaiDiem.Text = txtHeSoDiem.Text  = "";
            btnThem.Text = "Thêm mới";
            txtMaLoaiDiem.Enabled = btnSuaLoaiDiem.Enabled = btnXoaLoaiDiem.Enabled = btnTimKiemLoaiDiem.Enabled = true;

        }

        private void btnBoQuaLoaiDiem_Click(object sender, EventArgs e)
        {
            resetFormLoaiDiem();
        }

        private void btnXoaLoaiDiem_Click(object sender, EventArgs e)
        {

            
            DialogResult re = MessageBox.Show("Bạn có muốn xóa loại điểm", "Có", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.No) return;

            try
            {
                DataView dvLDiem = (DataView)gridviewLoaiDiem.DataSource;
                DataRowView drvLDiem = dvLDiem[gridviewLoaiDiem.CurrentRow.Index];
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;

                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("sp_DeleteLoaiDiem", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@maDiem", drvLDiem["sMaDiem"]);

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                        hienLoaiDiem();
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
    }
}

