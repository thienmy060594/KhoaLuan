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
    public partial class FormDeCuongMonHoc : Form
    {
        BindingSource DeCuongMonHocList = new BindingSource();
        public FormDeCuongMonHoc()
        {
            InitializeComponent();
            dgvDeCuongMonHoc.DataSource = DeCuongMonHocList;
            LoadListDeCuongMonHoc();            
            txtMaDeCuongMonHoc.Enabled = false;
            txtTenDeCuongMonHoc.Enabled = false;
            txtNoiDung.Enabled = false;
            txtGhiChu.Enabled = false;            
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvDeCuongMonHoc[column, row];
            DataGridViewCell cell2 = dgvDeCuongMonHoc[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }       

        private void dgvDeCuongMonHoc_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvDeCuongMonHoc.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvDeCuongMonHoc_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListDeCuongMonHoc()
        {
            dgvDeCuongMonHoc.DataSource = DeCuongMonHocBUS.Instance.GetListDeCuongMonHoc();
            dgvDeCuongMonHoc.Columns[0].Visible = false;
            dgvDeCuongMonHoc.Columns[1].Visible = false;
            dgvDeCuongMonHoc.Columns[2].Visible = false;
            dgvDeCuongMonHoc.Columns[3].HeaderText = "Mã Môn Học";
            dgvDeCuongMonHoc.Columns[4].HeaderText = "Tên Môn Học";
            dgvDeCuongMonHoc.Columns[5].HeaderText = "Mã Tài Liệu";
            dgvDeCuongMonHoc.Columns[6].HeaderText = "Tên Tài Liệu";
            dgvDeCuongMonHoc.Columns[7].HeaderText = "Mã Đề Cương Môn Học";
            dgvDeCuongMonHoc.Columns[8].HeaderText = "Tên Đề Cương Môn Học";
            dgvDeCuongMonHoc.Columns[9].HeaderText = "Nội Dung";
            dgvDeCuongMonHoc.Columns[10].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột          
            dgvDeCuongMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvDeCuongMonHoc.AllowUserToAddRows = false;
            dgvDeCuongMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp       
            dgvDeCuongMonHoc.AutoGenerateColumns = false;
        }        

        void DeCuongMonHocBinding()
        {
            txtMaDeCuongMonHoc.DataBindings.Clear();
            txtTenDeCuongMonHoc.DataBindings.Clear();            
            txtNoiDung.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaDeCuongMonHoc.Text = "";
            txtTenDeCuongMonHoc.Text = "";            
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
            txtMaDeCuongMonHoc.Enabled = true;
            txtTenDeCuongMonHoc.Enabled = true;            
            txtNoiDung.Enabled = true;
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
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
        }

        private event EventHandler insertDeCuongMonHoc;
        public event EventHandler InsertDeCuongMonHoc
        {
            add { insertDeCuongMonHoc += value; }
            remove { insertDeCuongMonHoc -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string madecuongmonhoc = txtMaDeCuongMonHoc.Text;
            string tendecuongmonhoc = txtTenDeCuongMonHoc.Text;            
            string noidung = txtNoiDung.Text;
            string ghichu = txtGhiChu.Text;
            string input = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
            int id_monhoc = Int32.Parse(input);
            string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
            int id_tailieu = Int32.Parse(input_1);

            if (txtMaDeCuongMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDeCuongMonHoc.Focus();
                return;
            }
            else if (txtTenDeCuongMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDeCuongMonHoc.Focus();
                return;
            }
            else if (txtNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return;
            }           
            else if (txtMaDeCuongMonHoc.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.DeCuongMonHoc DCuongMHoc WHERE DCuongMHoc.MaDeCuongMonHoc = N'{0}'", madecuongmonhoc);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã đề cương môn học đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDeCuongMonHoc.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm đề cương môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DeCuongMonHocBUS.Instance.InsertDeCuongMonHoc(id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, noidung, ghichu))
                {
                    MessageBox.Show("Thêm đề cương môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertDeCuongMonHoc != null)
                    {
                        insertDeCuongMonHoc(this, new EventArgs());
                    }
                    DeCuongMonHocBinding();
                    LoadListDeCuongMonHoc();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm đề cương môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaDeCuongMonHoc.Text = "";
            txtTenDeCuongMonHoc.Text = "";            
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateDeCuongMonHoc;
        public event EventHandler UpdateDeCuongMonHoc
        {
            add { updateDeCuongMonHoc += value; }
            remove { updateDeCuongMonHoc -= value; }
        }            
            
        private void btnSua_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Bạn có muốn sửa đề cương môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {              
                if (txtMaDeCuongMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDeCuongMonHoc.Focus();
                    return;
                }
                else if (txtTenDeCuongMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenDeCuongMonHoc.Focus();
                    return;
                }
                else if (txtNoiDung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoiDung.Focus();
                    return;
                }
                else
                {
                    string madecuongmonhoc = txtMaDeCuongMonHoc.Text;
                    string tendecuongmonhoc = txtTenDeCuongMonHoc.Text;
                    string noidung = txtNoiDung.Text;
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_DeCuongMonHoc FROM dbo.DeCuongMonHoc DCuongMHoc WHERE DCuongMHoc.MaDeCuongMonHoc = N'{0}'", madecuongmonhoc);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_decuongmonhoc = Int32.Parse(input);
                    string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
                    int id_monhoc = Int32.Parse(input_1);
                    string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
                    int id_tailieu = Int32.Parse(input_2);

                    if (DeCuongMonHocBUS.Instance.UpdateDeCuongMonHoc(id_decuongmonhoc, id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, noidung, ghichu))
                    {
                        MessageBox.Show("Sửa đề cương môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateDeCuongMonHoc != null)
                        {
                            updateDeCuongMonHoc(this, new EventArgs());
                        }
                        DeCuongMonHocBinding();
                        LoadListDeCuongMonHoc();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa đề cương môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteDeCuongMonHoc;
        public event EventHandler DeleteDeCuongMonHoc
        {
            add { deleteDeCuongMonHoc += value; }
            remove { deleteDeCuongMonHoc -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa đề cương môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaDeCuongMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDeCuongMonHoc.Focus();
                    return;
                }
                else
                {
                    string madecuongmonhoc = txtMaDeCuongMonHoc.Text;
                    string sql = string.Format("SELECT ID_DeCuongMonHoc FROM dbo.DeCuongMonHoc DCuongMHoc WHERE DCuongMHoc.MaDeCuongMonHoc = N'{0}'", madecuongmonhoc);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_decuongmonhoc = Int32.Parse(input);

                    if (DeCuongMonHocBUS.Instance.DeleteDeCuongMonHoc(id_decuongmonhoc))
                    {
                        MessageBox.Show("Xóa đề cương môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteDeCuongMonHoc != null)
                        {
                            deleteDeCuongMonHoc(this, new EventArgs());
                        }
                        DeCuongMonHocBinding();
                        LoadListDeCuongMonHoc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa đề cương môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
