using MiniMvvm.Events;

using System;
using System.Linq;

using Xunit;

namespace MiniMvvmTests.Events
{
    public class PubSubEventTest : PubSubEvent<int>
    {

    }
    public class PubSubEventTests
    {
        public bool PublishCalled { get; private set; }

        [Fact]
        public void Subscribe_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pubSubEvent = new PubSubEventTest();
            Action<int> action = null;

            // Act
            pubSubEvent.Subscribe(action);

            // Assert
            Assert.Equal(pubSubEvent.Subscriptions.Count, 1);
        }

        [Fact]
        public void Publish_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var eventAggregator = new EventAggregator();
            var pubSubEvent = eventAggregator.GetEvent<PubSubEventTest>();
            pubSubEvent.Subscribe(OnTeste);
            int payload = 10;

            // Act
            pubSubEvent.Publish(payload);

            // Assert
            Assert.True(PublishCalled);
        }

        private void OnTeste(int obj)
        {
            PublishCalled = true;
        }

        [Fact]
        public void Unsubscribe_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pubSubEvent = new PubSubEventTest();
            // Act
            pubSubEvent.Subscribe(OnAction);

            // Assert
            Assert.Equal(pubSubEvent.Subscriptions.Count, 1);
            pubSubEvent.Unsubscribe(OnAction);
            Assert.Equal(pubSubEvent.Subscriptions.First().Value.Count, 0);
        }

        private void OnAction(int obj)
        {
            throw new NotImplementedException();
        }
    }
}
