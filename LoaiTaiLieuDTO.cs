using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class LoaiTaiLieuDTO
    {
        private int maloaitailieu;
        private int maminhchung;
        private int manguonminhchung;
        private string tentailieu;
        private string ghichu;

        public int MaLoaiTaiLieu { get => maloaitailieu; set => maloaitailieu = value; }

        public int MaMinhChung { get => maminhchung; set => maminhchung = value; }

        public int MaNguonMinhChung { get => manguonminhchung; set => manguonminhchung = value; }

        public string TenTaiLieu { get => tentailieu; set => tentailieu = value; }

        public string GhiChu { get => ghichu; set => ghichu = value; }

        public LoaiTaiLieuDTO(int maloaitailieu, int maminhchung, int manguonminhchung, string tentailieu, string ghichu)
        {
            this.MaLoaiTaiLieu = maloaitailieu;
            this.MaMinhChung = maminhchung;
            this.MaNguonMinhChung = manguonminhchung;
            this.TenTaiLieu = tentailieu;
            this.GhiChu = ghichu;
        }

        public LoaiTaiLieuDTO(DataRow row)
        {
            this.MaLoaiTaiLieu = Int32.Parse(row["MaLoaiTaiLieu"].ToString());
            this.MaMinhChung = Int32.Parse(row["MaMinhChung"].ToString());
            this.MaNguonMinhChung = Int32.Parse(row["MaNguonMinhChung"].ToString());
            this.TenTaiLieu = row["TenTaiLieu"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
