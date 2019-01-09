using System;
using System.Threading;
using System.Threading.Tasks;

namespace MySqlDapper
{
    using MySqlDapper.Data;
    using MySqlDapper.Data.Interface;
    using MySqlDapper.Data.Repository;
    using MySqlDapper.Entity;

    internal static class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                #region "Sincrono"
                using (IConnectionManager conexao = ConnectionFactory.GetConnectionManager(Settings.TipoConexao, Settings.ConnString, false))
                {
                    IUsuarioRepository usuarioRepository = new UsuarioRepository(conexao);
                    Usuario usuario = new Usuario()
                    {
                        Nome = "Mauricio",
                        Sobrenome = "de Souza",
                        Idade = 27
                    };

                    long idUsuario = usuarioRepository.Insert(usuario);

                    usuario = usuarioRepository.GetById((int)idUsuario);

                    if (usuario != null)
                        Console.WriteLine($"{DateTime.Now} - {usuario.NomeCompleto}");

                    usuario = usuarioRepository.BuscarPorNome("Joaquim");

                    if (usuario != null)
                        Console.WriteLine($"{DateTime.Now} - {usuario.NomeCompleto}");

                    Thread.Sleep(1000);
                }
                # endregion

                #region "Assincrono"

                using (IConnectionManager conexao = ConnectionFactory.GetConnectionManager(Settings.TipoConexao, Settings.ConnString, false))
                {
                    IUsuarioRepository usuarioRepository = new UsuarioRepository(conexao);

                    Task.Run(async () =>
                    {
                        Usuario usuarioAsync = new Usuario()
                        {
                            Nome = "Mauricio",
                            Sobrenome = "de Souza Async",
                            Idade = 27
                        };

                        long idUsuarioAsync = await usuarioRepository.InsertAsync(usuarioAsync);

                        usuarioAsync = await usuarioRepository.GetByIdAsync((int)idUsuarioAsync);

                        if (usuarioAsync != null)
                            Console.WriteLine($"{DateTime.Now} - {usuarioAsync.NomeCompleto}");

                        usuarioAsync = await usuarioRepository.BuscarPorNomeAsync("Joaquim");

                        if (usuarioAsync != null)
                            Console.WriteLine($"{DateTime.Now} - {usuarioAsync.NomeCompleto}");

                        Thread.Sleep(1000);
                    });
                }

                #endregion "Assincrono"

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw;
            }
        }
    }
}