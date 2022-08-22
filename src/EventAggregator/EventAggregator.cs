namespace EventAggregator;

public class EventAggregator : IEventAggregator
{
    private readonly Dictionary<Type, List<object>> _handlers = new();

    #region IEventAggregator Members

    public void Subscribe<T>(EventHandler<T> handler)
    {
        var type = typeof(T);
        Subscribe(type, handler);
    }

    public void Subscribe(Type eventType, object handler)
    {
        if (!_handlers.ContainsKey(eventType))
            _handlers.Add(eventType, new List<object>());
        if (_handlers[eventType].Contains(handler)) return;
        _handlers[eventType].Add(handler);
    }

    public void Publish<T>(object sender, T @event)
    {
        var eventType = typeof(T);
        if (!_handlers.ContainsKey(eventType)) return;
        var handlers = _handlers[eventType].Select(h =>
        {
            if (h is EventHandler<T> eventHandler)
                return eventHandler;
            if (h is Action<object, T> action)
                return (o, e) => action(o, e);
            return null;
        });
        foreach (var handler in handlers) handler?.Invoke(sender, @event);
    }

    public void Unsubscribe<T>(EventHandler<T> handler)
    {
        var type = typeof(T);
        Unsubscribe(type, handler);
    }

    public void Unsubscribe(Type eventType, object handler)
    {
        if (!_handlers.ContainsKey(eventType))
            return;
        _handlers[eventType].Remove(handler);
    }

    #endregion
}