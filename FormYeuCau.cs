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
    public partial class FormYeuCau : Form
    {
        BindingSource YeuCauList = new BindingSource();
        public FormYeuCau()
        {
            InitializeComponent();
            dgvYeuCau.DataSource = YeuCauList;
            LoadListYeuCau();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtNoiDungYeuCau.Enabled = false;
            txtTenYeuCau.Enabled = false;
            txtGhiChu.Enabled = false;
        }
        private void LoadListYeuCau()
        {
            dgvYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            dgvYeuCau.Columns[0].HeaderText = "Mã Yêu Cầu";
            dgvYeuCau.Columns[1].HeaderText = "Tên Yêu Cầu";
            dgvYeuCau.Columns[2].HeaderText = "Nội Yêu Cầu";
            dgvYeuCau.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvYeuCau.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCau.AllowUserToAddRows = false;
            dgvYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void YeuCauBinding()
        {            
            txtTenYeuCau.DataBindings.Clear();
            txtNoiDungYeuCau.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {            
            txtTenYeuCau.Text = "";
            txtNoiDungYeuCau.Text = "";
            txtGhiChu.Text = "";            
            txtTenYeuCau.Enabled = true;
            txtNoiDungYeuCau.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
        }

        private event EventHandler insertYeuCau;
        public event EventHandler InsertYeuCau
        {
            add { insertYeuCau += value; }
            remove { insertYeuCau -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string tenyeucau = txtTenYeuCau.Text;
            string noidungyeucau = txtNoiDungYeuCau.Text;
            string ghichu = txtGhiChu.Text;

            if (txtTenYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenYeuCau.Focus();
            }
            else if (txtNoiDungYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungYeuCau.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm mới yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCauBUS.Instance.InsertYeuCau(tenyeucau, noidungyeucau, ghichu))
                {
                    MessageBox.Show("Thêm danh mục yêu cầu mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertYeuCau != null)
                    {
                        insertYeuCau(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;
                    YeuCauBinding();
                    LoadListYeuCau();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục yêu cầu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }      
        }

        void ResetGiaTri()
        {
            txtTenYeuCau.Text = "";
            txtNoiDungYeuCau.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateYeuCau;
        public event EventHandler UpdateYeuCau
        {
            add { updateYeuCau += value; }
            remove { updateYeuCau -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenyeucau = txtTenYeuCau.Text;
            string noidungyeucau = txtNoiDungYeuCau.Text;
            string ghichu = txtGhiChu.Text;
            string input = Interaction.InputBox("Nhập mã yêu cầu !", "Sửa yêu cầu", "Mã yêu cầu", -1, -1);
            int mayeucau = Int32.Parse(input);

            if (txtTenYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenYeuCau.Focus();
            }
            else if (txtNoiDungYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungYeuCau.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn sửa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCauBUS.Instance.UpdateYeuCau(mayeucau, tenyeucau, noidungyeucau, ghichu))
                {
                    MessageBox.Show("Sửa danh mục yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateYeuCau != null)
                    {
                        updateYeuCau(this, new EventArgs());
                    }
                    YeuCauBinding();
                    LoadListYeuCau();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa danh mục yêu cầu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private event EventHandler deleteYeuCau;
        public event EventHandler DeleteYeuCau
        {
            add { deleteYeuCau += value; }
            remove { deleteYeuCau -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mã yêu cầu !", "Xóa yêu cầu", "Mã yêu cầu", -1, -1);
            int mayeucau = Int32.Parse(input);

            if (YeuCauBUS.Instance.GetListYeuCau().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCauBUS.Instance.DeleteYeuCau(mayeucau))
                {
                    MessageBox.Show("Xóa yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteYeuCau != null)
                    {
                        deleteYeuCau(this, new EventArgs());
                    }
                    YeuCauBinding();
                    LoadListYeuCau();
                }
                else
                {
                    MessageBox.Show("Xóa yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
