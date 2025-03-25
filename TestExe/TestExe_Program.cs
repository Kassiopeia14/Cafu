using modTestHTTPClient;
using modTestWebApiJSONModels;

TestHTTPClient testClient = new TestHTTPClient();

string? result = await testClient.GetTest();

Console.WriteLine($"TestClient result: {result}");

string 
    sender = "SENDER",
    receiver = "RECEIVER";

Random random = new Random();

MessageItem message = new MessageItem
{
    Text = "BUBA" + random.Next(0, 100).ToString()
};

await testClient.PostMessage(sender, receiver, message);