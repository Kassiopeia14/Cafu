using Microsoft.AspNetCore.Mvc;
using modTestWebApiJSONModels;
using modTestChatRepository;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    ITestChatRepository chatRepository;

    public MessageController(ITestChatRepository chatRepository)
    {
        this.chatRepository = chatRepository;
    }       

    [HttpPost]
    public void Create(
        [FromHeader(Name = "sender")] string sender,
        [FromHeader(Name = "receiver")] string receiver,
        [FromBody] MessageItem message)
    {
        chatRepository.SaveMessage(sender, receiver, message);

        Console.WriteLine($"Received POST: {message.Text} from {sender} to {receiver}");
    }
}