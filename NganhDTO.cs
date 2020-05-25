using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class NganhDTO
    {
        private int id_nganh;
        private int id_khoa;
        private string makhoa;
        private string tenkhoa;
        private string manganh;
        private string tennganh;        
        private string ghichu;

        public int Id_Nganh { get => id_nganh; set => id_nganh = value; }
        public int Id_Khoa { get => id_khoa; set => id_khoa = value; }
        public string MaKhoa { get => makhoa; set => makhoa = value; }
        public string TenKhoa { get => tenkhoa; set => tenkhoa = value; }
        public string MaNganh { get => manganh; set => manganh = value; }
        public string TenNganh { get => tennganh; set => tennganh = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public NganhDTO(int id_nganh, int id_khoa, string makhoa, string tenkhoa, string manganh, string tennganh, string ghichu)
        {
            this.Id_Nganh = id_nganh;
            this.Id_Khoa = id_khoa;
            this.MaKhoa = makhoa;
            this.TenKhoa = tenkhoa;
            this.MaNganh = manganh;
            this.TenNganh = tennganh;            
            this.GhiChu = ghichu;
        }

        public NganhDTO(DataRow row)
        {
            this.Id_Nganh = Int32.Parse(row["ID_Nganh"].ToString());
            this.Id_Khoa = Int32.Parse(row["ID_Khoa"].ToString());
            this.MaKhoa = row["MaKhoa"].ToString();
            this.TenKhoa = row["TenKhoa"].ToString();
            this.MaNganh = row["MaNganh"].ToString();
            this.TenNganh = row["TenNganh"].ToString();            
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
