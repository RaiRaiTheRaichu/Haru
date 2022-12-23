using System;
using System.Threading.Tasks;
using Haru.Framework.Models;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     The main interface responsible for the DI logic
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        ///     Retrieve a concrete class instance bound to a given abstraction <typeparamref name="T"/>
        /// </summary>
        /// <param name="id">The concrete class ID</param>
        /// <typeparam name="T">Should be an abstraction (interface, abstract class, ...)</typeparam>
        /// <returns>An instance of <typeparamref name="T"/></returns>
        Task<T> Get<T>(string id = null) where T : class;

        /// <summary>
        ///     Same as the generic implementation (<see cref="Get{T}"/>)
        /// </summary>
        Task<object> Get(Type type, string id = null);

        /// <summary>
        ///     Bind an abstraction <typeparamref name="A"/> to an implementation class <typeparamref name="I"/>
        /// </summary>
        /// <param name="id">The concrete class ID</param>
        /// <typeparam name="A">Abstraction type (interface, abstract class, ...)</typeparam>
        /// <typeparam name="I">Implementation/Concrete class</typeparam>
        /// <param name="scope">The binding scope</param>
        /// <returns>The implementation type bound to the abstraction </returns>
        Task<IContainer> Bind<A, I>(string id = null, InjectionScope scope = InjectionScope.Singleton) where I : A;

        /// <summary>
        ///     Bind an abstraction <typeparamref name="A"/> to an instance of <typeparamref name="I"/>
        /// </summary>
        /// <param name="instance">The instance</param>
        /// <param name="id">The concrete class ID</param>
        /// <typeparam name="A">Abstraction type (interface, abstract class, ...)</typeparam>
        /// <typeparam name="I">Implementation/Concrete class</typeparam>
        /// <param name="scope">The binding scope</param>
        /// <returns>The implementation type bound to the abstraction </returns>
        Task<IContainer> Bind<A, I>(I instance, string id = null) where I : A;
    }
}