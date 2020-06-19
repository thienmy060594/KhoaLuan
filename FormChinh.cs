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

        private void mnuTieuChuanTieuChi_Click(object sender, EventArgs e)
        {
            FormTieuChuan_TieuChi FrTieuChuanTieuChi = new FormTieuChuan_TieuChi(); //Khởi tạo đối tượng
            this.Hide();
            FrTieuChuanTieuChi.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuYeuCauCuaTieuChi_Click(object sender, EventArgs e)
        {
            FormYeuCauTieuChi FrYeuCauTieuChi = new FormYeuCauTieuChi(); //Khởi tạo đối tượng
            this.Hide();
            FrYeuCauTieuChi.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMocChuanThamChieu_Click(object sender, EventArgs e)
        {
            FormMocThamChieuYeuCau FrMocThamChieuYeuCau = new FormMocThamChieuYeuCau(); //Khởi tạo đối tượng
            this.Hide();
            FrMocThamChieuYeuCau.ShowDialog(); //Hiển thị
            this.Show();
        }        

        private void mnuGoiY_Click(object sender, EventArgs e)
        {
            FormNguonMinhChungTieuChi FrNguonMinhChungTieuChi = new FormNguonMinhChungTieuChi(); //Khởi tạo đối tượng
            this.Hide();
            FrNguonMinhChungTieuChi.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMinhChung_Click(object sender, EventArgs e)
        {
            FormMinhChungTaiLieu FrMinhChungNguonMinhChung = new FormMinhChungTaiLieu(); //Khởi tạo đối tượng
            this.Hide();
            FrMinhChungNguonMinhChung.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuLoaiMinhChung_Click(object sender, EventArgs e)
        {
            FormLoaiTaiLieuNguonMinhChung FrLoaiTaiLieuNguonMinhChung = new FormLoaiTaiLieuNguonMinhChung(); //Khởi tạo đối tượng
            this.Hide();
            FrLoaiTaiLieuNguonMinhChung.ShowDialog(); //Hiển thị
            this.Show();
        }                     

        private void mnuChuongTrinhDaoTao_Click(object sender, EventArgs e)
        {
            FormChuongTrinhDaoTao FrChuongTrinhDaoTao = new FormChuongTrinhDaoTao(); //Khởi tạo đối tượng
            this.Hide();
            FrChuongTrinhDaoTao.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMonHoc_Click(object sender, EventArgs e)
        {
            FormMonHoc FrMonHoc = new FormMonHoc(); //Khởi tạo đối tượng
            this.Hide();
            FrMonHoc.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuNhomTuChon_Click(object sender, EventArgs e)
        {
            FormNhomTuChon FrNhomTuChon = new FormNhomTuChon(); //Khởi tạo đối tượng
            this.Hide();
            FrNhomTuChon.ShowDialog(); //Hiển thị
            this.Show();
        }        

        private void mnuDeCuongMonHoc_Click(object sender, EventArgs e)
        {
            FormDeCuongMonHoc FrDeCuongMonHoc = new FormDeCuongMonHoc(); //Khởi tạo đối tượng
            this.Hide();
            FrDeCuongMonHoc.ShowDialog(); //Hiển thị
            this.Show();
        }              

        private void mnuBaoCaoKiemDinhChatLuong_Click(object sender, EventArgs e)
        {
            FormBaoCaoKiemDinhChatLuong FrBaoCaoKiemDinhChatLuong = new FormBaoCaoKiemDinhChatLuong(); //Khởi tạo đối tượng
            this.Hide();
            FrBaoCaoKiemDinhChatLuong.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuBaoCaoChuongTrinhDaoTao_Click(object sender, EventArgs e)
        {
            FormBaoCaoChuongTrinhDaoTao FrBaoCaoChuongTrinhDaoTao = new FormBaoCaoChuongTrinhDaoTao(); //Khởi tạo đối tượng
            this.Hide();
            FrBaoCaoChuongTrinhDaoTao.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
