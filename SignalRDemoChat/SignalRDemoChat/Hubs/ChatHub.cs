using Microsoft.AspNetCore.SignalR;
using SignalRDemoChat.Models.Chat;

namespace SignalRDemoChat.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("NewMessage", new Message
            {
                User = this.Context.User.Identity.Name,
                Text = message
            });
        
        }
    }
}
