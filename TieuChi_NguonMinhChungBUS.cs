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
            string query = "SELECT * FROM dbo.TieuChi_NguonMinhChung";
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
    }
}
