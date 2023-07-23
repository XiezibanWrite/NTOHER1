using System;
using System.Collections.Generic;
using System.Linq;
using AmongUs.Data;
using AmongUs.Data.Player;
using Assets.InnerNet;
using HarmonyLib;
using Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace TOHE;

// ##https://github.com/Yumenopai/TownOfHost_Y
public class ModNews
{
    public int Number;
    public int BeforeNumber;
    public string Title;
    public string SubTitle;
    public string ShortTitle;
    public string Text;
    public string Date;

    public Announcement ToAnnouncement()
    {
        var result = new Announcement
        {
            Number = Number,
            Title = Title,
            SubTitle = SubTitle,
            ShortTitle = ShortTitle,
            Text = Text,
            Language = (uint)DataManager.Settings.Language.CurrentLanguage,
            Date = Date,
            Id = "ModNews"
        };

        return result;
    }
}
[HarmonyPatch]
public class ModNewsHistory
{
    public static List<ModNews> AllModNews = new();

    // 
    public static void Init()
    {
        // When creating new news, you can not delete old news
        {
            // NTOHER v1.1.1
            var news = new ModNews
            {
                Number = 100001,
                Title = "NewTownOfHostEditedRolesv1.1.1",
                SubTitle = "★★★★更新啦★★★★",
                ShortTitle = "★NTOHER v1.1.1",
                Text = "<size=150%>欢迎来到 NTOHER v1.1.1.</size>\n\n<size=125%>适配Among us6.27</size>\n"
                    + "\n【声明】## -本模组不隶属于Amongus或Innersloth LLC\n其中包含的内容未得到Innersloth LLC的认可或以其他方式赞助\n此处包含的部分材料是Innersloth LLC的财产\nInnersloth©有限责任公司 "
                    + "\n【对应官方版本】\n - TOH v5.0.0\r\n - TOHE v2.3.5\r\n"
                    + "\n【更正】\n - TOHE图标"
                    + "\n【修复】\n - 修复很多bug\n\r"
                    + "\n【新职业】\n ##船员阵营 \n - 神谕 \n - 惩罚者 \n ##内鬼阵营 \n - 邪恶的审判员 \n ##中立阵营 \n - 律师 \n - 秃鹫 \n ##附加职业 \n - 尸检"
                    + "\n【鸣谢】\n-乐崽——封装 \n-艾格——美工 \nNight_瓜——贡献者(给予帮助)",
                Date = "2023-7-23T00:00:00Z"

            };
            AllModNews.Add(news);
        }   
    }

    [HarmonyPatch(typeof(PlayerAnnouncementData), nameof(PlayerAnnouncementData.SetAnnouncements)), HarmonyPrefix]
    public static bool SetModAnnouncements(PlayerAnnouncementData __instance, [HarmonyArgument(0)] ref Il2CppReferenceArray<Announcement> aRange)
    {
        if (AllModNews.Count < 1)
        {
            Init();
            AllModNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });
        }

        List<Announcement> FinalAllNews = new();
        AllModNews.Do(n => FinalAllNews.Add(n.ToAnnouncement()));
        foreach (var news in aRange)
        {
            if (!AllModNews.Any(x => x.Number == news.Number))
                FinalAllNews.Add(news);
        }
        FinalAllNews.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });

        aRange = new(FinalAllNews.Count);
        for (int i = 0; i < FinalAllNews.Count; i++)
            aRange[i] = FinalAllNews[i];

        return true;
    }
}