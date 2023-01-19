using System;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using Haru.Client.Helpers;
using Haru.Client.Models;

namespace Haru.Client.Patches
{
    public abstract class APatch
    {
        protected PatchHelper _patchHelper;
        public Harmony Harmony { get; private set; }
        public EPatchType Type { get; protected set; }
        public string Id { get; protected set; }

        public APatch()
        {
            _patchHelper = new PatchHelper();
        }

        protected abstract MethodBase GetOriginalMethod();

        private HarmonyMethod GetPatchMethod()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var mi = GetType().GetMethod("Patch", flags);
            return new HarmonyMethod(mi);
        }

        public void Enable()
        {
            Debug.Log($"Running patch {Id}");

            Harmony = new Harmony(Id);

            switch (Type)
            {
                case EPatchType.Prefix:
                    Harmony.Patch(GetOriginalMethod(), prefix: GetPatchMethod());
                    return;

                case EPatchType.Postfix:
                    Harmony.Patch(GetOriginalMethod(), postfix: GetPatchMethod());
                    return;

                case EPatchType.Transpile:
                    Harmony.Patch(GetOriginalMethod(), transpiler: GetPatchMethod());
                    return;

                default:
                    throw new NotImplementedException("Patch type");
            }
        }

        public void Disable()
        {
            if (Harmony != null)
            {
                Harmony.Dispose();
            }
        }
    }
}