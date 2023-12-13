using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Handle_Logic
{
    public class ConnectDB
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public SqlConnection Connection { get => connection; set => connection = value; }
        public SqlCommand Command { get => command; set => command = value; }
        public SqlDataReader Reader { get => reader; set => reader = value; }

        public ConnectDB()
        {
            this.connectionString = null;
            this.connection = null;
            this.command = null;
            this.reader = null;
        }
        public ConnectDB(string connectionString, SqlConnection connection, SqlCommand command, SqlDataReader reader)
        {
            this.connectionString = connectionString;
            this.connection = connection;
            this.command = command;
            this.reader = reader;
        }
        public ConnectDB(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private void WriteLogs(string logs)
        {
            StreamWriter writer = new StreamWriter("Logs.txt");
            writer.WriteLine(logs);
            writer.Close();
        }
        public bool StartConnect()
        {
            try
            {
                this.connection = new SqlConnection(this.connectionString);
                return true;
            }
            catch (Exception ex)
            {
                WriteLogs(ex.ToString());
                return false;
            }        
        }
        public SqlDataReader QueryDatabase(string query)
        {
            SqlDataReader dataReader = null;
            this.command = new SqlCommand(query,this.connection);
            this.connection.Open();
            this.reader = this.command.ExecuteReader();
            dataReader =  this.reader;
            this.connection.Close();
            return dataReader;
        }
    }
}
