using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.AppService.AppServices
{
    public class LogAcessoAppService : AppServiceBase<LogAcesso>, ILogAcessoAppService
    {
        private readonly ILogAcessoRepository _logAcessoRepository;
        public LogAcessoAppService(ILogAcessoRepository logAcessoRepository) : base(logAcessoRepository)
        {
            _logAcessoRepository = logAcessoRepository;
        }

        public async Task InserirLogAcesso(LogAcesso logAcesso)
        {
            await _logAcessoRepository.InserirLogAcesso(logAcesso);
        }

        public async Task<IEnumerable<LogAcesso>> ObterLogsAcesso()
        {
            return await _logAcessoRepository.ObterLogsAcesso();
        }        
    }
}
