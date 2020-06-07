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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.KiemDinhChatLuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyTieuChuanDanhGiaDataSet = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSet();
            this.KiemDinhChatLuongTableAdapter = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSetTableAdapters.KiemDinhChatLuongTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvKiemDinhChatLuong = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.KiemDinhChatLuongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // KiemDinhChatLuongBindingSource
            // 
            this.KiemDinhChatLuongBindingSource.DataMember = "KiemDinhChatLuong";
            this.KiemDinhChatLuongBindingSource.DataSource = this.QuanLyTieuChuanDanhGiaDataSet;
            // 
            // QuanLyTieuChuanDanhGiaDataSet
            // 
            this.QuanLyTieuChuanDanhGiaDataSet.DataSetName = "QuanLyTieuChuanDanhGiaDataSet";
            this.QuanLyTieuChuanDanhGiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KiemDinhChatLuongTableAdapter
            // 
            this.KiemDinhChatLuongTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(96, 22);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 30);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvKiemDinhChatLuong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 683);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Báo Cáo";
            // 
            // rvKiemDinhChatLuong
            // 
            this.rvKiemDinhChatLuong.Dock = System.Windows.Forms.DockStyle.Top;
            reportDataSource1.Name = "DataSetKiemDinhChatLuong";
            reportDataSource1.Value = this.KiemDinhChatLuongBindingSource;
            this.rvKiemDinhChatLuong.LocalReport.DataSources.Add(reportDataSource1);
            this.rvKiemDinhChatLuong.LocalReport.ReportEmbeddedResource = "KiemDinhChatLuongGUI.BaoCaoKiemDinhChatLuong.rdlc";
            this.rvKiemDinhChatLuong.Location = new System.Drawing.Point(3, 24);
            this.rvKiemDinhChatLuong.Name = "rvKiemDinhChatLuong";
            this.rvKiemDinhChatLuong.ServerReport.BearerToken = null;
            this.rvKiemDinhChatLuong.Size = new System.Drawing.Size(1226, 653);
            this.rvKiemDinhChatLuong.TabIndex = 0;
            // 
            // FormBaoCaoKiemDinhChatLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormBaoCaoKiemDinhChatLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Kiểm Định Chất Lượng";
            this.Load += new System.EventHandler(this.FormBaoCaoKiemDinhChatLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KiemDinhChatLuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource KiemDinhChatLuongBindingSource;
        private QuanLyTieuChuanDanhGiaDataSet QuanLyTieuChuanDanhGiaDataSet;
        private QuanLyTieuChuanDanhGiaDataSetTableAdapters.KiemDinhChatLuongTableAdapter KiemDinhChatLuongTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvKiemDinhChatLuong;
        private System.Windows.Forms.Button btnDong;
    }
}