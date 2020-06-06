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
    public class ChuongTrinhDaoTaoBUS
    {
        private static ChuongTrinhDaoTaoBUS instance;

        public static ChuongTrinhDaoTaoBUS Instance
        {
            get { if (instance == null) instance = new ChuongTrinhDaoTaoBUS(); return ChuongTrinhDaoTaoBUS.instance; }
            private set { ChuongTrinhDaoTaoBUS.instance = value; }
        }

        private ChuongTrinhDaoTaoBUS() { }

        public List<ChuongTrinhDaoTaoDTO> GetListChuongTrinhDaoTao()
        {
            List<ChuongTrinhDaoTaoDTO> List = new List<ChuongTrinhDaoTaoDTO>();
            string query = "SELECT CTrinhDTao.ID_ChuongTrinhDaoTao, CTrinhDTao.ID_Nganh, CTrinhDTao.ID_TaiLieu, N.MaNganh, N.TenNganh, MChung.MaTaiLieu, MChung.TenTaiLieu, CTrinhDTao.MaChuongTrinhDaoTao, CTrinhDTao.NamKy, CTrinhDTao.NamApDung, CTrinhDTao.TomTatNoiDung, CTrinhDTao.GhiChu " +
                           "FROM dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.Nganh N, dbo.MinhChung MChung " +
                           "WHERE CTrinhDTao.ID_Nganh = N.ID_Nganh AND CTrinhDTao.ID_TaiLieu = MChung.ID_TaiLieu";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ChuongTrinhDaoTaoDTO chuongTrinhDaoTaoDTO = new ChuongTrinhDaoTaoDTO(dataRow);
                List.Add(chuongTrinhDaoTaoDTO);
            }
            return List;
        }
        public bool InsertChuongTrinhDaoTao(int id_nganh, int id_tailieu, string machuongtrinhdaotao, string namky, string namapdung, string tomtatnoidung, string ghichu)
        {
            string query = string.Format("INSERT dbo.ChuongTrinhDaoTao (ID_Nganh, ID_TaiLieu, MaChuongTrinhDaoTao, NamKy, NamApDung, TomTatNoiDung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}')", id_nganh, id_tailieu, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateChuongTrinhDaoTao(int id_chuongtrinhdaotao, int id_nganh, int id_tailieu, string machuongtrinhdaotao, string namky, string namapdung, string tomtatnoidung, string ghichu)
        {
            string query = string.Format("UPDATE dbo.ChuongTrinhDaoTao SET ID_Nganh = N'{1}', ID_TaiLieu = N'{2}', MaChuongTrinhDaoTao = N'{3}', NamKy = N'{4}', NamApDung = N'{5}', TomTatNoiDung = N'{6}', GhiChu = N'{7}' WHERE ID_ChuongTrinhDaoTao = N'{0}'", id_chuongtrinhdaotao, id_nganh, id_tailieu, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteChuongTrinhDaoTao(int id_chuongtrinhdaotao)
        {
            string query = string.Format("DELETE dbo.ChuongTrinhDaoTao WHERE ID_ChuongTrinhDaoTao = N'{0}'", id_chuongtrinhdaotao);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<ChuongTrinhDaoTaoDTO> SearchListChuongTrinhDaoTao(string valueToSearch)
        {
            List<ChuongTrinhDaoTaoDTO> List = new List<ChuongTrinhDaoTaoDTO>();
            string query = string.Format("SELECT CTrinhDTao.ID_ChuongTrinhDaoTao, CTrinhDTao.ID_Nganh, CTrinhDTao.ID_TaiLieu, N.MaNganh, N.TenNganh, MChung.MaTaiLieu, MChung.TenTaiLieu, CTrinhDTao.MaChuongTrinhDaoTao, CTrinhDTao.NamKy, CTrinhDTao.NamApDung, CTrinhDTao.TomTatNoiDung, CTrinhDTao.GhiChu " +
                "FROM dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.Nganh N, dbo.MinhChung MChung " +
                "WHERE CTrinhDTao.ID_Nganh = N.ID_Nganh AND CTrinhDTao.ID_TaiLieu = MChung.ID_TaiLieu AND CONCAT(N.MaNganh, N.TenNganh, MChung.MaTaiLieu, MChung.TenTaiLieu, CTrinhDTao.MaChuongTrinhDaoTao, CTrinhDTao.NamKy, CTrinhDTao.NamApDung, CTrinhDTao.TomTatNoiDung, CTrinhDTao.GhiChu) LIKE '%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ChuongTrinhDaoTaoDTO chuongTrinhDaoTao = new ChuongTrinhDaoTaoDTO(dataRow);
                List.Add(chuongTrinhDaoTao);
            }
            return List;
        }
    }
}
