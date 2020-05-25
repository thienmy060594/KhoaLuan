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
            string query = "SELECT CTrinhDTao.ID_ChuongTrinhDaoTao, CTrinhDTao.ID_Nganh, N.MaNganh, N.TenNganh, CTrinhDTao.MaChuongTrinhDaoTao, CTrinhDTao.NamKy, CTrinhDTao.NamApDung, CTrinhDTao.TomTatNoiDung, CTrinhDTao.GhiChu " +
                           "FROM dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.Nganh N " +
                           "WHERE CTrinhDTao.ID_Nganh = N.ID_Nganh";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                ChuongTrinhDaoTaoDTO nganh = new ChuongTrinhDaoTaoDTO(dataRow);
                List.Add(nganh);
            }
            return List;
        }
        public bool InsertChuongTrinhDaoTao(int id_nganh, string machuongtrinhdaotao, string namky, string namapdung, string tomtatnoidung, string ghichu)
        {
            string query = string.Format("INSERT dbo.ChuongTrinhDaoTao (ID_Nganh, MaChuongTrinhDaoTao, NamKy, NamApDung, TomTatNoiDung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", id_nganh, machuongtrinhdaotao, tomtatnoidung, namky, namapdung, tomtatnoidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateChuongTrinhDaoTao(int id_chuongtrinhdaotao, int id_nganh, string machuongtrinhdaotao, string namky, string namapdung, string tomtatnoidung, string ghichu)
        {
            string query = string.Format("UPDATE dbo.ChuongTrinhDaoTao SET ID_Nganh = N'{1}', MaChuongTrinhDaoTao = N'{2}', NamKy = N'{3}', NamApDung = N'{4}', TomTatNoiDung = N'{3}', GhiChu = N'{4}' WHERE ID_ChuongTrinhDaoTao = N'{0}'", id_chuongtrinhdaotao, id_nganh, machuongtrinhdaotao, namky, namapdung, tomtatnoidung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteChuongTrinhDaoTao(int id_chuongtrinhdaotao)
        {
            string query = string.Format("DELETE dbo.ChuongTrinhDaoTao WHERE ID_ChuongTrinhDaoTao = N'{0}'", id_chuongtrinhdaotao);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
