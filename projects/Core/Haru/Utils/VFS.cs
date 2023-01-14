using System.IO;

namespace Haru.Utils
{
    public class VFS
    {
        public bool Exists(string filepath)
        {
            return (File.Exists(filepath) || Directory.Exists(filepath));
        }

        public void CreateDirectory(string filepath)
        {
            var path = Path.GetDirectoryName(filepath);
            Directory.CreateDirectory(path);
        }

        public void WriteText(string filepath, string text, bool append = false)
        {
            if (!Exists(filepath))
            {
                CreateDirectory(filepath);
            }

            var mode = (append ? FileMode.Append : FileMode.Create);

            using (var fs = new FileStream(filepath, mode, FileAccess.Write))
            {
                using (var sr = new StreamWriter(fs))
                {
                    sr.WriteLine(text);
                }
            }
        }

        public void WriteBytes(string filepath, byte[] bytes)
        {
            if (!Exists(filepath))
            {
                CreateDirectory(filepath);
            }

            using (var fs = new FileStream(filepath, FileMode.Create, FileAccess.Write))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        public string ReadText(string filepath)
        {
            if (!Exists(filepath))
            {
                throw new FileNotFoundException(filepath);
            }

            using (var fs = new FileStream(filepath,FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public byte[] ReadBytes(string filepath)
        {
            if (!Exists(filepath))
            {
                throw new FileNotFoundException(filepath);
            }

            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                using (var ms = new MemoryStream())
                {
                    fs.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        public string GetFileExtension(string filepath)
        {
            return Path.GetExtension(filepath);
        }

        public string GetFileName(string filepath)
        {
            return Path.GetFileNameWithoutExtension(filepath);
        }
    }
}