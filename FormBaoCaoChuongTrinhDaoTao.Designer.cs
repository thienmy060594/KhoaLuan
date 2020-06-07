namespace KiemDinhChatLuongGUI
{
    partial class FormBaoCaoChuongTrinhDaoTao
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
            this.QuanLyTieuChuanDanhGiaDataSet = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvChuongTrinhDaoTao = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuanLyTieuChuanDanhGiaDataSet
            // 
            this.QuanLyTieuChuanDanhGiaDataSet.DataSetName = "QuanLyTieuChuanDanhGiaDataSet";
            this.QuanLyTieuChuanDanhGiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(108, 23);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 30);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvChuongTrinhDaoTao);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 682);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Báo Cáo";
            // 
            // rvChuongTrinhDaoTao
            // 
            this.rvChuongTrinhDaoTao.Dock = System.Windows.Forms.DockStyle.Top;
            this.rvChuongTrinhDaoTao.Location = new System.Drawing.Point(3, 24);
            this.rvChuongTrinhDaoTao.Name = "rvChuongTrinhDaoTao";
            this.rvChuongTrinhDaoTao.ServerReport.BearerToken = null;
            this.rvChuongTrinhDaoTao.Size = new System.Drawing.Size(1226, 652);
            this.rvChuongTrinhDaoTao.TabIndex = 0;
            // 
            // FormBaoCaoChuongTrinhDaoTao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBaoCaoChuongTrinhDaoTao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Chương Trình Đào Tạo";
            this.Load += new System.EventHandler(this.FormBaoCaoChuongTrinhDaoTao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private QuanLyTieuChuanDanhGiaDataSet QuanLyTieuChuanDanhGiaDataSet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvChuongTrinhDaoTao;
        private System.Windows.Forms.Button btnDong;
    }
}