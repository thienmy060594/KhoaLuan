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
using System.IO;

namespace KiemDinhChatLuongGUI
{
    public partial class FormMinhChungTaiLieu : Form
    {
        BindingSource MinhChungList = new BindingSource();
        public FormMinhChungTaiLieu()
        {
            InitializeComponent();
            dgvMinhChung.DataSource = MinhChungList;
            LoadListMinhChung();
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
            txtGhiChuMChung.DataBindings.Clear();
        }

        private event EventHandler insertMinhChung;
        public event EventHandler InserMinhChung
        {
            add { insertMinhChung += value; }
            remove { insertMinhChung -= value; }
        }

        private void btnThemMoiMChung_Click(object sender, EventArgs e)
        {
            string matailieu = txtMaTaiLieu.Text;
            string tentailieu = txtTenTaiLieu.Text;
            string ngayky = txtNgayKy.Text;
            string nguoiky = txtNguoiKy.Text;
            string sobanhanh = txtSoBanHanh.Text;
            string tomtatnoidung = txtTomTatNoiDung.Text;
            string ghichu = txtGhiChuMChung.Text;

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
                    ResetGiaTriMinhChung();
                }
                else
                {
                    MessageBox.Show("Thêm minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTriMinhChung()
        {
            txtMaTaiLieu.Text = "";
            txtTenTaiLieu.Text = "";
            txtNgayKy.Text = "";
            txtNguoiKy.Text = "";
            txtSoBanHanh.Text = "";
            txtTomTatNoiDung.Text = "";
            txtGhiChuMChung.Text = "";
        }

        private event EventHandler updateMinhChung;
        public event EventHandler UpdateMinhChung
        {
            add { updateMinhChung += value; }
            remove { updateMinhChung -= value; }
        }

        private void btnSuaMChung_Click(object sender, EventArgs e)
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
                    string ghichu = txtGhiChuMChung.Text;
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
                        ResetGiaTriMinhChung();
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

        private void btnXoaMChung_Click(object sender, EventArgs e)
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
                        ResetGiaTriMinhChung();
                    }
                    else
                    {
                        MessageBox.Show("Xóa minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnTimKiemMChung_Click(object sender, EventArgs e)
        {
            string timkiemminhchung = txtTenTaiLieu.Text;
            if (txtTenTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nội dung tìm kiếm !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTaiLieu.Focus();
                return;
            }

            dgvMinhChung.DataSource = MinhChungBUS.Instance.SearchListMinhChung(timkiemminhchung);
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
            ResetGiaTriMinhChung();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetGiaTriMinhChung();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadLuuTaiLieu()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "pdf files (*.pdf) |*.pdf;";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                PDFLuuTaiLieu.LoadFile(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDocTaiLieu_Click(object sender, EventArgs e)
        {
            LoadLuuTaiLieu();            
        }

        private void dgvMinhChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMinhChung.CurrentCell == null || dgvMinhChung.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvMinhChung.CurrentRow.Selected = true;
                txtMaTaiLieu.Text = dgvMinhChung.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                txtTenTaiLieu.Text = dgvMinhChung.Rows[e.RowIndex].Cells[2].FormattedValue.ToString();
                txtNgayKy.Text = dgvMinhChung.Rows[e.RowIndex].Cells[3].FormattedValue.ToString();
                txtNguoiKy.Text = dgvMinhChung.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                txtSoBanHanh.Text = dgvMinhChung.Rows[e.RowIndex].Cells[5].FormattedValue.ToString();
                txtTomTatNoiDung.Text = dgvMinhChung.Rows[e.RowIndex].Cells[6].FormattedValue.ToString();
                txtGhiChuMChung.Text = dgvMinhChung.Rows[e.RowIndex].Cells[7].FormattedValue.ToString();
            }
        }

        private event EventHandler updateLuuDuongLink;
        public event EventHandler UpdateLuuDuongLink
        {
            add { updateLuuDuongLink += value; }
            remove { updateLuuDuongLink -= value; }
        }

        private void dgvMinhChung_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMinhChung.CurrentCell == null || dgvMinhChung.CurrentCell.Value == null || e.RowIndex == -1)
            {
                MessageBox.Show("Bạn vui lòng chọn vào cột tên tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgvMinhChung.CurrentRow.Selected = true;
                string matailieu = dgvMinhChung.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();

                //mở file
                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult dialogResult = openFileDialog.ShowDialog();
                string file_1 = "";
                string file_2 = "";

                if (dialogResult == DialogResult.OK)
                {
                    if (File.Exists(openFileDialog.FileName))
                    {
                        file_1 = openFileDialog.FileName;
                    }
                    else
                    {
                        MessageBox.Show("Tài liệu không tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //save file
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = "D:\\KiemDinhChatLuong\\TaiLieuMinhChung";
                string filename = Path.GetFileName(file_1);
                saveFileDialog.FileName = filename;
                dialogResult = saveFileDialog.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    file_2 = saveFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("Lỗi khi lưu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                File.Copy(file_1, file_2);

                string duonglink = file_2;
                string sql1 = string.Format("SELECT ID_TaiLieu FROM dbo.MinhChung MChung WHERE MChung.MaTaiLieu = N'{0}'", matailieu);
                string input_1 = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql1);
                int id_tailieu = Int32.Parse(input_1);

                if (MinhChungBUS.Instance.UpdateLinkMinhChung(id_tailieu, duonglink))
                {
                    MessageBox.Show("Cập nhật tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (updateLuuDuongLink != null)
                    {
                        updateLuuDuongLink(this, new EventArgs());
                    }
                    PDFLuuTaiLieu.LoadFile(duonglink);
                }
                else
                {
                    MessageBox.Show("Cập nhật tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }          
            }
        }
    }
}


        
    

