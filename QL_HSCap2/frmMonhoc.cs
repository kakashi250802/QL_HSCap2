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
    public partial class frmMonhoc : Form
    {
        public frmMonhoc()
        {
            InitializeComponent();
        }

        private void frmMonhoc_Load(object sender, EventArgs e)
        {
            hienMon();
        }

        private void hienMon(string search = "")
        {
            using (DataTable tbl_MonHoc = getMon())
            {
                DataView dvNhomMon = new DataView(tbl_MonHoc);
                if (!string.IsNullOrEmpty(search))
                    dvNhomMon.RowFilter = search;
                dgrMon.AutoGenerateColumns = false;
                dgrMon.DataSource = dvNhomMon;

                btnSua.Enabled = btnXoa.Enabled = (dgrMon.Rows.Count > 0);
            }

        }

        private DataTable getMon()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("Mon_Get", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tbl_MonHoc");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaMon.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập mã môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaMon.Focus();
            }

            else if (string.IsNullOrEmpty(txtTenMon.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập tên môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMon.Focus();
            }
            else if (string.IsNullOrEmpty(txtNhomMon.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Nhóm Môn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhomMon.Focus();
            }
            else
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    if (btnThem.Text == "Thêm")
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_InsertMonHoc", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maMon", txtMaMon.Text);
                            Cmd.Parameters.AddWithValue("@tenMon", txtTenMon.Text);
                            Cmd.Parameters.AddWithValue("@maNhomMon", txtNhomMon.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienMon();
                        }
                    }
                    else
                    {
                        using (SqlCommand Cmd = new SqlCommand("sp_UpdateMonHoc", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;

                            Cmd.Parameters.AddWithValue("@maMon", txtMaMon.Text);
                            Cmd.Parameters.AddWithValue("@tenMon", txtTenMon.Text);
                            Cmd.Parameters.AddWithValue("@maNhomMon", txtNhomMon.Text);

                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();

                            hienMon();

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
                DataView dvMon = (DataView)dgrMon.DataSource;
                DataRowView drvMon = dvMon[dgrMon.CurrentRow.Index];
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;

                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("sp_DeleteMonHoc", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@maMon", drvMon["sMaMon"]);

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();

                        hienMon();
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
            DataView dvMon = (DataView)dgrMon.DataSource;
            DataRowView drvMon = dvMon[dgrMon.CurrentRow.Index];

            txtMaMon.Text = Convert.ToString(drvMon["sMaMon"]);
            txtTenMon.Text = Convert.ToString(drvMon["sTenMon"]);
            //txtTenMon.Text = Convert.ToString(drvMon["sTenNhomMon"]);
            txtNhomMon.Text = Convert.ToString(drvMon["sMaNhomMon"]);

            btnThem.Text = "Cập nhật";

            btnThem.Tag = drvMon["sMaNhomMon"].ToString();
            btnSua.Enabled = btnXoa.Enabled = false;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string search = "";
            int check = 0;
            if (!string.IsNullOrEmpty(txtMaMon.Text.Trim()))
            {
                check = 1;
                search += string.Format("sMaMon LIKE '%{0}%'", txtMaMon.Text);
            }

            if (!string.IsNullOrEmpty(txtTenMon.Text.Trim()))
            {
                if (check == 1) search += string.Format(" AND ");
                check = 1;
                search += string.Format("sTenMon LIKE '%{0}%'", txtTenMon.Text);
            }

            if (!string.IsNullOrEmpty(txtNhomMon.Text.Trim()))
            {
                if (check == 1) search += string.Format(" AND ");
                search += string.Format("sMaNhomMon LIKE '%{0}%'", txtNhomMon.Text);
            }

            hienMon(search);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtMaMon.Text = txtTenMon.Text = txtNhomMon.Text = "";
            btnSua.Enabled = btnXoa.Enabled = true;
            btnThem.Text = "Thêm";
            frmMonhoc_Load(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            
        }
    }
}
