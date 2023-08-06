using System.Runtime.InteropServices.ComTypes;
using AmongUs.Data;
using HarmonyLib;
using UnityEngine;

namespace TOHE;

[HarmonyPatch(typeof(ChatController), nameof(ChatController.Update))]
class ChatControllerUpdatePatch
{
    public static int CurrentHistorySelection = -1;
    public static void Prefix()
    {
        if (AmongUsClient.Instance.AmHost && DataManager.Settings.Multiplayer.ChatMode == InnerNet.QuickChatModes.QuickChatOnly)
            DataManager.Settings.Multiplayer.ChatMode = InnerNet.QuickChatModes.FreeChatOrQuickChat; //コマンドを打つためにホストのみ常時フリーチャット開放
    }
    public static void Postfix(ChatController __instance)
    {
        var TextArea = __instance.freeChatField.textArea;
        if (!TextArea.hasFocus) return;

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.C))
            ClipboardHelper.PutClipboardString(TextArea.text);

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.V))
            TextArea.SetText(TextArea.text + GUIUtility.systemCopyBuffer);

        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && Input.GetKeyDown(KeyCode.X))
        {
            ClipboardHelper.PutClipboardString(TextArea.text);
            TextArea.SetText("");
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && ChatCommands.ChatHistory.Count > 0)
        {
            CurrentHistorySelection = Mathf.Clamp(--CurrentHistorySelection, 0, ChatCommands.ChatHistory.Count - 1);
            TextArea.SetText(ChatCommands.ChatHistory[CurrentHistorySelection]);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && ChatCommands.ChatHistory.Count > 0)
        {
            CurrentHistorySelection++;
            if (CurrentHistorySelection < ChatCommands.ChatHistory.Count)
                TextArea.SetText(ChatCommands.ChatHistory[CurrentHistorySelection]);
            else TextArea.SetText("");
        }
    }
}