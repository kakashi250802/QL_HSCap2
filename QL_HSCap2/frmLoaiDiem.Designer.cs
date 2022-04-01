
namespace QL_HSCap2
{
    partial class frmLoaiDiem
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
            this.txtHeSoDiem = new System.Windows.Forms.TextBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.txtTenLoaiDiem = new System.Windows.Forms.TextBox();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.txtMaLoaiDiem = new System.Windows.Forms.TextBox();
            this.materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel8 = new MaterialSkin.Controls.MaterialLabel();
            this.gridviewLoaiDiem = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBoQuaLoaiDiem = new System.Windows.Forms.Button();
            this.btnTimKiemLoaiDiem = new System.Windows.Forms.Button();
            this.btnXoaLoaiDiem = new System.Windows.Forms.Button();
            this.btnSuaLoaiDiem = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewLoaiDiem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeSoDiem
            // 
            this.txtHeSoDiem.Location = new System.Drawing.Point(330, 139);
            this.txtHeSoDiem.Name = "txtHeSoDiem";
            this.txtHeSoDiem.Size = new System.Drawing.Size(198, 20);
            this.txtHeSoDiem.TabIndex = 84;
            this.txtHeSoDiem.UseWaitCursor = true;
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(260, 140);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(53, 19);
            this.materialLabel5.TabIndex = 83;
            this.materialLabel5.Text = "Hệ số:";
            this.materialLabel5.UseWaitCursor = true;
            // 
            // txtTenLoaiDiem
            // 
            this.txtTenLoaiDiem.Location = new System.Drawing.Point(330, 107);
            this.txtTenLoaiDiem.Name = "txtTenLoaiDiem";
            this.txtTenLoaiDiem.Size = new System.Drawing.Size(198, 20);
            this.txtTenLoaiDiem.TabIndex = 82;
            this.txtTenLoaiDiem.UseWaitCursor = true;
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(197, 107);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(110, 19);
            this.materialLabel6.TabIndex = 81;
            this.materialLabel6.Text = "Tên Loại Điểm:";
            this.materialLabel6.UseWaitCursor = true;
            // 
            // txtMaLoaiDiem
            // 
            this.txtMaLoaiDiem.Location = new System.Drawing.Point(330, 69);
            this.txtMaLoaiDiem.Name = "txtMaLoaiDiem";
            this.txtMaLoaiDiem.Size = new System.Drawing.Size(198, 20);
            this.txtMaLoaiDiem.TabIndex = 80;
            this.txtMaLoaiDiem.UseWaitCursor = true;
            // 
            // materialLabel7
            // 
            this.materialLabel7.AutoSize = true;
            this.materialLabel7.Depth = 0;
            this.materialLabel7.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel7.Location = new System.Drawing.Point(201, 69);
            this.materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel7.Name = "materialLabel7";
            this.materialLabel7.Size = new System.Drawing.Size(106, 19);
            this.materialLabel7.TabIndex = 79;
            this.materialLabel7.Text = "Mã Loại Điểm:";
            this.materialLabel7.UseWaitCursor = true;
            // 
            // materialLabel8
            // 
            this.materialLabel8.AutoSize = true;
            this.materialLabel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.materialLabel8.Depth = 0;
            this.materialLabel8.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel8.Location = new System.Drawing.Point(353, 23);
            this.materialLabel8.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel8.Name = "materialLabel8";
            this.materialLabel8.Size = new System.Drawing.Size(77, 19);
            this.materialLabel8.TabIndex = 78;
            this.materialLabel8.Text = "Loại Điểm";
            this.materialLabel8.UseWaitCursor = true;
            // 
            // gridviewLoaiDiem
            // 
            this.gridviewLoaiDiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridviewLoaiDiem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.gridviewLoaiDiem.Location = new System.Drawing.Point(201, 250);
            this.gridviewLoaiDiem.Name = "gridviewLoaiDiem";
            this.gridviewLoaiDiem.Size = new System.Drawing.Size(344, 179);
            this.gridviewLoaiDiem.TabIndex = 90;
            this.gridviewLoaiDiem.UseWaitCursor = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "sMaDiem";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Mã Loại Điểm";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "sTenDiem";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Tên Loại Điểm";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "sHeSo";
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Hệ Số";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnBoQuaLoaiDiem
            // 
            this.btnBoQuaLoaiDiem.Location = new System.Drawing.Point(650, 184);
            this.btnBoQuaLoaiDiem.Name = "btnBoQuaLoaiDiem";
            this.btnBoQuaLoaiDiem.Size = new System.Drawing.Size(75, 23);
            this.btnBoQuaLoaiDiem.TabIndex = 95;
            this.btnBoQuaLoaiDiem.Text = "Bỏ Qua";
            this.btnBoQuaLoaiDiem.UseVisualStyleBackColor = true;
            this.btnBoQuaLoaiDiem.Click += new System.EventHandler(this.btnBoQuaLoaiDiem_Click);
            // 
            // btnTimKiemLoaiDiem
            // 
            this.btnTimKiemLoaiDiem.Location = new System.Drawing.Point(477, 184);
            this.btnTimKiemLoaiDiem.Name = "btnTimKiemLoaiDiem";
            this.btnTimKiemLoaiDiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiemLoaiDiem.TabIndex = 94;
            this.btnTimKiemLoaiDiem.Text = "Tìm Kiếm";
            this.btnTimKiemLoaiDiem.UseVisualStyleBackColor = true;
            // 
            // btnXoaLoaiDiem
            // 
            this.btnXoaLoaiDiem.Location = new System.Drawing.Point(328, 184);
            this.btnXoaLoaiDiem.Name = "btnXoaLoaiDiem";
            this.btnXoaLoaiDiem.Size = new System.Drawing.Size(75, 23);
            this.btnXoaLoaiDiem.TabIndex = 93;
            this.btnXoaLoaiDiem.Text = "Xóa";
            this.btnXoaLoaiDiem.UseVisualStyleBackColor = true;
            this.btnXoaLoaiDiem.Click += new System.EventHandler(this.btnXoaLoaiDiem_Click);
            // 
            // btnSuaLoaiDiem
            // 
            this.btnSuaLoaiDiem.Location = new System.Drawing.Point(185, 184);
            this.btnSuaLoaiDiem.Name = "btnSuaLoaiDiem";
            this.btnSuaLoaiDiem.Size = new System.Drawing.Size(75, 23);
            this.btnSuaLoaiDiem.TabIndex = 92;
            this.btnSuaLoaiDiem.Text = "Sửa";
            this.btnSuaLoaiDiem.UseVisualStyleBackColor = true;
            this.btnSuaLoaiDiem.Click += new System.EventHandler(this.btnSuaLoaiDiem_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(84, 184);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 91;
            this.btnThem.Text = "Thêm Mới";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmLoaiDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBoQuaLoaiDiem);
            this.Controls.Add(this.btnTimKiemLoaiDiem);
            this.Controls.Add(this.btnXoaLoaiDiem);
            this.Controls.Add(this.btnSuaLoaiDiem);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.gridviewLoaiDiem);
            this.Controls.Add(this.txtHeSoDiem);
            this.Controls.Add(this.materialLabel5);
            this.Controls.Add(this.txtTenLoaiDiem);
            this.Controls.Add(this.materialLabel6);
            this.Controls.Add(this.txtMaLoaiDiem);
            this.Controls.Add(this.materialLabel7);
            this.Controls.Add(this.materialLabel8);
            this.Name = "frmLoaiDiem";
            this.Text = "frmLoaiDiem";
            this.Load += new System.EventHandler(this.frmLoaiDiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridviewLoaiDiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtHeSoDiem;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private System.Windows.Forms.TextBox txtTenLoaiDiem;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.TextBox txtMaLoaiDiem;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialLabel materialLabel8;
        private System.Windows.Forms.DataGridView gridviewLoaiDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button btnBoQuaLoaiDiem;
        private System.Windows.Forms.Button btnTimKiemLoaiDiem;
        private System.Windows.Forms.Button btnXoaLoaiDiem;
        private System.Windows.Forms.Button btnSuaLoaiDiem;
        private System.Windows.Forms.Button btnThem;
    }
}