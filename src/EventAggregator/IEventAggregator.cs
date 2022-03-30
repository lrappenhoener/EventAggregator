namespace PCC.Libraries.EventAggregator;

public interface IEventAggregator
{
    void Subscribe<T>(EventHandler<T> handler);
}