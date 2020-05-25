using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class NhomTuChonDTO
    {
        private int id_nhomtuchon;
        private int id_chuongtrinhdaotao;
        private string machuongtrinhdaotao;        
        private string manhomtuchon;
        private string tennhomtuchon;
        private int sotinchi;        
        private string ghichu;

        public int Id_NhomTuChon { get => id_nhomtuchon; set => id_nhomtuchon = value; }
        public int Id_ChuongTrinhDaoTao { get => id_chuongtrinhdaotao; set => id_chuongtrinhdaotao = value; }
        public string MaChuongTrinhDaoTao { get => machuongtrinhdaotao; set => machuongtrinhdaotao = value; }
        public string MaNhomTuChon { get => manhomtuchon; set => manhomtuchon = value; }
        public string TenNhomTuChon { get => tennhomtuchon; set => tennhomtuchon = value; }
        public int SoTinChi { get => sotinchi; set => sotinchi = value; }    
        public string GhiChu { get => ghichu; set => ghichu = value; }
        

        public NhomTuChonDTO(int id_nhomtuchon, int id_chuongtrinhdaotao, string machuongtrinhdaotao, string manhomtuchon, string tennhomtuchon, int sotinchi, string ghichu)
        {
            this.Id_NhomTuChon = id_nhomtuchon;
            this.Id_ChuongTrinhDaoTao = id_chuongtrinhdaotao;
            this.MaChuongTrinhDaoTao = machuongtrinhdaotao;
            this.MaNhomTuChon = manhomtuchon;
            this.TenNhomTuChon = tennhomtuchon;
            this.SoTinChi = sotinchi;
            this.GhiChu = ghichu;
        }

        public NhomTuChonDTO(DataRow row)
        {
            this.Id_NhomTuChon = Int32.Parse(row["ID_NhomTuChon"].ToString());
            this.Id_ChuongTrinhDaoTao = Int32.Parse(row["ID_ChuongTrinhDaoTao"].ToString());
            this.MaChuongTrinhDaoTao = row["MaChuongTrinhDaoTao"].ToString();
            this.MaNhomTuChon = row["MaNhomTuChon"].ToString();
            this.TenNhomTuChon = row["TenNhomTuChon"].ToString();            
            this.SoTinChi = Int32.Parse(row["SoTinChi"].ToString());
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
