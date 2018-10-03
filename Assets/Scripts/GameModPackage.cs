using System;
using UnityEngine;
using LuaInterface;
using System.Collections;
using System.IO;
using Helper;

/*
 * mod包类
 * 
 * 即 MOD 管理的基础
 * 
 * 2018.10.3
 */

/// <summary>
/// MOD 包
/// </summary>
public class GameModPackage : IDisposable
{
    public class GameModInitArgs
    {
        public MonoBehaviour loader = null;

        public GameModCodeType InitObjCodeType = GameModCodeType.Unknow;

        public string InitObjPerfabPath = "";
        public string InitObjCodePath = "";
        public bool InitObj = false;
        public bool InitObjAttatchCode = false;
        public bool InitObjLUACodeUseGlobalLuaState = false;
    }

    /// <summary>
    /// 指定 MOD 包如何寻找资源
    /// </summary>
    public enum GameModPackageAssetFindType
    {
        /// <summary>
        /// 指定在 zip 中查找资源（需开启Zip支持）
        /// </summary>
        UseZip,
        /// <summary>
        /// 指定在 AssetBundle 中查找资源
        /// </summary>
        UseAssetBundle,
    }
    /// <summary>
    /// 指定 MOD 包的代码格式
    /// </summary>
    public enum GameModCodeType
    {
        /// <summary>
        /// 未知，不支持
        /// </summary>
        Unknow,
        /// <summary>
        /// 使用LUA作为MOD脚本代码（推荐）
        /// </summary>
        LUA,
        /// <summary>
        /// 不支持（Reserved）
        /// </summary>
        CSharp,
        /// <summary>
        /// 使用 C# Dll mod 作为MOD脚本代码（很快就不支持（il2cpp编译时和ios将不支持此mod代码））
        /// </summary>
        CSharpNative,
    }

    /// <summary>
    /// 释放，请勿调用（IDisposable自动调用）
    /// </summary>
    public void Dispose()
    {
        if (ZipFile != null)
        {
            ZipFile.Dispose();
            ZipFile = null;
        }
        if (InitnaizeDefFile != null)
        {
            InitnaizeDefFile.Dispose();
            initBFSReader = null;
        }
        if (LuaState != null)
        {
            LuaState.CheckTop();
            LuaState.Dispose();
            LuaState = null;
        }
        foreach (AssetBundleMr a in loadedAssetBundles)
            a.assetBundle.Unload(true);
        loadedAssetBundles.Clear();
        loadedAssetBundles = null;
    }

    /// <summary>
    /// 初始化此 MOD 包为一个 Zip MOD 包，并开启Zip支持
    /// </summary>
    /// <param name="zipFileReader">指定 Zip 文件</param>
    /// <param name="assetPath">指定默认资源包在Zip文件中的路径</param>
    public GameModPackage(ZipFileReader zipFileReader, string assetPath)
    {
        if (zipFileReader != null)
        {
            IsZip = true;
            ZipFile = zipFileReader;
            AssetBundlePath = assetPath;
            Name = Path.GetFileNameWithoutExtension(zipFileReader.Url);
            FilePath = zipFileReader.Url;
            Initnaized = false;
            DefaultAssetFindType = GameModPackageAssetFindType.UseZip;
        }
        else throw new ArgumentNullException("zipFileReader");
    }
    /// <summary>
    /// 使用一个 AssetBundle 的路径初始化此 MOD 包为一个 AssetBundle MOD 包，
    /// </summary>
    /// <param name="assetPath">AssetBundle 路径</param>
    public GameModPackage(string assetPath)
    {
        IsZip = false;
        AssetBundlePath = assetPath;
        Name = assetPath;
        FilePath = Path.GetFileNameWithoutExtension(assetPath);
        Initnaized = false;
        DefaultAssetFindType = GameModPackageAssetFindType.UseAssetBundle;
    }
    /// <summary>
    /// 使用一个 AssetBundle 初始化此 MOD 包为一个 AssetBundle MOD 包，
    /// </summary>
    /// <param name="assetBundle">AssetBundle</param>
    public GameModPackage(AssetBundle assetBundle)
    {
        IsZip = false;
        Initnaized = false;
        if (assetBundle != null)
        {
            FilePath = assetBundle.name;
            AssetBundlePath = assetBundle.name;
            Name = assetBundle.name;
            BaseAssetPack = assetBundle;
            DefaultAssetFindType = GameModPackageAssetFindType.UseAssetBundle;
        }
        else throw new ArgumentNullException("assetBundle");
    }

