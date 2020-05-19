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
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                YeuCauDTO yeuCau = new YeuCauDTO(dataRow);
                List.Add(yeuCau);
            }
            return List;
        }
        public bool InsertYeuCau(string tenyeucau, string noidungyeucau, string ghichu)
        {
            string query = string.Format("INSERT dbo.YeuCau (TenYeuCau, NoiDungYeuCau, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", tenyeucau, noidungyeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateYeuCau(int mayeucau, string tenyeucau, string noidungyeucau, string ghichu)
        {
            string query = string.Format("UPDATE dbo.YeuCau SET TenYeuCau = N'{1}', NoiDungYeuCau = N'{2}', GhiChu = N'{3}' WHERE MaYeuCau = N'{0}'", mayeucau, tenyeucau, noidungyeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteYeuCau(int mayeucau)
        {
            string query = string.Format("DELETE dbo.YeuCau WHERE MaYeuCau= N'{0}'", mayeucau);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //public List<YeuCauDTO> SearchListYeuCau(string mayeucau)
        //{
        //    List<YeuCauDTO> List = new List<YeuCauDTO>();
        //    string query = string.Format("SELECT * FROM dbo.YeuCau WHERE MaYeuCau LIKE N'%' + N'" + mayeucau + "' + '%'");
        //    DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //    foreach (DataRow dataRow in data.Rows)
        //    {
        //        YeuCauDTO yeuCau = new YeuCauDTO(dataRow);
        //        List.Add(yeuCau);
        //    }
        //    return List;
        //}
    }
}
