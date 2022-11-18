using Newtonsoft.Json;

namespace Haru.Utils
{
    public static class Json
    {
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Serialize<T>(T o, bool stripNull = true)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = (stripNull)
                    ? NullValueHandling.Ignore
                    : NullValueHandling.Include
            };

            return JsonConvert.SerializeObject(o, settings);
        }
    }
}