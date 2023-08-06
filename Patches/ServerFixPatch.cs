using HarmonyLib;

namespace TOHE;

public class ServerFixPatch
{
    [HarmonyPatch(typeof(Constants), nameof(Constants.GetBroadcastVersion))]
    public static bool ConstantsGetBroadcastVersionPatch(ref int __result)
    {
        var CurrentRegion = ServerAddManager.serverManager.CurrentRegion;
        if (!(CurrentRegion.TranslateName is StringNames.ServerNA or StringNames.ServerEU or StringNames.ServerAS or StringNames.ServerSA)) return true;
        __result = Constants.GetVersion(2222, 0, 0, 0);
        Logger.Info($"服务器连接版本修改为 {__result} (2222, 0, 0, 0) ","ConstantsGetBroadcastVersionPatch");
        return false;
    }
}