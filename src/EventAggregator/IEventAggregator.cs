namespace PCC.Libraries.EventAggregator;

public interface IEventAggregator
{
    void Subscribe<T>(EventHandler<T> handler);
    void Publish<T>(object sender, T @event);
    void Unsubscribe<T>(EventHandler<T> handler);
}