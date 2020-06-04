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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rvBaoCaoChuongTrinhDaoTao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.QuanLyTieuChuanDanhGiaDataSet = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSet();
            this.KiemDinhChatLuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.KiemDinhChatLuongTableAdapter = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSetTableAdapters.KiemDinhChatLuongTableAdapter();
            this.BaoCaoChuongTrinhDaoTaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BaoCaoChuongTrinhDaoTaoTableAdapter = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSetTableAdapters.BaoCaoChuongTrinhDaoTaoTableAdapter();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KiemDinhChatLuongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoChuongTrinhDaoTaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rvBaoCaoChuongTrinhDaoTao);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 675);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo Cáo";
            // 
            // rvBaoCaoChuongTrinhDaoTao
            // 
            this.rvBaoCaoChuongTrinhDaoTao.Dock = System.Windows.Forms.DockStyle.Top;
            reportDataSource1.Name = "DataSetBaoCaoChuongTrinhDaoTao";
            reportDataSource1.Value = this.BaoCaoChuongTrinhDaoTaoBindingSource;
            this.rvBaoCaoChuongTrinhDaoTao.LocalReport.DataSources.Add(reportDataSource1);
            this.rvBaoCaoChuongTrinhDaoTao.LocalReport.ReportEmbeddedResource = "KiemDinhChatLuongGUI.ChuongTrinhDaoTao.rdlc";
            this.rvBaoCaoChuongTrinhDaoTao.Location = new System.Drawing.Point(3, 24);
            this.rvBaoCaoChuongTrinhDaoTao.Name = "rvBaoCaoChuongTrinhDaoTao";
            this.rvBaoCaoChuongTrinhDaoTao.ServerReport.BearerToken = null;
            this.rvBaoCaoChuongTrinhDaoTao.Size = new System.Drawing.Size(1226, 645);
            this.rvBaoCaoChuongTrinhDaoTao.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 681);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 72);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1053, 27);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(81, 33);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // QuanLyTieuChuanDanhGiaDataSet
            // 
            this.QuanLyTieuChuanDanhGiaDataSet.DataSetName = "QuanLyTieuChuanDanhGiaDataSet";
            this.QuanLyTieuChuanDanhGiaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KiemDinhChatLuongBindingSource
            // 
            this.KiemDinhChatLuongBindingSource.DataMember = "KiemDinhChatLuong";
            this.KiemDinhChatLuongBindingSource.DataSource = this.QuanLyTieuChuanDanhGiaDataSet;
            // 
            // KiemDinhChatLuongTableAdapter
            // 
            this.KiemDinhChatLuongTableAdapter.ClearBeforeFill = true;
            // 
            // BaoCaoChuongTrinhDaoTaoBindingSource
            // 
            this.BaoCaoChuongTrinhDaoTaoBindingSource.DataMember = "BaoCaoChuongTrinhDaoTao";
            this.BaoCaoChuongTrinhDaoTaoBindingSource.DataSource = this.QuanLyTieuChuanDanhGiaDataSet;
            // 
            // BaoCaoChuongTrinhDaoTaoTableAdapter
            // 
            this.BaoCaoChuongTrinhDaoTaoTableAdapter.ClearBeforeFill = true;
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
            this.Text = "Báo Cáo Chương Trình Đào Tạo";
            this.Load += new System.EventHandler(this.FormBaoCaoChuongTrinhDaoTao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KiemDinhChatLuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoChuongTrinhDaoTaoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDong;
        private Microsoft.Reporting.WinForms.ReportViewer rvBaoCaoChuongTrinhDaoTao;
        private System.Windows.Forms.BindingSource KiemDinhChatLuongBindingSource;
        private QuanLyTieuChuanDanhGiaDataSet QuanLyTieuChuanDanhGiaDataSet;
        private QuanLyTieuChuanDanhGiaDataSetTableAdapters.KiemDinhChatLuongTableAdapter KiemDinhChatLuongTableAdapter;
        private System.Windows.Forms.BindingSource BaoCaoChuongTrinhDaoTaoBindingSource;
        private QuanLyTieuChuanDanhGiaDataSetTableAdapters.BaoCaoChuongTrinhDaoTaoTableAdapter BaoCaoChuongTrinhDaoTaoTableAdapter;
    }
}