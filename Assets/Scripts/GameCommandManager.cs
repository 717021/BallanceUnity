using Helper;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 游戏指令系统管理器
 * 类似于mc的指令
 * 用于游戏调试以及参数查看等
 * 
 * 
 * 此模块已基本完善 2018.6.30
 * 不应该大更改
 * 
 */

/// <summary>
/// 指令管理器
/// </summary>
public class GameCommandManager : MonoBehaviour, IGameBasePart
{
    private int MaxDisplayItem = 1;
    private static GameCommandManager instance;

    public DisplayInfoUi DisplayInfoUi;
    public RectTransform panelCommandRectTransform;
    public RectTransform textLinesRectTransform;
    public RectTransform textLinesViewRectTransform;
    public LayoutElement textLinesLayoutElement;
    public GameObject panelCommand, textShowCmd;
    public Text textLines, textTips;
    public InputField inputCommand;
    public DUIDrag dragCommand;


    /// <summary>
    /// 获取CommandManager实例，可能为空
    /// </summary>
    public static GameCommandManager Instance
    {
        get { return instance; }
    }
    /// <summary>
    /// 获取控制台窗口是否显示
    /// </summary>
    public bool CommandShow
    {
        get { return commandShow; }
        set
        {
            if (commandShow != value)
            {
                commandShow = value;
                DisplayInfoUi.SetPos(CommandShow);
                if (value)
                {
                    textShowCmd.SetActive(false);
                    panelCommand.SetActive(true);
                    commandShowed2Count = 0;
                    commandDisplays2.Clear();
                    CommandShowEnd();
                }
                else
                {
                    panelCommand.SetActive(false);
                    textShowCmd.SetActive(true);
                    textLines.text = "";
                }
            }
        }
    }
    /// <summary>
    /// 当前显示的信息条目位置
    /// </summary>
    public int CommandShowPos
    {
        get { return commandShowPos; }
        set { SetCommandShowPos(value); }
    }

    public GameBulider GameBulider { get; set; }

    private bool isHoneButtonDown = false;
    private bool isEndButtonDown = false;
    private bool isF1ButtonDown = false;
    private bool isPageUpButtonDown = false;
    private bool isPageDownButtonDown = false;
    private bool isSCButtonDown = false;

    private string commandShowFilter = "All";
    private bool commandShow = true;
    private int sx = 0;
    private int sx2 = 0;
    private int sxs = 30;
    private bool scdirect = false;
    private bool scmouse = false;
    private bool showedcmdtip = false;
    private bool showedcmdstip = false;
    private int commandShowPos = 0;
    private int commandShowed2Count = 0;
    private class Dspl2
    {
        public Dspl2(string name, int ccc) { this.name = name; this.ccc = ccc; }
        public string name; public int ccc;
    }
    private static List<Dspl2> commandDisplays2 = new List<Dspl2>();
    private static List<string> commandDisplays = new List<string>();

