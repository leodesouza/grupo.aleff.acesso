using System.Data;
using System.Data.SqlClient;

namespace GrupoAleff.Acesso.Infra.Data.Context
{
    public class AleffDBContext : IAleffDBContext
    {
        IDbConnection _dbConnection;
        public AleffDBContext(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IDbConnection GetConnection()
        {
            return _dbConnection;
        }
      
    }
}
