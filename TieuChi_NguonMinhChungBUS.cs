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
    public class TieuChi_NguonMinhChungBUS
    {
        private static TieuChi_NguonMinhChungBUS instance;

        public static TieuChi_NguonMinhChungBUS Instance
        {
            get { if (instance == null) instance = new TieuChi_NguonMinhChungBUS(); return TieuChi_NguonMinhChungBUS.instance; }
            private set { TieuChi_NguonMinhChungBUS.instance = value; }
        }

        private TieuChi_NguonMinhChungBUS() { }

        public List<TieuChi_NguonMinhChungDTO> GetListTieuChi_NguonMinhChung()
        {
            List<TieuChi_NguonMinhChungDTO> List = new List<TieuChi_NguonMinhChungDTO>();
            string query = "SELECT TChiNMChung.ID_TieuChi, TChiNMChung.ID_NguonMinhChung, TChi.MaTieuChi, TChi.TenTieuChi, NMChung.MaNguonMinhChung, NMChung.TenNguonMinhChung, TChiNMChung.GhiChu " +
                            "FROM dbo.TieuChi_NguonMinhChung TChiNMChung, dbo.TieuChi TChi, dbo.NguonMinhChung NMChung " +
                            "WHERE TChi.ID_TieuChi = NMChung.ID_NguonMinhChung";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChi_NguonMinhChungDTO tieuChi_NguonMinhChung = new TieuChi_NguonMinhChungDTO(dataRow);
                List.Add(tieuChi_NguonMinhChung);
            }
            return List;
        }
        public bool InsertTieuChi_NguonMinhChung(int id_tieuchi, int id_nguonminhchung, string ghichu)
        {
            string query = string.Format("INSERT dbo.TieuChi_NguonMinhChung (ID_TieuChi, ID_NguonMinhChung, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_tieuchi, id_nguonminhchung, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTieuChi_NguonMinhChung(int id_tieuchi, int id_nguonminhchung)
        {
            string query = string.Format("DELETE dbo.YeuCau_MocThamChieu WHERE ID_YeuCau = N'{0}' AND ID_MocThamChieu = N'{1}' ", id_tieuchi, id_nguonminhchung);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }
    }
}
