using WebSocketServer;
using Haru.Utils;

namespace Haru.Server
{
    public class NotificationServer
    {
        public WebSocketServer.Server Server;

        public NotificationServer()
        {
            Server = new WebSocketServer.Server("ws://127.0.0.1:80/");

            Server.OnClientConnected += (object sender, OnClientConnectedEvent e) => 
            {
                Log.Write($"Client with GUID: {e.Client.Guid} Connected!");
            };

            Server.OnClientDisconnected += (object sender, OnClientDisconnectedEvent e) =>
            {
                Log.Write($"Client {e.Client.Guid} Disconnected");
            };

            Server.OnMessageReceived += (object sender, OnMessageReceivedEvent e) =>
            {
                Log.Write($"Received Message: 'e.Client.Guid' from client: {e.Message}");
            };

            Server.OnSendMessage += (object sender, OnSendMessageEvent e) =>
            {
                Log.Write($"Sent message: '{e.Message}' to client {e.Client.Guid}");
            };
        }

        public void Start()
        {
            Server.Start();
        }
    }
}