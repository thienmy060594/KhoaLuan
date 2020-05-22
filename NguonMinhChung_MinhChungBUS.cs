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
    class NguonMinhChung_MinhChungBUS
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
            string query = "SELECT * FROM dbo.NguonMinhChung_MinhChung";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NguonMinhChung_MinhChungDTO nguonMinhChung_MinhChung = new NguonMinhChung_MinhChungDTO(dataRow);
                List.Add(nguonMinhChung_MinhChung);
            }
            return List;
        }
        public bool InsertNguonMinhChung_MinhChung(int id_nguonminhchung, int id_minhchung, string ghichu)
        {
            string query = string.Format("INSERT dbo.NguonMinhChung_MinhChung (ID_NguonMinhChung, ID_MinhChung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_nguonminhchung, id_minhchung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
