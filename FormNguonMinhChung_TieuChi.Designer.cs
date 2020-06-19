namespace KiemDinhChatLuongGUI
{
    partial class FormNguonMinhChungTieuChi
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
            this.dgvNguonMinhChung = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTimKiemNMChung = new System.Windows.Forms.Button();
            this.btnXoaNMChung = new System.Windows.Forms.Button();
            this.btnSuaNMChung = new System.Windows.Forms.Button();
            this.btnThemMoiNMChung = new System.Windows.Forms.Button();
            this.txtGhiChuNMChung = new System.Windows.Forms.TextBox();
            this.txtNoiDungNguonMinhChung = new System.Windows.Forms.TextBox();
            this.txtTenNguonMinhChung = new System.Windows.Forms.TextBox();
            this.txtMaNguonMinhChung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvTieuChiNguonMinhChung = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimKiemMoiTChiNMChung = new System.Windows.Forms.Button();
            this.txtGhiChuTChiNMChung = new System.Windows.Forms.TextBox();
            this.btnXoaMoiTChiNMChung = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSuaMoiTChiNMChung = new System.Windows.Forms.Button();
            this.cbxNguonMinhChung = new System.Windows.Forms.ComboBox();
            this.btnThemMoiTChiNMChung = new System.Windows.Forms.Button();
            this.cbxTieuChi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguonMinhChung)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChiNguonMinhChung)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 753);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nguồn Minh Chứng";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dgvNguonMinhChung);
            this.groupBox4.Location = new System.Drawing.Point(6, 206);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(582, 539);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nội Dung Nguồn Minh Chứng";
            // 
            // dgvNguonMinhChung
            // 
            this.dgvNguonMinhChung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNguonMinhChung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguonMinhChung.Location = new System.Drawing.Point(6, 27);
            this.dgvNguonMinhChung.Name = "dgvNguonMinhChung";
            this.dgvNguonMinhChung.RowHeadersWidth = 51;
            this.dgvNguonMinhChung.RowTemplate.Height = 24;
            this.dgvNguonMinhChung.Size = new System.Drawing.Size(570, 506);
            this.dgvNguonMinhChung.TabIndex = 0;
            this.dgvNguonMinhChung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguonMinhChung_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnTimKiemNMChung);
            this.groupBox3.Controls.Add(this.btnXoaNMChung);
            this.groupBox3.Controls.Add(this.btnSuaNMChung);
            this.groupBox3.Controls.Add(this.btnThemMoiNMChung);
            this.groupBox3.Controls.Add(this.txtGhiChuNMChung);
            this.groupBox3.Controls.Add(this.txtNoiDungNguonMinhChung);
            this.groupBox3.Controls.Add(this.txtTenNguonMinhChung);
            this.groupBox3.Controls.Add(this.txtMaNguonMinhChung);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(582, 173);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức Năng";
            // 
            // btnTimKiemNMChung
            // 
            this.btnTimKiemNMChung.Location = new System.Drawing.Point(462, 126);
            this.btnTimKiemNMChung.Name = "btnTimKiemNMChung";
            this.btnTimKiemNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnTimKiemNMChung.TabIndex = 11;
            this.btnTimKiemNMChung.Text = "Tìm Kiếm";
            this.btnTimKiemNMChung.UseVisualStyleBackColor = true;
            // 
            // btnXoaNMChung
            // 
            this.btnXoaNMChung.Location = new System.Drawing.Point(462, 91);
            this.btnXoaNMChung.Name = "btnXoaNMChung";
            this.btnXoaNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnXoaNMChung.TabIndex = 10;
            this.btnXoaNMChung.Text = "Xóa";
            this.btnXoaNMChung.UseVisualStyleBackColor = true;
            this.btnXoaNMChung.Click += new System.EventHandler(this.btnXoaNMChung_Click);
            // 
            // btnSuaNMChung
            // 
            this.btnSuaNMChung.Location = new System.Drawing.Point(462, 57);
            this.btnSuaNMChung.Name = "btnSuaNMChung";
            this.btnSuaNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnSuaNMChung.TabIndex = 9;
            this.btnSuaNMChung.Text = "Sửa";
            this.btnSuaNMChung.UseVisualStyleBackColor = true;
            this.btnSuaNMChung.Click += new System.EventHandler(this.btnSuaNMChung_Click);
            // 
            // btnThemMoiNMChung
            // 
            this.btnThemMoiNMChung.Location = new System.Drawing.Point(462, 22);
            this.btnThemMoiNMChung.Name = "btnThemMoiNMChung";
            this.btnThemMoiNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnThemMoiNMChung.TabIndex = 8;
            this.btnThemMoiNMChung.Text = "Thêm Mới";
            this.btnThemMoiNMChung.UseVisualStyleBackColor = true;
            this.btnThemMoiNMChung.Click += new System.EventHandler(this.btnThemMoiNMChung_Click);
            // 
            // txtGhiChuNMChung
            // 
            this.txtGhiChuNMChung.Location = new System.Drawing.Point(202, 128);
            this.txtGhiChuNMChung.Name = "txtGhiChuNMChung";
            this.txtGhiChuNMChung.Size = new System.Drawing.Size(227, 28);
            this.txtGhiChuNMChung.TabIndex = 7;
            // 
            // txtNoiDungNguonMinhChung
            // 
            this.txtNoiDungNguonMinhChung.Location = new System.Drawing.Point(202, 93);
            this.txtNoiDungNguonMinhChung.Name = "txtNoiDungNguonMinhChung";
            this.txtNoiDungNguonMinhChung.Size = new System.Drawing.Size(227, 28);
            this.txtNoiDungNguonMinhChung.TabIndex = 6;
            // 
            // txtTenNguonMinhChung
            // 
            this.txtTenNguonMinhChung.Location = new System.Drawing.Point(202, 59);
            this.txtTenNguonMinhChung.Name = "txtTenNguonMinhChung";
            this.txtTenNguonMinhChung.Size = new System.Drawing.Size(227, 28);
            this.txtTenNguonMinhChung.TabIndex = 5;
            // 
            // txtMaNguonMinhChung
            // 
            this.txtMaNguonMinhChung.Location = new System.Drawing.Point(202, 24);
            this.txtMaNguonMinhChung.Name = "txtMaNguonMinhChung";
            this.txtMaNguonMinhChung.Size = new System.Drawing.Size(227, 28);
            this.txtMaNguonMinhChung.TabIndex = 4;
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
            this.label3.Size = new System.Drawing.Size(190, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nội Nguồn Minh Chứng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Nguồn Minh Chứng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Nguồn Minh Chứng";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Location = new System.Drawing.Point(600, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(700, 753);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiêu Chí - Nguồn Minh Chứng";
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.dgvTieuChiNguonMinhChung);
            this.groupBox6.Location = new System.Drawing.Point(8, 175);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(686, 572);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Nội Dung Tiêu Chí - Nguồn Minh Chứng";
            // 
            // dgvTieuChiNguonMinhChung
            // 
            this.dgvTieuChiNguonMinhChung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTieuChiNguonMinhChung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTieuChiNguonMinhChung.Location = new System.Drawing.Point(6, 27);
            this.dgvTieuChiNguonMinhChung.Name = "dgvTieuChiNguonMinhChung";
            this.dgvTieuChiNguonMinhChung.RowHeadersWidth = 51;
            this.dgvTieuChiNguonMinhChung.RowTemplate.Height = 24;
            this.dgvTieuChiNguonMinhChung.Size = new System.Drawing.Size(674, 537);
            this.dgvTieuChiNguonMinhChung.TabIndex = 0;
            this.dgvTieuChiNguonMinhChung.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTieuChiNguonMinhChung_CellFormatting);
            this.dgvTieuChiNguonMinhChung.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTieuChiNguonMinhChung_CellPainting);
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.btnHuy);
            this.groupBox5.Controls.Add(this.btnDong);
            this.groupBox5.Controls.Add(this.btnTimKiemMoiTChiNMChung);
            this.groupBox5.Controls.Add(this.txtGhiChuTChiNMChung);
            this.groupBox5.Controls.Add(this.btnXoaMoiTChiNMChung);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.btnSuaMoiTChiNMChung);
            this.groupBox5.Controls.Add(this.cbxNguonMinhChung);
            this.groupBox5.Controls.Add(this.btnThemMoiTChiNMChung);
            this.groupBox5.Controls.Add(this.cbxTieuChi);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(8, 27);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(686, 142);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Chức Năng";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(459, 96);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 30);
            this.btnHuy.TabIndex = 29;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(563, 96);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(98, 30);
            this.btnDong.TabIndex = 28;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimKiemMoiTChiNMChung
            // 
            this.btnTimKiemMoiTChiNMChung.Location = new System.Drawing.Point(563, 61);
            this.btnTimKiemMoiTChiNMChung.Name = "btnTimKiemMoiTChiNMChung";
            this.btnTimKiemMoiTChiNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnTimKiemMoiTChiNMChung.TabIndex = 15;
            this.btnTimKiemMoiTChiNMChung.Text = "Tìm Kiếm";
            this.btnTimKiemMoiTChiNMChung.UseVisualStyleBackColor = true;
            this.btnTimKiemMoiTChiNMChung.Click += new System.EventHandler(this.btnTimKiemMoiTChiNMChung_Click);
            // 
            // txtGhiChuTChiNMChung
            // 
            this.txtGhiChuTChiNMChung.Location = new System.Drawing.Point(167, 93);
            this.txtGhiChuTChiNMChung.Name = "txtGhiChuTChiNMChung";
            this.txtGhiChuTChiNMChung.Size = new System.Drawing.Size(257, 28);
            this.txtGhiChuTChiNMChung.TabIndex = 9;
            // 
            // btnXoaMoiTChiNMChung
            // 
            this.btnXoaMoiTChiNMChung.Location = new System.Drawing.Point(459, 60);
            this.btnXoaMoiTChiNMChung.Name = "btnXoaMoiTChiNMChung";
            this.btnXoaMoiTChiNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnXoaMoiTChiNMChung.TabIndex = 14;
            this.btnXoaMoiTChiNMChung.Text = "Xóa";
            this.btnXoaMoiTChiNMChung.UseVisualStyleBackColor = true;
            this.btnXoaMoiTChiNMChung.Click += new System.EventHandler(this.btnXoaMoiTChiNMChung_Click);
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
            // btnSuaMoiTChiNMChung
            // 
            this.btnSuaMoiTChiNMChung.Location = new System.Drawing.Point(563, 24);
            this.btnSuaMoiTChiNMChung.Name = "btnSuaMoiTChiNMChung";
            this.btnSuaMoiTChiNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnSuaMoiTChiNMChung.TabIndex = 13;
            this.btnSuaMoiTChiNMChung.Text = "Sửa";
            this.btnSuaMoiTChiNMChung.UseVisualStyleBackColor = true;
            this.btnSuaMoiTChiNMChung.Click += new System.EventHandler(this.btnSuaMoiTChiNMChung_Click);
            // 
            // cbxNguonMinhChung
            // 
            this.cbxNguonMinhChung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNguonMinhChung.FormattingEnabled = true;
            this.cbxNguonMinhChung.Location = new System.Drawing.Point(167, 59);
            this.cbxNguonMinhChung.Name = "cbxNguonMinhChung";
            this.cbxNguonMinhChung.Size = new System.Drawing.Size(257, 28);
            this.cbxNguonMinhChung.TabIndex = 8;
            // 
            // btnThemMoiTChiNMChung
            // 
            this.btnThemMoiTChiNMChung.Location = new System.Drawing.Point(459, 24);
            this.btnThemMoiTChiNMChung.Name = "btnThemMoiTChiNMChung";
            this.btnThemMoiTChiNMChung.Size = new System.Drawing.Size(98, 30);
            this.btnThemMoiTChiNMChung.TabIndex = 12;
            this.btnThemMoiTChiNMChung.Text = "Thêm Mới";
            this.btnThemMoiTChiNMChung.UseVisualStyleBackColor = true;
            this.btnThemMoiTChiNMChung.Click += new System.EventHandler(this.btnThemMoiTChiNMChung_Click);
            // 
            // cbxTieuChi
            // 
            this.cbxTieuChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTieuChi.FormattingEnabled = true;
            this.cbxTieuChi.Location = new System.Drawing.Point(167, 24);
            this.cbxTieuChi.Name = "cbxTieuChi";
            this.cbxTieuChi.Size = new System.Drawing.Size(257, 28);
            this.cbxTieuChi.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 21);
            this.label6.TabIndex = 7;
            this.label6.Text = "Nguồn Minh Chứng";
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
            // FormNguonMinhChungTieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormNguonMinhChungTieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nguồn Minh Chứng - Tiêu Chí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguonMinhChung)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChiNguonMinhChung)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dgvNguonMinhChung;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnTimKiemNMChung;
        private System.Windows.Forms.Button btnXoaNMChung;
        private System.Windows.Forms.Button btnSuaNMChung;
        private System.Windows.Forms.Button btnThemMoiNMChung;
        private System.Windows.Forms.TextBox txtGhiChuNMChung;
        private System.Windows.Forms.TextBox txtNoiDungNguonMinhChung;
        private System.Windows.Forms.TextBox txtTenNguonMinhChung;
        private System.Windows.Forms.TextBox txtMaNguonMinhChung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimKiemMoiTChiNMChung;
        private System.Windows.Forms.TextBox txtGhiChuTChiNMChung;
        private System.Windows.Forms.Button btnXoaMoiTChiNMChung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSuaMoiTChiNMChung;
        private System.Windows.Forms.ComboBox cbxNguonMinhChung;
        private System.Windows.Forms.Button btnThemMoiTChiNMChung;
        private System.Windows.Forms.ComboBox cbxTieuChi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvTieuChiNguonMinhChung;
    }
}