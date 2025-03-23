using modTestHTTPClient;
using modTestWebApiJSONModels;

TestHTTPClient testClient = new TestHTTPClient();

string? result = await testClient.GetTest();

Console.WriteLine($"TestClient result: {result}");

string 
    sender = "SENDER",
    receiver = "RECEIVER";

MessageItem message = new MessageItem
{
    Text = "BUBA"
};

await testClient.PostMessage(sender, receiver, message);