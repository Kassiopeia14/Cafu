using Microsoft.AspNetCore.Mvc;
using modTestWebApiJSONModels;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    [HttpPost]
    public void Create(
        [FromHeader(Name = "sender")] string sender,
        [FromHeader(Name = "receiver")] string receiver,
        [FromBody] MessageItem message)
    {
        Console.WriteLine($"Received POST: {message.Text} from {sender} to {receiver}");
    }
}