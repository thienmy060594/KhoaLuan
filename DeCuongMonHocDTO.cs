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
        private int id_decuongmonhoc;
        private int id_monhoc;
        private int id_tailieu;
        private string mamonhoc;
        private string tenmonhoc;
        private string matailieu;
        private string tentailieu;
        private string madecuongmonhoc;
        private string tendecuongmonhoc;
        private string noidung;
        private string ghichu;
        public int Id_DeCuongMonHoc { get => id_decuongmonhoc; set => id_decuongmonhoc = value; }
        public int Id_MonHoc { get => id_monhoc; set => id_monhoc = value; }
        public int Id_TaiLieu { get => id_tailieu; set => id_tailieu = value; }
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public string MaTaiLieu { get => matailieu; set => matailieu = value; }
        public string TenTaiLieu { get => tentailieu; set => tentailieu = value; }
        public string MaDeCuongMonHoc { get => madecuongmonhoc; set => madecuongmonhoc = value; }
        public string TenDeCuongMonHoc { get => tendecuongmonhoc; set => tendecuongmonhoc = value; }
        public string NoiDung { get => noidung; set => noidung = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public DeCuongMonHocDTO(int id_decuongmonhoc, int id_monhoc, int id_tailieu, string mamonhoc, string tenmonhoc, string matailieu, string tentailieu, string madecuongmonhoc, string tendecuongmonhoc, string noidung, string ghichu)
        {
            this.Id_DeCuongMonHoc = id_decuongmonhoc;
            this.Id_MonHoc = id_monhoc;
            this.Id_TaiLieu = id_tailieu;
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.MaTaiLieu = matailieu;
            this.TenTaiLieu = tentailieu;
            this.MaDeCuongMonHoc = madecuongmonhoc;
            this.TenDeCuongMonHoc = tendecuongmonhoc;
            this.NoiDung = noidung;
            this.GhiChu = ghichu;
        }

        public DeCuongMonHocDTO(DataRow row)
        {
            this.Id_DeCuongMonHoc = Int32.Parse(row["ID_DeCuongMonHoc"].ToString());
            this.Id_MonHoc = Int32.Parse(row["ID_MonHoc"].ToString());
            this.Id_TaiLieu = Int32.Parse(row["ID_TaiLieu"].ToString());
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();
            this.MaTaiLieu = row["MaTaiLieu"].ToString();
            this.TenTaiLieu = row["TenTaiLieu"].ToString();
            this.MaDeCuongMonHoc = row["MaDeCuongMonHoc"].ToString();
            this.TenDeCuongMonHoc = row["TenDeCuongMonHoc"].ToString();
            this.NoiDung = row["NoiDung"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
