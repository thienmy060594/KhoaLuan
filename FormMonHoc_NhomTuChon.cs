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
    public partial class FormMonHoc_NhomTuChon : Form
    {
        BindingSource MonHoc_NhomTuChonList = new BindingSource();
        public FormMonHoc_NhomTuChon()
        {
            InitializeComponent();
            dgvMonHocNhomTuChon.DataSource = MonHoc_NhomTuChonList;
            LoadListMonHoc_NhomTuChon();
            AddButtonColumn();
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListMonHoc_NhomTuChon()
        {
            dgvMonHocNhomTuChon.DataSource = NguonMinhChung_MinhChungBUS.Instance.GetListNguonMinhChung_MinhChung();
            dgvMonHocNhomTuChon.Columns[0].Visible = false;
            dgvMonHocNhomTuChon.Columns[1].Visible = false;
            dgvMonHocNhomTuChon.Columns[2].HeaderText = "Mã Môn Học";
            dgvMonHocNhomTuChon.Columns[3].HeaderText = "Tên Môn Học";
            dgvMonHocNhomTuChon.Columns[4].HeaderText = "Mã Nhóm Tự Chọn";
            dgvMonHocNhomTuChon.Columns[5].HeaderText = "Tên Nhóm Tự Chọn";
            dgvMonHocNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvMonHocNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMonHocNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvMonHocNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvMonHocNhomTuChon.AutoGenerateColumns = false;
        }

        private void AddButtonColumn()
        {
            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();// Nút sửa
            {
                btnSua.HeaderText = "Nút Sửa";
                btnSua.Name = "btnSua";
                btnSua.Text = "Sửa";
                btnSua.UseColumnTextForButtonValue = true;
                dgvMonHocNhomTuChon.Columns.Add(btnSua);
                btnSua.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();// Nút xóa
            {
                btnXoa.HeaderText = "Nút Xóa";
                btnXoa.Name = "btnXoa";
                btnXoa.Text = "Xóa";
                btnXoa.UseColumnTextForButtonValue = true;
                dgvMonHocNhomTuChon.Columns.Add(btnXoa);
                btnXoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        void MonHoc_NhomTuChonBinding()
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
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxNhomTuChon.DataSource = NhomTuChonBUS.Instance.GetListNhomTuChon();
            cbxNhomTuChon.ValueMember = "ID_NhomTuChon";
            cbxNhomTuChon.DisplayMember = "TenNhomTuChon";
        }

        private event EventHandler insertMonHoc_NhomTuChon;
        public event EventHandler InsertMonHoc_NhomTuChon
        {
            add { insertMonHoc_NhomTuChon += value; }
            remove { insertMonHoc_NhomTuChon -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue); ;
            int id_monhoc = Int32.Parse(input_1);
            string input_2 = cbxNhomTuChon.GetItemText(cbxNhomTuChon.SelectedValue);
            int id_nhomtuchon = Int32.Parse(input_2);

            if (MessageBox.Show("Bạn có muốn thêm môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MonHoc_NhomTuChonBUS.Instance.InsertMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon, ghichu))
                {
                    MessageBox.Show("Thêm môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMonHoc_NhomTuChon != null)
                    {
                        insertMonHoc_NhomTuChon(this, new EventArgs());
                    }
                    MonHoc_NhomTuChonBinding();
                    LoadListMonHoc_NhomTuChon();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMonHoc_NhomTuChon;
        public event EventHandler UpdateMonHoc_NhomTuChon
        {
            add { updateMonHoc_NhomTuChon += value; }
            remove { updateMonHoc_NhomTuChon -= value; }
        }

        private event EventHandler deleteMonHoc_NhomTuChon;
        public event EventHandler DeleteMonHoc_NhomTuChon
        {
            add { deleteMonHoc_NhomTuChon += value; }
            remove { deleteMonHoc_NhomTuChon -= value; }
        }

        private void dgvMonHocNhomTuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMonHocNhomTuChon.Columns[e.ColumnIndex].Name == "btnSua")
                {
                    dgvMonHocNhomTuChon.CurrentRow.Selected = true;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = dgvMonHocNhomTuChon.Rows[e.RowIndex].Cells["ID_MonHoc"].FormattedValue.ToString();
                    int id_monhoc = Int32.Parse(input_1);
                    string input_2 = dgvMonHocNhomTuChon.Rows[e.RowIndex].Cells["ID_NhomTuChon"].FormattedValue.ToString();
                    int id_nhomtuchon = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn sửa môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MonHoc_NhomTuChonBUS.Instance.UpdateMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon, ghichu))
                        {
                            MessageBox.Show("Sửa môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (updateMonHoc_NhomTuChon != null)
                            {
                                updateMonHoc_NhomTuChon(this, new EventArgs());
                            }
                            MonHoc_NhomTuChonBinding();
                            LoadListMonHoc_NhomTuChon();
                            ResetGiaTri();
                        }
                        else
                        {
                            MessageBox.Show("Sửa môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }                    
                }
                if(dgvMonHocNhomTuChon.Columns[e.ColumnIndex].Name == "btnXoa")
                {
                    dgvMonHocNhomTuChon.CurrentRow.Selected = true;                    
                    string input_1 = dgvMonHocNhomTuChon.Rows[e.RowIndex].Cells["ID_MonHoc"].FormattedValue.ToString();
                    int id_monhoc = Int32.Parse(input_1);
                    string input_2 = dgvMonHocNhomTuChon.Rows[e.RowIndex].Cells["ID_NhomTuChon"].FormattedValue.ToString();
                    int id_nhomtuchon = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn xóa môn học - nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MonHoc_NhomTuChonBUS.Instance.DeleteMonHoc_NhomTuChon(id_monhoc, id_nhomtuchon))
                        {
                            MessageBox.Show("Xóa môn học - nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteMonHoc_NhomTuChon != null)
                            {
                                deleteMonHoc_NhomTuChon(this, new EventArgs());
                            }
                            MonHoc_NhomTuChonBinding();
                            LoadListMonHoc_NhomTuChon();
                        }
                        else
                        {
                            MessageBox.Show("Xóa môn học - nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
