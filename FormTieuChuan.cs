using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KiemDinhChatLuongDTO;
using KiemDinhChatLuongBUS;
using KiemDinhChatLuongDAL;

namespace KiemDinhChatLuongGUI
{
    public partial class FormTieuChuan : Form
    {

        BindingSource TieuChuanList = new BindingSource();

        public FormTieuChuan()
        {
            InitializeComponent();
            dgvTieuChuan.DataSource = TieuChuanList;
            LoadListTieuChuan();           
            btnLuuLai.Enabled = false;
            txtTenTieuChuan.Enabled = false;
            txtMaTieuChuan.Enabled = false;
            txtNoiDungTieuChuan.Enabled = false;
            txtGhiChu.Enabled = false;

        }

        private void LoadListTieuChuan()
        {
            dgvTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            dgvTieuChuan.Columns[0].Visible = false;
            dgvTieuChuan.Columns[1].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChuan.Columns[2].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChuan.Columns[3].HeaderText = "Nội Dung Tiêu Chuẩn";
            dgvTieuChuan.Columns[4].HeaderText = "Ghi Chú";            
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChuan.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChuan.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChuan.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void TieuChuanBinding()
        {
            txtMaTieuChuan.DataBindings.Clear();
            txtTenTieuChuan.DataBindings.Clear();
            txtNoiDungTieuChuan.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        // nút bắt đầu các chức năng
        private void btnBatDau_Click_1(object sender, EventArgs e)
        {
            txtMaTieuChuan.Text = "";
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChu.Text = "";
            txtMaTieuChuan.Enabled = true;
            txtTenTieuChuan.Enabled = true;
            txtNoiDungTieuChuan.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;           
        }

        private event EventHandler insertTieuChuan;
        public event EventHandler InsertTieuChuan
        {
            add { insertTieuChuan += value; }
            remove { insertTieuChuan -= value; }
        }

        //thêm mới một tiêu chuẩn
        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string matieuchuan = txtMaTieuChuan.Text;
            string tentieuchuan = txtTenTieuChuan.Text;
            string noidungtieuchuan = txtNoiDungTieuChuan.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTieuChuan.Focus();
            }
            else if (txtTenTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChuan.Focus();
            }
            else if (txtNoiDungTieuChuan.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChuan.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChuanBUS.Instance.InsertTieuChuan(matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }
                    TieuChuanBinding();
                    LoadListTieuChuan();
                    ResetGiaTri();
                    btnDong.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaTieuChuan.Text = "";
            txtTenTieuChuan.Text = "";
            txtNoiDungTieuChuan.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler deleteTieuChuan;
        public event EventHandler DeleteTieuChuan
        {
            add { deleteTieuChuan += value; }
            remove { deleteTieuChuan -= value; }
        }        

        private event EventHandler updateTieuChuan;
        public event EventHandler UpdateTieuChuan
        {
            add { updateTieuChuan += value; }
            remove { updateTieuChuan -= value; }
        }        

        //chức năng xóa sửa
        private void dgvTieuChuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTieuChuan.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvTieuChuan.CurrentRow.Selected = true;
                    string input = dgvTieuChuan.Rows[e.RowIndex].Cells["ID_TieuChuan"].FormattedValue.ToString();
                    int id_tieuchuan = Int32.Parse(input);
                    if (MessageBox.Show("Bạn có muốn sửa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string matieuchuan = txtMaTieuChuan.Text;
                        string tentieuchuan = txtTenTieuChuan.Text;
                        string noidungtieuchuan = txtNoiDungTieuChuan.Text;
                        string ghichu = txtGhiChu.Text;
                        if (txtMaTieuChuan.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaTieuChuan.Focus();
                            return;
                        }
                        else if (txtTenTieuChuan.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenTieuChuan.Focus();
                            return;
                        }
                        else if (txtNoiDungTieuChuan.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập nội dung tiêu chuẩn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenTieuChuan.Focus();
                            return;
                        }
                        else
                        {
                            if (TieuChuanBUS.Instance.UpdateTieuChuan(id_tieuchuan, matieuchuan, tentieuchuan, noidungtieuchuan, ghichu))
                            {
                                MessageBox.Show("Sửa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateTieuChuan != null)
                                {
                                    updateTieuChuan(this, new EventArgs());
                                }
                                TieuChuanBinding();
                                LoadListTieuChuan();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa tiêu chuẩn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChuanBUS.Instance.DeleteTieuChuan(id_tieuchuan))
                        {
                            MessageBox.Show("Xóa tiêu chuẩn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteTieuChuan != null)
                            {
                                deleteTieuChuan(this, new EventArgs());
                            }
                            TieuChuanBinding();
                            LoadListTieuChuan();
                        }
                        else
                        {
                            MessageBox.Show("Xóa tiêu chuẩn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

          


       


