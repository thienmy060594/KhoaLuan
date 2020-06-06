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
    public class LoaiTaiLieuBUS
    {
        private static LoaiTaiLieuBUS instance;

        public static LoaiTaiLieuBUS Instance
        {
            get { if (instance == null) instance = new LoaiTaiLieuBUS(); return LoaiTaiLieuBUS.instance; }
            private set { LoaiTaiLieuBUS.instance = value; }
        }

        private LoaiTaiLieuBUS() { }

        public List<LoaiTaiLieuDTO> GetListLoaiTaiLieu()
        {
            List<LoaiTaiLieuDTO> List = new List<LoaiTaiLieuDTO>();
            string query = "SELECT LTLieu.ID_LoaiTaiLieu, MChung.ID_TaiLieu, NMChung.ID_NguonMinhChung, MChung.MaTaiLieu, MChung.TenTaiLieu, NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, LTLieu.MaLoaiTaiLieu, LTLieu.TenLoaiTaiLieu, LTLieu.GhiChu " +
                            "FROM dbo.LoaiTaiLieu LTLieu, dbo.MinhChung MChung, dbo.NguonMinhChung NMChung " +
                            "WHERE MChung.ID_TaiLieu = NMChung.ID_NguonMinhChung";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                LoaiTaiLieuDTO loaiTaiLieu = new LoaiTaiLieuDTO(dataRow);
                List.Add(loaiTaiLieu);
            }
            return List;
        }
        public bool InsertLoaiTaiLieu(int id_tailieu, int id_nguonminhchung, string maloaitailieu, string tenloaitailieu, string ghichu)
        {
            string query = string.Format("INSERT dbo.LoaiTaiLieu ( ID_TaiLieu, ID_NguonMInhChung, MaLoaiTaiLieu, TenLoaiTaiLieu, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", id_tailieu, id_nguonminhchung, maloaitailieu, tenloaitailieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateLoaiTaiLieu( int id_loaitailieu,int id_tailieu, int id_nguonminhchung, string maloaitailieu, string tenloaitailieu, string ghichu)
        {
            string query = string.Format("UPDATE dbo.LoaiTaiLieu SET ID_TaiLieu = N'{1}', ID_NguonMinhChung = N'{2}',MaLoaiTaiLieu = N'{3}', TenLoaiTaiLieu = N'{4}', GhiChu = N'{5}' WHERE ID_LoaiTaiLieu = N'{0}'", id_loaitailieu, id_tailieu, id_nguonminhchung, maloaitailieu, tenloaitailieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteLoaiTaiLieu(int id_loaitailieu)
        {
            string query = string.Format("DELETE dbo.LoaiTaiLieu WHERE ID_LoaiTaiLieu= N'{0}'", id_loaitailieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<LoaiTaiLieuDTO> SearchListLoaiTaiLieu(string valueToSearch)
        {
            List<LoaiTaiLieuDTO> List = new List<LoaiTaiLieuDTO>();
            string query = string.Format("SELECT LTLieu.ID_LoaiTaiLieu, MChung.ID_TaiLieu, NMChung.ID_NguonMinhChung, MChung.MaTaiLieu, MChung.TenTaiLieu, NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, LTLieu.MaLoaiTaiLieu, LTLieu.TenLoaiTaiLieu, LTLieu.GhiChu " +
                "FROM dbo.LoaiTaiLieu LTLieu, dbo.MinhChung MChung, dbo.NguonMinhChung NMChung " +
                "WHERE CONCAT(MChung.MaTaiLieu, MChung.TenTaiLieu, NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, LTLieu.MaLoaiTaiLieu, LTLieu.TenLoaiTaiLieu, LTLieu.GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                LoaiTaiLieuDTO loaiTaiLieu = new LoaiTaiLieuDTO(dataRow);
                List.Add(loaiTaiLieu);
            }
            return List;
        }
    }
}
