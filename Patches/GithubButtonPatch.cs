using System.Linq;
using HarmonyLib;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TOHE;

[HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]
public class MainMenuStartPatch
{
    private static void Prefix(MainMenuManager __instance)
    {
        var template = GameObject.Find("ExitGameButton");
        if (template == null) return;
        var buttonGitHub = UnityEngine.Object.Instantiate(template, null);
        GameObject.Destroy(buttonGitHub.GetComponent<AspectPosition>());
        buttonGitHub.transform.localPosition = new(4f, -2, 0);

        var textGitHub = buttonGitHub.GetComponentInChildren<TextMeshPro>();
        textGitHub.transform.localPosition = new(0, 0.035f, -2);
        textGitHub.alignment = TextAlignmentOptions.Right;
        __instance.StartCoroutine(Effects.Lerp(0.1f, new System.Action<float>((p) =>
        {
            if (textGitHub != null)
                textGitHub.SetText("GitHub");
        })));

        PassiveButton passiveButtonGitHub = buttonGitHub.GetComponent<PassiveButton>();
        SpriteRenderer buttonSpriteGitHub = buttonGitHub.transform.FindChild("Inactive").GetComponent<SpriteRenderer>();

        passiveButtonGitHub.OnClick = new Button.ButtonClickedEvent();
        passiveButtonGitHub.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://github.com/DuyeYa/NTOHER1")));

        Color GitHubColor = new Color32(135, 206, 250, byte.MaxValue);
        buttonSpriteGitHub.color = textGitHub.color = GitHubColor;
        passiveButtonGitHub.OnMouseOut.AddListener((System.Action)delegate
        {
            buttonSpriteGitHub.color = textGitHub.color = GitHubColor;
        });

    }
}
