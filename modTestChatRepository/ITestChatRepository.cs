namespace modTestChatRepository;

using modTestWebApiJSONModels;

public interface ITestChatRepository
{
    void SaveMessage(
        string sender,
        string receiver,
        MessageItem message);

}