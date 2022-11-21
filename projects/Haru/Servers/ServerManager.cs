namespace Haru.Servers
{
    public static class ServerManager
    {
        public static readonly GeneralServer GeneralServer;
        public static readonly NotificationServer NotificationServer;

        static ServerManager()
        {
            GeneralServer = new GeneralServer();
            NotificationServer = new NotificationServer();
        }
    }
}