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
        private readonly NotificationService _notificationService;
        private readonly Json _json;
        private readonly Log _log;
        public readonly WebSocketServer.Server Server;

        public NotificationServer()
        {
            _notificationService = new NotificationService();
            _json = new Json();
            _log = new Log();

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
                var data = _notificationService.GetPing();
                var body = new ResponseModel<PingModel>(data);
                client.Server.SendMessage(client, _json.Serialize(body));
                await Task.Delay(interval, cancellationToken);
            }
        }

        private async void OnClientConnected(object sender, OnClientConnectedEvent e)
        {
            await _log.Write($"Client with GUID: {e.Client.Guid} Connected!");
            await Task.Run(() => PingClient(e.Client, TimeSpan.FromSeconds(90), default(CancellationToken)));
        }

        private async void OnClientDisconnected(object sender, OnClientDisconnectedEvent e)
        {
            await _log.Write($"Client {e.Client.Guid} Disconnected");
        }

        private async void OnMessageReceived(object sender, OnMessageReceivedEvent e)
        {
            await _log.Write($"Received Message: 'e.Client.Guid' from client: {e.Message}");
        }

        private async void OnSendMessage(object sender, OnSendMessageEvent e)
        {
            await _log.Write($"Sent message: '{e.Message}' to client {e.Client.Guid}");
        }
    }
}