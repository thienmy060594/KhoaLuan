﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiemDinhChatLuongBUS;
using KiemDinhChatLuongDAL;
using KiemDinhChatLuongDTO;

namespace KiemDinhChatLuongGUI
{
    public partial class FormMocThamChieu : Form
    {
        BindingSource MocThamChieuList = new BindingSource();
        public FormMocThamChieu()
        {
            InitializeComponent();
            dgvMocThamChieu.DataSource = MocThamChieuList;                      
            txtMaMocThamChieu.Enabled = false;
            txtNoiDungMocThamChieu.Enabled = false;
            txtTenMocThamChieu.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void LoadListMocThamChieu()
        {
            dgvMocThamChieu.DataSource = MocThamChieuBUS.Instance.GetListMocThamChieu();
            dgvMocThamChieu.Columns[0].Visible = false;
            dgvMocThamChieu.Columns[1].HeaderText = "Mã Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[2].HeaderText = "Tên Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[3].HeaderText = "Nội Dung Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMocThamChieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMocThamChieu.AllowUserToAddRows = false;
            dgvMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp      
            dgvMocThamChieu.AutoGenerateColumns = false;

            dgvMocThamChieu.EnableHeadersVisualStyles = false;
            dgvMocThamChieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }              

        void MocThamChieuBinding()
        {
            txtMaMocThamChieu.DataBindings.Clear();
            txtNoiDungMocThamChieu.DataBindings.Clear();
            txtTenMocThamChieu.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtNoiDungMocThamChieu.Text = "";            
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtMaMocThamChieu.Enabled = true;            
            txtTenMocThamChieu.Enabled = true;
            txtNoiDungMocThamChieu.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListMocThamChieu();
        }

        private event EventHandler insertMocThamChieu;
        public event EventHandler InsertMocThamChieu
        {
            add { insertMocThamChieu += value; }
            remove { insertMocThamChieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string mamocthamchieu = txtMaMocThamChieu.Text;
            string tenmocthamchieu = txtTenMocThamChieu.Text;
            string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMocThamChieu.Focus();
                return;
            }
            else if (txtTenMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMocThamChieu.Focus();
                return;
            }
            else if (txtNoiDungMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungMocThamChieu.Focus();
                return;
            }
            else if (txtMaMocThamChieu.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.MocThamChieu MTChieu WHERE MTChieu.MaMocThamChieu = N'{0}'", mamocthamchieu);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã mốc tham chiếu đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMocThamChieu.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm mới mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MocThamChieuBUS.Instance.InsertMocThamChieu(mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMocThamChieu != null)
                    {
                        insertMocThamChieu(this, new EventArgs());
                    }                    
                    MocThamChieuBinding();
                    LoadListMocThamChieu();
                    ResetGiaTri();                                        
                }
                else
                {
                    MessageBox.Show("Thêm mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaMocThamChieu.Text = "";
            txtNoiDungMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private event EventHandler updateMocThamChieu;
        public event EventHandler UpdateMocThamChieu
        {
            add { updateMocThamChieu += value; }
            remove { updateMocThamChieu -= value; }
        }        

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa mốc tham chiếu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {           
                if (txtMaMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMocThamChieu.Focus();
                    return;
                }
                else if (txtTenMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMocThamChieu.Focus();
                    return;
                }
                else if (txtNoiDungMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMocThamChieu.Focus();
                    return;
                }
                else
                {
                    string mamocthamchieu = txtMaMocThamChieu.Text;
                    string tenmocthamchieu = txtTenMocThamChieu.Text;
                    string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_MocThamChieu FROM dbo.MocthamChieu MTChieu WHERE MTChieu.MaMocThamChieu = N'{0}'", mamocthamchieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_mocthamchieu = Int32.Parse(input);

                    if (MocThamChieuBUS.Instance.UpdateMocThamChieu(id_mocthamchieu, mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                    {
                        MessageBox.Show("Sửa mốc tham chiếu  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateMocThamChieu != null)
                        {
                            updateMocThamChieu(this, new EventArgs());
                        }
                        MocThamChieuBinding();
                        LoadListMocThamChieu();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa mốc tham chiếu  thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteMocThamChieu;
        public event EventHandler DeleteMocThamChieu
        {
            add { deleteMocThamChieu += value; }
            remove { deleteMocThamChieu -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa mốc tham chiếu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMocThamChieu.Focus();
                    return;
                }
                else
                {
                    string mamocthamchieu = txtMaMocThamChieu.Text;
                    string sql = string.Format("SELECT ID_MocThamChieu FROM dbo.MocthamChieu MTChieu WHERE MTChieu.MaMocThamChieu = N'{0}'", mamocthamchieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_mocthamchieu = Int32.Parse(input);

                    if (MocThamChieuBUS.Instance.DeleteMocThamChieu(id_mocthamchieu))
                    {
                        MessageBox.Show("Xóa mốc tham chiếu  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteMocThamChieu != null)
                        {
                            deleteMocThamChieu(this, new EventArgs());
                        }
                        MocThamChieuBinding();
                        LoadListMocThamChieu();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            dgvMocThamChieu.DataSource = MocThamChieuBUS.Instance.SearchListMocThamChieu(timkiem);
            dgvMocThamChieu.Columns[0].Visible = false;
            dgvMocThamChieu.Columns[1].HeaderText = "Mã Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[2].HeaderText = "Tên Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[3].HeaderText = "Nội Dung Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMocThamChieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMocThamChieu.AllowUserToAddRows = false;
            dgvMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp      
            dgvMocThamChieu.AutoGenerateColumns = false;

            dgvMocThamChieu.EnableHeadersVisualStyles = false;
            dgvMocThamChieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            MocThamChieuBinding();
            ResetGiaTri();
        }
    }
}

