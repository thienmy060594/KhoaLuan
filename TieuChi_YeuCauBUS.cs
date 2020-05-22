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
    public class TieuChi_YeuCauBUS
    {
        private static TieuChi_YeuCauBUS instance;

        public static TieuChi_YeuCauBUS Instance
        {
            get { if (instance == null) instance = new TieuChi_YeuCauBUS(); return TieuChi_YeuCauBUS.instance; }
            private set { TieuChi_YeuCauBUS.instance = value; }
        }

        private TieuChi_YeuCauBUS() { }

        public List<TieuChi_YeuCauDTO> GetListTieuChi_YeuCau()
        {
            List<TieuChi_YeuCauDTO> List = new List<TieuChi_YeuCauDTO>();
            string query = "SELECT * FROM dbo.TieuChi_YeuCau";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TieuChi_YeuCauDTO tieuChi_YeuCau = new TieuChi_YeuCauDTO(dataRow);
                List.Add(tieuChi_YeuCau);
            }
            return List;
        }
        public bool InsertTieuChi_YeuCau(int id_tieuchi, int id_yeucau, string ghichu)
        {
            string query = string.Format("INSERT dbo.LoaiTaiLieu (ID_TieuChi, ID_YeuCau, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", id_tieuchi, id_yeucau, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }           
    }
}
