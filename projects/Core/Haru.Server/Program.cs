using Haru.Servers;
using Haru.Utils;

namespace Haru.Server
{
    class Program
    {
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
    }
}
