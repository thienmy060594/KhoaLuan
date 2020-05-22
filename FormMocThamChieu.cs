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

namespace KiemDinhChatLuongGUI
{
    public partial class FormMocThamChieu : Form
    {
        BindingSource MocThamChieuList = new BindingSource();
        public FormMocThamChieu()
        {
            InitializeComponent();
            dgvMocThamChieu.DataSource = MocThamChieuList;
            LoadListMocThamChieu();            
            btnLuuLai.Enabled = false;
            txtMaMocThamChieu.Enabled = false;
            txtNoiDungMocThamChieu.Enabled = false;
            txtTenMocThamChieu.Enabled = false;
            txtGhiChu.Enabled = false;
        }

        private void LoadListMocThamChieu()
        {
            dgvMocThamChieu.DataSource = MocThamChieuBUS.Instance.GetListMocThamChieu();
            dgvMocThamChieu.Columns[0].Visible = false;
            dgvMocThamChieu.Columns[1].HeaderText = "Mã Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[2].HeaderText = "Tên Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[3].HeaderText = "Nội Dung Mốc Tham Chiếu";
            dgvMocThamChieu.Columns[4].HeaderText = "Ghi Chú";
            // Tự động chỉnh lại kích thước cột
            dgvMocThamChieu.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMocThamChieu.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvMocThamChieu.AllowUserToAddRows = false;
            dgvMocThamChieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp            
        }

        void MocThamChieuBinding()
        {
            txtMaMocThamChieu.DataBindings.Clear();
            txtNoiDungMocThamChieu.DataBindings.Clear();
            txtTenMocThamChieu.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            txtMaMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtNoiDungMocThamChieu.Text = "";            
            txtGhiChu.Text = "";
            txtMaMocThamChieu.Enabled = true;            
            txtTenMocThamChieu.Enabled = true;
            txtNoiDungMocThamChieu.Enabled = true;
            txtGhiChu.Enabled = true;
            btnLuuLai.Enabled = true;            
        }

        private event EventHandler insertMocThamChieu;
        public event EventHandler InsertMocThamChieu
        {
            add { insertMocThamChieu += value; }
            remove { insertMocThamChieu -= value; }
        }

        private void btnLuuLai_Click(object sender, EventArgs e)
        {
            string mamocthamchieu = txtMaMocThamChieu.Text;
            string tenmocthamchieu = txtTenMocThamChieu.Text;
            string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
            string ghichu = txtGhiChu.Text;

            if (txtMaMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaMocThamChieu.Focus();
            }
            else if (txtTenMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMocThamChieu.Focus();
            }
            else if (txtNoiDungMocThamChieu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiDungMocThamChieu.Focus();
            }
            else if (MessageBox.Show("Bạn có muốn thêm mới mốc tham chiếu này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (MocThamChieuBUS.Instance.InsertMocThamChieu(mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                {
                    MessageBox.Show("Thêm mốc tham chiếu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (insertMocThamChieu != null)
                    {
                        insertMocThamChieu(this, new EventArgs());
                    }                    
                    MocThamChieuBinding();
                    LoadListMocThamChieu();
                    ResetGiaTri();
                    btnDong.Enabled = true;                    
                }
                else
                {
                    MessageBox.Show("Thêm mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ResetGiaTri()
        {
            txtMaMocThamChieu.Text = "";
            txtNoiDungMocThamChieu.Text = "";
            txtTenMocThamChieu.Text = "";
            txtGhiChu.Text = "";
        }

        private event EventHandler updateMocThamChieu;
        public event EventHandler UpdateMocThamChieu
        {
            add { updateMocThamChieu += value; }
            remove { updateMocThamChieu -= value; }
        }

        private event EventHandler deleteMocThamChieu;
        public event EventHandler DeleteMocThamChieu
        {
            add { deleteMocThamChieu += value; }
            remove { deleteMocThamChieu -= value; }
        }

        private void dgvMocThamChieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMocThamChieu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvMocThamChieu.CurrentRow.Selected = true;
                    string input = dgvMocThamChieu.Rows[e.RowIndex].Cells["ID_MocThamChieu"].FormattedValue.ToString();
                    int id_mocthamchieu = Int32.Parse(input);                   
                    if (MessageBox.Show("Bạn có muốn sửa mốc tham chiếu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string mamocthamchieu = txtMaMocThamChieu.Text;
                        string tenmocthamchieu = txtTenMocThamChieu.Text;
                        string noidungmocthamchieu = txtNoiDungMocThamChieu.Text;
                        string ghichu = txtGhiChu.Text;

                        if (txtMaMocThamChieu.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập mã mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtMaMocThamChieu.Focus();
                            return;
                        }
                        else if (txtTenMocThamChieu.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập tên mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenMocThamChieu.Focus();
                            return;
                        }
                        else if (txtNoiDungMocThamChieu.Text == "")
                        {
                            MessageBox.Show("Bạn chưa nhập nội dung mốc tham chiếu  !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtTenMocThamChieu.Focus();
                            return;
                        }
                        else
                        {
                            if (MocThamChieuBUS.Instance.UpdateMocThamChieu(id_mocthamchieu, mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu))
                            {
                                MessageBox.Show("Sửa mốc tham chiếu  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (updateMocThamChieu != null)
                                {
                                    updateMocThamChieu(this, new EventArgs());
                                }
                                MocThamChieuBinding();
                                LoadListMocThamChieu();
                                ResetGiaTri();
                            }
                            else
                            {
                                MessageBox.Show("Sửa mốc tham chiếu  thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                    else if (MessageBox.Show("Bạn có muốn xóa mốc tham chiếu  này ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (MocThamChieuBUS.Instance.DeleteMocThamChieu(id_mocthamchieu))
                        {
                            MessageBox.Show("Xóa mốc tham chiếu  thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (deleteMocThamChieu != null)
                            {
                                deleteMocThamChieu(this, new EventArgs());
                            }
                            MocThamChieuBinding();
                            LoadListMocThamChieu();
                        }
                        else
                        {
                            MessageBox.Show("Xóa mốc tham chiếu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

