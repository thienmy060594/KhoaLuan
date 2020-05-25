using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class MonTienQuyetDTO
    {
        private int id_monhoc;
        private int id_monhoc_tienquyet;
        private string mamonhoc;
        private string tenmonhoc;
        private string mamonhoctienquyet;
        private string tenmonhoctienquyet;
        private string ghichu;

        public int Id_MonHoc { get => id_monhoc; set => id_monhoc = value; }
        public int Id_MonHoc_TienQuyet { get => id_monhoc_tienquyet; set => id_monhoc_tienquyet = value; }
        public string MaMonHoc { get => mamonhoc; set => mamonhoc = value; }
        public string TenMonHoc { get => tenmonhoc; set => tenmonhoc = value; }
        public string MaMonHocTienQuyet { get => mamonhoctienquyet; set => mamonhoctienquyet = value; }
        public string TenMonHocTienQuyet { get => tenmonhoctienquyet; set => tenmonhoctienquyet = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public MonTienQuyetDTO(int id_monhoc, int id_monhoc_tienquyet, string mamonhoc, string tenmonhoc, string mamonhoctienquyet, string tenmonhoctienquyet, string ghichu)
        {
            this.Id_MonHoc = id_monhoc;
            this.Id_MonHoc_TienQuyet = id_monhoc_tienquyet;
            this.MaMonHoc = mamonhoc;
            this.TenMonHoc = tenmonhoc;
            this.MaMonHocTienQuyet = mamonhoctienquyet;
            this.TenMonHocTienQuyet = tenmonhoctienquyet;
            this.GhiChu = ghichu;
        }

        public MonTienQuyetDTO(DataRow row)
        {
            this.Id_MonHoc = Int32.Parse(row["ID_MonHoc"].ToString());
            this.Id_MonHoc_TienQuyet = Int32.Parse(row["ID_MonHoc_TienQuyet"].ToString());
            this.MaMonHoc = row["MaMonHoc"].ToString();
            this.TenMonHoc = row["TenMonHoc"].ToString();
            this.MaMonHocTienQuyet = row["MaMonHocTienQuyet"].ToString();
            this.TenMonHocTienQuyet = row["TenMonHocTienQuyet"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
