namespace EventAggregator;

public interface IEventAggregator
{
    void Subscribe<T>(EventHandler<T> handler);
    void Subscribe(Type eventType, object handler);
    void Publish<T>(object sender, T @event);
    void Unsubscribe<T>(EventHandler<T> handler);
    void Unsubscribe(Type eventType, object handler);
}