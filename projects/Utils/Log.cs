using System;

namespace Haru.Utils
{
    public static class Log
    {
        private static readonly string _filepath;

        static Log()
        {
            _filepath = "./Logs/Haru.log";

            if (VFS.Exists(_filepath))
            {
                VFS.WriteText(_filepath, string.Empty);
            }
        }

        public static void Write(string text)
        {
            var formatted = $"[{DateTime.Now}]: {text}";
            Console.WriteLine(formatted);
            VFS.WriteText(_filepath, formatted, true);
        }
    }
}