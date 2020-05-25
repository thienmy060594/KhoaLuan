using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class MonHocDTO
    {
        private int id_monhoc;        
        private string mamonhoc;
        private string tenmonhoc;
        private int sotinchi;
        private int sotietlythuyet;
        private int sotietthuchanh;
        private string ghichu;

        public int Id_MonHoc { get => id_monhoc; set => id_monhoc = value; }        
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }        
        public int SoTinChi { get => sotinchi; set => sotinchi = value; }
        public int SoTietLyThuyet { get => sotietlythuyet; set => sotietlythuyet = value; }
        public int SoTietThucHanh { get => sotietthuchanh; set => sotietthuchanh = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }


        public MonHocDTO(int id_monhoc, string mamonhoc, string tenmonhoc, int sotinchi, int sotietlythuyet, int sotietthuchanh, string ghichu)
        {
            this.Id_MonHoc = id_monhoc;
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.SoTinChi = sotinchi;
            this.SoTietLyThuyet = sotietlythuyet;
            this.SoTietThucHanh = sotietthuchanh;
            this.GhiChu = ghichu;
        }

        public MonHocDTO(DataRow row)
        {
            this.Id_MonHoc = Int32.Parse(row["ID_MonHoc"].ToString());            
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();            
            this.SoTinChi = Int32.Parse(row["SoTinChi"].ToString());
            this.SoTietLyThuyet = Int32.Parse(row["SoTietLyThuyet"].ToString());
            this.SoTietThucHanh = Int32.Parse(row["SoTietThucHanh"].ToString());
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
