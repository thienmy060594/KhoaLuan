﻿namespace KiemDinhChatLuongGUI
{
    partial class FormMonHoc_NhomTuChon
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
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.cbxNhomTuChon = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.cbxMonHoc = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLuuLai = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvMonHocNhomTuChon = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHocNhomTuChon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.btnHuy);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.cbxNhomTuChon);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.cbxMonHoc);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLuuLai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnBatDau);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 137);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Môn Học - Nhóm Tự Chọn";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(593, 95);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(165, 28);
            this.txtTimKiem.TabIndex = 10;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(775, 59);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 30);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(764, 95);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(96, 30);
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(775, 23);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 30);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(290, 95);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(263, 28);
            this.txtGhiChu.TabIndex = 3;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(684, 59);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(85, 30);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // cbxNhomTuChon
            // 
            this.cbxNhomTuChon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNhomTuChon.FormattingEnabled = true;
            this.cbxNhomTuChon.Location = new System.Drawing.Point(290, 61);
            this.cbxNhomTuChon.Name = "cbxNhomTuChon";
            this.cbxNhomTuChon.Size = new System.Drawing.Size(263, 28);
            this.cbxNhomTuChon.TabIndex = 2;
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(593, 59);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(85, 30);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // cbxMonHoc
            // 
            this.cbxMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMonHoc.FormattingEnabled = true;
            this.cbxMonHoc.Location = new System.Drawing.Point(290, 27);
            this.cbxMonHoc.Name = "cbxMonHoc";
            this.cbxMonHoc.Size = new System.Drawing.Size(263, 28);
            this.cbxMonHoc.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ghi Chú";
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Location = new System.Drawing.Point(684, 23);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(85, 30);
            this.btnLuuLai.TabIndex = 5;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhóm Tự Chọn";
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(593, 23);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(85, 30);
            this.btnBatDau.TabIndex = 4;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Môn Học";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvMonHocNhomTuChon);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 137);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 404);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Môn Học - Nhóm Tự Chọn";
            // 
            // dgvMonHocNhomTuChon
            // 
            this.dgvMonHocNhomTuChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMonHocNhomTuChon.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvMonHocNhomTuChon.Location = new System.Drawing.Point(3, 24);
            this.dgvMonHocNhomTuChon.Name = "dgvMonHocNhomTuChon";
            this.dgvMonHocNhomTuChon.RowHeadersWidth = 51;
            this.dgvMonHocNhomTuChon.RowTemplate.Height = 24;
            this.dgvMonHocNhomTuChon.Size = new System.Drawing.Size(1026, 374);
            this.dgvMonHocNhomTuChon.TabIndex = 0;
            this.dgvMonHocNhomTuChon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvMonHocNhomTuChon_CellFormatting);
            this.dgvMonHocNhomTuChon.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMonHocNhomTuChon_CellPainting);
            // 
            // FormMonHoc_NhomTuChon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMonHoc_NhomTuChon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Môn Học - Nhóm Tự Chọn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMonHocNhomTuChon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMonHocNhomTuChon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.ComboBox cbxNhomTuChon;
        private System.Windows.Forms.ComboBox cbxMonHoc;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuuLai;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}