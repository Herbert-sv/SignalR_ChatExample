using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ChatTest.Models
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string UserName, string Message)
        {
            await Clients.All.SendAsync("ReceivedMessage", UserName, Message);
        }

        public override Task OnConnectedAsync()
        {
            return
            Clients.All.SendAsync(Context.ConnectionId);
        }


    }
}
