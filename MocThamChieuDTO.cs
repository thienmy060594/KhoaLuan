using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class MocThamChieuDTO
    {
        private int id_mocthamchieu;
        private string mamocthamchieu;
        private string tenmocthamchieu;
        private string noidungmocthamchieu;
        private string ghichu;

        public int Id_MocThamChieu { get => id_mocthamchieu; set => id_mocthamchieu = value; }
        public string MaMocThamChieu { get => mamocthamchieu; set => mamocthamchieu = value; }
        public string TenMocThamChieu { get => tenmocthamchieu; set => tenmocthamchieu = value; }
        public string NoiDungMocThamChieu { get => noidungmocthamchieu; set => noidungmocthamchieu = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public MocThamChieuDTO(int id_mocthamchieu, string mamocthamchieu, string tenmocthamchieu, string noidungmocthamchieu, string ghichu)
        {
            this.Id_MocThamChieu = id_mocthamchieu;
            this.MaMocThamChieu = mamocthamchieu;            
            this.TenMocThamChieu = tenmocthamchieu;
            this.NoiDungMocThamChieu = noidungmocthamchieu;
            this.GhiChu = ghichu;
        }

        public MocThamChieuDTO(DataRow row)
        {
            this.Id_MocThamChieu = Int32.Parse(row["ID_MocThamChieu"].ToString());
            this.MaMocThamChieu = row["MaMocThamChieu"].ToString();
            this.TenMocThamChieu = row["TenMocThamChieu"].ToString();
            this.NoiDungMocThamChieu = row["NoiDungMocThamChieu"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
