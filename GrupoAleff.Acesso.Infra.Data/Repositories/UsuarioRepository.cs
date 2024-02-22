using GrupoAleff.Acesso.Domain.Entities;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;

namespace GrupoAleff.Acesso.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IAleffDBContext aleffDBContext) : base(aleffDBContext)
        {

        }

        //public Task<IEnumerable<Usuario>> ObterPorNome(string nome)
        //{
        //    using (var connection = AleffDBContext.CreateConnection())
        //    {
        //        return connection.Query<Usuario>("select * from usuarios");
        //    }
        //}
    }
}
