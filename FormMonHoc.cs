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
    public partial class FormMonHoc : Form
    {
        BindingSource MonHocList = new BindingSource();
        BindingSource MonTienQuyetList = new BindingSource();
        BindingSource ChuongTrinhDaoTaoMonHocList = new BindingSource();
        public FormMonHoc()
        {
            InitializeComponent();
            dgvMonHoc.DataSource = MonHocList;
            LoadListMonHoc();
            dgvMonTienQuyet.DataSource = MonTienQuyetList;
            LoadListMonTienQuyet();
            FillComBoBoxMonTienQuyet();
            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTaoMonHocList;
            LoadListChuongTrinhDaoTaoMonHoc();
            FillComBoBoxChuongTrinhDaoTaoMonHoc();
        }

        private void LoadListMonHoc()
        {
            dgvMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            dgvMonHoc.Columns[0].Visible = false;
            dgvMonHoc.Columns[1].HeaderText = "Mã Môn Học";
            dgvMonHoc.Columns[2].HeaderText = "Tên Môn Học";
            dgvMonHoc.Columns[3].HeaderText = "Tên Tiếng Anh";
            dgvMonHoc.Columns[4].HeaderText = "Số Tín Chỉ";
            dgvMonHoc.Columns[5].HeaderText = "Số Tiết Lý Thuyết";
            dgvMonHoc.Columns[6].HeaderText = "Số Tiết Thực Hành";
            dgvMonHoc.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMonHoc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMonHoc.AutoGenerateColumns = false;

            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void MonHocBinding()
        {
            txtMaMonHoc.DataBindings.Clear();
            txtTenMonHoc.DataBindings.Clear();
            txtTenTiengAnh.DataBindings.Clear();
            txtSoTinChi.DataBindings.Clear();
            txtSoTietLyThuyet.DataBindings.Clear();
            txtSoTietThucHanh.DataBindings.Clear();
            txtGhiChuMHoc.DataBindings.Clear();            
        }

        bool IsTheSameCellValueMonTienQuyet(int column, int row)
        {
            DataGridViewCell cell1 = dgvMonTienQuyet[column, row];
            DataGridViewCell cell2 = dgvMonTienQuyet[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvMonTienQuyet_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueMonTienQuyet(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvMonTienQuyet.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvMonTienQuyet_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueMonTienQuyet(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListMonTienQuyet()
        {
            dgvMonTienQuyet.DataSource = MonTienQuyetBUS.Instance.GetListMonTienQuyet();
            dgvMonTienQuyet.Columns[0].Visible = false;
            dgvMonTienQuyet.Columns[1].Visible = false;
            dgvMonTienQuyet.Columns[2].HeaderText = "Mã Môn Học";
            dgvMonTienQuyet.Columns[3].HeaderText = "Tên Môn Học";
            dgvMonTienQuyet.Columns[4].HeaderText = "Mã Môn Tiên Quyết";
            dgvMonTienQuyet.Columns[5].HeaderText = "Tên Môn Tiên Quyết";
            dgvMonTienQuyet.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvMonTienQuyet.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonTienQuyet.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvMonTienQuyet.AutoGenerateColumns = false;

            dgvMonTienQuyet.EnableHeadersVisualStyles = false;
            dgvMonTienQuyet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void MonTienQuyetBinding()
        {
            txtGhiChuMTQuyet.DataBindings.Clear();            
        }

        private void FillComBoBoxMonTienQuyet()
        {
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxMonTienQuyet.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonTienQuyet.ValueMember = "ID_MonHoc";
            cbxMonTienQuyet.DisplayMember = "TenMonHoc";
        }

        bool IsTheSameCellValueChuongTrinhDaoTaoMonHoc(int column, int row)
        {
            DataGridViewCell cell1 = dgvChuongTrinhDaoTaoMonHoc[column, row];
            DataGridViewCell cell2 = dgvChuongTrinhDaoTaoMonHoc[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvChuongTrinhDaoTaoMonHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValueChuongTrinhDaoTaoMonHoc(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvChuongTrinhDaoTaoMonHoc.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvChuongTrinhDaoTaoMonHoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValueChuongTrinhDaoTaoMonHoc(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListChuongTrinhDaoTaoMonHoc()
        {
            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocBUS.Instance.GetListChuongTrinhDaoTao_MonHoc();
            dgvChuongTrinhDaoTaoMonHoc.Columns[0].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[1].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[2].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].HeaderText = "Mã Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].HeaderText = "Tên Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].HeaderText = "Mã Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].HeaderText = "Tên Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].HeaderText = "Học Kỳ";
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTaoMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp 
            dgvChuongTrinhDaoTaoMonHoc.AutoGenerateColumns = false;

            dgvChuongTrinhDaoTaoMonHoc.EnableHeadersVisualStyles = false;
            dgvChuongTrinhDaoTaoMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void ChuongTrinhDaoTaoMonHocBinding()
        {
            txtHocKy.DataBindings.Clear();
            txtGhiChuCTDTaoMHoc.DataBindings.Clear();            
        }

        private void FillComBoBoxChuongTrinhDaoTaoMonHoc()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "ID_ChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "MaChuongTrinhDaoTao";
            cbxMonHoc1.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc1.ValueMember = "ID_MonHoc";
            cbxMonHoc1.DisplayMember = "TenMonHoc";
            cbxLoaiMon.DataSource = LoaiMonBUS.Instance.GetListLoaiMon();
            cbxLoaiMon.ValueMember = "ID_LoaiMon";
            cbxLoaiMon.DisplayMember = "TenLoaiMon";
        }

        private event EventHandler insertMonHoc;
        public event EventHandler InserMonHoc
        {
            add { insertMonHoc += value; }
            remove { insertMonHoc -= value; }
        }

        private void btnThemMoiMHoc_Click(object sender, EventArgs e)
        {
            if (txtMaMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMonHoc.Focus();
                return;
            }
            else if (txtTenMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMonHoc.Focus();
                return;
            }
            else if (txtTenTiengAnh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiếng anh !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTiengAnh.Focus();
                return;
            }
            else if (txtSoTinChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTinChi.Focus();
                return;
            }
            else if (txtSoTietLyThuyet.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiết lý thuyết !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTietLyThuyet.Focus();
                return;
            }
            else if (txtSoTietThucHanh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiết thực hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTietThucHanh.Focus();
                return;
            }
            else if (txtMaMonHoc.Text != "")
            {
                string mamonhoc = txtMaMonHoc.Text;
                string sql = string.Format("SELECT * FROM dbo.MonHoc MHoc WHERE MHoc.MaMonHoc = N'{0}'", mamonhoc);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã môn học này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMonHoc.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string mamonhoc = txtMaMonHoc.Text;
                string tenmonhoc = txtTenMonHoc.Text;
                string tentienganh = txtTenTiengAnh.Text;
                string ghichu = txtGhiChuMHoc.Text;
                int sotinchi = Int32.Parse(txtSoTinChi.Text);
                int sotietlythuyet = Int32.Parse(txtSoTietLyThuyet.Text);
                int sotietthuchanh = Int32.Parse(txtSoTietThucHanh.Text);

                if (MonHocBUS.Instance.InsertMonHoc(mamonhoc, tenmonhoc, tentienganh, sotinchi, sotietlythuyet, sotietthuchanh, ghichu))
                {
                    MessageBox.Show("Thêm môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMonHoc != null)
                    {
                        insertMonHoc(this, new EventArgs());
                    }
                    MonHocBinding();
                    LoadListMonHoc();
                    ResetGiaTriMonHoc();
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriMonHoc()
        {
            txtMaMonHoc.Text = "";
            txtTenMonHoc.Text = "";
            txtTenTiengAnh.Text = "";
            txtSoTinChi.Text = "";
            txtSoTietLyThuyet.Text = "";
            txtSoTietThucHanh.Text = "";
            txtGhiChuMHoc.Text = "";            
        }

        private event EventHandler updateMonHoc;
        public event EventHandler UpdateMonHoc
        {
            add { updateMonHoc += value; }
            remove { updateMonHoc -= value; }
        }

        private void btnSuaMHoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMonHoc.Focus();
                    return;
                }
                else if (txtTenMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMonHoc.Focus();
                    return;
                }
                else if (txtTenTiengAnh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tiếng anh !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTiengAnh.Focus();
                    return;
                }
                else if (txtSoTinChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTinChi.Focus();
                    return;
                }
                else if (txtSoTietLyThuyet.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tiết lý thuyết !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTietLyThuyet.Focus();
                    return;
                }
                else if (txtSoTietThucHanh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tiết thực hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTietThucHanh.Focus();
                    return;
                }
                else
                {
                    string mamonhoc = txtMaMonHoc.Text;
                    string tenmonhoc = txtTenMonHoc.Text;
                    string tentienganh = txtTenTiengAnh.Text;
                    int sotinchi = Int32.Parse(txtSoTinChi.Text);
                    int sotietlythuyet = Int32.Parse(txtSoTietLyThuyet.Text);
                    int sotietthuchanh = Int32.Parse(txtSoTietThucHanh.Text);
                    string ghichu = txtGhiChuMHoc.Text;
                    string sql = string.Format("SELECT ID_MonHoc FROM dbo.MonHoc MHoc WHERE MHoc.MaMonHoc = N'{0}'", mamonhoc);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_monhoc = Int32.Parse(input);

                    if (MonHocBUS.Instance.UpdateMonHoc(id_monhoc, mamonhoc, tenmonhoc, tentienganh, sotinchi, sotietlythuyet, sotietthuchanh, ghichu))
                    {
                        MessageBox.Show("Sửa minh chứng  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateMonHoc != null)
                        {
                            updateMonHoc(this, new EventArgs());
                        }
                        MonHocBinding();
                        LoadListMonHoc();
                        ResetGiaTriMonHoc();
                    }
                    else
                    {
                        MessageBox.Show("Sửa môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteMonHoc;
        public event EventHandler DeleteMonHoc
        {
            add { deleteMonHoc += value; }
            remove { deleteMonHoc -= value; }
        }

        private void btnXoaMHoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa môn học  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMonHoc.Focus();
                    return;
                }
                else
                {
                    string mamonhoc = txtMaMonHoc.Text;
                    string sql = string.Format("SELECT ID_MonHoc FROM dbo.MonHoc MHoc WHERE MHoc.MaMonHoc = N'{0}'", mamonhoc);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_monhoc = Int32.Parse(input);

                    if (MonHocBUS.Instance.DeleteMonHoc(id_monhoc))
                    {
                        MessageBox.Show("Xóa môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteMonHoc != null)
                        {
                            deleteMonHoc(this, new EventArgs());
                        }
                        MonHocBinding();
                        LoadListMonHoc();
                        ResetGiaTriMonHoc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriMonHoc();
            ResetGiaTriMonTienQuyet();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiemMHoc_Click(object sender, EventArgs e)
        {
            string timkiemmonhoc = txtTenMonHoc.Text;
            if (txtTenMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMonHoc.Focus();
                return;
            }

            dgvMonHoc.DataSource = MonHocBUS.Instance.SearchListMonHoc(timkiemmonhoc);
            dgvMonHoc.Columns[0].Visible = false;
            dgvMonHoc.Columns[1].HeaderText = "Mã Môn Học";
            dgvMonHoc.Columns[2].HeaderText = "Tên Môn Học";
            dgvMonHoc.Columns[3].HeaderText = "Tên Tiếng Anh";
            dgvMonHoc.Columns[4].HeaderText = "Số Tín Chỉ";
            dgvMonHoc.Columns[5].HeaderText = "Số Tiết Lý Thuyết";
            dgvMonHoc.Columns[6].HeaderText = "Số Tiết Thực Hành";
            dgvMonHoc.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMonHoc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMonHoc.AutoGenerateColumns = false;

            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            MonHocBinding();
            ResetGiaTriMonHoc();
        }

        private event EventHandler insertMonTienQuyet;
        public event EventHandler InsertMonTienQuyet
        {
            add { insertMonTienQuyet += value; }
            remove { insertMonTienQuyet -= value; }
        }

        private void btnThemMoiMTQuyet_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChuMTQuyet.Text;
            string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
            int id_monhoc = Int32.Parse(input_1);
            string input_2 = cbxMonTienQuyet.GetItemText(cbxMonTienQuyet.SelectedValue);
            int id_monhoc_tienquyet = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm môn tiên quyết này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonTienQuyetBUS.Instance.InsertMonTienQuyet(id_monhoc, id_monhoc_tienquyet, ghichu))
                {
                    MessageBox.Show("Thêm môn tiên quyết thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMonTienQuyet != null)
                    {
                        insertMonTienQuyet(this, new EventArgs());
                    }
                    MonTienQuyetBinding();
                    LoadListMonTienQuyet();
                    ResetGiaTriMonTienQuyet();
                }
                else
                {
                    MessageBox.Show("Thêm môn tiên quyết thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriMonTienQuyet()
        {
            txtGhiChuMTQuyet.Text = "";            
        }

        private event EventHandler updateMonTienQuyet;
        public event EventHandler UpdateMonTienQuyet
        {
            add { updateMonTienQuyet += value; }
            remove { updateMonTienQuyet -= value; }
        }

        private void btnSuaMTQuyet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa môn tiên quyết này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChuMTQuyet.Text;
                string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
                int id_monhoc = Int32.Parse(input_1);
                string input_2 = cbxMonTienQuyet.GetItemText(cbxMonTienQuyet.SelectedValue);
                int id_monhoc_tienquyet = Int32.Parse(input_2);

                if (MonTienQuyetBUS.Instance.UpdateMonTienQuyet(id_monhoc, id_monhoc_tienquyet, ghichu))
                {
                    MessageBox.Show("Sửa môn tiên quyết thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateMonTienQuyet != null)
                    {
                        updateMonTienQuyet(this, new EventArgs());
                    }
                    MonTienQuyetBinding();
                    LoadListMonTienQuyet();
                    ResetGiaTriMonTienQuyet();
                }
                else
                {
                    MessageBox.Show("Sửa môn tiên quyết thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteMonTienQuyet;
        public event EventHandler DeleteMonTienQuyet
        {
            add { deleteMonTienQuyet += value; }
            remove { deleteMonTienQuyet -= value; }
        }

        private void btnXoaMTQuyet_Click(object sender, EventArgs e)
        {
            string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
            int id_monhoc = Int32.Parse(input_1);
            string input_2 = cbxMonTienQuyet.GetItemText(cbxMonTienQuyet.SelectedValue);
            int id_monhoc_tienquyet = Int32.Parse(input_2);

            if (MonTienQuyetBUS.Instance.DeleteMonTienQuyet(id_monhoc, id_monhoc_tienquyet))
            {
                MessageBox.Show("Xóa môn tiên quyết thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (deleteMonTienQuyet != null)
                {
                    deleteMonTienQuyet(this, new EventArgs());
                }
                MonTienQuyetBinding();
                LoadListMonTienQuyet();
                ResetGiaTriMonTienQuyet();
            }
            else
            {
                MessageBox.Show("Xóa môn tiên quyết thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiemMTQuyet_Click(object sender, EventArgs e)
        {
            string timkiemmontienquyet = txtGhiChuMTQuyet.Text;
            if (txtGhiChuMTQuyet.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuMTQuyet.Focus();
                return;
            }

            dgvMonTienQuyet.DataSource = MonTienQuyetBUS.Instance.SearchListMonTienQuyet(timkiemmontienquyet);
            dgvMonTienQuyet.Columns[0].Visible = false;
            dgvMonTienQuyet.Columns[1].Visible = false;
            dgvMonTienQuyet.Columns[2].HeaderText = "Mã Môn Học";
            dgvMonTienQuyet.Columns[3].HeaderText = "Tên Môn Học";
            dgvMonTienQuyet.Columns[4].HeaderText = "Mã Môn Tiên Quyết";
            dgvMonTienQuyet.Columns[5].HeaderText = "Tên Môn Tiên Quyết";
            dgvMonTienQuyet.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvMonTienQuyet.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonTienQuyet.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonTienQuyet.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvMonTienQuyet.AutoGenerateColumns = false;

            dgvMonTienQuyet.EnableHeadersVisualStyles = false;
            dgvMonTienQuyet.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            MonTienQuyetBinding();
            ResetGiaTriMonTienQuyet();
        }

        private event EventHandler insertChuongTrinhDaoTaoMonHoc;
        public event EventHandler InsertChuongTrinhDaoTao_MonHoc
        {
            add { insertChuongTrinhDaoTaoMonHoc += value; }
            remove { insertChuongTrinhDaoTaoMonHoc -= value; }
        }

        private void btnThemMoiCTDTaoMHoc_Click(object sender, EventArgs e)
        {
            string hocky = txtHocKy.Text;
            string ghichu = txtGhiChuCTDTaoMHoc.Text;
            string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
            int id_chuongtrinhdaotao = Int32.Parse(input_1);
            string input_2 = cbxMonHoc1.GetItemText(cbxMonHoc1.SelectedValue);
            int id_monhoc = Int32.Parse(input_2);
            string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
            int id_loaimon = Int32.Parse(input_3);

            if (MessageBox.Show("Bạn có muốn thêm chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ChuongTrinhDaoTao_MonHocBUS.Instance.InsertChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu))
                {
                    MessageBox.Show("Thêm chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertChuongTrinhDaoTaoMonHoc != null)
                    {
                        insertChuongTrinhDaoTaoMonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTaoMonHocBinding();
                    LoadListChuongTrinhDaoTaoMonHoc();
                    ResetGiaTriChuongTrinhDaoTaoMonHoc();
                }
                else
                {
                    MessageBox.Show("Thêm chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriChuongTrinhDaoTaoMonHoc()
        {
            txtHocKy.Text = "";
            txtGhiChuCTDTaoMHoc.Text = "";            
        }

        private event EventHandler updateChuongTrinhDaoTaoMonHoc;
        public event EventHandler UpdateChuongTrinhDaoTaoMonHoc
        {
            add { updateChuongTrinhDaoTaoMonHoc += value; }
            remove { updateChuongTrinhDaoTaoMonHoc -= value; }
        }

        private void btnSuaCTDTaoMHoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string hocky = txtHocKy.Text;
                string ghichu = txtGhiChuCTDTaoMHoc.Text;
                string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
                int id_chuongtrinhdaotao = Int32.Parse(input_1);
                string input_2 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
                int id_monhoc = Int32.Parse(input_2);
                string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
                int id_loaimon = Int32.Parse(input_3);

                if (ChuongTrinhDaoTao_MonHocBUS.Instance.UpdateChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu))
                {
                    MessageBox.Show("Sửa chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateChuongTrinhDaoTaoMonHoc != null)
                    {
                        updateChuongTrinhDaoTaoMonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTaoMonHocBinding();
                    LoadListChuongTrinhDaoTaoMonHoc();
                    ResetGiaTriChuongTrinhDaoTaoMonHoc();
                }
                else
                {
                    MessageBox.Show("Sửa chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteChuongTrinhDaoTaoMonHoc;
        public event EventHandler DeleteChuongTrinhDaoTaoMonHoc
        {
            add { deleteChuongTrinhDaoTaoMonHoc += value; }
            remove { deleteChuongTrinhDaoTaoMonHoc -= value; }
        }

        private void btnXoaCTDTaoMHoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
                int id_chuongtrinhdaotao = Int32.Parse(input_1);
                string input_2 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
                int id_monhoc = Int32.Parse(input_2);
                string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
                int id_loaimon = Int32.Parse(input_3);

                if (ChuongTrinhDaoTao_MonHocBUS.Instance.DeleteChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon))
                {
                    MessageBox.Show("Xóa chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteChuongTrinhDaoTaoMonHoc != null)
                    {
                        deleteChuongTrinhDaoTaoMonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTaoMonHocBinding();
                    LoadListChuongTrinhDaoTaoMonHoc();
                    ResetGiaTriChuongTrinhDaoTaoMonHoc();
                }
                else
                {
                    MessageBox.Show("Xóa chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemCTDTaoMHoc_Click(object sender, EventArgs e)
        {
            string timkiemchuongtrinhdaotaomonhoc = txtGhiChuCTDTaoMHoc.Text;
            if (txtGhiChuCTDTaoMHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuCTDTaoMHoc.Focus();
                return;
            }

            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocBUS.Instance.SearchListChuongTrinhDaoTao_MonHoc(timkiemchuongtrinhdaotaomonhoc);
            dgvChuongTrinhDaoTaoMonHoc.Columns[0].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[1].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[2].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].HeaderText = "Mã Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].HeaderText = "Tên Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].HeaderText = "Mã Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].HeaderText = "Tên Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].HeaderText = "Học Kỳ";
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTaoMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp 
            dgvChuongTrinhDaoTaoMonHoc.AutoGenerateColumns = false;

            dgvChuongTrinhDaoTaoMonHoc.EnableHeadersVisualStyles = false;
            dgvChuongTrinhDaoTaoMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            ChuongTrinhDaoTaoMonHocBinding();
            ResetGiaTriChuongTrinhDaoTaoMonHoc();
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMonHoc.CurrentCell == null || dgvMonHoc.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvMonHoc.CurrentRow.Selected = true;
                txtMaMonHoc.Text = dgvMonHoc.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenMonHoc.Text = dgvMonHoc.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtTenTiengAnh.Text = dgvMonHoc.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtSoTinChi.Text = dgvMonHoc.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtSoTietLyThuyet.Text = dgvMonHoc.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtSoTietThucHanh.Text = dgvMonHoc.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtGhiChuMHoc.Text = dgvMonHoc.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            }
        }
    }
}

