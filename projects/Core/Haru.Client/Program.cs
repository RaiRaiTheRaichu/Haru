using System.Threading.Tasks;
using Haru.Servers;
using Haru.Framework.DI;
using Haru.Framework.Events;
using Haru.Client.Helpers;
using Haru.Client.Patches;

namespace Haru.Client
{
    public class Program
    {
        private IContainerBuilder _containerBuilder;
        private IContainer _container;

        public async void SetupDI()
        {
            _containerBuilder = new ContainerBuilder();
            _container = await SetupContainer();
            await _container.Bind<IEventBus, EventBus>();
        }

        private Task<IContainer> SetupContainer()
        {
            var asmsToBeLoaded = new string[]
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

        public void SetupPatches()
        {
            var patchHelper = new PatchHelper();

            new BattlEyePatch(patchHelper).Enable();
            new ConsistencyGeneralPatch(patchHelper).Enable();
            new ConsistencyBundlesPatch(patchHelper).Enable();
            new SslCertificatePatch(patchHelper).Enable();
            new HttpUrlPatch(patchHelper).Enable();
            new HttpProtocolPatch(patchHelper).Enable();
            new HttpRequestPatch(patchHelper).Enable();
            new ZOutputCanReadPatch().Enable();
            new ZOutputCanWritePatch().Enable();
        }

        public void SetupServers()
        {
            GeneralServer.Instance.Start();
            NotificationServer.Instance.Start();
        }
    }
}