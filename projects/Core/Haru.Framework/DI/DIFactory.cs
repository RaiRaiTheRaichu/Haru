using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Haru.Framework.DI
{
    /// <summary>
    ///    Factory used to instantiate objects when getting them
    /// </summary>
    internal class DIFactory
    {
        private readonly ContainerData _data;

        internal DIFactory(ContainerData data)
        {
            _data = data;
        }

        internal async Task<object> Get(Type type, string id = null)
        {
            return await InstantiateAbstraction(type, id);
        }

        private async Task<object[]> GetAll(Type type)
        {
            var targets = await _data.ResolveTypes(type);

            var instances = new object[targets.Length];

            for (int targetIdx = 0; targetIdx < targets.Length; targetIdx++)
            {
                if (targets[targetIdx] == null) continue;

                instances[targetIdx] = await InstantiateConcreteClass(targets[targetIdx]);
            }

            return instances;
        }

        private async Task<object> InstantiateConcreteClass(Type type)
        {
            return await GetSingleton(type) ?? await Instantiate(type);
        }

        private async Task<object> InstantiateAbstraction(Type type, string id = null)
        {
            // Return the singleton if it exists
            object instance = await GetSingleton(type);
            if (instance != null)
            {
                return instance;
            }

            var target = await _data.ResolveType(type, id);
            return await Instantiate(target);
        }

        private async Task<object> GetSingleton(Type type)
        {
            // Return the singleton if it exists
            return await Task.Run(() => _data.GetSingleton(type));
        }

        private async Task<object> Instantiate(Type type)
        {
            // Instantiate otherwise
            var constructor = type.GetConstructors().FirstOrDefault()
                              ?? type.GetConstructor(Type.EmptyTypes);
            var parameters = constructor?.GetParameters();
            var resolvedParameters = await GetParamInstances(parameters);

            return constructor.Invoke(resolvedParameters.ToArray());
        }

        private async Task<object[]> GetParamInstances(ParameterInfo[] parameters)
        {
            if (parameters == null)
            {
                return new object[] { };
            }

            var resolvedParameters = new object[parameters.Length];

            // Use recursive reflection to get an instance of each parameter
            for (int paramIdx = 0; paramIdx < parameters.Length; paramIdx++)
            {
                var parameter = parameters[paramIdx];
                var type = parameter.ParameterType;
                string nestedId = null;

                if (type.IsArray)
                {
                    // Basically cast object[] into the more specific array
                    // Since otherwise, it complains at runtime
                    var instances = await GetAll(type.GetElementType());
                    var destinationArray = Array.CreateInstance(type.GetElementType(), instances.Length);
                    Array.Copy(instances, destinationArray, instances.Length);
                    resolvedParameters[paramIdx] = destinationArray;
                }
                else
                {
                    resolvedParameters[paramIdx] = await Get(type, nestedId);
                }
            }

            return resolvedParameters;
        }
    }
}