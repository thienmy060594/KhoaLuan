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
    public partial class FormMonTienQuyet : Form
    {
        BindingSource MonTienQuyetList = new BindingSource();
        public FormMonTienQuyet()
        {
            InitializeComponent();
            dgvMonTienQuyet.DataSource = MonTienQuyetList;
            LoadListMonTienQuyet();            
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
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
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
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
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
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
        }       

        void MonTienQuyetBinding()
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
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxMonTienQuyet.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonTienQuyet.ValueMember = "ID_MonHoc";
            cbxMonTienQuyet.DisplayMember = "TenMonHoc";
        }

        private event EventHandler insertMonTienQuyet;
        public event EventHandler InsertMonTienQuyet
        {
            add { insertMonTienQuyet += value; }
            remove { insertMonTienQuyet -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
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
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm môn tiên quyết thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMonTienQuyet;
        public event EventHandler UpdateMonTienQuyet
        {
            add { updateMonTienQuyet += value; }
            remove { updateMonTienQuyet -= value; }
        }    
        
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa môn tiên quyết này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChu.Text;
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
                    ResetGiaTri();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa môn tiên quyết này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
                }
                else
                {
                    MessageBox.Show("Xóa môn tiên quyết thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
