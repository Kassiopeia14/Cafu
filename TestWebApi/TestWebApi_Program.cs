using Microsoft.EntityFrameworkCore;
using modTestChatDataStorage;
using modTestChatRepository;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel((context, serverOptions) =>
{
    serverOptions.ListenAnyIP(5005);
});;

builder.Services.AddDbContext<ChatDataContext>(options =>
    options.UseNpgsql("Host=localhost;Database=test_cafu;Username=postgres;Password=postgres"));

builder.Services.AddSignalR();

builder.Services.AddScoped<ITestChatRepository, TestChatRepository>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ChatDataContext>();
    context.Database.Migrate(); // ← this runs all pending migrations!
}

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapHub<ChatHub>("/chatHub");
app.MapHub<MessageHistoryHub>("/messageHistoryHub");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();