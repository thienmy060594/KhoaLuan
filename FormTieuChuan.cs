﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiemDinhChatLuongDTO;
using KiemDinhChatLuongBUS;
using KiemDinhChatLuongDAL;

namespace KiemDinhChatLuongGUI
{
    public partial class FormTieuChuan : Form
    {

        BindingSource TieuChuanList = new BindingSource();

        public FormTieuChuan()
        {
            InitializeComponent();
            dgvTieuChuan.DataSource = TieuChuanList;                       
            txtMaTieuChuan.Enabled = false;
            txtTenTieuChuan.Enabled = false;
            txtNoiDungTieuChuan.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void LoadListTieuChuan()
        {          
            dgvTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            dgvTieuChuan.Columns[0].Visible = false;
            dgvTieuChuan.Columns[1].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChuan.Columns[2].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChuan.Columns[3].HeaderText = "Nội Dung Tiêu Chuẩn";
            dgvTieuChuan.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột                 
            dgvTieuChuan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;           
            dgvTieuChuan.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChuan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvTieuChuan.AutoGenerateColumns = false;                             
         
            dgvTieuChuan.EnableHeadersVisualStyles = false;
            dgvTieuChuan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;         
        }                

        void TieuChuanBinding()
        {
            txtMaTieuChuan.DataBindings.Clear();
            txtTenTieuChuan.DataBindings.Clear();
            txtNoiDungTieuChuan.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        // nút bắt đầu các chức năng
        private void btnBatDau_Click_1(object sender, EventArgs e)
        {
            txtMaTieuChuan.Text = "";
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtMaTieuChuan.Enabled = true;
            txtTenTieuChuan.Enabled = true;
            txtNoiDungTieuChuan.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListTieuChuan();
        }

        private event EventHandler insertTieuChuan;
        public event EventHandler InsertTieuChuan
        {
            add { insertTieuChuan += value; }
            remove { insertTieuChuan -= value; }
        }

        //thêm mới một tiêu chuẩn
        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTieuChuan.Focus();
                return;
            }
            else if (txtTenTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChuan.Focus();
                return;
            }
            else if (txtNoiDungTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChuan.Focus();
                return;
            }
            else if (txtMaTieuChuan.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.TieuChuan TChuan WHERE TChuan.MaTieuChuan = N'{0}'", matieuchuan);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã tiêu chuẩn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChuan.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChuanBUS.Instance.InsertTieuChuan(matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }
                    TieuChuanBinding();
                    LoadListTieuChuan();                    
                    ResetGiaTri();                                     
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaTieuChuan.Text = "";
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }                  

        private event EventHandler updateTieuChuan;
        public event EventHandler UpdateTieuChuan
        {
            add { updateTieuChuan += value; }
            remove { updateTieuChuan -= value; }
        }                 
      
        private void btnSua_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChu.Text;           

            if (MessageBox.Show("Bạn có muốn sửa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {               
                if (txtMaTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChuan.Focus();
                    return;
                }
                else if (txtTenTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChuan.Focus();
                    return;
                }
                else if (txtNoiDungTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChuan.Focus();
                    return;
                }
                else
                {
                    string sql = string.Format("SELECT ID_TieuChuan FROM dbo.TieuChuan TChuan WHERE TChuan.MaTieuChuan = N'{0}'", matieuchuan);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tieuchuan = Int32.Parse(input);

                    if (TieuChuanBUS.Instance.UpdateTieuChuan(id_tieuchuan, matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                    {
                        MessageBox.Show("Sửa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateTieuChuan != null)
                        {
                            updateTieuChuan(this, new EventArgs());
                        }
                        TieuChuanBinding();
                        LoadListTieuChuan();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteTieuChuan;
        public event EventHandler DeleteTieuChuan
        {
            add { deleteTieuChuan += value; }
            remove { deleteTieuChuan -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string sql = string.Format("SELECT ID_TieuChuan FROM dbo.TieuChuan TChuan WHERE TChuan.MaTieuChuan = N'{0}'", matieuchuan);
            string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
            int id_tieuchuan = Int32.Parse(input);

            if (MessageBox.Show("Bạn có muốn xóa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChuan.Focus();
                    return;
                }

                string sql_1 = string.Format("SELECT * FROM dbo.TieuChi TChi WHERE TChi.ID_TieuChuan = N'{0}'", id_tieuchuan);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql_1))
                {
                    MessageBox.Show("Đang tồn tại Tiêu chí liên kết với Tiêu Chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TieuChuanBUS.Instance.DeleteTieuChuan(id_tieuchuan))
                    {
                        MessageBox.Show("Xóa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteTieuChuan != null)
                        {
                            deleteTieuChuan(this, new EventArgs());
                        }
                        TieuChuanBinding();
                        LoadListTieuChuan();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }                
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTri();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;
            if(txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            dgvTieuChuan.DataSource = TieuChuanBUS.Instance.SearchListTieuChuan(timkiem);
            dgvTieuChuan.Columns[0].Visible = false;
            dgvTieuChuan.Columns[1].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChuan.Columns[2].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChuan.Columns[3].HeaderText = "Nội Dung Tiêu Chuẩn";
            dgvTieuChuan.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột                 
            dgvTieuChuan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChuan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvTieuChuan.AutoGenerateColumns = false;

            dgvTieuChuan.EnableHeadersVisualStyles = false;
            dgvTieuChuan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            TieuChuanBinding();            
            ResetGiaTri();
        }
    }
}

          


       


