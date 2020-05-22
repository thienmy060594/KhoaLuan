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
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MocThamChieuDTO mocThamChieu = new MocThamChieuDTO(dataRow);
                List.Add(mocThamChieu);
            }
            return List;
        }
        public bool InsertMocThamChieu(string mamocthamchieu, string tenmocthamchieu, string noidungmocthamchieu, string ghichu)
        {
            string query = string.Format("INSERT dbo.MocThamChieu (MaMocThamChieu, TenMocThamChieu, NoiDungMocThamChieu, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", mamocthamchieu,tenmocthamchieu, noidungmocthamchieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMocThamChieu(int id_mocthamchieu, string mamocthamchieu, string tenmocthamchieu, string noidungmocthamchieu, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MocThamChieu SET MaMocThamChieu = N'{1}', TenMocThamChieu = N'{2}', NoiDungMocThamChieu = N'{3}', GhiChu = N'{4}' WHERE ID_MocThamChieu = N'{0}'", id_mocthamchieu, mamocthamchieu, tenmocthamchieu, noidungmocthamchieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMocThamChieu(int id_mocthamchieu)
        {
            string query = string.Format("DELETE dbo.MocThamChieu WHERE ID_MocThamChieu= N'{0}'", id_mocthamchieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
