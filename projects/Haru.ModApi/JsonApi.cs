using Haru.Utils;

namespace Haru.ModApi
{
    public static class JsonApi
    {
        public static T Deserialize<T>(string json)
        {
            return Json.Deserialize<T>(json);
        }

        public static string Serialize(string json, bool stripNull = true)
        {
            return Json.Serialize(json, stripNull);
        }
    }
}
