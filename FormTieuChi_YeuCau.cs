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
    public partial class FormTieuChi_YeuCau : Form
    {
        BindingSource TieuChi_YeuCauList = new BindingSource();
        public FormTieuChi_YeuCau()
        {
            InitializeComponent();
            dgvTieuChiYeuCau.DataSource = TieuChi_YeuCauList;
            LoadListTieuChi_YeuCau();
            AddButtonColumn();
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;  
        }

        private void LoadListTieuChi_YeuCau()
        {
            dgvTieuChiYeuCau.DataSource = TieuChi_YeuCauBUS.Instance.GetListTieuChi_YeuCau();
            dgvTieuChiYeuCau.Columns[0].Visible = false;
            dgvTieuChiYeuCau.Columns[1].Visible = false;           
            dgvTieuChiYeuCau.Columns[2].HeaderText = "Mã Tiêu Chí";
            dgvTieuChiYeuCau.Columns[3].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiYeuCau.Columns[4].HeaderText = "Mã Yêu Cầu";
            dgvTieuChiYeuCau.Columns[5].HeaderText = "Tên Yêu Cầu";
            dgvTieuChiYeuCau.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChiYeuCau.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiYeuCau.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChiYeuCau.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvTieuChiYeuCau.AutoGenerateColumns = false;
        }

        private void AddButtonColumn()
        {
            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();// Nút sửa
            {
                btnSua.HeaderText = "Nút Sửa";
                btnSua.Name = "btnSua";
                btnSua.Text = "Sửa";
                btnSua.UseColumnTextForButtonValue = true;
                dgvTieuChiYeuCau.Columns.Add(btnSua);
                btnSua.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();// Nút xóa
            {
                btnXoa.HeaderText = "Nút Xóa";
                btnXoa.Name = "btnXoa";
                btnXoa.Text = "Xóa";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvTieuChiYeuCau.Columns.Add(btnXoa);
                btnXoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        void TieuChi_YeuCauBinding()
        {            
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtGhiChu.Text = "";           
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxTieuChi.DataSource = TieuChiBUS.Instance.GetListTieuChi();
            cbxTieuChi.ValueMember = "ID_TieuChi";
            cbxTieuChi.DisplayMember = "TenTieuChi";
            cbxYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            cbxYeuCau.ValueMember = "ID_YeuCau";
            cbxYeuCau.DisplayMember = "TenYeuCau";
        }

        private event EventHandler insertTieuChi_YeuCau;
        public event EventHandler InsertTieuChi_YeuCau
        {
            add { insertTieuChi_YeuCau += value; }
            remove { insertTieuChi_YeuCau -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
            int id_tieuchi = Int32.Parse(input_1);
            string input_2 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
            int id_yeucau = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_YeuCauBUS.Instance.InsertTieuChi_YeuCau( id_tieuchi, id_yeucau,ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChi_YeuCau != null)
                    {
                        insertTieuChi_YeuCau(this, new EventArgs());
                    }
                    TieuChi_YeuCauBinding();
                    LoadListTieuChi_YeuCau();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        void ResetGiaTri()
        {            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateTieuChi_YeuCau;
        public event EventHandler UpdateTieuChi_YeuCau
        {
            add { updateTieuChi_YeuCau += value; }
            remove { updateTieuChi_YeuCau -= value; }
        }

        private event EventHandler deleteTieuChi_YeuCau;
        public event EventHandler DeleteTieuChi_YeuCau
        {
            add { deleteTieuChi_YeuCau += value; }
            remove { deleteTieuChi_YeuCau -= value; }
        }

        private void dgvTieuChiYeuCau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTieuChiYeuCau.Columns[e.ColumnIndex].Name == "btnSua")
                {
                    dgvTieuChiYeuCau.CurrentRow.Selected = true;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = dgvTieuChiYeuCau.Rows[e.RowIndex].Cells["ID_TieuChi"].FormattedValue.ToString();
                    int id_tieuchi = Int32.Parse(input_1);
                    string input_2 = dgvTieuChiYeuCau.Rows[e.RowIndex].Cells["ID_YeuCau"].FormattedValue.ToString();
                    int id_yeucau = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn sửa tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChi_YeuCauBUS.Instance.UpdateTieuChi_YeuCau(id_tieuchi, id_yeucau, ghichu))
                        {
                            MessageBox.Show("Sửa tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (updateTieuChi_YeuCau != null)
                            {
                                updateTieuChi_YeuCau(this, new EventArgs());
                            }
                            TieuChi_YeuCauBinding();
                            LoadListTieuChi_YeuCau();
                            ResetGiaTri();
                        }
                        else
                        {
                            MessageBox.Show("Sửa tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }                    
                }
                if(dgvTieuChiYeuCau.Columns[e.ColumnIndex].Name == "btnXoa")
                {
                    dgvTieuChiYeuCau.CurrentRow.Selected = true;                    
                    string input_1 = dgvTieuChiYeuCau.Rows[e.RowIndex].Cells["ID_TieuChi"].FormattedValue.ToString();
                    int id_tieuchi = Int32.Parse(input_1);
                    string input_2 = dgvTieuChiYeuCau.Rows[e.RowIndex].Cells["ID_YeuCau"].FormattedValue.ToString();
                    int id_yeucau = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn xóa tiêu chí - yêu cầu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChi_YeuCauBUS.Instance.DeleteTieuChi_YeuCau(id_tieuchi, id_yeucau))
                        {
                            MessageBox.Show("Xóa tiêu chí - yêu cầu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteTieuChi_YeuCau != null)
                            {
                                deleteTieuChi_YeuCau(this, new EventArgs());
                            }
                            TieuChi_YeuCauBinding();
                            LoadListTieuChi_YeuCau();
                        }
                        else
                        {
                            MessageBox.Show("Xóa tiêu chí - yêu cầu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
