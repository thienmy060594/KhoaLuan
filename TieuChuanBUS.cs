using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiemDinhChatLuongDAL;
using KiemDinhChatLuongDTO;

namespace KiemDinhChatLuongBUS
{
    public class TieuChuanBUS
    {
        private static TieuChuanBUS instance;

        public static TieuChuanBUS Instance
        {
            get { if (instance == null) instance = new TieuChuanBUS(); return TieuChuanBUS.instance; }
            private set { TieuChuanBUS.instance = value; }
        }

        private TieuChuanBUS() { }

        public List<TieuChuanDTO> GetListTieuChuan()
        {
            List<TieuChuanDTO> List = new List<TieuChuanDTO>();
            string query = "SELECT * FROM dbo.TieuChuan";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChuanDTO tieuChuan = new TieuChuanDTO(dataRow);
                List.Add(tieuChuan);
            }
            return List;
        }
        public bool InsertTieuChuan(string matieuchuan, string tentieuchuan, string noidungtieuchuan, string ghichu)
        {
            string query = string.Format("INSERT dbo.TieuChuan (MaTieuChuan, TenTieuChuan, NoiDungTieuChuan, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", matieuchuan, tentieuchuan, noidungtieuchuan, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTieuChuan(int id_tieuchuan, string matieuchuan, string tentieuchuan, string noidungtieuchuan, string ghichu)
        {
            string query = string.Format("UPDATE dbo.TieuChuan SET MaTieuChuan =N'{1}', TenTieuChuan = N'{2}', NoiDungTieuChuan = N'{3}', GhiChu = N'{4}' WHERE ID_TieuChuan = N'{0}'", id_tieuchuan, matieuchuan, tentieuchuan, noidungtieuchuan, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTieuChuan(int id_tieuchuan)
        {
            string query = string.Format("DELETE dbo.TieuChuan WHERE ID_TieuChuan = N'{0}'", id_tieuchuan);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
        
        public List<TieuChuanDTO> SearchListTieuChuan(string valueToSearch)
        {
            List<TieuChuanDTO> List = new List<TieuChuanDTO>();
            string query = string.Format("SELECT * FROM dbo.TieuChuan WHERE CONCAT(MaTieuChuan, TenTieuChuan, NoiDungTieuChuan, GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChuanDTO tieuChuan = new TieuChuanDTO(dataRow);
                List.Add(tieuChuan);
            }
            return List;
        }
    }
}
