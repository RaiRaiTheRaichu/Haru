using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Haru.Extensions;

namespace Haru.Server.Resources
{
    public static class ResourceHandler
    {
        private readonly Dictionary<Assembly, string[]> _names;
        private const string ROOT_PATH = "{0}.Resources.Embedded.{1}";

        public ResourceHandler()
        {
            _names = new Dictionary<Assembly, string[]>();
            RegisterAssembly(Assembly.GetExecutingAssembly());
        }

        public void RegisterAssembly(Assembly asm)
        {
            _names.Add(asm, asm.GetManifestResourceNames());
        }

        public Stream GetStream(string filepath)
        {
            foreach (var kvp in _names)
            {
                var name = kvp.Key.GetName().Name;
                var resx = string.Format(ROOT_PATH, name, filepath);

                if (Array.IndexOf(kvp.Value, resx) != -1)
                {
                    return kvp.Key.GetManifestResourceStream(resx);
                }
            }

            throw new ResourceNotFoundException(
                $"Cannot find resource {filepath}");
        }

        public string GetText(string filepath)
        {
            using (var resource = GetStream(filepath))
            {
                using (var sr = new StreamReader(resource))
                {
                    return await sr.ReadToEnd();
                }
            }
        }

        public byte[] GetData(string filepath)
        {
            using (var resource = GetStream(filepath))
            {
                using (var ms = new MemoryStream())
                {
                    resource.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }
    }
}