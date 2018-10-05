using Ballance2.Management;
using Ballance2.Utils;
using LuaInterface;
using System;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

/*
 * 游戏主加载器、建造器
 * 负责对整个游戏进行初始化
 * 
 */

namespace Ballance2
{
    /// <summary>
    /// 游戏主建造器
    /// </summary>
    public class GameBulider : MonoBehaviour, IGameBasePart
    {
        public GameBulider()
        {
            instance = this;
        }

        //==============================

        //Static Perfabs

        public GameObject perfabWindow;
        public GameObject perfabCube;
        public GameObject perfabEmepty;

        //==============================

        public RectTransform uiHostRectTransform;
        public GameUIMgr uiMgr;
        public GameObject uiHost;
        private GameObject levelHost;

        //==============================

        private LuaEngine luaEngine;
        private static GameBulider instance = null;

        //==============================

        /// <summary>
        /// 获取静态实例
        /// </summary>
        public static GameBulider GetInstance() { return instance; }
        /// <summary>
        /// 全局 Lua 虚拟机
        /// </summary>
        public LuaState GlobalLuaState { get { return LuaEngine.globalLuaState; } }
        /// <summary>
        /// 全局 Lua 虚拟机（无looper）
        /// </summary>
        public LuaState GlobalLuaStateForRunner { get { return LuaEngine.globalLuaStateNew; } }
        public GameObject LevelHost { get { return levelHost; } }

        //==============================

        //Game Services

        /// <summary>
        /// 获取游戏主部件(对lua的接口)
        /// </summary>
        /// <typeparam name="T">请参照源码来确定获取的部件类型（参照 <seealso cref="GameServices"/> 源码）</typeparam>
        /// <param name="service">要获取的部件类型</param>
        /// <returns>返回指定的游戏主部件，如果没有找到则返回null</returns>
        public static T GetGameService<T>(GameServices service) where T : MonoBehaviour
        {
            switch (service)
            {
                case GameServices.GameMgr: return instance.GameMgr as T;
                case GameServices.GameModLoader: return instance.GameModLoader as T;
                case GameServices.GameCommandManager: return instance.CommandManager as T;
                case GameServices.GameUIManager: return instance.UIManager as T;
                case GameServices.GameCameraManager: return instance.GameCameraManager as T;
                case GameServices.GameWindowMgr: return instance.WindowMgr as T;
            }
            return null;
        }

        /// <summary>
        /// 窗口管理器实例
        /// </summary>
        public GameWindowMgr WindowMgr { get; private set; }
        /// <summary>
        /// 指令管理器实例
        /// </summary>
        public GameCommandManager CommandManager { get; private set; }
        /// <summary>
        /// 界面管理器实例
        /// </summary>
        public GameUIMgr UIManager { get { return uiMgr; } }
        /// <summary>
        /// 游戏管理器实例
        /// </summary>
        public GameMgr GameMgr { get; private set; }
        /// <summary>
        /// MOD 加载器实例
        /// </summary>
        public GameModLoader GameModLoader { get; private set; }
        /// <summary>
        /// 摄像机管理器
        /// </summary>
        public GameCameraManager GameCameraManager { get; private set; }

        //==============================

        GameBulider IGameBasePart.GameBulider
        {
            get { return this; }
            set { throw new NotImplementedException(); }
        }

        //==============================

        //全局加载入口
        private void Start()
        {
            InitGlobalUI();
            InitGlobal();
        }

        private void InitGlobalUI()
        {
            GameObject commandMgrr = GameObject.Find("GameCommandMgr");
            CommandManager = commandMgrr.GetComponent<GameCommandManager>();
            CommandManager.GameBulider = this;
            uiMgr.GameBulider = this;
            WindowMgr = uiMgr.gameObject.GetComponent<GameWindowMgr>();
            WindowMgr.GameBulider = this;
            WindowMgr.uiHost = uiHost;

            uiMgr.SetFadeBlack();
        }
        private void InitGlobal()
        {
            GameMgr.Log("Initializing Game...");

            //主管理器
            GameObject mainmgr = Instantiate(perfabEmepty);
            mainmgr.name = "GameMgr";
            GameMgr = mainmgr.AddComponent<GameMgr>();
            GameMgr.GameBulider = this;
            GameCameraManager = mainmgr.AddComponent<GameCameraManager>();
            GameCameraManager.GameBulider = this;

            luaEngine = mainmgr.AddComponent<LuaEngine>();
            luaEngine.InitLua();

            //主加载器
            GameObject mainloader = Instantiate(perfabEmepty);
            mainloader.name = "GameModLoader";
            GameModLoader = mainmgr.AddComponent<GameModLoader>();
            GameModLoader.GameBulider = this;

            //主关卡承载
            levelHost = Instantiate(perfabEmepty);
            levelHost.name = "GameLevelObjects";

            //启动lua初始化例程
            StartCoroutine(InitGame());
        }

