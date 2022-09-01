using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Haru.Server.Http;
using Haru.Databases;
using Haru.Resources;

namespace Haru.Server
{
    public class ServerApp
    {
        private readonly string _address;
        private IContainerBuilder _containerBuilder;
        public IContainer Container;
        private readonly List<string> _asmsToBeLoaded;

        public ServerApp(IContainerBuilder containerBuilder)
        {
            _address = "http://127.0.0.1:8000";
            _containerBuilder = containerBuilder;
            _asmsToBeLoaded = new List<string>()
            {
                "Haru.Standard",
                "Haru.Server"
            };
        }

        public async Task<ServerApp> Init()
        {
            var serverConfig = new HttpServerConfig(_address);
            Container = await SetupContainer();
            await Container.Bind<HttpServerConfig, HttpServerConfig>(serverConfig);
            await Container.Bind<IEventBus, EventBus>();

            await SetupResources(Container);
            await SetupDatabases(Container);

            return this;
        }

        public async void Run()
        {
            var server = await Container.Get<IHttpServer>();
            server.Start();
        }

        private Task<IContainer> SetupContainer()
        {
            foreach (var internalAsm in _asmsToBeLoaded)
            {
                _containerBuilder = _containerBuilder.WithAsm(internalAsm);
            }

            return _containerBuilder.BuildInjection();
        }

        private async Task SetupResources(IContainer container)
        {
            var resourceHandler = (IResourceHandler)(await container.Get<IResourceHandler>());
            resourceHandler.RegisterAssemblies();
        }

        private async Task SetupDatabases(IContainer container)
        {
            List<Type> DatabasesToInitialize = new List<Type>()
            {
                typeof(ILocaleDatabase),
                typeof(IResourceDatabase)
            };

            foreach (var databaseType in DatabasesToInitialize)
            {
                var database = (IDatabase)(await container.Get(databaseType));
                await database.Initialize();
            }
        }
    }
}