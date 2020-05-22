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
    public partial class FormLoaiTaiLieu : Form
    {
        BindingSource LoaiTaiLieuList = new BindingSource();
        public FormLoaiTaiLieu()
        {
            InitializeComponent();
            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuList;
            LoadListLoaiTaiLieu();            
            btnLuuLai.Enabled = false;
            txtMaLoaiTaiLieu.Enabled = false;
            txtTenLoaiTaiLieu.Enabled = false;
            txtGhiChu.Enabled = false;
        }
        private void LoadListLoaiTaiLieu()
        {
            dgvLoaiTaiLieu.DataSource = LoaiTaiLieuBUS.Instance.GetListLoaiTaiLieu();
            dgvLoaiTaiLieu.Columns[0].Visible = false;
            dgvLoaiTaiLieu.Columns[1].Visible = false;
            dgvLoaiTaiLieu.Columns[2].Visible = false;
            dgvLoaiTaiLieu.Columns[3].HeaderText = "Mã Loại Tài Liệu";            
            dgvLoaiTaiLieu.Columns[4].HeaderText = "Tên Loại Tài Liệu";            
            dgvLoaiTaiLieu.Columns[5].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvLoaiTaiLieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvLoaiTaiLieu.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;              
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvLoaiTaiLieu.AllowUserToAddRows = false;
            dgvLoaiTaiLieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void LoaiTaiLieuBinding()
        {
            txtMaLoaiTaiLieu.DataBindings.Clear();
            txtTenLoaiTaiLieu.DataBindings.Clear();            
            txtGhiChu.DataBindings.Clear();
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaLoaiTaiLieu.Text = "";
            txtTenLoaiTaiLieu.Text = "";
            txtGhiChu.Text = "";
            txtMaLoaiTaiLieu.Enabled = true;
            txtTenLoaiTaiLieu.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
        }        

        private event EventHandler insertLoaiTaiLieu;
        public event EventHandler InsertLoaiTaiLieu
        {
            add { insertLoaiTaiLieu += value; }
            remove { insertLoaiTaiLieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string maloaitailieu = txtMaLoaiTaiLieu.Text;
            string tenloaitailieu = txtTenLoaiTaiLieu.Text;           
            string ghichu = txtGhiChu.Text;           
            string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue); ;
            int id_tailieu = Int32.Parse(input_1);
            string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_2);

            if (txtTenLoaiTaiLieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiTaiLieu.Focus();
            }            
            else if (MessageBox.Show("Bạn có muốn thêm loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (LoaiTaiLieuBUS.Instance.InsertLoaiTaiLieu(id_tailieu, id_nguonminhchung ,maloaitailieu, tenloaitailieu, ghichu))
                {
                    MessageBox.Show("Thêm loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertLoaiTaiLieu != null)
                    {
                        insertLoaiTaiLieu(this, new EventArgs());
                    }                    
                    LoaiTaiLieuBinding();
                    LoadListLoaiTaiLieu();
                    ResetGiaTri();
                    btnDong.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("Thêm loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaLoaiTaiLieu.Text = "";
            txtTenLoaiTaiLieu.Text = "";            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateLoaiTaiLieu;
        public event EventHandler UpdateLoaiTaiLieu
        {
            add { updateLoaiTaiLieu += value; }
            remove { updateLoaiTaiLieu -= value; }
        }
               
        private event EventHandler deleteLoaiTaiLieu;
        public event EventHandler DeleteLoaiTaiLieu
        {
            add { deleteLoaiTaiLieu += value; }
            remove { deleteLoaiTaiLieu -= value; }
        }               

        private void dgvLoaiTaiLieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (dgvLoaiTaiLieu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvLoaiTaiLieu.CurrentRow.Selected = true;
                    string input = dgvLoaiTaiLieu.Rows[e.RowIndex].Cells["ID_LoaiTaiLieu"].FormattedValue.ToString();
                    int id_loaitailieu = Int32.Parse(input);
                    if (MessageBox.Show("Bạn có muốn sửa loại tài liệu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string maloaitailieu = txtMaLoaiTaiLieu.Text;
                        string tenloaitailieu = txtTenLoaiTaiLieu.Text;
                        string ghichu = txtGhiChu.Text;
                        string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue); ;
                        int id_tailieu = Int32.Parse(input_1);
                        string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
                        int id_nguonminhchung = Int32.Parse(input_2);

                        if (txtMaLoaiTaiLieu.Text == "")
                        {
                            MessageBox.Show("Bạn chưa mã loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaLoaiTaiLieu.Focus();
                        }
                        else if (txtTenLoaiTaiLieu.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên loại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenLoaiTaiLieu.Focus();
                        }                        
                        else
                        {
                            if (LoaiTaiLieuBUS.Instance.UpdateLoaiTaiLieu(id_loaitailieu, id_tailieu, id_nguonminhchung, maloaitailieu, tenloaitailieu, ghichu))
                            {
                                MessageBox.Show("Sửa loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateLoaiTaiLieu != null)
                                {
                                    updateLoaiTaiLieu(this, new EventArgs());
                                }
                                LoaiTaiLieuBinding();
                                LoadListLoaiTaiLieu();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa loại tài liệu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (LoaiTaiLieuBUS.Instance.DeleteLoaiTaiLieu(id_loaitailieu))
                        {
                            MessageBox.Show("Xóa loại tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteLoaiTaiLieu != null)
                            {
                                deleteLoaiTaiLieu(this, new EventArgs());
                            }
                            LoaiTaiLieuBinding();
                            LoadListLoaiTaiLieu();
                        }
                        else
                        {
                            MessageBox.Show("Xóa loại tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
