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
            string query = "SELECT MChung.ID_TaiLieu, MChung.MaTaiLieu, MChung.NgayKy, MChung.NguoiKy, MChung.SoBanHanh, MChung.TomTatNoiDung, MChung.GhiChu " +
                            "FROM dbo.MinhChung MChung";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                MinhChungDTO minhChung = new MinhChungDTO(dataRow);
                List.Add(minhChung);
            }
            return List;
        }
        public bool InsertMinhChung(string matailieu, string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string ghichu)
        {
            string query = string.Format("INSERT dbo.MinhChung (MaTaiLieu, TenTaiLieu, NgayKy, NguoiKy, SoBanHanh, TomTatNoiDung, GhiChu) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMinhChung(int id_tailieu, string matailieu, string tentailieu, string ngayky, string nguoiky, string sobanhanh, string tomtatnoidung, string ghichu)
        {
            string query = string.Format("UPDATE dbo.MinhChung SET MaTaiLieu = N'{1}', TenTaiLieu = N'{2}', NgayKy = N'{3}', NguoiKy = N'{4}', SoBanHanh = N'{5}', TomTatNoiDung = N'{6}', GhiChu = N'{7}'  WHERE ID_TaiLieu = N'{0}'",id_tailieu, matailieu, tentailieu, ngayky, nguoiky, sobanhanh, tomtatnoidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMinhChung(int id_tailieu)
        {
            string query = string.Format("DELETE dbo.MinhChung WHERE ID_TaiLieu = N'{0}'", id_tailieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateLinkMinhChung(int id_tailieu, string duonglink)
        {
            string query = string.Format("UPDATE dbo.MinhChung SET DuongLink= N'{1}' WHERE ID_TaiLieu = N'{0}'", id_tailieu, duonglink);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
