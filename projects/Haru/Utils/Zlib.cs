using System.IO;
using System.Threading.Tasks;
using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public class Zlib
    {
        private async Task<byte[]> Run(byte[] data, bool compress, ZlibCompression level = ZlibCompression.Store)
        {
            using (var msOut = new MemoryStream())
            {
                // ZOutputStream.Close() flushes itself.
                // ZOutputStream.Flush() flushes the target stream.
                // It's fucking stupid, but whatever.
                // -- Waffle.Lord, 2022-12-01

                using (var zsOut = (compress)
                    ? new ZOutputStream(msOut, (int)level)
                    : new ZOutputStream(msOut))
                {
                    await zsOut.WriteAsync(data, 0, data.Length);
                }

                return msOut.ToArray();
            }
        }

        public async Task<byte[]> Compress(byte[] data, ZlibCompression level)
        {
            return await Run(data, true, level);
        }

        public async Task<byte[]> Decompress(byte[] data)
        {
            return await Run(data, false);
        }
    }
}