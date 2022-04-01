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
    public partial class FrmDangKy : Form
    {
        public FrmDangKy()
        {
            InitializeComponent();
        }

        public Boolean check()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Họ Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtRepassword.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập lại mật khẩu password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepassword.Focus();
                return false;

            }
            if (txtPassword.Text != txtRepassword.Text)
            {
                MessageBox.Show("Mật Khẩu Bạn Không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRepassword.Focus();
                return false;

            }
            return true;

        }
        public void resetForm()
        {
            txtHoTen.Text = txtPassword.Text = txtRepassword.Text = txtHoTen.Text = "";
        }
        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (check())
            {
                try { 
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand Cmd = new SqlCommand("sp_InsertUSer", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;

                        Cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        Cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                        Cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);

                        Cnn.Open();
                        Cmd.ExecuteNonQuery();
                        Cnn.Close();
                        MessageBox.Show("Đăng ký tài Khoản thành công!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetForm();
                    }

                }
                }catch(Exception ex)
                {
                    MessageBox.Show("Tài Khoản Đã Tồn Tại Trên Hệ Thống!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void linkquenpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgotPass frmfg = (frmForgotPass)Program.FindOpenedForm("frmForgotPass");
            if (frmfg == null)
            {
                frmfg = new frmForgotPass();
                frmfg.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
