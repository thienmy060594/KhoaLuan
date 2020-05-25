using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class LoaiMonDTO
    {
        private int id_loaimon;
        private string maloaimon;
        private string tenloaimon;
        private string ghichu;

        public int Id_LoaiMon { get => id_loaimon; set => id_loaimon = value; }
        public string MaLoaiMon { get => maloaimon; set => maloaimon = value; }
        public string TenLoaiMon { get => tenloaimon; set => tenloaimon = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public LoaiMonDTO(int id_loaimon, string maloaimon, string tenloaimon, string ghichu)
        {
            this.Id_LoaiMon = id_loaimon;
            this.MaLoaiMon = maloaimon;
            this.TenLoaiMon = tenloaimon;
            this.GhiChu = ghichu;
        }

        public LoaiMonDTO(DataRow row)
        {
            this.Id_LoaiMon = Int32.Parse(row["ID_LoaiMon"].ToString());
            this.MaLoaiMon = row["MaLoaiMon"].ToString();
            this.TenLoaiMon = row["TenLoaiMon"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
