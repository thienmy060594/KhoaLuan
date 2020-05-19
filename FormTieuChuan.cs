using System;
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
using Microsoft.VisualBasic;

namespace KiemDinhChatLuongGUI
{
    public partial class FormTieuChuan : Form
    {

        BindingSource TieuChuanList = new BindingSource();

        public FormTieuChuan()
        {
            InitializeComponent();
            dgvTieuChuan.DataSource = TieuChuanList;
            LoadListTieuChuan();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtNoiDungTieuChuan.Enabled = false;
            txtTenTieuChuan.Enabled = false;
            txtGhiChu.Enabled = false;

        }

        private void LoadListTieuChuan()
        {
            dgvTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            dgvTieuChuan.Columns[0].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChuan.Columns[1].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChuan.Columns[2].HeaderText = "Nội Dung Tiêu Chuẩn";
            dgvTieuChuan.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột        
            dgvTieuChuan.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChuan.AllowUserToAddRows = false;
            dgvTieuChuan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void TieuChuanBinding()
        {            
            txtTenTieuChuan.DataBindings.Clear();
            txtNoiDungTieuChuan.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {            
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChu.Text = "";           
            txtTenTieuChuan.Enabled = true;
            txtNoiDungTieuChuan.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
        }

        private event EventHandler insertTieuChuan;
        public event EventHandler InsertTieuChuan
        {
            add { insertTieuChuan += value; }
            remove { insertTieuChuan -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChu.Text;

            if (txtTenTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChuan.Focus();
            }
            else if (txtNoiDungTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChuan.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm mới tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChuanBUS.Instance.InsertTieuChuan(tentieuchuan, noidungtieuchuan, ghichu))
                {
                    MessageBox.Show("Thêm danh mục tiêu chuẩn mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;
                    //ResetGiaTri();
                    TieuChuanBinding();
                    LoadListTieuChuan();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục tiêu chuẩn mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        { 
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateTieuChuan;
        public event EventHandler UpdateTieuChuan
        {
            add { updateTieuChuan += value; }
            remove { updateTieuChuan -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChu.Text;
            string input = Interaction.InputBox("Nhập mã tiêu chuẩn !", "Sửa tiêu chuẩn", "Mã tiêu chuẩn", -1, -1);
            int matieuchuan = Int32.Parse(input);

            if (txtTenTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChuan.Focus();
            }
            else if (txtNoiDungTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChuan.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn sửa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChuanBUS.Instance.UpdateTieuChuan(matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                {
                    MessageBox.Show("Sửa danh mục tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Sửa danh mục tiêu chuẩn mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private event EventHandler deleteTieuChuan;
        public event EventHandler DeleteTieuChuan
        {
            add { deleteTieuChuan += value; }
            remove { deleteTieuChuan -= value; }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mã tiêu chuẩn !", "Xóa tiêu chuẩn", "Mã tiêu chuẩn", -1, -1);
            int matieuchuan = Int32.Parse(input);

            if (TieuChuanBUS.Instance.GetListTieuChuan().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChuanBUS.Instance.DeleteTieuChuan(matieuchuan))
                {
                    MessageBox.Show("Xóa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteTieuChuan != null)
                    {
                        deleteTieuChuan(this, new EventArgs());
                    }
                    TieuChuanBinding();
                    LoadListTieuChuan();
                }
                else
                {
                    MessageBox.Show("Xóa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

          


       


