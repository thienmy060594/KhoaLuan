using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlTypes;

namespace KiemDinhChatLuongDTO
{
    public class TieuChuanDTO
    {
        private int matieuchuan;
        private string tentieuchuan;
        private string noidungtieuchuan;
        private string ghichu;

        public int MaTieuChuan { get => matieuchuan; set => matieuchuan = value; }
        public string TenTieuChuan { get => tentieuchuan; set => tentieuchuan = value; }
        public string NoiDungTieuChuan { get => noidungtieuchuan; set => noidungtieuchuan = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChuanDTO(int matieuchuan, string tentieuchuan, string noidungTieuChuan, string ghichu)
        {
            this.MaTieuChuan = matieuchuan;
            this.TenTieuChuan = tentieuchuan;
            this.NoiDungTieuChuan = noidungTieuChuan;
            this.GhiChu = ghichu;
        }

        public TieuChuanDTO(DataRow row)
        {
            this.MaTieuChuan = Int32.Parse(row["MaTieuChuan"].ToString());
            this.TenTieuChuan = row["TenTieuChuan"].ToString();
            this.NoiDungTieuChuan = row["NoiDungTieuChuan"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
