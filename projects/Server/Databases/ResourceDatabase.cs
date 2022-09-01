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
        private readonly IJson _json;
        private readonly IEventBus _eventBus;
        private readonly IResourceHandler _resourceHandler;
        public Dictionary<string, string> Files { get; set; }

        public string[] FileNames { get; private set; }

        public ResourceDatabase(IJson json, IEventBus eventBus, IResourceHandler resourceHandler)
        {
            _json = json;
            _eventBus = eventBus;
            _resourceHandler = resourceHandler;
            Files = new Dictionary<string, string>();
        }

        public async Task Initialize()
        {
            var json = await _resourceHandler.GetText("db.resxdb.json");
            var files = _json.Deserialize<Dictionary<string, string>>(json);

            foreach (var kvp in files)
            {
                Files.Add(kvp.Key, kvp.Value);
            }

            var localesKeys = Files.Keys;
            FileNames = new string[localesKeys.Count];
            localesKeys.CopyTo(FileNames, 0);
            await _eventBus.Invoke<ResourcesDatabaseInitialized>();
        }
    }
}