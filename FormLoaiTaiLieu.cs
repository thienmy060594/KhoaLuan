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
            txtMaLoaiTaiLieu.Enabled = false;
            txtTenLoaiTaiLieu.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvLoaiTaiLieu[column, row];
            DataGridViewCell cell2 = dgvLoaiTaiLieu[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvLoaiTaiLieu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvLoaiTaiLieu.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvLoaiTaiLieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListLoaiTaiLieu()
        {
            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuBUS.Instance.GetListLoaiTaiLieu();
            dgvLoaiTaiLieu.Columns[0].Visible = false;
            dgvLoaiTaiLieu.Columns[1].Visible = false;
            dgvLoaiTaiLieu.Columns[2].Visible = false;
            dgvLoaiTaiLieu.Columns[3].HeaderText = "Mã Tài Liệu";
            dgvLoaiTaiLieu.Columns[4].HeaderText = "Tên Tài Liệu";
            dgvLoaiTaiLieu.Columns[5].HeaderText = "Mã Nguồn Minh Chứng";
            dgvLoaiTaiLieu.Columns[6].HeaderText = "Tên Nguồn Minh Chứng";
            dgvLoaiTaiLieu.Columns[7].HeaderText = "Mã Loại Tài Liệu";
            dgvLoaiTaiLieu.Columns[8].HeaderText = "Tên Loại Tài Liệu";
            dgvLoaiTaiLieu.Columns[9].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvLoaiTaiLieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiTaiLieu.AllowUserToAddRows = false;
            dgvLoaiTaiLieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvLoaiTaiLieu.AutoGenerateColumns = false;
        }

        void LoaiTaiLieuBinding()
        {
            txtMaLoaiTaiLieu.DataBindings.Clear();
            txtTenLoaiTaiLieu.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaLoaiTaiLieu.Text = "";
            txtTenLoaiTaiLieu.Text = "";
            txtGhiChu.Text = "";
            txtMaLoaiTaiLieu.Enabled = true;
            txtTenLoaiTaiLieu.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
        }

        private event EventHandler insertLoaiTaiLieu;
        public event EventHandler InsertLoaiTaiLieu
        {
            add { insertLoaiTaiLieu += value; }
            remove { insertLoaiTaiLieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string maloaitailieu = txtMaLoaiTaiLieu.Text;
            string tenloaitailieu = txtTenLoaiTaiLieu.Text;
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue); ;
            int id_tailieu = Int32.Parse(input_1);
            string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_2);

            if (txtMaLoaiTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiTaiLieu.Focus();
                return;
            }
            else if (txtTenLoaiTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTaiLieu.Focus();
                return;
            }
            else if (txtMaLoaiTaiLieu.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.LoaiTaiLieu LTLieu WHERE LTLieu.MaLoaiTaiLieu = N'{0}'", maloaitailieu);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã loại tài liệu này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiTaiLieu.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiTaiLieuBUS.Instance.InsertLoaiTaiLieu(id_tailieu, id_nguonminhchung, maloaitailieu, tenloaitailieu, ghichu))
                {
                    MessageBox.Show("Thêm loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertLoaiTaiLieu != null)
                    {
                        insertLoaiTaiLieu(this, new EventArgs());
                    }
                    LoaiTaiLieuBinding();
                    LoadListLoaiTaiLieu();
                    ResetGiaTri();                   
                }
                else
                {
                    MessageBox.Show("Thêm loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaLoaiTaiLieu.Text = "";
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
            if (MessageBox.Show("Bạn có muốn sửa loại tài liệu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaLoaiTaiLieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa mã loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiTaiLieu.Focus();
                }
                else if (txtTenLoaiTaiLieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenLoaiTaiLieu.Focus();
                }
                else
                {
                    string maloaitailieu = txtMaLoaiTaiLieu.Text;
                    string tenloaitailieu = txtTenLoaiTaiLieu.Text;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue); ;
                    int id_tailieu = Int32.Parse(input_1);
                    string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
                    int id_nguonminhchung = Int32.Parse(input_2);
                    string sql = string.Format("SELECT ID_LoaiTaiLieu FROM dbo.LoaiTaiLieu LTLieu WHERE LTLieu.MaLoaiTaiLieu = N'{0}'", maloaitailieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_loaitailieu = Int32.Parse(input);

                    if (LoaiTaiLieuBUS.Instance.UpdateLoaiTaiLieu(id_loaitailieu, id_tailieu, id_nguonminhchung, maloaitailieu, tenloaitailieu, ghichu))
                    {
                        MessageBox.Show("Sửa loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("Sửa loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
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
            if (MessageBox.Show("Bạn có muốn xóa loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaLoaiTaiLieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa mã loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiTaiLieu.Focus();
                }
                else
                {
                    string maloaitailieu = txtMaLoaiTaiLieu.Text;
                    string sql = string.Format("SELECT ID_LoaiTaiLieu FROM dbo.LoaiTaiLieu LTLieu WHERE LTLieu.MaLoaiTaiLieu = N'{0}'", maloaitailieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_loaitailieu = Int32.Parse(input);

                    if (LoaiTaiLieuBUS.Instance.DeleteLoaiTaiLieu(id_loaitailieu))
                    {
                        MessageBox.Show("Xóa loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteLoaiTaiLieu != null)
                        {
                            deleteLoaiTaiLieu(this, new EventArgs());
                        }
                        LoaiTaiLieuBinding();
                        LoadListLoaiTaiLieu();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