        //初始化
        private IEnumerator InitGame()
        {
            GameObject intro = null;
            string errmsg = "";
            //加载Gameinit元件
            string gameinit_path = GamePathManager.GetResRealPath("core", "gameinit.assetbundle");
            //等待加载完成
            yield return StartCoroutine(GameModLoader.LoadMod(gameinit_path, GameModPackage.GameModType.Resource));

            //加载Gameinit mod
            GameModPackage gameinitModPackage = null;
            if (!GameModLoader.FindLadedMod(gameinit_path, out gameinitModPackage))
            { GameMgr.LogErr("Init {0} Failed.", gameinit_path); errmsg = "加载主元件 " + gameinit_path + " 失败"; goto ERRANDEXIT; }

            #region Intro

            //Intro界面
            bool updateProgress = false;
            RectTransform IntroProgreesBgRectTransform = null;
            RectTransform IntroProgreesRectTransform = null;
            //加载Intro界面
            intro = GameModPackageAssetMgr.InitObjWithPerfab(GameModPackageAssetMgr.GetPackagePerfab(gameinitModPackage, "GameIntro"), "GameUIIntro", uiHostRectTransform);
            if (intro != null)
            {
                IntroProgreesBgRectTransform = intro.transform.Find("IntroProgreesBg").gameObject.GetComponent<RectTransform>();
                IntroProgreesRectTransform = intro.transform.Find("IntroProgrees").gameObject.GetComponent<RectTransform>();

                if (IntroProgreesBgRectTransform && IntroProgreesRectTransform)
                    updateProgress = true;
            }

            #endregion

            //================================================

            #region Load and check

            TextAsset table = GameModPackageAssetMgr.GetPackageTextAsset(gameinitModPackage, "GameInit.table");
            TextAsset validTable = GameModPackageAssetMgr.GetPackageTextAsset(gameinitModPackage, "GameValidate.table");

            if (table == null) { GameMgr.LogErr("Init gameinit.table failed."); errmsg = "无效的主元件加载表 GameInit"; goto ERRANDEXIT; }
            if (validTable == null) { GameMgr.LogErr("Init gamevalidate.table failed."); errmsg = "无效的主元件验证表 GameValidate"; goto ERRANDEXIT; }

            //加载Gameinit初始化表中指定的默认包
            //================================================

            StringSpliter sp = new StringSpliter(table.text, '\n', '\r');
            if (sp.Success)
            {
                int failedCount = 0;
                for (int i = 0; i < sp.Count; i++)
                {
                    //获取包路径并加载
                    string pack_path = GamePathManager.GetResRealPath("core", sp.Result[i]);

                    GameMgr.Log("Loading package : {0}", pack_path);

                    yield return StartCoroutine(GameModLoader.LoadMod(pack_path));

                    //检测是否加载
                    if (!GameModLoader.IsModLaded(pack_path))
                    {
                        GameMgr.LogErr("Load package {0} failed!", pack_path);
                        failedCount++;
                    }

                    //更新进度条
                    if (updateProgress)
                    {
                        float x = IntroProgreesBgRectTransform.sizeDelta.x * ((float)i / sp.Count);
                        IntroProgreesRectTransform.sizeDelta = new Vector2(x, IntroProgreesRectTransform.sizeDelta.y);
                        IntroProgreesRectTransform.anchoredPosition = new Vector2(-((IntroProgreesBgRectTransform.sizeDelta.x - x) / 2), IntroProgreesRectTransform.anchoredPosition.y);
                    }
                }
                if (failedCount > 0) GameMgr.LogWarn("Load package failed :{0}/{1}", failedCount, sp.Count);
            }
            sp = null;

            //加载Gameinit初始化验证表并检测是否加载完全
            //================================================

            sp = new StringSpliter(validTable.text, '\n', '\r');
            if (sp.Success)
            {
                string requiredPacks = "";
                int failedCount = 0;
                foreach (string s in sp.Result)
                {
                    //获取包路径并加载
                    string pack_path = GamePathManager.GetResRealPath("core", s);

                    if (pack_path.StartsWith("Required:"))
                    {
                        pack_path = pack_path.Remove(0, 9);
                        if (!GameModLoader.IsModLaded(pack_path))
                            requiredPacks += pack_path + "\n";
                    }
                    else if (pack_path.StartsWith("Optional:"))
                    {
                        pack_path = pack_path.Remove(0, 9);
                        if (!GameModLoader.IsModLaded(pack_path)) failedCount++;
                    }
                }
                if (requiredPacks != "")
                {
                    errmsg = "一个或多个必要的依赖包无法加载：\n\n<color=#FF7256>" + requiredPacks + "</color>\n请尝试重新安装游戏";
                    goto ERRANDEXIT;
                }
                if (failedCount > 0)
                {
                    UIManager.ShowDialog(0, "游戏初始化出现异常", "游戏某些部件无法正常加载，" +
                        "游戏可能以及被破坏，请尝试重新安装游戏\n您可以尝试继续运行游戏，但是" +
                        "游戏功能可能不正常。\n\n详情请查看控制台输出", "退出游戏", "仍然继续游戏");
                    yield return new WaitUntil(UIManager.IsDialogClosed);

                    if (UIManager.GetLastDialogResult() == UI.Components.DialogResult.OK)
                        GameMgr.ExitGame();//选择了退出
                }
            }
            sp = null;

            #endregion

            //游戏已经加载完全了，现在将控制权交予 MenuLevel Loader
            //================================================

            GameModPackage gameinitModPackage = null;
            if (!GameModLoader.FindLadedMod(gameinit_path, out gameinitModPackage))


            goto ENDLOAD;
            ERRANDEXIT:
            if (intro != null) intro.SetActive(false);
            UIManager.ShowDialog(0, "游戏初始化失败", "请尝试重新安装游戏\n错误信息：" + errmsg, "退出游戏", "");
            yield return new WaitUntil(UIManager.IsDialogClosed);
            GameMgr.ExitGame();//加载失败退出

            ENDLOAD:
            yield break;
        }

