
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LibDB
{
    public class MainConnector
    {
        public SqlConnection connection;// = new SqlConnection(ConnectionString.MsSqlConnection);
        

        public async Task<bool> ConnectAsync()
        {
            bool result;
            try
            {
                connection = new SqlConnection(ConnectionString.MsSqlConnection);
                await connection.OpenAsync();
                result = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                result = false;
            }

            return result;
        }

        public  void DisconnectAsync()
        {
            if (connection.State == ConnectionState.Open)
            {
                 connection.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                return connection;
            }
            else
            {
                throw new Exception("Подключение уже закрыто!");
            }
        }
    }
}
