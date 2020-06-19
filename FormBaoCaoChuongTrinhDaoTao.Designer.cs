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
            this.BaoCaoChuongTrinhDaoTaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetBaoCaoChuongTrinhDaoTao = new KiemDinhChatLuongGUI.DataSetBaoCaoChuongTrinhDaoTao();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThucHien = new System.Windows.Forms.Button();
            this.cbxChuongTrinhDaoTao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rvChuongTrinhDaoTao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BaoCaoChuongTrinhDaoTaoTableAdapter = new KiemDinhChatLuongGUI.DataSetBaoCaoChuongTrinhDaoTaoTableAdapters.BaoCaoChuongTrinhDaoTaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoChuongTrinhDaoTaoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBaoCaoChuongTrinhDaoTao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaoCaoChuongTrinhDaoTaoBindingSource
            // 
            this.BaoCaoChuongTrinhDaoTaoBindingSource.DataMember = "BaoCaoChuongTrinhDaoTao";
            this.BaoCaoChuongTrinhDaoTaoBindingSource.DataSource = this.DataSetBaoCaoChuongTrinhDaoTao;
            // 
            // DataSetBaoCaoChuongTrinhDaoTao
            // 
            this.DataSetBaoCaoChuongTrinhDaoTao.DataSetName = "DataSetBaoCaoChuongTrinhDaoTao";
            this.DataSetBaoCaoChuongTrinhDaoTao.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThucHien);
            this.groupBox1.Controls.Add(this.cbxChuongTrinhDaoTao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnDong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chức Năng";
            // 
            // btnThucHien
            // 
            this.btnThucHien.Location = new System.Drawing.Point(642, 22);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(106, 30);
            this.btnThucHien.TabIndex = 7;
            this.btnThucHien.Text = "Thực Hiện";
            this.btnThucHien.UseVisualStyleBackColor = true;
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // cbxChuongTrinhDaoTao
            // 
            this.cbxChuongTrinhDaoTao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxChuongTrinhDaoTao.FormattingEnabled = true;
            this.cbxChuongTrinhDaoTao.Location = new System.Drawing.Point(236, 24);
            this.cbxChuongTrinhDaoTao.Name = "cbxChuongTrinhDaoTao";
            this.cbxChuongTrinhDaoTao.Size = new System.Drawing.Size(375, 28);
            this.cbxChuongTrinhDaoTao.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chương Trình Đào Tạo";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(754, 22);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(85, 30);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rvChuongTrinhDaoTao);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 77);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 676);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Báo Cáo";
            // 
            // rvChuongTrinhDaoTao
            // 
            this.rvChuongTrinhDaoTao.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetBaoCaoChuongTrinhDaoTao";
            reportDataSource1.Value = this.BaoCaoChuongTrinhDaoTaoBindingSource;
            this.rvChuongTrinhDaoTao.LocalReport.DataSources.Add(reportDataSource1);
            this.rvChuongTrinhDaoTao.LocalReport.ReportEmbeddedResource = "KiemDinhChatLuongGUI.BaoCaoChuongTrinhDaoTao.rdlc";
            this.rvChuongTrinhDaoTao.Location = new System.Drawing.Point(3, 24);
            this.rvChuongTrinhDaoTao.Name = "rvChuongTrinhDaoTao";
            this.rvChuongTrinhDaoTao.ServerReport.BearerToken = null;
            this.rvChuongTrinhDaoTao.Size = new System.Drawing.Size(1226, 649);
            this.rvChuongTrinhDaoTao.TabIndex = 0;
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Chương Trình Đào Tạo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormBaoCaoChuongTrinhDaoTao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoChuongTrinhDaoTaoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetBaoCaoChuongTrinhDaoTao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion       
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvChuongTrinhDaoTao;
        private System.Windows.Forms.Button btnThucHien;
        private System.Windows.Forms.ComboBox cbxChuongTrinhDaoTao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.BindingSource BaoCaoChuongTrinhDaoTaoBindingSource;
        private DataSetBaoCaoChuongTrinhDaoTao DataSetBaoCaoChuongTrinhDaoTao;
        private DataSetBaoCaoChuongTrinhDaoTaoTableAdapters.BaoCaoChuongTrinhDaoTaoTableAdapter BaoCaoChuongTrinhDaoTaoTableAdapter;
    }
}