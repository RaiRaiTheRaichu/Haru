using System;
using System.Threading.Tasks;
using Haru.Framework.Models;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     Responsible for the Bind operations
    /// </summary>
    internal class ContainerBinder
    {
        private readonly ContainerData _data;
        private readonly DIFactory _factory;

        internal ContainerBinder(ContainerData data, DIFactory factory)
        {
            _data = data;
            _factory = factory;
        }

        internal Task Bind(object instance, Type abstraction, string id = null, InjectionScope scope = InjectionScope.Singleton)
        {
            var internalId = id ?? instance.GetType().ToString();

            if (_data.MappingContains(abstraction, internalId))
            {
                throw new Exception($"Type {abstraction} already registered to {instance} using id \"{internalId}\"");
            }

            var instType = instance.GetType();

            _data.AddMapping(instType, abstraction, internalId);

            if (scope == InjectionScope.Singleton)
            {
                _data.AddSingleton(instance, instType);
            }

            return Task.FromResult(Task.CompletedTask);
        }

        internal async Task Bind(Type implem, Type abstraction, string id = null, InjectionScope scope = InjectionScope.Singleton)
        {
            _data.AddMapping(implem, abstraction, id);

            if (scope != InjectionScope.Singleton)
            {
                return;
            }

            var instance = await _factory.Get(abstraction);

            _data.AddSingleton(instance, abstraction);
        }
    }
}