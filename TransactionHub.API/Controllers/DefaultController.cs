using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TransactionHub.API;

namespace TransactionHub.API.Controllers
{
    //[EnableCors("AllowAll")]
    [ApiController]
    [Route("[controller]")]
    public class DefaultController : Controller
    {
        private readonly IHubContext<MonitorsHub> _hubContext;
        public DefaultController(IHubContext<MonitorsHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public string Get()
        {
            _hubContext.Clients.All.SendAsync("updateStuff", "some random text");
            return "I have been called!";
        }
    }
}