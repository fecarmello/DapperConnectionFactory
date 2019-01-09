namespace MySqlDapper.Entity
{
    using Dapper.Contrib.Extensions;

    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public virtual int IdUsuario { get; set; }

        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }
        public virtual int Idade { get; set; }

        [Write(false)]
        public virtual string NomeCompleto => $"{Nome} {Sobrenome} tem {Idade} anos.";

        public Usuario()
        {
        }
    }
}