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
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                NguonMinhChungDTO nguonMinhChung = new NguonMinhChungDTO(dataRow);
                List.Add(nguonMinhChung);
            }
            return List;
        }
        public bool InsertNguonMinhChung(string tennguonminhchung, string noidungnguonminhchung, string ghichu)
        {
            string query = string.Format("INSERT dbo.NguonMinhChung (TenNguonMinhChung, NoiDungNguonMinhChung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", tennguonminhchung, noidungnguonminhchung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNguonMinhChung(int manguonminhchung, string tennguonminhchung, string noidungnguonminhchung, string ghichu)
        {
            string query = string.Format("UPDATE dbo.NguonMinhChung SET TenNguonMinhChung = N'{1}', NoiDungNguonMinhChung = N'{2}', GhiChu = N'{3}' WHERE MaNguonMinhChung = N'{0}'", manguonminhchung, tennguonminhchung, noidungnguonminhchung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNguonMinhChung(int manguonminhchung)
        {
            string query = string.Format("DELETE dbo.NguonMinhChung WHERE MaNguonMinhChung= N'{0}'", manguonminhchung);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //public List<NguonMinhChungDTO> SearchListNguonMinhChung(string manguonminhchung)
        //{
        //    List<NguonMinhChungDTO> List = new List<NguonMinhChungDTO>();
        //    string query = string.Format("SELECT * FROM dbo.NguonMinhChung WHERE MaNguonMinhChung LIKE N'%' + N'" + manguonminhchung + "' + '%'");
        //    DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //    foreach (DataRow dataRow in data.Rows)
        //    {
        //        NguonMinhChungDTO nguonMinhChung = new NguonMinhChungDTO(dataRow);
        //        List.Add(nguonMinhChung);
        //    }
        //    return List;
        //}
    }
}
