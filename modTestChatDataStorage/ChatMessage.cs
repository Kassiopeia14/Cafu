using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace modTestChatDataStorage;

[Table("messages")]
public class ChatMessage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("sender")]
    public required string Sender { get; set; }
    
    [Column("receiver")]
    public required string Receiver { get; set; }

    [Column("text")]
    public required string Text { get; set; }

    [Column("init_time")]
    public DateTime TimeStamp { get; set; }
}