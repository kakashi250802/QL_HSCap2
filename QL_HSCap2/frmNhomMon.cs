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
    public partial class frmNhomMon : Form
    {
        public frmNhomMon()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="search">Điều kiện lọc</param>
        private void hienNhomMon(string search="")
        {
            using (DataTable tbl_NhomMonHoc = getNhomMon())
            {
                DataView dvNhomMon = new DataView(tbl_NhomMonHoc);
                if (!string.IsNullOrEmpty(search))
                    dvNhomMon.RowFilter = search;
                dgrNhomMon.AutoGenerateColumns = false;
                dgrNhomMon.DataSource = dvNhomMon;

                btnSua.Enabled = btnXoa.Enabled = (dgrNhomMon.Rows.Count > 0);
            }

        }

        private DataTable getNhomMon()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("NhomMon_Get", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tbl_NhomMonHoc");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }

        private void frmNhomMon_Load(object sender, EventArgs e)
        {
            hienNhomMon();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhom.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập mã nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNhom.Focus();
            }

            else if (string.IsNullOrEmpty(txtTenNhom.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên nhóm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNhom.Focus();
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    if (btnThem.Text == "Thêm")
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_InsertNhomMonHoc", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maNhomMon", txtMaNhom.Text);
                            Cmd.Parameters.AddWithValue("@tenNhomMon", txtTenNhom.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienNhomMon();
                        }
                    }
                    else
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_UpdateNhomMonHoc", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maNhomMon", txtMaNhom.Text);
                            Cmd.Parameters.AddWithValue("@tenNhomMon", txtTenNhom.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienNhomMon();

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
                DataView dvNhomMon = (DataView)dgrNhomMon.DataSource;
                DataRowView drvNhomMon = dvNhomMon[dgrNhomMon.CurrentRow.Index];
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;

                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("sp_DeleteNhomMonHoc", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@maNhomMon", drvNhomMon["sMaNhomMon"]);

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                        hienNhomMon();
                    }
                }
            }
            catch (Exception ex)
            {

                if (ex.Message.Contains("REFERENCE"))
                    MessageBox.Show("Lớp có học sinh học", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lỗi kỹ thuật", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvNhomMon = (DataView)dgrNhomMon.DataSource;
            DataRowView drvNhomMon = dvNhomMon[dgrNhomMon.CurrentRow.Index];

            txtMaNhom.Text = Convert.ToString(drvNhomMon["sMaNhomMon"]);
            txtTenNhom.Text = Convert.ToString(drvNhomMon["sTenNhomMon"]);

            btnThem.Text = "Cập nhật";

            btnThem.Tag = drvNhomMon["sMaNhomMon"].ToString();
            btnSua.Enabled = btnXoa.Enabled = false;

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string search = "";
            int check = 0;
            if (!string.IsNullOrEmpty(txtMaNhom.Text.Trim()))
            {
                check = 1;
                search += string.Format("sMaNhomMon LIKE '%{0}%'", txtMaNhom.Text);
            }

            if (!string.IsNullOrEmpty(txtTenNhom.Text.Trim()))
            {
                if (check == 1) search += string.Format(" AND ");
                search += string.Format("sTenNhomMon LIKE '%{0}%'", txtTenNhom.Text);
            }
            hienNhomMon(search);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaNhom.Text = txtTenNhom.Text = "";
            frmNhomMon_Load(sender,e);
        }
    }
}
