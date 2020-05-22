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
        private int id_tieuchi;
        private int id_tieuchuan;
        private string matieuchuan;
        private string tentieuchuan;
        private string matieuchi;
        private string tentieuchi;
        private string noidungtieuchi;
        private string ghichu;

        public int Id_TieuChi { get => id_tieuchi; set => id_tieuchi = value; }
        public int Id_TieuChuan { get => id_tieuchuan; set => id_tieuchuan = value; }
        public string MaTieuChuan { get => matieuchuan; set => matieuchuan = value; }
        public string TenTieuChuan { get => tentieuchuan; set => tentieuchuan = value; }
        public string MaTieuChi { get => matieuchi; set => matieuchi = value; }
        public string TenTieuChi { get => tentieuchi; set => tentieuchi = value; }
        public string NoiDungTieuChi { get => noidungtieuchi; set => noidungtieuchi = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChiDTO(int id_tieuchi, int id_tieuchuan, string matieuchuan, string tentieuchuan, string matieuchi, string tentieuchi, string noidungtieuchi, string ghichu)
        {
            this.Id_TieuChi = id_tieuchi;
            this.Id_TieuChuan = id_tieuchuan;
            this.MaTieuChuan = matieuchuan;            
            this.TenTieuChuan = tentieuchuan;
            this.MaTieuChi = matieuchi;
            this.TenTieuChi = tentieuchi;
            this.NoiDungTieuChi = noidungtieuchi;
            this.GhiChu = ghichu;
        }

        public TieuChiDTO(DataRow row)
        {
            this.Id_TieuChi = Int32.Parse(row["ID_TieuChi"].ToString());
            this.Id_TieuChuan = Int32.Parse(row["ID_TieuChuan"].ToString());
            this.MaTieuChuan = row["MaTieuChuan"].ToString();
            this.TenTieuChuan = row["TenTieuChuan"].ToString();
            this.MaTieuChi = row["MaTieuChi"].ToString();            
            this.TenTieuChi = row["TenTieuChi"].ToString();
            this.NoiDungTieuChi = row["NoiDungTieuChi"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}

