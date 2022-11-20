using System;

namespace WebSocketServer
{
    public class OnClientConnectedEvent : EventArgs
    {
        public Client Client { get; private set; }

        public OnClientConnectedEvent(Client client)
        {
            Client = client;
        }
    }
}