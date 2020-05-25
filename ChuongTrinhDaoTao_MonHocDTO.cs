using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class ChuongTrinhDaoTao_MonHocDTO
    {
        private int id_chuongtrinhdaotao;        
        private int id_monhoc;
        private int id_loaimon;
        private string machuongtrinhdaotao;
        private string mamonhoc;
        private string tenmonhoc;
        private string maloaimon;
        private string tenloaimon;
        private string hocky;
        private string ghichu;

        public int Id_ChuongTrinhDaoTao { get => id_chuongtrinhdaotao; set => id_chuongtrinhdaotao = value; }
        public int Id_MonHoc { get => id_monhoc; set => id_monhoc = value; }
        public int Id_LoaiMon { get => id_loaimon; set => id_loaimon = value; }
        public string MaChuongTrinhDaoTao { get => machuongtrinhdaotao; set => machuongtrinhdaotao = value; }
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }       
        public string MaLoaiMon { get => maloaimon; set => maloaimon = value; }
        public string TenLoaiMon { get => tenloaimon; set => tenloaimon = value; }
        public string HocKy { get => hocky; set => hocky = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public ChuongTrinhDaoTao_MonHocDTO(int id_chuongtrinhdaotao, int id_monhoc, int id_loaimon, string machuongtrinhdaotao, string mamonhoc, string tenmonhoc, string maloaimon, string tenloaimon, string hocky, string ghichu)
        {
            this.Id_ChuongTrinhDaoTao = id_chuongtrinhdaotao;
            this.Id_MonHoc = id_monhoc;            
            this.Id_LoaiMon = id_loaimon;
            this.MaChuongTrinhDaoTao = machuongtrinhdaotao;
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.MaLoaiMon = maloaimon;
            this.TenLoaiMon = tenloaimon;
            this.HocKy = hocky; 
            this.GhiChu = ghichu;
        }

        public ChuongTrinhDaoTao_MonHocDTO(DataRow row)
        {
            this.Id_ChuongTrinhDaoTao = Int32.Parse(row["ID_ChuongTrinhDaoTao"].ToString());
            this.Id_MonHoc = Int32.Parse(row["ID_MonHoc"].ToString());
            this.Id_LoaiMon = Int32.Parse(row["ID_LoaiMon"].ToString());
            this.MaChuongTrinhDaoTao = row["MaChuongTrinhDaoTao"].ToString();
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();            
            this.MaLoaiMon = row["MaLoaiMon"].ToString();
            this.TenLoaiMon = row["TenLoaiMon"].ToString();
            this.HocKy = row["HocKy"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
