﻿namespace KiemDinhChatLuongGUI
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
            this.KiemDinhChatLuongBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyTieuChuanDanhGiaDataSet = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSet();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rvBaoCaoKiemDinhChatLuong = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.KiemDinhChatLuongTableAdapter = new KiemDinhChatLuongGUI.QuanLyTieuChuanDanhGiaDataSetTableAdapters.KiemDinhChatLuongTableAdapter();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rvBaoCaoKiemDinhChatLuong);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1232, 685);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo Cáo";
            // 
            // rvBaoCaoKiemDinhChatLuong
            // 
            this.rvBaoCaoKiemDinhChatLuong.Dock = System.Windows.Forms.DockStyle.Top;
            reportDataSource2.Name = "DataSetKiemDinhChatLuong";
            reportDataSource2.Value = this.KiemDinhChatLuongBindingSource;
            this.rvBaoCaoKiemDinhChatLuong.LocalReport.DataSources.Add(reportDataSource2);
            this.rvBaoCaoKiemDinhChatLuong.LocalReport.ReportEmbeddedResource = "KiemDinhChatLuongGUI.BaoCaoKiemDinhChatLuong.rdlc";
            this.rvBaoCaoKiemDinhChatLuong.Location = new System.Drawing.Point(3, 24);
            this.rvBaoCaoKiemDinhChatLuong.Name = "rvBaoCaoKiemDinhChatLuong";
            this.rvBaoCaoKiemDinhChatLuong.ServerReport.BearerToken = null;
            this.rvBaoCaoKiemDinhChatLuong.Size = new System.Drawing.Size(1226, 655);
            this.rvBaoCaoKiemDinhChatLuong.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDong);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 691);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1232, 62);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1031, 17);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(81, 33);
            this.btnDong.TabIndex = 0;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // KiemDinhChatLuongTableAdapter
            // 
            this.KiemDinhChatLuongTableAdapter.ClearBeforeFill = true;
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
            this.Text = "Báo Cáo Kiểm Định Chất Lượng";
            this.Load += new System.EventHandler(this.FormBaoCaoKiemDinhChatLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.KiemDinhChatLuongBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyTieuChuanDanhGiaDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Microsoft.Reporting.WinForms.ReportViewer rvBaoCaoKiemDinhChatLuong;
        private System.Windows.Forms.BindingSource KiemDinhChatLuongBindingSource;
        private QuanLyTieuChuanDanhGiaDataSet QuanLyTieuChuanDanhGiaDataSet;
        private QuanLyTieuChuanDanhGiaDataSetTableAdapters.KiemDinhChatLuongTableAdapter KiemDinhChatLuongTableAdapter;
        private System.Windows.Forms.Button btnDong;
    }
}