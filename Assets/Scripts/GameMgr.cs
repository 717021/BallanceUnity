using Caller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour, IGameBasePart
{
    private GameBulider _GameBulider = null;
    public GameBulider GameBulider
    {
        get
        {
            return _GameBulider;
        }
        set
        {
            if (_GameBulider == null)
                _GameBulider = value;
        }
    }
    private static GameMgr _GameMgrInstance = null;
    public static GameMgr GameMgrInstance
    {
        get
        {
            return _GameMgrInstance;
        }
        set
        {
            if (_GameMgrInstance == null)
                _GameMgrInstance = value;
        }
    }



    //==============================

    void Start()
    {
        _GameMgrInstance = this;
        GameCommandManager.RegisterCommand("exit", Exit_CommandReceiverHandler, "退出游戏");
    }

    //==CMD============================

    bool SetSettings_CommandReceiverHandler(string[] pararms)
    {
        GameCommandManager.SetCurrentCommandResult("游戏正在退出。");
        return false;
    }
    bool Exit_CommandReceiverHandler(string[] pararms)
    {
        if (!GameExiting)
        {
            ExitGame();
            return true;
        }
        else GameCommandManager.SetCurrentCommandResult("游戏正在退出。");
        return false;
    }
    //==LOGS============================


    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public static void Log(string s)
    {
        GameBulider.GameBuliderStatic.CommandManager.Log(s);
    }
    /// <summary>
    /// 输出错误信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public static void LogErr(string s)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogErr(s);
    }
    /// <summary>
    /// 输出警告信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public static void LogWarn(string s)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogWarn(s);
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">信息</param>
    public static void LogInfo(string s)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogInfo(s);
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    public static void Log(string s, object agr1)
    {
        GameBulider.GameBuliderStatic.CommandManager.Log(string.Format(s, agr1));
    }
    /// <summary>
    /// 输出错误信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    public static void LogErr(string s, object agr1)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogErr(string.Format(s, agr1));
    }
    /// <summary>
    /// 输出警告信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    public static void LogWarn(string s, object agr1)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogWarn(string.Format(s, agr1));
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    public static void LogInfo(string s, object agr1)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogInfo(string.Format(s, agr1));
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    /// <param name="agr2">字符串格式化参数2</param>
    public static void Log(string s, object agr1, object agr2)
    {
        GameBulider.GameBuliderStatic.CommandManager.Log(string.Format(s, agr1, agr2));
    }
    /// <summary>
    /// 输出错误信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    /// <param name="agr2">字符串格式化参数2</param>
    public static void LogErr(string s, object agr1, object agr2)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogErr(string.Format(s, agr1, agr2));
    }
    /// <summary>
    /// 输出警告信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    /// <param name="agr2">字符串格式化参数2</param>
    public static void LogWarn(string s, object agr1, object agr2)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogWarn(string.Format(s, agr1, agr2));
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="agr1">字符串格式化参数1</param>
    /// <param name="agr2">字符串格式化参数2</param>
    public static void LogInfo(string s, object agr1, object agr2)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogInfo(string.Format(s, agr1, agr2));
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="args">字符串格式化参数</param>
    public static void Log(string s, params object[] args)
    {
        GameBulider.GameBuliderStatic.CommandManager.Log(string.Format(s, args));
    }
    /// <summary>
    /// 输出错误信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="args">字符串格式化参数</param>
    public static void LogErr(string s, params object[] args)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogErr(string.Format(s, args));
    }
    /// <summary>
    /// 输出警告信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="args">字符串格式化参数</param>
    public static void LogWarn(string s, params object[] args)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogWarn(string.Format(s, args));
    }
    /// <summary>
    /// 输出信息到控制台
    /// </summary>
    /// <param name="s">格式化字符串</param>
    /// <param name="args">字符串格式化参数</param>
    public static void LogInfo(string s, params object[] args)
    {
        GameBulider.GameBuliderStatic.CommandManager.LogInfo(string.Format(s, args));
    }


    //==SOME=PARARMS===========================

    /// <summary>
    /// 是否正在退出
    /// </summary>
    public bool GameExiting
    {
        get;private set;
    }

    //==FUNCTIONS============================

    #region Action

    /// <summary>
    /// 注册 Action。
    /// </summary>
    /// <param name="act">需要注册的 Action 。</param>
    /// <param name="name">Action 名字</param>
    /// <returns>返回一个Action处理器，可以用来接受Action。</returns>
    public static ActionHandler RegisterAction(Action act, string name = "")
    {
        if (act != null)
        {
            ActionHandler h = act.GetStaticHandler();
            if (h == null)
            {
                h = new ActionHandler(name);
                act.Register(h);
                return h;
            }
        }
        return null;
    }

    /// <summary>
    /// 调用 Action。
    /// </summary>
    /// <param name="act">需要调用的Action。</param>
    /// <returns>返回调用是否成功。</returns>
    public static bool CallAction(Action act)
    {
        if (act != null)
        {
            ActionHandler h = act.GetStaticHandler();
            if (h != null)
            {
                Dictionary<string, ActionHandler.ActionHandlerDelegate>.ValueCollection valueCol = h.handlers.Values;
                foreach (ActionHandler.ActionHandlerDelegate d in valueCol)
                    if (d != null) d.Invoke(act.pararms);
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 调用Action到指定接收者。
    /// </summary>
    /// <param name="act">需要调用的Action。</param>
    /// <param name="target">Action的接收者。</param>
    /// <returns>Action的接收者返回数据。</returns>
    public static object CallAction(Action act, string target)
    {
        if (act != null)
        {
            ActionHandler h = act.GetStaticHandler();
            if (h != null)
            {
                if (h.handlers.ContainsKey(target))
                {
                    ActionHandler.ActionHandlerDelegate d = h.handlers[target];
                    if (d == null) return h.handlers.Remove(target);
                    else d.Invoke(act.pararms);
                }
            }
        }
        return null;
    }

    #endregion

    #region Event

    //事件侦听器储存Dictionary
    private static Dictionary<string, List<EventLinster>> events = new Dictionary<string, List<EventLinster>>();

    /// <summary>
    /// 注册事件侦听器 注意：事件使用完毕（比如object已经释放，请使用UnRegisterEventLinster取消注册事件侦听器，否则会发生错误）
    /// </summary>
    /// <param name="eventLinster">要注册的事件侦听器</param>
    /// <returns>返回要注册的事件侦听器</returns>
    public static EventLinster RegisterEventLinster(EventLinster eventLinster)
    {
        string evtName = eventLinster.eventName;
        if (evtName == "" || eventLinster == null) return null;
        List<EventLinster> list = null;
        if (!events.ContainsKey(evtName))
        {
            list = new List<EventLinster>();
            events.Add(evtName, list);
        }
        else list = events[evtName];
        if (!list.Contains(eventLinster))
            list.Add(eventLinster);
        return eventLinster;
    }
    /// <summary>
    /// 取消注册事件侦听器
    /// </summary>
    /// <param name="eventLinster">要取消注册的事件侦听器</param>
    /// <returns>返回是否成功</returns>
    public static bool UnRegisterEventLinster(EventLinster eventLinster)
    {
        string evtName = eventLinster.eventName;
        if (evtName == "" || eventLinster == null) return false;
        List<EventLinster> list = null;
        if (events.ContainsKey(evtName))
        {
            list = events[evtName];
            if (list.Contains(eventLinster))
            {
                list.Remove(eventLinster);
                return false;
            }
        }
        return false;
    }
    /// <summary>
    /// 分发事件
    /// </summary>
    /// <param name="evtName">事件名称</param>
    /// <param name="sender">发送者</param>
    /// <param name="par">附加参数</param>
    /// <returns>返回是否成功</returns>
    public static bool DispatchEvent(string evtName, object sender, params object[] par)
    {
        if (string.IsNullOrEmpty(evtName)) return false;
        List<EventLinster> list = null;
        if (events.ContainsKey(evtName))
        {
            list = events[evtName];
            foreach (EventLinster l in list)
            {
                l.OnEvent(sender, par);
            }
            return true;
        }
        return false;
    }
    /// <summary>
    /// 发送事件给指定接收者
    /// </summary>
    /// <param name="evtName">事件名称</param>
    /// <param name="targetName">指定接收者</param>
    /// <param name="sender">发送者</param>
    /// <param name="par">附加参数</param>
    /// <returns>返回是否成功</returns>
    public static bool DispatchEventToTarget(string evtName, string targetName, object sender, params object[] par)
    {
        if (string.IsNullOrEmpty(evtName)) return false;
        if (string.IsNullOrEmpty(targetName)) return DispatchEvent(evtName, sender, par);
        List<EventLinster> list = null;
        if (events.ContainsKey(evtName))
        {
            list = events[evtName];
            foreach (EventLinster l in list)
            {
                if (l.receiverName == targetName)
                    l.OnEvent(sender, par);
            }
            return true;
        }
        return false;
    }
    #endregion

    /// <summary>
    /// 退出游戏
    /// </summary>
    public void ExitGame()
    {
        if(!GameExiting)
        {
            GameExiting = true;
            GameBulider.ExitGame();
        }
    }

    public void ExitGameClear()
    {
        
    }


}
