using System.Runtime.InteropServices;
using modTestChatDataStorage;
using modTestWebApiJSONModels;

namespace modTestChatRepository;

public class TestChatRepository : ITestChatRepository
{ 
    ChatDataContext chatDataContext;

    public TestChatRepository(ChatDataContext chatDataContext)
    {
        this.chatDataContext = chatDataContext;
    }

    public List<HistoryItem> GetHistory(string sender, string receiver)
    {
        List<HistoryItem> messageHistory = chatDataContext.ChatMessages
            .Where(
                cm => cm.Sender == sender && cm.Receiver == receiver ||
                cm.Sender == receiver && cm.Receiver == sender)
            .Select(cm => new HistoryItem
            { 
                Sender = cm.Sender,
                Receiver = cm.Receiver,
                Message = cm.Text,
                InitTime = cm.TimeStamp
            })
            .OrderBy(cm => cm.InitTime)
            .ToList();

        return messageHistory;
    }

    public void SaveMessage(
        string sender,
        string receiver,
        MessageItem message)
    {
        Random random = new Random();
        int randomId = random.Next(1, 1000);

        chatDataContext.ChatMessages.Add(new ChatMessage
        {
            Id = randomId,
            Sender = sender,
            Receiver = receiver,
            Text = message.Text,
            TimeStamp = DateTime.UtcNow
        });

        chatDataContext.SaveChanges();
    }
}