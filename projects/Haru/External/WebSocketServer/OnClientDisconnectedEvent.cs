using System;

namespace WebSocketServer
{
    public class OnClientDisconnectedEvent : EventArgs
    {
        public Client Client { get; private set; }

        public OnClientDisconnectedEvent(Client client)
        {
            Client = client;
        }
    }
}