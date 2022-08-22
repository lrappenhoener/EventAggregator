namespace EventAggregator.UnitTests;

public class SampleEvent
{
    public SampleEvent(string message, int time)
    {
        Time = time;
        Message = message;
    }

    public string Message { get; }
    public int Time { get; }
}