using System.IO;
using System.Threading.Tasks;

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

        public async Task WriteText(
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
                    await sr.WriteLineAsync(text);
                }
            }
        }

        public async Task<string> ReadText(string filepath)
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
                    return await sr.ReadToEndAsync();
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