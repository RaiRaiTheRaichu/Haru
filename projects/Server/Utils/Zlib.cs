using ComponentAce.Compression.Libs.zlib;
using Haru.Models;
using Haru.Server.Utils;

namespace Haru.Server.Utils
{
    public static class Zlib
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