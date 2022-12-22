using System;
using System.Net.Sockets;

namespace WebSocketServer
{
    public partial class Client
    {
        private readonly Helper _helper;
        public Socket Socket { get; private set; }
        public string Guid { get; private set; }
        public Server Server { get; private set; }

        public Client(Server server, Socket socket)
        {
            _helper = new Helper();
            Server = server;
            Socket = socket;
            Guid = _helper.CreateGuid("client");

            // Start to detect incomming messages 
            Socket.BeginReceive(new byte[] { 0 }, 0, 0, SocketFlags.None, messageCallback, null);
        }

        private void messageCallback(IAsyncResult asyncResult)
        {
            Socket.EndReceive(asyncResult);

            // Read the incomming message 
            var messageBuffer = new byte[8];
            var bytesReceived = Socket.Receive(messageBuffer);

            // Resize the byte array to remove whitespaces 
            if (bytesReceived < messageBuffer.Length)
            {
                Array.Resize(ref messageBuffer, bytesReceived);
            }

            // Get the opcode of the frame
            var opcode = _helper.GetFrameOpcode(messageBuffer);

            // If the connection was closed
            if (opcode == EOpcodeType.ClosedConnection)
            {
                Server.ClientDisconnect(this);
                return;
            }

            // Pass the message to the server event to handle the logic
            Server.ReceiveMessage(this, _helper.GetDataFromFrame(messageBuffer));

            // Start to receive messages again
            Socket.BeginReceive(new byte[] { 0 }, 0, 0, SocketFlags.None, messageCallback, null);
        }
    }
}