using System.Threading.Tasks;

namespace MySqlDapper.Data.Interface
{
    using MySqlDapper.Entity;

    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario BuscarPorNome(string nome);

        Task<Usuario> BuscarPorNomeAsync(string nome);
    }
}