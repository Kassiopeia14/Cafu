using System.Net;
using Microsoft.EntityFrameworkCore;
using modTestChatDataStorage;
using modTestChatRepository;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 8080);
});

builder.Services.AddDbContext<ChatDataContext>(options =>
    options.UseNpgsql("Host=localhost;Database=test_cafu;Username=postgres;Password=postgres"));

builder.Services.AddSignalR();

builder.Services.AddScoped<ITestChatRepository, TestChatRepository>();

builder.Services.AddControllers();

builder.Logging.SetMinimumLevel(LogLevel.Error);
builder.Logging.AddFilter("Microsoft", LogLevel.Warning);
builder.Logging.AddFilter("System", LogLevel.Warning);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ChatDataContext>();
    context.Database.Migrate(); 
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Hello from port 8080!");
app.MapHub<MessageHistoryHub>("/messageHistoryHub");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();