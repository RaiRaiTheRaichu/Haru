using Haru.Utils;

namespace Haru.ModApi
{
    public static class JsonApi
    {
        private static readonly Json _json;

        static JsonApi()
        {
            _json = new Json();
        }

        public static T Deserialize<T>(string json)
        {
            return _json.Deserialize<T>(json);
        }

        public static string Serialize(string json, bool stripNull = true)
        {
            return _json.Serialize(json, stripNull);
        }
    }
}
