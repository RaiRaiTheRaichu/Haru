using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Haru.Framework.Events
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<Type, List<EventListener>> _listeners;

        public EventBus()
        {
            _listeners = new Dictionary<Type, List<EventListener>>();
        }

        private EventListener GetListener(Type eventType, object instance, MethodInfo mi)
        {
            foreach (var listener in _listeners[eventType])
            {
                if (listener.Instance == instance && listener.Method == mi)
                {
                    return listener;
                }
            }

            return null;
        }

        public Task Subscribe<T>(object instance, Func<T, Task> callback) where T : Event
        {
            var eventType = typeof(T);
            List<EventListener> listeners = null;

            if (!_listeners.TryGetValue(eventType, out listeners))
            {
                _listeners.Add(eventType, new List<EventListener>());
            }

            if (GetListener(eventType, instance, callback.Method) == null)
            {
                var listener = new EventListener(eventType, instance, callback.Method);
                _listeners[eventType].Add(listener);
            }

            return Task.CompletedTask;
        }

        public Task UnSubscribe<T>(object instance, Func<T, Task> callback) where T : Event
        {
            var eventType = typeof(T);
            List<EventListener> listeners = null;

            if (!_listeners.TryGetValue(eventType, out listeners))
            {
                return Task.CompletedTask;
            }

            var listener = GetListener(eventType, instance, callback.Method);

            if (listener != null)
            {
                _listeners[eventType].Remove(listener);
            }

            return Task.CompletedTask;
        }

        public async Task Invoke<T>(T eventData = null) where T : Event
        {
            var eventType = typeof(T);
            List<EventListener> listeners = null;

            if (!_listeners.TryGetValue(eventType, out listeners))
            {
                return;
            }

            foreach (var listener in listeners)
            {
                if (listener.Event == eventType)
                {
                    await (Task)listener.Method.Invoke(listener.Instance, new[] { eventData });
                }
            }
        }
    }
}