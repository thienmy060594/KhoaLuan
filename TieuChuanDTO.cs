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
        private int id_tieuchuan;
        private string matieuchuan;
        private string tentieuchuan;
        private string noidungtieuchuan;
        private string ghichu;

        public int Id_TieuChuan { get => id_tieuchuan; set => id_tieuchuan = value; }
        public string MaTieuChuan { get => matieuchuan; set => matieuchuan = value; }
        public string TenTieuChuan { get => tentieuchuan; set => tentieuchuan = value; }
        public string NoiDungTieuChuan { get => noidungtieuchuan; set => noidungtieuchuan = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChuanDTO(int id_tieuchuan, string matieuchuan, string tentieuchuan, string noidungtieuchuan, string ghichu)
        {
            this.Id_TieuChuan = id_tieuchuan;
            this.MaTieuChuan = matieuchuan;
            this.TenTieuChuan = tentieuchuan;
            this.NoiDungTieuChuan = noidungtieuchuan;
            this.GhiChu = ghichu;
        }      

        public TieuChuanDTO(DataRow row)
        {
            this.Id_TieuChuan = Int32.Parse(row["ID_TieuChuan"].ToString());
            this.MaTieuChuan = row["MaTieuChuan"].ToString();
            this.TenTieuChuan = row["TenTieuChuan"].ToString();
            this.NoiDungTieuChuan = row["NoiDungTieuChuan"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }        
    }
}
