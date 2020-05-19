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
    public partial class FormChinh : Form
    {
        public FormChinh()
        {
            InitializeComponent();
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {

        }

        private void mnuTieuChuan_Click(object sender, EventArgs e)
        {
            FormTieuChuan FrTieuChuan = new FormTieuChuan(); //Khởi tạo đối tượng
            this.Hide();
            FrTieuChuan.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuTieuChi_Click(object sender, EventArgs e)
        {
            FormTieuChi FrTieuChi = new FormTieuChi(); //Khởi tạo đối tượng
            this.Hide();
            FrTieuChi.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuYeuCau_Click(object sender, EventArgs e)
        {
            FormYeuCau FrYeuCau = new FormYeuCau(); //Khởi tạo đối tượng
            this.Hide();
            FrYeuCau.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMocThamChieu_Click(object sender, EventArgs e)
        {
            FormMocThamChieu FrMocThamChieu = new FormMocThamChieu(); //Khởi tạo đối tượng
            this.Hide();
            FrMocThamChieu.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuGoiY_Click(object sender, EventArgs e)
        {
            FormNguonMinhChung FrNguonMinhChung = new FormNguonMinhChung(); //Khởi tạo đối tượng
            this.Hide();
            FrNguonMinhChung.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMinhChung_Click(object sender, EventArgs e)
        {
            FormMinhChung FrMinhChung = new FormMinhChung(); //Khởi tạo đối tượng
            this.Hide();
            FrMinhChung.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuLoaiMinhChung_Click(object sender, EventArgs e)
        {
            FormLoaiTaiLieu FrLoaiTaiLieu = new FormLoaiTaiLieu(); //Khởi tạo đối tượng
            this.Hide();
            FrLoaiTaiLieu.ShowDialog(); //Hiển thị
            this.Show();
        }
    }
}
