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
    public partial class FormChuongTrinhDaoTao : Form
    {
        BindingSource KhoaList = new BindingSource();
        BindingSource NganhList = new BindingSource();
        BindingSource ChuongTrinhDaoTaoList = new BindingSource();
        public FormChuongTrinhDaoTao()
        {
            InitializeComponent();
            dgvKhoa.DataSource = KhoaList;
            LoadListKhoa();
            dgvNganh.DataSource = NganhList;
            LoadListNganh();
            FillComBoBoxNganh();
            dgvChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoList;
            LoadListChuongTrinhDaoTao();
            FillComBoBoxChuongTrinhDaoTao();
        }

        private void LoadListKhoa()
        {
            dgvKhoa.DataSource = KhoaBUS.Instance.GetListKhoa();
            dgvKhoa.Columns[0].Visible = false;
            dgvKhoa.Columns[1].HeaderText = "Mã Khoa";
            dgvKhoa.Columns[2].HeaderText = "Tên Khoa";
            dgvKhoa.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvKhoa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvKhoa.AutoGenerateColumns = false;

            dgvKhoa.EnableHeadersVisualStyles = false;
            dgvKhoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void KhoaBinding()
        {
            txtMaKhoa.DataBindings.Clear();
            txtTenKhoa.DataBindings.Clear();
            txtGhiChuKhoa.DataBindings.Clear();            
        }

        bool IsTheSameCellValueNganh(int column, int row)
        {
            DataGridViewCell cell1 = dgvNganh[column, row];
            DataGridViewCell cell2 = dgvNganh[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvNganh_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueNganh(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvNganh.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvNganh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueNganh(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListNganh()
        {
            dgvNganh.DataSource = NganhBUS.Instance.GetListNganh();
            dgvNganh.Columns[0].Visible = false;
            dgvNganh.Columns[1].Visible = false;
            dgvNganh.Columns[2].HeaderText = "Mã Khoa";
            dgvNganh.Columns[3].HeaderText = "Tên Khoa";
            dgvNganh.Columns[4].HeaderText = "Mã Ngành";
            dgvNganh.Columns[5].HeaderText = "Tên Ngành";
            dgvNganh.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNganh.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNganh.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNganh.AutoGenerateColumns = false;

            dgvNganh.EnableHeadersVisualStyles = false;
            dgvNganh.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void NganhBinding()
        {
            txtMaNganh.DataBindings.Clear();
            txtTenNganh.DataBindings.Clear();
            txtGhiChuNganh.DataBindings.Clear();            
        }

        private void FillComBoBoxNganh()
        {
            cbxKhoa.DataSource = KhoaBUS.Instance.GetListKhoa();
            cbxKhoa.ValueMember = "ID_Khoa";
            cbxKhoa.DisplayMember = "TenKhoa";
        }

        bool IsTheSameCellValueCTrinhDTao(int column, int row)
        {
            DataGridViewCell cell1 = dgvChuongTrinhDaoTao[column, row];
            DataGridViewCell cell2 = dgvChuongTrinhDaoTao[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvChuongTrinhDaoTao_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueCTrinhDTao(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvChuongTrinhDaoTao.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvChuongTrinhDaoTao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueCTrinhDTao(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListChuongTrinhDaoTao()
        {
            dgvChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            dgvChuongTrinhDaoTao.Columns[0].Visible = false;
            dgvChuongTrinhDaoTao.Columns[1].Visible = false;
            dgvChuongTrinhDaoTao.Columns[2].Visible = false;
            dgvChuongTrinhDaoTao.Columns[3].HeaderText = "Mã Ngành";
            dgvChuongTrinhDaoTao.Columns[4].HeaderText = "Tên Tên Ngành";
            dgvChuongTrinhDaoTao.Columns[5].HeaderText = "Mã Tài Liệu";
            dgvChuongTrinhDaoTao.Columns[6].HeaderText = "Tên Tài Liệu";
            dgvChuongTrinhDaoTao.Columns[7].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTao.Columns[8].HeaderText = "Năm Ký";
            dgvChuongTrinhDaoTao.Columns[9].HeaderText = "Năm Áp Dụng";
            dgvChuongTrinhDaoTao.Columns[10].HeaderText = "Tóm Tắt Nội Dung";
            dgvChuongTrinhDaoTao.Columns[11].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvChuongTrinhDaoTao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTao.AllowUserToAddRows = false;
            dgvChuongTrinhDaoTao.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvChuongTrinhDaoTao.AutoGenerateColumns = false;

            dgvChuongTrinhDaoTao.EnableHeadersVisualStyles = false;
            dgvChuongTrinhDaoTao.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void ChuongTrinhDaoTaoBinding()
        {
            txtMaChuongTrinhDaoTao.DataBindings.Clear();
            txtNamKy.DataBindings.Clear();
            txtNamApDung.DataBindings.Clear();
            txtTomTatNoiDung.DataBindings.Clear();
            txtGhiChuCTrinhDTao.DataBindings.Clear();            
        }

        private void FillComBoBoxChuongTrinhDaoTao()
        {
            cbxNganh.DataSource = NganhBUS.Instance.GetListNganh();
            cbxNganh.ValueMember = "ID_Nganh";
            cbxNganh.DisplayMember = "TenNganh";
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
        }

        private event EventHandler insertKhoa;
        public event EventHandler InsertKhoa
        {
            add { insertKhoa += value; }
            remove { insertKhoa -= value; }
        }

        private void btnThemMoiKhoa_Click(object sender, EventArgs e)
        {
            string makhoa = txtMaKhoa.Text;
            string tenkhoa = txtTenKhoa.Text;
            string ghichu = txtGhiChuKhoa.Text;

            if (txtMaKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKhoa.Focus();
                return;
            }
            else if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
                return;
            }
            else if (txtMaKhoa.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.Khoa K WHERE K.MaKhoa = N'{0}'", makhoa);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã khoa đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoa.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm khoa này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (KhoaBUS.Instance.InsertKhoa(makhoa, tenkhoa, ghichu))
                {
                    MessageBox.Show("Thêm khoa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertKhoa != null)
                    {
                        insertKhoa(this, new EventArgs());
                    }
                    KhoaBinding();
                    LoadListKhoa();
                    ResetGiaTriKhoa();
                }
                else
                {
                    MessageBox.Show("Thêm khoa thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriKhoa()
        {
            txtMaKhoa.Text = "";
            txtTenKhoa.Text = "";
            txtGhiChuKhoa.Text = "";            
        }

        private event EventHandler updateKhoa;
        public event EventHandler UpdateKhoa
        {
            add { updateKhoa += value; }
            remove { updateKhoa -= value; }
        }

        private void btnSuaKhoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa khoa này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoa.Focus();
                    return;
                }
                else if (txtTenKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKhoa.Focus();
                    return;
                }
                else
                {
                    string makhoa = txtMaKhoa.Text;
                    string tenkhoa = txtTenKhoa.Text;
                    string ghichu = txtGhiChuKhoa.Text;
                    string sql = string.Format("SELECT ID_Khoa FROM dbo.Khoa K WHERE K.MaKhoa = N'{0}'", makhoa);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_khoa = Int32.Parse(input);

                    if (KhoaBUS.Instance.UpdateKhoa(id_khoa, makhoa, tenkhoa, ghichu))
                    {
                        MessageBox.Show("Sửa khoa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateKhoa != null)
                        {
                            updateKhoa(this, new EventArgs());
                        }
                        KhoaBinding();
                        LoadListKhoa();
                        ResetGiaTriKhoa();
                    }
                    else
                    {
                        MessageBox.Show("Sửa khoa thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteKhoa;
        public event EventHandler DeleteKhoa
        {
            add { deleteKhoa += value; }
            remove { deleteKhoa -= value; }
        }

        private void btnXoaKhoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa khoa này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaKhoa.Focus();
                    return;
                }
                else if (txtTenKhoa.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenKhoa.Focus();
                    return;
                }
                else
                {
                    string makhoa = txtMaKhoa.Text;
                    string tenkhoa = txtTenKhoa.Text;
                    string ghichu = txtGhiChuKhoa.Text;
                    string sql = string.Format("SELECT ID_Khoa FROM dbo.Khoa K WHERE K.MaKhoa = N'{0}'", makhoa);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_khoa = Int32.Parse(input);

                    if (KhoaBUS.Instance.UpdateKhoa(id_khoa, makhoa, tenkhoa, ghichu))
                    {
                        MessageBox.Show("Sửa khoa thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteKhoa != null)
                        {
                            deleteKhoa(this, new EventArgs());
                        }
                        KhoaBinding();
                        LoadListKhoa();
                        ResetGiaTriKhoa();
                    }
                    else
                    {
                        MessageBox.Show("Sửa khoa thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void btnTimKiemKhoa_Click(object sender, EventArgs e)
        {
            string timkiemkhoa = txtTenKhoa.Text;
            if (txtTenKhoa.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKhoa.Focus();
                return;
            }

            dgvKhoa.DataSource = KhoaBUS.Instance.SearchListKhoa(timkiemkhoa);
            dgvKhoa.Columns[0].Visible = false;
            dgvKhoa.Columns[1].HeaderText = "Mã Khoa";
            dgvKhoa.Columns[2].HeaderText = "Tên Khoa";
            dgvKhoa.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvKhoa.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvKhoa.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvKhoa.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvKhoa.AutoGenerateColumns = false;

            dgvKhoa.EnableHeadersVisualStyles = false;
            dgvKhoa.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            KhoaBinding();
            ResetGiaTriKhoa();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriKhoa();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private event EventHandler insertNganh;
        public event EventHandler InsertNganh
        {
            add { insertNganh += value; }
            remove { insertNganh -= value; }
        }

        private void btnThemMoiNganh_Click(object sender, EventArgs e)
        {
            string manganh = txtMaNganh.Text;
            string tennganh = txtTenNganh.Text;
            string ghichu = txtGhiChuNganh.Text;
            string input = cbxKhoa.GetItemText(cbxKhoa.SelectedValue);
            int id_khoa = Int32.Parse(input);

            if (txtMaNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNganh.Focus();
                return;
            }
            else if (txtTenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNganh.Focus();
                return;
            }
            else if (txtMaNganh.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.Nganh N WHERE N.MaNganh = N'{0}'", manganh);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã ngành đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNganh.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm ngành này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NganhBUS.Instance.InsertNganh(id_khoa, manganh, tennganh, ghichu))
                {
                    MessageBox.Show("Thêm ngành thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNganh != null)
                    {
                        insertNganh(this, new EventArgs());
                    }
                    NganhBinding();
                    LoadListNganh();
                    ResetGiaTriNganh();
                }
                else
                {
                    MessageBox.Show("Thêm ngành thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriNganh()
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";
            txtGhiChuNganh.Text = "";            
        }

        private event EventHandler updateNganh;
        public event EventHandler UpdateNganh
        {
            add { updateNganh += value; }
            remove { updateNganh -= value; }
        }

        private void btnSuaNganh_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa ngành này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNganh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNganh.Focus();
                    return;
                }
                else if (txtTenNganh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNganh.Focus();
                    return;
                }
                else
                {
                    string manganh = txtMaNganh.Text;
                    string tennganh = txtTenNganh.Text;
                    string ghichu = txtGhiChuNganh.Text;
                    string sql = string.Format("SELECT ID_Nganh FROM dbo.Nganh N WHERE N.MaNganh = N'{0}'", manganh);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nganh = Int32.Parse(input);
                    string input_1 = cbxKhoa.GetItemText(cbxKhoa.SelectedValue);
                    int id_khoa = Int32.Parse(input_1);

                    if (NganhBUS.Instance.UpdateNganh(id_nganh, id_khoa, manganh, tennganh, ghichu))
                    {
                        MessageBox.Show("Sửa ngành thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateNganh != null)
                        {
                            updateNganh(this, new EventArgs());
                        }
                        NganhBinding();
                        LoadListNganh();
                        ResetGiaTriNganh();
                    }
                    else
                    {
                        MessageBox.Show("Sửa ngành thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteNganh;
        public event EventHandler DeleteNganh
        {
            add { deleteNganh += value; }
            remove { deleteNganh -= value; }
        }

        private void btnXoaNganh_Click(object sender, EventArgs e)
        {
            string manganh = txtMaNganh.Text;
            string sql = string.Format("SELECT ID_Nganh FROM dbo.Nganh N WHERE N.MaNganh = N'{0}'", manganh);
            string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
            int id_nganh = Int32.Parse(input);

            if (MessageBox.Show("Bạn có muốn xóa ngành này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNganh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNganh.Focus();
                    return;
                }

                string sql_1 = string.Format("SELECT * FROM dbo.ChuongTrinhDaoTao CTrinhDTao WHERE CTrinhDTao.ID_Nganh = N'{0}'", id_nganh);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql_1))
                {
                    MessageBox.Show("Đang tồn tại Ngành liên kết với Chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (NganhBUS.Instance.DeleteNganh(id_nganh))
                    {
                        MessageBox.Show("Xóa ngành thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteNganh != null)
                        {
                            deleteNganh(this, new EventArgs());
                        }
                        NganhBinding();
                        LoadListNganh();
                        ResetGiaTriNganh();
                    }
                    else
                    {
                        MessageBox.Show("Xóa ngành thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemNganh_Click(object sender, EventArgs e)
        {
            string timkiemnganh = txtTenNganh.Text;
            if (txtTenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNganh.Focus();
                return;
            }

            dgvNganh.DataSource = NganhBUS.Instance.SearchListNganh(timkiemnganh);
            dgvNganh.Columns[0].Visible = false;
            dgvNganh.Columns[1].Visible = false;
            dgvNganh.Columns[2].HeaderText = "Mã Khoa";
            dgvNganh.Columns[3].HeaderText = "Tên Khoa";
            dgvNganh.Columns[4].HeaderText = "Mã Ngành";
            dgvNganh.Columns[5].HeaderText = "Tên Ngành";
            dgvNganh.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNganh.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNganh.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNganh.AutoGenerateColumns = false;

            dgvNganh.EnableHeadersVisualStyles = false;
            dgvNganh.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            NganhBinding();
            ResetGiaTriNganh();
        }

        private event EventHandler insertChuongTrinhDaoTao;
        public event EventHandler InsertChuongTrinhDaoTao
        {
            add { insertChuongTrinhDaoTao += value; }
            remove { insertChuongTrinhDaoTao -= value; }
        }

        private void btnThemMoiCTrinhDTao_Click(object sender, EventArgs e)
        {
            string machuongtrinhdaotao = txtMaChuongTrinhDaoTao.Text;
            string namky = txtNamKy.Text;
            string namapdung = txtNamApDung.Text;
            string tomtatnoidung = txtTomTatNoiDung.Text;
            string ghichu = txtGhiChuCTrinhDTao.Text;
            string input = cbxNganh.GetItemText(cbxNganh.SelectedValue);
            int id_nganh = Int32.Parse(input);
            string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
            int id_tailieu = Int32.Parse(input_1);

            if (txtMaChuongTrinhDaoTao.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChuongTrinhDaoTao.Focus();
                return;
            }
            else if (txtNamKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamKy.Focus();
                return;
            }
            else if (txtNamApDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm áp dụng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamApDung.Focus();
                return;
            }
            else if (txtTomTatNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTomTatNoiDung.Focus();
                return;
            }
            else if (txtMaChuongTrinhDaoTao.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.ChuongTrinhDaoTao CTDTao WHERE CTDTao.MaChuongTrinhDaoTao = N'{0}'", machuongtrinhdaotao);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã chương trình đào tạo đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaChuongTrinhDaoTao.Focus();
                    return;
                }
            }
            if (id_tailieu != 0)
            {
                string sql_1 = string.Format("SELECT * FROM dbo.ChuongTrinhDaoTao CTDTao WHERE CTDTao.ID_TaiLieu = N'{0}'", id_tailieu);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql_1))
                {
                    MessageBox.Show("Chương trình đào tạo đã tồn tại minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm chương trình đào tạo này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ChuongTrinhDaoTaoBUS.Instance.InsertChuongTrinhDaoTao(id_nganh, id_tailieu, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu))
                {
                    MessageBox.Show("Thêm chương trình đào tạo thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertChuongTrinhDaoTao != null)
                    {
                        insertChuongTrinhDaoTao(this, new EventArgs());
                    }
                    ChuongTrinhDaoTaoBinding();
                    LoadListChuongTrinhDaoTao();
                    ResetGiaTriChuongTrinhDaoTao();
                }
                else
                {
                    MessageBox.Show("Thêm chương trình đào tạo thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        void ResetGiaTriChuongTrinhDaoTao()
        {
            txtMaChuongTrinhDaoTao.Text = "";
            txtNamKy.Text = "";
            txtNamApDung.Text = "";
            txtTomTatNoiDung.Text = "";
            txtGhiChuCTrinhDTao.Text = "";            
        }

        private event EventHandler updateChuongTrinhDaoTao;
        public event EventHandler UpdateChuongTrinhDaoTao
        {
            add { updateChuongTrinhDaoTao += value; }
            remove { updateChuongTrinhDaoTao -= value; }
        }

        private void btnSuaCTrinhDTao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa chương trình đào tạo này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaChuongTrinhDaoTao.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaChuongTrinhDaoTao.Focus();
                    return;
                }
                else if (txtNamKy.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập năm ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamKy.Focus();
                    return;
                }
                else if (txtNamApDung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập năm áp dụng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamApDung.Focus();
                    return;
                }
                else if (txtTomTatNoiDung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTomTatNoiDung.Focus();
                    return;
                }
                else
                {
                    string machuongtrinhdaotao = txtMaChuongTrinhDaoTao.Text;
                    string namky = txtNamKy.Text;
                    string namapdung = txtNamApDung.Text;
                    string tomtatnoidung = txtTomTatNoiDung.Text;
                    string ghichu = txtGhiChuCTrinhDTao.Text;
                    string sql = string.Format("SELECT ID_ChuongTrinhDaoTao FROM dbo.ChuongTrinhDaoTao CTDTao WHERE CTDTao.MaChuongTrinhDaoTao = N'{0}'", machuongtrinhdaotao);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_chuongtrinhdaotao = Int32.Parse(input);
                    string input_1 = cbxNganh.GetItemText(cbxNganh.SelectedValue);
                    int id_nganh = Int32.Parse(input_1);
                    string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
                    int id_tailieu = Int32.Parse(input_2);

                    if (ChuongTrinhDaoTaoBUS.Instance.UpdateChuongTrinhDaoTao(id_chuongtrinhdaotao, id_nganh, id_tailieu, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu))
                    {
                        MessageBox.Show("Sửa chương trình đào tạo thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateChuongTrinhDaoTao != null)
                        {
                            updateChuongTrinhDaoTao(this, new EventArgs());
                        }
                        ChuongTrinhDaoTaoBinding();
                        LoadListChuongTrinhDaoTao();
                        ResetGiaTriChuongTrinhDaoTao();
                    }
                    else
                    {
                        MessageBox.Show("Sửa chương trình đào tạo thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteChuongTrinhDaoTao;
        public event EventHandler DeleteChuongTrinhDaoTao
        {
            add { deleteChuongTrinhDaoTao += value; }
            remove { deleteChuongTrinhDaoTao -= value; }
        }

        private void btnXoaCTrinhDTao_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chương trình đào tạo này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaChuongTrinhDaoTao.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaChuongTrinhDaoTao.Focus();
                    return;
                }
                else
                {
                    string machuongtrinhdaotao = txtMaChuongTrinhDaoTao.Text;
                    string sql = string.Format("SELECT ID_ChuongTrinhDaoTao FROM dbo.ChuongTrinhDaoTao CTDTao WHERE CTDTao.MaChuongTrinhDaoTao = N'{0}'", machuongtrinhdaotao);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_chuongtrinhdaotao = Int32.Parse(input);

                    if (ChuongTrinhDaoTaoBUS.Instance.DeleteChuongTrinhDaoTao(id_chuongtrinhdaotao))
                    {
                        MessageBox.Show("Xóa chương trình đào tạo thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteChuongTrinhDaoTao != null)
                        {
                            deleteChuongTrinhDaoTao(this, new EventArgs());
                        }
                        ChuongTrinhDaoTaoBinding();
                        LoadListChuongTrinhDaoTao();
                        ResetGiaTriChuongTrinhDaoTao();
                    }
                    else
                    {
                        MessageBox.Show("Xóa chương trình đào tạo thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemCTrinhDTao_Click(object sender, EventArgs e)
        {
            string timkiemchuongtrinhdaotao = txtMaChuongTrinhDaoTao.Text;
            if (txtMaChuongTrinhDaoTao.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChuongTrinhDaoTao.Focus();
                return;
            }

            dgvChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.SearchListChuongTrinhDaoTao(timkiemchuongtrinhdaotao);
            dgvChuongTrinhDaoTao.Columns[0].Visible = false;
            dgvChuongTrinhDaoTao.Columns[1].Visible = false;
            dgvChuongTrinhDaoTao.Columns[2].Visible = false;
            dgvChuongTrinhDaoTao.Columns[3].HeaderText = "Mã Ngành";
            dgvChuongTrinhDaoTao.Columns[4].HeaderText = "Tên Tên Ngành";
            dgvChuongTrinhDaoTao.Columns[5].HeaderText = "Mã Tài Liệu";
            dgvChuongTrinhDaoTao.Columns[6].HeaderText = "Tên Tài Liệu";
            dgvChuongTrinhDaoTao.Columns[7].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTao.Columns[8].HeaderText = "Năm Ký";
            dgvChuongTrinhDaoTao.Columns[9].HeaderText = "Năm Áp Dụng";
            dgvChuongTrinhDaoTao.Columns[10].HeaderText = "Tóm Tắt Nội Dung";
            dgvChuongTrinhDaoTao.Columns[11].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvChuongTrinhDaoTao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTao.AllowUserToAddRows = false;
            dgvChuongTrinhDaoTao.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvChuongTrinhDaoTao.AutoGenerateColumns = false;

            dgvChuongTrinhDaoTao.EnableHeadersVisualStyles = false;
            dgvChuongTrinhDaoTao.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            ChuongTrinhDaoTaoBinding();
            ResetGiaTriChuongTrinhDaoTao();
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhoa.CurrentCell == null || dgvKhoa.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên khoa !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvKhoa.CurrentRow.Selected = true;
                txtMaKhoa.Text = dgvKhoa.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenKhoa.Text = dgvKhoa.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtGhiChuKhoa.Text = dgvKhoa.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
        }

        private void dgvNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNganh.CurrentCell == null || dgvNganh.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvNganh.CurrentRow.Selected = true;
                txtMaNganh.Text = dgvNganh.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtTenNganh.Text = dgvNganh.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtGhiChuNganh.Text = dgvNganh.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            }
        }

        private void dgvChuongTrinhDaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvChuongTrinhDaoTao.CurrentCell == null || dgvChuongTrinhDaoTao.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột mã chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvChuongTrinhDaoTao.CurrentRow.Selected = true;
                txtMaChuongTrinhDaoTao.Text = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
                txtNamKy.Text = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells[8].FormattedValue.ToString();
                txtNamApDung.Text = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells[9].FormattedValue.ToString();
                txtTomTatNoiDung.Text = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells[10].FormattedValue.ToString();
                txtGhiChuCTrinhDTao.Text = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells[11].FormattedValue.ToString();
            }
        }
    }
}

