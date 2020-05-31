namespace KiemDinhChatLuongGUI
{
    partial class FormTieuChi_NguonMinhChung
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
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxTieuChi = new System.Windows.Forms.ComboBox();
            this.cbxNguonMinhChung = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTieuChiNguonMinhChung = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuuLai = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChiNguonMinhChung)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbxTieuChi);
            this.groupBox1.Controls.Add(this.cbxNguonMinhChung);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Tiêu Chí - Nguồn Minh Chứng";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(266, 100);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(297, 28);
            this.txtGhiChu.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chi Chú";
            // 
            // cbxTieuChi
            // 
            this.cbxTieuChi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTieuChi.FormattingEnabled = true;
            this.cbxTieuChi.Location = new System.Drawing.Point(266, 32);
            this.cbxTieuChi.Name = "cbxTieuChi";
            this.cbxTieuChi.Size = new System.Drawing.Size(297, 28);
            this.cbxTieuChi.TabIndex = 1;
            // 
            // cbxNguonMinhChung
            // 
            this.cbxNguonMinhChung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNguonMinhChung.FormattingEnabled = true;
            this.cbxNguonMinhChung.Location = new System.Drawing.Point(266, 66);
            this.cbxNguonMinhChung.Name = "cbxNguonMinhChung";
            this.cbxNguonMinhChung.Size = new System.Drawing.Size(297, 28);
            this.cbxNguonMinhChung.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nguồn Minh Chứng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiêu Chí";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTieuChiNguonMinhChung);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 337);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Tiêu Chí - Nguồn Minh Chứng";
            // 
            // dgvTieuChiNguonMinhChung
            // 
            this.dgvTieuChiNguonMinhChung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTieuChiNguonMinhChung.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTieuChiNguonMinhChung.Location = new System.Drawing.Point(3, 24);
            this.dgvTieuChiNguonMinhChung.Name = "dgvTieuChiNguonMinhChung";
            this.dgvTieuChiNguonMinhChung.RowHeadersWidth = 51;
            this.dgvTieuChiNguonMinhChung.RowTemplate.Height = 24;
            this.dgvTieuChiNguonMinhChung.Size = new System.Drawing.Size(1026, 307);
            this.dgvTieuChiNguonMinhChung.TabIndex = 0;
            this.dgvTieuChiNguonMinhChung.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTieuChiNguonMinhChung_CellFormatting);
            this.dgvTieuChiNguonMinhChung.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTieuChiNguonMinhChung_CellPainting);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnHuy);
            this.groupBox3.Controls.Add(this.btnDong);
            this.groupBox3.Controls.Add(this.btnXoa);
            this.groupBox3.Controls.Add(this.btnSua);
            this.groupBox3.Controls.Add(this.btnLuuLai);
            this.groupBox3.Controls.Add(this.btnBatDau);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 488);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1032, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức Năng";
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(451, 23);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(83, 30);
            this.btnHuy.TabIndex = 17;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(886, 24);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(84, 29);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(362, 24);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(83, 30);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(273, 23);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(83, 30);
            this.btnSua.TabIndex = 15;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Location = new System.Drawing.Point(183, 24);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(84, 29);
            this.btnLuuLai.TabIndex = 8;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(93, 24);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(84, 29);
            this.btnBatDau.TabIndex = 7;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // FormTieuChi_NguonMinhChung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 553);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormTieuChi_NguonMinhChung";
            this.Text = "Tiêu Chí - Nguồn Minh Chứng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChiNguonMinhChung)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTieuChiNguonMinhChung;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbxTieuChi;
        private System.Windows.Forms.ComboBox cbxNguonMinhChung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuuLai;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
    }
}