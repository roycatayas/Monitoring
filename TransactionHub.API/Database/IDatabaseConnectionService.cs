using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TransactionHub.API
{
    public interface IDatabaseConnectionService : IDisposable
    {
        Task<SqlConnection> CreateConnectionAsync();
        SqlConnection CreateConnection();
    }
}
