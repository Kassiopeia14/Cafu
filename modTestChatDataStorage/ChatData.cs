using System.ComponentModel.DataAnnotations.Schema;

namespace modTestChatDataStorage;

[Table("chats")]
public class ChatData
{
    [Column("id")]
    public int Id { get; set; }
        
    [Column("name")]
    public string? Name { get; set; }
}