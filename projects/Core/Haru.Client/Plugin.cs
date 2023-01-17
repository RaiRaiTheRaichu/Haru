using System;
using System.Diagnostics;
using System.IO;
using BepInEx;
using Haru.Client.Helpers;
using Haru.Client.Patches;

namespace Haru.Client
{
    [BepInPlugin("com.haru.client", "Haru", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            RunPatcher();
            RunServer();
        }

        public void RunServer()
        {
            // start server
            var process = new Process();
            var processInfo = new ProcessStartInfo()
            {
                FileName = Path.Combine(Environment.CurrentDirectory, "EscapeFromTarkov_Data/Managed/Haru.Server.exe"),
                WorkingDirectory = Environment.CurrentDirectory
            };
            
            process.StartInfo = processInfo;
            process.Start();

            // close server on game close
            AppDomain.CurrentDomain.ProcessExit += (object sender, EventArgs e) => {
                process.Close();
            };
        }

        public void RunPatcher()
        {
            var patchHelper = new PatchHelper();

            new BattlEyePatch(patchHelper).Enable();
            new ConsistencyGeneralPatch(patchHelper).Enable();
            new ConsistencyBundlesPatch(patchHelper).Enable();
            new SslCertificatePatch(patchHelper).Enable();
        }
    }
}