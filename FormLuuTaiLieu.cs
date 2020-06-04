using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;
using KiemDinhChatLuongBUS;
using System.Windows.Forms.VisualStyles;

namespace KiemDinhChatLuongGUI
{
    public partial class FormLuuTaiLieu : Form
    {
        public FormLuuTaiLieu()
        {
            InitializeComponent();
            btnDoc.Enabled = false;
            btnLuu.Enabled = false;
            btnLuuMinhChung.Enabled = false;
        }

        private void LoadLuuTaiLieu()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "pdf files (*.pdf) |*.pdf;";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                PDFLuuTaiLieu.LoadFile(openFileDialog.FileName);
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            btnDoc.Enabled = true;
            btnLuu.Enabled = true;
            btnLuuMinhChung.Enabled = true;
        }

        private void btnDoc_Click(object sender, EventArgs e)
        {
            LoadLuuTaiLieu();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //mở file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult dialogResult = openFileDialog.ShowDialog();
            string file_1 = "";
            string file_2 = "";

            if(dialogResult == DialogResult.OK)
            {
                if(File.Exists(openFileDialog.FileName))
                {
                    file_1 = openFileDialog.FileName;
                }
                else
                {
                    MessageBox.Show("Tài liệu không tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }    
            }

            //save file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "D:\\KiemDinhChatLuong\\TaiLieuMinhChung";
            string filename = Path.GetFileName(file_1);
            saveFileDialog.FileName = filename;            
            dialogResult = saveFileDialog.ShowDialog();

            if(dialogResult == DialogResult.OK)
            {
                file_2 = saveFileDialog.FileName;
            }    
            else
            {
                MessageBox.Show("Lỗi khi lưu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            File.Copy(file_1, file_2);
        }                

        private event EventHandler updateLuuDuongLink;
        public event EventHandler UpdateLuuDuongLink
        {
            add { updateLuuDuongLink += value; }
            remove { updateLuuDuongLink -= value; }
        }

        private void btnLuuMinhChung_Click(object sender, EventArgs e)
        {            
            string matailieu = Interaction.InputBox("Nhập mã tài liệu", "Thông báo", "", -1, -1);
            if (matailieu == "")
            {
                MessageBox.Show("Nhập mã tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = string.Format("SELECT MChung.DuongLink FROM dbo.MinhChung MChung WHERE MChung.MaTaiLieu = N'{0}'", matailieu);
                string input = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql);
                if (input != "")
                {
                    MessageBox.Show("Đã tồn tại tài liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = "D:\\KiemDinhChatLuong\\TaiLieuMinhChung";                   
                    string filename = "";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                       filename = openFileDialog.FileName;                        
                    }
                    else
                    {
                        MessageBox.Show("Tài liệu không tồn tại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    string duonglink = filename;
                    string sql1 = string.Format("SELECT ID_TaiLieu FROM dbo.MinhChung MChung WHERE MChung.MaTaiLieu = N'{0}'", matailieu);
                    string input_1 = KiemDinhChatLuongDAL.DataBaseConnection.GetFieldValuesId(sql1);
                    int id_tailieu = Int32.Parse(input_1);

                    if (MinhChungBUS.Instance.UpdateLinkMinhChung(id_tailieu, duonglink))
                    {
                        MessageBox.Show("Cập nhật tài liệu thành công !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (updateLuuDuongLink != null)
                        {
                            updateLuuDuongLink(this, new EventArgs());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật tài liệu thất bại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }            
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            FormMinhChung FrMinhChung = new FormMinhChung(); //Khởi tạo đối tượng
            this.Hide();
            FrMinhChung.ShowDialog(); //Hiển thị
            this.Show();
            this.Close();
        }
    }
}
