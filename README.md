# EventAggregator

Decoupled event communication

Example:
```
public class Program
{
  public static void Main()
  {
     var eventAggregator = new EventAggregator();
     var a = new A(eventAggregator);
     var b = new B(eventAggregator);
     eventAggregator.Publish(new SampleEvent("Hello Listeners"));
  }
}

public class A
{
  public A(IEventAggregator eventAggregator)
  {
      // listen for events of event type SampleEvent
      eventAggregator.Subscribe<SampleEvent>(OnSampleEvent);
  }
  
  private void OnSampleEvent(object? o, SampleEvent e)
  {
    // process event ...
  }
}

public class B
{
  public B(IEventAggregator eventAggregator)
  {
      // listen for events of event type SampleEvent
      eventAggregator.Subscribe<SampleEvent>(OnSampleEvent);
  }
  
  private void OnSampleEvent(object? o, SampleEvent e)
  {
    // process event ...
  }
}

public class SampleEvent
{
    public SampleEvent(string message)
    {
        Message = message;
    }

    public string Message { get; }
}

```
