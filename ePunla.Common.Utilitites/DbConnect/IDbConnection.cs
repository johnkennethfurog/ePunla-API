using System;
using System.Data;
using System.Threading.Tasks;

namespace ePunla.Common.Utilitites.DbConnect
{
    public interface IDatabaseConnection : IDisposable
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
