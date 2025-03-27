using Microsoft.EntityFrameworkCore;

namespace modTestChatDataStorage;

public class ChatDataContext : DbContext
{
    public DbSet<ChatMessageData> ChatMessages { get; set; }
    public DbSet<ChatData> Chats { get; set; }
    public DbSet<ChatUsersData> ChatUsers { get; set; }
    public DbSet<UserData> Users { get; set; }

    public ChatDataContext(DbContextOptions<ChatDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessageData>().HasKey(x => new { x.Id });
        
        modelBuilder.Entity<ChatMessageData>()
            .HasOne(x => x.Sender)
            .WithMany()
            .HasForeignKey(x => x.SenderId);
        
        modelBuilder.Entity<ChatMessageData>()
            .HasOne(x => x.Chat)
            .WithMany()
            .HasForeignKey(x => x.ChatId);

        modelBuilder.Entity<ChatData>().HasKey(x => new { x.Id });
        modelBuilder.Entity<UserData>().HasKey(x => new { x.Id });
        
        modelBuilder.Entity<ChatUsersData>()
            .HasKey(x => new { x.UserId, x.ChatId });

        modelBuilder.Entity<ChatUsersData>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId);
        
        modelBuilder.Entity<ChatUsersData>()
            .HasOne(x => x.Chat)
            .WithMany()
            .HasForeignKey(x => x.ChatId);
    }
}
