namespace GrupoAleff.Acesso.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public short IsAdmin { get; set; }
    }
}
