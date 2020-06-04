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
    public partial class FormNguonMinhChung_MinhChung : Form
    {
        BindingSource NguonMinhChung_MinhChungList = new BindingSource();
        public FormNguonMinhChung_MinhChung()
        {
            InitializeComponent();
            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChung_MinhChungList;
            LoadListNguonMinhChung_MinhChung();            
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvNguonMinhChungMinhChung[column, row];
            DataGridViewCell cell2 = dgvNguonMinhChungMinhChung[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvNguonMinhChungMinhChung_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvNguonMinhChungMinhChung.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvNguonMinhChungMinhChung_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListNguonMinhChung_MinhChung()
        {
            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChung_MinhChungBUS.Instance.GetListNguonMinhChung_MinhChung();
            dgvNguonMinhChungMinhChung.Columns[0].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[1].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[2].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[3].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[4].HeaderText = "Mã Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[5].HeaderText = "Tên Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNguonMinhChungMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChungMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNguonMinhChungMinhChung.AutoGenerateColumns = false;

            dgvNguonMinhChungMinhChung.EnableHeadersVisualStyles = false;
            dgvNguonMinhChungMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }
        
        void NguonMinhChung_MinhChungBinding()
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
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_Tailieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
        }

        private event EventHandler insertNguonMinhChung_MinhChung;
        public event EventHandler InsertNguonMinhChung_MinhChung
        {
            add { insertNguonMinhChung_MinhChung += value; }
            remove { insertNguonMinhChung_MinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;            
            string input_1 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_1);
            string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
            int id_tailieu = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChung_MinhChungBUS.Instance.InsertNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu, ghichu))
                {
                    MessageBox.Show("Thêm nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNguonMinhChung_MinhChung != null)
                    {
                        insertNguonMinhChung_MinhChung(this, new EventArgs());
                    }
                    NguonMinhChung_MinhChungBinding();
                    LoadListNguonMinhChung_MinhChung();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNguonMinhChung_MinhChung;
        public event EventHandler UpdateNguonMinhChung_MinhChung
        {
            add { updateNguonMinhChung_MinhChung += value; }
            remove { updateNguonMinhChung_MinhChung -= value; }
        }       

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                string ghichu = txtGhiChu.Text;
                string input_1 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
                int id_nguonminhchung = Int32.Parse(input_1);
                string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
                int id_tailieu = Int32.Parse(input_2);

                if (NguonMinhChung_MinhChungBUS.Instance.UpdateNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu, ghichu))
                {
                    MessageBox.Show("Sửa nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateNguonMinhChung_MinhChung != null)
                    {
                        updateNguonMinhChung_MinhChung(this, new EventArgs());
                    }
                    NguonMinhChung_MinhChungBinding();
                    LoadListNguonMinhChung_MinhChung();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Sửa nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private event EventHandler deleteNguonMinhChung_MinhChung;
        public event EventHandler DeleteNguonMinhChung_MinhChung
        {
            add { deleteNguonMinhChung_MinhChung += value; }
            remove { deleteNguonMinhChung_MinhChung -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {                
                string input_1 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
                int id_nguonminhchung = Int32.Parse(input_1);
                string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
                int id_tailieu = Int32.Parse(input_2);

                if (NguonMinhChung_MinhChungBUS.Instance.DeleteNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu))
                {
                    MessageBox.Show("Xóa nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (deleteNguonMinhChung_MinhChung != null)
                    {
                        deleteNguonMinhChung_MinhChung(this, new EventArgs());
                    }
                    NguonMinhChung_MinhChungBinding();
                    LoadListNguonMinhChung_MinhChung();
                    ResetGiaTri();
                }
                else
                {
                    MessageBox.Show("Xóa nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
