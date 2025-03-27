namespace modTestChatRepository;

using modTestWebApiJSONModels;

public interface ITestChatRepository
{
    int getUserId(string username);
    int getChatId(string sender, string receiver);

    List<HistoryItem> GetHistory(int chatId);
    
    void SaveMessage(
        int chatId,
        int senderId,
        MessageItem message);

}