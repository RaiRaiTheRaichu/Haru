using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public static class Zlib
    {
        public static byte[] Compress(byte[] data, ZlibCompression level)
        {
            return SimpleZlib.CompressToBytes(data, data.Length, (int)level);
        }

        public static byte[] Decompress(byte[] data)
        {
            return SimpleZlib.DecompressToBytes(data);
        }
    }
}