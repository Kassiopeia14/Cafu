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
        chatDataContext.ChatMessages.Add(new ChatMessage
        {
            Sender = sender,
            Receiver = receiver,
            Text = message.Text,
            TimeStamp = DateTime.UtcNow
        });

        chatDataContext.SaveChanges();
    }
}