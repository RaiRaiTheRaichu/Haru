using System;
using System.Threading;
using System.Threading.Tasks;
using WebSocketServer;
using Haru.Models.EFT;
using Haru.Models.EFT.Notification;
using Haru.Services;
using Haru.Utils;

namespace Haru.Servers
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

        private async void PingClient(Client client, TimeSpan interval, CancellationToken cancellationToken)
        {
            while (true)
            {
                var data = NotificationService.GetPing();
                var body = new ResponseModel<PingModel>(data);
                client.Server.SendMessage(client, Json.Serialize(body));
                await Task.Delay(interval, cancellationToken);
            }
        }

        private async void OnClientConnected(object sender, OnClientConnectedEvent e)
        {
            Log.Write($"Client with GUID: {e.Client.Guid} Connected!");
            await Task.Run(() => PingClient(e.Client, TimeSpan.FromSeconds(90), default(CancellationToken)));
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