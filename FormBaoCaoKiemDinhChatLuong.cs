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

namespace KiemDinhChatLuongGUI
{
    public partial class FormBaoCaoKiemDinhChatLuong : Form
    {
        public FormBaoCaoKiemDinhChatLuong()
        {
            InitializeComponent();
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxTieuChuan.DataSource = TieuChuanBUS.Instance.GetListTieuChuan();
            cbxTieuChuan.ValueMember = "TenTieuChuan";
            cbxTieuChuan.DisplayMember = "TenTieuChuan";
        }

        private void FormBaoCaoKiemDinhChatLuong_Load(object sender, EventArgs e)
        {                       

        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            string tentieuchuan = cbxTieuChuan.GetItemText(cbxTieuChuan.SelectedValue);
            this.BaoCaoKiemDinhChatLuongTableAdapter.Fill(this.DataSetBaoCaoKiemDinhChatLuong.BaoCaoKiemDinhChatLuong, tentieuchuan);
            this.rvKiemDinhChatLuong.RefreshReport();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
