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
        int senderId = chatRepository.getUserId(sender);
        int chatId = chatRepository.getChatId(sender, receiver);

        chatRepository.SaveMessage(
            chatId, 
            senderId, 
            new MessageItem { Text = message });

        await Clients.Group($"chat-{chatId}").SendAsync("ReceiveMessage", sender, message);
    }

    public async Task GetMessages(string sender, string receiver)
    {
        await Clients.Caller.SendAsync("ReceiveMessage", "Server", "Connected");

        int chatId = chatRepository.getChatId(sender, receiver);
        List<HistoryItem> messageHistory = chatRepository.GetHistory(chatId);

        await Clients.Caller.SendAsync("ReceiveHistory", messageHistory);

        string groupName = $"chat-{chatId}";
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        await Clients.Group(groupName).SendAsync("ChatNotification", $"{sender} is online!");
    }
}