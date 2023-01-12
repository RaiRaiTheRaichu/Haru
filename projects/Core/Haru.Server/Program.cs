using System;
using Haru.Servers;
using Haru.Utils;

namespace Haru.Server
{
    class Program
    {
        private static Log _log;

        static Program()
        {
            _log = new Log();
            AppDomain.CurrentDomain.UnhandledException += HandleException;
        }

        static void Main(string[] args)
        {
            // load mods
            Senko.EftData.Mod.Run();
            //Senko.LangPack.Mod.Run();

            // load certificate
            var cert = new Cert();
            cert.Load("Haru", string.Empty);

            // load servers
            GeneralServer.Instance.Start();
            NotificationServer.Instance.Start();

            // keep server alive
            while (true) ;
        }

        static async void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = (Exception)e.ExceptionObject;
            await _log.Write(ex.Message);
        }
    }
}