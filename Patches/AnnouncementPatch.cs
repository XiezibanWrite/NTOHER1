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
        // 创建新公告时，不能删除旧公告
                {
            // NTOHER v1.1.7
            var news = new ModNews
            {
                Number = 100005,
                Title = "NewTownOfHostEditedRolesv1.1.7",
                SubTitle = "★★★★更新新框架！！！以及新身份★★★★",
                ShortTitle = "★NTOHER v1.1.7",
                Text = "<size=100%>欢迎来到 NTOHER v1.1.6.</size>\n\n<size=125%>适配Among us v7.12</size>\n框架更新至672\n"
                    + "\n【声明】-本模组不隶属于Amongus或Innersloth LLC其中包含的内容未得到Innersloth LLC的认可或以其他方式赞助此处包含的部分材料是Innersloth LLC的财产Innersloth©有限责任公司 "
                    + "\n【对应官方版本】\n - TOH v5.0.2\r\n - TOHE v2.3.5\r\n"
                    + "\n【更正】\n -无"
                    + "\n【修复】\n -尝试修复爱人"
                    + "\n【新职业】\n-内鬼阵营\n-教父\n-天文家\n-中立阵营\n-萨满巫师"
                    + "\n【鸣谢】\n-乐崽——封装 \n-艾格——美工 \nNight_瓜——贡献者(给予帮助)",
                Date = "2023-8-7T00:00:00Z",
            };
            AllModNews.Add(news);
        }

        {
            // NTOHER v1.1.6    
            var news = new ModNews
            {
                Number = 100004,
                Title = "NewTownOfHostEditedRolesv1.1.6",
                SubTitle = "★★★★适配啦!!!★★★★",
                ShortTitle = "★NTOHER v1.1.6",
                Text = "<size=100%>欢迎来到 NTOHER v1.1.6.</size>\n\n<size=125%>适配Among us v7.11(和7.12)</size>\n"
                    + "\n【声明】-本模组不隶属于Amongus或Innersloth LLC其中包含的内容未得到Innersloth LLC的认可或以其他方式赞助此处包含的部分材料是Innersloth LLC的财产Innersloth©有限责任公司 "
                    + "\n【对应官方版本】\n - TOH v5.0.2\r\n - TOHE v2.3.5\r\n"
                    + "\n【更正】\n -颜色错位"
                    + "\n【修复】\n -图标"
                    + "\n【新职业】\n-中立阵营\n-爱人\n-(PS:目前模组端有BUG,非模组端无BUG)"
                    + "\n【鸣谢】\n-乐崽——封装 \n-艾格——美工 \nNight_瓜——贡献者(给予帮助)"
                    + "\n【PS】\n-失忆者模组端有BUG不知道为什么(doge!)",
                Date = "2023-8-6T00:00:00Z",
            };
            AllModNews.Add(news);
        }

        {
            // NTOHER v1.1.3
            var news = new ModNews
            {
                Number = 100003,
                Title = "NewTownOfHostEditedRolesv1.1.3",
                SubTitle = "★★★★专注绘制图标★★★★",
                ShortTitle = "★NTOHER v1.1.3",
                Text = "<size=100%>欢迎来到 NTOHER v1.1.3.</size>\n\n<size=125%>适配Among us v6.27</size>\n"
                    + "\n【声明】-本模组不隶属于Amongus或Innersloth LLC其中包含的内容未得到Innersloth LLC的认可或以其他方式赞助此处包含的部分材料是Innersloth LLC的财产Innersloth©有限责任公司 "
                    + "\n【对应官方版本】\n - TOH v5.0.0\r\n - TOHE v2.3.5\r\n"
                    + "\n【更正】\n -马里奥，夺魂者，赏金猎人，警长，时间之主，失忆者，死亡契约增添图标"
                    + "\n【修复】\n -修复秃鹫"
                    + "\n【新职业】\n 中立阵营 \n - 挑战者"
                    + "\n【鸣谢】\n-乐崽——封装 \n-艾格——美工 \nNight_瓜——贡献者(给予帮助)"
                    + "\n这个主开发者就算逊了",
                Date = "2023-7-30T00:00:00Z",
            };
            AllModNews.Add(news);
        }

        {
            // NTOHER v1.1.2
            var news = new ModNews
            {
                Number = 100002,
                Title = "NewTownOfHostEditedRolesv1.1.2",
                SubTitle = "★★★★乐！★★★★",
                ShortTitle = "★NTOHER v1.1.2",
                Text = "<size=100%>欢迎来到 NTOHER v1.1.2.</size>\n\n<size=125%>适配Among us v6.27</size>\n"
                    + "\n【声明】## -本模组不隶属于Amongus或Innersloth LLC其中包含的内容未得到Innersloth LLC的认可或以其他方式赞助此处包含的部分材料是Innersloth LLC的财产Innersloth©有限责任公司 "
                    + "\n【对应官方版本】\n - TOH v5.0.0\r\n - TOHE v2.3.5\r\n"
                    + "\n【更正】\n - 图标"
                    + "\n【修复】\n - 修复了代码语言缺少的问题\n - 修复了右上角水印位置不正确的问题\n -修复了部分错误中文的问题"
                    + "\n【新职业】\n船员阵营 \n - 时间之主 \n内鬼阵营 \n - 死亡契约 \n中立阵营 \n - 失忆者 \n - 末日赌怪\n附加职业 \n - 无"
                    + "\n【鸣谢】\n-乐崽——封装 \n-艾格——美工 \nNight_瓜——贡献者(给予帮助)",
                Date = "2023-7-25T00:00:00Z"
            };
            AllModNews.Add(news);
        }

        {
            // NTOHER v1.1.1
            var news = new ModNews
            {
                Number = 100001,
                Title = "NewTownOfHostEditedRolesv1.1.1",
                SubTitle = "★★★★更新啦★★★★",
                ShortTitle = "★NTOHER v1.1.1",
                Text = "<size=100%>欢迎来到 NTOHER v1.1.1.</size>\n\n<size=125%>适配Among us v6.27</size>\n"
                    + "\n【声明】-本模组不隶属于Amongus或Innersloth LLC其中包含的内容未得到Innersloth LLC的认可或以其他方式赞助此处包含的部分材料是Innersloth LLC的财产Innersloth©有限责任公司 "
                    + "\n【对应官方版本】\n - TOH v5.0.0\r\n - TOHE v2.3.5\r\n"
                    + "\n【更正】\n - TOHE图标"
                    + "\n【修复】\n - 修复很多bug\n\r"
                    + "\n【新职业】\n船员阵营 \n - 神谕 \n - 惩罚者 \n内鬼阵营 \n - 邪恶的审判员 \n中立阵营 \n - 律师 \n - 秃鹫 \n附加职业 \n - 尸检"
                    + "\n【鸣谢】\n-乐崽——封装 \n-艾格——美工 \nNight_瓜——贡献者(给予帮助)",
                Date = "2023-7-23T00:00:00Z"
            };
            AllModNews.Add(news);
        }
    }

    [HarmonyPatch(typeof(PlayerAnnouncementData), nameof(PlayerAnnouncementData.SetAnnouncements)), HarmonyPrefix]
    public static bool SetModAnnouncements(PlayerAnnouncementData __instance, [HarmonyArgument(0)] ref Il2CppReferenceArray<Announcement> aRange)
    {
        List<Announcement> list = new();
        list.AddRange(aRange);
        AllModNews.Do(n => list.Add(n.ToAnnouncement()));
        list.Sort((a1, a2) => { return DateTime.Compare(DateTime.Parse(a2.Date), DateTime.Parse(a1.Date)); });        
        aRange = list.ToArray();
        return true;
    }
}