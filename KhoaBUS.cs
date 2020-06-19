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
    public class KhoaBUS
    {
        private static KhoaBUS instance;

        public static KhoaBUS Instance
        {
            get { if (instance == null) instance = new KhoaBUS(); return KhoaBUS.instance; }
            private set { KhoaBUS.instance = value; }
        }

        private KhoaBUS() { }

        public List<KhoaDTO> GetListKhoa()
        {
            List<KhoaDTO> List = new List<KhoaDTO>();
            string query = "SELECT * FROM dbo.Khoa";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                KhoaDTO khoa = new KhoaDTO(dataRow);
                List.Add(khoa);
            }
            return List;
        }
        public bool InsertKhoa(string makhoa, string tenkhoa, string ghichu)
        {
            string query = string.Format("INSERT dbo.Khoa (MaKhoa, TenKhoa, GhiChu) VALUES (N'{0}', N'{1}', N'{2}')", makhoa, tenkhoa, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateKhoa(int id_khoa, string makhoa, string tenkhoa, string ghichu)
        {
            string query = string.Format("UPDATE dbo.Khoa SET MaKhoa =N'{1}', TenKhoa = N'{2}', GhiChu = N'{3}' WHERE ID_Khoa = N'{0}'", id_khoa, makhoa, tenkhoa, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteKhoa(int id_khoa)
        {
            string query = string.Format("DELETE dbo.Khoa WHERE ID_Khoa = N'{0}'", id_khoa);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<KhoaDTO> SearchListKhoa(string valueToSearch)
        {
            List<KhoaDTO> List = new List<KhoaDTO>();
            string query = string.Format("SELECT * FROM dbo.Khoa WHERE CONCAT(MaKhoa, TenKhoa, GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                KhoaDTO khoa = new KhoaDTO(dataRow);
                List.Add(khoa);
            }
            return List;
        }
    }
}
