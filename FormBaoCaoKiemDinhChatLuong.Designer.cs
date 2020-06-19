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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.BaoCaoKiemDinhChatLuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBaoCaoKiemDinhChatLuong = new KiemDinhChatLuongGUI.DataSetBaoCaoKiemDinhChatLuong();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.cbxTieuChuan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvKiemDinhChatLuong = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BaoCaoKiemDinhChatLuongTableAdapter = new KiemDinhChatLuongGUI.DataSetBaoCaoKiemDinhChatLuongTableAdapters.BaoCaoKiemDinhChatLuongTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoKiemDinhChatLuongBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBaoCaoKiemDinhChatLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaoCaoKiemDinhChatLuongBindingSource
            // 
            this.BaoCaoKiemDinhChatLuongBindingSource.DataMember = "BaoCaoKiemDinhChatLuong";
            this.BaoCaoKiemDinhChatLuongBindingSource.DataSource = this.DataSetBaoCaoKiemDinhChatLuong;
            // 
            // DataSetBaoCaoKiemDinhChatLuong
            // 
            this.DataSetBaoCaoKiemDinhChatLuong.DataSetName = "DataSetBaoCaoKiemDinhChatLuong";
            this.DataSetBaoCaoKiemDinhChatLuong.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThucHien);
            this.groupBox1.Controls.Add(this.cbxTieuChuan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(447, 19);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(106, 30);
            this.btnThucHien.TabIndex = 3;
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // cbxTieuChuan
            // 
            this.cbxTieuChuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTieuChuan.FormattingEnabled = true;
            this.cbxTieuChuan.Location = new System.Drawing.Point(171, 21);
            this.cbxTieuChuan.Name = "cbxTieuChuan";
            this.cbxTieuChuan.Size = new System.Drawing.Size(245, 28);
            this.cbxTieuChuan.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tiêu Chuẩn";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(559, 19);
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
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 695);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Báo Cáo";
            // 
            // rvKiemDinhChatLuong
            // 
            this.rvKiemDinhChatLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetBaoCaoKiemDinhChatLuong";
            reportDataSource2.Value = this.BaoCaoKiemDinhChatLuongBindingSource;
            this.rvKiemDinhChatLuong.LocalReport.DataSources.Add(reportDataSource2);
            this.rvKiemDinhChatLuong.LocalReport.ReportEmbeddedResource = "KiemDinhChatLuongGUI.BaoCaoKiemDinhChatLuong.rdlc";
            this.rvKiemDinhChatLuong.Location = new System.Drawing.Point(3, 24);
            this.rvKiemDinhChatLuong.Name = "rvKiemDinhChatLuong";
            this.rvKiemDinhChatLuong.ServerReport.BearerToken = null;
            this.rvKiemDinhChatLuong.Size = new System.Drawing.Size(1226, 668);
            this.rvKiemDinhChatLuong.TabIndex = 0;
            // 
            // BaoCaoKiemDinhChatLuongTableAdapter
            // 
            this.BaoCaoKiemDinhChatLuongTableAdapter.ClearBeforeFill = true;
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
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBaoCaoKiemDinhChatLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoKiemDinhChatLuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBaoCaoKiemDinhChatLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvKiemDinhChatLuong;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.ComboBox cbxTieuChuan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource BaoCaoKiemDinhChatLuongBindingSource;
        private DataSetBaoCaoKiemDinhChatLuong DataSetBaoCaoKiemDinhChatLuong;
        private DataSetBaoCaoKiemDinhChatLuongTableAdapters.BaoCaoKiemDinhChatLuongTableAdapter BaoCaoKiemDinhChatLuongTableAdapter;
    }
}