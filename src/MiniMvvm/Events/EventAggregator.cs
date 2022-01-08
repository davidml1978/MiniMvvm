using System;
using System.Collections.Generic;
using System.Threading;

namespace MiniMvvm.Events
{
    /// <summary>
    /// EventAggregator class
    /// </summary>
    /// <seealso cref="MiniMvvm.Events.IEventAggregator" />
    public class EventAggregator : IEventAggregator
    {
        private Dictionary<Type, EventBase> events;
        private readonly SynchronizationContext syncContext = SynchronizationContext.Current;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventAggregator"/> class.
        /// </summary>
        public EventAggregator()
        {
            events = new Dictionary<Type, EventBase>();
        }

        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <typeparam name="TEventType">The type of the event type.</typeparam>
        /// <returns></returns>
        public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
        {
            lock (events)
            {
                EventBase existingEvent = null;

                if (!events.TryGetValue(typeof(TEventType), out existingEvent))
                {
                    TEventType newEvent = new TEventType();
                    newEvent.SynchronizationContext = syncContext;
                    events[typeof(TEventType)] = newEvent;

                    return newEvent;
                }
                else
                {
                    return (TEventType)existingEvent;
                }
            }
        }
    }
}