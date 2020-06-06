using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KiemDinhChatLuongGUI
{
    public partial class FormBaoCaoChuongTrinhDaoTao : Form
    {
        public FormBaoCaoChuongTrinhDaoTao()
        {
            InitializeComponent();
        }

        private void FormBaoCaoChuongTrinhDaoTao_Load(object sender, EventArgs e)
        {
      
            // TODO: This line of code loads data into the 'QuanLyTieuChuanDanhGiaDataSet.KiemDinhChatLuong' table. You can move, or remove it, as needed.
            this.KiemDinhChatLuongTableAdapter.Fill(this.QuanLyTieuChuanDanhGiaDataSet.KiemDinhChatLuong);           
            this.rvChuongTrinhDaoTao.RefreshReport();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
