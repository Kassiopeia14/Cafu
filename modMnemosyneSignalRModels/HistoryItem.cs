namespace modMnemosyneSignalRModels;

public class HistoryItem
{
    public required string Sender { get; set; }
    
    public required string Message { get; set; }

    public required DateTime InitTime { get; set; }
}
