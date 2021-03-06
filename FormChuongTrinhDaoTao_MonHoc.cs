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
    public partial class FormChuongTrinhDaoTao_MonHoc : Form
    {
        BindingSource ChuongTrinhDaoTao_MonHocList = new BindingSource();
        public FormChuongTrinhDaoTao_MonHoc()
        {
            InitializeComponent();
            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocList;                      
            txtHocKy.Enabled = false;
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
            DataGridViewCell cell1 = dgvChuongTrinhDaoTaoMonHoc[column, row];
            DataGridViewCell cell2 = dgvChuongTrinhDaoTaoMonHoc[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvChuongTrinhDaoTaoMonHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvChuongTrinhDaoTaoMonHoc.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvChuongTrinhDaoTaoMonHoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListChuongTrinhDaoTao_MonHoc()
        {
            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocBUS.Instance.GetListChuongTrinhDaoTao_MonHoc();
            dgvChuongTrinhDaoTaoMonHoc.Columns[0].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[1].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[2].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].HeaderText = "Mã Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].HeaderText = "Tên Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].HeaderText = "Mã Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].HeaderText = "Tên Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].HeaderText = "Học Kỳ";
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTaoMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp 
            dgvChuongTrinhDaoTaoMonHoc.AutoGenerateColumns = false;

            dgvChuongTrinhDaoTaoMonHoc.EnableHeadersVisualStyles = false;
            dgvChuongTrinhDaoTaoMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }             

        void ChuongTrinhDaoTao_MonHocBinding()
        {
            txtHocKy.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtHocKy.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtHocKy.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListChuongTrinhDaoTao_MonHoc();
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "ID_ChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "MaChuongTrinhDaoTao";
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxLoaiMon.DataSource = LoaiMonBUS.Instance.GetListLoaiMon();
            cbxLoaiMon.ValueMember = "ID_LoaiMon";
            cbxLoaiMon.DisplayMember = "TenLoaiMon";
        }

        private event EventHandler insertChuongTrinhDaoTao_MonHoc;
        public event EventHandler InsertChuongTrinhDaoTao_MonHoc
        {
            add { insertChuongTrinhDaoTao_MonHoc += value; }
            remove { insertChuongTrinhDaoTao_MonHoc -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string hocky = txtHocKy.Text;
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
            int id_chuongtrinhdaotao = Int32.Parse(input_1);
            string input_2 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
            int id_monhoc = Int32.Parse(input_2);
            string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
            int id_loaimon = Int32.Parse(input_3);

            if (MessageBox.Show("Bạn có muốn thêm chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ChuongTrinhDaoTao_MonHocBUS.Instance.InsertChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu))
                {
                    MessageBox.Show("Thêm chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertChuongTrinhDaoTao_MonHoc != null)
                    {
                        insertChuongTrinhDaoTao_MonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTao_MonHocBinding();
                    LoadListChuongTrinhDaoTao_MonHoc();
                    ResetGiaTri();                    
                }
                else
                {
                    MessageBox.Show("Thêm chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtHocKy.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private event EventHandler updateChuongTrinhDaoTao_MonHoc;
        public event EventHandler UpdateChuongTrinhDaoTao_MonHoc
        {
            add { updateChuongTrinhDaoTao_MonHoc += value; }
            remove { updateChuongTrinhDaoTao_MonHoc -= value; }
        }
       
        private void btnSua_Click(object sender, EventArgs e)
        {       
            if (MessageBox.Show("Bạn có muốn sửa chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string hocky = txtHocKy.Text;
                string ghichu = txtGhiChu.Text;
                string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
                int id_chuongtrinhdaotao = Int32.Parse(input_1);
                string input_2 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
                int id_monhoc = Int32.Parse(input_2);
                string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
                int id_loaimon = Int32.Parse(input_3);

                if (ChuongTrinhDaoTao_MonHocBUS.Instance.UpdateChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu))
                {
                    MessageBox.Show("Sửa chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateChuongTrinhDaoTao_MonHoc != null)
                    {
                        updateChuongTrinhDaoTao_MonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTao_MonHocBinding();
                    LoadListChuongTrinhDaoTao_MonHoc();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteChuongTrinhDaoTao_MonHoc;
        public event EventHandler DeleteChuongTrinhDaoTao_MonHoc
        {
            add { deleteChuongTrinhDaoTao_MonHoc += value; }
            remove { deleteChuongTrinhDaoTao_MonHoc -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
                int id_chuongtrinhdaotao = Int32.Parse(input_1);
                string input_2 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
                int id_monhoc = Int32.Parse(input_2);
                string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
                int id_loaimon = Int32.Parse(input_3);

                if (ChuongTrinhDaoTao_MonHocBUS.Instance.DeleteChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon))
                {
                    MessageBox.Show("Xóa chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteChuongTrinhDaoTao_MonHoc != null)
                    {
                        deleteChuongTrinhDaoTao_MonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTao_MonHocBinding();
                    LoadListChuongTrinhDaoTao_MonHoc();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Xóa chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocBUS.Instance.SearchListChuongTrinhDaoTao_MonHoc(timkiem);
            dgvChuongTrinhDaoTaoMonHoc.Columns[0].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[1].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[2].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].HeaderText = "Mã Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].HeaderText = "Tên Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].HeaderText = "Mã Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].HeaderText = "Tên Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].HeaderText = "Học Kỳ";
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTaoMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp 
            dgvChuongTrinhDaoTaoMonHoc.AutoGenerateColumns = false;

            dgvChuongTrinhDaoTaoMonHoc.EnableHeadersVisualStyles = false;
            dgvChuongTrinhDaoTaoMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            ChuongTrinhDaoTao_MonHocBinding();
            ResetGiaTri();
        }        
    }
}
