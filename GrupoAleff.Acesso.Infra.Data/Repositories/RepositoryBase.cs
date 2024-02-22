
using Dapper;
using GrupoAleff.Acesso.Domain.Interfaces.Repository;
using GrupoAleff.Acesso.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

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

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var tableName = typeof(TEntity).Name;
            
            var connection = AleffDBContext.GetConnection();
            string sql = "SELECT * FROM " + typeof(TEntity).Name ;

            return await connection.QueryAsync<TEntity>(sql);
        }

        public async Task<TEntity> GetById(int id)
        {
            var tableName = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var Id = properties.FirstOrDefault(p => p.Name.Contains(tableName)).Name;
                    
            var connection = AleffDBContext.GetConnection();
            string sql = "SELECT * FROM " + typeof(TEntity).Name + $" WHERE {Id} = @Id";

            return await connection.QueryFirstOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

        public async Task Remove(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var Id = properties.FirstOrDefault(p => p.Name.Contains(tableName)).Name;
            var IdVaue = properties.FirstOrDefault(p => p.Name.Contains(tableName)).GetValue(entity);
            
            var connection = AleffDBContext.GetConnection();
            string sql = "DELETE FROM " + typeof(TEntity).Name + $" WHERE {Id} = @Id";

            await connection.ExecuteScalarAsync<TEntity>(sql, new { Id = IdVaue });
        }

        public async Task Update(TEntity entity)
        {
            var tableName = typeof(TEntity).Name;
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        
            var queryParams = string.Join(",", properties.Where(p => !p.Name.Contains(tableName)).Select(p =>
                    (p.Name + "=" + (p.GetValue(entity).GetType() == typeof(string) ? $"'{p.GetValue(entity)}'" : p.GetValue(entity)))
                ));
            
            var Id = properties.FirstOrDefault(p => p.Name.Contains(tableName)).Name;
            var IdVaue = properties.FirstOrDefault(p => p.Name.Contains(tableName)).GetValue(entity);

            var connection = AleffDBContext.GetConnection();

            var sql = $"UPDATE {tableName} set {queryParams}" + $" WHERE {Id} = @Id";

            await connection.ExecuteScalarAsync<TEntity>(sql, new { Id = IdVaue });
        }
    }
}
