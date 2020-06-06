namespace KiemDinhChatLuongGUI
{
    partial class FormLuuTaiLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLuuTaiLieu));
            this.btnLuuMinhChung = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnDoc = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PDFLuuTaiLieu = new AxAcroPDFLib.AxAcroPDF();
            this.btnKiemTraLuu = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PDFLuuTaiLieu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuuMinhChung
            // 
            this.btnLuuMinhChung.Location = new System.Drawing.Point(432, 21);
            this.btnLuuMinhChung.Name = "btnLuuMinhChung";
            this.btnLuuMinhChung.Size = new System.Drawing.Size(149, 30);
            this.btnLuuMinhChung.TabIndex = 4;
            this.btnLuuMinhChung.Text = "Lưu Minh Chứng";
            this.btnLuuMinhChung.UseVisualStyleBackColor = true;
            this.btnLuuMinhChung.Click += new System.EventHandler(this.btnLuuMinhChung_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(299, 21);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(127, 30);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu Tài Liệu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnDoc
            // 
            this.btnDoc.Location = new System.Drawing.Point(210, 21);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(83, 30);
            this.btnDoc.TabIndex = 2;
            this.btnDoc.Text = "Đọc";
            this.btnDoc.UseVisualStyleBackColor = true;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(720, 21);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(83, 30);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnBatDau
            // 
            this.btnBatDau.Location = new System.Drawing.Point(102, 21);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(102, 30);
            this.btnBatDau.TabIndex = 1;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnKiemTraLuu);
            this.groupBox1.Controls.Add(this.btnLuuMinhChung);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnBatDau);
            this.groupBox1.Controls.Add(this.btnDoc);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1302, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PDFLuuTaiLieu);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 57);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1302, 584);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tài Liệu";
            // 
            // PDFLuuTaiLieu
            // 
            this.PDFLuuTaiLieu.Dock = System.Windows.Forms.DockStyle.Top;
            this.PDFLuuTaiLieu.Enabled = true;
            this.PDFLuuTaiLieu.Location = new System.Drawing.Point(3, 24);
            this.PDFLuuTaiLieu.Name = "PDFLuuTaiLieu";
            this.PDFLuuTaiLieu.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("PDFLuuTaiLieu.OcxState")));
            this.PDFLuuTaiLieu.Size = new System.Drawing.Size(1296, 554);
            this.PDFLuuTaiLieu.TabIndex = 1;
            // 
            // btnKiemTraLuu
            // 
            this.btnKiemTraLuu.Location = new System.Drawing.Point(587, 21);
            this.btnKiemTraLuu.Name = "btnKiemTraLuu";
            this.btnKiemTraLuu.Size = new System.Drawing.Size(127, 30);
            this.btnKiemTraLuu.TabIndex = 5;
            this.btnKiemTraLuu.Text = "Kiểm Tra Lưu";
            this.btnKiemTraLuu.UseVisualStyleBackColor = true;
            this.btnKiemTraLuu.Click += new System.EventHandler(this.btnKiemTraLuu_Click);
            // 
            // FormLuuTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1302, 653);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLuuTaiLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lưu Tài Liệu";
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PDFLuuTaiLieu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Button btnLuuMinhChung;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private AxAcroPDFLib.AxAcroPDF PDFLuuTaiLieu;
        private System.Windows.Forms.Button btnKiemTraLuu;
    }
}