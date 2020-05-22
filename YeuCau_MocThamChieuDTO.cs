using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class YeuCau_MocThamChieuDTO
    {
        private int id_yeucau;
        private int id_mocthamchieu;
        private string ghichu;

        public int Id_YeuCau { get => id_yeucau; set => id_yeucau = value; }
        public int Id_MocThamChieu { get => id_mocthamchieu; set => id_mocthamchieu = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public YeuCau_MocThamChieuDTO(int id_yeucau, int id_mocthamchieu, string ghichu)
        {
            this.Id_YeuCau = id_yeucau;
            this.Id_MocThamChieu = id_mocthamchieu;
            this.GhiChu = ghichu;
        }

        public YeuCau_MocThamChieuDTO(DataRow row)
        {            
            this.Id_YeuCau = Int32.Parse(row["ID_YeuCau"].ToString());
            this.Id_MocThamChieu = Int32.Parse(row["ID_MocThamChieu"].ToString());
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
