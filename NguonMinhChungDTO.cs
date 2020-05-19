using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class NguonMinhChungDTO
    {
        private int manguonminhchung;
        private string tennguonminhchung;
        private string noidungnguonminhchung;
        private string ghichu;

        public int MaNguonMinhChung { get => manguonminhchung; set => manguonminhchung = value; }        

        public string TenNguonMinhChung { get => tennguonminhchung; set => tennguonminhchung = value; }

        public string NoiDungNguonMinhChung { get => noidungnguonminhchung; set => noidungnguonminhchung = value; }

        public string GhiChu { get => ghichu; set => ghichu = value; }

        public NguonMinhChungDTO(int manguonminhchung, string tennguonminhchung, string noidungnguonminhchung, string ghichu)
        {
            this.MaNguonMinhChung = manguonminhchung;
            this.TenNguonMinhChung = tennguonminhchung;
            this.NoiDungNguonMinhChung = noidungnguonminhchung;
            this.GhiChu = ghichu;
        }

        public NguonMinhChungDTO(DataRow row)
        {
            this.MaNguonMinhChung = Int32.Parse(row["MaNguonMinhChung"].ToString());            
            this.TenNguonMinhChung = row["TenNguonMinhChung"].ToString();
            this.NoiDungNguonMinhChung = row["NoiDungNguonMinhChung"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}


