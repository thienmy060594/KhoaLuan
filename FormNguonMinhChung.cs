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
    public partial class FormNguonMinhChung : Form
    {
        BindingSource NguonMinhChungList = new BindingSource();
        public FormNguonMinhChung()
        {
            InitializeComponent();
            dgvNguonMinhChung.DataSource = NguonMinhChungList;
            LoadListNguonMinhChung();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtTenNguonMinhChung.Enabled = false;
            txtNoiDungNguonMinhChung.Enabled = false;
            txtGhiChu.Enabled = false;
        }
        private void LoadListNguonMinhChung()
        {
            dgvNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            dgvNguonMinhChung.Columns[0].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[1].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[2].HeaderText = "Nội Dung Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvNguonMinhChung.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChung.AllowUserToAddRows = false;
            dgvNguonMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void NguonMinhChungBinding()
        {
            txtTenNguonMinhChung.DataBindings.Clear();
            txtNoiDungNguonMinhChung.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtTenNguonMinhChung.Text = "";
            txtNoiDungNguonMinhChung.Text = "";
            txtGhiChu.Text = "";
            txtTenNguonMinhChung.Enabled = true;
            txtNoiDungNguonMinhChung.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
        }

        private event EventHandler insertNguonMinhChung;
        public event EventHandler InsertNguonMinhChung
        {
            add { insertNguonMinhChung += value; }
            remove { insertNguonMinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string tennguonminhchung = txtTenNguonMinhChung.Text;
            string noidungnguonminhchung = txtNoiDungNguonMinhChung.Text;
            string ghichu = txtGhiChu.Text;

            if (txtTenNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguonMinhChung.Focus();
            }
            else if (txtNoiDungNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungNguonMinhChung.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm mới nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChungBUS.Instance.InsertNguonMinhChung(tennguonminhchung, noidungnguonminhchung, ghichu))
                {
                    MessageBox.Show("Thêm danh mục nguồn minh chứng mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNguonMinhChung != null)
                    {
                        insertNguonMinhChung(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;
                    NguonMinhChungBinding();
                    LoadListNguonMinhChung();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục nguồn minh chứng mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtTenNguonMinhChung.Text = "";
            txtNoiDungNguonMinhChung.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNguonMinhChung;
        public event EventHandler UpdateNguonMinhChung
        {
            add { updateNguonMinhChung += value; }
            remove { updateNguonMinhChung -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tennguonminhchung = txtTenNguonMinhChung.Text;
            string noidungnguonminhchung = txtNoiDungNguonMinhChung.Text;
            string ghichu = txtGhiChu.Text;
            string input = Interaction.InputBox("Nhập mã nguồn minh chứng !", "Sửa nguồn minh chứng", "Mã nguồn minh chứng", -1, -1);
            int manguonminhchung = Int32.Parse(input);

            if (txtTenNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguonMinhChung.Focus();
            }
            else if (txtNoiDungNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungNguonMinhChung.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn sửa nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChungBUS.Instance.UpdateNguonMinhChung(manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu))
                {
                    MessageBox.Show("Sửa danh mục nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateNguonMinhChung != null)
                    {
                        updateNguonMinhChung(this, new EventArgs());
                    }
                    NguonMinhChungBinding();
                    LoadListNguonMinhChung();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa danh mục nguồn minh chứng mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private event EventHandler deleteNguonMinhChung;
        public event EventHandler DeleteNguonMinhChung
        {
            add { deleteNguonMinhChung += value; }
            remove { deleteNguonMinhChung -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mã nguồn minh chứng !", "Xóa nguồn minh chứng", "Mã nguồn minh chứng", -1, -1);
            int mayeucau = Int32.Parse(input);

            if (NguonMinhChungBUS.Instance.GetListNguonMinhChung().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChungBUS.Instance.DeleteNguonMinhChung(mayeucau))
                {
                    MessageBox.Show("Xóa nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteNguonMinhChung != null)
                    {
                        deleteNguonMinhChung(this, new EventArgs());
                    }
                    NguonMinhChungBinding();
                    LoadListNguonMinhChung();
                }
                else
                {
                    MessageBox.Show("Xóa nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
