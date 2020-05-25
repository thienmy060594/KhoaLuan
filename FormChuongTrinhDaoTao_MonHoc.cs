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
    public partial class FormChuongTrinhDaoTao_MonHoc : Form
    {
        BindingSource ChuongTrinhDaoTao_MonHocList = new BindingSource();
        public FormChuongTrinhDaoTao_MonHoc()
        {
            InitializeComponent();
            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocList;
            LoadListChuongTrinhDaoTao_MonHoc();
            txtHocKy.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListChuongTrinhDaoTao_MonHoc()
        {
            dgvChuongTrinhDaoTaoMonHoc.DataSource = ChuongTrinhDaoTao_MonHocBUS.Instance.GetListChuongTrinhDaoTao_MonHoc();
            dgvChuongTrinhDaoTaoMonHoc.Columns[0].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[1].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[2].Visible = false;
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].HeaderText = "Mã Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].HeaderText = "Tên Môn Học";
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].HeaderText = "Mã Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].HeaderText = "Tên Loại Môn";
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].HeaderText = "Học Kỳ";
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvChuongTrinhDaoTaoMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTaoMonHoc.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTaoMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void ChuongTrinhDaoTao_MonHocBinding()
        {
            txtHocKy.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtHocKy.Text = "";
            txtGhiChu.Text = "";
            txtHocKy.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "ID_ChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "TenChuongTrinhDaoTao";
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxLoaiMon.DataSource = LoaiMonBUS.Instance.GetListLoaiMon();
            cbxLoaiMon.ValueMember = "ID_LoaiMon";
            cbxLoaiMon.DisplayMember = "TenLoaiMon";
        }

        private event EventHandler insertChuongTrinhDaoTao_MonHoc;
        public event EventHandler InsertChuongTrinhDaoTao_MonHoc
        {
            add { insertChuongTrinhDaoTao_MonHoc += value; }
            remove { insertChuongTrinhDaoTao_MonHoc -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string hocky = txtHocKy.Text;
            string ghichu = txtGhiChu.Text;
            string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue); ;
            int id_chuongtrinhdaotao = Int32.Parse(input_1);
            string input_2 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
            int id_monhoc = Int32.Parse(input_2);
            string input_3 = cbxLoaiMon.GetItemText(cbxLoaiMon.SelectedValue);
            int id_loaimon = Int32.Parse(input_3);

            if (MessageBox.Show("Bạn có muốn thêm chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ChuongTrinhDaoTao_MonHocBUS.Instance.InsertChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu))
                {
                    MessageBox.Show("Thêm chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertChuongTrinhDaoTao_MonHoc != null)
                    {
                        insertChuongTrinhDaoTao_MonHoc(this, new EventArgs());
                    }
                    ChuongTrinhDaoTao_MonHocBinding();
                    LoadListChuongTrinhDaoTao_MonHoc();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtHocKy.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateChuongTrinhDaoTao_MonHoc;
        public event EventHandler UpdateChuongTrinhDaoTao_MonHoc
        {
            add { updateChuongTrinhDaoTao_MonHoc += value; }
            remove { updateChuongTrinhDaoTao_MonHoc -= value; }
        }

        private event EventHandler deleteChuongTrinhDaoTao_MonHoc;
        public event EventHandler DeleteChuongTrinhDaoTao_MonHoc
        {
            add { deleteChuongTrinhDaoTao_MonHoc += value; }
            remove { deleteChuongTrinhDaoTao_MonHoc -= value; }
        }

        private void dgvChuongTrinhDaoTaoMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChuongTrinhDaoTaoMonHoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvChuongTrinhDaoTaoMonHoc.CurrentRow.Selected = true;
                    string hocky = txtHocKy.Text;
                    string ghichu = txtGhiChu.Text;
                    string input_1 = dgvChuongTrinhDaoTaoMonHoc.Rows[e.RowIndex].Cells["ID_ChuongTrinhDaoTao"].FormattedValue.ToString();
                    int id_chuongtrinhdaotao = Int32.Parse(input_1);
                    string input_2 = dgvChuongTrinhDaoTaoMonHoc.Rows[e.RowIndex].Cells["ID_MonHoc"].FormattedValue.ToString();
                    int id_monhoc = Int32.Parse(input_2);
                    string input_3 = dgvChuongTrinhDaoTaoMonHoc.Rows[e.RowIndex].Cells["ID_LoaiMon"].FormattedValue.ToString();
                    int id_loaimon = Int32.Parse(input_3);

                    if (MessageBox.Show("Bạn có muốn sửa chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ChuongTrinhDaoTao_MonHocBUS.Instance.UpdateChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu))
                        {
                            MessageBox.Show("Sửa chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (updateChuongTrinhDaoTao_MonHoc != null)
                            {
                                updateChuongTrinhDaoTao_MonHoc(this, new EventArgs());
                            }
                            ChuongTrinhDaoTao_MonHocBinding();
                            LoadListChuongTrinhDaoTao_MonHoc();
                            ResetGiaTri();
                        }
                        else
                        {
                            MessageBox.Show("Sửa chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa chương trình đào tạo - môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ChuongTrinhDaoTao_MonHocBUS.Instance.DeleteChuongTrinhDaoTao_MonHoc(id_chuongtrinhdaotao, id_monhoc, id_loaimon))
                        {
                            MessageBox.Show("Xóa chương trình đào tạo - môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteChuongTrinhDaoTao_MonHoc != null)
                            {
                                deleteChuongTrinhDaoTao_MonHoc(this, new EventArgs());
                            }
                            ChuongTrinhDaoTao_MonHocBinding();
                            LoadListChuongTrinhDaoTao_MonHoc();
                        }
                        else
                        {
                            MessageBox.Show("Xóa chương trình đào tạo - môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
