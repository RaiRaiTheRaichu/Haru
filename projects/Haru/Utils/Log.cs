using System;

namespace Haru.Utils
{
    public class Log
    {
        private static readonly string _filepath;
        private readonly VFS _vfs;

        static Log()
        {
            _filepath = "./Logs/Haru.log";
        }

        public Log()
        {
            _vfs = new VFS();

            if (_vfs.Exists(_filepath))
            {
                _vfs.WriteText(_filepath, string.Empty);
            }
        }

        public void Write(string text)
        {
            var datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            var formatted = $"[{datetime}]: {text}";

            Console.WriteLine(formatted);
            _vfs.WriteText(_filepath, formatted, true);
        }
    }
}