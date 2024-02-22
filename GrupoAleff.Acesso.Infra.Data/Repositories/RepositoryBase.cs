
using Dapper;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GrupoAleff.Acesso.Infra.Data.Repositories
{
    public  class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IAleffDBContext AleffDBContext;

        public RepositoryBase(IAleffDBContext aleffDBContext)
        {
            AleffDBContext = aleffDBContext;
        }

        public async Task Add(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var columns = string.Join(",", properties.Where(p => !p.Name.Contains(tableName)).Select(p => p.Name));

            var values = string.Join(",", properties.Where(p => !p.Name.Contains(tableName)).Select( p => 
                    (p.GetValue(entity).GetType() == typeof(string) ? $"'{p.GetValue(entity)}'" : p.GetValue(entity)) 
                ));

            var connection = AleffDBContext.GetConnection();

            var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
            
            await connection.ExecuteAsync(sql);                        
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
