using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;

namespace GrupoAleff.Acesso.Infra.Data.Repositories
{
    public class LogAcessoRepository: RepositoryBase<LogAcesso>, ILogAcessoRepository
    {       
        public LogAcessoRepository(IAleffDBContext aleffDBContext) : base(aleffDBContext)
        {

        }
    }
}
