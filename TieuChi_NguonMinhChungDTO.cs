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
        private string ghichu;


        public int Id_TieuChi { get => id_tieuchi; set => id_tieuchi = value; }
        public int Id_NguonMinhChung { get => id_nguonminhchung; set => id_nguonminhchung = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChi_NguonMinhChungDTO(int id_tieuchi, int id_nguonminhchung, string ghichu)
        {
            this.Id_TieuChi = id_tieuchi;
            this.Id_NguonMinhChung = id_nguonminhchung;
            this.GhiChu = ghichu;
        }

        public TieuChi_NguonMinhChungDTO(DataRow row)
        {
            this.Id_TieuChi = Int32.Parse(row["ID_TieuChi"].ToString());
            this.Id_NguonMinhChung = Int32.Parse(row["ID_NguonMinhChung"].ToString());
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
