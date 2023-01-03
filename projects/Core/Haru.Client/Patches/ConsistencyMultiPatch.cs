﻿using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FilesChecker;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public class ConsistencyMultiPatch : APatch
    {
        public ConsistencyMultiPatch()
        {
            Id = "com.haru.client.consistencymulti";
            Type = EPatchType.Prefix;
        }

        protected override MethodBase GetOriginalMethod()
        {
            var types = typeof(ICheckResult).Assembly.GetTypes();
            var type = types.Single(x => x.Name == "ConsistencyController");
            return type.GetMethods().Single(
                x => x.Name == "EnsureConsistency" &&
                x.ReturnType == typeof(Task<ICheckResult>));
        }

        protected static bool Patch(ref Task __result)
        {
            __result = Task.FromResult<ICheckResult>(new FakeFileCheckerResult());
            return false;
        }
    }
}
