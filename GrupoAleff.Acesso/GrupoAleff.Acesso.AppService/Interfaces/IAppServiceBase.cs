using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.AppService.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> GetById(int id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Remove(TEntity entity);
    }
    
}
