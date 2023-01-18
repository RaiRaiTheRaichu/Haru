using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;

namespace Haru.Client.Helpers
{
    public class ProcessHelper : MonoBehaviour
    {
        private const string _processPath = "EscapeFromTarkov_Data/Managed/Haru.Server.exe";
        private readonly ProcessStartInfo _processStartInfo;
        private readonly Process _process;

        public ProcessHelper()
        {
            var processStartInfo = new ProcessStartInfo()
            {
                FileName = Path.Combine(Environment.CurrentDirectory, _processPath),
                WorkingDirectory = Environment.CurrentDirectory
            };

            _process = new Process()
            {
                StartInfo = processStartInfo
            };
        }

        private void Awake()
        {
            _process.Start();
        }

        private void OnApplicationQuit()
        {
            _process.Close();
        }
    }
}