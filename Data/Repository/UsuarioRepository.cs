using Dapper;
using System.Threading.Tasks;

namespace MySqlDapper.Data.Repository
{
    using MySqlDapper.Data.Interface;
    using MySqlDapper.Entity;

    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly IConnectionManager _connectionManager;

        public UsuarioRepository(IConnectionManager connectionManager) : base(connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public Usuario BuscarPorNome(string nome)
        {
            string sql = "Select * From Usuario Where Nome = @Nome";
            object param = new { Nome = nome };
            return _connectionManager.GetConnection().QueryFirstOrDefault<Usuario>(sql, param);
        }

        public Task<Usuario> BuscarPorNomeAsync(string nome)
        {
            string sql = "Select * From Usuario Where Nome = @Nome";
            object param = new { Nome = nome };
            return _connectionManager.GetConnection().QueryFirstOrDefaultAsync<Usuario>(sql, param);
        }
    }
}