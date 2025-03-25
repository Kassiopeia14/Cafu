namespace modTestChatRepository;

using modTestWebApiJSONModels;

public interface ITestChatRepository
{
    List<HistoryItem> GetHistory(string sender, string receiver);
    
    void SaveMessage(
        string sender,
        string receiver,
        MessageItem message);

}