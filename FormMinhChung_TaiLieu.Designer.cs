namespace KiemDinhChatLuongGUI
{
    partial class FormMinhChungTaiLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMinhChungTaiLieu));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMinhChung = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PDFLuuTaiLieu = new AxAcroPDFLib.AxAcroPDF();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaTaiLieu = new System.Windows.Forms.TextBox();
            this.txtTenTaiLieu = new System.Windows.Forms.TextBox();
            this.txtNgayKy = new System.Windows.Forms.TextBox();
            this.txtNguoiKy = new System.Windows.Forms.TextBox();
            this.btnThemMoiMChung = new System.Windows.Forms.Button();
            this.btnSuaMChung = new System.Windows.Forms.Button();
            this.btnXoaMChung = new System.Windows.Forms.Button();
            this.btnTimKiemMChung = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoBanHanh = new System.Windows.Forms.TextBox();
            this.txtTomTatNoiDung = new System.Windows.Forms.TextBox();
            this.txtGhiChuMChung = new System.Windows.Forms.TextBox();
            this.btnDocTaiLieu = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinhChung)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDFLuuTaiLieu)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 753);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Minh Chứng";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvMinhChung);
            this.groupBox2.Location = new System.Drawing.Point(6, 310);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(582, 437);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Minh Chứng";
            // 
            // dgvMinhChung
            // 
            this.dgvMinhChung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMinhChung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMinhChung.Location = new System.Drawing.Point(6, 27);
            this.dgvMinhChung.Name = "dgvMinhChung";
            this.dgvMinhChung.RowHeadersWidth = 51;
            this.dgvMinhChung.RowTemplate.Height = 24;
            this.dgvMinhChung.Size = new System.Drawing.Size(570, 404);
            this.dgvMinhChung.TabIndex = 0;
            this.dgvMinhChung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMinhChung_CellClick);
            this.dgvMinhChung.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMinhChung_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.PDFLuuTaiLieu);
            this.groupBox3.Location = new System.Drawing.Point(603, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(695, 750);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tài Liệu";
            // 
            // PDFLuuTaiLieu
            // 
            this.PDFLuuTaiLieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PDFLuuTaiLieu.Enabled = true;
            this.PDFLuuTaiLieu.Location = new System.Drawing.Point(6, 26);
            this.PDFLuuTaiLieu.Name = "PDFLuuTaiLieu";
            this.PDFLuuTaiLieu.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFLuuTaiLieu.OcxState")));
            this.PDFLuuTaiLieu.Size = new System.Drawing.Size(683, 714);
            this.PDFLuuTaiLieu.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Tài Liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Tài Liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày Ký ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Ghi Chú";
            // 
            // txtMaTaiLieu
            // 
            this.txtMaTaiLieu.Location = new System.Drawing.Point(171, 24);
            this.txtMaTaiLieu.Name = "txtMaTaiLieu";
            this.txtMaTaiLieu.Size = new System.Drawing.Size(256, 28);
            this.txtMaTaiLieu.TabIndex = 1;
            // 
            // txtTenTaiLieu
            // 
            this.txtTenTaiLieu.Location = new System.Drawing.Point(171, 59);
            this.txtTenTaiLieu.Name = "txtTenTaiLieu";
            this.txtTenTaiLieu.Size = new System.Drawing.Size(256, 28);
            this.txtTenTaiLieu.TabIndex = 2;
            // 
            // txtNgayKy
            // 
            this.txtNgayKy.Location = new System.Drawing.Point(171, 93);
            this.txtNgayKy.Name = "txtNgayKy";
            this.txtNgayKy.Size = new System.Drawing.Size(256, 28);
            this.txtNgayKy.TabIndex = 3;
            // 
            // txtNguoiKy
            // 
            this.txtNguoiKy.Location = new System.Drawing.Point(171, 128);
            this.txtNguoiKy.Name = "txtNguoiKy";
            this.txtNguoiKy.Size = new System.Drawing.Size(256, 28);
            this.txtNguoiKy.TabIndex = 4;
            // 
            // btnThemMoiMChung
            // 
            this.btnThemMoiMChung.Location = new System.Drawing.Point(451, 22);
            this.btnThemMoiMChung.Name = "btnThemMoiMChung";
            this.btnThemMoiMChung.Size = new System.Drawing.Size(98, 30);
            this.btnThemMoiMChung.TabIndex = 8;
            this.btnThemMoiMChung.Text = "Thêm Mới";
            this.btnThemMoiMChung.UseVisualStyleBackColor = true;
            this.btnThemMoiMChung.Click += new System.EventHandler(this.btnThemMoiMChung_Click);
            // 
            // btnSuaMChung
            // 
            this.btnSuaMChung.Location = new System.Drawing.Point(451, 57);
            this.btnSuaMChung.Name = "btnSuaMChung";
            this.btnSuaMChung.Size = new System.Drawing.Size(98, 30);
            this.btnSuaMChung.TabIndex = 9;
            this.btnSuaMChung.Text = "Sửa";
            this.btnSuaMChung.UseVisualStyleBackColor = true;
            this.btnSuaMChung.Click += new System.EventHandler(this.btnSuaMChung_Click);
            // 
            // btnXoaMChung
            // 
            this.btnXoaMChung.Location = new System.Drawing.Point(451, 91);
            this.btnXoaMChung.Name = "btnXoaMChung";
            this.btnXoaMChung.Size = new System.Drawing.Size(98, 30);
            this.btnXoaMChung.TabIndex = 10;
            this.btnXoaMChung.Text = "Xóa";
            this.btnXoaMChung.UseVisualStyleBackColor = true;
            this.btnXoaMChung.Click += new System.EventHandler(this.btnXoaMChung_Click);
            // 
            // btnTimKiemMChung
            // 
            this.btnTimKiemMChung.Location = new System.Drawing.Point(451, 126);
            this.btnTimKiemMChung.Name = "btnTimKiemMChung";
            this.btnTimKiemMChung.Size = new System.Drawing.Size(98, 30);
            this.btnTimKiemMChung.TabIndex = 11;
            this.btnTimKiemMChung.Text = "Tìm Kiếm";
            this.btnTimKiemMChung.UseVisualStyleBackColor = true;
            this.btnTimKiemMChung.Click += new System.EventHandler(this.btnTimKiemMChung_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(451, 198);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(98, 30);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(451, 162);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(98, 30);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 21);
            this.label5.TabIndex = 30;
            this.label5.Text = "Tóm Tắt Nội Dung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 21);
            this.label6.TabIndex = 31;
            this.label6.Text = "Số Ban Hành";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 131);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 21);
            this.label7.TabIndex = 32;
            this.label7.Text = "Người Ký";
            // 
            // txtSoBanHanh
            // 
            this.txtSoBanHanh.Location = new System.Drawing.Point(171, 162);
            this.txtSoBanHanh.Name = "txtSoBanHanh";
            this.txtSoBanHanh.Size = new System.Drawing.Size(256, 28);
            this.txtSoBanHanh.TabIndex = 5;
            // 
            // txtTomTatNoiDung
            // 
            this.txtTomTatNoiDung.Location = new System.Drawing.Point(171, 196);
            this.txtTomTatNoiDung.Name = "txtTomTatNoiDung";
            this.txtTomTatNoiDung.Size = new System.Drawing.Size(256, 28);
            this.txtTomTatNoiDung.TabIndex = 6;
            // 
            // txtGhiChuMChung
            // 
            this.txtGhiChuMChung.Location = new System.Drawing.Point(171, 230);
            this.txtGhiChuMChung.Name = "txtGhiChuMChung";
            this.txtGhiChuMChung.Size = new System.Drawing.Size(256, 28);
            this.txtGhiChuMChung.TabIndex = 7;
            // 
            // btnDocTaiLieu
            // 
            this.btnDocTaiLieu.Location = new System.Drawing.Point(442, 234);
            this.btnDocTaiLieu.Name = "btnDocTaiLieu";
            this.btnDocTaiLieu.Size = new System.Drawing.Size(117, 30);
            this.btnDocTaiLieu.TabIndex = 14;
            this.btnDocTaiLieu.Text = "Đọc Tài Liệu";
            this.btnDocTaiLieu.UseVisualStyleBackColor = true;
            this.btnDocTaiLieu.Click += new System.EventHandler(this.btnDocTaiLieu_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnDocTaiLieu);
            this.groupBox4.Controls.Add(this.txtGhiChuMChung);
            this.groupBox4.Controls.Add(this.txtTomTatNoiDung);
            this.groupBox4.Controls.Add(this.txtSoBanHanh);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnHuy);
            this.groupBox4.Controls.Add(this.btnDong);
            this.groupBox4.Controls.Add(this.btnTimKiemMChung);
            this.groupBox4.Controls.Add(this.btnXoaMChung);
            this.groupBox4.Controls.Add(this.btnSuaMChung);
            this.groupBox4.Controls.Add(this.btnThemMoiMChung);
            this.groupBox4.Controls.Add(this.txtNguoiKy);
            this.groupBox4.Controls.Add(this.txtNgayKy);
            this.groupBox4.Controls.Add(this.txtTenTaiLieu);
            this.groupBox4.Controls.Add(this.txtMaTaiLieu);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(0, 27);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(588, 277);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức Năng";
            // 
            // FormMinhChungTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 753);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMinhChungTaiLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minh Chứng - Tài Liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMinhChung)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PDFLuuTaiLieu)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private AxAcroPDFLib.AxAcroPDF PDFLuuTaiLieu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMinhChung;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDocTaiLieu;
        private System.Windows.Forms.TextBox txtGhiChuMChung;
        private System.Windows.Forms.TextBox txtTomTatNoiDung;
        private System.Windows.Forms.TextBox txtSoBanHanh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnTimKiemMChung;
        private System.Windows.Forms.Button btnXoaMChung;
        private System.Windows.Forms.Button btnSuaMChung;
        private System.Windows.Forms.Button btnThemMoiMChung;
        private System.Windows.Forms.TextBox txtNguoiKy;
        private System.Windows.Forms.TextBox txtNgayKy;
        private System.Windows.Forms.TextBox txtTenTaiLieu;
        private System.Windows.Forms.TextBox txtMaTaiLieu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}