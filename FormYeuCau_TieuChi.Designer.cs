namespace KiemDinhChatLuongGUI
{
    partial class FormYeuCauTieuChi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvYeuCau = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemYCau = new System.Windows.Forms.Button();
            this.btnXoaYCau = new System.Windows.Forms.Button();
            this.btnSuaYCau = new System.Windows.Forms.Button();
            this.btnThemMoiYCau = new System.Windows.Forms.Button();
            this.txtGhiChuYCau = new System.Windows.Forms.TextBox();
            this.txtNoiDungYeuCau = new System.Windows.Forms.TextBox();
            this.txtTenYeuCau = new System.Windows.Forms.TextBox();
            this.txtMaYeuCau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvTieuChiYeuCau = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimKiemTChiYeuCau = new System.Windows.Forms.Button();
            this.txtGhiChuTChiYCau = new System.Windows.Forms.TextBox();
            this.btnXoaTChiYeuCau = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSuaTChiYeuCau = new System.Windows.Forms.Button();
            this.cbxYeuCau = new System.Windows.Forms.ComboBox();
            this.btnThemMoiTChiYeuCau = new System.Windows.Forms.Button();
            this.cbxTieuChi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChiYeuCau)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(594, 753);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yêu Cầu";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvYeuCau);
            this.groupBox4.Location = new System.Drawing.Point(6, 207);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 539);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nội Dung Yêu Cầu";
            // 
            // dgvYeuCau
            // 
            this.dgvYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYeuCau.Location = new System.Drawing.Point(6, 27);
            this.dgvYeuCau.Name = "dgvYeuCau";
            this.dgvYeuCau.RowHeadersWidth = 51;
            this.dgvYeuCau.RowTemplate.Height = 24;
            this.dgvYeuCau.Size = new System.Drawing.Size(569, 506);
            this.dgvYeuCau.TabIndex = 0;
            this.dgvYeuCau.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvYeuCau_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnTimKiemYCau);
            this.groupBox3.Controls.Add(this.btnXoaYCau);
            this.groupBox3.Controls.Add(this.btnSuaYCau);
            this.groupBox3.Controls.Add(this.btnThemMoiYCau);
            this.groupBox3.Controls.Add(this.txtGhiChuYCau);
            this.groupBox3.Controls.Add(this.txtNoiDungYeuCau);
            this.groupBox3.Controls.Add(this.txtTenYeuCau);
            this.groupBox3.Controls.Add(this.txtMaYeuCau);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(581, 173);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức Năng";
            // 
            // btnTimKiemYCau
            // 
            this.btnTimKiemYCau.Location = new System.Drawing.Point(451, 126);
            this.btnTimKiemYCau.Name = "btnTimKiemYCau";
            this.btnTimKiemYCau.Size = new System.Drawing.Size(98, 30);
            this.btnTimKiemYCau.TabIndex = 11;
            this.btnTimKiemYCau.Text = "Tìm Kiếm";
            this.btnTimKiemYCau.UseVisualStyleBackColor = true;
            this.btnTimKiemYCau.Click += new System.EventHandler(this.btnTimKiemYCau_Click);
            // 
            // btnXoaYCau
            // 
            this.btnXoaYCau.Location = new System.Drawing.Point(451, 91);
            this.btnXoaYCau.Name = "btnXoaYCau";
            this.btnXoaYCau.Size = new System.Drawing.Size(98, 30);
            this.btnXoaYCau.TabIndex = 10;
            this.btnXoaYCau.Text = "Xóa";
            this.btnXoaYCau.UseVisualStyleBackColor = true;
            this.btnXoaYCau.Click += new System.EventHandler(this.btnXoaYCau_Click);
            // 
            // btnSuaYCau
            // 
            this.btnSuaYCau.Location = new System.Drawing.Point(451, 57);
            this.btnSuaYCau.Name = "btnSuaYCau";
            this.btnSuaYCau.Size = new System.Drawing.Size(98, 30);
            this.btnSuaYCau.TabIndex = 9;
            this.btnSuaYCau.Text = "Sửa";
            this.btnSuaYCau.UseVisualStyleBackColor = true;
            this.btnSuaYCau.Click += new System.EventHandler(this.btnSuaYCau_Click);
            // 
            // btnThemMoiYCau
            // 
            this.btnThemMoiYCau.Location = new System.Drawing.Point(451, 22);
            this.btnThemMoiYCau.Name = "btnThemMoiYCau";
            this.btnThemMoiYCau.Size = new System.Drawing.Size(98, 30);
            this.btnThemMoiYCau.TabIndex = 8;
            this.btnThemMoiYCau.Text = "Thêm Mới";
            this.btnThemMoiYCau.UseVisualStyleBackColor = true;
            this.btnThemMoiYCau.Click += new System.EventHandler(this.btnThemMoiYCau_Click);
            // 
            // txtGhiChuYCau
            // 
            this.txtGhiChuYCau.Location = new System.Drawing.Point(200, 128);
            this.txtGhiChuYCau.Name = "txtGhiChuYCau";
            this.txtGhiChuYCau.Size = new System.Drawing.Size(227, 28);
            this.txtGhiChuYCau.TabIndex = 7;
            // 
            // txtNoiDungYeuCau
            // 
            this.txtNoiDungYeuCau.Location = new System.Drawing.Point(200, 93);
            this.txtNoiDungYeuCau.Name = "txtNoiDungYeuCau";
            this.txtNoiDungYeuCau.Size = new System.Drawing.Size(227, 28);
            this.txtNoiDungYeuCau.TabIndex = 6;
            // 
            // txtTenYeuCau
            // 
            this.txtTenYeuCau.Location = new System.Drawing.Point(200, 59);
            this.txtTenYeuCau.Name = "txtTenYeuCau";
            this.txtTenYeuCau.Size = new System.Drawing.Size(227, 28);
            this.txtTenYeuCau.TabIndex = 5;
            // 
            // txtMaYeuCau
            // 
            this.txtMaYeuCau.Location = new System.Drawing.Point(200, 24);
            this.txtMaYeuCau.Name = "txtMaYeuCau";
            this.txtMaYeuCau.Size = new System.Drawing.Size(227, 28);
            this.txtMaYeuCau.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ghi Chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nội Dung Yêu Cầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Yêu Cầu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Yêu Cầu";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(602, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(698, 753);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiêu Chí - Yêu Cầu";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.dgvTieuChiYeuCau);
            this.groupBox6.Location = new System.Drawing.Point(7, 170);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(684, 576);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nội Dung Tiêu Chí - Yêu Cầu";
            // 
            // dgvTieuChiYeuCau
            // 
            this.dgvTieuChiYeuCau.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTieuChiYeuCau.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTieuChiYeuCau.Location = new System.Drawing.Point(7, 27);
            this.dgvTieuChiYeuCau.Name = "dgvTieuChiYeuCau";
            this.dgvTieuChiYeuCau.RowHeadersWidth = 51;
            this.dgvTieuChiYeuCau.RowTemplate.Height = 24;
            this.dgvTieuChiYeuCau.Size = new System.Drawing.Size(671, 543);
            this.dgvTieuChiYeuCau.TabIndex = 0;
            this.dgvTieuChiYeuCau.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTieuChiYeuCau_CellFormatting);
            this.dgvTieuChiYeuCau.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTieuChiYeuCau_CellPainting);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnHuy);
            this.groupBox5.Controls.Add(this.btnDong);
            this.groupBox5.Controls.Add(this.btnTimKiemTChiYeuCau);
            this.groupBox5.Controls.Add(this.txtGhiChuTChiYCau);
            this.groupBox5.Controls.Add(this.btnXoaTChiYeuCau);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnSuaTChiYeuCau);
            this.groupBox5.Controls.Add(this.cbxYeuCau);
            this.groupBox5.Controls.Add(this.btnThemMoiTChiYeuCau);
            this.groupBox5.Controls.Add(this.cbxTieuChi);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(7, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(684, 136);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chức Năng";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(390, 96);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 30);
            this.btnHuy.TabIndex = 29;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(494, 96);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(98, 30);
            this.btnDong.TabIndex = 28;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimKiemTChiYeuCau
            // 
            this.btnTimKiemTChiYeuCau.Location = new System.Drawing.Point(494, 60);
            this.btnTimKiemTChiYeuCau.Name = "btnTimKiemTChiYeuCau";
            this.btnTimKiemTChiYeuCau.Size = new System.Drawing.Size(98, 30);
            this.btnTimKiemTChiYeuCau.TabIndex = 15;
            this.btnTimKiemTChiYeuCau.Text = "Tìm Kiếm";
            this.btnTimKiemTChiYeuCau.UseVisualStyleBackColor = true;
            this.btnTimKiemTChiYeuCau.Click += new System.EventHandler(this.btnTimKiemTChiYeuCau_Click);
            // 
            // txtGhiChuTChiYCau
            // 
            this.txtGhiChuTChiYCau.Location = new System.Drawing.Point(88, 93);
            this.txtGhiChuTChiYCau.Name = "txtGhiChuTChiYCau";
            this.txtGhiChuTChiYCau.Size = new System.Drawing.Size(257, 28);
            this.txtGhiChuTChiYCau.TabIndex = 9;
            // 
            // btnXoaTChiYeuCau
            // 
            this.btnXoaTChiYeuCau.Location = new System.Drawing.Point(390, 60);
            this.btnXoaTChiYeuCau.Name = "btnXoaTChiYeuCau";
            this.btnXoaTChiYeuCau.Size = new System.Drawing.Size(98, 30);
            this.btnXoaTChiYeuCau.TabIndex = 14;
            this.btnXoaTChiYeuCau.Text = "Xóa";
            this.btnXoaTChiYeuCau.UseVisualStyleBackColor = true;
            this.btnXoaTChiYeuCau.Click += new System.EventHandler(this.btnXoaTChiYeuCau_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chi Chú";
            // 
            // btnSuaTChiYeuCau
            // 
            this.btnSuaTChiYeuCau.Location = new System.Drawing.Point(494, 24);
            this.btnSuaTChiYeuCau.Name = "btnSuaTChiYeuCau";
            this.btnSuaTChiYeuCau.Size = new System.Drawing.Size(98, 30);
            this.btnSuaTChiYeuCau.TabIndex = 13;
            this.btnSuaTChiYeuCau.Text = "Sửa";
            this.btnSuaTChiYeuCau.UseVisualStyleBackColor = true;
            this.btnSuaTChiYeuCau.Click += new System.EventHandler(this.btnSuaTChiYeuCau_Click);
            // 
            // cbxYeuCau
            // 
            this.cbxYeuCau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxYeuCau.FormattingEnabled = true;
            this.cbxYeuCau.Location = new System.Drawing.Point(88, 59);
            this.cbxYeuCau.Name = "cbxYeuCau";
            this.cbxYeuCau.Size = new System.Drawing.Size(257, 28);
            this.cbxYeuCau.TabIndex = 8;
            // 
            // btnThemMoiTChiYeuCau
            // 
            this.btnThemMoiTChiYeuCau.Location = new System.Drawing.Point(390, 24);
            this.btnThemMoiTChiYeuCau.Name = "btnThemMoiTChiYeuCau";
            this.btnThemMoiTChiYeuCau.Size = new System.Drawing.Size(98, 30);
            this.btnThemMoiTChiYeuCau.TabIndex = 12;
            this.btnThemMoiTChiYeuCau.Text = "Thêm Mới";
            this.btnThemMoiTChiYeuCau.UseVisualStyleBackColor = true;
            this.btnThemMoiTChiYeuCau.Click += new System.EventHandler(this.btnThemMoiTChiYeuCau_Click);
            // 
            // cbxTieuChi
            // 
            this.cbxTieuChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTieuChi.FormattingEnabled = true;
            this.cbxTieuChi.Location = new System.Drawing.Point(88, 24);
            this.cbxTieuChi.Name = "cbxTieuChi";
            this.cbxTieuChi.Size = new System.Drawing.Size(257, 28);
            this.cbxTieuChi.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Yêu Cầu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Tiêu Chí";
            // 
            // FormYeuCauTieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormYeuCauTieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yêu Cầu - Tiêu Chí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYeuCau)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChiYeuCau)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvYeuCau;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTimKiemYCau;
        private System.Windows.Forms.Button btnXoaYCau;
        private System.Windows.Forms.Button btnSuaYCau;
        private System.Windows.Forms.Button btnThemMoiYCau;
        private System.Windows.Forms.TextBox txtGhiChuYCau;
        private System.Windows.Forms.TextBox txtNoiDungYeuCau;
        private System.Windows.Forms.TextBox txtTenYeuCau;
        private System.Windows.Forms.TextBox txtMaYeuCau;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvTieuChiYeuCau;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnTimKiemTChiYeuCau;
        private System.Windows.Forms.TextBox txtGhiChuTChiYCau;
        private System.Windows.Forms.Button btnXoaTChiYeuCau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSuaTChiYeuCau;
        private System.Windows.Forms.ComboBox cbxYeuCau;
        private System.Windows.Forms.Button btnThemMoiTChiYeuCau;
        private System.Windows.Forms.ComboBox cbxTieuChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
    }
}