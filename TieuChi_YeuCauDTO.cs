using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace KiemDinhChatLuongDTO
{
    public class TieuChi_YeuCauDTO
    {
        private int id_tieuchi;
        private int id_yeucau;       
        private string matieuchi;
        private string tentieuchi;
        private string mayeucau;
        private string tenyeucau;
        private string ghichu;

        public int Id_TieuChi { get => id_tieuchi; set => id_tieuchi = value; }
        public int Id_YeuCau { get => id_yeucau; set => id_yeucau = value; }        
        public string MaTieuChi { get => matieuchi; set => matieuchi = value; }
        public string TenTieuChi { get => tentieuchi; set => tentieuchi = value; }
        public string MaYeuCau { get => mayeucau; set => mayeucau = value; }
        public string TenYeuCau { get => tenyeucau; set => tenyeucau = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }

        public TieuChi_YeuCauDTO(int id_tieuchi, int id_yeucau, string matieuchi, string tentieuchi, string mayeucau, string tenyeucau, string ghichu)
        {
            this.Id_TieuChi = id_tieuchi;
            this.Id_YeuCau = id_yeucau;            
            this.MaTieuChi = matieuchi;
            this.TenTieuChi = tentieuchi;
            this.MaYeuCau = mayeucau;
            this.TenYeuCau = tenyeucau;            
            this.GhiChu = ghichu;
        }

        public TieuChi_YeuCauDTO(DataRow row)
        {
            this.Id_TieuChi = Int32.Parse(row["ID_TieuChi"].ToString());
            this.Id_YeuCau = Int32.Parse(row["ID_YeuCau"].ToString());            
            this.MaTieuChi = row["MaTieuChi"].ToString();
            this.TenTieuChi = row["TenTieuChi"].ToString();
            this.MaYeuCau = row["MaYeuCau"].ToString();
            this.TenYeuCau = row["TenYeuCau"].ToString();
            this.GhiChu = row["GhiChu"].ToString();
        }
    }
}
