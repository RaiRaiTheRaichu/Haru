using System;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     Use on class to register (bind) a concrete class for injection
    /// </summary>
    /// <remarks>
    ///     The full class name is used in <see cref="Container"/>
    ///     as the default identifier.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class)]
    public class Register : Attribute
    {
        /// <summary> The abstraction to bind the class </summary>
        /// <example>IMyInterface</example>
        public Type binding;

        /// <summary> Identification of the implementation </summary>
        /// <example>"MyIdentifier"</example>
        public string id;

        /// <summary> The binding scope </summary>
        /// <example>InjectionScope.Transient</example>
        public InjectionScope scope;

        /// <param name="binding">Type: The type to bind the class to</param>
        /// <param name="id">string: the identifier for the concrete class.</param>
        public Register(Type binding, string id = null, InjectionScope scope = InjectionScope.Transient)
        {
            this.binding = binding;
            this.id = id;
            this.scope = scope;
        }
    }
}