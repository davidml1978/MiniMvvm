using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMvvm.Events
{
    /// <summary>
    /// Class that manages publication and subscription to events.
    /// </summary>
    /// <typeparam name="TPayload">The type of the payload.</typeparam>
    /// <seealso cref="MiniMvvm.Events.EventBase" />
    public class PubSubEvent<TPayload> : EventBase
    {
        /// <summary>
        /// Subscribes the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Subscribe(Action<TPayload> action)
        {
            base.Subscribe(action);
        }

        /// <summary>
        /// Publishes the event message.
        /// </summary>
        /// <param name="payload">The payload.</param>
        public void Publish(TPayload payload)
        {
            base.Publish(payload);
        }

        /// <summary>
        /// Unsubscripted the specified subscriber.
        /// </summary>
        /// <param name="subscriber">The subscriber.</param>
        public void Unsubscribe(Action<TPayload> subscriber)
        {
            lock (Subscriptions)
            {
                if (Subscriptions.ContainsKey(typeof(TPayload)))
                {
                    var result = Subscriptions[typeof(TPayload)] as List<EventSubscription<TPayload>>;
                    if (result != null)
                    {
                        var eventAction = result.FirstOrDefault(x => x.Action == subscriber);
                        if (eventAction != null)
                            base.UnSubscribe(eventAction);
                    }
                }
            }
        }
    }
}
