using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KiemDinhChatLuongBUS;

namespace KiemDinhChatLuongGUI
{
    public partial class FormBaoCaoChuongTrinhDaoTao : Form
    {
        public FormBaoCaoChuongTrinhDaoTao()
        {
            InitializeComponent();
            FillComBoBox();
        }

        private void FillComBoBox()
        {
            cbxChuongTrinhDaoTao.DataSource = ChuongTrinhDaoTaoBUS.Instance.GetListChuongTrinhDaoTao();
            cbxChuongTrinhDaoTao.ValueMember = "MaChuongTrinhDaoTao";
            cbxChuongTrinhDaoTao.DisplayMember = "MaChuongTrinhDaoTao";
        }

        private void FormBaoCaoChuongTrinhDaoTao_Load(object sender, EventArgs e)
        {

        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            string machuongtrinhdaotao = cbxChuongTrinhDaoTao.GetItemText(cbxChuongTrinhDaoTao.SelectedValue);
            this.BaoCaoChuongTrinhDaoTaoTableAdapter.Fill(this.DataSetBaoCaoChuongTrinhDaoTao.BaoCaoChuongTrinhDaoTao, machuongtrinhdaotao);
            this.rvChuongTrinhDaoTao.RefreshReport();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
