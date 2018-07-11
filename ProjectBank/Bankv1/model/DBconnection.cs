using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Bankv1.model
{
    public class Dbconnection
    {
        private Dbconnection()
        {

        }
        private const string DatabaseName = "Bank";
        private const string ServerName = "localhost";
        private const string ServerPort = "3306";
        private const string Uid = "root";
        private const string Password = "";
        private const string SslMode = "none";
        private const string PersistSecurityInfo = "True";

        private MySqlConnection _connection = null;
        public MySqlConnection Connection
        {
            get { return _connection; }
        }
        private static Dbconnection _instance = null;

        public static Dbconnection Instance()
        {
            return _instance != null ? _instance : (_instance = new Dbconnection());
        }
        public void OpenConnection()
        {
            if (_connection == null)
            {
                var connString = string.Format("Server={0}; database={1};UID={2}; password={3};persistsecurityinfo{4};port={5};SslMode={6}", ServerName, DatabaseName, Uid, Password, PersistSecurityInfo, ServerPort, SslMode);
                _connection = new MySqlConnection(connString);
                _connection.Open();
            }
            else if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if(_connection != null && _connection.State == ConnectionState.Open)
            _connection.Close();
        }
    }
}