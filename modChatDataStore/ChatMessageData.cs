using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace modChatDataStore;

[Table("messages")]
public class ChatMessageData
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("sender_id")]
    public int SenderId { get; set; }
    public UserData Sender { get; set; }
    
    [Column("chat_id")]
    public int ChatId { get; set; }
    public ChatData Chat { get; set; }

    [Column("text")]
    public required string Text { get; set; }

    [Column("init_time")]
    public DateTime TimeStamp { get; set; }
}