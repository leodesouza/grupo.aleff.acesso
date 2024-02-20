using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Remove(TEntity entity);
    }
}
