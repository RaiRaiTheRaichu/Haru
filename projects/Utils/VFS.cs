using System.IO;

namespace Haru.Utils
{
    public static class VFS
    {
        public static bool Exists(string filepath)
        {
            return (File.Exists(filepath) || Directory.Exists(filepath));
        }

        public static void CreateDirectory(string filepath)
        {
            var path = Path.GetDirectoryName(filepath);
            Directory.CreateDirectory(path);
        }

        public static void WriteText(
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

        public static string ReadText(string filepath)
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

        public static string GetFileExtension(string filepath)
        {
            return Path.GetExtension(filepath);
        }

        public static string GetFileName(string filepath)
        {
            return Path.GetFileNameWithoutExtension(filepath);
        }
    }
}