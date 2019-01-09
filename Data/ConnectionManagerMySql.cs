using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySqlDapper.Data
{
    public class ConnectionManagerMySql : IDisposable, IConnectionManager
    {
        private readonly bool _async;

        public MySqlConnection Connection { get; set; }
        public string ConnectionString { get; set; }
        public MySqlTransaction Transaction { get; set; }

        public ConnectionManagerMySql(string connectionString, bool async = false)
        {
            ConnectionString = connectionString;
            Connection = new MySqlConnection(ConnectionString);

            _async = async;

            if (_async)
                Connection.OpenAsync();
            else
                Connection.Open();
        }

        public IDbConnection GetConnection()
        {
            return Connection;
        }

        public IDbTransaction GetTransaction()
        {
            return Transaction;
        }

        public void OpenConnection()
        {
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection = new MySqlConnection(ConnectionString);

                if (_async)
                    Connection.OpenAsync();
                else
                    Connection.Open();
            }
        }

        public bool IsInTransaction()
        {
            return Transaction != null;
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction != null)
                Transaction.Commit();
        }

        public void Rollback()
        {
            if (Transaction != null)
                Transaction.Rollback();
        }

        public void Dispose()
        {
            if (Transaction != null)
                Transaction.Dispose();

            if (Connection != null)
            {
                Connection.Close();
                Connection.Dispose();
            }
        }
    }
}