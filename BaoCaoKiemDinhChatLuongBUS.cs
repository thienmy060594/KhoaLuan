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
    public class BaoCaoKiemDinhChatLuongBUS
    {
        private static BaoCaoKiemDinhChatLuongBUS instance;

        public static BaoCaoKiemDinhChatLuongBUS Instance
        {
            get { if (instance == null) instance = new BaoCaoKiemDinhChatLuongBUS(); return BaoCaoKiemDinhChatLuongBUS.instance; }
            private set { BaoCaoKiemDinhChatLuongBUS.instance = value; }
        }

        private BaoCaoKiemDinhChatLuongBUS() { }

        public List<BaoCaoKiemDinhChatLuongDTO> GetListBaoCaoKiemDinhChatLuong()
        {
            List<BaoCaoKiemDinhChatLuongDTO> List = new List<BaoCaoKiemDinhChatLuongDTO>();
            string query = "SELECT TChuan.ID_TieuChuan, TChuan.NoiDungTieuChuan, TChi.ID_TieuChi, TChi.NoiDungTieuChi, YCau.ID_YeuCau, YCau.NoiDungYeuCau, MTChieu.ID_MocThamChieu, MTChieu.NoiDungMocThamChieu, NMChung.ID_NguonMinhChung, NMChung.NoiDungNguonMinhChung " +
                           "FROM dbo.TieuChuan TChuan, dbo.TieuChi TChi, dbo.TieuChi_YeuCau TChiYCau, dbo.YeuCau YCau, dbo.YeuCau_MocThamChieu YCauMTChieu, dbo.MocThamChieu MTChieu, dbo.TieuChi_NguonMinhChung TChiNMChung, dbo.NguonMinhChung NMChung " +
                           "WHERE TChuan.ID_TieuChuan = TChi.ID_TieuChuan AND TChi.ID_TieuChi = TChiYCau.ID_TieuChi AND YCau.ID_YeuCau = TChiYCau.ID_YeuCau AND YCau.ID_YeuCau = YCauMTChieu.ID_YeuCau AND MTChieu.ID_MocThamChieu = YCauMTChieu.ID_MocThamChieu AND TChi.ID_TieuChi = TChiNMChung.ID_TieuChi AND TChiNMChung.ID_NguonMinhChung = NMChung.ID_NguonMinhChung";
            DataTable dataTable = DataBaseConnection.Instance.ExecuteQuery(query);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                BaoCaoKiemDinhChatLuongDTO baoCaoKiemDinhChatLuongDTO = new BaoCaoKiemDinhChatLuongDTO(dataRow);
                List.Add(baoCaoKiemDinhChatLuongDTO);
            }
            return List;
        }
    }
}
