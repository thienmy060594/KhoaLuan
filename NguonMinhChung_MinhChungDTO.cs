using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class NguonMinhChung_MinhChungDTO
    {        
        private int id_nguonminhchung;
        private int id_tailieu;
        private string manguonminhchung;
        private string tennguonminhchung;
        private string matailieu;
        private string tentailieu;
        private string ghichu;
        
        public int Id_NguonMinhChung { get => id_nguonminhchung; set => id_nguonminhchung = value; }
        public int Id_TaiLieu { get => id_tailieu; set => id_tailieu = value; }
        public string MaNguonMinhChung { get => manguonminhchung; set => manguonminhchung = value; }
        public string TenNguonMinhChung { get => tennguonminhchung; set => tennguonminhchung = value; }
        public string MaTaiLieu { get => matailieu; set => matailieu = value; }
        public string TenTaiLieu { get => tentailieu; set => tentailieu = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public NguonMinhChung_MinhChungDTO(int id_nguonminhchung, int id_tailieu, string manguonminhchung, string tennguonminhchung, string matailieu, string tentailieu, string ghichu)
        {            
            this.Id_NguonMinhChung = id_nguonminhchung;
            this.Id_TaiLieu = id_tailieu;
            this.MaNguonMinhChung = manguonminhchung;
            this.TenNguonMinhChung = tennguonminhchung;
            this.MaTaiLieu = matailieu;
            this.TenTaiLieu = tentailieu;
            this.GhiChu = ghichu;
        }

        public NguonMinhChung_MinhChungDTO(DataRow row)
        {            
            this.Id_NguonMinhChung = Int32.Parse(row["ID_NguonMinhChung"].ToString());
            this.Id_TaiLieu = Int32.Parse(row["ID_TaiLieu"].ToString());
            this.MaNguonMinhChung = row["MaNguonMinhChung"].ToString();
            this.TenNguonMinhChung = row["TenNguonMinhChung"].ToString();
            this.MaTaiLieu = row["MaTaiLieu"].ToString();
            this.TenTaiLieu = row["TenTaiLieu"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
