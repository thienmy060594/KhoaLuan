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
    public class MonTienQuyetBUS
    {
        private static MonTienQuyetBUS instance;

        public static MonTienQuyetBUS Instance
        {
            get { if (instance == null) instance = new MonTienQuyetBUS(); return MonTienQuyetBUS.instance; }
            private set { MonTienQuyetBUS.instance = value; }
        }

        private MonTienQuyetBUS() { }

        public List<MonTienQuyetDTO> GetListMonTienQuyet()
        {
            List<MonTienQuyetDTO> List = new List<MonTienQuyetDTO>();
            string query = "SELECT MTQuyet.ID_MonHoc, MTQuyet.ID_MonHoc_TienQuyet, MHoc1.MaMonHoc, MHoc1.TenMonHoc, MHoc2.MaMonHoc AS MaMonHocTienQuyet, MHoc2.TenMonHoc AS TenMonHocTienQuyet, MTQuyet.GhiChu  " +
                           "FROM dbo.MonTienQuyet MTQuyet, dbo.MonHoc MHoc1, dbo.MonHoc MHoc2 " +
                           "WHERE MTQuyet.ID_MonHoc = MHoc1.ID_MonHoc AND MTQuyet.ID_MonHoc_TienQuyet = MHoc2.ID_MonHoc";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MonTienQuyetDTO monTienQuyet = new MonTienQuyetDTO(dataRow);
                List.Add(monTienQuyet);
            }
            return List;
        }
        public bool InsertMonTienQuyet(int id_monhoc, int id_monhoc_tienquyet, string ghichu)
        {
            string query = string.Format("INSERT dbo.MonTienQuyet (ID_MonHoc, ID_MonHoc_TienQuyet, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_monhoc, id_monhoc_tienquyet, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMonTienQuyet(int id_monhoc, int id_monhoc_tienquyet, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MonTienQuyet SET ID_MonHoc = N'{1}', ID_MonHoc_TienQuyet = N'{2}' WHERE ID_ChuongTrinhDaoTao = N'{0}'", id_monhoc, id_monhoc_tienquyet, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMonTienQuyet(int id_monhoc, int id_monhoc_tienquyet)
        {
            string query = string.Format("DELETE dbo.MonTienQuyet WHERE ID_MonHoc = N'{0}' AND ID_MonHoc_TienQuyet = N'{1}'",id_monhoc, id_monhoc_tienquyet);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<MonTienQuyetDTO> SearchListMonTienQuyet(string valueToSearch)
        {
            List<MonTienQuyetDTO> List = new List<MonTienQuyetDTO>();
            string query = string.Format("SELECT MTQuyet.ID_MonHoc, MTQuyet.ID_MonHoc_TienQuyet, MHoc1.MaMonHoc, MHoc1.TenMonHoc, MHoc2.MaMonHoc AS MaMonHocTienQuyet, MHoc2.TenMonHoc AS TenMonHocTienQuyet, MTQuyet.GhiChu " +
                "FROM dbo.MonTienQuyet MTQuyet, dbo.MonHoc MHoc1, dbo.MonHoc MHoc2 " +
                "WHERE MTQuyet.ID_MonHoc = MHoc1.ID_MonHoc AND MTQuyet.ID_MonHoc_TienQuyet = MHoc2.ID_MonHoc AND CONCAT(MHoc1.MaMonHoc, MHoc1.TenMonHoc, MHoc2.MaMonHoc AS MaMonHocTienQuyet, MHoc2.TenMonHoc AS TenMonHocTienQuyet, MTQuyet.GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MonTienQuyetDTO monTienQuyet = new MonTienQuyetDTO(dataRow);
                List.Add(monTienQuyet);
            }
            return List;
        }
    }
}
