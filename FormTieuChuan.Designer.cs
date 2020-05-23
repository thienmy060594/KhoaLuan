namespace KiemDinhChatLuongGUI
{
    partial class FormTieuChuan
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtNoiDungTieuChuan = new System.Windows.Forms.TextBox();
            this.txtTenTieuChuan = new System.Windows.Forms.TextBox();
            this.txtMaTieuChuan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTieuChuan = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnLuuLai = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChuan)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtNoiDungTieuChuan);
            this.groupBox1.Controls.Add(this.txtTenTieuChuan);
            this.groupBox1.Controls.Add(this.txtMaTieuChuan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1026, 108);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Tiêu Chuẩn";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(665, 61);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(303, 28);
            this.txtGhiChu.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ghi Chú";
            // 
            // txtNoiDungTieuChuan
            // 
            this.txtNoiDungTieuChuan.Location = new System.Drawing.Point(221, 61);
            this.txtNoiDungTieuChuan.Name = "txtNoiDungTieuChuan";
            this.txtNoiDungTieuChuan.Size = new System.Drawing.Size(303, 28);
            this.txtNoiDungTieuChuan.TabIndex = 3;
            // 
            // txtTenTieuChuan
            // 
            this.txtTenTieuChuan.Location = new System.Drawing.Point(665, 27);
            this.txtTenTieuChuan.Name = "txtTenTieuChuan";
            this.txtTenTieuChuan.Size = new System.Drawing.Size(303, 28);
            this.txtTenTieuChuan.TabIndex = 2;
            // 
            // txtMaTieuChuan
            // 
            this.txtMaTieuChuan.Location = new System.Drawing.Point(221, 27);
            this.txtMaTieuChuan.Name = "txtMaTieuChuan";
            this.txtMaTieuChuan.Size = new System.Drawing.Size(303, 28);
            this.txtMaTieuChuan.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nội Dung Tiêu Chuẩn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Tiêu Chuẩn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mã Tiêu Chuẩn";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTieuChuan);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1026, 352);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông Tin Tiêu Chuẩn";
            // 
            // dgvTieuChuan
            // 
            this.dgvTieuChuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTieuChuan.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTieuChuan.Location = new System.Drawing.Point(3, 24);
            this.dgvTieuChuan.Name = "dgvTieuChuan";
            this.dgvTieuChuan.RowHeadersWidth = 51;
            this.dgvTieuChuan.RowTemplate.Height = 24;
            this.dgvTieuChuan.Size = new System.Drawing.Size(1020, 322);
            this.dgvTieuChuan.TabIndex = 0;
            this.dgvTieuChuan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTieuChuan_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDong);
            this.groupBox3.Controls.Add(this.btnLuuLai);
            this.groupBox3.Controls.Add(this.btnBatDau);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 466);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1026, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(855, 24);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 30);
            this.btnDong.TabIndex = 11;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnLuuLai
            // 
            this.btnLuuLai.Location = new System.Drawing.Point(314, 24);
            this.btnLuuLai.Name = "btnLuuLai";
            this.btnLuuLai.Size = new System.Drawing.Size(83, 30);
            this.btnLuuLai.TabIndex = 8;
            this.btnLuuLai.Text = "Lưu Lại";
            this.btnLuuLai.UseVisualStyleBackColor = true;
            this.btnLuuLai.Click += new System.EventHandler(this.btnLuuLai_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(133, 24);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(102, 30);
            this.btnBatDau.TabIndex = 6;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click_1);
            // 
            // FormTieuChuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 532);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormTieuChuan";
            this.Text = "7";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTieuChuan)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNoiDungTieuChuan;
        private System.Windows.Forms.TextBox txtTenTieuChuan;
        private System.Windows.Forms.TextBox txtMaTieuChuan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTieuChuan;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnLuuLai;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label4;
    }
}