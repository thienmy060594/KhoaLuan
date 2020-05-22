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
            btnLuuLai.Enabled = false;
            txtMaYeuCau.Enabled = false;
            txtNoiDungYeuCau.Enabled = false;
            txtTenYeuCau.Enabled = false;
            txtGhiChu.Enabled = false;
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
        }

        void YeuCauBinding()
        {
            txtMaYeuCau.DataBindings.Clear();
            txtTenYeuCau.DataBindings.Clear();
            txtNoiDungYeuCau.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
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
            }
            else if (txtTenYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenYeuCau.Focus();
            }
            else if (txtNoiDungYeuCau.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung yêu cầu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungYeuCau.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
        }

        private event EventHandler updateYeuCau;
        public event EventHandler UpdateYeuCau
        {
            add { updateYeuCau += value; }
            remove { updateYeuCau -= value; }
        }        

        private event EventHandler deleteYeuCau;
        public event EventHandler DeleteYeuCau
        {
            add { deleteYeuCau += value; }
            remove { deleteYeuCau -= value; }
        } 
        
        private void dgvYeuCau_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvYeuCau.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvYeuCau.CurrentRow.Selected = true;
                    string input = dgvYeuCau.Rows[e.RowIndex].Cells["ID_YeuCau"].FormattedValue.ToString();
                    int id_yeucau = Int32.Parse(input);
                    if (MessageBox.Show("Bạn có muốn sửa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
                        else
                        {
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
                    else if (MessageBox.Show("Bạn có muốn xóa yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (YeuCauBUS.Instance.DeleteYeuCau(id_yeucau))
                        {
                            MessageBox.Show("Xóa yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteYeuCau != null)
                            {
                                deleteYeuCau(this, new EventArgs());
                            }
                            YeuCauBinding();
                            LoadListYeuCau();
                        }
                        else
                        {
                            MessageBox.Show("Xóa yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
