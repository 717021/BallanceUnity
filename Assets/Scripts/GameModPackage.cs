using System;
using UnityEngine;
using LuaInterface;
using System.Collections;
using System.IO;
using Helper;

//
/// <summary>
/// mod包
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
    }
    public enum GameModPackageAssetFindType
    {
        /// <summary>
        /// 在zip中查找
        /// </summary>
        UseZip,
        /// <summary>
        /// 在AssetBundle中查找
        /// </summary>
        UseAssetBundle,
    }
    public enum GameModCodeType
    {
        Unknow,
        LUA,
        CSharp,
        CSharpNative,
    }

    public void Dispose()
    {
        if (ZipFile != null)
        {
            ZipFile.Dispose();
            ZipFile = null;
        }
        if (InitnaizeDsbFile != null)
        {
            InitnaizeDsbFile.Dispose();
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

    public GameModPackage(ZipFileReader zipFileReader, string assetPath)
    {
        if (zipFileReader != null)
        {
            IsZip = true;
            ZipFile = zipFileReader;
            AssetBundlePath = assetPath;
            Name = zipFileReader.Url;
            Initnaized = false;
            DefaultAssetFindType = GameModPackageAssetFindType.UseZip;
        }
        else throw new ArgumentNullException("zipFileReader");
    }
    public GameModPackage(string assetPath)
    {
        IsZip = false;
        AssetBundlePath = assetPath;
        Name = assetPath;
        Initnaized = false;
        DefaultAssetFindType = GameModPackageAssetFindType.UseAssetBundle;
    }
    public GameModPackage(AssetBundle assetBundle)
    {
        IsZip = false;
        Initnaized = false;
        if (assetBundle != null)
        {
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
    /// 是否已加载zip包
    /// </summary>
    public bool IsZip { get; private set; }
    /// <summary>
    /// GameMod对应的zip包
    /// </summary>
    public ZipFileReader ZipFile { get; private set; }
    /// <summary>
    /// 默认资源寻找方式
    /// </summary>
    public GameModPackageAssetFindType DefaultAssetFindType { get; set; }
    /// <summary>
    /// AssetBundle 的文件位置（使用GameModPackage（string assetPath）初始化时才有效）
    /// </summary>
    public string AssetBundlePath { get; private set; }
    /// <summary>
    /// 此mod的AssetBundle
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
    public BFSReader InitnaizeDsbFile { get { return initBFSReader; } }

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
    private System.Collections.Generic.List<AssetBundleMr> loadedAssetBundles = new System.Collections.Generic.List<AssetBundleMr>();
    private BFSReader initBFSReader = null;

    /// <summary>
    /// 加载该mod包
    /// </summary>
    /// <param name="agrs">初始化参数</param>
    /// <returns></returns>
    public IEnumerator Initialize(bool forceReload)
    {
        if (Initnaized || (InitnaizeFailed && !forceReload)) yield break;

        GameMgr.Log("Initializing package : {0} ...", Name);

        GameModInitArgs agrs = new GameModInitArgs();

        //加载AssetBundle
        if (BaseAssetPack == null)
        {
            if (string.IsNullOrEmpty(AssetBundlePath))
            {
                InitnaizeFailed = true;
                GameMgr.LogErr("GameModPackage:Initnaize: failed to load AssetBundle because AssetBundlePath is null !");
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
                            GameMgr.LogErr("GameModPackage:Initnaize: failed to load AssetBundle in AssetBundle.LoadFromStream() !");
                            InitnaizeFailed = true;
                            yield break;
                        }
                        Name = BaseAssetPack.name;
                    }
                    else
                    {
                        GameMgr.LogErr("GameModPackage:Initnaize: failed to load AssetBundle because ZipFile load " + AssetBundlePath + " failed !");
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
                        {
                            BaseAssetPack = www.assetBundle;
                            Name = BaseAssetPack.name;
                        }
                        else GameMgr.LogWarn("The \"" + AssetBundlePath + " \" does not contain AssetBundle.");
                    }
                    else
                    {
                        GameMgr.LogErr("GameModPackage:Initnaize: failed to load AssetBundle because AssetBundlePath is null !");
                        InitnaizeFailed = true;
                        yield break;
                    }
                }
            }
        }

        //Read init cfg
        if (BaseAssetPack != null)
        {
            TextAsset ta = BaseAssetPack.LoadAsset<TextAsset>("ModDef.txt");
            if (ta != null) initBFSReader = new BFSReader(ta);
            else GameMgr.LogWarn("Package: {0} does not contain ModDef.txt .", Name);
        }
        else if (IsZip && ZipFile != null)
        {
            string s = ZipFile.GetText("ModDef.txt");
            if (s != null) initBFSReader = new BFSReader(s);
            else GameMgr.LogWarn("Package: {0} does not contain ModDef.txt .", Name);
        }
        if (initBFSReader != null)
        {
            agrs.InitObj = bool.Parse(initBFSReader.GetPropertyValue("InitObj"));
            agrs.InitObjPerfabPath = initBFSReader.GetPropertyValue("InitObjPerfabPath");
            agrs.InitObjCodeType = (GameModCodeType)Enum.Parse(typeof(GameModCodeType), initBFSReader.GetPropertyValue("InitObjCodeType"));
            agrs.InitObjAttatchCode = bool.Parse(initBFSReader.GetPropertyValue("InitObjAttatchCode"));
            agrs.InitObjCodePath = initBFSReader.GetPropertyValue("InitObjCodePath");
            DefaultAssetFindType = (GameModPackageAssetFindType)Enum.Parse(typeof(GameModPackageAssetFindType), initBFSReader.GetPropertyValue("DefaultAssetFindType"));
        }

        if (agrs.InitObjCodeType == GameModCodeType.LUA)
        {
            LuaState = new LuaState();
            LuaState.Start();
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
                gameObject.transform.SetParent(GameBulider.GameBuliderStatic.LevelHost.transform);
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
        string s = "子 资源包(" + ResPackCount + ")个";
        foreach (AssetBundleMr m in loadedAssetBundles)
        {
            s += m.assetBundle.name;
        }
        return s;
    }
    /// <summary>
    /// 加载该mod包中的AssetBundle（在zip模式有效）
    /// </summary>
    /// <param name="assetpath">AssetBundle路径</param>
    /// <returns></returns>
    public bool LoadModResPack(string assetpath)
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
    /// 加载自定义 AssetBundle 至该mod包中
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
    /// 卸载该mod包中的自定义 AssetBundle
    /// </summary>
    /// <param name="path">自定义 AssetBundle</param>
    /// <returns></returns>
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
