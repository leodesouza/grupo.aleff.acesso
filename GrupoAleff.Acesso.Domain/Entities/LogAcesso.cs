using System;

namespace GrupoAleff.Acesso.Domain.Entities
{
    public class LogAcesso
    {
        public int LogAcessoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataHoraAcesso { get; set; }
        public string EnderecoId { get; set; }
    }
}
