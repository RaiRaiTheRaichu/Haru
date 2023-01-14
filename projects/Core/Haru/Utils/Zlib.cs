using System.IO;
using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public class Zlib
    {
        private byte[] Run(byte[] data, bool compress, ZlibCompression level = ZlibCompression.Store)
        {
            using (var ms = new MemoryStream())
            {
                // ZOutputStream.Close() flushes itself.
                // ZOutputStream.Flush() flushes the target stream.
                // It's fucking stupid, but whatever.
                // -- Waffle.Lord, 2022-12-01

                using (var zs = (compress) ? new ZOutputStream(ms, (int)level) : new ZOutputStream(ms))
                {
                    zs.Write(data, 0, data.Length);
                }

                return ms.ToArray();
            }
        }

        public byte[] Compress(byte[] data, ZlibCompression level)
        {
            return Run(data, true, level);
        }

        public byte[] Decompress(byte[] data)
        {
            return Run(data, false);
        }
    }
}