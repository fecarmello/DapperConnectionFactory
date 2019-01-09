using System;

namespace MySqlDapper.Data
{
    public static class ConnectionFactory
    {
        public static IConnectionManager GetConnectionManager(string type, string connectionString, bool async)
        {
            switch (type.ToLower())
            {
                case "sqlserver":
                    return new ConnectionManagerSqlServer(connectionString, async);

                case "mysql":
                    return new ConnectionManagerMySql(connectionString, async);

                default:
                    throw new Exception("Tipo de conexão não informado!");
            }
        }
    }
}