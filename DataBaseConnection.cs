using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KiemDinhChatLuongDAL
{
    public class DataBaseConnection
    {
        private static DataBaseConnection instance;

        public static DataBaseConnection Instance
        {
            get { if (instance == null) instance = new DataBaseConnection(); return DataBaseConnection.instance; }
            private set { DataBaseConnection.instance = value; }
        }

        private DataBaseConnection() { }

        private string connectionSTR = "Data Source=PHUC-PC\\MYSQL;Initial Catalog=QuanLyTieuChuanDanhGia;Integrated Security=True;MultipleActiveResultSets=True";

        //Trả dữ liệu ra kiểu list
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(dataTable);
                connection.Close();
            }
            return dataTable;
        }

        //Trả về kiểu int
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteNonQuery();
                connection.Close();
            }
            return data;
        }

        public object ExcuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                data = command.ExecuteScalar();
                connection.Close();
            }
            return data;
        }

        public static SqlConnection connection;     //Khai báo đối tượng kết nối connection   

        public static void Connect()
        {
            connection = new SqlConnection();   // Khởi tạo đối tượng
            connection.ConnectionString = @"Data Source=PHUC-PC\MYSQL;Initial Catalog=QuanLyTieuChuanDanhGia;Integrated Security=True";
            connection.Open();  //Mở kết nối             
        }
                
        public static void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();     //Đóng kết nối
                connection.Dispose();   //Giải phóng tài nguyên
                connection = null;
            }
        }

        //Lấy dữ liệu vào bảng
        public static DataTable GetDataToTable(string sql)
        {
            // mở kết nối 
            DataBaseConnection.Connect();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(); //Định nghĩa đối tượng thuộc lớp SqlDataAdapter
            //Tạo đối tượng thuộc lớp SqlCommand
            sqlDataAdapter.SelectCommand = new SqlCommand();
            sqlDataAdapter.SelectCommand.Connection = DataBaseConnection.connection; //Kết nối cơ sở dữ liệu
            sqlDataAdapter.SelectCommand.CommandText = sql; //Lệnh SQL
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);         
            return dataTable;
        }
        //Hàm kiểm tra khoá trùng
        public static bool CheckKey(string sql)
        {
            // mở kết nối 
            DataBaseConnection.Connect();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Hàm thực hiện câu lệnh SQL
        public static void RunSQL(string sql)
        {
            SqlCommand sqlCommand; //Đối tượng thuộc lớp SqlCommand
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection; //Gán kết nối
            sqlCommand.CommandText = sql; //Gán lệnh SQL
            sqlCommand.ExecuteNonQuery(); //Thực hiện câu lệnh SQL
            sqlCommand.Dispose();//Giải phóng bộ nhớ
            sqlCommand = null;
        }
        public static void RunSqlDel(string sql)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = DataBaseConnection.connection;
            sqlCommand.CommandText = sql;
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                
            }
            sqlCommand.Dispose();
            sqlCommand = null;
        }
        public static string GetFieldValuesId(string sql)
        {
            DataBaseConnection.Connect();
            string ID = "";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            SqlDataReader sqlDataReader;
            sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
                ID = sqlDataReader.GetValue(0).ToString();
            sqlDataReader.Close();
            return ID;
        }
    }
}
