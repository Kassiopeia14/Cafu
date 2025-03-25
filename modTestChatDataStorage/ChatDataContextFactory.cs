using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace modTestChatDataStorage;

public class ChatDataContextFactory : IDesignTimeDbContextFactory<ChatDataContext>
{
    public ChatDataContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ChatDataContext> optionsBuilder = new DbContextOptionsBuilder<ChatDataContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=test_cafu;Username=postgres;Password=postgres");

        return new ChatDataContext(optionsBuilder.Options);
    }
}