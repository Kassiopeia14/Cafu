using Microsoft.AspNetCore.Mvc;
using modTestWebApiJSONModels;
using modTestChatRepository;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    ITestChatRepository chatRepository;
    IHubContext<MessageHistoryHub> messageHistoryHubContext;

    public MessageController(
        ITestChatRepository chatRepository,
        IHubContext<MessageHistoryHub> messageHistoryHubContext)
    {
        this.chatRepository = chatRepository;
        this.messageHistoryHubContext = messageHistoryHubContext;
    }       

    [HttpPost]
    public void Create(
        [FromHeader(Name = "sender")] string sender,
        [FromHeader(Name = "receiver")] string receiver,
        [FromBody] MessageItem message)
    {
        int chatId = chatRepository.getChatId(sender, receiver);
        int senderId = chatRepository.getUserId(sender);        

        chatRepository.SaveMessage(chatId, senderId, message);
        
        messageHistoryHubContext.Clients.All.SendAsync("SendMessage", sender, receiver, message);
    }
}