using System;
using System.IO;
using System.Threading.Tasks;
using ComponentAce.Compression.Libs.zlib;
using Haru.Models;

namespace Haru.Utils
{
    public class Zlib
    {
        private ZStream CreateZStream(ref byte[] data, ref byte[] buffer)
        {
            return new ZStream()
            {
                avail_in = data.Length,
                next_in = data,
                next_in_index = 0,
                avail_out = buffer.Length,
                next_out = buffer,
                next_out_index = 0
            };
        }

        public byte[] Compress(byte[] data, ZlibCompression level)
        {
            var buffer = new byte[data.Length + 24];
            var zs = CreateZStream(ref data, ref buffer);

            zs.deflateInit((int)level);
            zs.deflate(zlibConst.Z_FINISH);

            data = new byte[zs.next_out_index];
            Array.Copy(zs.next_out, 0, data, 0, zs.next_out_index);

            return data;
        }

        public async Task<byte[]> Decompress(byte[] data)
        {
            var buffer = new byte[4096];
            var zs = CreateZStream(ref data, ref buffer);

            zs.inflateInit();

            using (var ms = new MemoryStream())
            {
                do
                {
                    zs.avail_out = buffer.Length;
                    zs.next_out = buffer;
                    zs.next_out_index = 0;

                    var result = zs.inflate(0);

                    if (result != 0 && result != 1)
                    {
                        break;
                    }

                    await ms.WriteAsync(zs.next_out, 0, zs.next_out_index);
                }
                while (zs.avail_in > 0 || zs.avail_out == 0);

                return ms.ToArray();
            }
        }
    }
}