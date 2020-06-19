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
    public class NhomTuChonBUS
    {
        private static NhomTuChonBUS instance;

        public static NhomTuChonBUS Instance
        {
            get { if (instance == null) instance = new NhomTuChonBUS(); return NhomTuChonBUS.instance; }
            private set { NhomTuChonBUS.instance = value; }
        }

        private NhomTuChonBUS() { }

        public List<NhomTuChonDTO> GetListNhomTuChon()
        {
            List<NhomTuChonDTO> List = new List<NhomTuChonDTO>();
            string query = "SELECT NTChon.ID_NhomTuChon, NTChon.ID_ChuongTrinhDaoTao, CTrinhDTao.MaChuongTrinhDaoTao, NTChon.MaNhomTuChon, NTChon.TenNhomTuChon, NTChon.SoTinChi, NTChon.GhiChu " +
                            "FROM dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.NhomTuChon NTChon " +
                            "WHERE CTrinhDTao.ID_ChuongTrinhDaoTao = NTChon.ID_ChuongTrinhDaoTao";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NhomTuChonDTO nhomTuChon = new NhomTuChonDTO(dataRow);
                List.Add(nhomTuChon);
            }
            return List;
        }
        public bool InsertNhomTuChon(int id_chuongtrinhdaotao, string manhomtuchon, string tennhomtuchon, int sotinchi, string ghichu)
        {
            string query = string.Format("INSERT dbo.NhomTuChon (ID_ChuongTrinhDaoTao, MaNhomTuChon, TenNhomTuChon, SoTinChi, GhiChu) VALUES (N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')", id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNhomTuChon(int id_nhomtuchon, int id_chuongtrinhdaotao, string manhomtuchon, string tennhomtuchon, int sotinchi, string ghichu)
        {
            string query = string.Format("UPDATE dbo.NhomTuChon SET ID_ChuongTrinhDaotao = N'{1}', MaNhomTuChon = N'{2}', TenNhomTuChon = N'{3}', SoTinChi = N'{4}', GhiChu = N'{5}' WHERE ID_NhomTuChon = N'{0}'", id_nhomtuchon, id_chuongtrinhdaotao, manhomtuchon, tennhomtuchon, sotinchi, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNhomTuChon(int id_nhomtuchon)
        {
            string query = string.Format("DELETE dbo.NhomTuChon WHERE ID_NhomTuChon= N'{0}'", id_nhomtuchon);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public List<NhomTuChonDTO> SearchListNhomTuChon(string valueToSearch)
        {
            List<NhomTuChonDTO> List = new List<NhomTuChonDTO>();
            string query = string.Format("SELECT NTChon.ID_NhomTuChon, NTChon.ID_ChuongTrinhDaoTao, CTrinhDTao.MaChuongTrinhDaoTao, NTChon.MaNhomTuChon, NTChon.TenNhomTuChon, NTChon.SoTinChi, NTChon.GhiChu " +
                "FROM dbo.ChuongTrinhDaoTao CTrinhDTao, dbo.NhomTuChon NTChon " +
                "WHERE CTrinhDTao.ID_ChuongTrinhDaoTao = NTChon.ID_ChuongTrinhDaoTao AND CONCAT(NTChon.MaNhomTuChon, NTChon.TenNhomTuChon, NTChon.SoTinChi, NTChon.GhiChu) LIKE N'%" + valueToSearch + "%'");
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                NhomTuChonDTO nhomTuChon = new NhomTuChonDTO(dataRow);
                List.Add(nhomTuChon);
            }
            return List;
        }
    }
}
