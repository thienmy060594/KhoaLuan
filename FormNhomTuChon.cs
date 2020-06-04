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
    public partial class FormNhomTuChon : Form
    {
        BindingSource NhomTuChonList = new BindingSource();
        public FormNhomTuChon()
        {
            InitializeComponent();
            dgvNhomTuChon.DataSource = NhomTuChonList;
            LoadListNhomTuChon();           
            txtMaNhomTuChon.Enabled = false;
            txtTenNhomTuChon.Enabled = false;
            txtSoTinChi.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvNhomTuChon[column, row];
            DataGridViewCell cell2 = dgvNhomTuChon[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvNhomTuChon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
                e.AdvancedBorderStyle.Top = dgvNhomTuChon.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvNhomTuChon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListNhomTuChon()
        {
            dgvNhomTuChon.DataSource = NhomTuChonBUS.Instance.GetListNhomTuChon();
            dgvNhomTuChon.Columns[0].Visible = false;
            dgvNhomTuChon.Columns[1].Visible = false;
            dgvNhomTuChon.Columns[2].HeaderText = "Mã Chương Trình Đào Tạo";            
            dgvNhomTuChon.Columns[3].HeaderText = "Mã Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[4].HeaderText = "Tên Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[5].HeaderText = "Số Tín Chỉ";
            dgvNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
            dgvNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp         
            dgvNhomTuChon.AutoGenerateColumns = false;

            dgvNhomTuChon.EnableHeadersVisualStyles = false;
            dgvNhomTuChon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }        

        void NhomTuChonBinding()
        {
            txtMaNhomTuChon.DataBindings.Clear();
            txtTenNhomTuChon.DataBindings.Clear();
            txtSoTinChi.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaNhomTuChon.Text = "";
            txtTenNhomTuChon.Text = "";
            txtSoTinChi.Text = "";
            txtGhiChu.Text = "";
            txtMaNhomTuChon.Enabled = true;
            txtTenNhomTuChon.Enabled = true;
            txtSoTinChi.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "ID_ChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "TenChuongTrinhDaoTao";
        }

        private event EventHandler insertNhomTuChon;
        public event EventHandler InsertNhomTuChon
        {
            add { insertNhomTuChon += value; }
            remove { insertNhomTuChon -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string manhomtuchon = txtMaNhomTuChon.Text;
            string tennhomtuchon = txtTenNhomTuChon.Text;
            int sotinchi = Int32.Parse(txtSoTinChi.Text);
            string ghichu = txtGhiChu.Text;
            string input = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
            int id_chuongtrinhdaotao = Int32.Parse(input);

            if (txtMaNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhomTuChon.Focus();
                return;
            }
            else if (txtTenNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhomTuChon.Focus();
                return;
            }
            else if (txtMaNhomTuChon.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã nhóm tự chọn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NhomTuChonBUS.Instance.InsertNhomTuChon(id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu))
                {
                    MessageBox.Show("Thêm nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNhomTuChon != null)
                    {
                        insertNhomTuChon(this, new EventArgs());
                    }
                    NhomTuChonBinding();
                    LoadListNhomTuChon();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaNhomTuChon.Text = "";
            txtTenNhomTuChon.Text = "";
            txtSoTinChi.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNhomTuChon;
        public event EventHandler UpdateNhomTuChon
        {
            add { updateNhomTuChon += value; }
            remove { updateNhomTuChon -= value; }
        }     

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {               
                if (txtMaNhomTuChon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
                else if (txtTenNhomTuChon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenNhomTuChon.Focus();
                    return;
                }
                else if (txtSoTinChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTinChi.Focus();
                    return;
                }
                else
                {
                    string manhomtuchon = txtMaNhomTuChon.Text;
                    string tennhomtuchon = txtTenNhomTuChon.Text;
                    int sotinchi = Int32.Parse(txtSoTinChi.Text);
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_NhomTuChon FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nhomtuchon = Int32.Parse(input);
                    string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
                    int id_chuongtrinhdaotao = Int32.Parse(input_1);

                    if (NhomTuChonBUS.Instance.UpdateNhomTuChon(id_nhomtuchon, id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu))
                    {
                        MessageBox.Show("Sửa nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateNhomTuChon != null)
                        {
                            updateNhomTuChon(this, new EventArgs());
                        }
                        NhomTuChonBinding();
                        LoadListNhomTuChon();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteNhomTuChon;
        public event EventHandler DeleteNhomTuChon
        {
            add { deleteNhomTuChon += value; }
            remove { deleteNhomTuChon -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaNhomTuChon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
                else
                {
                    string manhomtuchon = txtMaNhomTuChon.Text;
                    string sql = string.Format("SELECT ID_NhomTuChon FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_nhomtuchon = Int32.Parse(input);

                    if (NhomTuChonBUS.Instance.DeleteNhomTuChon(id_nhomtuchon))
                    {
                        MessageBox.Show("Xóa nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteNhomTuChon != null)
                        {
                            deleteNhomTuChon(this, new EventArgs());
                        }
                        NhomTuChonBinding();
                        LoadListNhomTuChon();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
