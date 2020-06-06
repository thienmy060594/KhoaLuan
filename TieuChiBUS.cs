using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KiemDinhChatLuongDAL;
using KiemDinhChatLuongDTO;

namespace KiemDinhChatLuongBUS
{
    public class TieuChiBUS
    {
        private static TieuChiBUS instance;

        public static TieuChiBUS Instance
        {
            get { if (instance == null) instance = new TieuChiBUS(); return TieuChiBUS.instance; }
            private set { TieuChiBUS.instance = value; }
        }

        private TieuChiBUS() { }

        public List<TieuChiDTO> GetListTieuChi()
        {
            List<TieuChiDTO> List = new List<TieuChiDTO>();
            string query = "SELECT TChi.ID_TieuChi, TChuan.ID_TieuChuan, TChuan.MaTieuChuan, TChuan.TenTieuChuan, TChi.MaTieuChi, TChi.TenTieuChi, TChi.NoiDungTieuChi, TChi.GhiChu " +
                           "FROM dbo.TieuChuan TChuan, dbo.TieuChi TChi " +
                           "WHERE TChuan.ID_TieuChuan = TChi.ID_TieuChuan";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChiDTO tieuChi = new TieuChiDTO(dataRow);
                List.Add(tieuChi);
            }
            return List;
        }
        public bool InsertTieuChi(int id_tieuchuan, string matieuchi, string tentieuchi, string noidungtieuchi, string ghichu)
        {
            string query = string.Format("INSERT dbo.TieuChi (ID_TieuChuan, MaTieuChi, TenTieuChi, NoiDungTieuChi, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTieuChi(int id_tieuchi, int id_tieuchuan, string matieuchi, string tentieuchi, string noidungtieuchi, string ghichu)
        {
            string query = string.Format("UPDATE dbo.TieuChi SET ID_TieuChuan = N'{1}', MaTieuChi = N'{2}', TenTieuChi = N'{3}', NoiDungTieuChi = N'{4}', GhiChu = N'{5}' WHERE ID_TieuChi = N'{0}'", id_tieuchi, id_tieuchuan, matieuchi, tentieuchi, noidungtieuchi, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTieuChi(int id_tieuchi)
        {
            string query = string.Format("DELETE dbo.TieuChi WHERE ID_TieuChi = N'{0}'", id_tieuchi);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<TieuChiDTO> SearchListTieuChi(string valueToSearch)
        {
            List<TieuChiDTO> List = new List<TieuChiDTO>();
            string query = string.Format("SELECT TChi.ID_TieuChi, TChuan.ID_TieuChuan, TChuan.MaTieuChuan, TChuan.TenTieuChuan, TChi.MaTieuChi, TChi.TenTieuChi, TChi.NoiDungTieuChi, TChi.GhiChu " +
                "FROM dbo.TieuChuan TChuan, dbo.TieuChi TChi " +
                "WHERE TChuan.ID_TieuChuan = TChi.ID_TieuChuan AND CONCAT(TChi.MaTieuChi, TChi.TenTieuChi, TChi.NoiDungTieuChi, TChi.GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChiDTO tieuChi = new TieuChiDTO(dataRow);
                List.Add(tieuChi);
            }
            return List;
        }
    }
}
