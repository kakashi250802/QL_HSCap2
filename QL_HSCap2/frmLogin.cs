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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public Boolean check()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return false;

            }
            return true;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("sp_LoginUser", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                        Cmd.Parameters.AddWithValue("@password", txtPass.Text);
                        Cnn.Open();
                        SqlDataReader dta = Cmd.ExecuteReader();
                        if (dta.Read()==true)
                        {
                            MessageBox.Show("Đăng nhập thành công!!");
                            
                            TrangChu frm = (TrangChu)Program.FindOpenedForm("TrangChu");
                            if (frm == null)
                            {
                                frm = new TrangChu();
                                frm.Show();
                                
                            }
                            else
                            {
                                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Đăng nhập thất bại. Vui lòng kiểm tra lại!!");
                        }
                        Cnn.Close();

                    }
                }
            }
        }

        private void linkQuenPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            FrmDangKy frmdk = (FrmDangKy)Program.FindOpenedForm("FrmDangKy");
            if (frmdk == null)
            {
                frmdk = new FrmDangKy();
                frmdk.Show();
            }
            else
            {
                MessageBox.Show("Trang này vẫn đang mở", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
