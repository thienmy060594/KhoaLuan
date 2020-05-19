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
    public partial class FormTieuChi : Form
    {
        BindingSource TieuChiList = new BindingSource();

        public FormTieuChi()
        {
            InitializeComponent();
            dgvTieuChi.DataSource = TieuChiList;
            LoadListTieuChi();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtNoiDungTieuChi.Enabled = false;
            txtTenTieuChi.Enabled = false;
            txtGhiChu.Enabled = false;
        }

        private void LoadListTieuChi()
        {
            dgvTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            dgvTieuChi.Columns[0].HeaderText = "Mã Tiêu Chí";
            dgvTieuChi.Columns[1].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChi.Columns[2].HeaderText = "Tên Tiêu Chí";
            dgvTieuChi.Columns[3].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChi.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvTieuChi.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChi.AllowUserToAddRows = false;
            dgvTieuChi.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void TieuChiBinding()
        {
            txtTenTieuChi.DataBindings.Clear();
            txtNoiDungTieuChi.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {            
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChu.Text = "";            
            txtTenTieuChi.Enabled = true;
            txtNoiDungTieuChi.Enabled = true;
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
            string tentieuchi = txtTenTieuChi.Text;
            string noidungtieuchi = txtNoiDungTieuChi.Text;
            string ghichu = txtGhiChu.Text;
            string input = Interaction.InputBox("Nhập mã tiêu chuẩn !", "Thêm mã tiêu chuẩn", "Mã tiêu chuẩn", -1, -1);
            int matieuchuan = Int32.Parse(input);

            if (txtTenTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChi.Focus();
            }
            else if (txtNoiDungTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChi.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm mới tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChiBUS.Instance.InsertTieuChi(matieuchuan, tentieuchi, noidungtieuchi, ghichu))
                {
                    MessageBox.Show("Thêm danh mục tiêu chí mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;                    
                    TieuChiBinding();
                    LoadListTieuChi();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục tiêu chí mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateTieuChi;
        public event EventHandler UpdateTieuChi
        {
            add { updateTieuChi += value; }
            remove { updateTieuChi -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tentieuchi = txtTenTieuChi.Text;
            string noidungtieuchi = txtNoiDungTieuChi.Text;
            string ghichu = txtGhiChu.Text;
            string input_1 = Interaction.InputBox("Nhập mã tiêu chí !", "Sửa tiêu chí", "Mã tiêu chí", -1, -1);
            int matieuchi = Int32.Parse(input_1);
            string input_2 = Interaction.InputBox("Nhập mã tiêu chuẩn !", "Sửa tiêu chuẩn", "Mã tiêu chuẩn", -1, -1);
            int matieuchuan = Int32.Parse(input_2);

            if (txtTenTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChi.Focus();
            }
            else if (txtNoiDungTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChi.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn sửa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChiBUS.Instance.UpdateTieuChi(matieuchi, matieuchuan, tentieuchi, noidungtieuchi, ghichu))
                {
                    MessageBox.Show("Sửa danh mục tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Sửa danh mục tiêu chí mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private event EventHandler deleteTieuChi;
        public event EventHandler DeleteTieuChi
        {
            add { deleteTieuChi += value; }
            remove { deleteTieuChi -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mã tiêu chí !", "Xóa tiêu chí", "Mã tiêu chí", -1, -1);
            int matieuchi = Int32.Parse(input);

            if (TieuChiBUS.Instance.GetListTieuChi().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChiBUS.Instance.DeleteTieuChi(matieuchi))
                {
                    MessageBox.Show("Xóa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteTieuChi != null)
                    {
                        deleteTieuChi(this, new EventArgs());
                    }
                    TieuChiBinding();
                    LoadListTieuChi();
                }
                else
                {
                    MessageBox.Show("Xóa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
