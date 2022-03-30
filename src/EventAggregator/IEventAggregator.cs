namespace PCC.Libraries.EventAggregator;

public interface IEventAggregator
{
    void Subscribe<T>(EventHandler<T> handler);
    void Publish<T>(T @event);
}