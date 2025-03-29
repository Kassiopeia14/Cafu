using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace modChatDataStore;

[Table("users")]
public class UserData
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
        
    [Column("username")]
    public required string Username { get; set; }
}