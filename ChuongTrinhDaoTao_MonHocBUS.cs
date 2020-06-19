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
    public class ChuongTrinhDaoTao_MonHocBUS
    {
        private static ChuongTrinhDaoTao_MonHocBUS instance;

        public static ChuongTrinhDaoTao_MonHocBUS Instance
        {
            get { if (instance == null) instance = new ChuongTrinhDaoTao_MonHocBUS(); return ChuongTrinhDaoTao_MonHocBUS.instance; }
            private set { ChuongTrinhDaoTao_MonHocBUS.instance = value; }
        }

        private ChuongTrinhDaoTao_MonHocBUS() { }

        public List<ChuongTrinhDaoTao_MonHocDTO> GetListChuongTrinhDaoTao_MonHoc()
        {
            List<ChuongTrinhDaoTao_MonHocDTO> List = new List<ChuongTrinhDaoTao_MonHocDTO>();
            string query = "SELECT CTrinhDTao_MHoc.ID_ChuongTrinhDaoTao, CTrinhDTao_MHoc.ID_MonHoc, CTrinhDTao_MHoc.ID_LoaiMon, CTrinhDTao.MaChuongTrinhDaoTao, MHoc.MaMonHoc, MHoc.TenMonHoc, LMon.MaLoaiMon, LMon.TenLoaiMon, CTrinhDTao_MHoc.HocKy, CTrinhDTao_MHoc.GhiChu " +
                           "FROM dbo.ChuongTrinhDaoTao_MonHoc CTrinhDTao_MHoc, dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.MonHoc MHoc, dbo.LoaiMon LMon " +
                           "WHERE CTrinhDTao_MHoc.ID_ChuongTrinhDaoTao = CTrinhDTao.ID_ChuongTrinhDaoTao AND CTrinhDTao_MHoc.ID_MonHoc = MHoc.ID_MonHoc AND CTrinhDTao_MHoc.ID_LoaiMon = LMon.ID_LoaiMon";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ChuongTrinhDaoTao_MonHocDTO trinhDaoTao_MonHoc = new ChuongTrinhDaoTao_MonHocDTO(dataRow);
                List.Add(trinhDaoTao_MonHoc);
            }
            return List;
        }
        public bool InsertChuongTrinhDaoTao_MonHoc(int id_chuongtrinhdaotao, int id_monhoc, int id_loaimon, string hocky, string ghichu)
        {
            string query = string.Format("INSERT dbo.ChuongTrinhDaoTao_MonHoc (ID_ChuongTrinhDaoTao, ID_MonHoc, ID_LoaiMon, HocKy, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')",id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateChuongTrinhDaoTao_MonHoc(int id_chuongtrinhdaotao, int id_monhoc, int id_loaimon, string hocky, string ghichu)
        {
            string query = string.Format("UPDATE dbo.ChuongTrinhDaoTao_MonHoc SET HocKy = N'{3}', GhiChu = N'{4}' WHERE ID_ChuongTrinhDaoTao = N'{0}' AND ID_MonHoc = N'{1}' AND ID_LoaiMon = N'{2}'", id_chuongtrinhdaotao, id_monhoc, id_loaimon, hocky, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteChuongTrinhDaoTao_MonHoc(int id_chuongtrinhdaotao, int id_monhoc, int id_loaimon)
        {
            string query = string.Format("DELETE dbo.ChuongTrinhDaoTao_MonHoc WHERE ID_ChuongTrinhDaoTao = N'{0}' AND ID_MonHoc = N'{1}' AND ID_LoaiMon = N'{2}'", id_chuongtrinhdaotao, id_monhoc, id_loaimon);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<ChuongTrinhDaoTao_MonHocDTO> SearchListChuongTrinhDaoTao_MonHoc(string valueToSearch)
        {
            List<ChuongTrinhDaoTao_MonHocDTO> List = new List<ChuongTrinhDaoTao_MonHocDTO>();
            string query = string.Format("SELECT CTrinhDTao_MHoc.ID_ChuongTrinhDaoTao, CTrinhDTao_MHoc.ID_MonHoc, CTrinhDTao_MHoc.ID_LoaiMon, CTrinhDTao.MaChuongTrinhDaoTao, MHoc.MaMonHoc, MHoc.TenMonHoc, LMon.MaLoaiMon, LMon.TenLoaiMon, CTrinhDTao_MHoc.HocKy, CTrinhDTao_MHoc.GhiChu " +
                "FROM dbo.ChuongTrinhDaoTao_MonHoc CTrinhDTao_MHoc, dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.MonHoc MHoc, dbo.LoaiMon LMon " +
                "WHERE CTrinhDTao_MHoc.ID_ChuongTrinhDaoTao = CTrinhDTao.ID_ChuongTrinhDaoTao AND CTrinhDTao_MHoc.ID_MonHoc = MHoc.ID_MonHoc AND CTrinhDTao_MHoc.ID_LoaiMon = LMon.ID_LoaiMon AND CONCAT(CTrinhDTao.MaChuongTrinhDaoTao, MHoc.MaMonHoc, MHoc.TenMonHoc, LMon.MaLoaiMon, LMon.TenLoaiMon, CTrinhDTao_MHoc.HocKy, CTrinhDTao_MHoc.GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ChuongTrinhDaoTao_MonHocDTO chuongTrinhDaoTao_MonHoc = new ChuongTrinhDaoTao_MonHocDTO(dataRow);
                List.Add(chuongTrinhDaoTao_MonHoc);
            }
            return List;
        }
    }
}
