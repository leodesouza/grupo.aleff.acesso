using GrupoAleff.Acesso.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Domain.Interfaces.Repository
{
    public interface ILogAcessoRepository : IRepositoryBase<LogAcesso>
    {
        Task InserirLogAcesso(LogAcesso logAcesso);
        Task<IEnumerable<LogAcesso>> ObterLogsAcesso();
    }
}
