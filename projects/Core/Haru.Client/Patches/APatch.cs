﻿using System;
using System.Reflection;
using HarmonyLib;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public abstract class APatch
    {
        public EPatchType Type { get; protected set; }
        public string Id { get; protected set; }

        protected abstract MethodBase GetOriginalMethod();

        private HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var mi = GetType().GetMethod("Patch", flags);
            return new HarmonyMethod(mi);
        }

        public void Enable()
        {
            var harmony = new HarmonyLib.Harmony(Id);

            switch (Type)
            {
                case EPatchType.Prefix:
                    harmony.Patch(GetOriginalMethod(), prefix: GetPatchMethod());
                    return;

                case EPatchType.Postfix:
                    harmony.Patch(GetOriginalMethod(), postfix: GetPatchMethod());
                    return;

                case EPatchType.Transpile:
                    harmony.Patch(GetOriginalMethod(), transpiler: GetPatchMethod());
                    return;

                default:
                    throw new NotImplementedException("Patch type");
            }
        }
    }
}
