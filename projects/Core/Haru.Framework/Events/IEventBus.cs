using System;
using System.Threading.Tasks;

namespace Haru.Framework.Events
{
    public interface IEventBus
    {
        /// <summary>
        ///     Binds a callback to an event
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="callback">The callback</param>
        /// <typeparam name="T">The event type</typeparam>
        /// <example>eventBus.Subscribe&lt;MyEvent&gt;(this, MyCallback)</example>
        Task Subscribe<T>(object instance, Func<T, Task> callback) where T : Event;

        /// <summary>
        ///     Unbind a callback to an event
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="callback">The callback</param>
        /// <typeparam name="T">The event type</typeparam>
        /// <example>eventBus.UnSubscribe&lt;MyEvent&gt;(this, MyCallback)</example>
        Task UnSubscribe<T>(object instance, Func<T, Task> callback) where T : Event;

        /// <summary>
        ///     Invoke an event
        /// </summary>
        /// <param name="eventData">The event data</param>
        /// <typeparam name="T">The event type</typeparam>
        /// <example>eventBus.Invoke&lt;MyEvent&gt;(eventData)</example>
        Task Invoke<T>(T eventData = null) where T : Event;
    }
}