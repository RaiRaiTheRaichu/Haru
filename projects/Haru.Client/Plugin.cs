using System;
using System.Diagnostics;
using System.IO;
using BepInEx;
using Haru.Client.Patches;

namespace Haru.Client
{
    [BepInPlugin("com.haru.client", "Haru", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private const string _processPath = "EscapeFromTarkov_Data/Managed/Haru.Server.exe";
        private readonly Process _process;
        private readonly APatch[] _patches;

        public Plugin()
        {
            _patches = new APatch[]
            {
                // order matters!
                // integrity checks need to be disabled first
                new ConsistencyGeneralPatch(),
                new ConsistencyBundlesPatch(),
                new BattlEyePatch(),
                new SslCertificatePatch()
            };

            _process = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    FileName = Path.Combine(Environment.CurrentDirectory, _processPath),
                    WorkingDirectory = Environment.CurrentDirectory
                }
            };
        }

        private void Awake()
        {
            foreach (var patch in _patches)
            {
                patch.Enable();
            }

            _process.Start();
        }

        private void OnApplicationQuit()
        {
            _process.CloseMainWindow();

            // cleanup memory
            _process.Dispose();

            foreach (var patch in _patches)
            {
                patch.Disable();
            }
        }
    }
}