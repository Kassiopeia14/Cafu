using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello from TestSignalRClient!");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5005/chatHub")
    .Build();

connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"{user}: {message}");
});

await connection.StartAsync();
Console.WriteLine("Connected to the server.");

Console.WriteLine("Enter your username:");
var user = Console.ReadLine();

Console.WriteLine("Now chat.");
while (true)
{
    var message = Console.ReadLine();
    Console.SetCursorPosition(0, Console.CursorTop - 1);

    await connection.InvokeAsync("SendMessage", user, message);
    Console.WriteLine($"You: {message}");
}