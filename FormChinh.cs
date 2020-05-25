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

        private void mnuTieuChiYeuCau_Click(object sender, EventArgs e)
        {
            FormTieuChi_YeuCau FrTieuChiYeuCau = new FormTieuChi_YeuCau(); //Khởi tạo đối tượng
            this.Hide();
            FrTieuChiYeuCau.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuYeuCauMocThamChieu_Click(object sender, EventArgs e)
        {
            FormYeuCau_MocThamChieu FrYeuCauMocThamChieu = new FormYeuCau_MocThamChieu(); //Khởi tạo đối tượng
            this.Hide();
            FrYeuCauMocThamChieu.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuTieuChiGoiY_Click(object sender, EventArgs e)
        {
            FormTieuChi_NguonMinhChung FrTieuChiNguonMinhChung = new FormTieuChi_NguonMinhChung(); //Khởi tạo đối tượng
            this.Hide();
            FrTieuChiNguonMinhChung.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMinhChungGoiY_Click(object sender, EventArgs e)
        {
            FormNguonMinhChung_MinhChung FrNguonMinhChungMinhChung = new FormNguonMinhChung_MinhChung(); //Khởi tạo đối tượng
            this.Hide();
            FrNguonMinhChungMinhChung.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuKhoa_Click(object sender, EventArgs e)
        {
            FormKhoa FrKhoa = new FormKhoa(); //Khởi tạo đối tượng
            this.Hide();
            FrKhoa.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuNganh_Click(object sender, EventArgs e)
        {
            FormNganh FrNganh = new FormNganh(); //Khởi tạo đối tượng
            this.Hide();
            FrNganh.ShowDialog(); //Hiển thị
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

        private void mnuLoaiMon_Click(object sender, EventArgs e)
        {
            FormLoaiMon FrLoaiMon = new FormLoaiMon(); //Khởi tạo đối tượng
            this.Hide();
            FrLoaiMon.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuDeCuongMonHoc_Click(object sender, EventArgs e)
        {
            FormDeCuongMonHoc FrDeCuongMonHoc = new FormDeCuongMonHoc(); //Khởi tạo đối tượng
            this.Hide();
            FrDeCuongMonHoc.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuChuongTrinhDaoTaoMonHoc_Click(object sender, EventArgs e)
        {
            FormChuongTrinhDaoTao_MonHoc FrChuongTrinhDaoTao_MonHoc = new FormChuongTrinhDaoTao_MonHoc(); //Khởi tạo đối tượng
            this.Hide();
            FrChuongTrinhDaoTao_MonHoc.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void mnuMonHocNhomTuChon_Click(object sender, EventArgs e)
        {
            FormMonHoc_NhomTuChon FrMonHoc_NhomTuChon = new FormMonHoc_NhomTuChon(); //Khởi tạo đối tượng
            this.Hide();
            FrMonHoc_NhomTuChon.ShowDialog(); //Hiển thị
            this.Show();
        }

        
    }
}
