
namespace QL_HSCap2
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.LinkLabel linkQuenPass;
            this.username = new MaterialSkin.Controls.MaterialLabel();
            this.password = new MaterialSkin.Controls.MaterialLabel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDangKy = new MaterialSkin.Controls.MaterialRaisedButton();
            linkQuenPass = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.Depth = 0;
            this.username.Font = new System.Drawing.Font("Roboto", 11F);
            this.username.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.username.Location = new System.Drawing.Point(33, 48);
            this.username.MouseState = MaterialSkin.MouseState.HOVER;
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(79, 19);
            this.username.TabIndex = 0;
            this.username.Text = "username:";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Depth = 0;
            this.password.Font = new System.Drawing.Font("Roboto", 11F);
            this.password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.password.Location = new System.Drawing.Point(33, 92);
            this.password.MouseState = MaterialSkin.MouseState.HOVER;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(78, 19);
            this.password.TabIndex = 1;
            this.password.Text = "password:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(118, 47);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(185, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(118, 91);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(185, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.AutoSize = true;
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Depth = 0;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(37, 150);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Primary = true;
            this.btnLogin.Size = new System.Drawing.Size(99, 36);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.AutoSize = true;
            this.btnDangKy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDangKy.Depth = 0;
            this.btnDangKy.Icon = null;
            this.btnDangKy.Location = new System.Drawing.Point(224, 150);
            this.btnDangKy.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Primary = true;
            this.btnDangKy.Size = new System.Drawing.Size(79, 36);
            this.btnDangKy.TabIndex = 5;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // linkQuenPass
            // 
            linkQuenPass.AutoSize = true;
            linkQuenPass.Location = new System.Drawing.Point(147, 221);
            linkQuenPass.Name = "linkQuenPass";
            linkQuenPass.Size = new System.Drawing.Size(80, 13);
            linkQuenPass.TabIndex = 7;
            linkQuenPass.TabStop = true;
            linkQuenPass.Text = "Quên mật khẩu";
            linkQuenPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkQuenPass_LinkClicked);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 263);
            this.Controls.Add(linkQuenPass);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel username;
        private MaterialSkin.Controls.MaterialLabel password;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPass;
        private MaterialSkin.Controls.MaterialRaisedButton btnLogin;
        private MaterialSkin.Controls.MaterialRaisedButton btnDangKy;
    }
}