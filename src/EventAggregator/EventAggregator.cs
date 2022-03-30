namespace PCC.Libraries.EventAggregator;

public class EventAggregator : IEventAggregator
{
    public void Subscribe<T>(EventHandler<T> handler)
    {
        
    }

    public void Publish<T>(object sender, T @event)
    {
        
    }
}