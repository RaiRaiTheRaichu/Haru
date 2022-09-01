using System.Collections.Generic;
using Haru.Server.Databases;
using Haru.Server.Utils;

namespace Haru.Server.Databases
{
    public static class ResourceDatabase
    {
        public static Dictionary<string, string> Files;

        static ResourceDatabase()
        {
            Files = new Dictionary<string, string>();
            
            // load database
            var json = ResourceHandler.GetText("db.resxdb.json");
            var files = Json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in files)
            {
                Files.Add(kvp.Key, kvp.Value);
            }
        }
    }
}