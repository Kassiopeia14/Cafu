using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using modChatRepository;
using modMnemosyneHub;
using modMnemosyneJSONModels;

[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    IChatRepository chatRepository;
    IHubContext<MnemosyneHub> mnemosyneHubContext;

    public MessageController(
        IChatRepository chatRepository,
        IHubContext<MnemosyneHub> mnemosyneHubContext)
    {
        this.chatRepository = chatRepository;
        this.mnemosyneHubContext = mnemosyneHubContext;
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
        
        mnemosyneHubContext.Clients.All.SendAsync("SendMessage", sender, receiver, message);
    }
}