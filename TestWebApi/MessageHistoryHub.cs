using Microsoft.AspNetCore.SignalR;
using modTestChatRepository;
using modTestWebApiJSONModels;

public class MessageHistoryHub : Hub
{
    ITestChatRepository chatRepository;

    public MessageHistoryHub(ITestChatRepository chatRepository)
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

    public async Task GetMessages(string sender, string receiver)
    {
        List<HistoryItem> messageHistory = chatRepository.GetHistory(sender, receiver);

        await Clients.Caller.SendAsync("ReceiveHistory", messageHistory);
    }
}