using System;
using System.IO;
using System.Threading.Tasks;
using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public class Zlib
    {
        public Task<byte[]> Compress(byte[] data, ZlibCompression level)
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

            data = new byte[zs.next_out_index];
            Array.Copy(zs.next_out, 0, data, 0, zs.next_out_index);

            return Task.FromResult(data);
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