    /// <summary>
    /// 已加载的 AssetBundle 个数
    /// </summary>
    public int ResPackCount { get { return loadedAssetBundles.Count; } }
    /// <summary>
    /// 文件路径
    /// </summary>
    public string FilePath { get; private set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 是否已开启zip支持和是否已加载zip包
    /// </summary>
    public bool IsZip { get; private set; }
    /// <summary>
    /// 此 Mod 对应的zip包（<see cref="IsZip"/> 为 true 时有效）
    /// </summary>
    public ZipFileReader ZipFile { get; private set; }
    /// <summary>
    /// 指定默认资源寻找方式，<see cref="GameModPackageAssetMgr"/> 会根据此值来寻找资源（如果您没有明确指定资源类型）
    /// </summary>
    public GameModPackageAssetFindType DefaultAssetFindType { get; set; }
    public int VisitCount { get; set; }

    /// <summary>
    /// 此 Mod 的默认 AssetBundle 的路径（使用 <see cref="GameModPackage"/>(<see cref="string"/> assetPath) 初始化时才有效）
    /// </summary>
    public string AssetBundlePath { get; private set; }
    /// <summary>
    /// 此 Mod 的默认 AssetBundle
    /// </summary>
    public AssetBundle BaseAssetPack { get; private set; }
    /// <summary>
    /// LUA状态机，只有Mod加载lua支持时才有效
    /// </summary>
    public LuaState LuaState { get; private set; }
    /// <summary>
    /// C# dll mod，只有Mod加载dll支持并且为pc或android系统时才有效。
    /// 使用 il2cpp 编译时此选项不可用，所以NativeMod将很快不支持。
    /// </summary>
    public System.Reflection.Assembly NativeMod { get; private set; }
    /// <summary>
    /// 是否加载完成
    /// </summary>
    public bool Initnaized { get; private set; }
    /// <summary>
    /// 是否加载错误
    /// </summary>
    public bool InitnaizeFailed { get; private set; }
    /// <summary>
    /// 初始化数据（保存在ModDef.txt中）
    /// </summary>
    public BFSReader InitnaizeDefFile { get { return initBFSReader; } }

    //ab包暂存结构
    private struct AssetBundleMr
    {
        public AssetBundleMr(AssetBundle assetBundle, string path)
        {
            this.assetBundle = assetBundle;
            this.path = path;
            name = Path.GetFileNameWithoutExtension(path);
        }
        public AssetBundle assetBundle;
        public string path;
        public string name;
    }
    //资源池
    private System.Collections.Generic.List<AssetBundleMr> loadedAssetBundles = new System.Collections.Generic.List<AssetBundleMr>();
    //ModDef.txt 的读取器
    private BFSReader initBFSReader = null;

    /// <summary>
    /// 加载该 MOD 包
    /// </summary>
    /// <param name="forceReload">是否强制重新加载</param>
    /// <param name="forceAgrs">是否强制指定初始化参数</param>
    /// <param name="agrs">指定初始化参数</param>
    /// <returns></returns>
    public IEnumerator Initialize(bool forceReload, bool forceAgrs = false, GameModInitArgs agrs = null)
    {
        //检测是否重新加载
        if (Initnaized || (InitnaizeFailed && !forceReload)) yield break;

        GameMgr.Log("Initializing package : {0} ...", Name);

        //init agrs
        if (forceAgrs && agrs == null)
        {
            InitnaizeFailed = true;
            GameMgr.LogErr("Package : {0} You have specified forceAgrs, but no parameters were provided.", Name);
            yield break;
        }
        else if (!forceAgrs) agrs = new GameModInitArgs();

        //加载默认AssetBundle
        if (BaseAssetPack == null)
        {
            if (string.IsNullOrEmpty(AssetBundlePath))
            {
                InitnaizeFailed = true;
                GameMgr.LogErr("Package : {0} failed to load AssetBundle because AssetBundlePath is null !", Name);
                yield break;
            }
            else
            {
                if (IsZip)
                {
                    MemoryStream ms = new MemoryStream();
                    if (ZipFile.GetFile(AssetBundlePath, ms))
                    {
                        BaseAssetPack = AssetBundle.LoadFromStream(ms);
                        if (BaseAssetPack == null)
                        {
                            GameMgr.LogErr("Package : " + Name + " failed to load AssetBundle in AssetBundle.LoadFromStream() !");
                            InitnaizeFailed = true;
                            yield break;
                        }
                    }
                    else
                    {
                        GameMgr.LogErr("Package : " + Name + " failed to load AssetBundle because ZipFile load " + AssetBundlePath + " failed !\nZipFileReader return error : " + ZipFile.LastError);
                        InitnaizeFailed = true;
                        yield break;
                    }
                }
                else
                {
                    WWW www = new WWW(AssetBundlePath);
                    yield return www;
                    if (string.IsNullOrEmpty(www.error))
                    {
                        if (www.assetBundle != null)
                            BaseAssetPack = www.assetBundle;
                        else GameMgr.LogWarn("Package : " + Name + " The \"" + AssetBundlePath + " \" does not contain AssetBundle.");
                    }
                    else
                    {
                        GameMgr.LogErr("Package : " + Name + " failed to load AssetBundle ! \nError : " + www.error);
                        InitnaizeFailed = true;
                        yield break;
                    }
                }
            }
        }

        //Read init cfg 读取 ModDef.txt
        if (BaseAssetPack != null)
        {
            TextAsset ta = BaseAssetPack.LoadAsset<TextAsset>("ModDef.txt");
            if (ta != null) initBFSReader = new BFSReader(ta);
            else GameMgr.LogWarn("Package : {0} does not contain ModDef.txt .", Name);
        }
        else if (IsZip && ZipFile != null)
        {
            string s = ZipFile.GetText("ModDef.txt");
            if (s != null) initBFSReader = new BFSReader(s);
            else GameMgr.LogWarn("Package : {0} does not contain ModDef.txt .", Name);
        }

        //read init agrs
        if (initBFSReader != null && !forceAgrs)
        {
            agrs.InitObj = bool.Parse(initBFSReader.GetPropertyValue("InitObj"));
            agrs.InitObjPerfabPath = initBFSReader.GetPropertyValue("InitObjPerfabPath");
            agrs.InitObjCodeType = (GameModCodeType)Enum.Parse(typeof(GameModCodeType), initBFSReader.GetPropertyValue("InitObjCodeType"));
            agrs.InitObjAttatchCode = bool.Parse(initBFSReader.GetPropertyValue("InitObjAttatchCode"));
            agrs.InitObjCodePath = initBFSReader.GetPropertyValue("InitObjCodePath");
            agrs.InitObjLUACodeUseGlobalLuaState = bool.Parse(initBFSReader.GetPropertyValue("InitObjUseGlobalLuaState"));
            DefaultAssetFindType = (GameModPackageAssetFindType)Enum.Parse(typeof(GameModPackageAssetFindType), initBFSReader.GetPropertyValue("DefaultAssetFindType"));
        }

        if (agrs.InitObjCodeType == GameModCodeType.LUA)
        {
            if (agrs.InitObjLUACodeUseGlobalLuaState)
            {
                LuaState = GameBulider.GameBuliderInstance.GlobalLuaState;
            }
            else
            {
                LuaState = new LuaState();
                LuaState.Start();
            }
        }
        /*
        else if (agrs.InitObjCodeType == GameModCodeType.CSharp)
        {
        }
        else if (agrs.InitObjCodeType == GameModCodeType.CSharpNative)
        {
            
        }
        */

        //加载mod代码
        if (agrs.InitObj && !string.IsNullOrEmpty(agrs.InitObjPerfabPath))
        {
            GameObject gameObject = GameModPackageAssetMgr.InitObjWithPackageAsset(this, agrs.InitObjPerfabPath);
            if (gameObject == null)
                GameMgr.LogWarn("GameModPackage:Initnaize: failed to load InitObj because Perfab {0} load failed !", agrs.InitObjPerfabPath);
            else
            {
                gameObject.transform.SetParent(GameBulider.GameBuliderInstance.LevelHost.transform);
                if (agrs.InitObjAttatchCode && !string.IsNullOrEmpty(agrs.InitObjCodePath))
                {
                    if (agrs.InitObjCodeType == GameModCodeType.Unknow)
                        GameMgr.LogWarn("GameModPackage:Initnaize: failed to load InitObj because agrs.InitObjCodeType set wrong !");
                    else
                    {
                        if (agrs.InitObjCodeType == GameModCodeType.LUA)
                            GameModPackageAssetMgr.GetPackageCodeAndAttatchLUA(this, agrs.InitObjCodePath, gameObject);
                        else if (agrs.InitObjCodeType == GameModCodeType.CSharpNative)
                            GameModPackageAssetMgr.GetPackageCodeAndAttatchCs(this, agrs.InitObjCodePath, gameObject);
                    }
                }
            }
        }

        Initnaized = true;
        GameMgr.Log("Package : {0} initialized.", Name);
        yield break;
    }
    /// <summary>
    /// mod是否已加载某个AssetBundle
    /// </summary>
    /// <param name="assetpath">AssetBundle路径</param>
    /// <returns></returns>
    public bool HasResPack(string assetpath, out AssetBundle assetBundle)
    {
        bool rs = false;
        foreach (AssetBundleMr g in loadedAssetBundles)
        {
            if (g.path == assetpath)
            {
                rs = true;
                assetBundle = g.assetBundle;
                return true;
            }
        }
        assetBundle = null;
        return rs;
    }

    private bool HasResPack(string assetpath, out AssetBundleMr assetBundle)
    {
        bool rs = false;
        foreach (AssetBundleMr g in loadedAssetBundles)
        {
            if (g.path == assetpath)
            {
                rs = true;
                assetBundle = g;
                return true;
            }
        }
        assetBundle = default(AssetBundleMr);
        return rs;
    }

    public string EnumChildResPacks()
    {
        string s = "子 资源包 (" + ResPackCount + ")个";
        foreach (AssetBundleMr m in loadedAssetBundles)
        {
            s += "\n" + m.assetBundle.name;
        }
        return s;
    }
    /// <summary>
    /// 加载该 Zip MOD 包中的 AssetBundle 至资源池中（仅为zip模式有效）
    /// </summary>
    /// <param name="assetpath">AssetBundle 文件路径或名称</param>
    /// <returns>返回是否成功</returns>
    public bool LoadModResPackInZip(string assetpath)
    {
        if (Initnaized)
        {
            GameMgr.Log("Initializing package : {0} asset : {1}...", Name, assetpath);
            if (IsZip && ZipFile != null)
            {
                AssetBundle assetBundle = null;
                if (HasResPack(assetpath, out assetBundle))
                {
                    GameMgr.Log("Package : {0} asset : {1} loaded.", Name, assetpath);
                    return true;
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    if (ZipFile.GetFile(assetpath, ms))
                    {
                        assetBundle = AssetBundle.LoadFromStream(ms);
                        if (assetBundle != null)
                        {
                            loadedAssetBundles.Add(new AssetBundleMr(assetBundle, assetpath));
                            GameMgr.Log("Package : {0} asset : {1} loaded.", Name, assetpath);
                            return true;
                        }
                        else GameMgr.LogErr("Failed to load AssetBundle : {0} , invalid data.", assetpath);
                    }
                    else GameMgr.LogErr("Failed to load AssetBundle : {0} ,zip error : {1} .", assetpath, ZipFile.LastError);
                }
            }
            else GameMgr.Log("Initialize package : {0} asset : {1} failed no zip.", Name, assetpath);
        }
        return false;
    }
    /// <summary>
    /// 加载自定义 AssetBundle 至该 MOD 包的资源池中
    /// </summary>
    /// <param name="filepath">自定义 AssetBundle 文件路径</param>
    /// <returns></returns>
    public IEnumerator LoadFlieResPack(string filepath)
    {
        if (Initnaized)
        {
            GameMgr.Log("Initializing package : {0} asset : {1}...", Name, filepath);
            if (File.Exists(filepath))
            {
                AssetBundle assetBundle = null;
                if (HasResPack(filepath, out assetBundle))
                {
                    GameMgr.Log("Package : {0} asset : {1} loaded.", Name, filepath);
                    yield break;
                }
                else
                {
                    WWW www = new WWW(filepath);
                    yield return www;
                    if (string.IsNullOrEmpty(www.error))
                    {
                        assetBundle = www.assetBundle;
                        if (assetBundle != null)
                        {
                            loadedAssetBundles.Add(new AssetBundleMr(assetBundle, filepath));
                            GameMgr.Log("Package : {0} asset : {1} loaded.", Name, filepath);
                            yield break;
                        }
                        else GameMgr.LogErr("Failed to load AssetBundle : {0} , invalid data.", filepath);
                    }
                    else GameMgr.LogErr("Failed to load AssetBundle : {0} , error : {1} .", filepath, www.error);
                }
            }
            else GameMgr.LogErr("Failed to load AssetBundle : {0} , file not exists.", filepath);
        }
        yield break;
    }
    /// <summary>
    /// 卸载该 MOD 包的资源池中的自定义 AssetBundle
    /// </summary>
    /// <param name="path">自定义 AssetBundle</param>
    /// <returns>返回是否成功</returns>
    public bool UnLoadResPack(string path, bool unloadallobjs = false)
    {
        if (Initnaized)
        {
            AssetBundleMr assetBundle = default(AssetBundleMr);
            if (HasResPack(path, out assetBundle))
            {
                if (assetBundle.assetBundle != null)
                    assetBundle.assetBundle.Unload(unloadallobjs);
                GameMgr.Log("Package : {0} asset : {1} unloaded.", Name, path);
                loadedAssetBundles.Remove(assetBundle);
                return true;
            }
            else GameMgr.LogErr("Failed to unload AssetBundle : {0} , is was not load.", path);
        }
        return false;
    }
}
