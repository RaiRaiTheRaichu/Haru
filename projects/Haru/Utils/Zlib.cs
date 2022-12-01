using System.IO;
using System.Threading.Tasks;
using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public class Zlib
    {
        public async Task<byte[]> Compress(byte[] data, ZlibCompression level)
        {
            var buffer = new byte[data.Length + 24];
            var zs = new ZStream()
            {
                avail_in = data.Length,
                next_in = data,
                next_in_index = 0,
                avail_out = buffer.Length,
                next_out = buffer,
                next_out_index = 0
            };

            zs.deflateInit((int)level);
            zs.deflate(zlibConst.Z_FINISH);

            using (var ms = new MemoryStream())
            {
                await ms.WriteAsync(zs.next_out, 0, zs.next_out_index);
                return ms.ToArray();
            }
        }

        public async Task<byte[]> Decompress(byte[] data)
        {
            using (var msOut = new MemoryStream())
            {
                using (var zsOut = new ZOutputStream(msOut))
                {
                    using (var msIn = new MemoryStream(data))
                    {
                        await msIn.CopyToAsync(zsOut);
                        return msOut.ToArray();
                    }
                }
            }
        }
    }
}