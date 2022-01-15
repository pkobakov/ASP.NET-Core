using ChatWithSignalR.Models.Chat;
using Microsoft.AspNetCore.SignalR;

namespace ChatWithSignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("NewMessage", new Message() 
            { 
              User = this.Context.User.Identity.Name,
              Text = message
            });
        }
    }
}
