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
    public partial class FormNhomTuChon : Form
    {
        BindingSource NhomTuChonList = new BindingSource();
        public FormNhomTuChon()
        {
            InitializeComponent();
            dgvNhomTuChon.DataSource = NhomTuChonList;
            LoadListNhomTuChon();
            txtMaNhomTuChon.Enabled = false;
            txtTenNhomTuChon.Enabled = false;
            txtSoTinChi.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListNhomTuChon()
        {
            dgvNhomTuChon.DataSource = NhomTuChonBUS.Instance.GetListNhomTuChon();
            dgvNhomTuChon.Columns[0].Visible = false;
            dgvNhomTuChon.Columns[1].Visible = false;
            dgvNhomTuChon.Columns[2].HeaderText = "Mã Chương Trình Đào Tạo";            
            dgvNhomTuChon.Columns[3].HeaderText = "Mã Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[4].HeaderText = "Tên Nhóm Tự Chọn";
            dgvNhomTuChon.Columns[5].HeaderText = "Số Tín Chỉ";
            dgvNhomTuChon.Columns[6].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột     
            dgvNhomTuChon.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNhomTuChon.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;            
            dgvNhomTuChon.AllowUserToAddRows = false;//Không cho người dùng thêm dữ liệu trực tiếp
            dgvNhomTuChon.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void NhomTuChonBinding()
        {
            txtMaNhomTuChon.DataBindings.Clear();
            txtTenNhomTuChon.DataBindings.Clear();
            txtSoTinChi.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaNhomTuChon.Text = "";
            txtTenNhomTuChon.Text = "";
            txtSoTinChi.Text = "";
            txtGhiChu.Text = "";
            txtMaNhomTuChon.Enabled = true;
            txtTenNhomTuChon.Enabled = true;
            txtSoTinChi.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "ID_ChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "TenChuongTrinhDaoTao";
        }

        private event EventHandler insertNhomTuChon;
        public event EventHandler InsertNhomTuChon
        {
            add { insertNhomTuChon += value; }
            remove { insertNhomTuChon -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string manhomtuchon = txtMaNhomTuChon.Text;
            string tennhomtuchon = txtTenNhomTuChon.Text;
            int sotinchi = Int32.Parse(txtSoTinChi.Text);
            string ghichu = txtGhiChu.Text;
            string input = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
            int id_chuongtrinhdaotao = Int32.Parse(input);

            if (txtMaNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNhomTuChon.Focus();
                return;
            }
            else if (txtTenNhomTuChon.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhomTuChon.Focus();
                return;
            }
            else if (txtMaNhomTuChon.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.NhomTuChon NTChon WHERE NTChon.MaNhomTuChon = N'{0}'", manhomtuchon);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã nhóm tự chọn đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNhomTuChon.Focus();
                    return;
                }
            }
            else if (MessageBox.Show("Bạn có muốn thêm nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NhomTuChonBUS.Instance.InsertNhomTuChon(id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu))
                {
                    MessageBox.Show("Thêm nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNhomTuChon != null)
                    {
                        insertNhomTuChon(this, new EventArgs());
                    }
                    NhomTuChonBinding();
                    LoadListNhomTuChon();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaNhomTuChon.Text = "";
            txtTenNhomTuChon.Text = "";
            txtSoTinChi.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNhomTuChon;
        public event EventHandler UpdateNhomTuChon
        {
            add { updateNhomTuChon += value; }
            remove { updateNhomTuChon -= value; }
        }


        private event EventHandler deleteNhomTuChon;
        public event EventHandler DeleteNhomTuChon
        {
            add { deleteNhomTuChon += value; }
            remove { deleteNhomTuChon -= value; }
        }

        private void dgvNhomTuChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNhomTuChon.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvNhomTuChon.CurrentRow.Selected = true;
                    string input = dgvNhomTuChon.Rows[e.RowIndex].Cells["ID_NhomTuChon"].FormattedValue.ToString();
                    int id_nhomtuchon = Int32.Parse(input);
                    string input_1 = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
                    int id_chuongtrinhdaotao = Int32.Parse(input_1);
                    if (MessageBox.Show("Bạn có muốn sửa nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string manhomtuchon = txtMaNhomTuChon.Text;
                        string tennhomtuchon = txtTenNhomTuChon.Text;
                        int sotinchi = Int32.Parse(txtSoTinChi.Text);
                        string ghichu = txtGhiChu.Text;

                        if (txtMaNhomTuChon.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaNhomTuChon.Focus();
                            return;
                        }
                        else if (txtTenNhomTuChon.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên nhóm tự chọn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenNhomTuChon.Focus();
                            return;
                        }
                        else if (txtSoTinChi.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập số tín chỉ !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSoTinChi.Focus();
                            return;
                        }
                        else
                        {
                            if (NhomTuChonBUS.Instance.UpdateNhomTuChon( id_nhomtuchon, id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu))
                            {
                                MessageBox.Show("Sửa nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateNhomTuChon != null)
                                {
                                    updateNhomTuChon(this, new EventArgs());
                                }
                                NhomTuChonBinding();
                                LoadListNhomTuChon();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa nhóm tự chọn này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NhomTuChonBUS.Instance.DeleteNhomTuChon(id_nhomtuchon))
                        {
                            MessageBox.Show("Xóa nhóm tự chọn thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteNhomTuChon != null)
                            {
                                deleteNhomTuChon(this, new EventArgs());
                            }
                            NhomTuChonBinding();
                            LoadListNhomTuChon();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nhóm tự chọn thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
