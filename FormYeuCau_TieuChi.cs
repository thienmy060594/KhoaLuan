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
    public partial class FormYeuCauTieuChi : Form
    {
        BindingSource YeuCauList = new BindingSource();
        BindingSource TieuChiYeuCauList = new BindingSource();
        public FormYeuCauTieuChi()
        {
            InitializeComponent();
            dgvYeuCau.DataSource = YeuCauList;
            LoadListYeuCau();
            dgvTieuChiYeuCau.DataSource = TieuChiYeuCauList;
            LoadListTieuChiYeuCau();
            FillComBoBox();
        }

        private void LoadListYeuCau()
        {
            dgvYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            dgvYeuCau.Columns[0].Visible = false;
            dgvYeuCau.Columns[1].HeaderText = "Mã Yêu Cầu";
            dgvYeuCau.Columns[2].HeaderText = "Tên Yêu Cầu";
            dgvYeuCau.Columns[3].HeaderText = "Nội Dung Yêu Cầu";
            dgvYeuCau.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvYeuCau.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCau.AllowUserToAddRows = false;
            dgvYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvYeuCau.AutoGenerateColumns = false;

            dgvYeuCau.EnableHeadersVisualStyles = false;
            dgvYeuCau.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void YeuCauBinding()
        {
            txtMaYeuCau.DataBindings.Clear();
            txtTenYeuCau.DataBindings.Clear();
            txtNoiDungYeuCau.DataBindings.Clear();
            txtGhiChuYCau.DataBindings.Clear();
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvTieuChiYeuCau[column, row];
            DataGridViewCell cell2 = dgvTieuChiYeuCau[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvTieuChiYeuCau_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvTieuChiYeuCau.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvTieuChiYeuCau_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListTieuChiYeuCau()
        {
            dgvTieuChiYeuCau.DataSource = TieuChi_YeuCauBUS.Instance.GetListTieuChi_YeuCau();
            dgvTieuChiYeuCau.Columns[0].Visible = false;
            dgvTieuChiYeuCau.Columns[1].Visible = false;
            dgvTieuChiYeuCau.Columns[2].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiYeuCau.Columns[3].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChiYeuCau.Columns[4].HeaderText = "Tên Yêu Cầu";
            dgvTieuChiYeuCau.Columns[5].HeaderText = "Nội Dung Yêu Cầu";
            dgvTieuChiYeuCau.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChiYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChiYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvTieuChiYeuCau.AutoGenerateColumns = false;

            dgvTieuChiYeuCau.EnableHeadersVisualStyles = false;
            dgvTieuChiYeuCau.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void TieuChiYeuCauBinding()
        {
            txtGhiChuTChiYCau.DataBindings.Clear();            
        }

        private void FillComBoBox()
        {
            cbxTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            cbxTieuChi.ValueMember = "ID_TieuChi";
            cbxTieuChi.DisplayMember = "TenTieuChi";
            cbxYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            cbxYeuCau.ValueMember = "ID_YeuCau";
            cbxYeuCau.DisplayMember = "TenYeuCau";
        }


        private event EventHandler insertYeuCau;
        public event EventHandler InsertYeuCau
        {
            add { insertYeuCau += value; }
            remove { insertYeuCau -= value; }
        }

        private void btnThemMoiYCau_Click(object sender, EventArgs e)
        {
            string mayeucau = txtMaYeuCau.Text;
            string tenyeucau = txtTenYeuCau.Text;
            string noidungyeucau = txtNoiDungYeuCau.Text;
            string ghichu = txtGhiChuTChiYCau.Text;

            if (txtMaYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaYeuCau.Focus();
                return;
            }
            else if (txtTenYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenYeuCau.Focus();
                return;
            }
            else if (txtNoiDungYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungYeuCau.Focus();
                return;
            }
            else if (txtMaYeuCau.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.YeuCau YCau WHERE YCau.MaYeuCau = N'{0}'", mayeucau);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã yêu cầu đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaYeuCau.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCauBUS.Instance.InsertYeuCau(mayeucau, tenyeucau, noidungyeucau, ghichu))
                {
                    MessageBox.Show("Thêm yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertYeuCau != null)
                    {
                        insertYeuCau(this, new EventArgs());
                    }
                    YeuCauBinding();
                    LoadListYeuCau();
                    ResetGiaTriYeuCau();
                }
                else
                {
                    MessageBox.Show("Thêm yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriYeuCau()
        {
            txtMaYeuCau.Text = "";
            txtTenYeuCau.Text = "";
            txtNoiDungYeuCau.Text = "";
            txtGhiChuYCau.Text = "";
        }

        private event EventHandler updateYeuCau;
        public event EventHandler UpdateYeuCau
        {
            add { updateYeuCau += value; }
            remove { updateYeuCau -= value; }
        }

        private void btnSuaYCau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaYeuCau.Focus();
                    return;
                }
                else if (txtTenYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenYeuCau.Focus();
                    return;
                }
                else if (txtNoiDungYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoiDungYeuCau.Focus();
                    return;
                }
                else
                {
                    string mayeucau = txtMaYeuCau.Text;
                    string tenyeucau = txtTenYeuCau.Text;
                    string noidungyeucau = txtNoiDungYeuCau.Text;
                    string ghichu = txtGhiChuTChiYCau.Text;
                    string sql = string.Format("SELECT ID_YeuCau FROM dbo.YeuCau YCau WHERE YCau.MaYeuCau = N'{0}'", mayeucau);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_yeucau = Int32.Parse(input);

                    if (YeuCauBUS.Instance.UpdateYeuCau(id_yeucau, mayeucau, tenyeucau, noidungyeucau, ghichu))
                    {
                        MessageBox.Show("Sửa yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateYeuCau != null)
                        {
                            updateYeuCau(this, new EventArgs());
                        }
                        YeuCauBinding();
                        LoadListYeuCau();
                        ResetGiaTriYeuCau();
                    }
                    else
                    {
                        MessageBox.Show("Sửa yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteYeuCau;
        public event EventHandler DeleteYeuCau
        {
            add { deleteYeuCau += value; }
            remove { deleteYeuCau -= value; }
        }

        private void btnXoaYCau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaYeuCau.Focus();
                    return;
                }
                else
                {
                    string mayeucau = txtMaYeuCau.Text;
                    string sql = string.Format("SELECT ID_YeuCau FROM dbo.YeuCau YCau WHERE YCau.MaYeuCau = N'{0}'", mayeucau);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_yeucau = Int32.Parse(input);

                    if (YeuCauBUS.Instance.DeleteYeuCau(id_yeucau))
                    {
                        MessageBox.Show("Xóa yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteYeuCau != null)
                        {
                            deleteYeuCau(this, new EventArgs());
                        }
                        YeuCauBinding();
                        LoadListYeuCau();
                        ResetGiaTriYeuCau();
                    }
                    else
                    {
                        MessageBox.Show("Xóa yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriYeuCau();
            ResetGiaTriTieuChiYeuCau();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiemYCau_Click(object sender, EventArgs e)
        {
            string timkiemyeucau = txtTenYeuCau.Text;
            if (txtTenYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenYeuCau.Focus();
                return;
            }

            dgvYeuCau.DataSource = YeuCauBUS.Instance.SearchListYeuCau(timkiemyeucau);
            dgvYeuCau.Columns[0].Visible = false;
            dgvYeuCau.Columns[1].HeaderText = "Mã Yêu Cầu";
            dgvYeuCau.Columns[2].HeaderText = "Tên Yêu Cầu";
            dgvYeuCau.Columns[3].HeaderText = "Nội Dung Yêu Cầu";
            dgvYeuCau.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvYeuCau.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCau.AllowUserToAddRows = false;
            dgvYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvYeuCau.AutoGenerateColumns = false;

            dgvYeuCau.EnableHeadersVisualStyles = false;
            dgvYeuCau.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            YeuCauBinding();
            ResetGiaTriYeuCau();
        }

        private event EventHandler insertTieuChiYeuCau;
        public event EventHandler InsertTieuChiYeuCau
        {
            add { insertTieuChiYeuCau += value; }
            remove { insertTieuChiYeuCau -= value; }
        }

        private void btnThemMoiTChiYeuCau_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChuTChiYCau.Text;
            string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
            int id_tieuchi = Int32.Parse(input_1);
            string input_2 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
            int id_yeucau = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_YeuCauBUS.Instance.InsertTieuChi_YeuCau(id_tieuchi, id_yeucau, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChiYeuCau != null)
                    {
                        insertTieuChiYeuCau(this, new EventArgs());
                    }
                    TieuChiYeuCauBinding();
                    LoadListTieuChiYeuCau();
                    ResetGiaTriTieuChiYeuCau();
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriTieuChiYeuCau()
        {
            txtGhiChuTChiYCau.Text = "";            
        }

        private event EventHandler updateTieuChiYeuCau;
        public event EventHandler UpdateTieuChiYeuCau
        {
            add { updateTieuChiYeuCau += value; }
            remove { updateTieuChiYeuCau -= value; }
        }

        private void btnSuaTChiYeuCau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChuTChiYCau.Text;
                string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
                int id_tieuchi = Int32.Parse(input_1);
                string input_2 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
                int id_yeucau = Int32.Parse(input_2);

                if (TieuChi_YeuCauBUS.Instance.UpdateTieuChi_YeuCau(id_tieuchi, id_yeucau, ghichu))
                {
                    MessageBox.Show("Sửa tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateTieuChiYeuCau != null)
                    {
                        updateTieuChiYeuCau(this, new EventArgs());
                    }
                    TieuChiYeuCauBinding();
                    LoadListTieuChiYeuCau();
                    ResetGiaTriTieuChiYeuCau();
                }
                else
                {
                    MessageBox.Show("Sửa tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteTieuChiYeuCau;
        public event EventHandler DeleteTieuChiYeuCau
        {
            add { deleteTieuChiYeuCau += value; }
            remove { deleteTieuChiYeuCau -= value; }
        }

        private void btnXoaTChiYeuCau_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
                int id_tieuchi = Int32.Parse(input_1);
                string input_2 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
                int id_yeucau = Int32.Parse(input_2);

                if (TieuChi_YeuCauBUS.Instance.DeleteTieuChi_YeuCau(id_tieuchi, id_yeucau))
                {
                    MessageBox.Show("Xóa tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteTieuChiYeuCau != null)
                    {
                        deleteTieuChiYeuCau(this, new EventArgs());
                    }
                    TieuChiYeuCauBinding();
                    LoadListTieuChiYeuCau();
                    ResetGiaTriTieuChiYeuCau();
                }
                else
                {
                    MessageBox.Show("Xóa tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiemTChiYeuCau_Click(object sender, EventArgs e)
        {
            string timkiemtieuchiyeucau = txtGhiChuTChiYCau.Text;
            if (txtGhiChuTChiYCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGhiChuTChiYCau.Focus();
                return;
            }

            dgvTieuChiYeuCau.DataSource = TieuChi_YeuCauBUS.Instance.SearchListTieuChi_YeuCau(timkiemtieuchiyeucau);
            dgvTieuChiYeuCau.Columns[0].Visible = false;
            dgvTieuChiYeuCau.Columns[1].Visible = false;
            dgvTieuChiYeuCau.Columns[2].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiYeuCau.Columns[3].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChiYeuCau.Columns[4].HeaderText = "Tên Yêu Cầu";
            dgvTieuChiYeuCau.Columns[5].HeaderText = "Nội Dung Yêu Cầu";
            dgvTieuChiYeuCau.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChiYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChiYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvTieuChiYeuCau.AutoGenerateColumns = false;

            dgvTieuChiYeuCau.EnableHeadersVisualStyles = false;
            dgvTieuChiYeuCau.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            TieuChiYeuCauBinding();
            ResetGiaTriTieuChiYeuCau();
        }

        private void dgvYeuCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvYeuCau.CurrentCell == null || dgvYeuCau.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvYeuCau.CurrentRow.Selected = true;
                txtMaYeuCau.Text = dgvYeuCau.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenYeuCau.Text = dgvYeuCau.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtNoiDungYeuCau.Text = dgvYeuCau.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtGhiChuYCau.Text = dgvYeuCau.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            }
        }
    }
}

