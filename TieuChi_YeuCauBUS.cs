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
    public class TieuChi_YeuCauBUS
    {
        private static TieuChi_YeuCauBUS instance;

        public static TieuChi_YeuCauBUS Instance
        {
            get { if (instance == null) instance = new TieuChi_YeuCauBUS(); return TieuChi_YeuCauBUS.instance; }
            private set { TieuChi_YeuCauBUS.instance = value; }
        }

        private TieuChi_YeuCauBUS() { }

        public List<TieuChi_YeuCauDTO> GetListTieuChi_YeuCau()
        {
            List<TieuChi_YeuCauDTO> List = new List<TieuChi_YeuCauDTO>();
            string query = "SELECT TChiYCau.ID_TieuChi, TChiYCau.ID_YeuCau, TChi.TenTieuChi, TChi.NoiDungTieuChi, YCau.TenYeuCau, YCau.NoiDungYeuCau, TChiYCau.GhiChu " +
                            "FROM dbo.TieuChi_YeuCau TChiYCau, dbo.TieuChi TChi, dbo.YeuCau YCau " +
                            "WHERE TChiYCau.ID_TieuChi = TChi.ID_TieuChi AND TChiYCau.ID_YeuCau = YCau.ID_YeuCau ";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChi_YeuCauDTO tieuChi_YeuCau = new TieuChi_YeuCauDTO(dataRow);
                List.Add(tieuChi_YeuCau);
            }
            return List;
        }
        public bool InsertTieuChi_YeuCau(int id_tieuchi, int id_yeucau, string ghichu)
        {
            string query = string.Format("INSERT dbo.TieuChi_YeuCau (ID_TieuChi, ID_YeuCau, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_tieuchi, id_yeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTieuChi_YeuCau(int id_tieuchi, int id_yeucau, string ghichu)
        {
            string query = string.Format("UPDATE dbo.TieuChi_YeuCau SET GhiChu = N'{2}' WHERE ID_TieuChi = N'{0}' AND ID_YeuCau = N'{1}'", id_tieuchi, id_yeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTieuChi_YeuCau(int id_tieuchi, int id_yeucau)
        {
            string query = string.Format("DELETE dbo.TieuChi_YeuCau WHERE ID_TieuChi = N'{0}' AND ID_YeuCau = N'{1}'", id_tieuchi, id_yeucau);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<TieuChi_YeuCauDTO> SearchListTieuChi_YeuCau(string valueToSearch)
        {
            List<TieuChi_YeuCauDTO> List = new List<TieuChi_YeuCauDTO>();
            string query = string.Format("SELECT TChiYCau.ID_TieuChi, TChiYCau.ID_YeuCau, TChi.MaTieuChi, TChi.TenTieuChi, YCau.MaYeuCau, YCau.TenYeuCau, TChiYCau.GhiChu " +
                "FROM dbo.TieuChi_YeuCau TChiYCau, dbo.TieuChi TChi, dbo.YeuCau YCau " +
                "WHERE TChiYCau.ID_TieuChi = TChi.ID_TieuChi AND TChiYCau.ID_YeuCau = YCau.ID_YeuCau AND CONCAT(TChi.MaTieuChi, TChi.TenTieuChi, YCau.MaYeuCau, YCau.TenYeuCau, TChiYCau.GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChi_YeuCauDTO tieuChi_YeuCau = new TieuChi_YeuCauDTO(dataRow);
                List.Add(tieuChi_YeuCau);
            }
            return List;
        }
    }
}
