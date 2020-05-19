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
    public partial class FormMinhChung : Form
    {
        BindingSource MinhChungList = new BindingSource();
        public FormMinhChung()
        {
            InitializeComponent();
            dgvMinhChung.DataSource = MinhChungList;
            LoadListMinhChung();
            btnSua.Enabled = false;
            btnLuuLai.Enabled = false;
            txtTenTaiLieu.Enabled = false;
            txtNgayKy.Enabled = false;
            txtNguoiKy.Enabled = false;
            txtSoBanHanh.Enabled = false;
            txtTomTatNoiDung.Enabled = false;
            txtDuongLink.Enabled = false;
            txtGhiChu.Enabled = false;
        }
        private void LoadListMinhChung()
        {
            dgvMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            dgvMinhChung.Columns[0].HeaderText = "Mã Tài Liệu";
            dgvMinhChung.Columns[1].HeaderText = "Tên Tài Liệu";
            dgvMinhChung.Columns[2].HeaderText = "Ngày Ký";
            dgvMinhChung.Columns[3].HeaderText = "Người Ký";
            dgvMinhChung.Columns[4].HeaderText = "Số Ban Hành";
            dgvMinhChung.Columns[5].HeaderText = "Tóm Tắt Nội Dung";
            dgvMinhChung.Columns[6].HeaderText = "Đường Link";
            dgvMinhChung.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMinhChung.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMinhChung.AllowUserToAddRows = false;
            dgvMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void MinhChungBinding()
        {
            txtTenTaiLieu.DataBindings.Clear();
            txtNgayKy.DataBindings.Clear();
            txtNguoiKy.DataBindings.Clear();
            txtSoBanHanh.DataBindings.Clear();
            txtTomTatNoiDung.DataBindings.Clear();
            txtDuongLink.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            txtTenTaiLieu.Text = "";
            txtNgayKy.Text = "";
            txtNguoiKy.Text = "";
            txtSoBanHanh.Text = "";
            txtTomTatNoiDung.Text = "";
            txtDuongLink.Text = "";
            txtGhiChu.Text = "";
            txtTenTaiLieu.Enabled = true;
            txtNgayKy.Enabled = true;
            txtNguoiKy.Enabled = true;
            txtSoBanHanh.Enabled = true;
            txtTomTatNoiDung.Enabled = true;
            txtDuongLink.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
        }

        private event EventHandler insertMinhChung;
        public event EventHandler InserMinhChung
        {
            add { insertMinhChung += value; }
            remove { insertMinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string tentailieu = txtTenTaiLieu.Text;
            string ngayky = txtNgayKy.Text;
            string nguoiky = txtNguoiKy.Text;
            string sobanhanh = txtSoBanHanh.Text;
            string tomtatnoidung = txtTomTatNoiDung.Text;
            string duonglink = txtDuongLink.Text;
            string ghichu = txtGhiChu.Text;

            if (txtTenTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiLieu.Focus();
            }
            else if (txtNgayKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayKy.Focus();
            }
            else if (txtNguoiKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập người ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiKy.Focus();
            }
            else if (txtSoBanHanh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số ban hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoBanHanh.Focus();
            }
            else if (txtTomTatNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTomTatNoiDung.Focus();
            }
            else if (txtDuongLink.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đường link !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuongLink.Focus();
            }           
            else if (MessageBox.Show("Bạn có muốn thêm mới tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MinhChungBUS.Instance.InsertMinhChung(tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, duonglink, ghichu))
                {
                    MessageBox.Show("Thêm danh mục loại tài liệu mới thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMinhChung != null)
                    {
                        insertMinhChung(this, new EventArgs());
                    }
                    btnLuuLai.Enabled = false;
                    MinhChungBinding();
                    LoadListMinhChung();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm danh mục tài liệu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtTenTaiLieu.Text = "";
            txtNgayKy.Text = "";
            txtNguoiKy.Text = "";
            txtSoBanHanh.Text = "";
            txtTomTatNoiDung.Text = "";
            txtDuongLink.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMinhChung;
        public event EventHandler UpdateMinhChung
        {
            add { updateMinhChung += value; }
            remove { updateMinhChung -= value; }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tentailieu = txtTenTaiLieu.Text;
            string ngayky = txtNgayKy.Text;
            string nguoiky = txtNguoiKy.Text;
            string sobanhanh = txtSoBanHanh.Text;
            string tomtatnoidung = txtTomTatNoiDung.Text;
            string duonglink = txtDuongLink.Text;
            string ghichu = txtGhiChu.Text;
            string input = Interaction.InputBox("Nhập mã tài liệu !", "Sửa tài liệu", "Mã tài liệu", -1, -1);
            int matailieu = Int32.Parse(input);

            if (txtTenTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiLieu.Focus();
            }
            else if (txtNgayKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayKy.Focus();
            }
            else if (txtNguoiKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập người ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiKy.Focus();
            }
            else if (txtSoBanHanh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số ban hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoBanHanh.Focus();
            }
            else if (txtTomTatNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTomTatNoiDung.Focus();
            }
            else if (txtDuongLink.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập đường link !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDuongLink.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn sửa tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MinhChungBUS.Instance.UpdateMinhChung(matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, duonglink, ghichu))
                {
                    MessageBox.Show("Sửa danh mục tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateMinhChung != null)
                    {
                        updateMinhChung(this, new EventArgs());
                    }
                    MinhChungBinding();
                    LoadListMinhChung();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa danh mục tài liệu mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private event EventHandler deleteMinhChung;
        public event EventHandler DeleteMinhChung
        {
            add { deleteMinhChung += value; }
            remove { deleteMinhChung -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string input = Interaction.InputBox("Nhập mã tài liệu !", "Xóa tài liệu", "Mã tài liệu", -1, -1);
            int matailieu = Int32.Parse(input);

            if (MinhChungBUS.Instance.GetListMinhChung().Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (MessageBox.Show("Bạn có muốn xóa tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MinhChungBUS.Instance.DeleteMinhChung(matailieu))
                {
                    MessageBox.Show("Xóa tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteMinhChung != null)
                    {
                        deleteMinhChung(this, new EventArgs());
                    }
                    MinhChungBinding();
                    LoadListMinhChung();
                }
                else
                {
                    MessageBox.Show("Xóa tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
