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
    public class DeCuongMonHocBUS
    {
        private static DeCuongMonHocBUS instance;

        public static DeCuongMonHocBUS Instance
        {
            get { if (instance == null) instance = new DeCuongMonHocBUS(); return DeCuongMonHocBUS.instance; }
            private set { DeCuongMonHocBUS.instance = value; }
        }

        private DeCuongMonHocBUS() { }

        public List<DeCuongMonHocDTO> GetListDeCuongMonHoc()
        {
            List<DeCuongMonHocDTO> List = new List<DeCuongMonHocDTO>();
            string query = "SELECT DCuongMHoc.ID_MonHoc, DCuongMHoc.ID_TaiLieu, MHoc.MaMonHoc, MHoc.TenMonHoc, MChung.MaTaiLieu, MChung.TenTaiLieu, DCuongMHoc.MaDeCuongMonHoc, DCuongMHoc.TenDeCuongMonHoc, DCuongMHoc.MoTa, DCuongMHoc.HinhThucDanhGia, DCuongMHoc.GiaoTrinh, DCuongMHoc.GhiChu " +
                           "FROM dbo.DeCuongMonHoc DCuongMHoc, dbo.MonHoc MHoc, dbo.MinhChung MChung " +
                           "WHERE DCuongMHoc.ID_MonHoc = MHoc.ID_MonHoc AND DCuongMHoc.ID_TaiLieu = MChung.ID_TaiLieu";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                DeCuongMonHocDTO deCuongMonHoc = new DeCuongMonHocDTO(dataRow);
                List.Add(deCuongMonHoc);
            }
            return List;
        }
        public bool InsertDeCuongMonHoc(int id_monhoc, int id_tailieu, string madecuongmonhoc, string tendecuongmonhoc, string mota, string hinhthucdanhgia, string giaotrinh, string ghichu)
        {
            string query = string.Format("INSERT dbo.DeCuongMonHoc (ID_MonHoc, ID_TaiLieu, MaDeCuongMonHoc, TenDeCuongMonHoc, MoTa, HinhThucDanhGia, GiaoTrinh, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, mota, hinhthucdanhgia, giaotrinh, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateDeCuongMonHoc(int id_monhoc, int id_tailieu, string madecuongmonhoc, string tendecuongmonhoc, string mota, string hinhthucdanhgia, string giaotrinh, string ghichu)
        {
            string query = string.Format("UPDATE dbo.DeCuongMonHoc SET ID_TaiLieu = N'{2}', MaDeCuongMonHoc = N'{3}', TenDeCuongMonHoc = N'{4}', MoTa = N'{3}', HinhThucDanhGia = N'{4}', GiaoTrinh = N'{5}', GhiChu = N'{6}' WHERE ID_MonHoc = N'{0}'", id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, mota, hinhthucdanhgia, giaotrinh, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteDeCuongMonHoc(int id_monhoc)
        {
            string query = string.Format("DELETE dbo.DeCuongMonHoc WHERE ID_MonHoc = N'{0}'", id_monhoc);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<DeCuongMonHocDTO> SearchListDeCuongMonHoc(string valueToSearch)
        {
            List<DeCuongMonHocDTO> List = new List<DeCuongMonHocDTO>();
            string query = string.Format("SELECT DCuongMHoc.ID_MonHoc, DCuongMHoc.ID_TaiLieu, MHoc.MaMonHoc, MHoc.TenMonHoc, MChung.MaTaiLieu, MChung.TenTaiLieu, DCuongMHoc.MaDeCuongMonHoc, DCuongMHoc.TenDeCuongMonHoc, DCuongMHoc.MoTa, DCuongMHoc.HinhThucDanhGia, DCuongMHoc.GiaoTrinh, DCuongMHoc.GhiChu " +
                "FROM dbo.DeCuongMonHoc DCuongMHoc, dbo.MonHoc MHoc, dbo.MinhChung MChung " +
                "WHERE DCuongMHoc.ID_MonHoc = MHoc.ID_MonHoc AND DCuongMHoc.ID_TaiLieu = MChung.ID_TaiLieu AND CONCAT(MHoc.MaMonHoc, MHoc.TenMonHoc, MChung.MaTaiLieu, MChung.TenTaiLieu, DCuongMHoc.MaDeCuongMonHoc, DCuongMHoc.TenDeCuongMonHoc, DCuongMHoc.MoTa, DCuongMHoc.HinhThucDanhGia, DCuongMHoc.GiaoTrinh, DCuongMHoc.GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                DeCuongMonHocDTO deCuongMonHoc = new DeCuongMonHocDTO(dataRow);
                List.Add(deCuongMonHoc);
            }
            return List;
        }
    }
}
