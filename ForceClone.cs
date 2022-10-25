using System.Reflection;
using VRC.Core;
using MelonLoader;

[assembly: MelonInfo(typeof(ForceClone.ForceCloneMod), "ForceClone", "1.0.0", "Behemoth")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace ForceClone
{
    public class ForceCloneMod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            var original = typeof(APIUser).GetProperty(nameof(APIUser.allowAvatarCopying)).GetSetMethod();
            var method = typeof(ForceCloneMod).GetMethod(nameof(ForceCloneMod.Hook), BindingFlags.NonPublic | BindingFlags.Static);
            var patch = new HarmonyLib.HarmonyMethod(method);
            HarmonyInstance.Patch(original, patch);
        }

        private static void Hook(ref bool __0) => __0 = true;
    }
}
