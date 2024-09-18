using Microsoft.AspNetCore.SignalR;

namespace JordanChat.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub() { }

        public async Task JoinAsync(string channel)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, channel);
        }

        public async Task BroadcastMessageAsync(string message, string channel)
        {
            await Clients.Group(channel).SendAsync("OnBroadcast", message);
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine(Context.ConnectionId + " is connected!");
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine(Context.ConnectionId + " has disconnected!");

        }
    }
}
