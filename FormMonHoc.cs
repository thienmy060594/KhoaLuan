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
            txtSoTinChi.Enabled = false;
            txtSoTietLyThuyet.Enabled = false;
            txtSoTietThucHanh.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListMonHoc()
        {
            dgvMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            dgvMonHoc.Columns[0].Visible = false;
            dgvMonHoc.Columns[1].HeaderText = "Mã Môn Học";
            dgvMonHoc.Columns[2].HeaderText = "Tên Môn Học";
            dgvMonHoc.Columns[3].HeaderText = "Số Tín Chỉ";
            dgvMonHoc.Columns[4].HeaderText = "Số Tiết Lý Thuyết";
            dgvMonHoc.Columns[5].HeaderText = "Số Tiết Thực Hành";
            dgvMonHoc.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMonHoc.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
        }
                 
         void MonHocBinding()
        {
            txtMaMonHoc.DataBindings.Clear();
            txtTenMonHoc.DataBindings.Clear();
            txtSoTinChi.DataBindings.Clear();
            txtSoTietLyThuyet.DataBindings.Clear();
            txtSoTietThucHanh.DataBindings.Clear();            
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaMonHoc.Text = "";
            txtTenMonHoc.Text = "";
            txtSoTinChi.Text = "";
            txtSoTietLyThuyet.Text = "";
            txtSoTietThucHanh.Text = "";
            txtGhiChu.Text = "";
            txtMaMonHoc.Enabled = true;
            txtTenMonHoc.Enabled = true;
            txtSoTinChi.Enabled = true;
            txtSoTietLyThuyet.Enabled = true;
            txtSoTietThucHanh.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
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
            else if (MessageBox.Show("Bạn có muốn thêm môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonHocBUS.Instance.InsertMonHoc(mamonhoc, tenmonhoc, sotinchi, sotietlythuyet, sotietthuchanh, ghichu))
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

        private event EventHandler deleteMonHoc;
        public event EventHandler DeleteMonHoc
        {
            add { deleteMonHoc += value; }
            remove { deleteMonHoc -= value; }
        }

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMonHoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvMonHoc.CurrentRow.Selected = true;
                    string input = dgvMonHoc.Rows[e.RowIndex].Cells["ID_MonHoc"].FormattedValue.ToString();
                    int id_monhoc = Int32.Parse(input);
                    if (MessageBox.Show("Bạn có muốn sửa môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string mamonhoc = txtMaMonHoc.Text;
                        string tenmonhoc = txtTenMonHoc.Text;
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
                            if (MonHocBUS.Instance.UpdateMonHoc(id_monhoc, mamonhoc, tenmonhoc, sotinchi, sotietlythuyet, sotietthuchanh, ghichu))
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
                    else if (MessageBox.Show("Bạn có muốn xóa môn học  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MonHocBUS.Instance.DeleteMonHoc(id_monhoc))
                        {
                            MessageBox.Show("Xóa minh môn học công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteMonHoc != null)
                            {
                                deleteMonHoc(this, new EventArgs());
                            }
                            MonHocBinding();
                            LoadListMonHoc();
                        }
                        else
                        {
                            MessageBox.Show("Xóa môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không có dữ liệu để thao tác !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
