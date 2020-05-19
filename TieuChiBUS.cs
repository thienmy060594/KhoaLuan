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
            string query = "SELECT * FROM dbo.TieuChi";
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                TieuChiDTO tieuChi = new TieuChiDTO(dataRow);
                List.Add(tieuChi);
            }
            return List;
        }
        public bool InsertTieuChi(int matieuchuan,string tentieuchi, string noidungtieuchi, string ghichu)
        {
            string query = string.Format("INSERT dbo.TieuChi ( MaTieuChuan,TenTieuChi, NoiDungTieuChi, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", matieuchuan, tentieuchi, noidungtieuchi, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTieuChi(int matieuchi, int matieuchuan, string tentieuchi, string noidungtieuchi, string ghichu)
        {
            string query = string.Format("UPDATE dbo.TieuChi SET MaTieuChuan = N'{1}', TenTieuChi = N'{2}', NoiDungTieuChi = N'{3}', GhiChu = N'{4}' WHERE MaTieuChi = N'{0}'",matieuchi, matieuchuan, tentieuchi, noidungtieuchi, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTieuChi(int matieuchi)
        {
            string query = string.Format("DELETE dbo.TieuChi WHERE MaTieuChi= N'{0}'", matieuchi);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //public List<TieuChiDTO> SearchListTieuChi(string matieuchi)
        //{
        //    List<TieuChiDTO> List = new List<TieuChiDTO>();
        //    string query = string.Format("SELECT * FROM dbo.TieuChi WHERE MaTieuChi LIKE N'%' + N'" + matieuchi + "' + '%'");
        //    DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //    foreach (DataRow dataRow in data.Rows)
        //    {
        //        TieuChiDTO tieuChi = new TieuChiDTO(dataRow);
        //        List.Add(tieuChi);
        //    }
        //        return List;
        //}
    }
}
