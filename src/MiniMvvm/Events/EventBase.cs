using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BasicMiniMvvm.Events
{
    /// <summary>
    /// Base class for Publish and Subscribe
    /// </summary>
    public abstract class EventBase
    {
        public SynchronizationContext SynchronizationContext { get; set; }
        public Dictionary<Type, IList> Subscriptions { get; } = new Dictionary<Type, IList>();

        /// <summary>
        /// Publishes the specified event message.
        /// </summary>
        /// <typeparam name="TMessageType">The type of the event message type.</typeparam>
        /// <param name="message">The message.</param>
        public void Publish<TMessageType>(TMessageType message)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            if (Subscriptions.ContainsKey(t))
            {
                actionlst = new List<EventSubscription<TMessageType>>(Subscriptions[t].Cast<EventSubscription<TMessageType>>());

                foreach (EventSubscription<TMessageType> a in actionlst)
                {
                    a.Action(message);
                }
            }
        }

        /// <summary>
        /// Subscribes the specified action.
        /// </summary>
        /// <typeparam name="TMessageType">The type of the message type.</typeparam>
        /// <param name="action">The action.</param>
        /// <returns>EventSubscription</returns>
        public EventSubscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
        {
            Type t = typeof(TMessageType);
            IList actionlst;
            var actiondetail = new EventSubscription<TMessageType>(action);

            if (!Subscriptions.TryGetValue(t, out actionlst))
            {
                actionlst = new List<EventSubscription<TMessageType>>();
                actionlst.Add(actiondetail);
                Subscriptions.Add(t, actionlst);
            }
            else
            {
                actionlst.Add(actiondetail);
            }

            return actiondetail;
        }

        /// <summary>
        /// Unsubscribe.
        /// </summary>
        /// <typeparam name="TMessageType">The type of the message type.</typeparam>
        /// <param name="subscription">The subscription.</param>
        public void UnSubscribe<TMessageType>(EventSubscription<TMessageType> subscription)
        {
            Type t = typeof(TMessageType);
            if (Subscriptions.ContainsKey(t))
            {
                Subscriptions[t].Remove(subscription);
            }
        }
    }
}