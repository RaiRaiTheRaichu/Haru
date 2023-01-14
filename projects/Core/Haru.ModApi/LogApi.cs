using Haru.Utils;

namespace Haru.ModApi
{
    public static class LogApi
    {
        private static readonly Log _log;

        static LogApi()
        {
            _log = new Log();
        }

        public static void Write(string text)
        {
            _log.Write(text);
        }
    }
}
