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
    public partial class FormMonHoc_NhomTuChon : Form
    {
        BindingSource MonHoc_NhomTuChonList = new BindingSource();
        public FormMonHoc_NhomTuChon()
        {
            InitializeComponent();
            dgvMonHocNhomTuChon.DataSource = MonHoc_NhomTuChonList;                     
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
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
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
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListMonHoc_NhomTuChon()
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
        
        void MonHoc_NhomTuChonBinding()
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
            LoadListMonHoc_NhomTuChon();
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxNhomTuChon.DataSource = NhomTuChonBUS.Instance.GetListNhomTuChon();
            cbxNhomTuChon.ValueMember = "ID_NhomTuChon";
            cbxNhomTuChon.DisplayMember = "TenNhomTuChon";
        }

        private event EventHandler insertMonHoc_NhomTuChon;
        public event EventHandler InsertMonHoc_NhomTuChon
        {
            add { insertMonHoc_NhomTuChon += value; }
            remove { insertMonHoc_NhomTuChon -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
            int id_monhoc = Int32.Parse(input_1);
            string input_2 = cbxNhomTuChon.GetItemText(cbxNhomTuChon.SelectedValue);
            int id_nhomtuchon = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonHoc_NhomTuChonBUS.Instance.InsertMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon, ghichu))
                {
                    MessageBox.Show("Thêm môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMonHoc_NhomTuChon != null)
                    {
                        insertMonHoc_NhomTuChon(this, new EventArgs());
                    }
                    MonHoc_NhomTuChonBinding();
                    LoadListMonHoc_NhomTuChon();
                    ResetGiaTri();                    
                }
                else
                {
                    MessageBox.Show("Thêm môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
        }

        private event EventHandler updateMonHoc_NhomTuChon;
        public event EventHandler UpdateMonHoc_NhomTuChon
        {
            add { updateMonHoc_NhomTuChon += value; }
            remove { updateMonHoc_NhomTuChon -= value; }
        }
 
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChu.Text;
                string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
                int id_monhoc = Int32.Parse(input_1);
                string input_2 = cbxNhomTuChon.GetItemText(cbxNhomTuChon.SelectedValue);
                int id_nhomtuchon = Int32.Parse(input_2);

                if (MonHoc_NhomTuChonBUS.Instance.UpdateMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon, ghichu))
                {
                    MessageBox.Show("Sửa môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateMonHoc_NhomTuChon != null)
                    {
                        updateMonHoc_NhomTuChon(this, new EventArgs());
                    }
                    MonHoc_NhomTuChonBinding();
                    LoadListMonHoc_NhomTuChon();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteMonHoc_NhomTuChon;
        public event EventHandler DeleteMonHoc_NhomTuChon
        {
            add { deleteMonHoc_NhomTuChon += value; }
            remove { deleteMonHoc_NhomTuChon -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
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
                    if (deleteMonHoc_NhomTuChon != null)
                    {
                        deleteMonHoc_NhomTuChon(this, new EventArgs());
                    }
                    MonHoc_NhomTuChonBinding();
                    LoadListMonHoc_NhomTuChon();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Xóa môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvMonHocNhomTuChon.DataSource = MonHoc_NhomTuChonBUS.Instance.SearchListMonHoc_NhomTuChon(timkiem);
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

            MonHoc_NhomTuChonBinding();
            ResetGiaTri();
        }
    }
}
