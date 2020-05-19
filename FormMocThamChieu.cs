using System;
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
using Microsoft.VisualBasic;

namespace KiemDinhChatLuongGUI
{
    public partial class FormMocThamChieu : Form
    {
        BindingSource MocThamChieuList = new BindingSource();
        public FormMocThamChieu()
        {
            InitializeComponent();
            dgvMocThamChieu.DataSource = MocThamChieuList;
            LoadListMocThamChieu();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtNoiDungMocThamChieu.Enabled = false;
            txtTenMocThamChieu.Enabled = false;
            txtGhiChu.Enabled = false;
        }

        private void LoadListMocThamChieu()
        {
            dgvMocThamChieu.DataSource = MocThamChieuBUS.Instance.GetListMocThamChieu();
            dgvMocThamChieu.Columns[0].HeaderText = "Mã Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[1].HeaderText = "Tên Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[2].HeaderText = "Nội Dung Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMocThamChieu.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMocThamChieu.AllowUserToAddRows = false;
            dgvMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void MocThamChieuBinding()
        {
            txtNoiDungMocThamChieu.DataBindings.Clear();
            txtTenMocThamChieu.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtNoiDungMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtGhiChu.Text = "";
            txtNoiDungMocThamChieu.Enabled = true;
            txtTenMocThamChieu.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
        }

        private event EventHandler insertMocThamChieu;
        public event EventHandler InsertMocThamChieu
        {
            add { insertMocThamChieu += value; }
            remove { insertMocThamChieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string tenmocthamchieu = txtTenMocThamChieu.Text;
            string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
            string ghichu = txtGhiChu.Text;

            if (txtNoiDungMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungMocThamChieu.Focus();
            }
            else if (txtTenMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMocThamChieu.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm mới mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MocThamChieuBUS.Instance.InsertMocThamChieu(tenmocthamchieu, noidungmocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm danh mục mốc tham chiếu mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMocThamChieu != null)
                    {
                        insertMocThamChieu(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;
                    MocThamChieuBinding();
                    LoadListMocThamChieu();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục mốc tham chiếu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtNoiDungMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMocThamChieu;
        public event EventHandler UpdateMocThamChieu
        {
            add { updateMocThamChieu += value; }
            remove { updateMocThamChieu -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenmocthamchieu = txtTenMocThamChieu.Text;
            string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
            string ghichu = txtGhiChu.Text;
            string input = Interaction.InputBox("Nhập mã mốc tham chiếu !", "Sửa mốc tham chiếu", "Mã mốc tham chiếu", -1, -1);
            int mamocthamchieu = Int32.Parse(input);

            if (txtNoiDungMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungMocThamChieu.Focus();
            }
            else if (txtTenMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMocThamChieu.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn sửa mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MocThamChieuBUS.Instance.UpdateMocThamChieu(mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                {
                    MessageBox.Show("Sửa danh mục mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Sửa danh mục mốc tham chiếu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            string input = Interaction.InputBox("Nhập mã mốc tham chiếu !", "Xóa mốc tham chiếu", "Mã mốc tham chiếu", -1, -1);
            int mamocthamchieu = Int32.Parse(input);

            if (MocThamChieuBUS.Instance.GetListMocThamChieu().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MocThamChieuBUS.Instance.DeleteMocThamChieu(mamocthamchieu))
                {
                    MessageBox.Show("Xóa mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteMocThamChieu != null)
                    {
                        deleteMocThamChieu(this, new EventArgs());
                    }
                    MocThamChieuBinding();
                    LoadListMocThamChieu();
                }
                else
                {
                    MessageBox.Show("Xóa mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

