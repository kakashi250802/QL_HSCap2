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
    public partial class frmForgotPass : Form
    {
        public frmForgotPass()
        {
            InitializeComponent();
        }
        public bool check()
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Họ Tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Bạn Chưa Nhập Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
                return false;
            }
            return true;
        }
        public bool checkData()
        {

                string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("sp_SelectUser", Cnn))
                    {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    Cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                        {
                            DataTable tbl = new DataTable("tbl_User");
                            Da.Fill(tbl);
                            if(tbl.Rows.Count>0)
                            return true;
                        }
                    }
                }

            return false;
        }
        public void resetForm()
        {
            txtHoTen.Text = txtUsername.Text = "";
        }
        private void btnForgotPass_Click(object sender, EventArgs e)
        {
            if (check()&& checkData())
            {

                    string connectionString = ConfigurationManager.ConnectionStrings["QL_DiemHSCap2"].ConnectionString;
                    using (SqlConnection Cnn = new SqlConnection(connectionString))
                    {
                      using (SqlCommand Cmd = new SqlCommand("sp_ResetPassword", Cnn))
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            Cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                            Cnn.Open();
                            Cmd.ExecuteNonQuery();
                            Cnn.Close();
                            MessageBox.Show("Mật khẩu đã được đổi thành 12345678!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            resetForm();
                        
                    }
                    }
            }
            else
            {
                            MessageBox.Show("Không Tìm Thấy Tài Khoản có vui lòng kiểm tra lại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        }
    }
