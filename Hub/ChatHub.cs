using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace JPT.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinTicketRoom(string ticketId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"ticket-{ticketId}");
        }

        public async Task SendMessage(string ticketId, string user, string message)
        {
            await Clients.Group($"ticket-{ticketId}").SendAsync("ReceiveMessage", user, message, DateTime.UtcNow);
        }
    }
}