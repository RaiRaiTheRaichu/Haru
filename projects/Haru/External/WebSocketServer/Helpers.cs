using System;
using System.Text;
using System.Security.Cryptography;

namespace WebSocketServer
{
    public static class Helpers
    {
        private const string _handshakeKey = "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
        private const string _ids = "0123456789abcdefghijklmnopqrstuvwxyz";
        private const string _handshakeResponse = "HTTP/1.1 101 Switching Protocols\nUpgrade: WebSocket\nConnection: Upgrade\nSec-WebSocket-Accept: {0}\r\n\r\n";

        public static SFrameMaskData GetFrameData(byte[] data)
        {
            // Get the opcode from the frame
            var opcode = data[0] - 128;

            // If the length of the message is in the 2 first indexes
            if (data[1] - 128 <= 125)
            {
                var dataLength = (data[1] - 128);
                return new SFrameMaskData(dataLength, 2, dataLength + 6, (EOpcodeType)opcode);
            }

            // If the length of the message is in the following two indexes
            if (data[1] - 128 == 126)
            {
                // Combine the bytes to get the length
                var dataLength = BitConverter.ToInt16(new byte[] { data[3], data[2] }, 0);
                return new SFrameMaskData(dataLength, 4, dataLength + 8, (EOpcodeType)opcode);
            }

            // If the data length is in the following 8 indexes
            if (data[1] - 128 == 127)
            {
                // Get the following 8 bytes to combine to get the data 
                var combine = new byte[8];

                for (var i = 0; i < 8; i++)
                {
                    combine[i] = data[i + 2];
                }

                // Combine the bytes to get the length
                var dataLength = (int)BitConverter.ToInt64(combine, 0);
                return new SFrameMaskData(dataLength, 10, dataLength + 14, (EOpcodeType)opcode);
            }

            // Error
            return new SFrameMaskData(0, 0, 0, 0);
        }

        public static EOpcodeType GetFrameOpcode(byte[] frame)
        {
            return (EOpcodeType)frame[0] - 128;
        }

        public static string GetDataFromFrame(byte[] data)
        {
            var frameData = GetFrameData(data);

            // Get the decode frame key from the frame data
            var decodeKey = new byte[4];
           
            for (var i = 0; i < 4; i++)
            {
                decodeKey[i] = data[frameData.KeyIndex + i];
            }

            var dataIndex = frameData.KeyIndex + 4;
            var count = 0;

            // Decode the data using the key
            for (var i = dataIndex; i < frameData.TotalLenght; i++)
            {
                data[i] = (byte)(data[i] ^ decodeKey[count % 4]);
                count++;
            }

            // Return the decoded message 
            return Encoding.Default.GetString(data, dataIndex, frameData.DataLength);
        }

        public static bool GetIsBufferValid(ref byte[] buffer)
        {
            return (buffer != null && buffer.Length > 0);
        }

        public static byte[] GetFrameFromString(string message, EOpcodeType opcode = EOpcodeType.Text)
        {
            byte[] response;
            var bytesRaw = Encoding.Default.GetBytes(message);
            var frame = new byte[10];
            var indexStartRawData = -1;
            var length = bytesRaw.Length;

            frame[0] = (byte)(128 + (int)opcode);

            if (length <= 125)
            {
                frame[1] = (byte)length;
                indexStartRawData = 2;
            }
            else if (length >= 126 && length <= 65535)
            {
                frame[1] = (byte)126;
                frame[2] = (byte)((length >> 8) & 255);
                frame[3] = (byte)(length & 255);
                indexStartRawData = 4;
            }
            else
            {
                frame[1] = (byte)127;
                frame[2] = (byte)((length >> 56) & 255);
                frame[3] = (byte)((length >> 48) & 255);
                frame[4] = (byte)((length >> 40) & 255);
                frame[5] = (byte)((length >> 32) & 255);
                frame[6] = (byte)((length >> 24) & 255);
                frame[7] = (byte)((length >> 16) & 255);
                frame[8] = (byte)((length >> 8) & 255);
                frame[9] = (byte)(length & 255);

                indexStartRawData = 10;
            }

            response = new byte[indexStartRawData + length];

            var i = 0;
            var reponseIdx = 0;

            // Add the frame bytes to the reponse
            for (i = 0; i < indexStartRawData; i++)
            {
                response[reponseIdx] = frame[i];
                reponseIdx++;
            }

            // Add the data bytes to the response
            for (i = 0; i < length; i++)
            {
                response[reponseIdx] = bytesRaw[i];
                reponseIdx++;
            }

            return response;
        }

        public static string HashKey(string key)
        {
            var longKey = key + _handshakeKey;
            var sha1 = SHA1.Create();
            var hashBytes = sha1.ComputeHash(Encoding.ASCII.GetBytes(longKey));

            return Convert.ToBase64String(hashBytes);
        }

        public static string GetHandshakeResponse(string key)
        {
            return string.Format(_handshakeResponse, key);
        }

        public static string GetHandshakeRequestKey(string HttpRequest)
        {
            var keyStart = HttpRequest.IndexOf("Sec-WebSocket-Key: ") + 19;
            var key = string.Empty;

            for (var i = keyStart; i < (keyStart + 24); i++)
            {
                key += HttpRequest[i];
            }

            return key;
        }

        public static string CreateGuid(string prefix, int length = 16)
        {
            var final = string.Empty;
            var random = new Random();

            // Loop and get a random index in the ids and append to id 
            for (var i = 0; i < length; i++)
            {
                final += _ids[random.Next(0, _ids.Length)];
            }

            // Return the guid without a prefix
            if (prefix == null)
            {
                return final;
            }

            // Return the guid with a prefix
            return string.Format("{0}-{1}", prefix, final);
        }
    }
}