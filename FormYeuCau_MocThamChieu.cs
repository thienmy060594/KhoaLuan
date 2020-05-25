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
    public partial class FormYeuCau_MocThamChieu : Form
    {
        BindingSource YeuCau_MocThamChieuList = new BindingSource();
        public FormYeuCau_MocThamChieu()
        {
            InitializeComponent();
            dgvYeuCauMocThamChieu.DataSource = YeuCau_MocThamChieuList;
            LoadListYeuCau_MocThamChieu();            
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListYeuCau_MocThamChieu()
        {
            dgvYeuCauMocThamChieu.DataSource = YeuCau_MocThamChieuBUS.Instance.GetListYeuCau_MocThamChieu();
            dgvYeuCauMocThamChieu.Columns[0].Visible = false;
            dgvYeuCauMocThamChieu.Columns[1].Visible = false;
            dgvYeuCauMocThamChieu.Columns[2].HeaderText = "Mã Yêu Cầu";
            dgvYeuCauMocThamChieu.Columns[3].HeaderText = "Tên Yêu Cầu";
            dgvYeuCauMocThamChieu.Columns[4].HeaderText = "Mã Mốc Tham Chiếu";
            dgvYeuCauMocThamChieu.Columns[5].HeaderText = "Tên Mốc Tham Chiếu";
            dgvYeuCauMocThamChieu.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvYeuCauMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvYeuCauMocThamChieu.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvYeuCauMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void YeuCau_MocThamChieuBinding()
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
            cbxYeuCau.DataSource = YeuCauBUS.Instance.GetListYeuCau();
            cbxYeuCau.ValueMember = "ID_YeuCau";
            cbxYeuCau.DisplayMember = "TenYeuCau";
            cbxMocThamChieu.DataSource = MocThamChieuBUS.Instance.GetListMocThamChieu();
            cbxMocThamChieu.ValueMember = "ID_MocThamChieu";
            cbxMocThamChieu.DisplayMember = "TenMocThamChieu";
        }

        private event EventHandler insertYeuCau_MocThamChieu;
        public event EventHandler InsertYeuCau_MocThamChieu
        {
            add { insertYeuCau_MocThamChieu += value; }
            remove { insertYeuCau_MocThamChieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxYeuCau.GetItemText(cbxYeuCau.SelectedValue); ;
            int id_yeucau = Int32.Parse(input_1);
            string input_2 = cbxMocThamChieu.GetItemText(cbxMocThamChieu.SelectedValue); ;
            int id_mocthamchieu = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (TieuChi_YeuCauBUS.Instance.InsertTieuChi_YeuCau(id_yeucau, id_mocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertYeuCau_MocThamChieu != null)
                    {
                        insertYeuCau_MocThamChieu(this, new EventArgs());
                    }
                    YeuCau_MocThamChieuBinding();
                    LoadListYeuCau_MocThamChieu();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {            
            txtGhiChu.Text = "";
        }

        private event EventHandler updateYeuCau_MocThamChieu;
        public event EventHandler UpdateYeuCau_MocThamChieu
        {
            add { updateYeuCau_MocThamChieu += value; }
            remove { updateYeuCau_MocThamChieu -= value; }
        }

        private event EventHandler deleteYeuCau_MocThamChieu;
        public event EventHandler DeleteYeuCau_MocThamChieu
        {
            add { deleteYeuCau_MocThamChieu += value; }
            remove { deleteYeuCau_MocThamChieu -= value; }
        }

        private void dgvYeuCauMocThamChieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvYeuCauMocThamChieu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvYeuCauMocThamChieu.CurrentRow.Selected = true;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = dgvYeuCauMocThamChieu.Rows[e.RowIndex].Cells["ID_YeuCau"].FormattedValue.ToString();
                    int id_yeucau = Int32.Parse(input_1);
                    string input_2 = dgvYeuCauMocThamChieu.Rows[e.RowIndex].Cells["ID_MocThamChieu"].FormattedValue.ToString();
                    int id_mocthamchieu = Int32.Parse(input_2);

                    if(MessageBox.Show("Bạn có muốn sửa yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (YeuCau_MocThamChieuBUS.Instance.UpdateYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu, ghichu))
                        {
                            MessageBox.Show("Sửa yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (updateYeuCau_MocThamChieu != null)
                            {
                                updateYeuCau_MocThamChieu(this, new EventArgs());
                            }
                            YeuCau_MocThamChieuBinding();
                            LoadListYeuCau_MocThamChieu();
                            ResetGiaTri();
                        }
                        else
                        {
                            MessageBox.Show("Sửa yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa yêu cầu - mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (YeuCau_MocThamChieuBUS.Instance.DeleteYeuCau_MocThamChieu(id_yeucau, id_mocthamchieu))
                        {
                            MessageBox.Show("Xóa yêu cầu - mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteYeuCau_MocThamChieu != null)
                            {
                                deleteYeuCau_MocThamChieu(this, new EventArgs());
                            }
                            YeuCau_MocThamChieuBinding();
                            LoadListYeuCau_MocThamChieu();
                        }
                        else
                        {
                            MessageBox.Show("Xóa yêu cầu - mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
