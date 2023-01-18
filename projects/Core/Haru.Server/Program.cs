using System;
using Haru.Servers;
using Haru.Utils;

namespace Haru.Server
{
    class Program
    {
        private static readonly Log _log;

        static Program()
        {
            _log = new Log();
            AppDomain.CurrentDomain.UnhandledException += HandleException;
            Console.Title = "Haru.Server";
        }

        static void Main(string[] args)
        {
            // load mods
            Senko.EftData.Mod.Run();

            // load certificate
            var cert = new Cert("./Haru/certs/cert.pfx");

            if (!cert.IsValid(string.Empty))
            {
                cert.CreateCertificate("Haru");
            }

            // load servers
            GeneralServer.Instance.Start();
            NotificationServer.Instance.Start();

            // keep server alive
            while (true) ;
        }

        static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            _log.Write(ex.Message);
        }
    }
}