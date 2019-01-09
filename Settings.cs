using System.Configuration;

namespace MySqlDapper
{
    public static class Settings
    {
        public static string ConnString => ConfigurationManager.ConnectionStrings["Conexao"].ToString();
        public static string TipoConexao => ConfigurationManager.AppSettings["TipoConexao"].ToString();
    }
}