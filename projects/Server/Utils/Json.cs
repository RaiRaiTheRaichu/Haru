using Haru.Server.Utils;
using Newtonsoft.Json;

namespace Haru.Server.Utils
{
    public static class Json
    {
        private readonly JsonSerializerSettings _settings;

        public Json()
        {
            _settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize<T>(T o)
        {
            return JsonConvert.SerializeObject(o, _settings);
        }
    }
}