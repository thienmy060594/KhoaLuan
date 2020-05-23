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
    public class NguonMinhChungBUS
    {
        private static NguonMinhChungBUS instance;

        public static NguonMinhChungBUS Instance
        {
            get { if (instance == null) instance = new NguonMinhChungBUS(); return NguonMinhChungBUS.instance; }
            private set { NguonMinhChungBUS.instance = value; }
        }

        private NguonMinhChungBUS() { }

        public List<NguonMinhChungDTO> GetListNguonMinhChung()
        {
            List<NguonMinhChungDTO> List = new List<NguonMinhChungDTO>();
            string query = "SELECT * FROM dbo.NguonMinhChung";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NguonMinhChungDTO nguonMinhChung = new NguonMinhChungDTO(dataRow);
                List.Add(nguonMinhChung);
            }
            return List;
        }
        public bool InsertNguonMinhChung(string manguonminhchung, string tennguonminhchung, string noidungnguonminhchung, string ghichu)
        {
            string query = string.Format("INSERT dbo.NguonMinhChung (MaNguonMinhChung, TenNguonMinhChung, NoiDungNguonMinhChung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNguonMinhChung(int id_nguonminhchung, string manguonminhchung, string tennguonminhchung, string noidungnguonminhchung, string ghichu)
        {
            string query = string.Format("UPDATE dbo.NguonMinhChung SET MaNguonMinhChung = N'{1}', TenNguonMinhChung = N'{2}', NoiDungNguonMinhChung = N'{3}', GhiChu = N'{4}' WHERE ID_NguonMinhChung = N'{0}'", id_nguonminhchung, manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNguonMinhChung(int id_nguonminhchung)
        {
            string query = string.Format("DELETE dbo.NguonMinhChung WHERE ID_NguonMinhChung = N'{0}'", id_nguonminhchung);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }        
    }
}
