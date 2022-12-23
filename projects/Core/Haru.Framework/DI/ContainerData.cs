using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haru.Framework.Exceptions;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     Simple Getter/Setters of container data
    /// </summary>
    internal class ContainerData
    {
        private readonly Dictionary<Type, Dictionary<string, Type>> _mappings;
        private readonly Dictionary<Type, object> _singletons;
        private readonly ContainerData _parent;

        internal ContainerData(ContainerData parent = null)
        {
            _parent = parent;
            _mappings = new Dictionary<Type, Dictionary<string, Type>>();
            _singletons = new Dictionary<Type, object>();
        }

        internal object GetSingleton(Type implem)
        {
            return _singletons.ContainsKey(implem) ? _singletons[implem] : null;
        }

        internal void AddSingleton(object instance, Type implem)
        {
            _singletons.Add(implem, instance);
        }

        internal bool MappingContains(Type abstraction, string id = null)
        {
            if (id == null)
            {
                return _mappings.ContainsKey(abstraction);
            }

            return _mappings.ContainsKey(abstraction) && _mappings[abstraction].ContainsKey(id);
        }

        private Type ResolveMappingType(Type abstraction, string id = null)
        {
            if (!MappingContains(abstraction, id))
            {
                return null;
            }

            return id == null ? _mappings[abstraction].First().Value : _mappings[abstraction][id];
        }

        internal void AddMapping(Type implem, Type abstraction, string id = null)
        {
            // Ignore if already added
            if (MappingContains(abstraction, id))
            {
                return;
            }

            var internalId = id ?? implem.ToString();

            if (_mappings.TryGetValue(abstraction, out Dictionary<string, Type> newMap))
            {
                newMap.Add(internalId, implem);
                return;
            }

            newMap = new Dictionary<string, Type>()
            {
                { internalId, implem }
            };

            _mappings.Add(abstraction, newMap);
        }

        internal async Task<Type> ResolveType(Type type, string id = null)
        {
            Type implem = ResolveMappingType(type, id);

            // If found, just return it
            if (implem != null)
            {
                return implem;
            }

            // if no registration is found in this container
            // try the parent and climb up the hierarchy
            if (_parent != null)
            {
                implem = await _parent.ResolveType(type, id);
            }

            // If no registration is found in the whole hierarchy
            // throw exception
            if (implem == null)
            {
                throw new DIResolutionException($"No implementation found for type \"{type}\" and id \"{id}\"");
            }

            return implem;
        }

        internal Task<Type[]> ResolveTypes(Type abstraction)
        {
            if (!MappingContains(abstraction))
            {
                return Task.FromResult(new Type[] { });
            }

            return Task.FromResult(_mappings[abstraction].Values.ToArray());
        }
    }
}