using Newtonsoft.Json;

namespace Haru.Server.Utils
{
    public static class Json
    {
        private static readonly JsonSerializerSettings _settings;

        static Json()
        {
            _settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Serialize<T>(T o)
        {
            return JsonConvert.SerializeObject(o, _settings);
        }
    }
}