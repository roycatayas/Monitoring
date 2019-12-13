using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.Enums;
using TableDependency.SqlClient.Base.EventArgs;

namespace TransactionHub.API
{
    public class TableRepository : ITableRepository
    {
        private readonly SqlConnection _sqlConnection;
        private readonly IHubContext<MonitorsHub> _hubContext;
        private SqlTableDependency<Transaction> _tableDependency;
        readonly string _connectionString = "Data Source=localhost;Initial Catalog=APMonitor;Integrated Security=True;";

        public TableRepository(IDatabaseConnectionService databaseConnection,IHubContext<MonitorsHub> hubContext)
        {
            _sqlConnection = databaseConnection.CreateConnection();
            _hubContext = hubContext;

            _tableDependency = new SqlTableDependency<Transaction>(_sqlConnection.ConnectionString, "tblTransaction");
            _tableDependency.OnChanged += Changed;
            _tableDependency.OnError += TableDependency_OnError;
            _tableDependency.Start();
        }

        public IEnumerable<Transaction> Transaction => GetTransaction();
        public int ValidAccount => GetAccessCount();
        public int NotValidAccount => GetNotValidAccessCount();

        public Task AddTransactionAsync(Transaction data)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<Transaction> GetTransaction()
        {
            var transaction = new List<Transaction>(); 
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "select top 300 * from tblTransaction order by TransactionNo desc";

                using var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    var transactionno = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("TransactionNo"));
                    var userid = sqlDataReader.GetString(sqlDataReader.GetOrdinal("UserID"));
                    var username = sqlDataReader.GetString(sqlDataReader.GetOrdinal("UserName"));
                    var rfidcardnumber = sqlDataReader.GetString(sqlDataReader.GetOrdinal("RFIDCardNumber"));
                    var controllerid = sqlDataReader.GetString(sqlDataReader.GetOrdinal("ControllerID"));
                    var doornumber = sqlDataReader.GetString(sqlDataReader.GetOrdinal("DoorNumber"));
                    var eventalarmcode = sqlDataReader.GetString(sqlDataReader.GetOrdinal("EventAlarmCode"));
                    var transactiontype = sqlDataReader.GetString(sqlDataReader.GetOrdinal("TransactionType"));
                    var cardreadername = sqlDataReader.GetString(sqlDataReader.GetOrdinal("CardReaderName"));
                    var transactiondescription = sqlDataReader.GetString(sqlDataReader.GetOrdinal("TransactionDescription"));
                    var transactiondate = sqlDataReader.GetDateTime(sqlDataReader.GetOrdinal("TransactionDate"));

                    var item = new Transaction
                    {
                        TransactionNo = transactionno,
                        UserID = userid,
                        UserName = username,
                        RFIDCardNumber = rfidcardnumber,
                        ControllerID = controllerid,
                        DoorNumber = doornumber,
                        EventAlarmCode = eventalarmcode,
                        TransactionType = transactiontype,
                        CardReaderName = cardreadername,
                        TransactionDescription = transactiondescription,
                        TransactionDate = transactiondate.ToString("G")
                    };

                    transaction.Add(item);
                }
            }
            return transaction;
        }

        private int GetAccessCount()
        {
            int validaccess = 0;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "Select count(TransactionType) as ValidAccess from [tblTransaction] where TransactionType = 'Access'";

                using var sqlDataReader = sqlCommand.ExecuteReader();
                
                while (sqlDataReader.Read())
                {
                    validaccess = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("ValidAccess"));
                }
            }
            return validaccess;
        }

        private int GetNotValidAccessCount()
        {
            int notValidAccess = 0;
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                using var sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = "Select count(TransactionType) as NoValidAccess from [tblTransaction] where TransactionType = 'No Access'";

                using var sqlDataReader = sqlCommand.ExecuteReader();
                
                while (sqlDataReader.Read())
                {
                    notValidAccess = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("NoValidAccess"));
                }
            }
            return notValidAccess;
        }

        private void TableDependency_OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"SqlTableDependency error: {e.Error.Message}");
        }

        private void Changed(object sender, RecordChangedEventArgs<Transaction> e)
        {
            if (e.ChangeType != ChangeType.None)
            {
                Console.WriteLine("something is happening");
                _hubContext.Clients.All.SendAsync("UpdateTransaction", Transaction,ValidAccount,NotValidAccount);
            }
        }

        #region IDisposable
        private bool disposedValue = false;
        ~TableRepository()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _tableDependency.Stop();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
