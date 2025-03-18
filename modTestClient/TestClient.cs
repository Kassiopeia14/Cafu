using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace modTestClient;

public class TestClient
{
    string serviceUri = "http://localhost:5005";

    public async Task PostMessage(string message)
    {
        HttpClient httpClient = new HttpClient();
        
        string jsonString = JsonSerializer.Serialize(message);
        
        HttpContent httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        HttpResponseMessage result = await httpClient.PostAsync(serviceUri + "/message", httpContent);
    }

    public async Task<string?> GetTest()
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage result = await httpClient.GetAsync(serviceUri + "/test");

        try
        {
            if (result.IsSuccessStatusCode)
            {
                var stringData = await result.Content.ReadAsStringAsync();

                return stringData;
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("GetTest ERROR: ", ex.ToString());
        }

        return null;
    }
}
