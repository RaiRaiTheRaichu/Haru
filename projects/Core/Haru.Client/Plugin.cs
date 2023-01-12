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
            var filename = Path.Combine(Environment.CurrentDirectory, "EscapeFromTarkov_Data/Managed/Haru.Server.exe");
            var processInfo = new ProcessStartInfo()
            {
                FileName = filename,
                UseShellExecute = false,
                WorkingDirectory = Environment.CurrentDirectory
            };
            
            var process = new Process();
            process.StartInfo = processInfo;
            process.Start();
        }

        public void RunPatcher()
        {
            var patchHelper = new PatchHelper();

            new BattlEyePatch(patchHelper).Enable();
            new ConsistencyGeneralPatch(patchHelper).Enable();
            new ConsistencyBundlesPatch(patchHelper).Enable();
            new SslCertificatePatch(patchHelper).Enable();
            new ZOutputCanReadPatch().Enable();
            new ZOutputCanWritePatch().Enable();
        }
    }
}