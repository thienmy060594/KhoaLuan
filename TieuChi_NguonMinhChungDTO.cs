using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class TieuChi_NguonMinhChungDTO
    {
        private int id_tieuchi;
        private int id_nguonminhchung;
        private string matieuchi;
        private string tentieuchi;
        private string manguonminhchung;
        private string tennguonminhchung;
        private string ghichu;


        public int Id_TieuChi { get => id_tieuchi; set => id_tieuchi = value; }
        public int Id_NguonMinhChung { get => id_nguonminhchung; set => id_nguonminhchung = value; }
        public string MaTieuChi { get => matieuchi; set => matieuchi = value; }
        public string TenTieuChi { get => tentieuchi; set => tentieuchi = value; }
        public string MaNguonMinhChung { get => manguonminhchung; set => manguonminhchung = value; }
        public string TenNguonMinhChung { get => tennguonminhchung; set => tennguonminhchung = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChi_NguonMinhChungDTO(int id_tieuchi, int id_nguonminhchung, string matieuchi, string tentieuchi, string manguonminhchung, string tennguonminhchung, string ghichu)
        {
            this.Id_TieuChi = id_tieuchi;
            this.Id_NguonMinhChung = id_nguonminhchung;
            this.MaTieuChi = matieuchi;
            this.TenTieuChi = tentieuchi;
            this.MaNguonMinhChung = manguonminhchung;
            this.TenNguonMinhChung = tennguonminhchung;
            this.GhiChu = ghichu;
        }

        public TieuChi_NguonMinhChungDTO(DataRow row)
        {
            this.Id_TieuChi = Int32.Parse(row["ID_TieuChi"].ToString());
            this.Id_NguonMinhChung = Int32.Parse(row["ID_NguonMinhChung"].ToString());
            this.MaTieuChi = row["MaTieuChi"].ToString();
            this.TenTieuChi = row["TenTieuChi"].ToString();
            this.MaNguonMinhChung = row["MaNguonMinhChung"].ToString();
            this.TenNguonMinhChung = row["TenNguonMinhChung"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
