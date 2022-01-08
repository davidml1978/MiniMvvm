using MiniMvvm.Events;

using System;

using Xunit;

namespace MiniMvvmTests.Events
{
    public class EventAggregatorTests
    {
        [Fact]
        public void GetEvent_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eventAggregator = new EventAggregator();

            // Act
            var instance1 = eventAggregator.GetEvent<MockEventBase>();
            var instance2 = eventAggregator.GetEvent<MockEventBase>();

            // Assert
            Assert.Same(instance1, instance2);
        }

    }
    public class MockEventBase : EventBase
    {

    }
}
