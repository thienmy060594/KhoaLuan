namespace KiemDinhChatLuongGUI
{
    partial class FormLoaiTaiLieu
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
            this.txtMaLoaiTaiLieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxNguonMinhChung = new System.Windows.Forms.ComboBox();
            this.cbxMinhChung = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenLoaiTaiLieu = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuuLai = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLoaiTaiLieu = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTaiLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMaLoaiTaiLieu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbxNguonMinhChung);
            this.groupBox1.Controls.Add(this.cbxMinhChung);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTenLoaiTaiLieu);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(892, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Loại Tài Liệu";
            // 
            // txtMaLoaiTaiLieu
            // 
            this.txtMaLoaiTaiLieu.Location = new System.Drawing.Point(203, 27);
            this.txtMaLoaiTaiLieu.Name = "txtMaLoaiTaiLieu";
            this.txtMaLoaiTaiLieu.Size = new System.Drawing.Size(306, 28);
            this.txtMaLoaiTaiLieu.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mã Loại Tài Liệu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(859, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 21);
            this.label5.TabIndex = 8;
            // 
            // cbxNguonMinhChung
            // 
            this.cbxNguonMinhChung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNguonMinhChung.FormattingEnabled = true;
            this.cbxNguonMinhChung.Location = new System.Drawing.Point(689, 62);
            this.cbxNguonMinhChung.Name = "cbxNguonMinhChung";
            this.cbxNguonMinhChung.Size = new System.Drawing.Size(134, 28);
            this.cbxNguonMinhChung.TabIndex = 7;
            // 
            // cbxMinhChung
            // 
            this.cbxMinhChung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMinhChung.FormattingEnabled = true;
            this.cbxMinhChung.Location = new System.Drawing.Point(689, 27);
            this.cbxMinhChung.Name = "cbxMinhChung";
            this.cbxMinhChung.Size = new System.Drawing.Size(134, 28);
            this.cbxMinhChung.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(525, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nguồn Minh Chứng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Minh Chứng";
            // 
            // txtTenLoaiTaiLieu
            // 
            this.txtTenLoaiTaiLieu.Location = new System.Drawing.Point(203, 96);
            this.txtTenLoaiTaiLieu.Name = "txtTenLoaiTaiLieu";
            this.txtTenLoaiTaiLieu.Size = new System.Drawing.Size(306, 28);
            this.txtTenLoaiTaiLieu.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(203, 62);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(306, 28);
            this.txtGhiChu.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên Loại Tài Liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi Chú";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDong);
            this.groupBox3.Controls.Add(this.btnLuuLai);
            this.groupBox3.Controls.Add(this.btnBatDau);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 510);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(892, 59);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(750, 17);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 30);
            this.btnDong.TabIndex = 5;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Location = new System.Drawing.Point(281, 17);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(83, 30);
            this.btnLuuLai.TabIndex = 2;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(121, 17);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(102, 30);
            this.btnBatDau.TabIndex = 0;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLoaiTaiLieu);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(892, 367);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Loại Tài Liệu";
            // 
            // dgvLoaiTaiLieu
            // 
            this.dgvLoaiTaiLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiTaiLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvLoaiTaiLieu.Location = new System.Drawing.Point(3, 24);
            this.dgvLoaiTaiLieu.Name = "dgvLoaiTaiLieu";
            this.dgvLoaiTaiLieu.RowHeadersWidth = 51;
            this.dgvLoaiTaiLieu.RowTemplate.Height = 24;
            this.dgvLoaiTaiLieu.Size = new System.Drawing.Size(886, 338);
            this.dgvLoaiTaiLieu.TabIndex = 0;
            this.dgvLoaiTaiLieu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiTaiLieu_CellContentClick);
            // 
            // FormLoaiTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 569);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormLoaiTaiLieu";
            this.Text = "Loại Tài Liệu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiTaiLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTenLoaiTaiLieu;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuuLai;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvLoaiTaiLieu;
        private System.Windows.Forms.ComboBox cbxNguonMinhChung;
        private System.Windows.Forms.ComboBox cbxMinhChung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaLoaiTaiLieu;
        private System.Windows.Forms.Label label6;
    }
}