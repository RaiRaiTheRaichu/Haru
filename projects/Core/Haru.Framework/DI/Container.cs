using System;
using System.Threading.Tasks;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     The main dispatcher class for the DI logic
    /// </summary>
    public class Container : IContainer
    {
        private readonly ContainerData _data;
        private readonly DIFactory _factory;
        private readonly ContainerBinder _binder;

        public Container(Container parent = null)
        {
            _data = new ContainerData(parent?._data);
            _factory = new DIFactory(_data);
            _binder = new ContainerBinder(_data, _factory);
        }

        public async Task<T> Get<T>(string id = null) where T : class
        {
            return await _factory.Get(typeof(T), id) as T;
        }

        public async Task<object> Get(Type type, string id = null)
        {
            return await _factory.Get(type, id);
        }

        public async Task<IContainer> Bind<A, I>(string id = null, InjectionScope scope = InjectionScope.Singleton) where I : A
        {
            return await Bind(typeof(I), typeof(A), id, scope);
        }

        public async Task<IContainer> Bind(Type implemType, Type abstractType, string id = null, InjectionScope scope = InjectionScope.Singleton)
        {
            await _binder.Bind(implemType, abstractType, id, scope);
            return await Task.FromResult((IContainer)this);
        }

        public async Task<IContainer> Bind<A, I>(I instance, string id = null) where I : A
        {
            return await Bind(instance, typeof(A), id);
        }

        public async Task<IContainer> Bind(object instance, Type abstraction, string id = null, InjectionScope scope = InjectionScope.Singleton)
        {
            await _binder.Bind(instance, abstraction, id, scope);
            return await Task.FromResult((IContainer)this);
        }
    }
}