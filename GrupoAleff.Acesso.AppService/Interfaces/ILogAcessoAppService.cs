using GrupoAleff.Acesso.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.AppService.Interfaces
{
    public interface ILogAcessoAppService : IAppServiceBase<LogAcesso>
    {
        Task InserirLogAcesso(LogAcesso logAcesso);
        Task<IEnumerable<LogAcesso>> ObterLogsAcesso();
        Task<IEnumerable<LogAcesso>> ObterLogsAcesso(int usuarioId );
    }
}
