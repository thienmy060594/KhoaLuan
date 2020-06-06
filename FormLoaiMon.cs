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
    public partial class FormLoaiMon : Form
    {
        BindingSource LoaiMonList = new BindingSource();
        public FormLoaiMon()
        {
            InitializeComponent();
            dgvLoaiMon.DataSource = LoaiMonList;                    
            txtMaLoaiMon.Enabled = false;
            txtTenLoaiMon.Enabled = false;
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void LoadListLoaiMon()
        {
            dgvLoaiMon.DataSource = LoaiMonBUS.Instance.GetListLoaiMon();
            dgvLoaiMon.Columns[0].Visible = false;
            dgvLoaiMon.Columns[1].HeaderText = "Mã Loại Môn";
            dgvLoaiMon.Columns[2].HeaderText = "Tên Loại Môn";
            dgvLoaiMon.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvLoaiMon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiMon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvLoaiMon.AutoGenerateColumns = false;

            dgvLoaiMon.EnableHeadersVisualStyles = false;
            dgvLoaiMon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }       

        void LoaiMonBinding()
        {
            txtMaLoaiMon.DataBindings.Clear();
            txtTenLoaiMon.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaLoaiMon.Text = "";
            txtTenLoaiMon.Text = "";
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtMaLoaiMon.Enabled = true;
            txtTenLoaiMon.Enabled = true;
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
            btnTimKiem.Enabled = true;
            LoadListLoaiMon();
        }

        private event EventHandler insertLoaiMon;
        public event EventHandler InsertLoaiMon
        {
            add { insertLoaiMon += value; }
            remove { insertLoaiMon -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string maloaimon = txtMaLoaiMon.Text;
            string tenloaimon = txtTenLoaiMon.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaLoaiMon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLoaiMon.Focus();
                return;
            }
            else if (txtTenLoaiMon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiMon.Focus();
                return;
            }
            else if (txtMaLoaiMon.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.LoaiMon LMon WHERE LMon.MaLoaiMon = N'{0}'", maloaimon);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã loại môn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiMon.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm loại môn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiMonBUS.Instance.InsertLoaiMon(maloaimon, tenloaimon, ghichu))
                {
                    MessageBox.Show("Thêm loại môn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertLoaiMon != null)
                    {
                        insertLoaiMon(this, new EventArgs());
                    }
                    LoaiMonBinding();
                    LoadListLoaiMon();
                    ResetGiaTri();                    
                }
                else
                {
                    MessageBox.Show("Thêm loại môn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaLoaiMon.Text = "";
            txtTenLoaiMon.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler deleteLoaiMon;
        public event EventHandler DeleteLoaiMon
        {
            add { deleteLoaiMon += value; }
            remove { deleteLoaiMon -= value; }
        }                

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa loại môn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaLoaiMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiMon.Focus();
                    return;
                }
                else if (txtTenLoaiMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenLoaiMon.Focus();
                    return;
                }
                else
                {
                    string maloaimon = txtMaLoaiMon.Text;
                    string tenloaimon = txtTenLoaiMon.Text;
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_LoaiMon FROM dbo.LoaiMon LMon WHERE LMon.MaLoaiMon  = N'{0}'", maloaimon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_loaimon = Int32.Parse(input);

                    if (LoaiMonBUS.Instance.UpdateLoaiMon(id_loaimon, maloaimon, tenloaimon, ghichu))
                    {
                        MessageBox.Show("Sửa loại môn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateLoaiMon != null)
                        {
                            updateLoaiMon(this, new EventArgs());
                        }
                        LoaiMonBinding();
                        LoadListLoaiMon();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa loại môn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler updateLoaiMon;
        public event EventHandler UpdateLoaiMon
        {
            add { updateLoaiMon += value; }
            remove { updateLoaiMon -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn xóa loại môn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaLoaiMon.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã loại môn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLoaiMon.Focus();
                    return;
                }
                else
                {
                    string maloaimon = txtMaLoaiMon.Text;
                    string sql = string.Format("SELECT ID_LoaiMon FROM dbo.LoaiMon LMon WHERE LMon.MaLoaiMon  = N'{0}'", maloaimon);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_loaimon = Int32.Parse(input);

                    if (LoaiMonBUS.Instance.DeleteLoaiMon(id_loaimon))
                    {
                        MessageBox.Show("Xóa loại môn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteLoaiMon != null)
                        {
                            deleteLoaiMon(this, new EventArgs());
                        }
                        LoaiMonBinding();
                        LoadListLoaiMon();
                        ResetGiaTri();
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

            dgvLoaiMon.DataSource = LoaiMonBUS.Instance.SearchListLoaiMon(timkiem);
            dgvLoaiMon.Columns[0].Visible = false;
            dgvLoaiMon.Columns[1].HeaderText = "Mã Loại Môn";
            dgvLoaiMon.Columns[2].HeaderText = "Tên Loại Môn";
            dgvLoaiMon.Columns[3].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvLoaiMon.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiMon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiMon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvLoaiMon.AutoGenerateColumns = false;

            dgvLoaiMon.EnableHeadersVisualStyles = false;
            dgvLoaiMon.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            LoaiMonBinding();
            ResetGiaTri();
        }
    }
}
