using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;

namespace GrupoAleff.Acesso.AppService.AppServices
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioAppService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            
        }
    }
}
