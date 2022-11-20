namespace WebSocketServer
{
    public struct SFrameMaskData
    {
        public int DataLength;
        public int KeyIndex;
        public int TotalLenght;
        public EOpcodeType Opcode;

        public SFrameMaskData(int dataLength, int keyIndex, int totalLenght, EOpcodeType opcode)
        {
            DataLength = dataLength;
            KeyIndex = keyIndex;
            TotalLenght = totalLenght;
            Opcode = opcode;
        }
    }
}