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
    public class LoaiMonBUS
    {
        private static LoaiMonBUS instance;

        public static LoaiMonBUS Instance
        {
            get { if (instance == null) instance = new LoaiMonBUS(); return LoaiMonBUS.instance; }
            private set { LoaiMonBUS.instance = value; }
        }

        private LoaiMonBUS() { }

        public List<LoaiMonDTO> GetListLoaiMon()
        {
            List<LoaiMonDTO> List = new List<LoaiMonDTO>();
            string query = "SELECT * FROM dbo.LoaiMon";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                LoaiMonDTO loaiMon = new LoaiMonDTO(dataRow);
                List.Add(loaiMon);
            }
            return List;
        }
        public bool InsertLoaiMon(string maloaimon, string tenloaimon, string ghichu)
        {
            string query = string.Format("INSERT dbo.LoaiMon (MaLoaiMon, TenLoaiMon, GhiChu) VALUES (N'{0}', N'{1}', N'{2}')", maloaimon, tenloaimon, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateLoaiMon(int id_loaimon, string maloaimon, string tenloaimon, string ghichu)
        {
            string query = string.Format("UPDATE dbo.Khoa SET MaLoaiMon =N'{1}', TenLoaiMon = N'{2}', GhiChu = N'{3}' WHERE ID_LoaiMon = N'{0}'", id_loaimon, maloaimon, tenloaimon, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteLoaiMon(int id_loaimon)
        {
            string query = string.Format("DELETE dbo.LoaiMon WHERE ID_LoaiMon = N'{0}'", id_loaimon);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<LoaiMonDTO> SearchListLoaiMon(string valueToSearch)
        {
            List<LoaiMonDTO> List = new List<LoaiMonDTO>();
            string query = string.Format("SELECT * FROM dbo.LoaiMon WHERE CONCAT(MaLoaiMon, TenLoaiMon, GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                LoaiMonDTO loaiMon = new LoaiMonDTO(dataRow);
                List.Add(loaiMon);
            }
            return List;
        }
    }
}
