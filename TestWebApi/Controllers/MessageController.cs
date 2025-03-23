using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    [HttpPost]
    public void Create([FromBody] string message)
    {
        Console.WriteLine($"Received POST: {message}");
    }
}