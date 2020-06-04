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
    public partial class FormNganh : Form
    {
        BindingSource NganhList = new BindingSource();
        public FormNganh()
        {
            InitializeComponent();
            dgvNganh.DataSource = NganhList;
            LoadListNganh();            
            txtMaNganh.Enabled = false;
            txtTenNganh.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvNganh[column, row];
            DataGridViewCell cell2 = dgvNganh[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvNganh_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvNganh.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvNganh_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListNganh()
        {
            dgvNganh.DataSource = NganhBUS.Instance.GetListNganh();
            dgvNganh.Columns[0].Visible = false;
            dgvNganh.Columns[1].Visible = false;
            dgvNganh.Columns[2].HeaderText = "Mã Khoa";
            dgvNganh.Columns[3].HeaderText = "Tên Khoa";
            dgvNganh.Columns[4].HeaderText = "Mã Ngành";
            dgvNganh.Columns[5].HeaderText = "Tên Ngành";
            dgvNganh.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNganh.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNganh.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNganh.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNganh.AutoGenerateColumns = false;

            dgvNganh.EnableHeadersVisualStyles = false;
            dgvNganh.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }
      
        void NganhBinding()
        {
            txtMaNganh.DataBindings.Clear();
            txtTenNganh.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";            
            txtGhiChu.Text = "";
            txtMaNganh.Enabled = true;
            txtTenNganh.Enabled = true;            
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxKhoa.DataSource = KhoaBUS.Instance.GetListKhoa();
            cbxKhoa.ValueMember = "ID_Khoa";
            cbxKhoa.DisplayMember = "TenKhoa";
        }

        private event EventHandler insertNganh;
        public event EventHandler InsertNganh
        {
            add { insertNganh += value; }
            remove { insertNganh -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string manganh = txtMaNganh.Text;
            string tennganh = txtTenNganh.Text;            
            string ghichu = txtGhiChu.Text;
            string input = cbxKhoa.GetItemText(cbxKhoa.SelectedValue);
            int id_khoa = Int32.Parse(input);

            if (txtMaNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNganh.Focus();
                return;
            }
            else if (txtTenNganh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNganh.Focus();
                return;
            }            
            else if (txtMaNganh.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.Nganh N WHERE N.MaNganh = N'{0}'", manganh);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã ngành đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNganh.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm ngành này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NganhBUS.Instance.InsertNganh(id_khoa, manganh, tennganh, ghichu))
                {
                    MessageBox.Show("Thêm ngành thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNganh != null)
                    {
                        insertNganh(this, new EventArgs());
                    }
                    NganhBinding();
                    LoadListNganh();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm ngành thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaNganh.Text = "";
            txtTenNganh.Text = "";            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNganh;
        public event EventHandler UpdateNganh
        {
            add { updateNganh += value; }
            remove { updateNganh -= value; }
        }        

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa ngành này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {             
                if (txtMaNganh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNganh.Focus();
                    return;
                }
                else if (txtTenNganh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNganh.Focus();
                    return;
                }
                else
                {
                    string manganh = txtMaNganh.Text;
                    string tennganh = txtTenNganh.Text;
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_Nganh FROM dbo.Nganh N WHERE N.MaNganh = N'{0}'", manganh);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nganh = Int32.Parse(input);
                    string input_1 = cbxKhoa.GetItemText(cbxKhoa.SelectedValue);
                    int id_khoa = Int32.Parse(input_1);

                    if (NganhBUS.Instance.UpdateNganh(id_nganh, id_khoa, manganh, tennganh, ghichu))
                    {
                        MessageBox.Show("Sửa ngành thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateNganh != null)
                        {
                            updateNganh(this, new EventArgs());
                        }
                        NganhBinding();
                        LoadListNganh();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa ngành thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteNganh;
        public event EventHandler DeleteNganh
        {
            add { deleteNganh += value; }
            remove { deleteNganh -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa ngành này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNganh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã ngành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNganh.Focus();
                    return;
                }
                else
                {
                    string manganh = txtMaNganh.Text;
                    string sql = string.Format("SELECT ID_Nganh FROM dbo.Nganh N WHERE N.MaNganh = N'{0}'", manganh);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nganh = Int32.Parse(input);

                    if (NganhBUS.Instance.DeleteNganh(id_nganh))
                    {
                        MessageBox.Show("Xóa ngành thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteNganh != null)
                        {
                            deleteNganh(this, new EventArgs());
                        }
                        NganhBinding();
                        LoadListNganh();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa ngành thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
