using BepInEx;
using BepInEx.Unity.IL2CPP;
using VRC.Core;
using System.Reflection;
using HarmonyLib;

namespace ForceClone;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInProcess("VRChat.exe")]
public class ForceCloneMod : BasePlugin
{
    public override void Load()
    {
        var original = typeof(APIUser).GetProperty(nameof(APIUser.allowAvatarCopying)).GetSetMethod();
        var method = typeof(ForceCloneMod).GetMethod(nameof(Hook), BindingFlags.NonPublic | BindingFlags.Static);
        var patch = new HarmonyMethod(method);
        var harmony = new Harmony("com.reggie.ironlightsmod");
        harmony.Patch(original, patch);
    }

    private static void Hook(ref bool __0) => __0 = true;
}
