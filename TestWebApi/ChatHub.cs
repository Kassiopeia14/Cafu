using Microsoft.AspNetCore.SignalR;
using modTestChatRepository;
using modTestWebApiJSONModels;

public class ChatHub : Hub
{
    ITestChatRepository chatRepository;

    public ChatHub(ITestChatRepository chatRepository)
    {
        this.chatRepository = chatRepository;
    }       

    public async Task SendMessage(string user, string message)
    {
        chatRepository.SaveMessage(
            user, 
            $"everyone_except_{user}", 
            new MessageItem { Text = message });

        await Clients
            .AllExcept(Context.ConnectionId)
            .SendAsync("ReceiveMessage", user, message);
    }
}