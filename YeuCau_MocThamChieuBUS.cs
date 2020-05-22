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
    public class YeuCau_MocThamChieuBUS
    {
        private static YeuCau_MocThamChieuBUS instance;

        public static YeuCau_MocThamChieuBUS Instance
        {
            get { if (instance == null) instance = new YeuCau_MocThamChieuBUS(); return YeuCau_MocThamChieuBUS.instance; }
            private set { YeuCau_MocThamChieuBUS.instance = value; }
        }

        private YeuCau_MocThamChieuBUS() { }

        public List<YeuCau_MocThamChieuDTO> GetListYeuCau_MocThamChieu()
        {
            List<YeuCau_MocThamChieuDTO> List = new List<YeuCau_MocThamChieuDTO>();
            string query = "SELECT * FROM dbo.YeuCau_MocThamChieu";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                YeuCau_MocThamChieuDTO yeuCau_MocThamChieu = new YeuCau_MocThamChieuDTO(dataRow);
                List.Add(yeuCau_MocThamChieu);
            }
            return List;
        }
        public bool InsertYeuCau_MocThamChieu(int id_yeucau, int id_mocthamchieu, string ghichu)
        {
            string query = string.Format("INSERT dbo.YeuCau_MocThamChieu (ID_YeuCau, ID_MocThamChieu, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_yeucau, id_mocthamchieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
