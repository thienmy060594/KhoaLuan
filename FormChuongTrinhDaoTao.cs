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
    public partial class FormChuongTrinhDaoTao : Form
    {
        BindingSource ChuongTrinhDaoTaoList = new BindingSource();
        public FormChuongTrinhDaoTao()
        {
            InitializeComponent();
            dgvChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoList;
            LoadListChuongTrinhDaoTao();
            txtMaChuongTrinhDaoTao.Enabled = false;
            txtNamKy.Enabled = false;
            txtNamApDung.Enabled = false;
            txtTomTatNoiDung.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;
        }

        private void LoadListChuongTrinhDaoTao()
        {
            dgvChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            dgvChuongTrinhDaoTao.Columns[0].Visible = false;
            dgvChuongTrinhDaoTao.Columns[1].Visible = false;
            dgvChuongTrinhDaoTao.Columns[2].Visible = false;
            dgvChuongTrinhDaoTao.Columns[3].HeaderText = "Mã Ngành";
            dgvChuongTrinhDaoTao.Columns[4].HeaderText = "Tên Tên Ngành";
            dgvChuongTrinhDaoTao.Columns[5].HeaderText = "Mã Tài Liệu";
            dgvChuongTrinhDaoTao.Columns[6].HeaderText = "Tên Tài Liệu";
            dgvChuongTrinhDaoTao.Columns[7].HeaderText = "Mã Chương Trình Đào Tạo";
            dgvChuongTrinhDaoTao.Columns[8].HeaderText = "Năm Ký";
            dgvChuongTrinhDaoTao.Columns[9].HeaderText = "Năm Áp Dụng";
            dgvChuongTrinhDaoTao.Columns[10].HeaderText = "Tóm Tắt Nội Dung";
            dgvChuongTrinhDaoTao.Columns[11].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột           
            dgvChuongTrinhDaoTao.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvChuongTrinhDaoTao.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvChuongTrinhDaoTao.AllowUserToAddRows = false;
            dgvChuongTrinhDaoTao.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  

            DataGridViewButtonColumn btnSua = new DataGridViewButtonColumn();// Nút sửa
            btnSua.HeaderText = "Nút Sửa";
            btnSua.Name = "btnSua";
            btnSua.Text = "Sửa";
            btnSua.UseColumnTextForButtonValue = true;
            dgvChuongTrinhDaoTao.Columns.Add(btnSua);

            DataGridViewButtonColumn btnXoa = new DataGridViewButtonColumn();// Nút xóa
            btnXoa.HeaderText = "Nút Xóa";
            btnXoa.Name = "btnXoa";
            btnXoa.Text = "Xóa";
            btnXoa.UseColumnTextForButtonValue = true;
            dgvChuongTrinhDaoTao.Columns.Add(btnXoa);
        }

        void ChuongTrinhDaoTaoBinding()
        {
            txtMaChuongTrinhDaoTao.DataBindings.Clear();
            txtNamKy.DataBindings.Clear();
            txtNamApDung.DataBindings.Clear();
            txtTomTatNoiDung.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaChuongTrinhDaoTao.Text = "";
            txtNamKy.Text = "";
            txtNamApDung.Text = "";
            txtTomTatNoiDung.Text = "";
            txtGhiChu.Text = "";
            txtMaChuongTrinhDaoTao.Enabled = true;
            txtNamKy.Enabled = true;
            txtNamApDung.Enabled = true;
            txtTomTatNoiDung.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxNganh.DataSource = NganhBUS.Instance.GetListNganh();
            cbxNganh.ValueMember = "ID_Nganh";
            cbxNganh.DisplayMember = "TenNganh";
            cbxMinhChung.DataSource = MinhChungBUS.Instance.GetListMinhChung();
            cbxMinhChung.ValueMember = "ID_TaiLieu";
            cbxMinhChung.DisplayMember = "TenTaiLieu";
        }

        private event EventHandler insertChuongTrinhDaoTao;
        public event EventHandler InsertChuongTrinhDaoTao
        {
            add { insertChuongTrinhDaoTao += value; }
            remove { insertChuongTrinhDaoTao -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string machuongtrinhdaotao = txtMaChuongTrinhDaoTao.Text;
            string namky = txtNamKy.Text;
            string namapdung = txtNamApDung.Text;
            string tomtatnoidung = txtTomTatNoiDung.Text;
            string ghichu = txtGhiChu.Text;
            string input = cbxNganh.GetItemText(cbxNganh.SelectedValue);
            int id_nganh = Int32.Parse(input);
            string input_1 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
            int id_tailieu = Int32.Parse(input_1);

            if (txtMaChuongTrinhDaoTao.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaChuongTrinhDaoTao.Focus();
                return;
            }
            else if (txtNamKy.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamKy.Focus();
                return;
            }
            else if (txtNamApDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập năm áp dụng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamApDung.Focus();
                return;
            }
            else if (txtTomTatNoiDung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTomTatNoiDung.Focus();
                return;
            }
            else if (txtMaChuongTrinhDaoTao.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.ChuongTrinhDaoTao CTDTao WHERE CTDTao.MaChuongTrinhDaoTao = N'{0}'", machuongtrinhdaotao);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã chương trình đào tạo đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaChuongTrinhDaoTao.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm chương trình đào tạo này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ChuongTrinhDaoTaoBUS.Instance.InsertChuongTrinhDaoTao(id_nganh, id_tailieu, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu))
                {
                    MessageBox.Show("Thêm chương trình đào tạo thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertChuongTrinhDaoTao != null)
                    {
                        insertChuongTrinhDaoTao(this, new EventArgs());
                    }
                    ChuongTrinhDaoTaoBinding();
                    LoadListChuongTrinhDaoTao();
                    ResetGiaTri();
                    btnDong.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Thêm chương trình đào tạo thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaChuongTrinhDaoTao.Text = "";
            txtNamKy.Text = "";
            txtNamApDung.Text = "";
            txtTomTatNoiDung.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateChuongTrinhDaoTao;
        public event EventHandler UpdateChuongTrinhDaoTao
        {
            add { updateChuongTrinhDaoTao += value; }
            remove { updateChuongTrinhDaoTao -= value; }
        }


        private event EventHandler deleteChuongTrinhDaoTao;
        public event EventHandler DeleteChuongTrinhDaoTao
        {
            add { deleteChuongTrinhDaoTao += value; }
            remove { deleteChuongTrinhDaoTao -= value; }
        }

        private void dgvChuongTrinhDaoTao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvChuongTrinhDaoTao.Columns[e.ColumnIndex].Name == "btnSua")
                {
                    dgvChuongTrinhDaoTao.CurrentRow.Selected = true;
                    string input = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells["ID_ChuongTrinhDaoTao"].FormattedValue.ToString();
                    int id_chuongtrinhdaotao = Int32.Parse(input);
                    string input_1 = cbxNganh.GetItemText(cbxNganh.SelectedValue);
                    int id_nganh = Int32.Parse(input_1);
                    string input_2 = cbxMinhChung.GetItemText(cbxMinhChung.SelectedValue);
                    int id_tailieu = Int32.Parse(input_2);

                    if (MessageBox.Show("Bạn có muốn sửa chương trình đào tạo này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string machuongtrinhdaotao = txtMaChuongTrinhDaoTao.Text;
                        string namky = txtNamKy.Text;
                        string namapdung = txtNamApDung.Text;
                        string tomtatnoidung = txtTomTatNoiDung.Text;
                        string ghichu = txtGhiChu.Text;

                        if (txtMaChuongTrinhDaoTao.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã chương trình đào tạo !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaChuongTrinhDaoTao.Focus();
                            return;
                        }
                        else if (txtNamKy.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập năm ký !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNamKy.Focus();
                            return;
                        }
                        else if (txtNamApDung.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập năm áp dụng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNamApDung.Focus();
                            return;
                        }
                        else if (txtTomTatNoiDung.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tóm tắt nội dung !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTomTatNoiDung.Focus();
                            return;
                        }
                        else
                        {
                            if (ChuongTrinhDaoTaoBUS.Instance.UpdateChuongTrinhDaoTao(id_chuongtrinhdaotao, id_nganh, id_tailieu, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu))
                            {
                                MessageBox.Show("Sửa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateChuongTrinhDaoTao != null)
                                {
                                    updateChuongTrinhDaoTao(this, new EventArgs());
                                }
                                ChuongTrinhDaoTaoBinding();
                                LoadListChuongTrinhDaoTao();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa chương trình đào tạo thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }                    
                }
                if(dgvChuongTrinhDaoTao.Columns[e.ColumnIndex].Name == "btnXoa")
                {
                    string input = dgvChuongTrinhDaoTao.Rows[e.RowIndex].Cells["ID_ChuongTrinhDaoTao"].FormattedValue.ToString();
                    int id_chuongtrinhdaotao = Int32.Parse(input);

                    if (MessageBox.Show("Bạn có muốn xóa chương trình đào tạo này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (ChuongTrinhDaoTaoBUS.Instance.DeleteChuongTrinhDaoTao(id_chuongtrinhdaotao))
                        {
                            MessageBox.Show("Xóa tiêu chí thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteChuongTrinhDaoTao != null)
                            {
                                deleteChuongTrinhDaoTao(this, new EventArgs());
                            }
                            ChuongTrinhDaoTaoBinding();
                            LoadListChuongTrinhDaoTao();
                        }
                        else
                        {
                            MessageBox.Show("Xóa chương trình đào tạo thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
