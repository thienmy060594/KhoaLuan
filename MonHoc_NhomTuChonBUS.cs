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
    public class MonHoc_NhomTuChonBUS
    {
        private static MonHoc_NhomTuChonBUS instance;

        public static MonHoc_NhomTuChonBUS Instance
        {
            get { if (instance == null) instance = new MonHoc_NhomTuChonBUS(); return MonHoc_NhomTuChonBUS.instance; }
            private set { MonHoc_NhomTuChonBUS.instance = value; }
        }

        private MonHoc_NhomTuChonBUS() { }

        public List<MonHoc_NhomTuChonDTO> GetListMonHoc_NhomTuChon()
        {
            List<MonHoc_NhomTuChonDTO> List = new List<MonHoc_NhomTuChonDTO>();
            string query = "SELECT MHocMTChon.ID_MonHoc, MHocMTChon.ID_NhomTuChon, MHoc.MaMonHoc, MHoc.TenMonHoc, NTChon.MaNhomTuChon, NTChon.TenNhomTuChon, MHocMTChon.GhiChu " +
                           "FROM dbo.MonHoc_NhomTuChon MHocMTChon, dbo.MonHoc MHoc, dbo.NhomTuChon NTChon " +
                           "WHERE MHocMTChon.ID_MonHoc = MHoc.ID_MonHoc AND MHocMTChon.ID_NhomTuChon = NTChon.ID_NhomTuChon";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MonHoc_NhomTuChonDTO monHoc_NhomTuChon = new MonHoc_NhomTuChonDTO(dataRow);
                List.Add(monHoc_NhomTuChon);
            }
            return List;
        }
        public bool InsertMonHoc_NhomTuChon(int id_monhoc, int id_nhomtuchon, string ghichu)
        {
            string query = string.Format("INSERT dbo.MonHoc_NhomTuChon (ID_MonHoc, ID_NhomTuChon, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_monhoc, id_nhomtuchon, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMonHoc_NhomTuChon(int id_monhoc, int id_nhomtuchon, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MonHoc_NhomTuChon SET GhiChu = N'{2}' WHERE ID_MonHoc = N'{0}' AND ID_NhomTuChon = N'{1}'", id_monhoc, id_nhomtuchon, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMonHoc_NhomTuChon(int id_monhoc, int id_nhomtuchon)
        {
            string query = string.Format("DELETE dbo.MonHoc_NhomTuChon WHERE ID_MonHoc = N'{0}' AND ID_NhomTuChon = N'{1}'", id_monhoc, id_nhomtuchon);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<MonHoc_NhomTuChonDTO> SearchListMonHoc_NhomTuChon(string valueToSearch)
        {
            List<MonHoc_NhomTuChonDTO> List = new List<MonHoc_NhomTuChonDTO>();
            string query = string.Format("SELECT MHocMTChon.ID_MonHoc, MHocMTChon.ID_NhomTuChon, MHoc.MaMonHoc, MHoc.TenMonHoc, NTChon.MaNhomTuChon, NTChon.TenNhomTuChon, MHocMTChon.GhiChu " +
                "FROM dbo.MonHoc_NhomTuChon MHocMTChon, dbo.MonHoc MHoc, dbo.NhomTuChon NTChon " +
                "WHERE MHocMTChon.ID_MonHoc = MHoc.ID_MonHoc AND MHocMTChon.ID_NhomTuChon = NTChon.ID_NhomTuChon AND CONCAT(MHoc.MaMonHoc, MHoc.TenMonHoc, NTChon.MaNhomTuChon, NTChon.TenNhomTuChon, MHocMTChon.GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MonHoc_NhomTuChonDTO monHoc_NhomTuChon = new MonHoc_NhomTuChonDTO(dataRow);
                List.Add(monHoc_NhomTuChon);
            }
            return List;
        }
    }
}
