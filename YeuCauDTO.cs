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
        private int mayeucau;        
        private string tenyeucau;
        private string noidungyeucau;
        private string ghichu;

        public int MaYeuCau { get => mayeucau; set => mayeucau = value; }        

        public string TenYeuCau { get => tenyeucau; set => tenyeucau = value; }

        public string NoiDungYeuCau { get => noidungyeucau; set => noidungyeucau = value; }

        public string GhiChu { get => ghichu; set => ghichu = value; }

        public YeuCauDTO(int mayeucau, string tenyeucau, string noidungyeucau, string ghichu)
        {
            this.MaYeuCau = mayeucau;            
            this.TenYeuCau = tenyeucau;
            this.NoiDungYeuCau = noidungyeucau;
            this.GhiChu = ghichu;
        }

        public YeuCauDTO(DataRow row)
        {
            this.MaYeuCau = Int32.Parse(row["MaYeuCau"].ToString());            
            this.TenYeuCau = row["TenYeuCau"].ToString();
            this.NoiDungYeuCau = row["NoiDungYeuCau"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
