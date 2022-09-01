using System.IO;
using System.Threading.Tasks;
using Haru.Server.Utils;

namespace Haru.Server.Utils
{
    public satic class VFS
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

        public void WriteText(
            string filepath, string text, bool append = false)
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

        public string ReadText(string filepath)
        {
            if (!Exists(filepath))
            {
                return "";
            }

            using (var fs = new FileStream(
                filepath,FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
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