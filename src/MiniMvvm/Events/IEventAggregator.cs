namespace MiniMvvm.Events
{
    /// <summary>
    /// IEventAggregator interface
    /// </summary>
    public interface IEventAggregator
    {
        /// <summary>
        /// Gets the event.
        /// </summary>
        /// <typeparam name="TEventType">The type of the event type.</typeparam>
        /// <returns>TEventType</returns>
        TEventType GetEvent<TEventType>() where TEventType : EventBase, new();
    }
}