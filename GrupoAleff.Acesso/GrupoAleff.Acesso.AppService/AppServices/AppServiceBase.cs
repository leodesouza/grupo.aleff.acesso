using GrupoAleff.Acesso.AppService.Interfaces;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.AppService.AppServices
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;
        public AppServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }
        public async Task Add(TEntity entity)
        {
            await _repositoryBase.Add(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task Remove(TEntity entity)
        {
            await _repositoryBase.Remove(entity);
        }
    }
}
