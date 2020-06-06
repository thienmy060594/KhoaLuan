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
    public class NganhBUS
    {
        private static NganhBUS instance;

        public static NganhBUS Instance
        {
            get { if (instance == null) instance = new NganhBUS(); return NganhBUS.instance; }
            private set { NganhBUS.instance = value; }
        }

        private NganhBUS() { }

        public List<NganhDTO> GetListNganh()
        {
            List<NganhDTO> List = new List<NganhDTO>();
            string query = "SELECT N.ID_Nganh, K.ID_Khoa, K.MaKhoa, K.TenKhoa, N.MaNganh, N.TenNganh, N.GhiChu " +
                           "FROM dbo.Khoa K, dbo.Nganh N " +
                           "WHERE K.ID_Khoa = N.ID_Khoa";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NganhDTO nganh = new NganhDTO(dataRow);
                List.Add(nganh);
            }
            return List;
        }
        public bool InsertNganh(int id_khoa, string manganh, string tennganh, string ghichu)
        {
            string query = string.Format("INSERT dbo.Nganh (ID_Khoa, MaNganh, TenNganh, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", id_khoa, manganh, tennganh, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNganh(int id_nganh, int id_khoa, string manganh, string tennganh, string ghichu)
        {
            string query = string.Format("UPDATE dbo.Nganh SET ID_Khoa = N'{1}', MaNganh = N'{2}', TenNganh = N'{3}', GhiChu = N'{4}' WHERE ID_Nganh = N'{0}'", id_nganh, id_khoa, manganh, tennganh, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNganh(int id_nganh)
        {
            string query = string.Format("DELETE dbo.Nganh WHERE ID_Nganh = N'{0}'", id_nganh);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<NganhDTO> SearchListNganh(string valueToSearch)
        {
            List<NganhDTO> List = new List<NganhDTO>();
            string query = string.Format("SELECT N.ID_Nganh, K.ID_Khoa, K.MaKhoa, K.TenKhoa, N.MaNganh, N.TenNganh, N.GhiChu " +
                "FROM dbo.Khoa K, dbo.Nganh N " +
                "WHERE K.ID_Khoa = N.ID_Khoa AND CONCAT(K.MaKhoa, K.TenKhoa, N.MaNganh, N.TenNganh, N.GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NganhDTO nganh = new NganhDTO(dataRow);
                List.Add(nganh);
            }
            return List;
        }
    }
}
