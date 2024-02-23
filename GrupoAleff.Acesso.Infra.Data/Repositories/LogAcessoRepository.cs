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
            var connection = AleffDBContext.GetConnection();
            return await connection.QueryAsync<LogAcesso>("select ac.DataHoraAcesso, a.Nome, ac.EnderecoIp from LogAcesso ac inner join Usuario a on ac.UsuarioId = a.UsuarioId");                        
        }

        public async Task<IEnumerable<LogAcesso>> ObterLogsAcesso(int usuarioId)
        {
            var connection = AleffDBContext.GetConnection();
            var sql = @"select ac.DataHoraAcesso, a.Nome, ac.EnderecoIp from LogAcesso ac inner join Usuario a on ac.UsuarioId = a.UsuarioId
                        where a.usuarioid =@pUsuarioId";
            return await connection.QueryAsync<LogAcesso>(sql, new { pUsuarioId = usuarioId });
        }
    }
}
