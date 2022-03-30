namespace PCC.Libraries.EventAggregator.UnitTests;

public class SampleEvent
{
    public SampleEvent(string message, int time)
    {
        Time = time;
        Message = message;
    }
    
    public string Message { get; private set; } 
    public int Time { get; private set; }
}