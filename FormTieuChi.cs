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
    public partial class FormTieuChi : Form
    {
        BindingSource TieuChiList = new BindingSource();

        public FormTieuChi()
        {
            InitializeComponent();
            dgvTieuChi.DataSource = TieuChiList;
            LoadListTieuChi();          
            txtMaTieuChi.Enabled = false;
            txtTenTieuChi.Enabled = false;
            txtNoiDungTieuChi.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;           
           
        }

        private void LoadListTieuChi()
        {
            dgvTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            dgvTieuChi.Columns[0].Visible = false;
            dgvTieuChi.Columns[1].Visible = false;
            dgvTieuChi.Columns[2].HeaderText = "Mã Tiêu Chuẩn";
            dgvTieuChi.Columns[3].HeaderText = "Tên Tiêu Chuẩn";
            dgvTieuChi.Columns[4].HeaderText = "Mã Tiêu Chí";
            dgvTieuChi.Columns[5].HeaderText = "Tên Tiêu Chí";
            dgvTieuChi.Columns[6].HeaderText = "Nội Dung Tiêu Chí";
            dgvTieuChi.Columns[7].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvTieuChi.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChi.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChi.AllowUserToAddRows = false;
            dgvTieuChi.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp 
            

            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();// Nút sửa
            dgvTieuChi.Columns.Add(btnSua);
            btnSua.HeaderText = "Nút Sửa";
            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.UseColumnTextForButtonValue = true;            

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();// Nút xóa
            dgvTieuChi.Columns.Add(btnXoa);
            btnXoa.HeaderText = "Nút Xóa";
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.UseColumnTextForButtonValue = true;
        }
        
        void TieuChiBinding()
        {
            txtMaTieuChi.DataBindings.Clear();
            txtTenTieuChi.DataBindings.Clear();
            txtNoiDungTieuChi.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();            
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaTieuChi.Text = "";
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChu.Text = "";
            txtMaTieuChi.Enabled = true;
            txtTenTieuChi.Enabled = true;
            txtNoiDungTieuChi.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }             

        private void FillComBoBox()
        {            
            cbxTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            cbxTieuChuan.ValueMember = "ID_TieuChuan";
            cbxTieuChuan.DisplayMember = "TenTieuChuan";                    
        }       

        private event EventHandler insertTieuChuan;
        public event EventHandler InsertTieuChuan
        {
            add { insertTieuChuan += value; }
            remove { insertTieuChuan -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string matieuchi = txtMaTieuChi.Text;
            string tentieuchi = txtTenTieuChi.Text;
            string noidungtieuchi = txtNoiDungTieuChi.Text;
            string ghichu = txtGhiChu.Text;
            string input = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
            int id_tieuchuan = Int32.Parse(input);

            if (txtMaTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaTieuChi.Focus();
                return;
            }
            else if (txtTenTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTieuChi.Focus();
                return;
            }
            else if (txtNoiDungTieuChi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungTieuChi.Focus();
                return;
            }
            else if (txtMaTieuChi.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.TieuChi TChi WHERE TChi.MaTieuChi = N'{0}'", matieuchi);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã tiêu chí đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaTieuChi.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChiBUS.Instance.InsertTieuChi(id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChuan != null)
                    {
                        insertTieuChuan(this, new EventArgs());
                    }                           
                    TieuChiBinding();
                    LoadListTieuChi();
                    ResetGiaTri();
                    btnDong.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaTieuChi.Text = "";
            txtTenTieuChi.Text = "";
            txtNoiDungTieuChi.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateTieuChi;
        public event EventHandler UpdateTieuChi
        {
            add { updateTieuChi += value; }
            remove { updateTieuChi -= value; }
        }

        
        private event EventHandler deleteTieuChi;
        public event EventHandler DeleteTieuChi
        {
            add { deleteTieuChi += value; }
            remove { deleteTieuChi -= value; }
        }

        private void dgvTieuChi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTieuChi.Columns[e.ColumnIndex].Name == "btnSua")
                {
                    dgvTieuChi.CurrentRow.Selected = true;
                    string input = dgvTieuChi.Rows[e.RowIndex].Cells["ID_TieuChi"].FormattedValue.ToString();
                    int id_tieuchi = Int32.Parse(input);
                    string input_1 = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
                    int id_tieuchuan = Int32.Parse(input_1);
                    if (MessageBox.Show("Bạn có muốn sửa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string matieuchi = txtMaTieuChi.Text;
                        string tentieuchi = txtTenTieuChi.Text;
                        string noidungtieuchi = txtNoiDungTieuChi.Text;
                        string ghichu = txtGhiChu.Text;                        

                        if (txtMaTieuChi.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaTieuChi.Focus();
                            return;
                        }
                        else if (txtTenTieuChi.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenTieuChi.Focus();
                            return;
                        }
                        else if (txtNoiDungTieuChi.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập nội dung tiêu chí !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenTieuChi.Focus();
                            return;
                        }
                        else
                        {
                            if (TieuChiBUS.Instance.UpdateTieuChi(id_tieuchi, id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu))
                            {
                                MessageBox.Show("Sửa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateTieuChi != null)
                                {
                                    updateTieuChi(this, new EventArgs());
                                }
                                TieuChiBinding();
                                LoadListTieuChi();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }                    
                }
                if (dgvTieuChi.Columns[e.ColumnIndex].Name == "btnXoa")
                {
                    dgvTieuChi.CurrentRow.Selected = true;
                    string input = dgvTieuChi.Rows[e.RowIndex].Cells["ID_TieuChi"].FormattedValue.ToString();
                    int id_tieuchi = Int32.Parse(input);

                    if (MessageBox.Show("Bạn có muốn xóa tiêu chí này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChiBUS.Instance.DeleteTieuChi(id_tieuchi))
                        {
                            MessageBox.Show("Xóa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteTieuChi != null)
                            {
                                deleteTieuChi(this, new EventArgs());
                            }
                            TieuChiBinding();
                            LoadListTieuChi();
                        }
                        else
                        {
                            MessageBox.Show("Xóa tiêu chí thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
