using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Haru.Extensions;

namespace Haru.Server.Utils
{
    public static class Resource
    {
        private static readonly Dictionary<Assembly, string[]> _names;
        private const string ROOT_PATH = "{0}.Resources.Embedded.{1}";

        static Resource()
        {
            _names = new Dictionary<Assembly, string[]>();
        }

        public static void RegisterAssembly(Assembly asm)
        {
            _names.Add(asm, asm.GetManifestResourceNames());
        }

        public static Stream GetStream(string filepath)
        {
            foreach (var kvp in _names)
            {
                // get assembly name
                var name = kvp.Key.GetName().Name;

                // hack: Remove "NLog." to match assembly root namespace
                name = name.ReplaceFirst("NLog.", "");

                // find assembly resource
                var resx = string.Format(ROOT_PATH, name, filepath);

                if (Array.IndexOf(kvp.Value, resx) != -1)
                {
                    return kvp.Key.GetManifestResourceStream(resx);
                }
            }

            throw new ResourceNotFoundException(
                $"Cannot find resource {filepath}");
        }

        public static string GetText(string filepath)
        {
            using (var resource = GetStream(filepath))
            {
                using (var sr = new StreamReader(resource))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public static byte[] GetData(string filepath)
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