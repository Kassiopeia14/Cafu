using Microsoft.AspNetCore.SignalR.Client;
using modTestWebApiJSONModels;

Console.WriteLine("Hello from TestSignalRHistoryClient!");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5005/messageHistoryHub")
    .Build();

connection.On<List<HistoryItem>>("ReceiveHistory", (messageHistory) =>
{
    foreach(var historyItem in messageHistory)
    {
        Console.WriteLine($"{historyItem.Sender}: {historyItem.Message}");
    }
});

connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"{user}: {message}");
});

await connection.StartAsync();
Console.WriteLine("Connected to the server.");

Console.WriteLine("Enter your username:");
var sender = Console.ReadLine();

Console.WriteLine("Enter receiver's username:");
var receiver = Console.ReadLine();

await connection.InvokeAsync("GetMessages", sender, receiver);

while (true)
{
    var message = Console.ReadLine();
    Console.SetCursorPosition(0, Console.CursorTop - 1);

    await connection.InvokeAsync("SendMessage", sender, receiver, message);
    Console.WriteLine($"you: {message}");
}