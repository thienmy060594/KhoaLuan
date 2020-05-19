using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class TieuChiDTO
    {
        private int matieuchi;
        private int matieuchuan;
        private string tentieuchi;
        private string noidungtieuchi;
        private string ghichu;

        public int MaTieuChi { get => matieuchi; set => matieuchi = value; }

        public int MaTieuChuan { get => matieuchuan; set => matieuchuan = value; }

        public string TenTieuChi { get => tentieuchi; set => tentieuchi = value; }

        public string NoiDungTieuChi { get => noidungtieuchi; set => noidungtieuchi = value; }

        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChiDTO(int matieuchi, int matieuchuan, string tentieuchi, string noidungtieuchuan, string ghichu)
        {
            this.MaTieuChi = matieuchi;
            this.MaTieuChuan = matieuchuan;
            this.TenTieuChi = tentieuchi;
            this.NoiDungTieuChi = noidungtieuchuan;
            this.GhiChu = ghichu;
        }

        public TieuChiDTO(DataRow row)
        {
            this.MaTieuChi = Int32.Parse(row["MaTieuChi"].ToString());
            this.MaTieuChuan = Int32.Parse(row["MaTieuChuan"].ToString());
            this.TenTieuChi = row["TenTieuChi"].ToString();
            this.NoiDungTieuChi = row["NoiDungTieuChi"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}

