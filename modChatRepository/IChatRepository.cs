using modMnemosyneJSONModels;
using modMnemosyneSignalRModels;

namespace modChatRepository;

public interface IChatRepository
{
    int getUserId(string username);
    int getChatId(string sender, string receiver);

    List<HistoryItem> GetHistory(int chatId);
    
    void SaveMessage(
        int chatId,
        int senderId,
        MessageItem message);
}
