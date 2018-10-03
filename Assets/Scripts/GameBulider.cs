using Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class GameBulider : MonoBehaviour, IGameBasePart
{
    public static GameBulider GameBuliderStatic = null;

    public GameObject perfabCube;
    public GameObject perfabEmepty;

    public GameObject uiMgr;
    public GameObject uiHost;
    private GameObject levelHost;

    private LuaEngine luaEngine;

    /// <summary>
    /// 全局 Lua 虚拟机
    /// </summary>
    public LuaInterface.LuaState GlobalLuaState { get { return LuaEngine.globalLuaState; } }
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
        GameBuliderStatic = this;

        InitGlobalUI();
        InitGlobal();
        InitLoader();
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
        GameMgr.Log("InitGlobal");

        GameObject mainmgr = Instantiate(perfabEmepty);
        mainmgr.name = "GameMgr";
        GameMgr = mainmgr.AddComponent<GameMgr>();
        GameMgr.GameBulider = this;
        luaEngine = mainmgr.AddComponent<LuaEngine>();

        GameObject mainloader = Instantiate(perfabEmepty);
        mainloader.name = "GameModLoader";
        GameModLoader = mainmgr.AddComponent<GameModLoader>();
        GameModLoader.GameBulider = this;

        levelHost = Instantiate(perfabEmepty);
        levelHost.name = "GameLevelObjects";


    }
    private void InitLoader()
    {
        GameMgr.Log("InitLoader");

        StartCoroutine(InitGame());
    }

    private IEnumerator InitGame()
    {
        //加载Gameinit mod
        string gameinit_path = GamePathManager.GetResRealPath("core", "gameinit.assetbundle");
        yield return StartCoroutine(GameModLoader.LoadMod(gameinit_path, false, ""));

        //运行Gameinit mod中的gameinit.lua进行加载程序
        GameModPackage gameinitModPackage = null;
        if (GameModLoader.FindLadedMod(gameinit_path, out gameinitModPackage))
        {
            TextAsset lua = GameModPackageAssetMgr.GetPackageTextAsset(gameinitModPackage, "GameInit.lua");
            if (lua != null)
            {
                GlobalLuaState.LuaLoadBuffer(lua.bytes, lua.bytes.Length, "GameInit");//gameinit.lua装入运行
            }
        }
        else
        {
            UIManager.ShowDialog(0, "游戏初始化失败", "GameInit 加载失败\n路径：" + gameinit_path, "退出游戏", "");
            yield return new WaitUntil(UIManager.IsDialogClosed);
            ExitGame();//加载失败退出
            yield break;
        }
    }

    //==============================

    /// <summary>
    /// 唯一退出游戏方法。调用此函数游戏方法。
    /// </summary>
    public void ExitGame()
    {
        if (GameMgr.GameExiting)
        {
            ExitGameClear();
            GameMgr.ExitGameClear();
            GameModLoader.ExitGameClear();
            luaEngine.ExitGameClear();

#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif

        }
    }

    public void ExitGameClear()
    {
        
    }
}

