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
        private int id_loaitailieu;
        private int id_tailieu;
        private int id_nguonminhchung;
        private string matailieu;
        private string tentailieu;
        private string manguonminhchung;
        private string tennguonminhchung;
        private string maloaitailieu;       
        private string tenloaitailieu;
        private string ghichu;

        public int Id_LoaiTaiLieu { get => id_loaitailieu; set => id_loaitailieu = value; }
        public int Id_TaiLieu { get => id_tailieu; set => id_tailieu = value; }
        public int Id_NguonMinhChung { get => id_nguonminhchung; set => id_nguonminhchung = value; }
        public string MaTaiLieu { get => matailieu; set => matailieu = value; }        
        public string TenTaiLieu { get => tentailieu; set => tentailieu = value; }
        public string MaNguonMinhChung { get => manguonminhchung; set => manguonminhchung = value; }
        public string TenNguonMinhChung { get => tennguonminhchung; set => tennguonminhchung = value; }
        public string MaLoaiTaiLieu { get => maloaitailieu; set => maloaitailieu = value; }
        public string TenLoaiTaiLieu { get => tenloaitailieu; set => tenloaitailieu = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }
        public LoaiTaiLieuDTO(int id_loaitailieu,int id_tailieu, int id_nguonminhchung, string matailieu, string tentailieu, string manguonminhchung, string tennguonminhchung, string maloaitailieu, string tenloaitailieu, string ghichu)
        {
            this.Id_LoaiTaiLieu = id_loaitailieu;
            this.Id_TaiLieu = id_tailieu;
            this.Id_NguonMinhChung = id_nguonminhchung;
            this.MaTaiLieu = matailieu;
            this.TenTaiLieu = tentailieu;
            this.MaNguonMinhChung = manguonminhchung;
            this.TenNguonMinhChung = tennguonminhchung;
            this.MaLoaiTaiLieu = maloaitailieu;            
            this.TenLoaiTaiLieu = tenloaitailieu;
            this.GhiChu = ghichu;
        }

        public LoaiTaiLieuDTO(DataRow row)
        {
            this.Id_LoaiTaiLieu = Int32.Parse(row["ID_LoaiTaiLieu"].ToString());
            this.Id_TaiLieu = Int32.Parse(row["ID_TaiLieu"].ToString());
            this.Id_NguonMinhChung = Int32.Parse(row["ID_NguonMinhChung"].ToString());
            this.MaTaiLieu = row["MaTaiLieu"].ToString();
            this.TenTaiLieu = row["TenTaiLieu"].ToString();
            this.MaNguonMinhChung = row["MaNguonMinhChung"].ToString();
            this.TenNguonMinhChung = row["TenNguonMinhChung"].ToString();
            this.MaLoaiTaiLieu = row["MaLoaiTaiLieu"].ToString();           
            this.TenLoaiTaiLieu = row["TenLoaiTaiLieu"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
