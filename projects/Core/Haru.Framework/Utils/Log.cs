using System;
using System.Threading.Tasks;

namespace Haru.Framework.Utils
{
    public class Log
    {
        private static readonly VFS _vfs;
        public static string Filepath;

        private static Log _instance;
        public static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Log();
                }

                return _instance;
            }
        }

        static Log()
        {
            _vfs = new VFS();
            Filepath = $"./Logs/Haru/Haru_{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}.log";
        }

        public async Task Write(string text)
        {
            var datetime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            var formatted = $"[{datetime}]: {text}";
            Console.WriteLine(formatted);
            await _vfs.WriteText(Filepath, formatted, true);
        }
    }
}