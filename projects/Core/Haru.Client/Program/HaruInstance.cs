using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarmonyLib;
using Haru.Client.Patches;
using Haru.Servers;
using Haru.Framework.DI;
using Haru.Framework.Events;

namespace Haru.Client.Program
{
    public class HaruInstance
    {
        private IContainerBuilder _containerBuilder;
        private IContainer _container;

        public HaruInstance()
        {
            _containerBuilder = new ContainerBuilder();
        }

        public async void Run()
        {
            // setup DI
            _container = await SetupContainer();
            await _container.Bind<IEventBus, EventBus>();

            // patch client
            new BattlEyePatch().Enable();
            new ConsistencyMultiPatch().Enable();
            new ConsistencySinglePatch().Enable();
            new SslCertificateGeneralPatch().Enable();
            new SslCertificateTexturePatch().Enable();
            new ZOutputCanReadPatch().Enable();
            new ZOutputCanWritePatch().Enable();

            // run servers
            GeneralServer.Instance.Start();
            NotificationServer.Instance.Start();
        }

        private Task<IContainer> SetupContainer()
        {
            var asmsToBeLoaded = new List<string>()
            {
                "Haru.Framework",
                "Haru"
            };

            foreach (var internalAsm in asmsToBeLoaded)
            {
                _containerBuilder = _containerBuilder.WithAsm(internalAsm);
            }

            return _containerBuilder.BuildInjection();
        }
    }
}
