using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class BaoCaoKiemDinhChatLuongDTO
    {
        private int id_tieuchuan;
        private int id_tieuchi;
        private int id_yeucau;
        private int id_mocthamchieu;
        private int id_nguonminhchung;        
        private string noidungtieuchuan;
        private string noidungtieuchi;
        private string noidungyeucau;
        private string noidungmocthamchieu;
        private string noidungnguonminhchung;

        public int Id_TieuChuan { get => id_tieuchuan; set => id_tieuchuan = value; }
        public int Id_TieuChi { get => id_tieuchi; set => id_tieuchi = value; }
        public int Id_YeuCau { get => id_yeucau; set => id_yeucau = value; }
        public int Id_MocThamChieu { get => id_mocthamchieu; set => id_mocthamchieu = value; }
        public int Id_NguonMinhChung { get => id_nguonminhchung; set => id_nguonminhchung = value; }
        public string NoiDungTieuChuan { get => noidungtieuchuan; set => noidungtieuchuan = value; }
        public string NoiDungTieuChi { get => noidungtieuchi; set => noidungtieuchi = value; }
        public string NoiDungYeuCau { get => noidungyeucau; set => noidungyeucau = value; }
        public string NoiDungMocThamChieu { get => noidungmocthamchieu; set => noidungmocthamchieu = value; }
        public string NoiDungNguonMinhChung { get => noidungnguonminhchung; set => noidungnguonminhchung = value; }

        public BaoCaoKiemDinhChatLuongDTO(int id_tieuchuan, int id_tieuchi, int id_yeucau, int id_mocthamchieu, int id_nguonminhchung, string noidungtieuchuan, string noidungtieuchi, string noidungyeucau, string noidungmocthamchieu, string noidungnguonminhchung)
        {
            this.Id_TieuChuan = id_tieuchuan;
            this.Id_TieuChi = id_tieuchi;
            this.Id_YeuCau = id_yeucau;
            this.Id_MocThamChieu = id_mocthamchieu;
            this.Id_NguonMinhChung = id_nguonminhchung;
            this.NoiDungTieuChuan = noidungtieuchuan;
            this.NoiDungTieuChi = noidungtieuchi;
            this.NoiDungYeuCau = noidungyeucau;
            this.NoiDungMocThamChieu = noidungmocthamchieu;
            this.NoiDungNguonMinhChung = noidungnguonminhchung;
        }

        public BaoCaoKiemDinhChatLuongDTO(DataRow row)
        {
            this.Id_TieuChuan = Int32.Parse(row["ID_TieuChuan"].ToString());
            this.Id_TieuChi = Int32.Parse(row["ID_TieuChi"].ToString());
            this.Id_YeuCau = Int32.Parse(row["ID_YeuCau"].ToString());
            this.Id_MocThamChieu = Int32.Parse(row["ID_MocThamChieu"].ToString());
            this.Id_NguonMinhChung = Int32.Parse(row["ID_NguonMinhChung"].ToString());
            this.NoiDungTieuChuan = row["NoiDungTieuChuan"].ToString();
            this.NoiDungTieuChi = row["NoiDungTieuChi"].ToString();
            this.NoiDungYeuCau = row["NoiDungYeuCau"].ToString();
            this.NoiDungMocThamChieu = row["NoiDungMocThamChieu"].ToString();
            this.NoiDungNguonMinhChung = row["NoiDungNguonMinhChung"].ToString();
        }
    }
}
