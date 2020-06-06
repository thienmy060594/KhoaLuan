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
                           "WHERE NMChungMChung.ID_NguonMinhChung = NMChung.ID_NguonMinhChung AND NMChungMChung.ID_TaiLieu = MChung.ID_TaiLieu";
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

        public bool UpdateNguonMinhChung_MinhChung(int id_nguonminhchung, int id_tailieu, string ghichu)
        {
            string query = string.Format("UPDATE dbo.NguonMinhChung_MinhChung SET GhiChu = N'{2}' WHERE ID_NguonMinhChung = N'{0}' AND ID_TaiLieu = N'{1}'", id_nguonminhchung, id_tailieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNguonMinhChung_MinhChung(int id_nguonminhchung, int id_tailieu)
        {
            string query = string.Format("DELETE dbo.NguonMinhChung_MinhChung WHERE ID_NguonMinhChung = N'{0}' AND ID_TaiLieu = N'{1}'", id_nguonminhchung, id_tailieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<NguonMinhChung_MinhChungDTO> SearchListNguonMinhChung_MinhChung(string valueToSearch)
        {
            List<NguonMinhChung_MinhChungDTO> List = new List<NguonMinhChung_MinhChungDTO>();
            string query = string.Format("SELECT NMChungMChung.ID_NguonMinhChung, NMChungMChung.ID_TaiLieu, NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, MChung.MaTaiLieu, MChung.TenTaiLieu, NMChungMChung.GhiChu " +
                "FROM dbo.NguonMinhChung_MinhChung NMChungMChung, dbo.NguonMinhChung NMChung, dbo.MinhChung MChung " +
                "WHERE NMChungMChung.ID_NguonMinhChung = NMChung.ID_NguonMinhChung AND NMChungMChung.ID_TaiLieu = MChung.ID_TaiLieu AND CONCAT(NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, MChung.MaTaiLieu, MChung.TenTaiLieu, NMChungMChung.GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NguonMinhChung_MinhChungDTO nguonMinhChung_MinhChung = new NguonMinhChung_MinhChungDTO(dataRow);
                List.Add(nguonMinhChung_MinhChung);
            }
            return List;
        }
    }
}
