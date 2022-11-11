using System.Collections.Generic;
using Haru.Utils;

namespace Haru.Server.Databases
{
    public static class ResourceDatabase
    {
        public static Dictionary<string, string> Files;

        static ResourceDatabase()
        {
            Files = new Dictionary<string, string>();

            var json = Resource.GetText("db.resxdb.json");
            var files = Json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in files)
            {
                Files.Add(kvp.Key, kvp.Value);
            }
        }
    }
}