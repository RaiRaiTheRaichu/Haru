using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HarmonyLib;
using Haru.Patches;
using Haru.Servers;
using Haru.Framework.DI;
using Haru.Framework.Events;

namespace Haru.Loader
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
            Patch(new BattlEyePatch());
            Patch(new ConsistencyMultiPatch());
            Patch(new ConsistencySinglePatch());
            Patch(new ZOutputCanReadPatch());
            Patch(new ZOutputCanWritePatch());

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

        private void Patch(IPatch patch)
        {
            var harmony = new HarmonyLib.Harmony(patch.Id);
            var method = new HarmonyMethod(patch.GetPatchMethod());

            switch (patch.Type)
            {
                case EPatchType.Prefix:
                    harmony.Patch(patch.GetOriginalMethod(), prefix: method);
                    return;

                default:
                    throw new NotImplementedException("Patch type");
            }
        }
    }
}