    private void SetCommandDisPalyItem(int i)
    {
        if (i == MaxDisplayItem) return;
        if (i >= 10 && i <= 50)
        {
            MaxDisplayItem = i;
            textLinesRectTransform.sizeDelta = new Vector2(textLinesRectTransform.sizeDelta.x, 13 * i);
            textLinesRectTransform.anchoredPosition = new Vector2(textLinesRectTransform.anchoredPosition.x, -13.83391f - (13 * (i - 1)) / 2f);

            textLinesViewRectTransform.sizeDelta = new Vector2(textLinesViewRectTransform.sizeDelta.x, 40 + 13 * i);
            textLinesViewRectTransform.anchoredPosition = new Vector2(textLinesViewRectTransform.anchoredPosition.x, -22.7f - (13 * (i - 1)) / 2f);
            panelCommandRectTransform.sizeDelta = new Vector2(panelCommandRectTransform.sizeDelta.x, 40 + 13 * i);
            panelCommandRectTransform.anchoredPosition = new Vector2(panelCommandRectTransform.anchoredPosition.x, -22.7f - (13 * (i - 1)) / 2f);
        }
    }
    private void SetCommandTip(string s)
    {
        textTips.text = "Debug Mode "+
            "\n<color=#66eeeeff>PageUP/PageDown/手指拖动</color> <color=#1177ffff>上移下移</color>" +
            "\n<color=#0077eeff>输入指令回车后执行指令</color>" +
            "\n点击         或按<color=#66eeeeff>F12</color> <color=#66aaff>关闭指令窗口</color>";
    }
    private void SetCommandShowFilter(string s)
    {
        if (commandShowFilter != s)
        {
            SetCommandTip(s);
            DisplayCommand();
        }
    }
    private void SetCommandShowPos(int pos)
    {
        if (pos < commandDisplays.Count - (MaxDisplayItem - 1))
        {
            commandShowPos = pos;
            DisplayCommand();
        }
        else pos = commandDisplays.Count - MaxDisplayItem;
    }
    private void CommandShowDown()
    {
        if (commandShowPos < commandDisplays.Count - (MaxDisplayItem - 1))
        {
            commandShowPos++;
            DisplayCommand();
        }
    }
    private void CommandShowUp()
    {
        if (commandShowPos > 0)
        {
            commandShowPos--;
            DisplayCommand();
        }

    }
    private void CommandShowAnyPos(int i)
    {

        if (i < commandDisplays.Count - (MaxDisplayItem - 1))
        {
            if (i > 0)
                commandShowPos = i;
            else commandShowPos = 0;
        }
        else commandShowPos = commandDisplays.Count - (MaxDisplayItem - 1);
        DisplayCommand();
    }
    private void CommandShowHome()
    {
        if (commandShowPos > 0)
        {
            commandShowPos = 0;
            DisplayCommand();
        }
    }
    private void CommandShowEnd()
    {
        if (commandShowPos < commandDisplays.Count - (MaxDisplayItem - 1))
        {
            commandShowPos = commandDisplays.Count - (MaxDisplayItem - 1);
        }
        DisplayCommand();
    }
    private void NextCommandShowFilter()
    {
        if (commandShowFilter == "All")
            SetCommandShowFilter("Warnings");
        if (commandShowFilter == "Warnings")
            SetCommandShowFilter("Errors");
        if (commandShowFilter == "Errors")
            SetCommandShowFilter("Messages");
        if (commandShowFilter == "Messages")
            SetCommandShowFilter("All");
    }
    private void DisplayCommand()
    {
        if (showedcmdstip) showedcmdstip = false;
        if (showedcmdtip) showedcmdtip = false;
        
        textLines.text = "";
        if (commandDisplays.Count > MaxDisplayItem)
        {
            int imax = commandShowPos;
            imax += MaxDisplayItem;
            bool flag = imax < commandDisplays.Count + 1;
            if (flag) imax -= 1;

            if (commandShowPos > 0)
            {
                textLines.text += "<color=#1177ffff>上面还有</color><color=#66eeeeff>" + (commandShowPos).ToString() + "</color> <color=#1177ffff>条消息</color>\n";
                imax -= 1;

                for (int i = commandShowPos; i < commandDisplays.Count && i < imax; i++)
                {
                    if (commandDisplays[i].Contains("\n"))
                    {
                        imax -= (System.Text.RegularExpressions.Regex.Matches(commandDisplays[i], @"\n").Count + 2);
                        flag = imax < commandDisplays.Count + 1;
                    }
                    textLines.text += commandDisplays[i] + "\n";
                }
                if (flag) textLines.text += "<color=#1177ffff>下面还有</color><color=#66eeeeff>" + (commandDisplays.Count - 1 - imax).ToString() + "</color> <color=#1177ffff>条消息</color>";
            }
            else
            {
                for (int i = commandShowPos; i < commandDisplays.Count && i < imax; i++)
                {
                    if (commandDisplays[i].Contains("\n"))
                    {
                        imax -= (System.Text.RegularExpressions.Regex.Matches(commandDisplays[i], @"\n").Count + 2);
                        flag = imax < commandDisplays.Count + 1;
                    }
                    textLines.text += commandDisplays[i] + "\n";
                }
                if (flag) textLines.text += "<color=#1177ffff>下面还有</color><color=#66eeeeff>" + (commandDisplays.Count - 1 - imax).ToString() + "</color> <color=#1177ffff>条消息</color>";
            }
        }
        else
        {
            foreach (string s in commandDisplays)
                textLines.text += s + "\n";
        }
    }
    private void DisplayCommandFff()
    {
        textLines.text = "";
        foreach (Dspl2 s in commandDisplays2)
            textLines.text += s.name + "\n";
    }

    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public void Log(string s)
    {
        if (GameSettings.Debug)
            OutPut(s);
    }
    /// <summary>
    /// 输出错误信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public void LogErr(string s)
    {
        //if (GameSettings.Debug)
            OutPut("<color=#FF7256>" + s + "</color>");
    }
    /// <summary>
    /// 输出警告信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public void LogWarn(string s)
    {
        //if (GameSettings.Debug)
            OutPut("<color=#FFB90F>" + s + "</color>");
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public void LogInfo(string s)
    {
        if (GameSettings.Debug)
            OutPut("<color=#1177ffff>" + s + "</color>");
    }

    /// <summary>
    /// 输出自定义信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public void OutPut(string s)
    {
        commandDisplays.Insert(commandDisplays.Count, s);
        if (commandShow)
        {
            if (commandShowPos == commandDisplays.Count - (MaxDisplayItem - 1))
            {
                commandShowPos++;
                DisplayCommand();
            }
        }
        else
        {
            if (commandShowed2Count >= MaxDisplayItem)
            {
                commandDisplays2.Remove(commandDisplays2[0]);
                commandShowed2Count--;
                commandDisplays2.Add(new Dspl2(s, 5));
                commandShowed2Count++;
                DisplayCommandFff();
            }
            else
            {
                textLines.text += s + "\n";
                commandDisplays2.Add(new Dspl2(s, 5));
                commandShowed2Count++;
            }
        }
    }
    /// <summary>
    /// 输出错误信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    /// <param name="sender">发送者名称</param>
    public void OutPutError(string s, string sender = "")
    {
        OutPut("<color=#FF7256>[" + sender + "] Error " + s + "</color>");
    }
    /// <summary>
    /// 输出警告信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    /// <param name="sender">发送者名称</param>
    public void OutPutWarn(string s, string sender = "")
    {
        OutPut("<color=#FFB90F>[" + sender + "] Warning " + s + "</color>");
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    /// <param name="sender">发送者名称</param>
    public void OutPutInfo(string s, string sender = "")
    {
        OutPut("<color=#1177ffff>[ " + sender + "] Info " + s + "</color>");
    }

    /// <summary>
    /// 指令文本框回车事件
    /// </summary>
    /// <param name="s"></param>
    public void OnCommandOk(string s)
    {
        if (s.StartsWith("/"))
        {
            if (RunCmd(s.Remove(0, 1)))
            {
                inputCommand.text = "";
                if (currentCommandResult != null && currentCommandResult != "")
                    OutPut(currentCommandResult);
            }
            else
            {
                if (currentCommandResult != null && currentCommandResult != "")
                    OutPut("<color=#FFB90F>" + currentCommandResult + "</color>");
                else OutPut("<color=#FFB90F>指令 " + s.Remove(0, 1) + " 执行错误</color>");
            }

        }
        else OutPut(s);
        CommandShowEnd();
    }
    /// <summary>
    /// 指令文本框改变事件
    /// </summary>
    /// <param name="s"></param>
    public void OnCommandChanged(string s)
    {
        if (s.StartsWith("/"))
        {
            if (s.Contains(" "))
            {
                if (inputCommand.caretPosition != 0)
                {
                    int mum = 0, curpos = inputCommand.caretPosition, lastspace = 0, lastspace2 = s.Length;
                    for (int i = 0; i < curpos; i++)
                        if (i > 0 && i < curpos - 1)
                            if (s[i] == ' ' && s[i + 1] != ' ' && s[i - 1] != ' ')
                            {
                                mum++;
                                lastspace = i;
                            }
                            else if (s[i] == ' ') lastspace = i;

                    if (lastspace != 0 && mum != 0)
                    {
                        if (s.EndsWith(" "))
                            MakeCmdsHlp4("", mum + 1);
                        else
                        {
                            for (int i = lastspace + 1; i < s.Length; i++)
                            {
                                if (s[i] == ' ')
                                {
                                    lastspace2 = i;
                                    break;
                                }
                            }
                            if (lastspace2 > lastspace)
                            {
                                string curenter = s.Substring(lastspace, lastspace2 - lastspace);
                                MakeCmdsHlp4(curenter.Trim(), mum);
                            }
                        }
                    }
                }
                showedcmdtip = true;
            }
            else MakeCmdsHlp1(s);          
        }
        else if (showedcmdtip) CommandShowEnd();
    }

    //
    //
    private CommandStg lasetEnterCmd = null;
    //指令提示功能
    private void MakeCmdsHlp1(string s)
    {
        if (s == "/") MakeCmdsHlp2();
        else
        {
            string ss = s.Remove(0, 1);
            MakeCmdsHlp3(ss);
        }
        showedcmdtip = true;
    }
    private void MakeCmdsHlp2()
    {
        textLines.text = "<color=#888888>";
        for (int i = 0; i < MaxDisplayItem - 1 && i < registeredCommands.Count; i++)
        {
            if (registeredCommands[i].tipColor != "")
                textLines.text += registeredCommands[i].ToString() + "  --  <color=" + registeredCommands[i].tipColor
                    + ">" + registeredCommands[i].tip + "</color>" + "\n";
            else textLines.text += registeredCommands[i].ToString() + "  --  " + registeredCommands[i].tip + "\n";
        }
        textLines.text += "</color>";
    }
    private void MakeCmdsHlp3(string s)
    {
        textLines.text = "<color=#888888>";
        for (int i = 0; i < registeredCommands.Count; i++)
        {
            string sz = registeredCommands[i].ToString();
            if (sz == s)
            {
                textLines.text = "";
                for (int i2 = 0; i2 < MaxDisplayItem - 2; i2++) textLines.text += "\n";
                textLines.text += "<color=#ffffff>" + s + "</color>";
                lasetEnterCmd = registeredCommands[i];
                return;
            }
            else if (sz.Contains(s)) 
                textLines.text += sz.Replace(s, "<color=#ffffff>" + s + "</color>") + "\n";
        }
        lasetEnterCmd = null;
        textLines.text += "</color>";
    }
    private void MakeCmdsHlp4(string s, int index)
    {
        if (index > 0 && lasetEnterCmd != null)
        {
            textLines.text = "<color=#888888>";
            if (lasetEnterCmd.pararmOverloads.Count > 0)
            {
                CommandOverload ov = null;
                for (int i = 0; i < lasetEnterCmd.pararmOverloads.Count; i++)
                {
                    if (lasetEnterCmd.pararmOverloads[i].pararmFormats.Count > index)
                    {
                        ov = lasetEnterCmd.pararmOverloads[i];
                        break;
                    }
                }
                if (ov == null) ov = lasetEnterCmd.pararmOverloads[0];
                if (ov != null)
                {
                    if (ov.pararmFormats.Count > index)
                    {
                        int useable_line = MaxDisplayItem - 1;
                        for (int i = 0; i < ov.pararmFormats.Count; i++)
                        {
                            CommandOverload.PararmFormat pararmFormat = ov.pararmFormats[i];
                            if (i == index)
                            {
                                useable_line = MaxDisplayItem - 1;
                                if (s != "" && pararmFormat.pararmChoices != null && pararmFormat.pararmChoices.Length > 0)
                                {
                                    textLines.text += "\n";
                                    for (int x = 0; x < pararmFormat.pararmChoices.Length && useable_line > 0; x++)
                                    {
                                        string sz = pararmFormat.pararmChoices[x];
                                        if (sz.Contains(s))
                                        {
                                            textLines.text += sz.Replace(s, "<color=#ffffff>" + s + "</color>") + "\n";
                                            useable_line--;
                                            if (useable_line == 1) textLines.text += "...\n";
                                        }
                                        else
                                        {
                                            textLines.text += sz + "\n";
                                            useable_line--;
                                            if (useable_line == 1) textLines.text += "...\n";
                                        }
                                    }
                                    if (useable_line > 2)
                                    {
                                        int m = useable_line - 2;
                                        for (int i2 = 0; i2 < m; i2++) textLines.text += "\n";
                                    }
                                }
                                else for (int i2 = 0; i2 < MaxDisplayItem - 2; i2++) textLines.text += "\n";
                                if (pararmFormat.pararmType != "")
                                    textLines.text += "  <color=#ffffff><" + pararmFormat.pararmType + ":" + pararmFormat.pararmName + "></color>";
                                else if (pararmFormat.pararmName != "") textLines.text += "  <color=#ffffff><" + pararmFormat.pararmName + "></color>";
                            }
                            else
                            {
                                if (pararmFormat.pararmType != "")
                                    textLines.text += "  <" + pararmFormat.pararmType + ":" + pararmFormat.pararmName + ">";
                                else if(pararmFormat.pararmName != "") textLines.text += "  <" + pararmFormat.pararmName + ">";
                            }
                        }
                        useable_line--;
                    }
                }
            }
            textLines.text += "</color>";
        }
    }

    //注册的指令存放结构
    private class CommandStg : IComparer<CommandStg>
    {
        public CommandReceiverHandler receiverHandler;
        public string entryCmd;
        public string tip = "";
        public string formatTip = "";
        public string color = "";
        public string tipColor = "";
        public int checkPararmsCount = -1;

        public void clear()
        {
            foreach (CommandOverload ov in pararmOverloads)
            {
                ov.pararmFormats.Clear();
                ov.pararmFormats = null;
            }
            pararmOverloads.Clear();
            pararmOverloads = null;
        }
        public List<CommandOverload> pararmOverloads = new List<CommandOverload>();

        public override string ToString()
        {
            return entryCmd;
        }

        public int Compare(CommandStg x, CommandStg y)
        {
            return string.Compare(x.entryCmd, y.entryCmd);
        }
    }
    private class CommandOverload
    {
        public List<PararmFormat> pararmFormats = new List<PararmFormat>();
        public struct PararmFormat
        {
            public PararmFormat(string pararm3i)
            {
                string[] pss = null;
                if (pararm3i.Contains(":"))
                {
                    pss = pararm3i.Split(':');
                    pararmType = pss[0];
                    pararmName = pss[1];
                    if (pss.Length>=3)
                    {
                        string[] pscs = null;
                        if (pss[2].Contains("/"))
                            pscs = pss[2].Split('/');
                        else pscs = new string[] { pss[2] };
                        pararmChoices = pscs;
                    }
                    else pararmChoices = null;
                }
                else
                {
                    pararmType = pararm3i;
                    pararmName = null;
                    pararmChoices = null;
                }
            }
            public PararmFormat(string pararmType, string pararmName, string[] pararmChoices)
            {
                this.pararmType = pararmType;
                this.pararmName = pararmName;
                this.pararmChoices = pararmChoices;
            }
            public string pararmType;
            public string pararmName;
            public string[] pararmChoices;
        }
    }

    //注册的指令
    private static List<CommandStg> registeredCommands = new List<CommandStg>();
    //指令返回结果
    private static string currentCommandResult = null;

    /// <summary>
    /// 指令接收者公用方法
    /// </summary>
    /// <param name="pararms">用户输入的指令参数</param>
    /// <returns>返回指令是否成功</returns>
    public delegate bool CommandReceiverHandler(string[] pararms);

    /// <summary>
    /// 注册指令
    /// </summary>
    /// <param name="entryCmd">指令名称</param>
    /// <param name="handler">接收器</param>
    /// <param name="tip">提示文字</param>
    /// <param name="formatTip">格式提示</param>
    /// <param name="oldhandler">旧接收器(修改接收器必须写旧接收器)</param>
    /// <returns>返回是否成功</returns>
    public static bool RegisterCommand(string entryCmd, CommandReceiverHandler handler, string tip = "",
        string formatTip = "", int checkPararmsCount = -1, CommandReceiverHandler oldhandler = null)
    {
        if (string.IsNullOrEmpty(entryCmd) || handler == null) return false;
        CommandStg oc;
        if (!FindCommand(entryCmd, out oc))
        {
            oc = new CommandStg();
            oc.entryCmd = entryCmd;
            oc.tip = tip;
            oc.receiverHandler = handler;
            oc.formatTip = formatTip;
            if (formatTip != "") ResolveCmdFormat(oc);
            oc.checkPararmsCount = checkPararmsCount;
            registeredCommands.Add(oc);
            return true;
        }
        else
        {
            if (oldhandler == oc.receiverHandler)
                oc.receiverHandler = handler;
            else return false; ;
            if (!string.IsNullOrEmpty(tip) && oc.tip != tip)
                oc.tip = tip;
            if (!string.IsNullOrEmpty(formatTip) && oc.formatTip != formatTip)
                oc.formatTip = formatTip;
            return true;
        }
    }
    //相当于 IsCommandRegistered
    private static bool FindCommand(string entryCmd, out CommandStg oc)
    {
        oc = null;
        if (string.IsNullOrEmpty(entryCmd)) return false;
        bool rs = false;
        foreach (CommandStg c in registeredCommands)
        {
            if (c.entryCmd == entryCmd)
            {
                oc = c;
                rs = true;
                break;
            }
        }
        return rs;
    }
    /// <summary>
    /// 获取指令是否已经注册
    /// </summary>
    /// <param name="entryCmd">指令名称</param>
    /// <returns>返回是否已经注册</returns>
    public static bool IsCommandRegistered(string entryCmd)
    {
        if (string.IsNullOrEmpty(entryCmd)) return false;
        foreach (CommandStg c in registeredCommands)
        {
            if (c.entryCmd == entryCmd)
                return true;
        }
        return false;
    }
    /// <summary>
    /// 取消注册指令
    /// </summary>
    /// <param name="entryCmd">指令名称</param>
    /// <returns>返回是否成功</returns>
    public static bool UnRegisterCommand(string entryCmd, CommandReceiverHandler oldhandler)
    {
        if (string.IsNullOrEmpty(entryCmd)) return false;
        CommandStg oc;
        if (FindCommand(entryCmd, out oc))
        {
            if (oldhandler == oc.receiverHandler)
            {
                oc.clear();
                registeredCommands.Remove(oc);
            }
            return true;
        }
        return false;
    }
    /// <summary>
    /// 设置当前指令返回输出信息
    /// </summary>
    /// <param name="rs">需要输出到控制台的信息</param>
    public static void SetCurrentCommandResult(string rs)
    {
        currentCommandResult = rs;
    }
    public void NoDebug()
    {
        if (canUseCommandTool)
        {
            canUseCommandTool = false;
            panelCommand.SetActive(false);
            DisplayInfoUi.gameObject.SetActive(false);
            textShowCmd.SetActive(false);
            textLines.text = "";
        }
    }
    public void CanDebug()
    {
        if (!canUseCommandTool)
        {
            canUseCommandTool = true;
            DisplayInfoUi.gameObject.SetActive(true);
            textShowCmd.SetActive(true);
        }
    }

    private static void ResolveCmdFormat(CommandStg oc)
    {
        string format = oc.formatTip;
        
        string[] parts = null;
        if (format.Contains("|"))
            parts = format.Split('|');
        else parts = new string[] { format };
        for (int i = 0; i < parts.Length; i++)
        {
            string part1 = parts[i];
            part1 = part1.Trim();
            if (part1.Contains(" "))
            {
                int isp = format.IndexOf(' ');
                if (part1.Substring(0, isp) == oc.entryCmd)
                    part1 = part1.Remove(0, isp);
            }
            StringSpliter sp = new StringSpliter(part1, ' ', true);
            if (sp.Success)
            {
                string[] sps = sp.Result;
                CommandOverload ov = new CommandOverload();
                for (int i2 = 0; i2 < sps.Length; i2++)
                    ov.pararmFormats.Add(new CommandOverload.PararmFormat(sps[i2]));
                oc.pararmOverloads.Add(ov);
            }
        }
    }
    private bool canUseCommandTool = false;
    //解析指令
    private bool RunCmd(string s)
    {
        bool rs = false;
        if (string.IsNullOrEmpty(s)) return false;
        StringSpliter sp = new StringSpliter(s, ' ', true);
        if (sp.Success)
        {
            List<string> cmds = new List<string>(sp.Result);
            if (cmds[0] != "")
            {
                CommandStg oc;
                if (FindCommand(cmds[0], out oc))
                {
                    cmds.Remove(cmds[0]);
                    if (oc.checkPararmsCount != -1)
                    {
                        if (oc.checkPararmsCount > cmds.Count)
                        {
                            cmds.Clear();
                            currentCommandResult = "指令 <color=#FFB90F>" + cmds[0] + "</color> 至少需要 " + oc.checkPararmsCount + " 个参数";
                            return false;
                        }
                    }
                    rs = oc.receiverHandler(cmds.ToArray());
                }
                else currentCommandResult = "指令 <color=#FFB90F>" + cmds[0] + "</color> 不存在";
            }
            cmds.Clear();
        }
        else
        {
            CommandStg oc;
            if (FindCommand(s, out oc))
            {
                rs = oc.receiverHandler(new string[0]);
            }
            else currentCommandResult = "指令 <color=#FFB90F>" + s + "</color> 不存在";
        }
        return rs;
    }

    //logMessage回调
    private void Application_logMessageReceived(string condition, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Error:
            case LogType.Exception:
            case LogType.Assert:
                LogErr(condition + " [StackTrace] : " + stackTrace);
                break;
            case LogType.Warning:
                LogWarn(condition);
                break;
            case LogType.Log:
                Log(condition);
                break;
        }

    }
    //显示关闭指令窗口按钮
    private void BtnShowCmd_OnClicked()
    {
        CommandShow = true;
    }
    private void BtnHideCmd_OnClicked()
    {
        CommandShow = false;
    }
    

    private void Start()
    {
        Application.logMessageReceived += Application_logMessageReceived;
        canUseCommandTool = GameSettings.Debug;
        DisplayInfoUi.gameObject.SetActive(canUseCommandTool);
        if (canUseCommandTool) DisplayInfoUi.SetPos(CommandShow);

        textLinesLayoutElement.minWidth = Screen.width - 20;

        instance = this;
        if (GameSettings.CmdLine > 15)
            SetCommandDisPalyItem(GameSettings.CmdLine);
        else SetCommandDisPalyItem(15);
        CommandShow = false;
        textLines.text = "";

        RegisterCommand("cls", ClearCommandReceiverHandler, "清空控制台");
        RegisterCommand("help", HelpCommandReceiverHandler, "查看指令帮助");
        RegisterCommand("output", OutPutCommandReceiverHandler, "输出");
        RegisterCommand("cmdline", SetLineCommandReceiverHandler, "设置控制台显示消息数量", "cmdline int:count", 1);
        RegisterCommand("test", TESTCommandReceiverHandler, "测试指令", "test enum:type:test1/enum2/enum3 string:x int:y");

        /*for (int i = 0; i < 50; i++)
            OutPut(i.ToString() + "   xxx");*/
        SetCommandTip("");
    }
    private void Update()
    {
        if (canUseCommandTool)
        {
            /*
             if(sx2<400)
             {
                 sx2++;
                 if ((sx2%10)==0)
                 {
                     if (sx2 < 100)
                     {
                         OutPut("test:"+(sx2/60));
                     }
                     else if (sx2 < 200)
                     {
                         OutPutError("test2:" + (sx2 / 60));
                     }
                     else if (sx2 < 300)
                     {
                         OutPutWarn("test3:" + (sx2 / 60));
                     }
                     else
                     {
                         OutPutInfo("test4:" + (sx2 / 60));
                     }
                 }
             }
             */
            if (Input.GetKeyDown(KeyCode.F12) && !isF1ButtonDown)
            {
                isF1ButtonDown = true;
                CommandShow = !commandShow;
            }
            else if (Input.GetKeyUp(KeyCode.F12) && isF1ButtonDown) isF1ButtonDown = false;
            else if (commandShow)
            {
                if (Input.GetKeyDown(KeyCode.PageDown) && !isPageDownButtonDown) isPageDownButtonDown = true;
                else if (Input.GetKeyUp(KeyCode.PageDown) && isPageDownButtonDown)
                {
                    isPageDownButtonDown = false;
                    sxs = 30;
                }

                else if (Input.GetKeyDown(KeyCode.PageUp) && !isPageUpButtonDown) isPageUpButtonDown = true;
                else if (Input.GetKeyUp(KeyCode.PageUp) && isPageUpButtonDown)
                {
                    isPageUpButtonDown = false;
                    sxs = 30;
                }

                else if (Input.GetKeyDown(KeyCode.Home) && !isHoneButtonDown)
                {
                    isHoneButtonDown = true;
                    CommandShowHome();
                }
                else if (Input.GetKeyUp(KeyCode.Home) && isHoneButtonDown) isHoneButtonDown = false;

                else if (Input.GetKeyDown(KeyCode.End) && !isEndButtonDown)
                {
                    isEndButtonDown = true;
                    CommandShowEnd();
                }
                else if (Input.GetKeyUp(KeyCode.End) && isEndButtonDown) isEndButtonDown = false;

                else if (!isSCButtonDown && ((Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.LeftShift)) || Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.RightShift)))
                {
                    isSCButtonDown = true;
                    NextCommandShowFilter();
                }
                else if (isSCButtonDown && ((Input.GetKeyUp(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.LeftShift)) || Input.GetKeyUp(KeyCode.LeftControl) && Input.GetKeyUp(KeyCode.RightShift))) isSCButtonDown = false;

                else if (dragCommand.isDrag)
                {
                    if (dragCommand.isDraged)
                    {
                        float y = dragCommand.DragOffist.y;
                        if (y != 0)
                        {
                            float ya = Mathf.Abs(y);
                            if (ya > 25) sxs = 10;
                            else if (ya > 20) sxs = 20;
                            else if (ya > 15) sxs = 30;
                            else if (ya > 10) sxs = 40;
                            else if (ya > 5) sxs = 50;
                            else sxs = 60;
                            scdirect = y < 0;
                            scmouse = true;
                        }
                        else scmouse = false;
                    }
                    else scmouse = false;
                }

                if (sx2 < sxs) sx2++;
                else
                {
                    sx2 = 0;
                    if (isPageDownButtonDown)
                    {
                        CommandShowDown();
                        if (sxs > 5)
                            sxs -= 5;
                    }
                    else if (isPageUpButtonDown)
                    {
                        CommandShowUp();
                        if (sxs > 5)
                            sxs -= 5;
                    }
                    else if (scmouse)
                    {
                        if (scdirect) CommandShowAnyPos(commandShowPos - 1);
                        else CommandShowAnyPos(commandShowPos + 1);
                        scmouse = false;
                    }
                }
            }
            else
            {
                if (sx < 60) sx++;
                else
                {
                    sx = 0;
                    if (commandShowed2Count > 0)
                    {
                        bool b = false;
                        for (int i = commandDisplays2.Count - 1; i >= 0; i--)
                        {
                            if (commandDisplays2[i].ccc > 0) commandDisplays2[i].ccc--;
                            else
                            {
                                commandDisplays2.Remove(commandDisplays2[i]);
                                commandShowed2Count--;
                                b = true;
                            }
                        }
                        if (b) DisplayCommandFff();
                    }
                }
            }
        }
    }
    private void OnDestroy()
    {
        Application.logMessageReceived -= Application_logMessageReceived;
        UnRegisterCommand("cls", ClearCommandReceiverHandler);
        UnRegisterCommand("help", HelpCommandReceiverHandler);
        UnRegisterCommand("output", OutPutCommandReceiverHandler);
        UnRegisterCommand("cmdline", SetLineCommandReceiverHandler);
        UnRegisterCommand("test", TESTCommandReceiverHandler);
    }

    /// <summary>
    /// 退出游戏之前的清理。【不可调用】
    /// </summary>
    public void ExitGameClear()
    {
        //if (GlobalMediator.GameExiting)
        //{
            commandDisplays2.Clear();
            commandDisplays.Clear();
            registeredCommands.Clear();
        //}
    }

    //一些指令接收器
    private bool OutPutCommandReceiverHandler(string[] pararms)
    {
        if (pararms.Length >= 1)
            OutPut(pararms[0]);
        return true;
    }
    private bool HelpCommandReceiverHandler(string[] pararms)
    {
        OutPut("指令帮助 <size=9>共 " + registeredCommands.Count + " 条指令</size>");
        string s = "";
        foreach (CommandStg c in registeredCommands)
        {
            if (c.color != "") s = " <color=" + c.color + ">" + c.entryCmd + "</color>";
            else s = c.entryCmd;
            if (c.tipColor != "") OutPut(s + (string.IsNullOrEmpty(c.tip) ? "" : " <color=" + c.tipColor + ">" + c.tip + "</color>"));
            else OutPut(s + (string.IsNullOrEmpty(c.tip) ? "" : " <color=#888888>" + c.tip + "</color>"));
        }
        return true;
    }
    private bool ClearCommandReceiverHandler(string[] pararms)
    {
        commandDisplays2.Clear();
        commandDisplays.Clear();
        CommandShowHome();
        return true;
    }
    private bool SetLineCommandReceiverHandler(string[] pararms)
    {
        int i = 0;
        if (int.TryParse(pararms[0], out i))
        {
            if (i >= 10 && i <= 50)
            {
                SetCommandDisPalyItem(i);
                return true;
            }
            else SetCurrentCommandResult("输入的数值 " + pararms[0] + " 必须在（10~50之间）");
        }
        else SetCurrentCommandResult("输入参数 " + pararms[0] + " 不是有效的数字");
        return false;
    }
    private bool TESTCommandReceiverHandler(string[] pararms)
    {
        currentCommandResult = "这只是一个测试指令，没有功能";
        return true;
    }
}
