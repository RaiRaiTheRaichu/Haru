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
        public readonly Server Server;

        private static NotificationServer _instance;
        public static NotificationServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NotificationServer();
                }

                return _instance;
            }
        }

        public NotificationServer()
        {
            _notificationService = new NotificationService();
            _json = new Json();
            _log = new Log();

            Server = new Server("ws://127.0.0.1:80/");
            Server.OnClientConnected += OnClientConnected;
            Server.OnClientDisconnected += OnClientDisconnected;
            Server.OnMessageReceived += OnMessageReceived;
            Server.OnSendMessage += OnSendMessage;
        }

        public void Start()
        {
            Server.Start();
        }

        private async Task PingClient(Client client, TimeSpan interval, CancellationToken cancellationToken)
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
            _log.Write($"Client with GUID: {e.Client.Guid} Connected!");
            await PingClient(e.Client, TimeSpan.FromSeconds(90), default);
        }

        private void OnClientDisconnected(object sender, OnClientDisconnectedEvent e)
        {
            _log.Write($"Client {e.Client.Guid} Disconnected");
        }

        private void OnMessageReceived(object sender, OnMessageReceivedEvent e)
        {
            _log.Write($"Received Message: 'e.Client.Guid' from client: {e.Message}");
        }

        private void OnSendMessage(object sender, OnSendMessageEvent e)
        {
            _log.Write($"Sent message: '{e.Message}' to client {e.Client.Guid}");
        }
    }
}