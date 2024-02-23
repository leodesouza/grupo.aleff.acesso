using System;
using System.ComponentModel.DataAnnotations;

namespace GrupoAleff.Acesso.Web.Models
{

    public class LogAcessoViewModel
    {
        public int UsuarioId { get; set; }

        [Display(Name = "Data/Hora Acesso")]
        public DateTime DataHoraAcesso { get; set; }

        [Display(Name = "Nome Usuário")]
        public string Nome { get; set; }

        [Display(Name = "Endereço Ip")]
        public string EnderecoIp { get; set; }
    }
}