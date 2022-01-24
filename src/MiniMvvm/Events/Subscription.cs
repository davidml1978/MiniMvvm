using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicMiniMvvm.Events
{
    /// <summary>
    /// EventSubscription class
    /// </summary>
    /// <typeparam name="TMessageType">The type of the message type.</typeparam>
    /// <seealso cref="System.IDisposable" />
    /// <seealso cref="MiniMvvm.Events.IEventSubscription&lt;TMessageType&gt;" />
    public class EventSubscription<TMessageType> : IDisposable, IEventSubscription<TMessageType>
    {
        public Action<TMessageType> Action { get; private set; }
        private bool isDisposed;
        public EventSubscription(Action<TMessageType> action)
        {
            Action = action;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="EventSubscription{TMessageType}"/> class.
        /// </summary>
        ~EventSubscription()
        {
            if (!isDisposed)
                Dispose();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            isDisposed = true;
        }
    }
}
