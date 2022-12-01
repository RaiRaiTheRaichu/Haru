using System;
using System.Threading.Tasks;

namespace Haru.Utils
{
    public class Log
    {
        private static readonly string _filepath;
        private static readonly VFS _vfs;

        static Log()
        {
            _filepath = "./Logs/Haru.log";
            _vfs = new VFS();
            Initialize();
        }

        public static async void Initialize()
        {
            if (_vfs.Exists(_filepath))
            {
                await _vfs.WriteText(_filepath, string.Empty);
            }
        }

        public async Task Write(string text)
        {
            var datetime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
            var formatted = $"[{datetime}]: {text}";

            Console.WriteLine(formatted);
            await _vfs.WriteText(_filepath, formatted, true);
        }
    }
}