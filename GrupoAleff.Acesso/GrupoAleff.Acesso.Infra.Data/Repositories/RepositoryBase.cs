
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Infra.Data.Repositories
{
    public  class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        public Task Add(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<TEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task Remove(TEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
