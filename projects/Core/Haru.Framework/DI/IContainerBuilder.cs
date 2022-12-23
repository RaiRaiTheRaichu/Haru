using System;
using System.Threading.Tasks;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     The main interface responsible for the DI logic
    /// </summary>
    public interface IContainerBuilder
    {
        /// <summary>
        ///     Whitelist an Assembly to be loaded by the container
        /// </summary>
        /// <param name="asm">The assembly name to whitelist</param>
        /// <example>new Container().WithAsm("Haru.Server")</example>
        IContainerBuilder WithAsm(string asm);

        /// <summary>
        ///     Use to build the injection
        /// </summary>
        /// <example>new Container().BuildInjection()</example>
        Task<IContainer> BuildInjection();
    }
}