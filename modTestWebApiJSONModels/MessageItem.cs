using System.Text.Json.Serialization;

namespace modTestWebApiJSONModels;

public class MessageItem
{
    [JsonPropertyName("text")]
    public required string Text { get; set; }
}