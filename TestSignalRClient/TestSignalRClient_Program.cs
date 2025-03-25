using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello from TestSignalRClient1!");

var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5005/chatHub")
    .Build();

connection.On<string, string>("ReceiveMessage", (user, message) =>
{
    Console.WriteLine($"{user}: {message}");
});

await connection.StartAsync();
Console.WriteLine("Connected to the server.");

string user = "TestSignalRClient1";

while (true)
{
    var message = Console.ReadLine();

    await connection.InvokeAsync("SendMessage", user, message);
}