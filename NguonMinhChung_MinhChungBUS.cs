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
    public class NguonMinhChung_MinhChungBUS
    {
        private static NguonMinhChung_MinhChungBUS instance;

        public static NguonMinhChung_MinhChungBUS Instance
        {
            get { if (instance == null) instance = new NguonMinhChung_MinhChungBUS(); return NguonMinhChung_MinhChungBUS.instance; }
            private set { NguonMinhChung_MinhChungBUS.instance = value; }
        }

        private NguonMinhChung_MinhChungBUS() { }

        public List<NguonMinhChung_MinhChungDTO> GetListNguonMinhChung_MinhChung()
        {
            List<NguonMinhChung_MinhChungDTO> List = new List<NguonMinhChung_MinhChungDTO>();
            string query = "SELECT NMChungMChung.ID_NguonMinhChung, NMChungMChung.ID_TaiLieu, NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, MChung.MaTaiLieu, MChung.TenTaiLieu, NMChungMChung.GhiChu " +
                           "FROM dbo.NguonMinhChung_MinhChung NMChungMChung, dbo.NguonMinhChung NMChung, dbo.MinhChung MChung " +
                           "WHERE NMChung.ID_NguonMinhChung = MChung.ID_TaiLieu";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NguonMinhChung_MinhChungDTO nguonMinhChung_MinhChung = new NguonMinhChung_MinhChungDTO(dataRow);
                List.Add(nguonMinhChung_MinhChung);
            }
            return List;
        }
        public bool InsertNguonMinhChung_MinhChung(int id_nguonminhchung, int id_tailieu, string ghichu)
        {
            string query = string.Format("INSERT dbo.NguonMinhChung_MinhChung (ID_NguonMinhChung, ID_TaiLieu, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_nguonminhchung, id_tailieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNguonMinhChung_MinhChung(int id_nguonminhchung, int id_tailieu)
        {
            string query = string.Format("DELETE dbo.YeuCau_MocThamChieu WHERE ID_YeuCau = N'{0}' AND ID_MocThamChieu = N'{1}' ", id_nguonminhchung, id_tailieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
