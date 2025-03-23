using modTestHTTPClient;

TestHTTPClient testClient = new TestHTTPClient();

string? result = await testClient.GetTest();

Console.WriteLine($"TestClient result: {result}");

await testClient.PostMessage("TEST MESSAGE");