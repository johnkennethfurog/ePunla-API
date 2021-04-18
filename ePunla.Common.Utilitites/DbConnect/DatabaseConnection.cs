using System;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ePunla.Common.Utilitites.DbConnect
{
    public class DatabaseConnection : IDatabaseConnection
    {

        private readonly string _connectionString;

        public DatabaseConnection(string connectionString) => _connectionString = connectionString ?? throw new ArgumentException(nameof(connectionString));
 
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConn = new SqlConnection(_connectionString);
            await sqlConn.OpenAsync();
            return sqlConn;
        }

        public void Dispose()
        {
        }
    }
}
