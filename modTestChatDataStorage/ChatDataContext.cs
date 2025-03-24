using Microsoft.EntityFrameworkCore;

namespace modTestChatDataStorage;

public class ChatDataContext : DbContext
{
    public DbSet<ChatMessage> ChatMessages { get; set; }

    public ChatDataContext(DbContextOptions<ChatDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>().HasKey(x => new { x.Id });
    }
}
