namespace modTestClient;

public class TestClient
{
    public TestClient()
    {
        
    }

    public async Task<string?> GetTest()
    {
        string uri = "http://localhost:5005";

        HttpClient httpClient = new HttpClient();
        HttpResponseMessage result = await httpClient.GetAsync(uri + "/test");

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
