using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients
            .AllExcept(Context.ConnectionId)
            .SendAsync("ReceiveMessage", user, message);
    }
}