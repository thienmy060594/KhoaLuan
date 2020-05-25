using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class ChuongTrinhDaoTaoDTO
    {
        private int id_chuongtrinhdaotao;       
        private int id_nganh;
        private string manganh;
        private string tennganh;
        private string machuongtrinhdaotao;
        private string namky;
        private string namapdung;
        private string tomtatnoidung;
        private string ghichu;
        public int Id_ChuongTrinhDaoTao { get => id_chuongtrinhdaotao; set => id_chuongtrinhdaotao = value; }        
        public int Id_Nganh { get => id_nganh; set => id_nganh = value; }
        public string MaNganh { get => manganh; set => manganh = value; }
        public string TenNganh { get => tennganh; set => tennganh = value; }
        public string MaChuongTrinhDaoTao { get => machuongtrinhdaotao; set => machuongtrinhdaotao = value; }
        public string NamKy { get => namky; set => namky = value; }
        public string NamApDung { get => namapdung; set => namapdung = value; }
        public string TomTatNoiDung { get => tomtatnoidung; set => tomtatnoidung = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public ChuongTrinhDaoTaoDTO(int id_chuongtrinhdaotao, int id_nganh, string manganh, string tennganh, string machuongtrinhdaotao, string namky, string namapdung, string tomtatnoidung, string ghichu)
        {
            this.Id_ChuongTrinhDaoTao = id_chuongtrinhdaotao;            
            this.Id_Nganh = id_nganh;
            this.MaNganh = manganh;
            this.TenNganh = tennganh;
            this.MaChuongTrinhDaoTao = machuongtrinhdaotao;
            this.NamKy = namky;
            this.NamApDung = namapdung;
            this.TomTatNoiDung = tomtatnoidung;
            this.GhiChu = ghichu;
        }

        public ChuongTrinhDaoTaoDTO(DataRow row)
        {
            this.Id_ChuongTrinhDaoTao = Int32.Parse(row["ID_ChuongTrinhDaoTao"].ToString());            
            this.Id_Nganh = Int32.Parse(row["ID_Nganh"].ToString());
            this.MaNganh = row["MaNganh"].ToString();
            this.TenNganh = row["TenNganh"].ToString();
            this.MaChuongTrinhDaoTao = row["MaChuongTrinhDaoTao"].ToString();
            this.NamKy = row["NamKy"].ToString();
            this.NamApDung = row["NamApDung"].ToString();
            this.TomTatNoiDung = row["TomTatNoiDung"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
