using System.Text.Json.Serialization;

namespace modTestWebApiJSONModels;

public class MessageItem
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}