using System.Collections.Generic;
using System.Linq;

namespace TOHE;

public class DevUser
{
    public string Code { get; set; }
    public string Color { get; set; }
    public string Tag { get; set; }
    public bool IsUp { get; set; }
    public bool IsDev { get; set; }
    public bool DeBug { get; set; }
    public string UpName { get; set; }
    public DevUser(string code = "", string color = "null", string tag = "null", bool isUp = false, bool isDev = false, bool deBug = false, string upName = "未认证用户")
    {
        Code = code;
        Color = color;
        Tag = tag;
        IsUp = isUp;
        IsDev = isDev;
        DeBug = deBug;
        UpName = upName;
    }
    public bool HasTag() => Tag != "null";
    public string GetTag() => Color == "null" ? $"<size=1.7>{Tag}</size>\r\n" : $"<color={Color}><size=1.7>{(Tag == "#Dev" ? Translator.GetString("Developer") : Tag)}</size></color>\r\n";
}

public static class DevManager
{
    public static DevUser DefaultDevUser = new();
    public static List<DevUser> DevUserList = new();
    public static void Init()
    {
        // Dev
        DevUserList.Add(new(code: "gridunable#5279", color: "#87CEFA", tag: "#Dev", isUp: true, isDev: true, deBug: true, upName: "毒液"));
        DevUserList.Add(new(code: "actorour#0029", color: "#ffc0cb", tag: "#Dev", isUp: true, isDev: true, deBug: true, upName: "KARPED1EM"));
        DevUserList.Add(new(code: "pinklaze#1776", color: "#30548e", tag: "#Dev", isUp: true, isDev: true, deBug: true, upName: "NCSIMON"));
        DevUserList.Add(new(code: "keepchirpy#6354", color: "#1FF3C6", tag: "Переводчик", isUp: false, isDev: true, deBug: false, upName: null)); //Tommy-XL
        DevUserList.Add(new(code: "taskunsold#2701", color: "null", tag: "<color=#426798>Tem</color><color=#f6e509>mie</color>", isUp: false, isDev: true, deBug: false, upName: null)); //Tem
        DevUserList.Add(new(code: "timedapper#9496", color: "#48FFFF", tag: "#Dev", isUp: false, isDev: true, deBug: true, upName: null)); //阿龍
        DevUserList.Add(new(code: "sofaagile#3120", color: "null", tag: "null", isUp: false, isDev: true, deBug: true, upName: null)); //天寸

        // Up
        DevUserList.Add(new(code: "truantwarm#9165", color: "null", tag: "null", isUp: true, isDev: false, deBug: false, upName: "萧暮不姓萧"));
        DevUserList.Add(new(code: "storyeager#0815", color: "null", tag: "null", isUp: true, isDev: false, deBug: false, upName: "航娜丽莎"));
        DevUserList.Add(new(code: "storeroan#0331", color: "#FF0066", tag: "Night_瓜", isUp: true, isDev: false, deBug: false, upName: "Night_瓜"));
        DevUserList.Add(new(code: "teamelder#5856", color: "#1379bf", tag: "屑Slok（没信誉的鸽子）", isUp: true, isDev: false, deBug: false, upName: "Slok7565"));
        DevUserList.Add(new(code: "farwig#2804", color: "#ffff00", tag: "贡献者", isUp: true, isDev: true, deBug: true, upName: "水木年华"));
        DevUserList.Add(new(code: "herdsiaty#9698", color: "#666666", tag: "贡献者/金主爹爹", isUp: true, isDev: true, deBug: true, upName: "屑杰鱼"));
        DevUserList.Add(new(code: "cloakhazy#9133", color: "#FFFF00", tag: "贡献者/打包", isUp: true, isDev: true, deBug: true, upName: "LezaiYa（乐崽呀）"));
        DevUserList.Add(new(code: "radarright#2509", color: "null", tag: "null", isUp: false, isDev: false, deBug: true, upName: null));

        // Sponsor
        DevUserList.Add(new(code: "herdslaty#9698", color: "#808080", tag: "屑杰鱼", isUp: false, isDev: false, deBug: false, upName: null)); //屑杰鱼
        DevUserList.Add(new(code: "beamelfin#9478", color: "#6495ED", tag: "一师傅", isUp: false, isDev: false, deBug: false, upName: null)); //A master
    }
    public static bool IsDevUser(this string code) => DevUserList.Any(x => x.Code == code);
    public static DevUser GetDevUser(this string code) => code.IsDevUser() ? DevUserList.Find(x => x.Code == code) : DefaultDevUser;
}
