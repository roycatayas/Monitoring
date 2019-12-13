using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransactionHub.API
{
    public interface ITableRepository
    {
        IEnumerable<Transaction> Transaction { get; }
        Task AddTransactionAsync(Transaction data);
        int ValidAccount { get; }
        int NotValidAccount { get; }
    }
}