        /// <summary>
        /// 在全局运行 MOD包 中的一个lua脚本
        /// </summary>
        /// <param name="pk">MOD包</param>
        /// <param name="textAssetName">lua脚本资源文件名</param>
        /// <param name="entryFunction">入口函数，为空则无调用函数（默认无参数，无返回值）</param>
        /// <param name="chunkname">可选</param>
        public void RunLuaScriptInAssetGlobal(GameModPackage pk, string textAssetName, string entryFunction = "", string chunkname = "GameBulider.cs")
        {
            TextAsset lua = GameModPackageAssetMgr.GetPackageTextAsset(pk, textAssetName);
            if (lua == null)
                GameMgr.LogErr("[RunLuaScriptInAsset] Load lua resuorce {0} failed. Package :{1}", textAssetName, pk.Name);
            else
            {
                //装入运行
                GlobalLuaState.DoString(lua.text, chunkname);
                GlobalLuaState.CheckTop();

                if (!string.IsNullOrEmpty(entryFunction))
                {
                    LuaFunction entery = GlobalLuaState.GetFunction(entryFunction);
                    if (entery == null)
                        GameMgr.LogErr("[RunLuaScriptInAsset] Find lua entry Function {0} failed. LuaFile :{1}", entryFunction, textAssetName);
                    else
                    {
                        entery.Call();
                        entery.Dispose();
                    }
                }
            }
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

    /// <summary>
    /// 标识游戏主部件
    /// </summary>
    public enum GameServices
    {
        /// <summary>
        /// 主管理器
        /// </summary>
        GameMgr,
        /// <summary>
        /// MOD 加载器
        /// </summary>
        GameModLoader,
        /// <summary>
        /// 输出和控制台管理器
        /// </summary>
        GameCommandManager,
        /// <summary>
        /// 通用界面管理器
        /// </summary>
        GameUIManager,
        /// <summary>
        /// 摄像机管理器
        /// </summary>
        GameCameraManager,
        /// <summary>
        /// 窗口管理器
        /// </summary>
        GameWindowMgr,
    }
}

