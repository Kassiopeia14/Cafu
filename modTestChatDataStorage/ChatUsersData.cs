using System.ComponentModel.DataAnnotations.Schema;

namespace modTestChatDataStorage;

[Table("chat_members")]
public class ChatUsersData
{
    [Column("chat_id")]
    public required int ChatId { get; set; }
    public ChatData Chat { get; set; }
        
    [Column("user_id")]
    public required int UserId { get; set; }
    public UserData User { get; set; }
}