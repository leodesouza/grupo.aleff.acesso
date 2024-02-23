using Dapper;
using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IAleffDBContext aleffDBContext) : base(aleffDBContext)
        {

        }

        public async Task<Usuario> ObterUsuario(string login, string senha)
        {
            var connection = AleffDBContext.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<Usuario>("select * from usuario where Login=@pLogin and Senha=@pSenha",
                new
                {
                    pLogin = login,
                    pSenha = senha
                });           
        }
        
    }
}
