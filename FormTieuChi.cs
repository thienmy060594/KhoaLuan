﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiemDinhChatLuongDTO;
using KiemDinhChatLuongBUS;
using KiemDinhChatLuongDAL;

namespace KiemDinhChatLuongGUI
{
    public partial class FormTieuChi : Form
    {
        BindingSource TieuChiList = new BindingSource();

        public FormTieuChi()
        {
            InitializeComponent();
            dgvTieuChi.DataSource = TieuChiList;            
            txtMaTieuChi.Enabled = false;
            txtTenTieuChi.Enabled = false;
            txtNoiDungTieuChi.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvTieuChi[column, row];
            DataGridViewCell cell2 = dgvTieuChi[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvTieuChi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            { return; }
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvTieuChi.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvTieuChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
            { return; }
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }

        private void LoadListTieuChi()
        {
            dgvTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            dgvTieuChi.Columns[0].Visible = false;
            dgvTieuChi.Columns[1].Visible = false;
            dgvTieuChi.Columns[2].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChi.Columns[3].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChi.Columns[4].HeaderText = "Mã Tiêu Chí";
            dgvTieuChi.Columns[5].HeaderText = "Tên Tiêu Chí";
            dgvTieuChi.Columns[6].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChi.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvTieuChi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChi.AllowUserToAddRows = false;
            dgvTieuChi.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvTieuChi.AutoGenerateColumns = false;

            dgvTieuChi.EnableHeadersVisualStyles = false;
            dgvTieuChi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void TieuChiBinding()
        {
            txtMaTieuChi.DataBindings.Clear();
            txtTenTieuChi.DataBindings.Clear();
            txtNoiDungTieuChi.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click_1(object sender, EventArgs e)
        {
            txtMaTieuChi.Text = "";
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtMaTieuChi.Enabled = true;
            txtTenTieuChi.Enabled = true;
            txtNoiDungTieuChi.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListTieuChi();
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            cbxTieuChuan.ValueMember = "ID_TieuChuan";
            cbxTieuChuan.DisplayMember = "TenTieuChuan";
        }

        private event EventHandler insertTieuChuan;
        public event EventHandler InsertTieuChuan
        {
            add { insertTieuChuan += value; }
            remove { insertTieuChuan -= value; }
        }

        private void btnLuuLai_Click_1(object sender, EventArgs e)
        {
            string matieuchi = txtMaTieuChi.Text;
            string tentieuchi = txtTenTieuChi.Text;
            string noidungtieuchi = txtNoiDungTieuChi.Text;
            string ghichu = txtGhiChu.Text;
            string input = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
            int id_tieuchuan = Int32.Parse(input);

            if (txtMaTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTieuChi.Focus();
                return;
            }
            else if (txtTenTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChi.Focus();
                return;
            }
            else if (txtNoiDungTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChi.Focus();
                return;
            }
            else if (txtMaTieuChi.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã tiêu chí đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChiBUS.Instance.InsertTieuChi(id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }
                    TieuChiBinding();
                    LoadListTieuChi();
                    ResetGiaTri();                    
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaTieuChi.Text = "";
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private event EventHandler updateTieuChi;
        public event EventHandler UpdateTieuChi
        {
            add { updateTieuChi += value; }
            remove { updateTieuChi -= value; }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn sửa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
                else if (txtTenTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChi.Focus();
                    return;
                }
                else if (txtNoiDungTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChi.Focus();
                    return;

                }
                else
                {
                    string matieuchi = txtMaTieuChi.Text;
                    string tentieuchi = txtTenTieuChi.Text;
                    string noidungtieuchi = txtNoiDungTieuChi.Text;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
                    int id_tieuchuan = Int32.Parse(input_1);
                    string sql = string.Format("SELECT ID_TieuChi FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tieuchi = Int32.Parse(input);

                    if (TieuChiBUS.Instance.UpdateTieuChi(id_tieuchi, id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu))
                    {
                        MessageBox.Show("Sửa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateTieuChi != null)
                        {
                            updateTieuChi(this, new EventArgs());
                        }
                        TieuChiBinding();
                        LoadListTieuChi();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
        }

        private event EventHandler deleteTieuChi;
        public event EventHandler DeleteTieuChi
        {
            add { deleteTieuChi += value; }
            remove { deleteTieuChi -= value; }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
                else
                {
                    string matieuchi = txtMaTieuChi.Text;
                    string sql = string.Format("SELECT ID_TieuChi FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tieuchi = Int32.Parse(input);

                    if (TieuChiBUS.Instance.DeleteTieuChi(id_tieuchi))
                    {
                        MessageBox.Show("Xóa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteTieuChi != null)
                        {
                            deleteTieuChi(this, new EventArgs());
                        }
                        TieuChiBinding();
                        LoadListTieuChi();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            ResetGiaTri();
        }

        private void btnDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            dgvTieuChi.DataSource = TieuChiBUS.Instance.SearchListTieuChi(timkiem);
            dgvTieuChi.Columns[0].Visible = false;
            dgvTieuChi.Columns[1].Visible = false;
            dgvTieuChi.Columns[2].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChi.Columns[3].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChi.Columns[4].HeaderText = "Mã Tiêu Chí";
            dgvTieuChi.Columns[5].HeaderText = "Tên Tiêu Chí";
            dgvTieuChi.Columns[6].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChi.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvTieuChi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChi.AllowUserToAddRows = false;
            dgvTieuChi.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvTieuChi.AutoGenerateColumns = false;

            dgvTieuChi.EnableHeadersVisualStyles = false;
            dgvTieuChi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            TieuChiBinding();
            ResetGiaTri();
        }
    }
}

        
