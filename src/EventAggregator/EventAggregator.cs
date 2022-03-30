namespace PCC.Libraries.EventAggregator;

public class EventAggregator : IEventAggregator
{
    private readonly Dictionary<Type, List<object>> _handlers =
        new Dictionary<Type, List<object>>();

    public void Subscribe<T>(EventHandler<T> handler)
    {
        var type = typeof(T);
        if (!_handlers.ContainsKey(type))
            _handlers.Add(type, new List<object>());
        _handlers[type].Add(handler);
    }

    public void Publish<T>(object sender, T @event)
    {
        
    }
}