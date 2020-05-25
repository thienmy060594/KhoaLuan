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
    public partial class FormTieuChi_NguonMinhChung : Form
    {
        BindingSource TieuChi_NguonMinhChungList = new BindingSource();
        public FormTieuChi_NguonMinhChung()
        {
            InitializeComponent();
            dgvTieuChiNguonMinhChung.DataSource = TieuChi_NguonMinhChungList;
            LoadListTieuChi_NguonMinhChung();            
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListTieuChi_NguonMinhChung()
        {
            dgvTieuChiNguonMinhChung.DataSource = TieuChi_NguonMinhChungBUS.Instance.GetListTieuChi_NguonMinhChung();
            dgvTieuChiNguonMinhChung.Columns[0].Visible = false;
            dgvTieuChiNguonMinhChung.Columns[1].Visible = false;
            dgvTieuChiNguonMinhChung.Columns[2].HeaderText = "Mã Tiêu Chí";
            dgvTieuChiNguonMinhChung.Columns[3].HeaderText = "Tên Tiêu Chí";
            dgvTieuChiNguonMinhChung.Columns[4].HeaderText = "Mã Nguồn Minh Chứng";
            dgvTieuChiNguonMinhChung.Columns[5].HeaderText = "Tên Nguồn Minh Chứng";
            dgvTieuChiNguonMinhChung.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvTieuChiNguonMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvTieuChiNguonMinhChung.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvTieuChiNguonMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void TieuChi_NguonMinhChungBinding()
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
            cbxNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            cbxNguonMinhChung.ValueMember = "ID_NguonMinhChung";
            cbxNguonMinhChung.DisplayMember = "TenNguonMinhChung";
        }

        private event EventHandler insertTieuChi_NguonMinhChung;
        public event EventHandler InsertTieuChi_NguonMinhChung
        {
            add { insertTieuChi_NguonMinhChung += value; }
            remove { insertTieuChi_NguonMinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxTieuChi.GetItemText(cbxTieuChi.SelectedValue); ;
            int id_tieuchi = Int32.Parse(input_1);
            string input_2 = cbxNguonMinhChung.GetItemText(cbxNguonMinhChung.SelectedValue); ;
            int id_nguonminhchung = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm tiêu chí - nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_YeuCauBUS.Instance.InsertTieuChi_YeuCau(id_tieuchi, id_nguonminhchung, ghichu))
                {
                    MessageBox.Show("Thêm tiêu chí - nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertTieuChi_NguonMinhChung != null)
                    {
                        insertTieuChi_NguonMinhChung(this, new EventArgs());
                    }
                    TieuChi_NguonMinhChungBinding();
                    LoadListTieuChi_NguonMinhChung();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm tiêu chí - nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtGhiChu.Text = "";
        }

        private event EventHandler updateTieuChi_NguonMinhChung;
        public event EventHandler UpdateTieuChi_NguonMinhChung
        {
            add { updateTieuChi_NguonMinhChung += value; }
            remove { updateTieuChi_NguonMinhChung -= value; }
        }

        private event EventHandler deleteTieuChi_NguonMinhChung;
        public event EventHandler DeleteTieuChi_NguonMinhChung
        {
            add { deleteTieuChi_NguonMinhChung += value; }
            remove { deleteTieuChi_NguonMinhChung -= value; }
        }

        private void dgvTieuChiNguonMinhChung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTieuChiNguonMinhChung.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvTieuChiNguonMinhChung.CurrentRow.Selected = true;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = dgvTieuChiNguonMinhChung.Rows[e.RowIndex].Cells["ID_TieuChi"].FormattedValue.ToString();
                    int id_tieuchi = Int32.Parse(input_1);
                    string input_2 = dgvTieuChiNguonMinhChung.Rows[e.RowIndex].Cells["ID_NguonMinhChung"].FormattedValue.ToString();
                    int id_nguonminhchung = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn sửa tiêu chí - nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChi_NguonMinhChungBUS.Instance.UpdateTieuChi_NguonMinhChung(id_tieuchi, id_nguonminhchung, ghichu))
                        {
                            MessageBox.Show("Sửa tiêu chí - nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (updateTieuChi_NguonMinhChung != null)
                            {
                                updateTieuChi_NguonMinhChung(this, new EventArgs());
                            }
                            TieuChi_NguonMinhChungBinding();
                            LoadListTieuChi_NguonMinhChung();
                            ResetGiaTri();
                        }
                        else
                        {
                            MessageBox.Show("Sửa tiêu chí - nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if(MessageBox.Show("Bạn có muốn xóa tiêu chí - nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (TieuChi_YeuCauBUS.Instance.DeleteTieuChi_YeuCau(id_tieuchi, id_nguonminhchung))
                        {
                            MessageBox.Show("Xóa tiêu chí - nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteTieuChi_NguonMinhChung != null)
                            {
                                deleteTieuChi_NguonMinhChung(this, new EventArgs());
                            }
                            TieuChi_NguonMinhChungBinding();
                            LoadListTieuChi_NguonMinhChung();
                        }
                        else
                        {
                            MessageBox.Show("Xóa tiêu chí - nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
