using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DataProvider
    {
        private string conString = $"Data Source=.\\SQLEXPRESS;Initial Catalog=DemoWebAPI;User ID=sa;Password=100100";
        #region cau truc design patent singleton
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            private set => instance = value;
        }

        private DataProvider() { }
        #endregion

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(conString))
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
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Lenh truy van ko tra ve data.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameter"></param>
        /// <returns>trang thai truy van, neu !=0 laf thanh cong.</returns>
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;//so dong execute thanh cong

            using (SqlConnection connection = new SqlConnection(conString))
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

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;//so dong execute thanh cong

            using (SqlConnection connection = new SqlConnection(conString))
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
    }
}
