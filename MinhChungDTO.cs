using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class MinhChungDTO
    {
        private int id_tailieu;
        private string matailieu;
        private string tentailieu;
        private string ngayky;
        private string nguoiky;
        private string sobanhanh;
        private string tomtatnoidung;
        private string duonglink;
        private string ghichu;

        public int Id_TaiLieu { get => id_tailieu; set => id_tailieu = value; }
        public string MaTaiLieu { get => matailieu; set => matailieu = value; }
        public string TenTaiLieu { get => tentailieu; set => tentailieu = value; }
        public string NgayKy { get => ngayky; set => ngayky = value; }
        public string NguoiKy { get => nguoiky; set => nguoiky = value; }
        public string SoBanHanh { get => sobanhanh; set => sobanhanh = value; }
        public string TomTatNoiDung { get => tomtatnoidung; set => tomtatnoidung = value; }
        public string DuongLink { get => duonglink; set => duonglink = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public MinhChungDTO(int id_tailieu ,string matailieu, string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string duonglink, string ghichu)
        {
            this.Id_TaiLieu = id_tailieu;
            this.MaTaiLieu = matailieu;
            this.TenTaiLieu = tentailieu;
            this.NgayKy = ngayky;
            this.NguoiKy = nguoiky;
            this.SoBanHanh = sobanhanh;
            this.TomTatNoiDung = tomtatnoidung;
            this.DuongLink = duonglink;
            this.GhiChu = ghichu;
        }

        public MinhChungDTO(DataRow row)
        {
            this.Id_TaiLieu = Int32.Parse(row["ID_TaiLieu"].ToString());
            this.MaTaiLieu = row["MaTaiLieu"].ToString();
            this.TenTaiLieu = row["TenTaiLieu"].ToString();
            this.NgayKy = row["NgayKy"].ToString();
            this.NguoiKy = row["NguoiKy"].ToString();
            this.SoBanHanh = row["SoBanHanh"].ToString();
            this.TomTatNoiDung = row["TomTatNoiDung"].ToString();
            this.DuongLink = row["DuongLink"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
