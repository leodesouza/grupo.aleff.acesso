using Dapper;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Infra.Data.Repositories
{
    public class LogAcessoRepository : RepositoryBase<LogAcesso>, ILogAcessoRepository
    {
        public LogAcessoRepository(IAleffDBContext aleffDBContext) : base(aleffDBContext)
        {

        }

        public async Task InserirLogAcesso(LogAcesso logAcesso)
        {
           
            var connection = AleffDBContext.GetConnection();

            await connection.ExecuteAsync("INSERT INTO LOGACESSO(UsuarioId, DataHoraAcesso, EnderecoIp) VALUES (@pUsuarioId, @pDataHoraAcesso,@pEnderecoId)",
                new
                {
                    pUsuarioId = logAcesso.UsuarioId,
                    pDataHoraAcesso = DateTime.Now,
                    @pEnderecoId = logAcesso.EnderecoIp
                });          
        }

        public async Task<IEnumerable<LogAcesso>> ObterLogsAcesso()
        {
            try
            {
                var connection = AleffDBContext.GetConnection();

                return await connection.QueryAsync<LogAcesso>("select ac.DataHoraAcesso, a.Nome, ac.EnderecoIp from LogAcesso ac inner join Usuario a on ac.UsuarioId = a.UsuarioId");

            }catch(Exception ex)
            {
                var p = 0;
            }

            return new List<LogAcesso>();
        }
    }
}
