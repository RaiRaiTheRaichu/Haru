using System;

namespace WebSocketServer
{
    public class OnSendMessageEvent : EventArgs
    {
        public Client Client { get; private set; }
        public string Message { get; private set; }

        public OnSendMessageEvent(Client client, string message)
        {
            Client = client;
            Message = message;
        }
    }
}