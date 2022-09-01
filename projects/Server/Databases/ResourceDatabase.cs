using System.Collections.Generic;
using System.Threading.Tasks;
using Haru.Server.Events;
using Haru.Databases;
using Haru.Resources;
using Haru.Server.Utils;

namespace Haru.Server.Databases
{
    public class ResourceDatabase : IResourceDatabase
    {
        public static Dictionary<string, string> Files;

        public ResourceDatabase()
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