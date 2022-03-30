using System;
using FluentAssertions;
using Xunit;

namespace PCC.Libraries.EventAggregator.UnitTests;

public abstract class Tests
{
    protected abstract IEventAggregator CreateSut();

    [Fact]
    public void Subscribed_Handler_Invoked_When_Event_Published()
    {
        var sut = CreateSut();
        var expectedEvent = new SampleEvent("TestMessage", 42);
        var expectedSender = new object();
        var invoked = false;
        void Handler(object o, SampleEvent e) => invoked = e == expectedEvent && o == expectedSender;
        sut.Subscribe<SampleEvent>(Handler);

        sut.Publish(expectedSender, expectedEvent);

        invoked.Should().BeTrue();
    }
    
    [Fact]
    public void Unsubscribed_Handler_Not_Invoked_When_Event_Published()
    {
        var sut = CreateSut();
        var expectedEvent = new SampleEvent("TestMessage", 42);
        var expectedSender = new object();
        var invoked = false;
        void Handler(object o, SampleEvent e) => invoked = e == expectedEvent && o == expectedSender;
        sut.Subscribe<SampleEvent>(Handler);
        sut.Unsubscribe<SampleEvent>(Handler);

        sut.Publish(expectedSender, expectedEvent);

        invoked.Should().BeFalse();
    }
    
    [Fact]
    public void Unsubscribed_Not_Subscribed_Handler_Not_Throws()
    {
        var sut = CreateSut();
        void Handler(object o, SampleEvent e) { }

        Record.Exception(() => sut.Unsubscribe<SampleEvent>(Handler)).Should().BeNull();
    }
}