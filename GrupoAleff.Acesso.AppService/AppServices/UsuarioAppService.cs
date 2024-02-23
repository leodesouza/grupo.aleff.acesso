using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.AppService.AppServices
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioAppService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> ObterUsuario(string login, string senha)
        {
            return await _usuarioRepository.ObterUsuario(login, senha);
        }
    }
}
