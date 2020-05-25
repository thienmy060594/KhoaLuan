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
    public class MonHocBUS
    {
        private static MonHocBUS instance;

        public static MonHocBUS Instance
        {
            get { if (instance == null) instance = new MonHocBUS(); return MonHocBUS.instance; }
            private set { MonHocBUS.instance = value; }
        }

        private MonHocBUS() { }

        public List<MonHocDTO> GetListMonHoc()
        {
            List<MonHocDTO> List = new List<MonHocDTO>();
            string query = "SELECT * FROM dbo.MonHoc";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MonHocDTO monHoc = new MonHocDTO(dataRow);
                List.Add(monHoc);
            }
            return List;
        }
        public bool InsertMonHoc(string mamonhoc, string tenmonhoc, int sotinchi, int sotietlythuyet, int sotietthuchanh, string ghichu)
        {
            string query = string.Format("INSERT dbo.MonHoc (MaMonHoc, TenMonHoc, SoTinChi, SoTietLyThuyet, SoTietThucHanh, GhiChu) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", mamonhoc, tenmonhoc, sotinchi, sotietlythuyet, sotietthuchanh, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMonHoc(int id_monhoc, string mamonhoc, string tenmonhoc, int sotinchi, int sotietlythuyet, int sotietthuchanh, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MonHoc SET MaMonHoc =N'{1}', TenMonHoc = N'{2}', SoTinChi = N'{3}', SoTietLyThuyet = N'{4}', SoTietThucHanh = N'{5}', GhiChu = N'{6}' WHERE ID_MonHoc = N'{0}'", id_monhoc, mamonhoc, tenmonhoc, sotinchi, sotietlythuyet, sotietthuchanh, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMonHoc(int id_monhoc)
        {
            string query = string.Format("DELETE dbo.MonHoc WHERE ID_MonHoc = N'{0}'", id_monhoc);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
