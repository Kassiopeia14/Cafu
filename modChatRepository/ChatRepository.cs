using modChatDataStore;
using modMnemosyneSignalRModels;
using modMnemosyneJSONModels;

namespace modChatRepository;

public class ChatRepository : IChatRepository
{
    ChatDataContext chatDataContext;

    public ChatRepository(ChatDataContext _chatDataContext)
    {
        chatDataContext = _chatDataContext;
    }

        public int getUserId(string username)
    {
        int userId = chatDataContext.Users
            .Where(u => u.Username == username)
            .Select(u => u.Id)
            .FirstOrDefault();

        if (userId == 0)
        {
            chatDataContext.Users.Add(new UserData
            {
                Username = username
            });

            chatDataContext.SaveChanges();
        }

        userId = chatDataContext.Users
            .Where(u => u.Username == username)
            .Select(u => u.Id)
            .FirstOrDefault();

        //Console.WriteLine($"User {username} has id {userId}");

        return userId;
    }

        public int getChatId(string sender, string receiver)
    {
        int senderId = getUserId(sender);
        int receiverId = getUserId(receiver);

        int chatId = chatDataContext.ChatUsers
            .Where(cu => cu.UserId == receiverId || cu.UserId == senderId)
            .GroupBy(cu => cu.ChatId)
            .Where(g =>
                g.Any(cu => cu.UserId == senderId) &&
                g.Any(cu => cu.UserId == receiverId))
            .Select(g => g.Key)
            .FirstOrDefault();

        if (chatId == 0)
        {
            string chatName = $"{sender} and {receiver}";
            
            chatDataContext.Chats.Add(new ChatData
            {
                Name = $"{sender} and {receiver}"
            });

            chatDataContext.SaveChanges();

            chatId = chatDataContext.Chats
                .Where(c => c.Name == chatName)
                .Select(c => c.Id)
                .FirstOrDefault();

            chatDataContext.ChatUsers.Add(new ChatUsersData
            {
                UserId = senderId,
                ChatId = chatId
            });
            
            chatDataContext.ChatUsers.Add(new ChatUsersData
            {
                UserId = receiverId,
                ChatId = chatId
            });
            
            chatDataContext.SaveChanges();
        }

        //Console.WriteLine($"Chat for {sender} and {receiver} has id {chatId}");

        return chatId;
    }

    public List<HistoryItem> GetHistory(int chatId)
    {
        List<HistoryItem> messageHistory = chatDataContext.ChatMessages
            .Where(cm => cm.ChatId == chatId)
            .Select(c => new HistoryItem
            { 
                Sender = c.Sender.Username,
                Message = c.Text,
                InitTime = c.TimeStamp
            })
            .OrderBy(hi => hi.InitTime)
            .ToList();

        return messageHistory;
    }

    public void SaveMessage(
        int chatId,
        int senderId,
        MessageItem message)
    {
        chatDataContext.ChatMessages.Add(new ChatMessageData
        {
            SenderId = senderId,
            ChatId = chatId,
            Text = message.Text,
            TimeStamp = DateTime.UtcNow
        });

        chatDataContext.SaveChanges();
    }
}