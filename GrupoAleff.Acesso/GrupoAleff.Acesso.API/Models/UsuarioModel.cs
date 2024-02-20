namespace GrupoAleff.Acesso.API.Models
{
    public class UsuarioModel
    {
        public int Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }

    }
}