using modTestClient;

TestClient testClient = new TestClient();

string? result = await testClient.GetTest();

Console.WriteLine($"TestClient result: {result}");