using System;

namespace MiniMvvm.Events
{
    /// <summary>
    /// IEventSubscription
    /// </summary>
    /// <typeparam name="TMessageType">The type of the message type.</typeparam>
    public interface IEventSubscription<TMessageType>
    {
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        Action<TMessageType> Action { get; }
    }
}