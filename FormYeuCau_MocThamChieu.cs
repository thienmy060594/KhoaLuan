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
    public partial class FormYeuCau_MocThamChieu : Form
    {
        BindingSource YeuCau_MocThamChieuList = new BindingSource();
        public FormYeuCau_MocThamChieu()
        {
            InitializeComponent();
            dgvYeuCauMocThamChieu.DataSource = YeuCau_MocThamChieuList;                      
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnTimKiem.Enabled = false;
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

        private void LoadListYeuCau_MocThamChieu()
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

        void YeuCau_MocThamChieuBinding()
        {
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListYeuCau_MocThamChieu();
            FillComBoBox();
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

        private event EventHandler insertYeuCau_MocThamChieu;
        public event EventHandler InsertYeuCau_MocThamChieu
        {
            add { insertYeuCau_MocThamChieu += value; }
            remove { insertYeuCau_MocThamChieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
            int id_yeucau = Int32.Parse(input_1);
            string input_2 = cbxMocThamChieu.GetItemText(cbxMocThamChieu.SelectedValue); ;
            int id_mocthamchieu = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCau_MocThamChieuBUS.Instance.InsertYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertYeuCau_MocThamChieu != null)
                    {
                        insertYeuCau_MocThamChieu(this, new EventArgs());
                    }
                    YeuCau_MocThamChieuBinding();
                    LoadListYeuCau_MocThamChieu();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {            
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private event EventHandler updateYeuCau_MocThamChieu;
        public event EventHandler UpdateYeuCau_MocThamChieu
        {
            add { updateYeuCau_MocThamChieu += value; }
            remove { updateYeuCau_MocThamChieu -= value; }
        }                  
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {                
                string ghichu = txtGhiChu.Text;
                string input_1 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
                int id_yeucau = Int32.Parse(input_1);
                string input_2 = cbxMocThamChieu.GetItemText(cbxMocThamChieu.SelectedValue); ;
                int id_mocthamchieu = Int32.Parse(input_2);

                if (YeuCau_MocThamChieuBUS.Instance.UpdateYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu, ghichu))
                {
                    MessageBox.Show("Sửa yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateYeuCau_MocThamChieu != null)
                    {
                        updateYeuCau_MocThamChieu(this, new EventArgs());
                    }
                    YeuCau_MocThamChieuBinding();
                    LoadListYeuCau_MocThamChieu();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteYeuCau_MocThamChieu;
        public event EventHandler DeleteYeuCau_MocThamChieu
        {
            add { deleteYeuCau_MocThamChieu += value; }
            remove { deleteYeuCau_MocThamChieu -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                    if (deleteYeuCau_MocThamChieu != null)
                    {
                        deleteYeuCau_MocThamChieu(this, new EventArgs());
                    }
                    YeuCau_MocThamChieuBinding();
                    LoadListYeuCau_MocThamChieu();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Xóa yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string timkiem = txtTimKiem.Text;
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTimKiem.Focus();
                return;
            }

            dgvYeuCauMocThamChieu.DataSource = YeuCau_MocThamChieuBUS.Instance.SearchListYeuCau_MocThamChieu(timkiem);
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

            YeuCau_MocThamChieuBinding();
            ResetGiaTri();
        }       
    }
}
