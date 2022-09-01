using System;
using System.Threading.Tasks;
using Haru.Server.Utils;

namespace Haru.Server.Utils
{
    public class Log
    {
        private readonly string _filepath;

        public Log()
        {
            _filepath = "./Logs/Haru.log";

            if (VFS.Exists(_filepath))
            {
                VFS.WriteText(_filepath, string.Empty);
            }
        }

        public void Write(string text)
        {
            var formatted = $"[{DateTime.Now}]: {text}";
            Console.WriteLine(formatted);
            VFS.WriteText(_filepath, formatted, true);
        }
    }
}