using WebSocketServer;
using Haru.Utils;

namespace Haru.Server.Servers
{
    public class NotificationServer
    {
        public WebSocketServer.Server Server;

        public NotificationServer()
        {
            Server = new WebSocketServer.Server("ws://127.0.0.1:80/");
            Server.OnClientConnected += OnClientConnected;
            Server.OnClientDisconnected += OnClientDisconnected;
            Server.OnMessageReceived += OnMessageReceived;
            Server.OnSendMessage += OnSendMessage;
        }

        public void Start()
        {
            Server.Start();
        }

        private void OnClientConnected(object sender, OnClientConnectedEvent e)
        {
            Log.Write($"Client with GUID: {e.Client.Guid} Connected!");
        }

        private void OnClientDisconnected(object sender, OnClientDisconnectedEvent e)
        {
            Log.Write($"Client {e.Client.Guid} Disconnected");
        }

        private void OnMessageReceived(object sender, OnMessageReceivedEvent e)
        {
            Log.Write($"Received Message: 'e.Client.Guid' from client: {e.Message}");
        }

        private void OnSendMessage(object sender, OnSendMessageEvent e)
        {
            Log.Write($"Sent message: '{e.Message}' to client {e.Client.Guid}");
        }
    }
}