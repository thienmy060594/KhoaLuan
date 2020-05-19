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
    public class MinhChungBUS
    {
        private static MinhChungBUS instance;

        public static MinhChungBUS Instance
        {
            get { if (instance == null) instance = new MinhChungBUS(); return MinhChungBUS.instance; }
            private set { MinhChungBUS.instance = value; }
        }

        private MinhChungBUS() { }

        public List<MinhChungDTO> GetListMinhChung()
        {
            List<MinhChungDTO> List = new List<MinhChungDTO>();
            string query = "SELECT * FROM dbo.MinhChung";
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                MinhChungDTO minhChung = new MinhChungDTO(dataRow);
                List.Add(minhChung);
            }
            return List;
        }
        public bool InsertMinhChung(string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string duonglink, string ghichu)
        {
            string query = string.Format("INSERT dbo.MinhChung (TenTaiLieu, NgayKy, NguoiKy, SoBanHanh, TomTatNoiDung, DuongLink, GhiChu) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, duonglink, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMinhChung(int matailieu, string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string duonglink, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MinhChung SET TenTaiLieu = N'{1}', NgayKy = N'{2}', NguoiKy = N'{3}', SoBanHanh = N'{4}', TomTatNoiDung = N'{5}', DuongLink = N'{6}', GhiChu = N'{7}'  WHERE MaTaiLieu = N'{0}'", matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, duonglink, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMinhChung(int matailieu)
        {
            string query = string.Format("DELETE dbo.MinhChung WHERE MaTaiLieu= N'{0}'", matailieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //public List<MinhChungDTO> SearchListMinhChung(string maminhchung)
        //{
        //    List<MinhChungDTO> List = new List<MinhChungDTO>();
        //    string query = string.Format("SELECT * FROM dbo.MinhChung WHERE MaMinhChung LIKE N'%' + N'" + maminhchung + "' + '%'");
        //    DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //    foreach (DataRow dataRow in data.Rows)
        //    {
        //        MinhChungDTO minhChung = new MinhChungDTO(dataRow);
        //        List.Add(minhChung);
        //    }
        //    return List;
        //}
    }
}
