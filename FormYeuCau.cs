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
using Microsoft.VisualBasic;

namespace KiemDinhChatLuongGUI
{
    public partial class FormYeuCau : Form
    {
        BindingSource YeuCauList = new BindingSource();
        public FormYeuCau()
        {
            InitializeComponent();
            dgvYeuCau.DataSource = YeuCauList;
            LoadListYeuCau();           
            txtMaYeuCau.Enabled = false;
            txtNoiDungYeuCau.Enabled = false;
            txtTenYeuCau.Enabled = false;
            txtGhiChu.Enabled = false; 
            btnLuuLai.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = false;
        }
        private void LoadListYeuCau()
        {
            dgvYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            dgvYeuCau.Columns[0].Visible = false;
            dgvYeuCau.Columns[1].HeaderText = "Mã Yêu Cầu";
            dgvYeuCau.Columns[2].HeaderText = "Tên Yêu Cầu";
            dgvYeuCau.Columns[3].HeaderText = "Nội Dung Yêu Cầu";
            dgvYeuCau.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvYeuCau.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCau.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCau.AllowUserToAddRows = false;
            dgvYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp     
            dgvYeuCau.AutoGenerateColumns = false;

            dgvYeuCau.EnableHeadersVisualStyles = false;
            dgvYeuCau.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
        }                

        void YeuCauBinding()
        {
            txtMaYeuCau.DataBindings.Clear();
            txtTenYeuCau.DataBindings.Clear();
            txtNoiDungYeuCau.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaYeuCau.Text = "";
            txtTenYeuCau.Text = "";
            txtNoiDungYeuCau.Text = "";
            txtGhiChu.Text = "";
            txtMaYeuCau.Enabled = true;
            txtTenYeuCau.Enabled = true;
            txtNoiDungYeuCau.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnHuy.Enabled = true;
        }

        private event EventHandler insertYeuCau;
        public event EventHandler InsertYeuCau
        {
            add { insertYeuCau += value; }
            remove { insertYeuCau -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string mayeucau = txtMaYeuCau.Text;
            string tenyeucau = txtTenYeuCau.Text;
            string noidungyeucau = txtNoiDungYeuCau.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaYeuCau.Focus();
                return;
            }
            else if (txtTenYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenYeuCau.Focus();
                return;
            }
            else if (txtNoiDungYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungYeuCau.Focus();
                return;
            }
            else if (txtMaYeuCau.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.YeuCau YCau WHERE YCau.MaYeuCau = N'{0}'", mayeucau);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã yêu cầu đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaYeuCau.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (YeuCauBUS.Instance.InsertYeuCau(mayeucau, tenyeucau, noidungyeucau, ghichu))
                {
                    MessageBox.Show("Thêm yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertYeuCau != null)
                    {
                        insertYeuCau(this, new EventArgs());
                    }                   
                    YeuCauBinding();
                    LoadListYeuCau();
                    ResetGiaTri();
                    btnDong.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("Thêm yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }      
        }

        void ResetGiaTri()
        {
            txtMaYeuCau.Text = "";
            txtTenYeuCau.Text = "";
            txtNoiDungYeuCau.Text = "";
            txtGhiChu.Text = "";
        }  
        
        private event EventHandler updateYeuCau;
        public event EventHandler UpdateYeuCau
        {
            add { updateYeuCau += value; }
            remove { updateYeuCau -= value; }
        }    

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn sửa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {               
                if (txtMaYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaYeuCau.Focus();
                    return;
                }
                else if (txtTenYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenYeuCau.Focus();
                    return;
                }
                else if (txtNoiDungYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNoiDungYeuCau.Focus();
                    return;
                }
                else
                {
                    string mayeucau = txtMaYeuCau.Text;
                    string tenyeucau = txtTenYeuCau.Text;
                    string noidungyeucau = txtNoiDungYeuCau.Text;
                    string ghichu = txtGhiChu.Text;
                    string sql = string.Format("SELECT ID_YeuCau FROM dbo.YeuCau YCau WHERE YCau.MaYeuCau = N'{0}'", mayeucau);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_yeucau = Int32.Parse(input);

                    if (YeuCauBUS.Instance.UpdateYeuCau(id_yeucau, mayeucau, tenyeucau, noidungyeucau, ghichu))
                    {
                        MessageBox.Show("Sửa yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateYeuCau != null)
                        {
                            updateYeuCau(this, new EventArgs());
                        }
                        YeuCauBinding();
                        LoadListYeuCau();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Sửa yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private event EventHandler deleteYeuCau;
        public event EventHandler DeleteYeuCau
        {
            add { deleteYeuCau += value; }
            remove { deleteYeuCau -= value; }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtMaYeuCau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaYeuCau.Focus();
                    return;
                }
                else
                {
                    string mayeucau = txtMaYeuCau.Text;
                    string sql = string.Format("SELECT ID_YeuCau FROM dbo.YeuCau YCau WHERE YCau.MaYeuCau = N'{0}'", mayeucau);
                    string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                    int id_yeucau = Int32.Parse(input);

                    if (YeuCauBUS.Instance.DeleteYeuCau(id_yeucau))
                    {
                        MessageBox.Show("Xóa yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (deleteYeuCau != null)
                        {
                            deleteYeuCau(this, new EventArgs());
                        }
                        YeuCauBinding();
                        LoadListYeuCau();
                        ResetGiaTri();
                    }
                    else
                    {
                        MessageBox.Show("Xóa yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
