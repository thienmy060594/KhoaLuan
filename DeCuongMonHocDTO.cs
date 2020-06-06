using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.CompilerServices;

namespace KiemDinhChatLuongDTO
{
    public class DeCuongMonHocDTO
    {        
        private int id_monhoc;
        private int id_tailieu;
        private string mamonhoc;
        private string tenmonhoc;
        private string matailieu;
        private string tentailieu;
        private string madecuongmonhoc;
        private string tendecuongmonhoc;
        private string mota;
        private string hinhthucdanhgia;
        private string giaotrinh;
        private string ghichu;
        
        public int Id_MonHoc { get => id_monhoc; set => id_monhoc = value; }
        public int Id_TaiLieu { get => id_tailieu; set => id_tailieu = value; }
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public string MaTaiLieu { get => matailieu; set => matailieu = value; }
        public string TenTaiLieu { get => tentailieu; set => tentailieu = value; }
        public string MaDeCuongMonHoc { get => madecuongmonhoc; set => madecuongmonhoc = value; }
        public string TenDeCuongMonHoc { get => tendecuongmonhoc; set => tendecuongmonhoc = value; }
        public string HinhThucDanhGia { get => hinhthucdanhgia; set => hinhthucdanhgia = value; }
        public string GiaoTrinh { get => giaotrinh; set => giaotrinh = value; }
        public string MoTa { get => mota; set => mota = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public DeCuongMonHocDTO( int id_monhoc, int id_tailieu, string mamonhoc, string tenmonhoc, string matailieu, string tentailieu, string madecuongmonhoc, string tendecuongmonhoc, string hinhthucdanhgia, string giaotrinh, string mota, string noidung, string ghichu)
        {            
            this.Id_MonHoc = id_monhoc;
            this.Id_TaiLieu = id_tailieu;
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.MaTaiLieu = matailieu;
            this.TenTaiLieu = tentailieu;
            this.MaDeCuongMonHoc = madecuongmonhoc;
            this.TenDeCuongMonHoc = tendecuongmonhoc;
            this.HinhThucDanhGia = hinhthucdanhgia;
            this.GiaoTrinh = giaotrinh;
            this.MoTa = mota;
            this.GhiChu = ghichu;
        }

        public DeCuongMonHocDTO(DataRow row)
        {            
            this.Id_MonHoc = Int32.Parse(row["ID_MonHoc"].ToString());
            this.Id_TaiLieu = Int32.Parse(row["ID_TaiLieu"].ToString());
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();
            this.MaTaiLieu = row["MaTaiLieu"].ToString();
            this.TenTaiLieu = row["TenTaiLieu"].ToString();
            this.MaDeCuongMonHoc = row["MaDeCuongMonHoc"].ToString();
            this.TenDeCuongMonHoc = row["TenDeCuongMonHoc"].ToString();
            this.HinhThucDanhGia = row["HinhThucDanhGia"].ToString();
            this.GiaoTrinh = row["GiaoTrinh"].ToString();
            this.MoTa = row["MoTa"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
