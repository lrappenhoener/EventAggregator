namespace EventAggregator.UnitTests;

public class EventAggregatorTests : Tests
{
    protected override IEventAggregator CreateSut()
    {
        return new EventAggregator();
    }
}