using GrupoAleff.Acesso.Domain.Entities;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository: IRepositoryBase<Usuario>
    {
        Task<Usuario> ObterUsuario(string login, string senha);
    }
}
