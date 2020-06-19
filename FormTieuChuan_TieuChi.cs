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
    public partial class FormTieuChuan_TieuChi : Form
    {
        BindingSource TieuChuanList = new BindingSource();
        BindingSource TieuChiList = new BindingSource();
        public FormTieuChuan_TieuChi()
        {
            InitializeComponent();
            dgvTieuChuan.DataSource = TieuChuanList;
            LoadListTieuChuan();
            dgvTieuChi.DataSource = TieuChiList;
            LoadListTieuChi();
            FillComBoBox();
        }

        private void LoadListTieuChuan()
        {
            dgvTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            dgvTieuChuan.Columns[0].Visible = false;
            dgvTieuChuan.Columns[1].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChuan.Columns[2].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChuan.Columns[3].HeaderText = "Nội Dung Tiêu Chuẩn";
            dgvTieuChuan.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột                 
            dgvTieuChuan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChuan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvTieuChuan.AutoGenerateColumns = false;

            dgvTieuChuan.EnableHeadersVisualStyles = false;
            dgvTieuChuan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void TieuChuanBinding()
        {
            txtMaTieuChuan.DataBindings.Clear();
            txtTenTieuChuan.DataBindings.Clear();
            txtNoiDungTieuChuan.DataBindings.Clear();
            txtGhiChuTChuan.DataBindings.Clear();
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvTieuChi[column, row];
            DataGridViewCell cell2 = dgvTieuChi[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvTieuChi_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            { return; }
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvTieuChi.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvTieuChi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
            { return; }
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = string.Empty;
                e.FormattingApplied = true;
            }
        }

        private void LoadListTieuChi()
        {
            dgvTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            dgvTieuChi.Columns[0].Visible = false;
            dgvTieuChi.Columns[1].Visible = false;
            dgvTieuChi.Columns[2].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChi.Columns[3].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChi.Columns[4].HeaderText = "Mã Tiêu Chí";
            dgvTieuChi.Columns[5].HeaderText = "Tên Tiêu Chí";
            dgvTieuChi.Columns[6].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChi.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvTieuChi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChi.AllowUserToAddRows = false;
            dgvTieuChi.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvTieuChi.AutoGenerateColumns = false;

            dgvTieuChi.EnableHeadersVisualStyles = false;
            dgvTieuChi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }

        void TieuChiBinding()
        {
            txtMaTieuChi.DataBindings.Clear();
            txtTenTieuChi.DataBindings.Clear();
            txtNoiDungTieuChi.DataBindings.Clear();
            txtGhiChuTChi.DataBindings.Clear();
        }

        private void FillComBoBox()
        {
            cbxTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            cbxTieuChuan.ValueMember = "ID_TieuChuan";
            cbxTieuChuan.DisplayMember = "TenTieuChuan";
        }


        private event EventHandler insertTieuChuan;
        public event EventHandler InsertTieuChuan
        {
            add { insertTieuChuan += value; }
            remove { insertTieuChuan -= value; }
        }

        private void btnThemMoiTChuan_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChuTChuan.Text;

            if (txtMaTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTieuChuan.Focus();
                return;
            }
            else if (txtTenTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChuan.Focus();
                return;
            }
            else if (txtNoiDungTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChuan.Focus();
                return;
            }
            else if (txtMaTieuChuan.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.TieuChuan TChuan WHERE TChuan.MaTieuChuan = N'{0}'", matieuchuan);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã tiêu chuẩn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChuan.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChuanBUS.Instance.InsertTieuChuan(matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }
                    TieuChuanBinding();
                    LoadListTieuChuan();
                    ResetGiaTriTieuChuan();
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriTieuChuan()
        {
            txtMaTieuChuan.Text = "";
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChuTChuan.Text = "";
        }

        private event EventHandler updateTieuChuan;
        public event EventHandler UpdateTieuChuan
        {
            add { updateTieuChuan += value; }
            remove { updateTieuChuan -= value; }
        }

        private void btnSuaTChuan_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChuTChuan.Text;

            if (MessageBox.Show("Bạn có muốn sửa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChuan.Focus();
                    return;
                }
                else if (txtTenTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChuan.Focus();
                    return;
                }
                else if (txtNoiDungTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChuan.Focus();
                    return;
                }
                else
                {
                    string sql = string.Format("SELECT ID_TieuChuan FROM dbo.TieuChuan TChuan WHERE TChuan.MaTieuChuan = N'{0}'", matieuchuan);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tieuchuan = Int32.Parse(input);

                    if (TieuChuanBUS.Instance.UpdateTieuChuan(id_tieuchuan, matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                    {
                        MessageBox.Show("Sửa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateTieuChuan != null)
                        {
                            updateTieuChuan(this, new EventArgs());
                        }
                        TieuChuanBinding();
                        LoadListTieuChuan();
                        ResetGiaTriTieuChuan();
                    }
                    else
                    {
                        MessageBox.Show("Sửa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteTieuChuan;
        public event EventHandler DeleteTieuChuan
        {
            add { deleteTieuChuan += value; }
            remove { deleteTieuChuan -= value; }
        }

        private void btnXoaTChuan_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string sql = string.Format("SELECT ID_TieuChuan FROM dbo.TieuChuan TChuan WHERE TChuan.MaTieuChuan = N'{0}'", matieuchuan);
            string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
            int id_tieuchuan = Int32.Parse(input);

            if (MessageBox.Show("Bạn có muốn xóa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChuan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChuan.Focus();
                    return;
                }

                string sql_1 = string.Format("SELECT * FROM dbo.TieuChi TChi WHERE TChi.ID_TieuChuan = N'{0}'", id_tieuchuan);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql_1))
                {
                    MessageBox.Show("Đang tồn tại Tiêu chí liên kết với Tiêu Chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (TieuChuanBUS.Instance.DeleteTieuChuan(id_tieuchuan))
                    {
                        MessageBox.Show("Xóa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteTieuChuan != null)
                        {
                            deleteTieuChuan(this, new EventArgs());
                        }
                        TieuChuanBinding();
                        LoadListTieuChuan();
                        ResetGiaTriTieuChuan();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriTieuChuan();
            ResetGiaTriTieuChi();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiemTChuan_Click(object sender, EventArgs e)
        {
            string timkiemtieuchuan = txtTenTieuChuan.Text;
            if (txtTenTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChuan.Focus();
                return;
            }

            dgvTieuChuan.DataSource = TieuChuanBUS.Instance.SearchListTieuChuan(timkiemtieuchuan);
            dgvTieuChuan.Columns[0].Visible = false;
            dgvTieuChuan.Columns[1].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChuan.Columns[2].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChuan.Columns[3].HeaderText = "Nội Dung Tiêu Chuẩn";
            dgvTieuChuan.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột                 
            dgvTieuChuan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChuan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvTieuChuan.AutoGenerateColumns = false;

            dgvTieuChuan.EnableHeadersVisualStyles = false;
            dgvTieuChuan.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            TieuChuanBinding();
            ResetGiaTriTieuChuan();
        }

        private event EventHandler insertTieuChi;
        public event EventHandler InsertTieuChi
        {
            add { insertTieuChi += value; }
            remove { insertTieuChi -= value; }
        }

        private void btnThemMoiTChi_Click(object sender, EventArgs e)
        {
            string matieuchi = txtMaTieuChi.Text;
            string tentieuchi = txtTenTieuChi.Text;
            string noidungtieuchi = txtNoiDungTieuChi.Text;
            string ghichu = txtGhiChuTChi.Text;
            string input = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
            int id_tieuchuan = Int32.Parse(input);

            if (txtMaTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTieuChi.Focus();
                return;
            }
            else if (txtTenTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChi.Focus();
                return;
            }
            else if (txtNoiDungTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChi.Focus();
                return;
            }
            else if (txtMaTieuChi.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã tiêu chí đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChiBUS.Instance.InsertTieuChi(id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChi != null)
                    {
                        insertTieuChi(this, new EventArgs());
                    }
                    TieuChiBinding();
                    LoadListTieuChi();
                    ResetGiaTriTieuChi();
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriTieuChi()
        {
            txtMaTieuChi.Text = "";
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChuTChi.Text = "";
        }

        private event EventHandler updateTieuChi;
        public event EventHandler UpdateTieuChi
        {
            add { updateTieuChi += value; }
            remove { updateTieuChi -= value; }
        }

        private void btnSuaTChi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
                else if (txtTenTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChi.Focus();
                    return;
                }
                else if (txtNoiDungTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTieuChi.Focus();
                    return;

                }
                else
                {
                    string matieuchi = txtMaTieuChi.Text;
                    string tentieuchi = txtTenTieuChi.Text;
                    string noidungtieuchi = txtNoiDungTieuChi.Text;
                    string ghichu = txtGhiChuTChi.Text;
                    string input_1 = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
                    int id_tieuchuan = Int32.Parse(input_1);
                    string sql = string.Format("SELECT ID_TieuChi FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tieuchi = Int32.Parse(input);

                    if (TieuChiBUS.Instance.UpdateTieuChi(id_tieuchi, id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu))
                    {
                        MessageBox.Show("Sửa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateTieuChi != null)
                        {
                            updateTieuChi(this, new EventArgs());
                        }
                        TieuChiBinding();
                        LoadListTieuChi();
                        ResetGiaTriTieuChi();
                    }
                    else
                    {
                        MessageBox.Show("Sửa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteTieuChi;
        public event EventHandler DeleteTieuChi
        {
            add { deleteTieuChi += value; }
            remove { deleteTieuChi -= value; }
        }

        private void btnXoaTChi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTieuChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
                else
                {
                    string matieuchi = txtMaTieuChi.Text;
                    string sql = string.Format("SELECT ID_TieuChi FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tieuchi = Int32.Parse(input);

                    if (TieuChiBUS.Instance.DeleteTieuChi(id_tieuchi))
                    {
                        MessageBox.Show("Xóa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteTieuChi != null)
                        {
                            deleteTieuChi(this, new EventArgs());
                        }
                        TieuChiBinding();
                        LoadListTieuChi();
                        ResetGiaTriTieuChi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemTChi_Click(object sender, EventArgs e)
        {
            string timkiemtieuchi = txtTenTieuChi.Text;
            if (txtTenTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chí tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChi.Focus();
                return;
            }

            dgvTieuChi.DataSource = TieuChiBUS.Instance.SearchListTieuChi(timkiemtieuchi);
            dgvTieuChi.Columns[0].Visible = false;
            dgvTieuChi.Columns[1].Visible = false;
            dgvTieuChi.Columns[2].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChi.Columns[3].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChi.Columns[4].HeaderText = "Mã Tiêu Chí";
            dgvTieuChi.Columns[5].HeaderText = "Tên Tiêu Chí";
            dgvTieuChi.Columns[6].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChi.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvTieuChi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChi.AllowUserToAddRows = false;
            dgvTieuChi.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvTieuChi.AutoGenerateColumns = false;

            dgvTieuChi.EnableHeadersVisualStyles = false;
            dgvTieuChi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            TieuChiBinding();
            ResetGiaTriTieuChi();
        }

        private void dgvTieuChuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvTieuChuan.CurrentCell == null || dgvTieuChuan.CurrentCell.Value == null || e.RowIndex == -1)
            {
               MessageBox.Show("Bạn vui lòng chọn vào cột tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }  
            else
            {                
                dgvTieuChuan.CurrentRow.Selected = true;
                txtMaTieuChuan.Text = dgvTieuChuan.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenTieuChuan.Text = dgvTieuChuan.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtNoiDungTieuChuan.Text = dgvTieuChuan.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtGhiChuTChuan.Text = dgvTieuChuan.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
            }    
        }

        private void dgvTieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTieuChi.CurrentCell == null || dgvTieuChi.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvTieuChi.CurrentRow.Selected = true;
                txtMaTieuChi.Text = dgvTieuChi.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtTenTieuChi.Text = dgvTieuChi.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtNoiDungTieuChi.Text = dgvTieuChi.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtGhiChuTChi.Text = dgvTieuChi.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();                
            }
        }
    }
}       
