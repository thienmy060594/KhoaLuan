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
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MinhChungDTO minhChung = new MinhChungDTO(dataRow);
                List.Add(minhChung);
            }
            return List;
        }
        public bool InsertMinhChung(string matailieu, string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string duonglink, string ghichu)
        {
            string query = string.Format("INSERT dbo.MinhChung (MaTaiLieu, TenTaiLieu, NgayKy, NguoiKy, SoBanHanh, TomTatNoiDung, DuongLink, GhiChu) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, duonglink, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMinhChung(int id_tailieu, string matailieu, string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string duonglink, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MinhChung SET MaTaiLieu = N'{1}', TenTaiLieu = N'{2}', NgayKy = N'{3}', NguoiKy = N'{4}', SoBanHanh = N'{5}', TomTatNoiDung = N'{6}', DuongLink = N'{7}', GhiChu = N'{8}'  WHERE ID_TaiLieu = N'{0}'",id_tailieu, matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, duonglink, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMinhChung(int id_tailie)
        {
            string query = string.Format("DELETE dbo.MinhChung WHERE ID_TaiLieu= N'{0}'", id_tailie);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }        
    }
}
