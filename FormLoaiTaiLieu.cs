using System;
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
using Microsoft.VisualBasic;

namespace KiemDinhChatLuongGUI
{    
    public partial class FormLoaiTaiLieu : Form
    {
        BindingSource LoaiTaiLieuList = new BindingSource();
        public FormLoaiTaiLieu()
        {
            InitializeComponent();
            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuList;
            LoadListLoaiTaiLieu();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtTenLoaiTaiLieu.Enabled = false;
            txtGhiChu.Enabled = false;
        }
        private void LoadListLoaiTaiLieu()
        {
            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuBUS.Instance.GetListLoaiTaiLieu();
            dgvLoaiTaiLieu.Columns[0].HeaderText = "Mã Loại Tài Liệu";
            dgvLoaiTaiLieu.Columns[1].HeaderText = "Mã Minh Chứng";
            dgvLoaiTaiLieu.Columns[2].HeaderText = "Mã Nguồn Minh Chứng";
            dgvLoaiTaiLieu.Columns[3].HeaderText = "Tên Loại Tài Liệu";            
            dgvLoaiTaiLieu.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvLoaiTaiLieu.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;           
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiTaiLieu.AllowUserToAddRows = false;
            dgvLoaiTaiLieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void LoaiTaiLieuBinding()
        {
            txtTenLoaiTaiLieu.DataBindings.Clear();            
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtTenLoaiTaiLieu.Text = "";            
            txtGhiChu.Text = "";
            txtTenLoaiTaiLieu.Enabled = true;            
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
        }

        private event EventHandler insertLoaiTaiLieu;
        public event EventHandler InsertLoaiTaiLieu
        {
            add { insertLoaiTaiLieu += value; }
            remove { insertLoaiTaiLieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string tenloaitailieu = txtTenLoaiTaiLieu.Text;           
            string ghichu = txtGhiChu.Text;           
            string input_1 = Interaction.InputBox("Nhập mã minh chứng !", "Sửa minh chứng", "Mã minh chứng", -1, -1);
            int maminhchung = Int32.Parse(input_1);
            string input_2 = Interaction.InputBox("Nhập mã nguồn minh chứng !", "Sửa nguồn minh chứng", "Mã nguồn minh chứng", -1, -1);
            int manguonminhchung = Int32.Parse(input_2);

            if (txtTenLoaiTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTaiLieu.Focus();
            }            
            else if (MessageBox.Show("Bạn có muốn thêm mới loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiTaiLieuBUS.Instance.InsertLoaiTaiLieu(maminhchung, manguonminhchung,tenloaitailieu, ghichu))
                {
                    MessageBox.Show("Thêm danh mục loại tài liệu mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertLoaiTaiLieu != null)
                    {
                        insertLoaiTaiLieu(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;
                    LoaiTaiLieuBinding();
                    LoadListLoaiTaiLieu();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục loại tài liệu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtTenLoaiTaiLieu.Text = "";            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateLoaiTaiLieu;
        public event EventHandler UpdateLoaiTaiLieu
        {
            add { updateLoaiTaiLieu += value; }
            remove { updateLoaiTaiLieu -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenloaitailieu = txtTenLoaiTaiLieu.Text;            
            string ghichu = txtGhiChu.Text;
            string input_1 = Interaction.InputBox("Nhập mã loại tài liệu !", "Sửa yêu cầu", "Mã loại tài liệu", -1, -1);
            int maloaitailieu = Int32.Parse(input_1);
            string input_2 = Interaction.InputBox("Nhập mã minh chứng !", "Sửa minh chứng", "Mã minh chứng", -1, -1);
            int maminhchung = Int32.Parse(input_2);
            string input_3 = Interaction.InputBox("Nhập mã nguồn minh chứng !", "Sửa nguồn minh chứng", "Mã nguồn minh chứng", -1, -1);
            int manguonminhchung = Int32.Parse(input_3);

            if (txtTenLoaiTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTaiLieu.Focus();
            }           
            else if (MessageBox.Show("Bạn có muốn sửa loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiTaiLieuBUS.Instance.UpdateLoaiTaiLieu(maloaitailieu, maminhchung, manguonminhchung, tenloaitailieu, ghichu))
                {
                    MessageBox.Show("Sửa danh mục loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateLoaiTaiLieu != null)
                    {
                        updateLoaiTaiLieu(this, new EventArgs());
                    }
                    LoaiTaiLieuBinding();
                    LoadListLoaiTaiLieu();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa danh mục loại tài liệu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private event EventHandler deleteLoaiTaiLieu;
        public event EventHandler DeleteLoaiTaiLieu
        {
            add { deleteLoaiTaiLieu += value; }
            remove { deleteLoaiTaiLieu -= value; }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mã loại tài liệu !", "Xóa loại tài liệu", "Mã loại tài liệu", -1, -1);
            int maloaitailieu = Int32.Parse(input);

            if (LoaiTaiLieuBUS.Instance.GetListLoaiTaiLieu().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiTaiLieuBUS.Instance.DeleteLoaiTaiLieu(maloaitailieu))
                {
                    MessageBox.Show("Xóa loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteLoaiTaiLieu != null)
                    {
                        deleteLoaiTaiLieu(this, new EventArgs());
                    }
                    LoaiTaiLieuBinding();
                    LoadListLoaiTaiLieu();
                }
                else
                {
                    MessageBox.Show("Xóa loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
