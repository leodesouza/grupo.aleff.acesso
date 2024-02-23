using GrupoAleff.Acesso.Domain.Entities;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.AppService.Interfaces
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Task<Usuario> ObterUsuario(string login, string senha);
    }
}
