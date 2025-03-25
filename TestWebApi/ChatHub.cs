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

    public async Task SendMessage(
        string sender, 
        string receiver, 
        string message)
    {
        chatRepository.SaveMessage(
            sender, 
            receiver, 
            new MessageItem { Text = message });

        await Clients
            .AllExcept(Context.ConnectionId)
            .SendAsync("ReceiveMessage", sender, message);
    }
}