using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class YeuCauDTO
    {
        private int id_yeucau;
        private string mayeucau;        
        private string tenyeucau;
        private string noidungyeucau;
        private string ghichu;

        public int Id_YeuCau { get => id_yeucau; set => id_yeucau = value; }
        public string MaYeuCau { get => mayeucau; set => mayeucau = value; } 
        public string TenYeuCau { get => tenyeucau; set => tenyeucau = value; }
        public string NoiDungYeuCau { get => noidungyeucau; set => noidungyeucau = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public YeuCauDTO( int id_yeucau,string mayeucau, string tenyeucau, string noidungyeucau, string ghichu)
        {
            this.Id_YeuCau = id_yeucau;
            this.MaYeuCau = mayeucau;            
            this.TenYeuCau = tenyeucau;
            this.NoiDungYeuCau = noidungyeucau;
            this.GhiChu = ghichu;
        }

        public YeuCauDTO(DataRow row)
        {
            this.Id_YeuCau = Int32.Parse(row["ID_YeuCau"].ToString());
            this.MaYeuCau = row["MaYeuCau"].ToString();            
            this.TenYeuCau = row["TenYeuCau"].ToString();
            this.NoiDungYeuCau = row["NoiDungYeuCau"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
