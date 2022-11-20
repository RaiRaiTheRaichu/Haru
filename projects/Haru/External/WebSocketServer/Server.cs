using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace WebSocketServer
{
    public partial class Server
    {
        private readonly List<Client> _clients;
        public Socket Socket { get; private set; }
        public IPEndPoint EndPoint { get; private set; }
        public event EventHandler<OnSendMessageEvent> OnSendMessage;
        public event EventHandler<OnClientConnectedEvent> OnClientConnected;
        public event EventHandler<OnMessageReceivedEvent> OnMessageReceived;
        public event EventHandler<OnClientDisconnectedEvent> OnClientDisconnected;

        public Server(IPEndPoint endPoint)
        {
            if (endPoint == null)
            {
                return;
            }

            _clients = new List<Client>();
            EndPoint = EndPoint;
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public Client GetConnectedClient(int index)
        {
            if (index < 0 || index >= _clients.Count)
            {
                return null;
            }

            return _clients[index];
        }

        public Client GetConnectedClient(string guid)
        {
            foreach (var client in _clients)
            {
                if (client.Guid == guid)
                {
                    return client;
                }
            }

            return null;
        }

        public Client GetConnectedClient(Socket socket)
        {
            foreach (var client in _clients)
            {
                if (client.Socket == socket)
                {
                    return client;
                }
            }

            return null;
        }

        public int GetConnectedClientCount()
        {
            return _clients.Count;
        }

        public void Start()
        {
            Socket.Bind(EndPoint);
            Socket.Listen(0);
            Socket.BeginAccept(connectionCallback, null);
        }

        public void Stop()
        {
            Socket.Close();
            Socket.Dispose();
        }

        private void connectionCallback(IAsyncResult asyncResult)
        {
            var clientSocket = Socket.EndAccept(asyncResult);
            var handshakeBuffer = new byte[1024];
            var handshakeReceived = clientSocket.Receive(handshakeBuffer);
            var requestKey = Helpers.GetHandshakeRequestKey(Encoding.Default.GetString(handshakeBuffer));
            var hanshakeResponse = Helpers.GetHandshakeResponse(Helpers.HashKey(requestKey));

            clientSocket.Send(Encoding.Default.GetBytes(hanshakeResponse));

            var client = new Client(this, clientSocket);

            _clients.Add(client);

            if (OnClientConnected == null)
            {
                throw new Exception("Server error: event OnClientConnected is not bound!");
            }

            OnClientConnected(this, new OnClientConnectedEvent(client));
            Socket.BeginAccept(connectionCallback, null);
        }

        public void ReceiveMessage(Client client, string message)
        {
            if (OnMessageReceived == null)
            {
                throw new Exception("Server error: event OnMessageReceived is not bound!");
            }

            OnMessageReceived(this, new OnMessageReceivedEvent(client, message));
        }

        public void ClientDisconnect(Client client)
        {
            _clients.Remove(client);

            if (OnClientDisconnected == null)
            {
                throw new Exception("Server error: OnClientDisconnected is not bound!");
            }

            OnClientDisconnected(this, new OnClientDisconnectedEvent(client));
        }

        public void SendMessage(Client client, string data)
        {
            var frameMessage = Helpers.GetFrameFromString(data);

            client.Socket.Send(frameMessage);

            if (OnSendMessage == null)
            {
                throw new Exception("Server error: event OnSendMessage is not bound!");
            }

            OnSendMessage(this, new OnSendMessageEvent(client, data));
        }
    }
}