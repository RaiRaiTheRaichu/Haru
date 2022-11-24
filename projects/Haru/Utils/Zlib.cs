using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public class Zlib
    {
        public byte[] Compress(byte[] data, ZlibCompression level)
        {
            return SimpleZlib.CompressToBytes(data, data.Length, (int)level);
        }

        public byte[] Decompress(byte[] data)
        {
            return SimpleZlib.DecompressToBytes(data);
        }
    }
}