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
    public class YeuCauBUS
    {
        private static YeuCauBUS instance;

        public static YeuCauBUS Instance
        {
            get { if (instance == null) instance = new YeuCauBUS(); return YeuCauBUS.instance; }
            private set { YeuCauBUS.instance = value; }
        }

        private YeuCauBUS() { }

        public List<YeuCauDTO> GetListYeuCau()
        {
            List<YeuCauDTO> List = new List<YeuCauDTO>();
            string query = "SELECT * FROM dbo.YeuCau";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                YeuCauDTO yeuCau = new YeuCauDTO(dataRow);
                List.Add(yeuCau);
            }
            return List;
        }
        public bool InsertYeuCau(string mayeucau, string tenyeucau, string noidungyeucau, string ghichu)
        {
            string query = string.Format("INSERT dbo.YeuCau (MaYeuCau, TenYeuCau, NoiDungYeuCau, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", mayeucau, tenyeucau, noidungyeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateYeuCau(int id_yeucau, string mayeucau, string tenyeucau, string noidungyeucau, string ghichu)
        {
            string query = string.Format("UPDATE dbo.YeuCau SET MaYeuCau = N'{1}', TenYeuCau = N'{2}', NoiDungYeuCau = N'{3}', GhiChu = N'{4}' WHERE ID_YeuCau = N'{0}'", id_yeucau, mayeucau, tenyeucau, noidungyeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteYeuCau(int id_yeucau)
        {
            string query = string.Format("DELETE dbo.YeuCau WHERE ID_YeuCau = N'{0}'", id_yeucau);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }        
    }
}
