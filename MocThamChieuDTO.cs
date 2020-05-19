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
        private int mamocthamchieu;
        private string tenmocthamchieu;
        private string noidungmocthamchieu;
        private string ghichu;

        public int MaMocThamChieu { get => mamocthamchieu; set => mamocthamchieu = value; }
        
        public string TenMocThamChieu { get => tenmocthamchieu; set => tenmocthamchieu = value; }

        public string NoiDungMocThamChieu { get => noidungmocthamchieu; set => noidungmocthamchieu = value; }

        public string GhiChu { get => ghichu; set => ghichu = value; }

        public MocThamChieuDTO(int mamocthamchieu, string tenmocthamchieu, string noidungmocthamchieu, string ghichu)
        {
            this.MaMocThamChieu = mamocthamchieu;            
            this.TenMocThamChieu = tenmocthamchieu;
            this.NoiDungMocThamChieu = noidungmocthamchieu;
            this.GhiChu = ghichu;
        }

        public MocThamChieuDTO(DataRow row)
        {
            this.MaMocThamChieu = Int32.Parse(row["MaMocThamChieu"].ToString());            
            this.TenMocThamChieu = row[".TenMocThamChieu"].ToString();
            this.NoiDungMocThamChieu = row["NoiDungMocThamChieu"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
