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
        private string mayeucau;
        private string tenyeucau;
        private string mamocthamchieu;
        private string tenmocthamchieu;
        private string ghichu;

        public int Id_YeuCau { get => id_yeucau; set => id_yeucau = value; }
        public int Id_MocThamChieu { get => id_mocthamchieu; set => id_mocthamchieu = value; }
        public string MaYeuCau { get => mayeucau; set => mayeucau = value; }
        public string TenYeuCau { get => tenyeucau; set => tenyeucau = value; }
        public string MaMocThamChieu { get => mamocthamchieu; set => mamocthamchieu = value; }
        public string TenMocThamChieu { get => tenmocthamchieu; set => tenmocthamchieu = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public YeuCau_MocThamChieuDTO(int id_yeucau, int id_mocthamchieu, string mayeucau, string tenyeucau, string mamocthamchieu, string tenmocthamchieu, string ghichu)
        {
            this.Id_YeuCau = id_yeucau;
            this.Id_MocThamChieu = id_mocthamchieu;
            this.MaYeuCau = mayeucau;
            this.TenYeuCau = tenyeucau;
            this.MaMocThamChieu = mamocthamchieu;
            this.TenMocThamChieu = tenmocthamchieu;
            this.GhiChu = ghichu;
        }

        public YeuCau_MocThamChieuDTO(DataRow row)
        {            
            this.Id_YeuCau = Int32.Parse(row["ID_YeuCau"].ToString());
            this.Id_MocThamChieu = Int32.Parse(row["ID_MocThamChieu"].ToString());            
            this.MaYeuCau = row["MaYeuCau"].ToString();
            this.TenYeuCau = row["TenYeuCau"].ToString();
            this.MaMocThamChieu = row["MaMocThamChieu"].ToString();
            this.TenMocThamChieu = row["TenMocThamChieu"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
