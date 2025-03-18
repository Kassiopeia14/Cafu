Console.WriteLine("Hello from TestExe!");

string uri = "http://localhost:5005";

HttpClient httpClient = new HttpClient();
HttpResponseMessage result = await httpClient.GetAsync(uri + "/weatherforecast");

if (result.IsSuccessStatusCode)
{
    var stringData = await result.Content.ReadAsStringAsync();

    Console.WriteLine(stringData);
}