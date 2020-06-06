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
    public partial class FormMinhChung : Form
    {
        BindingSource MinhChungList = new BindingSource();
        public FormMinhChung()
        {
            InitializeComponent();
            dgvMinhChung.DataSource = MinhChungList;                    
            txtMaTaiLieu.Enabled = false;
            txtTenTaiLieu.Enabled = false;
            txtNgayKy.Enabled = false;
            txtNguoiKy.Enabled = false;
            txtSoBanHanh.Enabled = false;
            txtTomTatNoiDung.Enabled = false;           
            txtGhiChu.Enabled = false;
            txtTimKiem.Enabled = false;
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;           
            btnLuuTaiLieu.Enabled = false;
            btnTimKiem.Enabled = false;            
        }
        private void LoadListMinhChung()
        {
            dgvMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            dgvMinhChung.Columns[0].Visible = false;
            dgvMinhChung.Columns[1].HeaderText = "Mã Tài Liệu";
            dgvMinhChung.Columns[2].HeaderText = "Tên Tài Liệu";
            dgvMinhChung.Columns[3].HeaderText = "Ngày Ký";
            dgvMinhChung.Columns[4].HeaderText = "Người Ký";
            dgvMinhChung.Columns[5].HeaderText = "Số Ban Hành";
            dgvMinhChung.Columns[6].HeaderText = "Tóm Tắt Nội Dung";           
            dgvMinhChung.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMinhChung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
            dgvMinhChung.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMinhChung.AutoGenerateColumns = false;

            dgvMinhChung.EnableHeadersVisualStyles = false;
            dgvMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }
       
        void MinhChungBinding()
        {
            txtMaTaiLieu.DataBindings.Clear();
            txtTenTaiLieu.DataBindings.Clear();
            txtNgayKy.DataBindings.Clear();
            txtNguoiKy.DataBindings.Clear();
            txtSoBanHanh.DataBindings.Clear();
            txtTomTatNoiDung.DataBindings.Clear();            
            txtGhiChu.DataBindings.Clear();
            txtTimKiem.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {            
            txtTenTaiLieu.Text = "";
            txtNgayKy.Text = "";
            txtNguoiKy.Text = "";
            txtSoBanHanh.Text = "";
            txtTomTatNoiDung.Text = "";            
            txtGhiChu.Text = "";
            txtTimKiem.Text = "";
            txtMaTaiLieu.Enabled = true;
            txtTenTaiLieu.Enabled = true;
            txtNgayKy.Enabled = true;
            txtNguoiKy.Enabled = true;
            txtSoBanHanh.Enabled = true;
            txtTomTatNoiDung.Enabled = true;           
            txtGhiChu.Enabled = true;
            txtTimKiem.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;            
            btnLuuTaiLieu.Enabled = true;
            btnTimKiem.Enabled = true;            
            LoadListMinhChung();
        }

        private event EventHandler insertMinhChung;
        public event EventHandler InserMinhChung
        {
            add { insertMinhChung += value; }
            remove { insertMinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string matailieu = txtMaTaiLieu.Text;
            string tentailieu = txtTenTaiLieu.Text;
            string ngayky = txtNgayKy.Text;
            string nguoiky = txtNguoiKy.Text;
            string sobanhanh = txtSoBanHanh.Text;
            string tomtatnoidung = txtTomTatNoiDung.Text;           
            string ghichu = txtGhiChu.Text;

            if (txtMaTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTaiLieu.Focus();
                return;
            }
            else if (txtTenTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiLieu.Focus();
                return;
            }
            else if (txtNgayKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNgayKy.Focus();
                return;
            }
            else if (txtNguoiKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập người ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiKy.Focus();
                return;
            }
            else if (txtSoBanHanh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số ban hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoBanHanh.Focus();
                return;
            }
            else if (txtTomTatNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTomTatNoiDung.Focus();
                return;
            }            
            else if (txtMaTaiLieu.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.MinhChung MChung WHERE MChung.MaTaiLieu = N'{0}'", matailieu);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã tài liệu này đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTaiLieu.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MinhChungBUS.Instance.InsertMinhChung(matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, ghichu))
                {
                    MessageBox.Show("Thêm minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMinhChung != null)
                    {
                        insertMinhChung(this, new EventArgs());
                    }
                    MinhChungBinding();
                    LoadListMinhChung();
                    ResetGiaTri();                                        
                }
                else
                {
                    MessageBox.Show("Thêm minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaTaiLieu.Text = "";
            txtTenTaiLieu.Text = "";
            txtNgayKy.Text = "";
            txtNguoiKy.Text = "";
            txtSoBanHanh.Text = "";
            txtTomTatNoiDung.Text = "";            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMinhChung;
        public event EventHandler UpdateMinhChung
        {
            add { updateMinhChung += value; }
            remove { updateMinhChung -= value; }
        }       
              
        private void btnSua_Click(object sender, EventArgs e)
        {           
            if (MessageBox.Show("Bạn có muốn sửa minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {             
                if (txtMaTaiLieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa mã tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTaiLieu.Focus();
                }
                else if (txtTenTaiLieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTaiLieu.Focus();
                }
                else if (txtNgayKy.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập ngày ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNgayKy.Focus();
                }
                else if (txtNguoiKy.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập người ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNguoiKy.Focus();
                }
                else if (txtSoBanHanh.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập số ban hành !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoBanHanh.Focus();
                }
                else if (txtTomTatNoiDung.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTomTatNoiDung.Focus();
                }                
                else
                {
                    string matailieu = txtMaTaiLieu.Text;
                    string tentailieu = txtTenTaiLieu.Text;
                    string ngayky = txtNgayKy.Text;
                    string nguoiky = txtNguoiKy.Text;
                    string sobanhanh = txtSoBanHanh.Text;
                    string tomtatnoidung = txtTomTatNoiDung.Text;                    
                    string ghichu = txtGhiChu.Text;                   
                    string sql = string.Format("SELECT ID_TaiLieu FROM dbo.MinhChung MChung WHERE MChung.MaTaiLieu = N'{0}'", matailieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tailieu = Int32.Parse(input);

                    if (MinhChungBUS.Instance.UpdateMinhChung(id_tailieu, matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, ghichu))
                    {
                        MessageBox.Show("Sửa minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateMinhChung != null)
                        {
                            updateMinhChung(this, new EventArgs());
                        }
                        MinhChungBinding();
                        LoadListMinhChung();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteMinhChung;
        public event EventHandler DeleteMinhChung
        {
            add { deleteMinhChung += value; }
            remove { deleteMinhChung -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaTaiLieu.Text == "")
                {
                    MessageBox.Show("Bạn chưa mã tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTaiLieu.Focus();
                }
                else
                {
                    string matailieu = txtMaTaiLieu.Text;
                    string sql = string.Format("SELECT ID_TaiLieu FROM dbo.MinhChung MChung WHERE MChung.MaTaiLieu = N'{0}'", matailieu);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_tailieu = Int32.Parse(input);

                    if (MinhChungBUS.Instance.DeleteMinhChung(id_tailieu))
                    {
                        MessageBox.Show("Xóa minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteMinhChung != null)
                        {
                            deleteMinhChung(this, new EventArgs());
                        }
                        MinhChungBinding();
                        LoadListMinhChung();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }       

        private void btnLuuTaiLieu_Click(object sender, EventArgs e)
        {
            FormLuuTaiLieu FrLuuTaiLieu = new FormLuuTaiLieu(); //Khởi tạo đối tượng            
            FrLuuTaiLieu.ShowDialog(); //Hiển thị
            this.Show();
            this.Close();
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

            dgvMinhChung.DataSource = MinhChungBUS.Instance.SearchListMinhChung(timkiem);
            dgvMinhChung.Columns[0].Visible = false;
            dgvMinhChung.Columns[1].HeaderText = "Mã Tài Liệu";
            dgvMinhChung.Columns[2].HeaderText = "Tên Tài Liệu";
            dgvMinhChung.Columns[3].HeaderText = "Ngày Ký";
            dgvMinhChung.Columns[4].HeaderText = "Người Ký";
            dgvMinhChung.Columns[5].HeaderText = "Số Ban Hành";
            dgvMinhChung.Columns[6].HeaderText = "Tóm Tắt Nội Dung";
            dgvMinhChung.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMinhChung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMinhChung.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgvMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMinhChung.AutoGenerateColumns = false;

            dgvMinhChung.EnableHeadersVisualStyles = false;
            dgvMinhChung.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;

            MinhChungBinding();
            ResetGiaTri();
        }        
    }
}
