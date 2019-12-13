using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.SignalR;

namespace TransactionHub.API
{
    //[EnableCors("AllowAll")]
    public class MonitorsHub : Hub
    {
        private readonly ITableRepository _repository;

        public MonitorsHub(ITableRepository repository)
        {
            _repository = repository;
        }

        public Task BroadcastTransaction(string test)
        {
            Console.WriteLine("testing ");
            return Clients.All.SendAsync("BroadcastTransaction", _repository.Transaction);
        }

        public override async Task OnConnectedAsync() 
        { 
            await  Clients.Caller.SendAsync("BroadcastTransaction" , _repository.Transaction, _repository.ValidAccount, _repository.NotValidAccount); 
        } 
    }
}
