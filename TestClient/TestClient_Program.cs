using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello from TestClient!");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:8080/messageHistoryHub")
    .WithAutomaticReconnect()
    .Build();

connection.On<string>("ChatNotification", (notification) =>
{
    Console.WriteLine($"{notification}");
});

Console.WriteLine("Enter your username:");
var sender = Console.ReadLine();

Console.WriteLine("Enter receiver's username:");
var receiver = Console.ReadLine();

connection.On<List<HistoryItem>>("ReceiveHistory", (messageHistory) =>
{
    foreach(var historyItem in messageHistory)
    {
        if(historyItem.Sender.Equals(sender))
        {
            Console.WriteLine($"you: {historyItem.Message}");
        }
        else
        {
            Console.WriteLine($"{historyItem.Sender}: {historyItem.Message}");
        }
    }
});

connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    if(user.Equals(sender))
    {
        Console.WriteLine($"you: {message}");
        return;
    }
    
    Console.WriteLine($"{user}: {message}");
});

await connection.StartAsync();

await connection.InvokeAsync("GetMessages", sender, receiver);

while (true)
{
    var message = Console.ReadLine();
    Console.SetCursorPosition(0, Console.CursorTop - 1);

    await connection.InvokeAsync("SendMessage", sender, receiver, message);
}