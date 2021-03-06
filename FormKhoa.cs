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
    public partial class FormKhoa : Form
    { 
        BindingSource KhoaList = new BindingSource();

        public FormKhoa()
        {
            InitializeComponent();
            dgvKhoa.DataSource = KhoaList;                     
            txtMaKhoa.Enabled = false;
            txtTenKhoa.Enabled = false;            
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void LoadListKhoa()
        {
            dgvKhoa.DataSource = KhoaBUS.Instance.GetListKhoa();
            dgvKhoa.Columns[0].Visible = false;
            dgvKhoa.Columns[1].HeaderText = "Mã Khoa";
            dgvKhoa.Columns[2].HeaderText = "Tên Khoa";
            dgvKhoa.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvKhoa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
            dgvKhoa.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvKhoa.AutoGenerateColumns = false;

            dgvKhoa.EnableHeadersVisualStyles = false;
            dgvKhoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }               

        void KhoaBinding()
        {
            txtMaKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Clear();            
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";            
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtMaKhoa.Enabled = true;
            txtTenKhoa.Enabled = true;            
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListKhoa();
        }

        private event EventHandler insertKhoa;
        public event EventHandler InsertKhoa
        {
            add { insertKhoa += value; }
            remove { insertKhoa -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string makhoa = txtMaKhoa.Text;
            string tenkhoa = txtTenKhoa.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Focus();
                return;
            }
            else if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
                return;
            }
            else if (txtMaKhoa.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.Khoa K WHERE K.MaKhoa = N'{0}'", makhoa);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã khoa đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoa.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm khoa này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (KhoaBUS.Instance.InsertKhoa( makhoa, tenkhoa,ghichu))
                {
                    MessageBox.Show("Thêm khoa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertKhoa != null)
                    {
                        insertKhoa(this, new EventArgs());
                    }
                    KhoaBinding();
                    LoadListKhoa();
                    ResetGiaTri();                    
                }
                else
                {
                    MessageBox.Show("Thêm khoa thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";            
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private event EventHandler deleteKhoa;
        public event EventHandler DeleteKhoa
        {
            add { deleteKhoa += value; }
            remove { deleteKhoa -= value; }
        }          
      
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa khoa này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {               
                if (txtMaKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoa.Focus();
                    return;
                }
                else if (txtTenKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKhoa.Focus();
                    return;
                }
                else
                {
                    string makhoa = txtMaKhoa.Text;
                    string tenkhoa = txtTenKhoa.Text;
                    string ghichu = txtGhiChu.Text;                    
                    string sql = string.Format("SELECT ID_Khoa FROM dbo.Khoa K WHERE K.MaKhoa = N'{0}'", makhoa);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_khoa = Int32.Parse(input);

                    if (KhoaBUS.Instance.UpdateKhoa(id_khoa, makhoa, tenkhoa, ghichu))
                    {
                        MessageBox.Show("Sửa khoa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateKhoa != null)
                        {
                            updateKhoa(this, new EventArgs());
                        }
                        KhoaBinding();
                        LoadListKhoa();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa khoa thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler updateKhoa;
        public event EventHandler UpdateKhoa
        {
            add { updateKhoa += value; }
            remove { updateKhoa -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string makhoa = txtMaKhoa.Text;
            string sql = string.Format("SELECT ID_Khoa FROM dbo.Khoa K WHERE K.MaKhoa = N'{0}'", makhoa);
            string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
            int id_khoa = Int32.Parse(input);

            if (MessageBox.Show("Bạn có muốn xóa khoa này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoa.Focus();
                    return;
                }

                string sql_1 = string.Format("SELECT * FROM dbo.Nganh N WHERE N.ID_Khoa = N'{0}'", id_khoa);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql_1))
                {
                    MessageBox.Show("Đang tồn tại Ngành liên kết với Khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                { 
                    if (KhoaBUS.Instance.DeleteKhoa(id_khoa))
                    {
                        MessageBox.Show("Xóa khoa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteKhoa != null)
                        {
                            deleteKhoa(this, new EventArgs());
                        }
                        KhoaBinding();
                        LoadListKhoa();
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
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            dgvKhoa.DataSource = KhoaBUS.Instance.SearchListKhoa(timkiem);
            dgvKhoa.Columns[0].Visible = false;
            dgvKhoa.Columns[1].HeaderText = "Mã Khoa";
            dgvKhoa.Columns[2].HeaderText = "Tên Khoa";
            dgvKhoa.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvKhoa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvKhoa.AutoGenerateColumns = false;

            dgvKhoa.EnableHeadersVisualStyles = false;
            dgvKhoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            KhoaBinding();
            ResetGiaTri();
        }
    }
}
