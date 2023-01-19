using System;

namespace WebSocketServer
{
    public class OnMessageReceivedEvent : EventArgs
    {
        public Client Client { get; private set; }
        public string Message { get; private set; }

        public OnMessageReceivedEvent(Client client, string message)
        {
            Client = client;
            Message = message;
        }
    }
}