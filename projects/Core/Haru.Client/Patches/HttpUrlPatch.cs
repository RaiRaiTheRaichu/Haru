// This patch does two things:
// 1. change protocols to non-SSL variants.
// 2. fix url protocol (which somehow has https://http:// in it).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Haru.Client.Helpers;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class HttpUrlPatch : APatch
    {
        private PatchHelper _patchHelper;
        private static Type _type;
        private static FieldInfo _prefixes;
        private static readonly Dictionary<ETransportProtocolType, string> _protocols;

        static HttpUrlPatch()
        {
            _protocols = new Dictionary<ETransportProtocolType, string>()
            {
                { ETransportProtocolType.HTTPS, "http://" },
                { ETransportProtocolType.WSS, "ws://" }
            };
        }

        public HttpUrlPatch(PatchHelper patchHelper) : base()
        {
            Id = "com.haru.client.httpurl";
            Type = EPatchType.Prefix;
            _patchHelper = patchHelper;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var name = "CreateFromLegacyParams";

            // get type
            _type = _patchHelper.EftTypes.Single(x => x?.GetMethod(name) != null);

            // get field
            _prefixes = _type.GetField("TransportPrefixes");

            // get method
            return _type.GetMethod(name);
        }

        protected static bool Patch(object __result, object __instance, object[] __args, MethodBase __originalMethod)
        {
            // change transport layers
            _prefixes.SetValue(__instance, _protocols);

            // we're dealing here with an obfuscated object (GStruct22 legacyParams),
            // so we gotta use reflection to get the parameter and all it's fields.
            var legacy_obj                          = __args[0];
            var legacy_type                         = __originalMethod.GetParameters()[0].ParameterType;
            var legacy_url                          = (string)legacy_type.GetField("Url").GetValue(legacy_obj);
            var legacy_useCache                     = (bool)legacy_type.GetField("UseCache").GetValue(legacy_obj);
            var legacy_cacheId                      = (string)legacy_type.GetField("CacheId").GetValue(legacy_obj);
            var legacy_defaultObjectInCaseOfCache   = (object)legacy_type.GetField("DefaultObjectInCaseOfCache").GetValue(legacy_obj);
            var legacy_params                       = (object)legacy_type.GetField("Params").GetValue(legacy_obj);
            var legacy_retries                      = (byte?)legacy_type.GetField("Retries").GetValue(legacy_obj);
            var legacy_timoutSeconds                = (int)legacy_type.GetField("TimeoutSeconds").GetValue(legacy_obj);
            var legacy_defaultTimoutSeconds         = (int)legacy_type.GetField("DefaultTimeoutSeconds").GetValue(legacy_obj);
            var legacy_handlingMode                 = (ERequestHandlingMode)legacy_type.GetField("HandlingMode").GetValue(legacy_obj);

            // strip protocols from arguments
            var url = legacy_url.Replace("https://", "").Replace("http://", "");
            var seconds = legacy_timoutSeconds > 0 ? legacy_timoutSeconds : legacy_defaultTimoutSeconds;

            // original function below, but written using reflection
            var splitUrl = url.Split('/');

            var result_obj = Activator.CreateInstance(_type);
            _type.GetField("BackendName").SetValue(result_obj, splitUrl[0]);
            _type.GetField("BackendField").SetValue(result_obj, $"/{ splitUrl[1] }");
            _type.GetField("FallbackBackendNames").SetValue(result_obj, null);
            _type.GetField("ShouldUseCache").SetValue(result_obj, legacy_useCache);
            _type.GetField("OverrideCacheId").SetValue(result_obj, legacy_cacheId);
            _type.GetField("DefaultObjectInCaseOfCache").SetValue(result_obj, legacy_defaultObjectInCaseOfCache);
            _type.GetField("Params").SetValue(result_obj, legacy_params);
            _type.GetField("Retries").SetValue(result_obj, legacy_retries);
            _type.GetField("TimeoutSeconds").SetValue(result_obj, seconds);
            _type.GetField("HandlingMode").SetValue(result_obj, legacy_handlingMode);

            __result = result_obj;
            return false;
        }
    }
}