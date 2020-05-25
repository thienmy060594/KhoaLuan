using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class KhoaDTO
    {
        private int id_khoa;
        private string makhoa;
        private string tenkhoa;       
        private string ghichu;

        public int Id_Khoa { get => id_khoa; set => id_khoa = value; }
        public string MaKhoa { get => makhoa; set => makhoa= value; }
        public string TenKhoa { get => tenkhoa; set => tenkhoa = value; }        
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public KhoaDTO(int id_khoa, string makhoa, string tenkhoa, string ghichu)
        {
            this.Id_Khoa = id_khoa;
            this.MaKhoa = makhoa;
            this.TenKhoa = tenkhoa;            
            this.GhiChu = ghichu;
        }

        public KhoaDTO(DataRow row)
        {
            this.Id_Khoa = Int32.Parse(row["ID_Khoa"].ToString());
            this.MaKhoa = row["MaKhoa"].ToString();
            this.TenKhoa = row["TenKhoa"].ToString();           
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
