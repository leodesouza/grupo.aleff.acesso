using System.Data;

namespace GrupoAleff.Acesso.Infra.Data.Context
{
    public interface IAleffDBContext
    {
        IDbConnection GetConnection();
    }
}
