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
    public partial class FormNhomTuChon : Form
    {
        BindingSource NhomTuChonList = new BindingSource();
        BindingSource LoaiMonList = new BindingSource();
        BindingSource MonHocNhomTuChonList = new BindingSource();
        public FormNhomTuChon()
        {
            InitializeComponent();
            dgvNhomTuChon.DataSource = NhomTuChonList;
            LoadListNhomTuChon();
            FillComBoBoxNhomTuChon();
            dgvLoaiMon.DataSource = LoaiMonList;
            LoadListLoaiMon();
            dgvMonHocNhomTuChon.DataSource = MonHocNhomTuChonList;
            LoadListMonHocNhomTuChon();
            FillComBoBoxMonHocNhomTuChon();
        }

        bool IsTheSameCellValueNhomTuChon(int column, int row)
        {
            DataGridViewCell cell1 = dgvNhomTuChon[column, row];
            DataGridViewCell cell2 = dgvNhomTuChon[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvNhomTuChon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueNhomTuChon(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvNhomTuChon.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvNhomTuChon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueNhomTuChon(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListNhomTuChon()
        {
            dgvNhomTuChon.DataSource = NhomTuChonBUS.Instance.GetListNhomTuChon();
            dgvNhomTuChon.Columns[0].Visible = false;
            dgvNhomTuChon.Columns[1].Visible = false;
            dgvNhomTuChon.Columns[2].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvNhomTuChon.Columns[3].HeaderText = "Mã Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[4].HeaderText = "Tên Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[5].HeaderText = "Số Tín Chỉ";
            dgvNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp         
            dgvNhomTuChon.AutoGenerateColumns = false;

            dgvNhomTuChon.EnableHeadersVisualStyles = false;
            dgvNhomTuChon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void NhomTuChonBinding()
        {
            txtMaNhomTuChon.DataBindings.Clear();
            txtTenNhomTuChon.DataBindings.Clear();
            txtSoTinChi.DataBindings.Clear();
            txtGhiChuNTChon.DataBindings.Clear();            
        }        

        private void FillComBoBoxNhomTuChon()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "ID_ChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "MaChuongTrinhDaoTao";
        }

        private void LoadListLoaiMon()
        {
            dgvLoaiMon.DataSource = LoaiMonBUS.Instance.GetListLoaiMon();
            dgvLoaiMon.Columns[0].Visible = false;
            dgvLoaiMon.Columns[1].HeaderText = "Mã Loại Môn";
            dgvLoaiMon.Columns[2].HeaderText = "Tên Loại Môn";
            dgvLoaiMon.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvLoaiMon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiMon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvLoaiMon.AutoGenerateColumns = false;

            dgvLoaiMon.EnableHeadersVisualStyles = false;
            dgvLoaiMon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void LoaiMonBinding()
        {
            txtMaLoaiMon.DataBindings.Clear();
            txtTenLoaiMon.DataBindings.Clear();
            txtGhiChuLMon.DataBindings.Clear();            
        }

        bool IsTheSameCellValueMonHocNhomTuChon(int column, int row)
        {
            DataGridViewCell cell1 = dgvMonHocNhomTuChon[column, row];
            DataGridViewCell cell2 = dgvMonHocNhomTuChon[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvMonHocNhomTuChon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueMonHocNhomTuChon(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvMonHocNhomTuChon.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvMonHocNhomTuChon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueMonHocNhomTuChon(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListMonHocNhomTuChon()
        {
            dgvMonHocNhomTuChon.DataSource = MonHoc_NhomTuChonBUS.Instance.GetListMonHoc_NhomTuChon();
            dgvMonHocNhomTuChon.Columns[0].Visible = false;
            dgvMonHocNhomTuChon.Columns[1].Visible = false;
            dgvMonHocNhomTuChon.Columns[2].HeaderText = "Mã Môn Học";
            dgvMonHocNhomTuChon.Columns[3].HeaderText = "Tên Môn Học";
            dgvMonHocNhomTuChon.Columns[4].HeaderText = "Mã Nhóm Tự Chọn";
            dgvMonHocNhomTuChon.Columns[5].HeaderText = "Tên Nhóm Tự Chọn";
            dgvMonHocNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvMonHocNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHocNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMonHocNhomTuChon.AutoGenerateColumns = false;

            dgvMonHocNhomTuChon.EnableHeadersVisualStyles = false;
            dgvMonHocNhomTuChon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void MonHocNhomTuChonBinding()
        {
            txtGhiChuMHocNTChon.DataBindings.Clear();            
        }

        private void FillComBoBoxMonHocNhomTuChon()
        {
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxNhomTuChon.DataSource = NhomTuChonBUS.Instance.GetListNhomTuChon();
            cbxNhomTuChon.ValueMember = "ID_NhomTuChon";
            cbxNhomTuChon.DisplayMember = "TenNhomTuChon";
        }

        private event EventHandler insertNhomTuChon;
        public event EventHandler InsertNhomTuChon
        {
            add { insertNhomTuChon += value; }
            remove { insertNhomTuChon -= value; }
        }

        private void btnThemMoiNTChon_Click(object sender, EventArgs e)
        {
            string manhomtuchon = txtMaNhomTuChon.Text;
            string tennhomtuchon = txtTenNhomTuChon.Text;
            int sotinchi = Int32.Parse(txtSoTinChi.Text);
            string ghichu = txtGhiChuNTChon.Text;
            string input = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
            int id_chuongtrinhdaotao = Int32.Parse(input);

            if (txtMaNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhomTuChon.Focus();
                return;
            }
            else if (txtTenNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhomTuChon.Focus();
                return;
            }
            else if (txtMaNhomTuChon.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã nhóm tự chọn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NhomTuChonBUS.Instance.InsertNhomTuChon(id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu))
                {
                    MessageBox.Show("Thêm nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNhomTuChon != null)
                    {
                        insertNhomTuChon(this, new EventArgs());
                    }
                    NhomTuChonBinding();
                    LoadListNhomTuChon();
                    ResetGiaTriNhomTuChon();
                }
                else
                {
                    MessageBox.Show("Thêm nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriNhomTuChon()
        {
            txtMaNhomTuChon.Text = "";
            txtTenNhomTuChon.Text = "";
            txtSoTinChi.Text = "";
            txtGhiChuNTChon.Text = "";            
        }

        private event EventHandler updateNhomTuChon;
        public event EventHandler UpdateNhomTuChon
        {
            add { updateNhomTuChon += value; }
            remove { updateNhomTuChon -= value; }
        }

        private void btnSuaNTChon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNhomTuChon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
                else if (txtTenNhomTuChon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhomTuChon.Focus();
                    return;
                }
                else if (txtSoTinChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTinChi.Focus();
                    return;
                }
                else
                {
                    string manhomtuchon = txtMaNhomTuChon.Text;
                    string tennhomtuchon = txtTenNhomTuChon.Text;
                    int sotinchi = Int32.Parse(txtSoTinChi.Text);
                    string ghichu = txtGhiChuNTChon.Text;
                    string sql = string.Format("SELECT ID_NhomTuChon FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nhomtuchon = Int32.Parse(input);
                    string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
                    int id_chuongtrinhdaotao = Int32.Parse(input_1);

                    if (NhomTuChonBUS.Instance.UpdateNhomTuChon(id_nhomtuchon, id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu))
                    {
                        MessageBox.Show("Sửa nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateNhomTuChon != null)
                        {
                            updateNhomTuChon(this, new EventArgs());
                        }
                        NhomTuChonBinding();
                        LoadListNhomTuChon();
                        ResetGiaTriNhomTuChon();
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteNhomTuChon;
        public event EventHandler DeleteNhomTuChon
        {
            add { deleteNhomTuChon += value; }
            remove { deleteNhomTuChon -= value; }
        }

        private void btnXoaNTChon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNhomTuChon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
                else
                {
                    string manhomtuchon = txtMaNhomTuChon.Text;
                    string sql = string.Format("SELECT ID_NhomTuChon FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nhomtuchon = Int32.Parse(input);

                    if (NhomTuChonBUS.Instance.DeleteNhomTuChon(id_nhomtuchon))
                    {
                        MessageBox.Show("Xóa nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteNhomTuChon != null)
                        {
                            deleteNhomTuChon(this, new EventArgs());
                        }
                        NhomTuChonBinding();
                        LoadListNhomTuChon();
                        ResetGiaTriNhomTuChon();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemNTChon_Click(object sender, EventArgs e)
        {
            string timkiemnhomtuchon = txtTenNhomTuChon.Text;
            if (txtTenNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhomTuChon.Focus();
                return;
            }

            dgvNhomTuChon.DataSource = NhomTuChonBUS.Instance.SearchListNhomTuChon(timkiemnhomtuchon);
            dgvNhomTuChon.Columns[0].Visible = false;
            dgvNhomTuChon.Columns[1].Visible = false;
            dgvNhomTuChon.Columns[2].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvNhomTuChon.Columns[3].HeaderText = "Mã Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[4].HeaderText = "Tên Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[5].HeaderText = "Số Tín Chỉ";
            dgvNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp         
            dgvNhomTuChon.AutoGenerateColumns = false;

            dgvNhomTuChon.EnableHeadersVisualStyles = false;
            dgvNhomTuChon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            NhomTuChonBinding();
            ResetGiaTriNhomTuChon();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriNhomTuChon();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private event EventHandler insertLoaiMon;
        public event EventHandler InsertLoaiMon
        {
            add { insertLoaiMon += value; }
            remove { insertLoaiMon -= value; }
        }

        private void btnThemMoiLMon_Click(object sender, EventArgs e)
        {

            string maloaimon = txtMaLoaiMon.Text;
            string tenloaimon = txtTenLoaiMon.Text;
            string ghichu = txtGhiChuLMon.Text;

            if (txtMaLoaiMon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiMon.Focus();
                return;
            }
            else if (txtTenLoaiMon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiMon.Focus();
                return;
            }
            else if (txtMaLoaiMon.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.LoaiMon LMon WHERE LMon.MaLoaiMon = N'{0}'", maloaimon);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã loại môn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiMon.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm loại môn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiMonBUS.Instance.InsertLoaiMon(maloaimon, tenloaimon, ghichu))
                {
                    MessageBox.Show("Thêm loại môn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertLoaiMon != null)
                    {
                        insertLoaiMon(this, new EventArgs());
                    }
                    LoaiMonBinding();
                    LoadListLoaiMon();
                    ResetGiaTriLoaiMon();
                }
                else
                {
                    MessageBox.Show("Thêm loại môn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriLoaiMon()
        {
            txtMaLoaiMon.Text = "";
            txtTenLoaiMon.Text = "";
            txtGhiChuLMon.Text = "";
        }

        private event EventHandler updateLoaiMon;
        public event EventHandler UpdateLoaiMon
        {
            add { updateLoaiMon += value; }
            remove { updateLoaiMon -= value; }
        }

        private void btnSuaLMon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa loại môn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaLoaiMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiMon.Focus();
                    return;
                }
                else if (txtTenLoaiMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenLoaiMon.Focus();
                    return;
                }
                else
                {
                    string maloaimon = txtMaLoaiMon.Text;
                    string tenloaimon = txtTenLoaiMon.Text;
                    string ghichu = txtGhiChuLMon.Text;
                    string sql = string.Format("SELECT ID_LoaiMon FROM dbo.LoaiMon LMon WHERE LMon.MaLoaiMon  = N'{0}'", maloaimon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_loaimon = Int32.Parse(input);

                    if (LoaiMonBUS.Instance.UpdateLoaiMon(id_loaimon, maloaimon, tenloaimon, ghichu))
                    {
                        MessageBox.Show("Sửa loại môn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateLoaiMon != null)
                        {
                            updateLoaiMon(this, new EventArgs());
                        }
                        LoaiMonBinding();
                        LoadListLoaiMon();
                        ResetGiaTriLoaiMon();
                    }
                    else
                    {
                        MessageBox.Show("Sửa loại môn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteLoaiMon;
        public event EventHandler DeleteLoaiMon
        {
            add { deleteLoaiMon += value; }
            remove { deleteLoaiMon -= value; }
        }

        private void btnXoaLMon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại môn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaLoaiMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiMon.Focus();
                    return;
                }
                else
                {
                    string maloaimon = txtMaLoaiMon.Text;
                    string sql = string.Format("SELECT ID_LoaiMon FROM dbo.LoaiMon LMon WHERE LMon.MaLoaiMon  = N'{0}'", maloaimon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_loaimon = Int32.Parse(input);

                    if (LoaiMonBUS.Instance.DeleteLoaiMon(id_loaimon))
                    {
                        MessageBox.Show("Xóa loại môn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteLoaiMon != null)
                        {
                            deleteLoaiMon(this, new EventArgs());
                        }
                        LoaiMonBinding();
                        LoadListLoaiMon();
                        ResetGiaTriLoaiMon();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemLMon_Click(object sender, EventArgs e)
        {
            string timkiemloaimon = txtTenLoaiMon.Text;
            if (txtTenLoaiMon.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiMon.Focus();
                return;
            }

            dgvLoaiMon.DataSource = LoaiMonBUS.Instance.SearchListLoaiMon(timkiemloaimon);
            dgvLoaiMon.Columns[0].Visible = false;
            dgvLoaiMon.Columns[1].HeaderText = "Mã Loại Môn";
            dgvLoaiMon.Columns[2].HeaderText = "Tên Loại Môn";
            dgvLoaiMon.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvLoaiMon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiMon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvLoaiMon.AutoGenerateColumns = false;

            dgvLoaiMon.EnableHeadersVisualStyles = false;
            dgvLoaiMon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            LoaiMonBinding();
            ResetGiaTriLoaiMon();
        }

        private event EventHandler insertMonHocNhomTuChon;
        public event EventHandler InsertMonHocNhomTuChon
        {
            add { insertMonHocNhomTuChon += value; }
            remove { insertMonHocNhomTuChon -= value; }
        }

        private void btnThemMoiMHocNTChon_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChuMHocNTChon.Text;
            string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
            int id_monhoc = Int32.Parse(input_1);
            string input_2 = cbxNhomTuChon.GetItemText(cbxNhomTuChon.SelectedValue);
            int id_nhomtuchon = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonHoc_NhomTuChonBUS.Instance.InsertMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon, ghichu))
                {
                    MessageBox.Show("Thêm môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMonHocNhomTuChon != null)
                    {
                        insertMonHocNhomTuChon(this, new EventArgs());
                    }
                    MonHocNhomTuChonBinding();
                    LoadListMonHocNhomTuChon();
                    ResetGiaTriMonHocNhomTuChon();
                }
                else
                {
                    MessageBox.Show("Thêm môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriMonHocNhomTuChon()
        {
            txtGhiChuMHocNTChon.Text = "";            
        }

        private event EventHandler updateMonHocNhomTuChon;
        public event EventHandler UpdateMonHocNhomTuChon
        {
            add { updateMonHocNhomTuChon += value; }
            remove { updateMonHocNhomTuChon -= value; }
        }

        private void btnSuaMHocNTChon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChuMHocNTChon.Text;
                string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
                int id_monhoc = Int32.Parse(input_1);
                string input_2 = cbxNhomTuChon.GetItemText(cbxNhomTuChon.SelectedValue);
                int id_nhomtuchon = Int32.Parse(input_2);

                if (MonHoc_NhomTuChonBUS.Instance.UpdateMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon, ghichu))
                {
                    MessageBox.Show("Sửa môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateMonHocNhomTuChon != null)
                    {
                        updateMonHocNhomTuChon(this, new EventArgs());
                    }
                    MonHocNhomTuChonBinding();
                    LoadListMonHocNhomTuChon();
                    ResetGiaTriMonHocNhomTuChon();
                }
                else
                {
                    MessageBox.Show("Sửa môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteMonHocNhomTuChon;
        public event EventHandler DeleteMonHocNhomTuChon
        {
            add { deleteMonHocNhomTuChon += value; }
            remove { deleteMonHocNhomTuChon -= value; }
        }

        private void btnXoaMHocNTChon_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
                int id_monhoc = Int32.Parse(input_1);
                string input_2 = cbxNhomTuChon.GetItemText(cbxNhomTuChon.SelectedValue);
                int id_nhomtuchon = Int32.Parse(input_2);

                if (MonHoc_NhomTuChonBUS.Instance.DeleteMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon))
                {
                    MessageBox.Show("Xóa môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteMonHocNhomTuChon != null)
                    {
                        deleteMonHocNhomTuChon(this, new EventArgs());
                    }
                    MonHocNhomTuChonBinding();
                    LoadListMonHocNhomTuChon();
                    ResetGiaTriMonHocNhomTuChon();
                }
                else
                {
                    MessageBox.Show("Xóa môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemMHocNTChon_Click(object sender, EventArgs e)
        {
            string timkiemmonhocnhomtuchon = txtGhiChuMHocNTChon.Text;
            if (txtGhiChuMHocNTChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuMHocNTChon.Focus();
                return;
            }
            dgvMonHocNhomTuChon.DataSource = MonHoc_NhomTuChonBUS.Instance.SearchListMonHoc_NhomTuChon(timkiemmonhocnhomtuchon);
            dgvMonHocNhomTuChon.Columns[0].Visible = false;
            dgvMonHocNhomTuChon.Columns[1].Visible = false;
            dgvMonHocNhomTuChon.Columns[2].HeaderText = "Mã Môn Học";
            dgvMonHocNhomTuChon.Columns[3].HeaderText = "Tên Môn Học";
            dgvMonHocNhomTuChon.Columns[4].HeaderText = "Mã Nhóm Tự Chọn";
            dgvMonHocNhomTuChon.Columns[5].HeaderText = "Tên Nhóm Tự Chọn";
            dgvMonHocNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvMonHocNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHocNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMonHocNhomTuChon.AutoGenerateColumns = false;

            dgvMonHocNhomTuChon.EnableHeadersVisualStyles = false;
            dgvMonHocNhomTuChon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            MonHocNhomTuChonBinding();
            ResetGiaTriMonHocNhomTuChon();
        }

        private void dgvNhomTuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhomTuChon.CurrentCell == null || dgvNhomTuChon.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvNhomTuChon.CurrentRow.Selected = true;
                txtMaNhomTuChon.Text = dgvNhomTuChon.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtTenNhomTuChon.Text = dgvNhomTuChon.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtSoTinChi.Text = dgvNhomTuChon.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtGhiChuNTChon.Text = dgvNhomTuChon.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
            }
        }

        private void dgvLoaiMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLoaiMon.CurrentCell == null || dgvLoaiMon.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvLoaiMon.CurrentRow.Selected = true;
                txtMaLoaiMon.Text = dgvLoaiMon.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenLoaiMon.Text = dgvLoaiMon.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();                
                txtGhiChuLMon.Text = dgvLoaiMon.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
            }
        }
    }
}
