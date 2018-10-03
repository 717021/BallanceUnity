using Helper;
using LuaInterface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

/*
 * 游戏主加载器、建造器
 * 负责对整个游戏进行初始化
 * 
 */

/// <summary>
/// 游戏主建造器
/// </summary>
public class GameBulider : MonoBehaviour, IGameBasePart
{
    public GameObject perfabCube;
    public GameObject perfabEmepty;

    public GameObject uiMgr;
    public GameObject uiHost;
    private GameObject levelHost;

    private LuaEngine luaEngine;

    /// <summary>
    /// 静态实例
    /// </summary>
    public static GameBulider GameBuliderInstance { get; private set; }
    /// <summary>
    /// 全局 Lua 虚拟机
    /// </summary>
    public LuaState GlobalLuaState { get { return LuaEngine.globalLuaState; } }
    public GameObject LevelHost { get { return levelHost; } }
    /// <summary>
    /// 指令管理器实例
    /// </summary>
    public GameCommandManager CommandManager { get; private set; }
    /// <summary>
    /// 界面管理器实例
    /// </summary>
    public GameUIMgr UIManager { get; private set; }
    /// <summary>
    /// 游戏管理器实例
    /// </summary>
    public GameMgr GameMgr
    {
        get;private set;
    }
    /// <summary>
    /// MOD 加载器实例
    /// </summary>
    public GameModLoader GameModLoader
    {
        get; private set;
    }

    GameBulider IGameBasePart.GameBulider
    {
        get
        {
            return this;
        }
        set
        {
            throw new NotImplementedException();
        }
    }

    //==============================

    //全局加载入口
    private void Start()
    {
        GameBuliderInstance = this;

        InitGlobalUI();
        InitGlobal();
    }

    private void InitGlobalUI()
    {
        GameObject commandMgrr = GameObject.Find("GameCommandMgr");
        CommandManager = commandMgrr.GetComponent<GameCommandManager>();
        CommandManager.GameBulider = this;
        UIManager = GameObject.Find("GameUIMgr").GetComponent<GameUIMgr>();
        UIManager.GameBulider = this;
    }
    private void InitGlobal()
    {
        GameMgr.Log("Initializing Game...");

        GameObject mainmgr = Instantiate(perfabEmepty);
        mainmgr.name = "GameMgr";
        GameMgr = mainmgr.AddComponent<GameMgr>();
        GameMgr.GameBulider = this;
        luaEngine = mainmgr.AddComponent<LuaEngine>();
        luaEngine.InitThis();

        GameObject mainloader = Instantiate(perfabEmepty);
        mainloader.name = "GameModLoader";
        GameModLoader = mainmgr.AddComponent<GameModLoader>();
        GameModLoader.GameBulider = this;

        levelHost = Instantiate(perfabEmepty);
        levelHost.name = "GameLevelObjects";

        StartCoroutine(InitGame());
    }

    private IEnumerator InitGame()
    {
        string errmsg = "";
        //加载Gameinit mod
        string gameinit_path = GamePathManager.GetResRealPath("core", "gameinit.assetbundle");
        yield return StartCoroutine(GameModLoader.LoadMod(gameinit_path, false, ""));

        //运行Gameinit mod中的gameinit.lua进行加载程序
        GameModPackage gameinitModPackage = null;
        if (!GameModLoader.FindLadedMod(gameinit_path, out gameinitModPackage))
        { GameMgr.LogErr("Init {0} Failed.", gameinit_path); errmsg = "加载主元件 " + gameinit_path + " 失败"; goto ERRANDEXIT; }

        TextAsset lua = GameModPackageAssetMgr.GetPackageTextAsset(gameinitModPackage, "GameInit.lua");
        if (lua == null) { GameMgr.LogErr("Init gameinit.lua failed."); errmsg = "无效的主元件 GameInit"; goto ERRANDEXIT; }

        //gameinit.lua装入运行
        //GlobalLuaState.LuaLoadBuffer(lua.bytes, lua.bytes.Length, "GameInit");
        GlobalLuaState.DoString(lua.text, "GameInit");
        GlobalLuaState.CheckTop();

        LuaFunction gameinit_entery = GlobalLuaState.GetFunction("GameInit_Entry");
        LuaFunction gameinit_geterr = GlobalLuaState.GetFunction("GameInit_GetLoaderError");

        if(gameinit_entery == null || gameinit_geterr == null)
        {
            GameMgr.LogErr("gameinit.lua have been damaged.");
            errmsg = "无效的主元件 GameInit"; goto ERRANDEXIT;
        }

        try
        {
            //调用lua文件中的人口
            gameinit_entery.Call();
            if (!gameinit_entery.CheckBoolean()) //获取返回值
            {
                gameinit_entery.Call();//获取错误返回值
                errmsg = new String(gameinit_entery.CheckCharBuffer());
                goto ERRANDEXIT;
            }
        }
        catch (LuaException e)
        {
            errmsg = "执行 gameinit.lua 失败\n" + e.Message;
            GameMgr.LogErr(e.ToString());
            goto ERRANDEXIT;
        }

        goto CONLOAD;
        ERRANDEXIT:
        UIManager.ShowDialog(0, "游戏初始化失败", "请尝试重新安装游戏\n错误信息：" + errmsg, "退出游戏", "");
        yield return new WaitUntil(UIManager.IsDialogClosed);
        ExitGame();//加载失败退出
        CONLOAD:
        yield break;
    }

    //==============================

    internal void ExitGame()
    {
        if (GameMgr.GameExiting)
        {
            ExitGameClear();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    public void ExitGameClear()
    {
        if (GameMgr.GameExiting)
        {
            GameMgr.ExitGameClear();
            GameModLoader.ExitGameClear();
            luaEngine.ExitGameClear();
        }
    }
}

