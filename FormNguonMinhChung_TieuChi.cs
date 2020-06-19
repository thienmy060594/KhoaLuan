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
    public partial class FormNguonMinhChungTieuChi : Form
    {
        BindingSource NguonMinhChungList = new BindingSource();
        BindingSource TieuChiNguonMinhChungList = new BindingSource();
        public FormNguonMinhChungTieuChi()
        {
            InitializeComponent();
            dgvNguonMinhChung.DataSource = NguonMinhChungList;
            LoadListNguonMinhChung();
            dgvTieuChiNguonMinhChung.DataSource = TieuChiNguonMinhChungList;
            LoadListTieuChiNguonMinhChung();
            FillComBoBox();
        }

        private void LoadListNguonMinhChung()
        {
            dgvNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            dgvNguonMinhChung.Columns[0].Visible = false;
            dgvNguonMinhChung.Columns[1].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[2].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[3].HeaderText = "Nội Dung Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvNguonMinhChung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChung.AllowUserToAddRows = false;
            dgvNguonMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvNguonMinhChung.AutoGenerateColumns = false;

            dgvNguonMinhChung.EnableHeadersVisualStyles = false;
            dgvNguonMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void NguonMinhChungBinding()
        {
            txtMaNguonMinhChung.DataBindings.Clear();
            txtTenNguonMinhChung.DataBindings.Clear();
            txtNoiDungNguonMinhChung.DataBindings.Clear();
            txtGhiChuNMChung.DataBindings.Clear();            
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvTieuChiNguonMinhChung[column, row];
            DataGridViewCell cell2 = dgvTieuChiNguonMinhChung[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvTieuChiNguonMinhChung_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvTieuChiNguonMinhChung.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvTieuChiNguonMinhChung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListTieuChiNguonMinhChung()
        {
            dgvTieuChiNguonMinhChung.DataSource = TieuChi_NguonMinhChungBUS.Instance.GetListTieuChi_NguonMinhChung();
            dgvTieuChiNguonMinhChung.Columns[0].Visible = false;
            dgvTieuChiNguonMinhChung.Columns[1].Visible = false;
            dgvTieuChiNguonMinhChung.Columns[2].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiNguonMinhChung.Columns[3].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChiNguonMinhChung.Columns[4].HeaderText = "Tên Nguồn Minh Chứng";
            dgvTieuChiNguonMinhChung.Columns[5].HeaderText = "Nội Dung Nguồn Minh Chứng";
            dgvTieuChiNguonMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChiNguonMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChiNguonMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvTieuChiNguonMinhChung.AutoGenerateColumns = false;

            dgvTieuChiNguonMinhChung.EnableHeadersVisualStyles = false;
            dgvTieuChiNguonMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void TieuChiNguonMinhChungBinding()
        {
            txtGhiChuTChiNMChung.DataBindings.Clear();
        }

        private void FillComBoBox()
        {
            cbxTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            cbxTieuChi.ValueMember = "ID_TieuChi";
            cbxTieuChi.DisplayMember = "TenTieuChi";
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
        }

        private event EventHandler insertNguonMinhChung;
        public event EventHandler InsertNguonMinhChung
        {
            add { insertNguonMinhChung += value; }
            remove { insertNguonMinhChung -= value; }
        }

        private void btnThemMoiNMChung_Click(object sender, EventArgs e)
        {
            string manguonminhchung = txtMaNguonMinhChung.Text;
            string tennguonminhchung = txtTenNguonMinhChung.Text;
            string noidungnguonminhchung = txtNoiDungNguonMinhChung.Text;
            string ghichu = txtGhiChuNMChung.Text;

            if (txtMaNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNguonMinhChung.Focus();
                return;
            }
            else if (txtTenNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguonMinhChung.Focus();
                return;
            }
            else if (txtNoiDungNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungNguonMinhChung.Focus();
                return;
            }
            else if (txtMaNguonMinhChung.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.NguonMinhChung NMChung WHERE NMChung.MaNguonMinhChung = N'{0}'", manguonminhchung);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã nguồn minh chứng đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNguonMinhChung.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChungBUS.Instance.InsertNguonMinhChung(manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu))
                {
                    MessageBox.Show("Thêm nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNguonMinhChung != null)
                    {
                        insertNguonMinhChung(this, new EventArgs());
                    }
                    NguonMinhChungBinding();
                    LoadListNguonMinhChung();
                    ResetGiaTriNguonMinhChung();
                }
                else
                {
                    MessageBox.Show("Thêm nguồn minh chứng mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriNguonMinhChung()
        {
            txtMaNguonMinhChung.Text = "";
            txtTenNguonMinhChung.Text = "";
            txtNoiDungNguonMinhChung.Text = "";
            txtGhiChuNMChung.Text = "";            
        }

        private event EventHandler updateNguonMinhChung;
        public event EventHandler UpdateNguonMinhChung
        {
            add { updateNguonMinhChung += value; }
            remove { updateNguonMinhChung -= value; }
        }

        private void btnSuaNMChung_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNguonMinhChung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNguonMinhChung.Focus();
                    return;
                }
                else if (txtTenNguonMinhChung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNguonMinhChung.Focus();
                    return;
                }
                else if (txtNoiDungNguonMinhChung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoiDungNguonMinhChung.Focus();
                    return;
                }
                else
                {

                    string manguonminhchung = txtMaNguonMinhChung.Text;
                    string tennguonminhchung = txtTenNguonMinhChung.Text;
                    string noidungnguonminhchung = txtNoiDungNguonMinhChung.Text;
                    string ghichu = txtGhiChuNMChung.Text;
                    string sql = string.Format("SELECT ID_NguonMinhChung FROM dbo.NguonMinhChung NMChung WHERE NMChung.MaNguonMinhChung = N'{0}'", manguonminhchung);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nguonminhchung = Int32.Parse(input);

                    if (NguonMinhChungBUS.Instance.UpdateNguonMinhChung(id_nguonminhchung, manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu))
                    {
                        MessageBox.Show("Sửa nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateNguonMinhChung != null)
                        {
                            updateNguonMinhChung(this, new EventArgs());
                        }
                        NguonMinhChungBinding();
                        LoadListNguonMinhChung();
                        ResetGiaTriNguonMinhChung();
                    }
                    else
                    {
                        MessageBox.Show("Sửa nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteNguonMinhChung;
        public event EventHandler DeleteNguonMinhChung
        {
            add { deleteNguonMinhChung += value; }
            remove { deleteNguonMinhChung -= value; }
        }

        private void btnXoaNMChung_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNguonMinhChung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNguonMinhChung.Focus();
                    return;
                }
                else
                {
                    string manguonminhchung = txtMaNguonMinhChung.Text;
                    string sql = string.Format("SELECT ID_NguonMinhChung FROM dbo.NguonMinhChung NMChung WHERE NMChung.MaNguonMinhChung = N'{0}'", manguonminhchung);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nguonminhchung = Int32.Parse(input);

                    if (NguonMinhChungBUS.Instance.DeleteNguonMinhChung(id_nguonminhchung))
                    {
                        MessageBox.Show("Xóa nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteNguonMinhChung != null)
                        {
                            deleteNguonMinhChung(this, new EventArgs());
                        }
                        NguonMinhChungBinding();
                        LoadListNguonMinhChung();
                        ResetGiaTriNguonMinhChung();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriNguonMinhChung();
            ResetGiaTriTieuChiNguonMinhChung();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private event EventHandler insertTieuChiNguonMinhChung;
        public event EventHandler InsertTieuChiNguonMinhChung
        {
            add { insertTieuChiNguonMinhChung += value; }
            remove { insertTieuChiNguonMinhChung -= value; }
        }

        private void btnThemMoiTChiNMChung_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChuTChiNMChung.Text;
            string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
            int id_tieuchi = Int32.Parse(input_1);
            string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm tiêu chí - nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_NguonMinhChungBUS.Instance.InsertTieuChi_NguonMinhChung(id_tieuchi, id_nguonminhchung, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí - nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChiNguonMinhChung != null)
                    {
                        insertTieuChiNguonMinhChung(this, new EventArgs());
                    }
                    TieuChiNguonMinhChungBinding();
                    LoadListTieuChiNguonMinhChung();
                    ResetGiaTriTieuChiNguonMinhChung();
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí - nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriTieuChiNguonMinhChung()
        {
            txtGhiChuTChiNMChung.Text = "";            
        }

        private event EventHandler updateTieuChiNguonMinhChung;
        public event EventHandler UpdateTieuChiNguonMinhChung
        {
            add { updateTieuChiNguonMinhChung += value; }
            remove { updateTieuChiNguonMinhChung -= value; }
        }

        private void btnSuaMoiTChiNMChung_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa tiêu chí - nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChuTChiNMChung.Text;
                string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
                int id_tieuchi = Int32.Parse(input_1);
                string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
                int id_nguonminhchung = Int32.Parse(input_2);

                if (TieuChi_NguonMinhChungBUS.Instance.UpdateTieuChi_NguonMinhChung(id_tieuchi, id_nguonminhchung, ghichu))
                {
                    MessageBox.Show("Sửa tiêu chí - nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateTieuChiNguonMinhChung != null)
                    {
                        updateTieuChiNguonMinhChung(this, new EventArgs());
                    }
                    TieuChiNguonMinhChungBinding();
                    LoadListTieuChiNguonMinhChung();
                    ResetGiaTriTieuChiNguonMinhChung();
                }
                else
                {
                    MessageBox.Show("Sửa tiêu chí - nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteTieuChiNguonMinhChung;
        public event EventHandler DeleteTieuChiNguonMinhChung
        {
            add { deleteTieuChiNguonMinhChung += value; }
            remove { deleteTieuChiNguonMinhChung -= value; }
        }

        private void btnXoaMoiTChiNMChung_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tiêu chí - nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
                int id_tieuchi = Int32.Parse(input_1);
                string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
                int id_nguonminhchung = Int32.Parse(input_2);

                if (TieuChi_NguonMinhChungBUS.Instance.DeleteTieuChi_NguonMinhChung(id_tieuchi, id_nguonminhchung))
                {
                    MessageBox.Show("Xóa tiêu chí - nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteTieuChiNguonMinhChung != null)
                    {
                        deleteTieuChiNguonMinhChung(this, new EventArgs());
                    }
                    TieuChiNguonMinhChungBinding();
                    LoadListTieuChiNguonMinhChung();
                    ResetGiaTriTieuChiNguonMinhChung();
                }
                else
                {
                    MessageBox.Show("Xóa tiêu chí - nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemMoiTChiNMChung_Click(object sender, EventArgs e)
        {
            string timkiemtieuchinguonminhchung = txtGhiChuTChiNMChung.Text;
            if (txtGhiChuTChiNMChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuTChiNMChung.Focus();
                return;
            }

            dgvTieuChiNguonMinhChung.DataSource = TieuChi_NguonMinhChungBUS.Instance.SearchListTieuChi_NguonMinhChung(timkiemtieuchinguonminhchung);
            dgvTieuChiNguonMinhChung.Columns[0].Visible = false;
            dgvTieuChiNguonMinhChung.Columns[1].Visible = false;
            dgvTieuChiNguonMinhChung.Columns[2].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiNguonMinhChung.Columns[3].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChiNguonMinhChung.Columns[4].HeaderText = "Tên Nguồn Minh Chứng";
            dgvTieuChiNguonMinhChung.Columns[5].HeaderText = "Nội Dung Nguồn Minh Chứng";
            dgvTieuChiNguonMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChiNguonMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChiNguonMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp   
            dgvTieuChiNguonMinhChung.AutoGenerateColumns = false;

            dgvTieuChiNguonMinhChung.EnableHeadersVisualStyles = false;
            dgvTieuChiNguonMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            TieuChiNguonMinhChungBinding();
            ResetGiaTriTieuChiNguonMinhChung();
        }

        private void dgvNguonMinhChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNguonMinhChung.CurrentCell == null || dgvNguonMinhChung.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvNguonMinhChung.CurrentRow.Selected = true;
                txtMaNguonMinhChung.Text = dgvNguonMinhChung.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenNguonMinhChung.Text = dgvNguonMinhChung.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtNoiDungNguonMinhChung.Text = dgvNguonMinhChung.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtGhiChuNMChung.Text = dgvNguonMinhChung.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            }
        }
    }
}

