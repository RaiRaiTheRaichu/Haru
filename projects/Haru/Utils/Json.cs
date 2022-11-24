using Newtonsoft.Json;

namespace Haru.Utils
{
    public class Json
    {
        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string Serialize<T>(T o, bool stripNull = true)
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