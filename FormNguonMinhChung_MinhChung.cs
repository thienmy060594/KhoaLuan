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
    public partial class FormNguonMinhChung_MinhChung : Form
    {
        BindingSource NguonMinhChung_MinhChungList = new BindingSource();
        public FormNguonMinhChung_MinhChung()
        {
            InitializeComponent();
            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChung_MinhChungList;
            LoadListNguonMinhChung_MinhChung();
            AddButtonColumn();
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;            
        }

        private void LoadListNguonMinhChung_MinhChung()
        {
            dgvNguonMinhChungMinhChung.DataSource = NguonMinhChung_MinhChungBUS.Instance.GetListNguonMinhChung_MinhChung();
            dgvNguonMinhChungMinhChung.Columns[0].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[1].Visible = false;
            dgvNguonMinhChungMinhChung.Columns[2].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[3].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChungMinhChung.Columns[4].HeaderText = "Mã Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[5].HeaderText = "Tên Tài Liệu";
            dgvNguonMinhChungMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNguonMinhChungMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChungMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChungMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp    
            dgvNguonMinhChungMinhChung.AutoGenerateColumns = false;
        }

        private void AddButtonColumn()
        {
            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();// Nút sửa
            {
                btnSua.HeaderText = "Nút Sửa";
                btnSua.Name = "btnSua";
                btnSua.Text = "Sửa";
                btnSua.UseColumnTextForButtonValue = true;
                dgvNguonMinhChungMinhChung.Columns.Add(btnSua);
                btnSua.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();// Nút xóa
            {
                btnXoa.HeaderText = "Nút Xóa";
                btnXoa.Name = "btnXoa";
                btnXoa.Text = "Xóa";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvNguonMinhChungMinhChung.Columns.Add(btnXoa);
                btnXoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        void NguonMinhChung_MinhChungBinding()
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
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_Tailieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
        }

        private event EventHandler insertNguonMinhChung_MinhChung;
        public event EventHandler InsertNguonMinhChung_MinhChung
        {
            add { insertNguonMinhChung_MinhChung += value; }
            remove { insertNguonMinhChung_MinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;            
            string input_1 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_1);
            string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
            int id_tailieu = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_YeuCauBUS.Instance.InsertTieuChi_YeuCau(id_nguonminhchung, id_tailieu, ghichu))
                {
                    MessageBox.Show("Thêm nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNguonMinhChung_MinhChung != null)
                    {
                        insertNguonMinhChung_MinhChung(this, new EventArgs());
                    }
                    NguonMinhChung_MinhChungBinding();
                    LoadListNguonMinhChung_MinhChung();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNguonMinhChung_MinhChung;
        public event EventHandler UpdateNguonMinhChung_MinhChung
        {
            add { updateNguonMinhChung_MinhChung += value; }
            remove { updateNguonMinhChung_MinhChung -= value; }
        }

        private event EventHandler deleteNguonMinhChung_MinhChung;
        public event EventHandler DeleteNguonMinhChung_MinhChung
        {
            add { deleteNguonMinhChung_MinhChung += value; }
            remove { deleteNguonMinhChung_MinhChung -= value; }
        }

        private void dgvNguonMinhChungMinhChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNguonMinhChungMinhChung.Columns[e.ColumnIndex].Name == "btnSua")
                {
                    dgvNguonMinhChungMinhChung.CurrentRow.Selected = true;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = dgvNguonMinhChungMinhChung.Rows[e.RowIndex].Cells["ID_NguonMinhChung"].FormattedValue.ToString();
                    int id_nguonminhchung = Int32.Parse(input_1);
                    string input_2 = dgvNguonMinhChungMinhChung.Rows[e.RowIndex].Cells["ID_TaiLieu"].FormattedValue.ToString();
                    int id_tailieu = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn sửa nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NguonMinhChung_MinhChungBUS.Instance.UpdateNguonMinhChung_MinhChung(id_nguonminhchung, id_tailieu, ghichu))
                        {
                            MessageBox.Show("Sửa nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (updateNguonMinhChung_MinhChung != null)
                            {
                                updateNguonMinhChung_MinhChung(this, new EventArgs());
                            }
                            NguonMinhChung_MinhChungBinding();
                            LoadListNguonMinhChung_MinhChung();
                            ResetGiaTri();
                        }
                        else
                        {
                            MessageBox.Show("Sửa nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }                    
                }
                if(dgvNguonMinhChungMinhChung.Columns[e.ColumnIndex].Name == "btnXoa")
                {
                    string input_1 = dgvNguonMinhChungMinhChung.Rows[e.RowIndex].Cells["ID_NguonMinhChung"].FormattedValue.ToString();
                    int id_nguonminhchung = Int32.Parse(input_1);
                    string input_2 = dgvNguonMinhChungMinhChung.Rows[e.RowIndex].Cells["ID_TaiLieu"].FormattedValue.ToString();
                    int id_tailieu = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn xóa nguồn minh chứng - minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChi_YeuCauBUS.Instance.DeleteTieuChi_YeuCau(id_nguonminhchung, id_tailieu))
                        {
                            MessageBox.Show("Xóa nguồn minh chứng - minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteNguonMinhChung_MinhChung != null)
                            {
                                deleteNguonMinhChung_MinhChung(this, new EventArgs());
                            }
                            NguonMinhChung_MinhChungBinding();
                            LoadListNguonMinhChung_MinhChung();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nguồn minh chứng - minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
