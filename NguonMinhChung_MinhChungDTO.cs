using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class NguonMinhChung_MinhChungDTO
    {        
        private int id_nguonminhchung;
        private int id_minhchung;
        private string ghichu;
        
        public int Id_NguonMinhChung { get => id_nguonminhchung; set => id_nguonminhchung = value; }
        public int Id_MinhChung { get => id_minhchung; set => id_minhchung = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public NguonMinhChung_MinhChungDTO(int id_nguonminhchung, int id_minhchung, string ghichu)
        {            
            this.Id_NguonMinhChung = id_nguonminhchung;
            this.Id_MinhChung = id_minhchung;
            this.GhiChu = ghichu;
        }

        public NguonMinhChung_MinhChungDTO(DataRow row)
        {            
            this.Id_NguonMinhChung = Int32.Parse(row["ID_NguonMinhChung"].ToString());
            this.Id_MinhChung = Int32.Parse(row["ID_MinhChung"].ToString());
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
