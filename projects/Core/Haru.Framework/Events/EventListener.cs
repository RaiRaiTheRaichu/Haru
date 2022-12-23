using System;
using System.Reflection;

namespace Haru.Framework.Events
{
    public class EventListener
    {
        public Type Event;
        public object Instance;
        public MethodInfo Method;

        public EventListener(Type type, object instance, MethodInfo method)
        {
            Event = type;
            Instance = instance;
            Method = method;
        }
    }
}