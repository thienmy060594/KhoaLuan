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

namespace KiemDinhChatLuongGUI
{
    public partial class FormMocThamChieuYeuCau : Form
    {
        BindingSource MocThamChieuList = new BindingSource();
        BindingSource YeuCauMocThamChieuList = new BindingSource();
        public FormMocThamChieuYeuCau()
        {
            InitializeComponent();
            dgvMocThamChieu.DataSource = MocThamChieuList;
            LoadListMocThamChieu();
            dgvYeuCauMocThamChieu.DataSource = YeuCauMocThamChieuList;
            LoadListYeuCauMocThamChieu();
            FillComBoBox();
        }

        private void LoadListMocThamChieu()
        {
            dgvMocThamChieu.DataSource = MocThamChieuBUS.Instance.GetListMocThamChieu();
            dgvMocThamChieu.Columns[0].Visible = false;
            dgvMocThamChieu.Columns[1].HeaderText = "Mã Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[2].HeaderText = "Tên Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[3].HeaderText = "Nội Dung Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMocThamChieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMocThamChieu.AllowUserToAddRows = false;
            dgvMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp      
            dgvMocThamChieu.AutoGenerateColumns = false;

            dgvMocThamChieu.EnableHeadersVisualStyles = false;
            dgvMocThamChieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void MocThamChieuBinding()
        {
            txtMaMocThamChieu.DataBindings.Clear();
            txtNoiDungMocThamChieu.DataBindings.Clear();
            txtTenMocThamChieu.DataBindings.Clear();
            txtGhiChuMTChieu.DataBindings.Clear();            
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvYeuCauMocThamChieu[column, row];
            DataGridViewCell cell2 = dgvYeuCauMocThamChieu[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvYeuCauMocThamChieu_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvYeuCauMocThamChieu.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvYeuCauMocThamChieu_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListYeuCauMocThamChieu()
        {
            dgvYeuCauMocThamChieu.DataSource = YeuCau_MocThamChieuBUS.Instance.GetListYeuCau_MocThamChieu();
            dgvYeuCauMocThamChieu.Columns[0].Visible = false;
            dgvYeuCauMocThamChieu.Columns[1].Visible = false;
            dgvYeuCauMocThamChieu.Columns[2].HeaderText = "Mã Yêu Cầu";
            dgvYeuCauMocThamChieu.Columns[3].HeaderText = "Tên Yêu Cầu";
            dgvYeuCauMocThamChieu.Columns[4].HeaderText = "Mã Mốc Tham Chiếu";
            dgvYeuCauMocThamChieu.Columns[5].HeaderText = "Tên Mốc Tham Chiếu";
            dgvYeuCauMocThamChieu.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvYeuCauMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCauMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp       
            dgvYeuCauMocThamChieu.AutoGenerateColumns = false;

            dgvYeuCauMocThamChieu.EnableHeadersVisualStyles = false;
            dgvYeuCauMocThamChieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void YeuCauMocThamChieuBinding()
        {
            txtGhiChuYCauMTChieu.DataBindings.Clear();            
        }

        private void FillComBoBox()
        {
            cbxYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            cbxYeuCau.ValueMember = "ID_YeuCau";
            cbxYeuCau.DisplayMember = "TenYeuCau";
            cbxMocThamChieu.DataSource = MocThamChieuBUS.Instance.GetListMocThamChieu();
            cbxMocThamChieu.ValueMember = "ID_MocThamChieu";
            cbxMocThamChieu.DisplayMember = "TenMocThamChieu";
        }

        private event EventHandler insertMocThamChieu;
        public event EventHandler InsertMocThamChieu
        {
            add { insertMocThamChieu += value; }
            remove { insertMocThamChieu -= value; }
        }

        private void btnThemMoiMTChieu_Click(object sender, EventArgs e)
        {
            string mamocthamchieu = txtMaMocThamChieu.Text;
            string tenmocthamchieu = txtTenMocThamChieu.Text;
            string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
            string ghichu = txtGhiChuMTChieu.Text;

            if (txtMaMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMocThamChieu.Focus();
                return;
            }
            else if (txtTenMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMocThamChieu.Focus();
                return;
            }
            else if (txtNoiDungMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungMocThamChieu.Focus();
                return;
            }
            else if (txtMaMocThamChieu.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.MocThamChieu MTChieu WHERE MTChieu.MaMocThamChieu = N'{0}'", mamocthamchieu);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã mốc tham chiếu đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMocThamChieu.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm mới mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MocThamChieuBUS.Instance.InsertMocThamChieu(mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMocThamChieu != null)
                    {
                        insertMocThamChieu(this, new EventArgs());
                    }
                    MocThamChieuBinding();
                    LoadListMocThamChieu();
                    ResetGiaTriMocThamChieu();
                }
                else
                {
                    MessageBox.Show("Thêm mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriMocThamChieu()
        {
            txtMaMocThamChieu.Text = "";
            txtNoiDungMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtGhiChuMTChieu.Text = "";           
        }

        private event EventHandler updateMocThamChieu;
        public event EventHandler UpdateMocThamChieu
        {
            add { updateMocThamChieu += value; }
            remove { updateMocThamChieu -= value; }
        }

        private void btnSuaMTChieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa mốc tham chiếu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMocThamChieu.Focus();
                    return;
                }
                else if (txtTenMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMocThamChieu.Focus();
                    return;
                }
                else if (txtNoiDungMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMocThamChieu.Focus();
                    return;
                }
                else
                {
                    string mamocthamchieu = txtMaMocThamChieu.Text;
                    string tenmocthamchieu = txtTenMocThamChieu.Text;
                    string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
                    string ghichu = txtGhiChuMTChieu.Text;
                    string sql = string.Format("SELECT ID_MocThamChieu FROM dbo.MocthamChieu MTChieu WHERE MTChieu.MaMocThamChieu = N'{0}'", mamocthamchieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_mocthamchieu = Int32.Parse(input);

                    if (MocThamChieuBUS.Instance.UpdateMocThamChieu(id_mocthamchieu, mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                    {
                        MessageBox.Show("Sửa mốc tham chiếu  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateMocThamChieu != null)
                        {
                            updateMocThamChieu(this, new EventArgs());
                        }
                        MocThamChieuBinding();
                        LoadListMocThamChieu();
                        ResetGiaTriMocThamChieu();
                    }
                    else
                    {
                        MessageBox.Show("Sửa mốc tham chiếu  thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteMocThamChieu;
        public event EventHandler DeleteMocThamChieu
        {
            add { deleteMocThamChieu += value; }
            remove { deleteMocThamChieu -= value; }
        }

        private void btnXoaMTChieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa mốc tham chiếu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaMocThamChieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMocThamChieu.Focus();
                    return;
                }
                else
                {
                    string mamocthamchieu = txtMaMocThamChieu.Text;
                    string sql = string.Format("SELECT ID_MocThamChieu FROM dbo.MocthamChieu MTChieu WHERE MTChieu.MaMocThamChieu = N'{0}'", mamocthamchieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_mocthamchieu = Int32.Parse(input);

                    if (MocThamChieuBUS.Instance.DeleteMocThamChieu(id_mocthamchieu))
                    {
                        MessageBox.Show("Xóa mốc tham chiếu  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteMocThamChieu != null)
                        {
                            deleteMocThamChieu(this, new EventArgs());
                        }
                        MocThamChieuBinding();
                        LoadListMocThamChieu();
                        ResetGiaTriMocThamChieu();
                    }
                    else
                    {
                        MessageBox.Show("Xóa mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriMocThamChieu();
            ResetGiaTriYeuCauMocThamChieu();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiemMTChieu_Click(object sender, EventArgs e)
        {
            string timkiemmocthamchieu = txtTenMocThamChieu.Text;
            if (txtTenMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMocThamChieu.Focus();
                return;
            }

            dgvMocThamChieu.DataSource = MocThamChieuBUS.Instance.SearchListMocThamChieu(timkiemmocthamchieu);
            dgvMocThamChieu.Columns[0].Visible = false;
            dgvMocThamChieu.Columns[1].HeaderText = "Mã Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[2].HeaderText = "Tên Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[3].HeaderText = "Nội Dung Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMocThamChieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMocThamChieu.AllowUserToAddRows = false;
            dgvMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp      
            dgvMocThamChieu.AutoGenerateColumns = false;

            dgvMocThamChieu.EnableHeadersVisualStyles = false;
            dgvMocThamChieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            MocThamChieuBinding();
            ResetGiaTriMocThamChieu();
        }

        private event EventHandler insertYeuCauMocThamChieu;
        public event EventHandler InsertYeuCauMocThamChieu
        {
            add { insertYeuCauMocThamChieu += value; }
            remove { insertYeuCauMocThamChieu -= value; }
        }

        private void btnThemMoiYeuCauMTChieu_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChuYCauMTChieu.Text;
            string input_1 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
            int id_yeucau = Int32.Parse(input_1);
            string input_2 = cbxMocThamChieu.GetItemText(cbxMocThamChieu.SelectedValue); ;
            int id_mocthamchieu = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCau_MocThamChieuBUS.Instance.InsertYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertYeuCauMocThamChieu != null)
                    {
                        insertYeuCauMocThamChieu(this, new EventArgs());
                    }
                    YeuCauMocThamChieuBinding();
                    LoadListYeuCauMocThamChieu();
                    ResetGiaTriYeuCauMocThamChieu();                    
                }
                else
                {
                    MessageBox.Show("Thêm yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        void ResetGiaTriYeuCauMocThamChieu()
        {
            txtGhiChuYCauMTChieu.Text = "";            
        }

        private event EventHandler updateYeuCauMocThamChieu;
        public event EventHandler UpdateYeuCauMocThamChieu
        {
            add { updateYeuCauMocThamChieu += value; }
            remove { updateYeuCauMocThamChieu -= value; }
        }

        private void btnSuaYeuCauMTChieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChuYCauMTChieu.Text;
                string input_1 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
                int id_yeucau = Int32.Parse(input_1);
                string input_2 = cbxMocThamChieu.GetItemText(cbxMocThamChieu.SelectedValue); ;
                int id_mocthamchieu = Int32.Parse(input_2);

                if (YeuCau_MocThamChieuBUS.Instance.UpdateYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu, ghichu))
                {
                    MessageBox.Show("Sửa yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateYeuCauMocThamChieu != null)
                    {
                        updateYeuCauMocThamChieu(this, new EventArgs());
                    }
                    YeuCauMocThamChieuBinding();
                    LoadListYeuCauMocThamChieu();
                    ResetGiaTriYeuCauMocThamChieu();
                }
                else
                {
                    MessageBox.Show("Sửa yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteYeuCauMocThamChieu;
        public event EventHandler DeleteYeuCauMocThamChieu
        {
            add { deleteYeuCauMocThamChieu += value; }
            remove { deleteYeuCauMocThamChieu -= value; }
        }

        private void btnXoaYeuCauMTChieu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string input_1 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
                int id_yeucau = Int32.Parse(input_1);
                string input_2 = cbxMocThamChieu.GetItemText(cbxMocThamChieu.SelectedValue); ;
                int id_mocthamchieu = Int32.Parse(input_2);

                if (YeuCau_MocThamChieuBUS.Instance.DeleteYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu))
                {
                    MessageBox.Show("Xóa yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteYeuCauMocThamChieu != null)
                    {
                        deleteYeuCauMocThamChieu(this, new EventArgs());
                    }
                    YeuCauMocThamChieuBinding();
                    LoadListYeuCauMocThamChieu();
                    ResetGiaTriYeuCauMocThamChieu();
                }
                else
                {
                    MessageBox.Show("Xóa yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemYeuCauMTChieu_Click(object sender, EventArgs e)
        {
            string timkiemyeucaumocthamchieu = txtGhiChuYCauMTChieu.Text;
            if (txtGhiChuYCauMTChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuYCauMTChieu.Focus();
                return;
            }

            dgvYeuCauMocThamChieu.DataSource = YeuCau_MocThamChieuBUS.Instance.SearchListYeuCau_MocThamChieu(timkiemyeucaumocthamchieu);
            dgvYeuCauMocThamChieu.Columns[0].Visible = false;
            dgvYeuCauMocThamChieu.Columns[1].Visible = false;
            dgvYeuCauMocThamChieu.Columns[2].HeaderText = "Mã Yêu Cầu";
            dgvYeuCauMocThamChieu.Columns[3].HeaderText = "Tên Yêu Cầu";
            dgvYeuCauMocThamChieu.Columns[4].HeaderText = "Mã Mốc Tham Chiếu";
            dgvYeuCauMocThamChieu.Columns[5].HeaderText = "Tên Mốc Tham Chiếu";
            dgvYeuCauMocThamChieu.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvYeuCauMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCauMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp       
            dgvYeuCauMocThamChieu.AutoGenerateColumns = false;

            dgvYeuCauMocThamChieu.EnableHeadersVisualStyles = false;
            dgvYeuCauMocThamChieu.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            YeuCauMocThamChieuBinding();
            ResetGiaTriYeuCauMocThamChieu();
        }

        private void dgvMocThamChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMocThamChieu.CurrentCell == null || dgvMocThamChieu.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvMocThamChieu.CurrentRow.Selected = true;
                txtMaMocThamChieu.Text = dgvMocThamChieu.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenMocThamChieu.Text = dgvMocThamChieu.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtNoiDungMocThamChieu.Text = dgvMocThamChieu.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtGhiChuMTChieu.Text = dgvMocThamChieu.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            }
        }
    }       
}
