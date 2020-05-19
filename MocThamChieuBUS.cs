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
    public class MocThamChieuBUS
    {
        private static MocThamChieuBUS instance;

        public static MocThamChieuBUS Instance
        {
            get { if (instance == null) instance = new MocThamChieuBUS(); return MocThamChieuBUS.instance; }
            private set { MocThamChieuBUS.instance = value; }
        }

        private MocThamChieuBUS() { }

        public List<MocThamChieuDTO> GetListMocThamChieu()
        {
            List<MocThamChieuDTO> List = new List<MocThamChieuDTO>();
            string query = "SELECT * FROM dbo.MocThamChieu";
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                MocThamChieuDTO mocThamChieu = new MocThamChieuDTO(dataRow);
                List.Add(mocThamChieu);
            }
            return List;
        }
        public bool InsertMocThamChieu(string tenmocthamchieu, string noidungmocthamchieu, string ghichu)
        {
            string query = string.Format("INSERT dbo.MocThamChieu (TenMocThamChieu, NoiDungMocThamChieu, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')",tenmocthamchieu, noidungmocthamchieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMocThamChieu(int mamocthamchieu, string tenmocthamchieu, string noidungmocthamchieu, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MocThamChieu SET TenMocThamChieu = N'{1}', NoiDungMocThamChieu = N'{2}', GhiChu = N'{3}' WHERE MaMocThamChieu = N'{0}'", mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMocThamChieu(int mamocthamchieu)
        {
            string query = string.Format("DELETE dbo.MocThamChieu WHERE MaMocThamChieu= N'{0}'", mamocthamchieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //    public List<MocThamChieuDTO> SearchListMocThamChieu(string mamocthamchieu)
        //    {
        //        List<MocThamChieuDTO> List = new List<MocThamChieuDTO>();
        //        string query = string.Format("SELECT * FROM dbo.MocThamChieu WHERE MaTieuChi LIKE N'%' + N'" + mamocthamchieu + "' + '%'");
        //        DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //        foreach (DataRow dataRow in data.Rows)
        //        {
        //            MocThamChieuDTO mocThamChieu = new MocThamChieuDTO(dataRow);
        //            List.Add(mocThamChieu);
        //        }
        //        return List;
        //    }
        //}
    }
}
