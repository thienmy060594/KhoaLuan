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
    public partial class FormTieuChi_YeuCau : Form
    {
        BindingSource TieuChi_YeuCauList = new BindingSource();
        public FormTieuChi_YeuCau()
        {
            InitializeComponent();
            dgvTieuChiYeuCau.DataSource = TieuChi_YeuCauList;
            LoadListTieuChi_YeuCau();           
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
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

        private void LoadListTieuChi_YeuCau()
        {
            dgvTieuChiYeuCau.DataSource = TieuChi_YeuCauBUS.Instance.GetListTieuChi_YeuCau();
            dgvTieuChiYeuCau.Columns[0].Visible = false;
            dgvTieuChiYeuCau.Columns[1].Visible = false;           
            dgvTieuChiYeuCau.Columns[2].HeaderText = "Mã Tiêu Chí";
            dgvTieuChiYeuCau.Columns[3].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiYeuCau.Columns[4].HeaderText = "Mã Yêu Cầu";
            dgvTieuChiYeuCau.Columns[5].HeaderText = "Tên Yêu Cầu";
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

        void TieuChi_YeuCauBinding()
        {            
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtGhiChu.Text = "";           
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            FillComBoBox();
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

        private event EventHandler insertTieuChi_YeuCau;
        public event EventHandler InsertTieuChi_YeuCau
        {
            add { insertTieuChi_YeuCau += value; }
            remove { insertTieuChi_YeuCau -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
            int id_tieuchi = Int32.Parse(input_1);
            string input_2 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
            int id_yeucau = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_YeuCauBUS.Instance.InsertTieuChi_YeuCau( id_tieuchi, id_yeucau,ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChi_YeuCau != null)
                    {
                        insertTieuChi_YeuCau(this, new EventArgs());
                    }
                    TieuChi_YeuCauBinding();
                    LoadListTieuChi_YeuCau();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        void ResetGiaTri()
        {            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateTieuChi_YeuCau;
        public event EventHandler UpdateTieuChi_YeuCau
        {
            add { updateTieuChi_YeuCau += value; }
            remove { updateTieuChi_YeuCau -= value; }
        }   

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChu.Text;
                string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
                int id_tieuchi = Int32.Parse(input_1);
                string input_2 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
                int id_yeucau = Int32.Parse(input_2);

                if (TieuChi_YeuCauBUS.Instance.UpdateTieuChi_YeuCau(id_tieuchi, id_yeucau, ghichu))
                {
                    MessageBox.Show("Sửa tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateTieuChi_YeuCau != null)
                    {
                        updateTieuChi_YeuCau(this, new EventArgs());
                    }
                    TieuChi_YeuCauBinding();
                    LoadListTieuChi_YeuCau();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteTieuChi_YeuCau;
        public event EventHandler DeleteTieuChi_YeuCau
        {
            add { deleteTieuChi_YeuCau += value; }
            remove { deleteTieuChi_YeuCau -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                    if (deleteTieuChi_YeuCau != null)
                    {
                        deleteTieuChi_YeuCau(this, new EventArgs());
                    }
                    TieuChi_YeuCauBinding();
                    LoadListTieuChi_YeuCau();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Xóa tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
