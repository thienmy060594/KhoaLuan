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
    public partial class FormBaoCaoKiemDinhChatLuong : Form
    {
        BindingSource BaoCaoKiemDinhChatLuongList = new BindingSource();
        public FormBaoCaoKiemDinhChatLuong()
        {
            InitializeComponent();
            dgvBaoCaoKiemDinhChatLuong.DataSource = BaoCaoKiemDinhChatLuongList;
            LoadListBaoCaoKiemDinhChatLuong();
            btnXuatRaFileWord.Enabled = false;
            btnXemFileWord.Enabled = false;
            btnXemFilePDF.Enabled = false;
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dgvBaoCaoKiemDinhChatLuong[column, row];
            DataGridViewCell cell2 = dgvBaoCaoKiemDinhChatLuong[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }

        private void dgvBaoCaoKiemDinhChatLuong_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dgvBaoCaoKiemDinhChatLuong.AdvancedCellBorderStyle.Top;
            }
        }

        private void dgvBaoCaoKiemDinhChatLuong_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }

        private void LoadListBaoCaoKiemDinhChatLuong()
        {
            dgvBaoCaoKiemDinhChatLuong.DataSource = BaoCaoKiemDinhChatLuongBUS.Instance.GetListBaoCaoKiemDinhChatLuong();
            dgvBaoCaoKiemDinhChatLuong.Columns[0].Visible = false;
            dgvBaoCaoKiemDinhChatLuong.Columns[1].Visible = false;
            dgvBaoCaoKiemDinhChatLuong.Columns[2].Visible = false;
            dgvBaoCaoKiemDinhChatLuong.Columns[3].Visible = false;
            dgvBaoCaoKiemDinhChatLuong.Columns[4].Visible = false;
            dgvBaoCaoKiemDinhChatLuong.Columns[5].HeaderText = "Tiêu Chuẩn";
            dgvBaoCaoKiemDinhChatLuong.Columns[6].HeaderText = "Tiêu Chí";
            dgvBaoCaoKiemDinhChatLuong.Columns[7].HeaderText = "Yêu Cầu";
            dgvBaoCaoKiemDinhChatLuong.Columns[8].HeaderText = "Mốc Tham Chiếu";
            dgvBaoCaoKiemDinhChatLuong.Columns[9].HeaderText = "Nguồn Minh Chứng";            
            // Tự động chỉnh lại kích thước cột         
            dgvBaoCaoKiemDinhChatLuong.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBaoCaoKiemDinhChatLuong.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBaoCaoKiemDinhChatLuong.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBaoCaoKiemDinhChatLuong.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvBaoCaoKiemDinhChatLuong.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //Không cho người dùng thêm dữ liệu trực tiếp
            dgvBaoCaoKiemDinhChatLuong.AllowUserToAddRows = false;
            dgvBaoCaoKiemDinhChatLuong.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp  
            dgvBaoCaoKiemDinhChatLuong.AutoGenerateColumns = false;         
        }         

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            btnXuatRaFileWord.Enabled = true;
            btnXemFileWord.Enabled = true;
            btnXemFilePDF.Enabled = true;
        }

        private void btnXuatRaFileWord_Click(object sender, EventArgs e)
        {

        }

        private void btnXemFileWord_Click(object sender, EventArgs e)
        {

        }

        private void btnXemFilePDF_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
