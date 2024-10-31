using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
namespace DemoFormDangNhap
{
    internal class Modify
    {
        public Modify()
        {

        }
        //truy van cac cau lenh insert,...
        SqlDataReader dataReader;
        private static string stringconnection = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\TRINH\source\repos\DemoFormDangNhap\Database1.mdf;Integrated Security=True";
        public List<TaiKhoan> TaiKhoans(string q)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlconnection = new SqlConnection(stringconnection))
            {
                try
                {
                    sqlconnection.Open();
                    SqlCommand sqlcommand = new SqlCommand(q, sqlconnection);
                    using (SqlDataReader reader = sqlcommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            taiKhoans.Add(new TaiKhoan(reader.GetString(0), reader.GetString(1)));
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sai");
                }
                finally
                {
                    sqlconnection.Close();
                }

            }
            return taiKhoans;
        }
        public bool CheckTaiKhoanExists(string tk)
        {
            using (SqlConnection connection = new SqlConnection(stringconnection))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM TaiKhoan WHERE TaiKhoan = @TaiKhoan";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaiKhoan", tk);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public bool CheckEmailExists(string email)
        {
            using (SqlConnection connection = new SqlConnection(stringconnection))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM TaiKhoan WHERE Email = @Email";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    object result = command.ExecuteScalar();
                    int count = result == null ? 0 : Convert.ToInt32(result);
                    return count > 0;
                }
            }
        }
        public bool InsertUser(string username, string email, string password)
        {
            using (SqlConnection connection = new SqlConnection(stringconnection))
            {
                connection.Open();

                string query = "INSERT INTO TaiKhoan (TenTaiKhoan,MatKhau,Email) VALUES (@Username, @Password, @Email)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);

                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}
