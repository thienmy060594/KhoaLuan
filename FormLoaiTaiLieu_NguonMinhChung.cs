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
    public partial class FormLoaiTaiLieuNguonMinhChung : Form
    {
        BindingSource LoaiTaiLieuList = new BindingSource();
        BindingSource NguonMinhChungMinhChungList = new BindingSource();
        public FormLoaiTaiLieuNguonMinhChung()
        {
            InitializeComponent();
            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuList;
            LoadListLoaiTaiLieu();
            FillComBoBoxLoaiTaiLieu();
            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChungMinhChungList;
            LoadListNguonMinhChungMinhChung();
            FillComBoBoxNguonMinhChungMinhChung();
        }

        bool IsTheSameCellValueLoaiTaiLieu(int column, int row)
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
            if (IsTheSameCellValueLoaiTaiLieu(e.ColumnIndex, e.RowIndex))
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
            if (IsTheSameCellValueLoaiTaiLieu(e.ColumnIndex, e.RowIndex))
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

            dgvLoaiTaiLieu.EnableHeadersVisualStyles = false;
            dgvLoaiTaiLieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void LoaiTaiLieuBinding()
        {
            txtMaLoaiTaiLieu.DataBindings.Clear();
            txtTenLoaiTaiLieu.DataBindings.Clear();
            txtGhiChuLTLieu.DataBindings.Clear();            
        }

        private void FillComBoBoxLoaiTaiLieu()
        {
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
        }

        bool IsTheSameCellValueNguonMinhChungMinhChung(int column, int row)
        {
            DataGridViewCell cell1 = dgvNguonMinhChungMinhChung[column, row];
            DataGridViewCell cell2 = dgvNguonMinhChungMinhChung[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvNguonMinhChungMinhChung_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueNguonMinhChungMinhChung(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvNguonMinhChungMinhChung.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvNguonMinhChungMinhChung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueNguonMinhChungMinhChung(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListNguonMinhChungMinhChung()
        {
            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChung_MinhChungBUS.Instance.GetListNguonMinhChung_MinhChung();
            dgvNguonMinhChungMinhChung.Columns[0].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[1].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[2].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[3].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[4].HeaderText = "Mã Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[5].HeaderText = "Tên Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNguonMinhChungMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChungMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNguonMinhChungMinhChung.AutoGenerateColumns = false;

            dgvNguonMinhChungMinhChung.EnableHeadersVisualStyles = false;
            dgvNguonMinhChungMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void NguonMinhChungMinhChungBinding()
        {
            txtGhiChuNMChungMChung.DataBindings.Clear();            
        }

        private void FillComBoBoxNguonMinhChungMinhChung()
        {
            cbxMinhChung1.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung1.ValueMember = "ID_TaiLieu";
            cbxMinhChung1.DisplayMember = "TenTaiLieu";
            cbxNguonMinhChung1.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung1.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung1.DisplayMember = "TenNguonMinhChung";
        }

        private event EventHandler insertLoaiTaiLieu;
        public event EventHandler InsertLoaiTaiLieu
        {
            add { insertLoaiTaiLieu += value; }
            remove { insertLoaiTaiLieu -= value; }
        }

        private void btnThemMoiLTLieu_Click(object sender, EventArgs e)
        {
            string maloaitailieu = txtMaLoaiTaiLieu.Text;
            string tenloaitailieu = txtTenLoaiTaiLieu.Text;
            string ghichu = txtGhiChuLTLieu.Text;
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
                    ResetGiaTriLoaiTaiLieu();
                }
                else
                {
                    MessageBox.Show("Thêm loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriLoaiTaiLieu()
        {
            txtMaLoaiTaiLieu.Text = "";
            txtTenLoaiTaiLieu.Text = "";
            txtGhiChuLTLieu.Text = "";            
        }

        private event EventHandler updateLoaiTaiLieu;
        public event EventHandler UpdateLoaiTaiLieu
        {
            add { updateLoaiTaiLieu += value; }
            remove { updateLoaiTaiLieu -= value; }
        }

        private void btnSuaLTLieu_Click(object sender, EventArgs e)
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
                    string ghichu = txtGhiChuLTLieu.Text;
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
                        ResetGiaTriLoaiTaiLieu();
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

        private void btnXoaLTLieu_Click(object sender, EventArgs e)
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
                        ResetGiaTriLoaiTaiLieu();
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
            ResetGiaTriLoaiTaiLieu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiemLTLieu_Click(object sender, EventArgs e)
        {
            string timkiemloaitailieu = txtTenLoaiTaiLieu.Text;
            if (txtTenLoaiTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTaiLieu.Focus();
                return;
            }

            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuBUS.Instance.SearchListLoaiTaiLieu(timkiemloaitailieu);
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

            dgvLoaiTaiLieu.EnableHeadersVisualStyles = false;
            dgvLoaiTaiLieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            LoaiTaiLieuBinding();
            ResetGiaTriLoaiTaiLieu();
        }

        private event EventHandler insertNguonMinhChungMinhChung;
        public event EventHandler InsertNguonMinhChung_MinhChung
        {
            add { insertNguonMinhChungMinhChung += value; }
            remove { insertNguonMinhChungMinhChung -= value; }
        }

        private void btnThemMoiNMChungMChung_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChuNMChungMChung.Text;
            string input_1 = cbxNguonMinhChung1.GetItemText(cbxNguonMinhChung1.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_1);
            string input_2 = cbxMinhChung1.GetItemText(cbxMinhChung1.SelectedValue);
            int id_tailieu = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChung_MinhChungBUS.Instance.InsertNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu, ghichu))
                {
                    MessageBox.Show("Thêm nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNguonMinhChungMinhChung != null)
                    {
                        insertNguonMinhChungMinhChung(this, new EventArgs());
                    }
                    NguonMinhChungMinhChungBinding();
                    LoadListNguonMinhChungMinhChung();
                    ResetGiaTriNguonMinhChungMinhChung();
                }
                else
                {
                    MessageBox.Show("Thêm nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriNguonMinhChungMinhChung()
        {
            txtGhiChuNMChungMChung.Text = "";            
        }

        private event EventHandler updateNguonMinhChungMinhChung;
        public event EventHandler UpdateNguonMinhChungMinhChung
        {
            add { updateNguonMinhChungMinhChung += value; }
            remove { updateNguonMinhChungMinhChung -= value; }
        }

        private void btnSuaNMChungMChung_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChuNMChungMChung.Text;
                string input_1 = cbxNguonMinhChung1.GetItemText(cbxNguonMinhChung1.SelectedValue); ;
                int id_nguonminhchung = Int32.Parse(input_1);
                string input_2 = cbxMinhChung1.GetItemText(cbxMinhChung1.SelectedValue);
                int id_tailieu = Int32.Parse(input_2);

                if (NguonMinhChung_MinhChungBUS.Instance.UpdateNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu, ghichu))
                {
                    MessageBox.Show("Sửa nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateNguonMinhChungMinhChung != null)
                    {
                        updateNguonMinhChungMinhChung(this, new EventArgs());
                    }
                    NguonMinhChungMinhChungBinding();
                    LoadListNguonMinhChungMinhChung();
                    ResetGiaTriNguonMinhChungMinhChung();
                }
                else
                {
                    MessageBox.Show("Sửa nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteNguonMinhChungMinhChung;
        public event EventHandler DeleteNguonMinhChungMinhChung
        {
            add { deleteNguonMinhChungMinhChung += value; }
            remove { deleteNguonMinhChungMinhChung -= value; }
        }

        private void btnXoaNMChungMChung_Click(object sender, EventArgs e)
        {
            string input_1 = cbxNguonMinhChung1.GetItemText(cbxNguonMinhChung1.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_1);
            string input_2 = cbxMinhChung1.GetItemText(cbxMinhChung1.SelectedValue);
            int id_tailieu = Int32.Parse(input_2);

            if (NguonMinhChung_MinhChungBUS.Instance.DeleteNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu))
            {
                MessageBox.Show("Xóa nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (deleteNguonMinhChungMinhChung != null)
                {
                    deleteNguonMinhChungMinhChung(this, new EventArgs());
                }
                NguonMinhChungMinhChungBinding();
                LoadListNguonMinhChungMinhChung();
                ResetGiaTriNguonMinhChungMinhChung();
            }
            else
            {
                MessageBox.Show("Xóa nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemNMChungMChung_Click(object sender, EventArgs e)
        {
            string timkiemnguonminhchungminhchung = txtGhiChuNMChungMChung.Text;
            if (txtGhiChuNMChungMChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuNMChungMChung.Focus();
                return;
            }

            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChung_MinhChungBUS.Instance.SearchListNguonMinhChung_MinhChung(timkiemnguonminhchungminhchung);
            dgvNguonMinhChungMinhChung.Columns[0].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[1].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[2].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[3].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[4].HeaderText = "Mã Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[5].HeaderText = "Tên Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNguonMinhChungMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChungMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNguonMinhChungMinhChung.AutoGenerateColumns = false;

            dgvNguonMinhChungMinhChung.EnableHeadersVisualStyles = false;
            dgvNguonMinhChungMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            NguonMinhChungMinhChungBinding();
            ResetGiaTriNguonMinhChungMinhChung();
        }

        private void dgvLoaiTaiLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiTaiLieu.CurrentCell == null || dgvLoaiTaiLieu.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvLoaiTaiLieu.CurrentRow.Selected = true;
                txtMaLoaiTaiLieu.Text = dgvLoaiTaiLieu.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtTenLoaiTaiLieu.Text = dgvLoaiTaiLieu.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();                
                txtGhiChuLTLieu.Text = dgvLoaiTaiLieu.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
            }
        }
    }
}


