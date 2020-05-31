namespace KiemDinhChatLuongGUI
{
    partial class FormBaoCaoKiemDinhChatLuong
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
            this.dgvBaoCaoKiemDinhChatLuong = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnXuatRaFileWord = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnXemFileWord = new System.Windows.Forms.Button();
            this.btnXemFilePDF = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoKiemDinhChatLuong)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvBaoCaoKiemDinhChatLuong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 483);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo Cáo Kiểm Định Chất Lượng";
            // 
            // dgvBaoCaoKiemDinhChatLuong
            // 
            this.dgvBaoCaoKiemDinhChatLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaoCaoKiemDinhChatLuong.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBaoCaoKiemDinhChatLuong.Location = new System.Drawing.Point(3, 24);
            this.dgvBaoCaoKiemDinhChatLuong.Name = "dgvBaoCaoKiemDinhChatLuong";
            this.dgvBaoCaoKiemDinhChatLuong.RowHeadersWidth = 51;
            this.dgvBaoCaoKiemDinhChatLuong.RowTemplate.Height = 24;
            this.dgvBaoCaoKiemDinhChatLuong.Size = new System.Drawing.Size(1026, 453);
            this.dgvBaoCaoKiemDinhChatLuong.TabIndex = 0;
            this.dgvBaoCaoKiemDinhChatLuong.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBaoCaoKiemDinhChatLuong_CellFormatting);
            this.dgvBaoCaoKiemDinhChatLuong.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBaoCaoKiemDinhChatLuong_CellPainting);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXemFilePDF);
            this.groupBox2.Controls.Add(this.btnXemFileWord);
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Controls.Add(this.btnXuatRaFileWord);
            this.groupBox2.Controls.Add(this.btnBatDau);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 489);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 64);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(871, 27);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 30);
            this.btnDong.TabIndex = 35;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnXuatRaFileWord
            // 
            this.btnXuatRaFileWord.Location = new System.Drawing.Point(201, 27);
            this.btnXuatRaFileWord.Name = "btnXuatRaFileWord";
            this.btnXuatRaFileWord.Size = new System.Drawing.Size(159, 30);
            this.btnXuatRaFileWord.TabIndex = 34;
            this.btnXuatRaFileWord.Text = "Xuất Ra File Word ";
            this.btnXuatRaFileWord.UseVisualStyleBackColor = true;
            this.btnXuatRaFileWord.Click += new System.EventHandler(this.btnXuatRaFileWord_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(93, 27);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(102, 30);
            this.btnBatDau.TabIndex = 33;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnXemFileWord
            // 
            this.btnXemFileWord.Location = new System.Drawing.Point(366, 27);
            this.btnXemFileWord.Name = "btnXemFileWord";
            this.btnXemFileWord.Size = new System.Drawing.Size(134, 30);
            this.btnXemFileWord.TabIndex = 36;
            this.btnXemFileWord.Text = "Xem File Word ";
            this.btnXemFileWord.UseVisualStyleBackColor = true;
            this.btnXemFileWord.Click += new System.EventHandler(this.btnXemFileWord_Click);
            // 
            // btnXemFilePDF
            // 
            this.btnXemFilePDF.Location = new System.Drawing.Point(506, 27);
            this.btnXemFilePDF.Name = "btnXemFilePDF";
            this.btnXemFilePDF.Size = new System.Drawing.Size(134, 30);
            this.btnXemFilePDF.TabIndex = 37;
            this.btnXemFilePDF.Text = "Xem File PDF";
            this.btnXemFilePDF.UseVisualStyleBackColor = true;
            this.btnXemFilePDF.Click += new System.EventHandler(this.btnXemFilePDF_Click);
            // 
            // FormBaoCaoKiemDinhChatLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBaoCaoKiemDinhChatLuong";
            this.Text = "Báo Cáo Kiểm Định Chất Lượng";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaoCaoKiemDinhChatLuong)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvBaoCaoKiemDinhChatLuong;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnXuatRaFileWord;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnXemFileWord;
        private System.Windows.Forms.Button btnXemFilePDF;
    }
}