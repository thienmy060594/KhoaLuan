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
            string query = "SELECT DCuongMHoc.ID_DeCuongMonHoc, DCuongMHoc.ID_MonHoc, DCuongMHoc.ID_TaiLieu, MHoc.MaMonHoc, MHoc.TenMonHoc, MChung.MaTaiLieu, MChung.TenTaiLieu, DCuongMHoc.MaDeCuongMonHoc, DCuongMHoc.TenDeCuongMonHoc, DCuongMHoc.NoiDung, DCuongMHoc.GhiChu " +
                           "FROM dbo.DeCuongMonHoc DCuongMHoc, dbo.MonHoc MHoc, dbo.MinhChung MChung " +
                           "WHERE MHoc.ID_MonHoc = MChung.ID_TaiLieu";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                DeCuongMonHocDTO deCuongMonHoc = new DeCuongMonHocDTO(dataRow);
                List.Add(deCuongMonHoc);
            }
            return List;
        }
        public bool InsertDeCuongMonHoc(int id_monhoc, int id_tailieu, string madecuongmonhoc, string tendecuongmonhoc, string noidung, string ghichu)
        {
            string query = string.Format("INSERT dbo.DeCuongMonHoc (ID_MonHoc, ID_TaiLieu, MaDeCuongMonHoc, TenDeCuongMonHoc, NoiDung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, noidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateDeCuongMonHoc(int id_decuongmonhoc, int id_monhoc, int id_tailieu, string madecuongmonhoc, string tendecuongmonhoc, string noidung, string ghichu)
        {
            string query = string.Format("UPDATE dbo.DeCuongMonHoc SET ID_MonHoc = N'{1}', ID_TaiLieu = N'{2}', MaDeCuongMonHoc = N'{3}', TenDeCuongMonHoc = N'{4}', NoiDung = N'{3}', GhiChu = N'{4}' WHERE ID_DeCuongMonHoc = N'{0}'", id_decuongmonhoc, id_monhoc, id_tailieu, madecuongmonhoc, tendecuongmonhoc, noidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteDeCuongMonHoc(int id_decuongmonhoc)
        {
            string query = string.Format("DELETE dbo.DeCuongMonHoc WHERE ID_DeCuongMonHoc = N'{0}'", id_decuongmonhoc);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
