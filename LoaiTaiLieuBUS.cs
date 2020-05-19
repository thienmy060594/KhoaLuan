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
            string query = "SELECT * FROM dbo.LoaiTaiLieu";
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                LoaiTaiLieuDTO loaiTaiLieu = new LoaiTaiLieuDTO(dataRow);
                List.Add(loaiTaiLieu);
            }
            return List;
        }
        public bool InsertLoaiTaiLieu(int maminhchung, int manguonminhchung, string tenloaitailieu, string ghichu)
        {
            string query = string.Format("INSERT dbo.LoaiTaiLieu (MaMinhChung, MaNguonMinhChung, TenLoaiTaiLieu, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}', N'{3}')", maminhchung, manguonminhchung, tenloaitailieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateLoaiTaiLieu(int maloaitailieu,int maminhchung, int manguonminhchung, string tenloaitailieu, string ghichu)
        {
            string query = string.Format("UPDATE dbo.LoaiTaiLieu SET MaMinhChung = N'{1}', MaNguonMinhChung = N'{2}', TenLoaiTaiLieu = N'{3}', GhiChu = N'{4}' WHERE MaLoaiTaiLieu = N'{0}'", maloaitailieu, maminhchung, manguonminhchung, tenloaitailieu, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteLoaiTaiLieu(int maloaitailieu)
        {
            string query = string.Format("DELETE dbo.LoaiTaiLieu WHERE MaLoaiTaiLieu= N'{0}'", maloaitailieu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //public List<LoaiTaiLieuDTO> SearchListYeuCau(string maloaitailieu)
        //{
        //    List<LoaiTaiLieuDTO> List = new List<LoaiTaiLieuDTO>();
        //    string query = string.Format("SELECT * FROM dbo.LoaiTaiLieu WHERE MaLoaiTaiLieu LIKE N'%' + N'" + maloaitailieu + "' + '%'");
        //    DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //    foreach (DataRow dataRow in data.Rows)
        //    {
        //        LoaiTaiLieuDTO loaiTaiLieu = new LoaiTaiLieuDTO(dataRow);
        //        List.Add(loaiTaiLieu);
        //    }
        //    return List;
        //}
    }
}
