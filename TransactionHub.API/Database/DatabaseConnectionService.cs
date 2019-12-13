using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TransactionHub.API
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private SqlConnection _sqlConnection;
        private readonly string _connectionString;

        public void Dispose() 
        {
            if (_sqlConnection == null)
            {
                return;
            }

            _sqlConnection.Dispose();
            _sqlConnection = null;
        }

        public DatabaseConnectionService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<SqlConnection> CreateConnectionAsync()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            await _sqlConnection.OpenAsync();

            return await Task.FromResult(_sqlConnection);
        }

        public SqlConnection CreateConnection()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlConnection.Open();

            return _sqlConnection;
        }
    }
}
