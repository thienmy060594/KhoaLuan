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
    public partial class FormDeCuongMonHoc : Form
    {
        BindingSource DeCuongMonHocList = new BindingSource();
        public FormDeCuongMonHoc()
        {
            InitializeComponent();
            dgvDeCuongMonHoc.DataSource = DeCuongMonHocList;
            LoadListDeCuongMonHoc();
            txtMaDeCuongMonHoc.Enabled = false;
            txtTenDeCuongMonHoc.Enabled = false;
            txtNoiDung.Enabled = false;
            txtGhiChu.Enabled = false;            
            btnLuuLai.Enabled = false;
        }

        private void LoadListDeCuongMonHoc()
        {
            dgvDeCuongMonHoc.DataSource = DeCuongMonHocBUS.Instance.GetListDeCuongMonHoc();
            dgvDeCuongMonHoc.Columns[0].Visible = false;
            dgvDeCuongMonHoc.Columns[1].Visible = false;
            dgvDeCuongMonHoc.Columns[2].Visible = false;
            dgvDeCuongMonHoc.Columns[3].HeaderText = "Mã Môn Học";
            dgvDeCuongMonHoc.Columns[4].HeaderText = "Tên Môn Học";
            dgvDeCuongMonHoc.Columns[5].HeaderText = "Mã Tài Liệu";
            dgvDeCuongMonHoc.Columns[6].HeaderText = "Tên Tài Liệu";
            dgvDeCuongMonHoc.Columns[7].HeaderText = "Mã Đề Cương Môn Học";
            dgvDeCuongMonHoc.Columns[8].HeaderText = "Tên Đề Cương Môn Học";
            dgvDeCuongMonHoc.Columns[9].HeaderText = "Nội Dung";
            dgvDeCuongMonHoc.Columns[10].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột          
            dgvDeCuongMonHoc.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvDeCuongMonHoc.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvDeCuongMonHoc.AllowUserToAddRows = false;
            dgvDeCuongMonHoc.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void DeCuongMonHocBinding()
        {
            txtMaDeCuongMonHoc.DataBindings.Clear();
            txtTenDeCuongMonHoc.DataBindings.Clear();            
            txtNoiDung.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaDeCuongMonHoc.Text = "";
            txtTenDeCuongMonHoc.Text = "";            
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
            txtMaDeCuongMonHoc.Enabled = true;
            txtTenDeCuongMonHoc.Enabled = true;            
            txtNoiDung.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxMonHoc.DataSource = MonHocBUS.Instance.GetListMonHoc();
            cbxMonHoc.ValueMember = "ID_MonHoc";
            cbxMonHoc.DisplayMember = "TenMonHoc";
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
        }

        private event EventHandler insertDeCuongMonHoc;
        public event EventHandler InsertDeCuongMonHoc
        {
            add { insertDeCuongMonHoc += value; }
            remove { insertDeCuongMonHoc -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string madecuongmonhoc = txtMaDeCuongMonHoc.Text;
            string tendecuongmonhoc = txtTenDeCuongMonHoc.Text;            
            string noidung = txtNoiDung.Text;
            string ghichu = txtGhiChu.Text;
            string input = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
            int id_monhoc = Int32.Parse(input);
            string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
            int id_tailieu = Int32.Parse(input_1);

            if (txtMaDeCuongMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaDeCuongMonHoc.Focus();
                return;
            }
            else if (txtTenDeCuongMonHoc.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDeCuongMonHoc.Focus();
                return;
            }
            else if (txtNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDung.Focus();
                return;
            }           
            else if (txtMaDeCuongMonHoc.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.DeCuongMonHoc DCuongMHoc WHERE DCuongMHoc.MaDeCuongMonHoc = N'{0}'", madecuongmonhoc);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã đề cương môn học đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaDeCuongMonHoc.Focus();
                    return;
                }
            }
            else if (MessageBox.Show("Bạn có muốn thêm đề cương môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (DeCuongMonHocBUS.Instance.InsertDeCuongMonHoc(id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, noidung, ghichu))
                {
                    MessageBox.Show("Thêm đề cương môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertDeCuongMonHoc != null)
                    {
                        insertDeCuongMonHoc(this, new EventArgs());
                    }
                    DeCuongMonHocBinding();
                    LoadListDeCuongMonHoc();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm đề cương môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaDeCuongMonHoc.Text = "";
            txtTenDeCuongMonHoc.Text = "";            
            txtNoiDung.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateDeCuongMonHoc;
        public event EventHandler UpdateDeCuongMonHoc
        {
            add { updateDeCuongMonHoc += value; }
            remove { updateDeCuongMonHoc -= value; }
        }


        private event EventHandler deleteDeCuongMonHoc;
        public event EventHandler DeleteDeCuongMonHoc
        {
            add { deleteDeCuongMonHoc += value; }
            remove { deleteDeCuongMonHoc -= value; }
        }

        private void dgvDeCuongMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDeCuongMonHoc.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvDeCuongMonHoc.CurrentRow.Selected = true;
                    string input = dgvDeCuongMonHoc.Rows[e.RowIndex].Cells["ID_DeCuongMonHoc"].FormattedValue.ToString();
                    int id_decuongmonhoc = Int32.Parse(input);
                    string input_1 = cbxMonHoc.GetItemText(cbxMonHoc.SelectedValue);
                    int id_monhoc = Int32.Parse(input_1);
                    string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
                    int id_tailieu = Int32.Parse(input_2);
                    if (MessageBox.Show("Bạn có muốn sửa đề cương môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string madecuongmonhoc = txtMaDeCuongMonHoc.Text;
                        string tendecuongmonhoc = txtTenDeCuongMonHoc.Text;
                        string noidung = txtNoiDung.Text;
                        string ghichu = txtGhiChu.Text;

                        if (txtMaDeCuongMonHoc.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaDeCuongMonHoc.Focus();
                            return;
                        }
                        else if (txtTenDeCuongMonHoc.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên đề cương môn học !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenDeCuongMonHoc.Focus();
                            return;
                        }
                        else if (txtNoiDung.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNoiDung.Focus();
                            return;
                        }
                        else
                        {
                            if (DeCuongMonHocBUS.Instance.UpdateDeCuongMonHoc(id_decuongmonhoc, id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, noidung, ghichu))
                            {
                                MessageBox.Show("Sửa đề cương môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateDeCuongMonHoc != null)
                                {
                                    updateDeCuongMonHoc(this, new EventArgs());
                                }
                                DeCuongMonHocBinding();
                                LoadListDeCuongMonHoc();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa đề cương môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa đề cương môn học này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (DeCuongMonHocBUS.Instance.DeleteDeCuongMonHoc(id_decuongmonhoc))
                        {
                            MessageBox.Show("Xóa đề cương môn học thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteDeCuongMonHoc != null)
                            {
                                deleteDeCuongMonHoc(this, new EventArgs());
                            }
                            DeCuongMonHocBinding();
                            LoadListDeCuongMonHoc();
                        }
                        else
                        {
                            MessageBox.Show("Xóa đề cương môn học thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
