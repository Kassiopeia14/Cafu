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