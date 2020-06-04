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
    public partial class FormMonHoc : Form
    {
        BindingSource MonHocList = new BindingSource();
        public FormMonHoc()
        {
            InitializeComponent();
            dgvMonHoc.DataSource = MonHocList;
            LoadListMonHoc();            
            txtMaMonHoc.Enabled = false;
            txtTenMonHoc.Enabled = false;
            txtTenTiengAnh.Enabled = false;
            txtSoTinChi.Enabled = false;
            txtSoTietLyThuyet.Enabled = false;
            txtSoTietThucHanh.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void LoadListMonHoc()
        {
            dgvMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            dgvMonHoc.Columns[0].Visible = false;
            dgvMonHoc.Columns[1].HeaderText = "Mã Môn Học";
            dgvMonHoc.Columns[2].HeaderText = "Tên Môn Học";
            dgvMonHoc.Columns[3].HeaderText = "Tên Tiếng Anh";
            dgvMonHoc.Columns[4].HeaderText = "Số Tín Chỉ";
            dgvMonHoc.Columns[5].HeaderText = "Số Tiết Lý Thuyết";
            dgvMonHoc.Columns[6].HeaderText = "Số Tiết Thực Hành";
            dgvMonHoc.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMonHoc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMonHoc.AutoGenerateColumns = false;

            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }                

        void MonHocBinding()
        {
            txtMaMonHoc.DataBindings.Clear();
            txtTenMonHoc.DataBindings.Clear();
            txtTenTiengAnh.DataBindings.Clear();
            txtSoTinChi.DataBindings.Clear();
            txtSoTietLyThuyet.DataBindings.Clear();
            txtSoTietThucHanh.DataBindings.Clear();            
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Text = "";
            txtTenMonHoc.Text = "";
            txtTenTiengAnh.Text = "";
            txtSoTinChi.Text = "";
            txtSoTietLyThuyet.Text = "";
            txtSoTietThucHanh.Text = "";
            txtGhiChu.Text = "";
            txtMaMonHoc.Enabled = true;
            txtTenMonHoc.Enabled = true;
            txtTenTiengAnh.Enabled = true;
            txtSoTinChi.Enabled = true;
            txtSoTietLyThuyet.Enabled = true;
            txtSoTietThucHanh.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private event EventHandler insertMonHoc;
        public event EventHandler InserMonHoc
        {
            add { insertMonHoc += value; }
            remove { insertMonHoc -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string mamonhoc = txtMaMonHoc.Text;
            string tenmonhoc = txtTenMonHoc.Text;
            string tentienganh = txtTenTiengAnh.Text;
            int sotinchi = Int32.Parse(txtSoTinChi.Text);
            int sotietlythuyet = Int32.Parse(txtSoTietLyThuyet.Text);
            int sotietthuchanh = Int32.Parse(txtSoTietThucHanh.Text);
            string ghichu = txtGhiChu.Text;

            if (txtMaMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMonHoc.Focus();
                return;
            }
            else if (txtTenMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMonHoc.Focus();
                return;
            }
            else if (txtTenTiengAnh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiếng anh !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTiengAnh.Focus();
                return;
            }
            else if (txtSoTinChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTinChi.Focus();
                return;
            }
            else if (txtSoTietLyThuyet.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiết lý thuyết !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTietLyThuyet.Focus();
                return;
            }
            else if (txtSoTietThucHanh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số tiết thực hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoTietThucHanh.Focus();
                return;
            }           
            else if (txtMaMonHoc.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.MonHoc MHoc WHERE MHoc.MaMonHoc = N'{0}'", mamonhoc);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã môn học này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMonHoc.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonHocBUS.Instance.InsertMonHoc(mamonhoc, tenmonhoc, tentienganh, sotinchi, sotietlythuyet, sotietthuchanh, ghichu))
                {
                    MessageBox.Show("Thêm môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMonHoc != null)
                    {
                        insertMonHoc(this, new EventArgs());
                    }
                    MonHocBinding();
                    LoadListMonHoc();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaMonHoc.Text = "";
            txtTenMonHoc.Text = "";
            txtTenTiengAnh.Text = "";
            txtSoTinChi.Text = "";
            txtSoTietLyThuyet.Text = "";
            txtSoTietThucHanh.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMonHoc;
        public event EventHandler UpdateMonHoc
        {
            add { updateMonHoc += value; }
            remove { updateMonHoc -= value; }
        }
     
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {               
                if (txtMaMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMonHoc.Focus();
                    return;
                }
                else if (txtTenMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenMonHoc.Focus();
                    return;
                }
                else if (txtTenTiengAnh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tiếng anh !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTiengAnh.Focus();
                    return;
                }
                else if (txtSoTinChi.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTinChi.Focus();
                    return;
                }
                else if (txtSoTietLyThuyet.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tiết lý thuyết !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTietLyThuyet.Focus();
                    return;
                }
                else if (txtSoTietThucHanh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số tiết thực hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoTietThucHanh.Focus();
                    return;
                }
                else
                {
                    string mamonhoc = txtMaMonHoc.Text;
                    string tenmonhoc = txtTenMonHoc.Text;
                    string tentienganh = txtTenTiengAnh.Text;
                    int sotinchi = Int32.Parse(txtSoTinChi.Text);
                    int sotietlythuyet = Int32.Parse(txtSoTietLyThuyet.Text);
                    int sotietthuchanh = Int32.Parse(txtSoTietThucHanh.Text);
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_MonHoc FROM dbo.MonHoc MHoc WHERE MHoc.MaMonHoc = N'{0}'", mamonhoc);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_monhoc = Int32.Parse(input);

                    if (MonHocBUS.Instance.UpdateMonHoc(id_monhoc, mamonhoc, tenmonhoc, tentienganh, sotinchi, sotietlythuyet, sotietthuchanh, ghichu))
                    {
                        MessageBox.Show("Sửa minh chứng  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateMonHoc != null)
                        {
                            updateMonHoc(this, new EventArgs());
                        }
                        MonHocBinding();
                        LoadListMonHoc();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteMonHoc;
        public event EventHandler DeleteMonHoc
        {
            add { deleteMonHoc += value; }
            remove { deleteMonHoc -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa môn học  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaMonHoc.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaMonHoc.Focus();
                    return;
                }
                else
                {
                    string mamonhoc = txtMaMonHoc.Text;
                    string sql = string.Format("SELECT ID_MonHoc FROM dbo.MonHoc MHoc WHERE MHoc.MaMonHoc = N'{0}'", mamonhoc);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_monhoc = Int32.Parse(input);

                    if (MonHocBUS.Instance.DeleteMonHoc(id_monhoc))
                    {
                        MessageBox.Show("Xóa minh môn học công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteMonHoc != null)
                        {
                            deleteMonHoc(this, new EventArgs());
                        }
                        MonHocBinding();
                        LoadListMonHoc();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
