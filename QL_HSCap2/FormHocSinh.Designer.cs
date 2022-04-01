namespace BTL_FORM_MDI
{
    partial class FormHocSinh
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
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.tlblDiaChi = new MaterialSkin.Controls.MaterialLabel();
            this.txtMaLopHS = new System.Windows.Forms.TextBox();
            this.lblMaLopHS = new MaterialSkin.Controls.MaterialLabel();
            this.mktSDTPhuHuynh = new System.Windows.Forms.MaskedTextBox();
            this.lblsdtph = new MaterialSkin.Controls.MaterialLabel();
            this.mktNgaySinh = new System.Windows.Forms.MaskedTextBox();
            this.lblNgaySinh = new MaterialSkin.Controls.MaterialLabel();
            this.rdbNu = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdbNam = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblGioiTinh = new MaterialSkin.Controls.MaterialLabel();
            this.txtTenHS = new System.Windows.Forms.TextBox();
            this.lblTenHS = new MaterialSkin.Controls.MaterialLabel();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.lblmaHS = new MaterialSkin.Controls.MaterialLabel();
            this.btnThemHS = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnSuaHS = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnXoaHS = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnTimKiemHS = new MaterialSkin.Controls.MaterialFlatButton();
            this.btnBoQuaHS = new MaterialSkin.Controls.MaterialFlatButton();
            this.gridviewHS = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewHS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(173, 201);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(613, 20);
            this.txtDiaChi.TabIndex = 50;
            this.txtDiaChi.UseWaitCursor = true;
            // 
            // tlblDiaChi
            // 
            this.tlblDiaChi.AutoSize = true;
            this.tlblDiaChi.Depth = 0;
            this.tlblDiaChi.Font = new System.Drawing.Font("Roboto", 11F);
            this.tlblDiaChi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tlblDiaChi.Location = new System.Drawing.Point(97, 201);
            this.tlblDiaChi.MouseState = MaterialSkin.MouseState.HOVER;
            this.tlblDiaChi.Name = "tlblDiaChi";
            this.tlblDiaChi.Size = new System.Drawing.Size(59, 19);
            this.tlblDiaChi.TabIndex = 49;
            this.tlblDiaChi.Text = "Địa chỉ:";
            this.tlblDiaChi.UseWaitCursor = true;
            // 
            // txtMaLopHS
            // 
            this.txtMaLopHS.Location = new System.Drawing.Point(583, 163);
            this.txtMaLopHS.Name = "txtMaLopHS";
            this.txtMaLopHS.Size = new System.Drawing.Size(203, 20);
            this.txtMaLopHS.TabIndex = 47;
            this.txtMaLopHS.UseWaitCursor = true;
            // 
            // lblMaLopHS
            // 
            this.lblMaLopHS.AutoSize = true;
            this.lblMaLopHS.Depth = 0;
            this.lblMaLopHS.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblMaLopHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblMaLopHS.Location = new System.Drawing.Point(479, 164);
            this.lblMaLopHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblMaLopHS.Name = "lblMaLopHS";
            this.lblMaLopHS.Size = new System.Drawing.Size(88, 19);
            this.lblMaLopHS.TabIndex = 46;
            this.lblMaLopHS.Text = "Mã lớp học:";
            this.lblMaLopHS.UseWaitCursor = true;
            // 
            // mktSDTPhuHuynh
            // 
            this.mktSDTPhuHuynh.Location = new System.Drawing.Point(583, 122);
            this.mktSDTPhuHuynh.Mask = "(999) 000-0000";
            this.mktSDTPhuHuynh.Name = "mktSDTPhuHuynh";
            this.mktSDTPhuHuynh.Size = new System.Drawing.Size(203, 20);
            this.mktSDTPhuHuynh.TabIndex = 45;
            this.mktSDTPhuHuynh.UseWaitCursor = true;
            // 
            // lblsdtph
            // 
            this.lblsdtph.AutoSize = true;
            this.lblsdtph.Depth = 0;
            this.lblsdtph.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblsdtph.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblsdtph.Location = new System.Drawing.Point(448, 123);
            this.lblsdtph.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblsdtph.Name = "lblsdtph";
            this.lblsdtph.Size = new System.Drawing.Size(112, 19);
            this.lblsdtph.TabIndex = 44;
            this.lblsdtph.Text = "SĐT phụ huynh:";
            this.lblsdtph.UseWaitCursor = true;
            // 
            // mktNgaySinh
            // 
            this.mktNgaySinh.Location = new System.Drawing.Point(583, 83);
            this.mktNgaySinh.Mask = "00/00/0000";
            this.mktNgaySinh.Name = "mktNgaySinh";
            this.mktNgaySinh.Size = new System.Drawing.Size(203, 20);
            this.mktNgaySinh.TabIndex = 43;
            this.mktNgaySinh.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.mktNgaySinh.UseWaitCursor = true;
            this.mktNgaySinh.ValidatingType = typeof(System.DateTime);
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Depth = 0;
            this.lblNgaySinh.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblNgaySinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNgaySinh.Location = new System.Drawing.Point(487, 84);
            this.lblNgaySinh.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(79, 19);
            this.lblNgaySinh.TabIndex = 42;
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblNgaySinh.UseWaitCursor = true;
            // 
            // rdbNu
            // 
            this.rdbNu.AutoSize = true;
            this.rdbNu.Depth = 0;
            this.rdbNu.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdbNu.Location = new System.Drawing.Point(273, 154);
            this.rdbNu.Margin = new System.Windows.Forms.Padding(0);
            this.rdbNu.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdbNu.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdbNu.Name = "rdbNu";
            this.rdbNu.Ripple = true;
            this.rdbNu.Size = new System.Drawing.Size(47, 30);
            this.rdbNu.TabIndex = 41;
            this.rdbNu.TabStop = true;
            this.rdbNu.Text = "Nữ";
            this.rdbNu.UseVisualStyleBackColor = true;
            this.rdbNu.UseWaitCursor = true;
            // 
            // rdbNam
            // 
            this.rdbNam.AutoSize = true;
            this.rdbNam.Depth = 0;
            this.rdbNam.Font = new System.Drawing.Font("Roboto", 10F);
            this.rdbNam.Location = new System.Drawing.Point(173, 154);
            this.rdbNam.Margin = new System.Windows.Forms.Padding(0);
            this.rdbNam.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdbNam.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdbNam.Name = "rdbNam";
            this.rdbNam.Ripple = true;
            this.rdbNam.Size = new System.Drawing.Size(58, 30);
            this.rdbNam.TabIndex = 40;
            this.rdbNam.TabStop = true;
            this.rdbNam.Text = "Nam";
            this.rdbNam.UseVisualStyleBackColor = true;
            this.rdbNam.UseWaitCursor = true;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Depth = 0;
            this.lblGioiTinh.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblGioiTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblGioiTinh.Location = new System.Drawing.Point(87, 164);
            this.lblGioiTinh.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(69, 19);
            this.lblGioiTinh.TabIndex = 39;
            this.lblGioiTinh.Text = "Giới tính:";
            this.lblGioiTinh.UseWaitCursor = true;
            // 
            // txtTenHS
            // 
            this.txtTenHS.Location = new System.Drawing.Point(173, 122);
            this.txtTenHS.Name = "txtTenHS";
            this.txtTenHS.Size = new System.Drawing.Size(198, 20);
            this.txtTenHS.TabIndex = 38;
            this.txtTenHS.UseWaitCursor = true;
            // 
            // lblTenHS
            // 
            this.lblTenHS.AutoSize = true;
            this.lblTenHS.Depth = 0;
            this.lblTenHS.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTenHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTenHS.Location = new System.Drawing.Point(59, 122);
            this.lblTenHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTenHS.Name = "lblTenHS";
            this.lblTenHS.Size = new System.Drawing.Size(99, 19);
            this.lblTenHS.TabIndex = 37;
            this.lblTenHS.Text = "Tên học sinh:";
            this.lblTenHS.UseWaitCursor = true;
            // 
            // txtMaHS
            // 
            this.txtMaHS.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txtMaHS.Location = new System.Drawing.Point(173, 84);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.Size = new System.Drawing.Size(198, 20);
            this.txtMaHS.TabIndex = 36;
            this.txtMaHS.UseWaitCursor = true;
            // 
            // lblmaHS
            // 
            this.lblmaHS.AutoSize = true;
            this.lblmaHS.Depth = 0;
            this.lblmaHS.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblmaHS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblmaHS.Location = new System.Drawing.Point(59, 84);
            this.lblmaHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblmaHS.Name = "lblmaHS";
            this.lblmaHS.Size = new System.Drawing.Size(95, 19);
            this.lblmaHS.TabIndex = 35;
            this.lblmaHS.Text = "Mã học sinh:";
            this.lblmaHS.UseWaitCursor = true;
            // 
            // btnThemHS
            // 
            this.btnThemHS.AutoSize = true;
            this.btnThemHS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnThemHS.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnThemHS.Depth = 0;
            this.btnThemHS.Icon = null;
            this.btnThemHS.Location = new System.Drawing.Point(70, 240);
            this.btnThemHS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnThemHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnThemHS.Name = "btnThemHS";
            this.btnThemHS.Primary = false;
            this.btnThemHS.Size = new System.Drawing.Size(88, 36);
            this.btnThemHS.TabIndex = 52;
            this.btnThemHS.Text = "Thêm Mới";
            this.btnThemHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThemHS.UseVisualStyleBackColor = false;
            this.btnThemHS.Click += new System.EventHandler(this.btnThemHS_Click);
            // 
            // btnSuaHS
            // 
            this.btnSuaHS.AutoSize = true;
            this.btnSuaHS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSuaHS.Depth = 0;
            this.btnSuaHS.Icon = null;
            this.btnSuaHS.Location = new System.Drawing.Point(209, 240);
            this.btnSuaHS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSuaHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSuaHS.Name = "btnSuaHS";
            this.btnSuaHS.Primary = false;
            this.btnSuaHS.Size = new System.Drawing.Size(48, 36);
            this.btnSuaHS.TabIndex = 53;
            this.btnSuaHS.Text = "Sửa";
            this.btnSuaHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSuaHS.UseVisualStyleBackColor = true;
            this.btnSuaHS.Click += new System.EventHandler(this.btnSuaHS_Click);
            // 
            // btnXoaHS
            // 
            this.btnXoaHS.AutoSize = true;
            this.btnXoaHS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnXoaHS.Depth = 0;
            this.btnXoaHS.Icon = null;
            this.btnXoaHS.Location = new System.Drawing.Point(334, 240);
            this.btnXoaHS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnXoaHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnXoaHS.Name = "btnXoaHS";
            this.btnXoaHS.Primary = false;
            this.btnXoaHS.Size = new System.Drawing.Size(48, 36);
            this.btnXoaHS.TabIndex = 54;
            this.btnXoaHS.Text = "Xóa";
            this.btnXoaHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoaHS.UseVisualStyleBackColor = true;
            this.btnXoaHS.Click += new System.EventHandler(this.btnXoaHS_Click);
            // 
            // btnTimKiemHS
            // 
            this.btnTimKiemHS.AutoSize = true;
            this.btnTimKiemHS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTimKiemHS.Depth = 0;
            this.btnTimKiemHS.Icon = null;
            this.btnTimKiemHS.Location = new System.Drawing.Point(483, 240);
            this.btnTimKiemHS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTimKiemHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTimKiemHS.Name = "btnTimKiemHS";
            this.btnTimKiemHS.Primary = false;
            this.btnTimKiemHS.Size = new System.Drawing.Size(81, 36);
            this.btnTimKiemHS.TabIndex = 55;
            this.btnTimKiemHS.Text = "Tìm Kiếm";
            this.btnTimKiemHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTimKiemHS.UseVisualStyleBackColor = true;
            this.btnTimKiemHS.Click += new System.EventHandler(this.btnTimKiemHS_Click);
            // 
            // btnBoQuaHS
            // 
            this.btnBoQuaHS.AutoSize = true;
            this.btnBoQuaHS.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBoQuaHS.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBoQuaHS.Depth = 0;
            this.btnBoQuaHS.Icon = null;
            this.btnBoQuaHS.Location = new System.Drawing.Point(705, 240);
            this.btnBoQuaHS.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBoQuaHS.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBoQuaHS.Name = "btnBoQuaHS";
            this.btnBoQuaHS.Primary = false;
            this.btnBoQuaHS.Size = new System.Drawing.Size(70, 36);
            this.btnBoQuaHS.TabIndex = 56;
            this.btnBoQuaHS.Text = "Bỏ Qua";
            this.btnBoQuaHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQuaHS.UseVisualStyleBackColor = false;
            this.btnBoQuaHS.Click += new System.EventHandler(this.btnBoQuaHS_Click);
            // 
            // gridviewHS
            // 
            this.gridviewHS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewHS.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.gridviewHS.Location = new System.Drawing.Point(20, 324);
            this.gridviewHS.Name = "gridviewHS";
            this.gridviewHS.Size = new System.Drawing.Size(900, 197);
            this.gridviewHS.TabIndex = 57;
            this.gridviewHS.UseWaitCursor = true;
            // 
            // FormHocSinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 543);
            this.Controls.Add(this.gridviewHS);
            this.Controls.Add(this.btnBoQuaHS);
            this.Controls.Add(this.btnTimKiemHS);
            this.Controls.Add(this.btnXoaHS);
            this.Controls.Add(this.btnSuaHS);
            this.Controls.Add(this.btnThemHS);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.tlblDiaChi);
            this.Controls.Add(this.txtMaLopHS);
            this.Controls.Add(this.lblMaLopHS);
            this.Controls.Add(this.mktSDTPhuHuynh);
            this.Controls.Add(this.lblsdtph);
            this.Controls.Add(this.mktNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.rdbNu);
            this.Controls.Add(this.rdbNam);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.txtTenHS);
            this.Controls.Add(this.lblTenHS);
            this.Controls.Add(this.txtMaHS);
            this.Controls.Add(this.lblmaHS);
            this.Name = "FormHocSinh";
            this.Text = "HocSinh";
            this.Load += new System.EventHandler(this.FormHocSinh_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewHS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDiaChi;
        private MaterialSkin.Controls.MaterialLabel tlblDiaChi;
        private System.Windows.Forms.TextBox txtMaLopHS;
        private MaterialSkin.Controls.MaterialLabel lblMaLopHS;
        private System.Windows.Forms.MaskedTextBox mktSDTPhuHuynh;
        private MaterialSkin.Controls.MaterialLabel lblsdtph;
        private System.Windows.Forms.MaskedTextBox mktNgaySinh;
        private MaterialSkin.Controls.MaterialLabel lblNgaySinh;
        private MaterialSkin.Controls.MaterialRadioButton rdbNu;
        private MaterialSkin.Controls.MaterialRadioButton rdbNam;
        private MaterialSkin.Controls.MaterialLabel lblGioiTinh;
        private System.Windows.Forms.TextBox txtTenHS;
        private MaterialSkin.Controls.MaterialLabel lblTenHS;
        private System.Windows.Forms.TextBox txtMaHS;
        private MaterialSkin.Controls.MaterialLabel lblmaHS;
        private MaterialSkin.Controls.MaterialFlatButton btnThemHS;
        private MaterialSkin.Controls.MaterialFlatButton btnSuaHS;
        private MaterialSkin.Controls.MaterialFlatButton btnXoaHS;
        private MaterialSkin.Controls.MaterialFlatButton btnTimKiemHS;
        private MaterialSkin.Controls.MaterialFlatButton btnBoQuaHS;
        private System.Windows.Forms.DataGridView gridviewHS;
    }
}