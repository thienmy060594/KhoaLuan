using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiemDinhChatLuongBUS;
using KiemDinhChatLuongDAL;
using KiemDinhChatLuongDTO;
using Microsoft.VisualBasic;

namespace KiemDinhChatLuongGUI
{
    public partial class FormNguonMinhChung : Form
    {
        BindingSource NguonMinhChungList = new BindingSource();
        public FormNguonMinhChung()
        {
            InitializeComponent();
            dgvNguonMinhChung.DataSource = NguonMinhChungList;
            LoadListNguonMinhChung();            
            txtMaNguonMinhChung.Enabled = false;
            txtTenNguonMinhChung.Enabled = false;
            txtNoiDungNguonMinhChung.Enabled = false;
            txtGhiChu.Enabled = false;
            btnLuuLai.Enabled = false;           
        }
        private void LoadListNguonMinhChung()
        {
            dgvNguonMinhChung.DataSource = NguonMinhChungBUS.Instance.GetListNguonMinhChung();
            dgvNguonMinhChung.Columns[0].Visible = false;
            dgvNguonMinhChung.Columns[1].HeaderText = "Mã Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[2].HeaderText = "Tên Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[3].HeaderText = "Nội Dung Nguồn Minh Chứng";
            dgvNguonMinhChung.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvNguonMinhChung.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvNguonMinhChung.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvNguonMinhChung.AllowUserToAddRows = false;
            dgvNguonMinhChung.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void NguonMinhChungBinding()
        {
            txtMaNguonMinhChung.DataBindings.Clear();
            txtTenNguonMinhChung.DataBindings.Clear();
            txtNoiDungNguonMinhChung.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaNguonMinhChung.Text = "";
            txtTenNguonMinhChung.Text = "";
            txtNoiDungNguonMinhChung.Text = "";
            txtGhiChu.Text = "";
            txtMaNguonMinhChung.Enabled = true;
            txtTenNguonMinhChung.Enabled = true;
            txtNoiDungNguonMinhChung.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;
        }

        private event EventHandler insertNguonMinhChung;
        public event EventHandler InsertNguonMinhChung
        {
            add { insertNguonMinhChung += value; }
            remove { insertNguonMinhChung -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string manguonminhchung = txtMaNguonMinhChung.Text;
            string tennguonminhchung = txtTenNguonMinhChung.Text;
            string noidungnguonminhchung = txtNoiDungNguonMinhChung.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNguonMinhChung.Focus();
                return;
            }
            else if (txtTenNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNguonMinhChung.Focus();
                return;
            }
            else if (txtNoiDungNguonMinhChung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungNguonMinhChung.Focus();
                return;
            }
            else if (txtMaNguonMinhChung.Text != "")
            {
                string sql = string.Format("SELECT * FROM dbo.NguonMinhChung NMChung WHERE NMChung.MaNguonMinhChung = N'{0}'", manguonminhchung);
                if (KiemDinhChatLuongDAL.DataBaseConnection.CheckKey(sql))
                {
                    MessageBox.Show("Mã nguồn minh chứng đã tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaNguonMinhChung.Focus();
                    return;
                }
            }
            if (MessageBox.Show("Bạn có muốn thêm nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (NguonMinhChungBUS.Instance.InsertNguonMinhChung(manguonminhchung ,tennguonminhchung, noidungnguonminhchung, ghichu))
                {
                    MessageBox.Show("Thêm nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertNguonMinhChung != null)
                    {
                        insertNguonMinhChung(this, new EventArgs());
                    }                   
                    NguonMinhChungBinding();
                    LoadListNguonMinhChung();
                    ResetGiaTri();
                    btnDong.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("Thêm nguồn minh chứng mới thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaNguonMinhChung.Text = "";
            txtTenNguonMinhChung.Text = "";
            txtNoiDungNguonMinhChung.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateNguonMinhChung;
        public event EventHandler UpdateNguonMinhChung
        {
            add { updateNguonMinhChung += value; }
            remove { updateNguonMinhChung -= value; }
        }
        
        private event EventHandler deleteNguonMinhChung;
        public event EventHandler DeleteNguonMinhChung
        {
            add { deleteNguonMinhChung += value; }
            remove { deleteNguonMinhChung -= value; }
        }
        
        private void dgvNguonMinhChung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNguonMinhChung.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvNguonMinhChung.CurrentRow.Selected = true;
                    string input = dgvNguonMinhChung.Rows[e.RowIndex].Cells["ID_NguonMinhChung"].FormattedValue.ToString();
                    int id_nguonminhchung = Int32.Parse(input);                 
                    
                    if (MessageBox.Show("Bạn có muốn sửa nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string manguonminhchung = txtMaNguonMinhChung.Text;
                        string tennguonminhchung = txtTenNguonMinhChung.Text;
                        string noidungnguonminhchung = txtNoiDungNguonMinhChung.Text;
                        string ghichu = txtGhiChu.Text;

                        if (txtMaNguonMinhChung.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaNguonMinhChung.Focus();
                            return;
                        }
                        else if (txtTenNguonMinhChung.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenNguonMinhChung.Focus();
                            return;
                        }
                        else if (txtNoiDungNguonMinhChung.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập nội dung nguồn minh chứng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNoiDungNguonMinhChung.Focus();
                            return;
                        }
                        else
                        {
                            if (NguonMinhChungBUS.Instance.UpdateNguonMinhChung(id_nguonminhchung, manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu))
                            {
                                MessageBox.Show("Sửa nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateNguonMinhChung != null)
                                {
                                    updateNguonMinhChung(this, new EventArgs());
                                }
                                NguonMinhChungBinding();
                                LoadListNguonMinhChung();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa nguồn minh chứng này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (NguonMinhChungBUS.Instance.DeleteNguonMinhChung(id_nguonminhchung))
                        {
                            MessageBox.Show("Xóa nguồn minh chứng thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteNguonMinhChung != null)
                            {
                                deleteNguonMinhChung(this, new EventArgs());
                            }
                            NguonMinhChungBinding();
                            LoadListNguonMinhChung();
                        }
                        else
                        {
                            MessageBox.Show("Xóa nguồn minh chứng thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
