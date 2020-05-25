using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class MonHoc_NhomTuChonDTO
    {
        private int id_monhoc;
        private int id_nhomtuchon;
        private string mamonhoc;
        private string tenmonhoc;
        private string manhomtuchon;
        private string tennhomtuchon;
        private string ghichu;

        public int Id_MonHoc { get => id_monhoc; set => id_monhoc = value; }
        public int Id_NhomTuChon { get => id_nhomtuchon; set => id_nhomtuchon = value; }
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public string MaNhomTuChon { get => manhomtuchon; set => manhomtuchon = value; }
        public string TenNhomTuChon { get => tennhomtuchon; set => tennhomtuchon = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public MonHoc_NhomTuChonDTO(int id_monhoc, int id_nhomtuchon, string mamonhoc, string tenmonhoc, string manhomtuchon, string tennhomtuchon, string ghichu)
        {
            this.Id_MonHoc = id_monhoc;
            this.Id_NhomTuChon = id_nhomtuchon;
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.MaNhomTuChon = manhomtuchon;
            this.TenNhomTuChon = tennhomtuchon;
            this.GhiChu = ghichu;
        }

        public MonHoc_NhomTuChonDTO(DataRow row)
        {
            this.Id_MonHoc = Int32.Parse(row["ID_MonHoc"].ToString());
            this.Id_NhomTuChon = Int32.Parse(row["ID_NhomTuChon"].ToString());
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();
            this.MaNhomTuChon = row["MaNhomTuChon"].ToString();
            this.TenNhomTuChon = row["TenNhomTuChon"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
