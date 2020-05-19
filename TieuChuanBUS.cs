using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KiemDinhChatLuongDAL;
using KiemDinhChatLuongDTO;
//using System.Form;

namespace KiemDinhChatLuongBUS
{
    public class TieuChuanBUS
    {
        private static TieuChuanBUS instance;

        public static TieuChuanBUS Instance
        {
            get { if (instance == null) instance = new TieuChuanBUS(); return TieuChuanBUS.instance; }
            private set { TieuChuanBUS.instance = value; }
        }

        private TieuChuanBUS() { }

        public List<TieuChuanDTO> GetListTieuChuan()
        {
            List<TieuChuanDTO> List = new List<TieuChuanDTO>();
            string query = "SELECT * FROM dbo.TieuChuan";
            DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in data.Rows)
            {
                TieuChuanDTO tieuChuan = new TieuChuanDTO(dataRow);
                List.Add(tieuChuan);
            }
            return List;
        }
        public bool InsertTieuChuan(string tentieuchuan, string noidungtieuchuan, string ghichu)
        {
            string query = string.Format("INSERT dbo.TieuChuan (TenTieuChuan, NoiDungTieuChuan, GhiChu ) VALUES (N'{0}', N'{1}', N'{2}')", tentieuchuan, noidungtieuchuan, ghichu); 
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTieuChuan(int matieuchuan, string tentieuchuan, string noidungtieuchuan, string ghichu)
        {
            string query = string.Format("UPDATE dbo.TieuChuan SET TenTieuChuan = N'{1}', NoiDungTieuChuan = N'{2}', GhiChu = N'{3}' WHERE MaTieuChuan = N'{0}'", matieuchuan, tentieuchuan, noidungtieuchuan, ghichu);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTieuChuan(int matieuchuan)
        {
            string query = string.Format("DELETE dbo.TieuChuan WHERE MaTieuChuan= N'{0}'", matieuchuan);
            int result = DataBaseConnection.Instance.ExcuteNonQuery(query);
            return result > 0;
        }

        //public List<TieuChuanDTO> SearchListTieuChuan(int matieuchuan)
        //{
        //    List<TieuChuanDTO> List = new List<TieuChuanDTO>();
        //    string query = string.Format("SELECT * FROM dbo.TieuChuan WHERE MATIEUCHUAN LIKE N'%' + N'"+ matieuchuan + "' + '%'");
        //    DataTable data = DataBaseConnection.Instance.ExecuteQuery(query);
        //    foreach (DataRow dataRow in data.Rows)
        //    {
        //        TieuChuanDTO tieuChuan = new TieuChuanDTO(dataRow);
        //        List.Add(tieuChuan);
        //    }
        //    return List;
        //}
    }
}
