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

        public static async void Write(string text)
        {
            await _log.Write(text);
        }
    }
}
