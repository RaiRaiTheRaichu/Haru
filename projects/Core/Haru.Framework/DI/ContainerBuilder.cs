using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Framework.Attributes;
using Haru.Framework.Models;

namespace Haru.Framework.DI
{
    /// <summary>
    ///     Responsible for building the container and the dependency tree
    /// </summary>
    public class ContainerBuilder : IContainerBuilder
    {
        private readonly HashSet<string> _assemblies;
        private Container _parent;
        private readonly Container _container;
        public Container StaticContainer;

        public ContainerBuilder(Container parent = null)
        {
            _parent = parent;
            _container = new Container();
            _assemblies = new HashSet<string>();
        }

        public IContainerBuilder WithAsm(string asm)
        {
            _assemblies.Add(asm);
            return this;
        }

        public async Task<IContainer> BuildInjection()
        {
            if (StaticContainer == null)
            {
                StaticContainer = new Container();
            }

            if (StaticContainer != _container && _parent == null)
            {
                _parent = StaticContainer;
            }

            // Load all whitelisted assemblies
            var assemblies = new List<Assembly>();

            foreach (var asm in _assemblies)
            {
                assemblies.Add(Assembly.Load(asm));
            }
            
            // Bind all types containing the Register attribute
            // Omit singleton scope at first to bind all types
            // Resolve singletons afterwards to be sure to have the whole 
            // dep graph
            // (Note the second time is faster due to skips in the binding)
            var singletonTasks = new List<Task>();

            foreach (Assembly asm in assemblies)
            {
                var asmTypes = asm.GetTypes();

                foreach (Type currType in asmTypes)
                {
                    var attribs = currType.GetCustomAttributes(typeof(Register), true);

                    // Filter out if the type does not have the Register attribute
                    if (attribs.Length <= 0)
                    {
                        continue;
                    }

                    var register = ((Register)attribs[0]);
                    var scope = register.scope;
                    
                    if (scope == InjectionScope.Singleton)
                    {
                        // Add it to register the singleton later on
                        singletonTasks.Add(Register(register, currType));
                    }
                    else
                    {
                        // Register the type right now
                        await Register(register, currType, InjectionScope.Transient);
                    }
                }
            }

            foreach (var task in singletonTasks)
            {
                task.Start();
                task.Wait();
            }

            return _container;
        }

        private async Task Register(Register register, Type type, InjectionScope scope = InjectionScope.Singleton)
        {
            var bindingSource = register.binding;
            var bindingId = register.id ?? type.ToString();
            await _container.Bind(type, bindingSource, bindingId, scope);
        }
    }
}