using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
//
/// <summary>
/// mod加载器
/// </summary>
public class GameModLoader : MonoBehaviour, IGameBasePart
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

    public GameModLoader()
    {
        if (LoadedPackages == null)
            LoadedPackages = new List<GameModPackage>();
    }

    //==============================

    void Start()
    {
        GameCommandManager.RegisterCommand("mods", Mods_CommandReceiverHandler, "查看已加载mod", "");
        GameCommandManager.RegisterCommand("loadmod", LodMod_CommandReceiverHandler, "加载mod", "loadmod string:modpath bool:iszip:true/false|loadmod string:modpath bool:iszip:true/false string:assetpath bool:forceReload:true/false", 2);
        GameCommandManager.RegisterCommand("unloadmod", UnLodMod_CommandReceiverHandler, "卸载mod", "unloadmod string:modpathorname", 1);
        GameCommandManager.RegisterCommand("loadmodrs", LodModRes_CommandReceiverHandler, "加载mod资源包", "loadmod string:modpath string:respath", 2);
        GameCommandManager.RegisterCommand("unloadmodrs", UnLodModRes_CommandReceiverHandler, "卸载mod资源包", "unloadmod string:modpath string:respath", 2);
    }

    //==============================

    public static List<GameModPackage> LoadedPackages { get; private set; }

    /// <summary>
    /// 寻找已加载mod包
    /// </summary>
    /// <param name="filePath">路径</param>
    /// <param name="modPackage"></param>
    /// <returns></returns>
    public bool FindLadedMod(string filePath,out GameModPackage modPackage)
    {
        bool rs = false;
        foreach (GameModPackage g in LoadedPackages)
        {
            if (g.FilePath == filePath)
            {
                modPackage = g;
                return true;
            }
        }
        modPackage = null;
        return rs;
    }
    /// <summary>
    /// 获取mod包是否已加载
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool IsModLaded(string filePath)
    {
        bool rs = false;
        foreach(GameModPackage g in LoadedPackages)
        {
            if (g.FilePath == filePath)
            {
                rs = true;
                break;
            }
        }
        return rs;
    }
    /// <summary>
    /// 加载mod包
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="iszip">是否为zip，是则assetpath填写主assetbundle在zip文件中路径。</param>
    /// <param name="assetpath">是zip则assetpath填写主assetbundle在zip文件中路径</param>
    /// <param name="forceReload">是否强制重新加载</param>
    /// <returns></returns>
    public IEnumerator LoadMod(string filePath, bool iszip, string assetpath, bool forceReload = false)
    {
        if (!IsModLaded(filePath))
        {
            GameModPackage modPackage = null;
            if (iszip)
            {
                ZipFileReader zipFileReader = new ZipFileReader(filePath);
                if (zipFileReader.Load())
                {
                    modPackage = new GameModPackage(zipFileReader, assetpath);
                    yield return StartCoroutine(modPackage.Initialize(forceReload));
                    if (modPackage.Initnaized)
                    {
                        LoadedPackages.Add(modPackage);
                        GameMgr.Log("mod : {0} initialize successfuly.", filePath);
                    }
                    else if (modPackage.InitnaizeFailed) GameMgr.LogErr("Failed to Initnaize mod : {0} .", filePath);
                }
                else GameMgr.LogErr("Failed to load mod : {0} ,zip error : {1} .", filePath, zipFileReader.LastError);
            }
            else
            {
                modPackage = new GameModPackage(filePath);
                yield return StartCoroutine(modPackage.Initialize(forceReload));
                if (modPackage.Initnaized)
                {
                    LoadedPackages.Add(modPackage);
                    GameMgr.Log("mod : {0} initialize successfuly.", filePath);
                }
                else if (modPackage.InitnaizeFailed) GameMgr.LogErr("Failed to Initnaize mod : {0} .", filePath);
            }
        }
        yield break;
    }
    /// <summary>
    /// 加载mod包中的资源包
    /// </summary>
    /// <param name="pk"></param>
    /// <param name="assetpath">assetpath 资源包名称路径</param>
    /// <returns></returns>
    public bool LoadResInMod(GameModPackage pk, string assetpath)
    {
        if (pk.Initnaized)
            return pk.LoadModResPack(assetpath);
        else GameMgr.LogErr("Package : {0} not Initnaize.", pk.Name);
        return false;
    }
    /// <summary>
    /// 卸载mod包中的资源包
    /// </summary>
    /// <param name="pk"></param>
    /// <param name="assetpath">资源包名称路径</param>
    /// <returns></returns>
    public bool UnLoadResInMod(GameModPackage pk, string assetpath)
    {
        if (pk.Initnaized)
            return pk.UnLoadResPack(assetpath);
        else GameMgr.LogErr("Package : {0} not Initnaize.", pk.Name);
        return false;
    }
    /// <summary>
    /// 加载mod包中的资源包
    /// </summary>
    /// <param name="pk"></param>
    /// <param name="assetpath">资源包名称路径</param>
    /// <returns></returns>
    public IEnumerator LoadResToMod(GameModPackage pk, string assetpath)
    {
        if (pk.Initnaized)
            yield return StartCoroutine(pk.LoadFlieResPack(assetpath));
        else GameMgr.LogErr("Package : {0} not Initnaize.", pk.Name);
        yield break;
    }
    /// <summary>
    /// 使用路径卸载mod
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool UnLoadMod(string filePath)
    {
        GameModPackage modPackage;
        if (FindLadedMod(filePath, out modPackage))
            return UnLoadMod(modPackage);
        return false;
    }
    /// <summary>
    /// 卸载mod
    /// </summary>
    /// <param name="modPackage"></param>
    /// <returns></returns>
    public bool UnLoadMod(GameModPackage modPackage)
    {
        modPackage.Dispose();
        if (!GameMgr.GameMgrInstance.GameExiting) LoadedPackages.Remove(modPackage);
        modPackage = null;
        return false;
    }

    //==============================

    public void ExitGameClear()
    {
        foreach (GameModPackage g in LoadedPackages)
            UnLoadMod(g);
        LoadedPackages.Clear();
        LoadedPackages = null;
    }

    //==============================

    bool Mods_CommandReceiverHandler(string[] pararms)
    {
        if (LoadedPackages.Count == 0)
            GameBulider.CommandManager.OutPut("已加载的mod " + LoadedPackages.Count + " 个");
        else
        {
            bool enumcab = false;
            if (pararms.Length >= 1) enumcab = pararms[0] == "showchild";
            string s = "";
            GameBulider.CommandManager.OutPut("已加载的mod " + LoadedPackages.Count + " 个");
            foreach(GameModPackage g in LoadedPackages)
            {
                s = g.Name;
                s += "\n    AssetBundlePath : " + g.AssetBundlePath;
                s += "\n    Initnaized : " + g.Initnaized;
                s += "\n    DefaultAssetFindType : " + g.DefaultAssetFindType;
                s += "\n    FilePath : " + g.FilePath;
                s += "\n    IsZip : " + g.IsZip;
                GameBulider.CommandManager.OutPutInfo(s);
                if(enumcab) GameBulider.CommandManager.OutPut(g.EnumChildResPacks());
            }
        }
        return true;
    }
    bool LodMod_CommandReceiverHandler(string[] pararms)
    {
        string path = pararms[0];
        if(System.IO.File.Exists(path))
        {
            if (pararms.Length > 3)
                LoadMod(path, pararms[1] == "true", pararms[2], pararms[3] == "true");
            else if (pararms.Length > 2)
                LoadMod(path, pararms[1] == "true", pararms[2]);
            else
                LoadMod(path, pararms[1] == "true", "");
        }
        else GameCommandManager.SetCurrentCommandResult("文件不存在：" + path);
        return false;
    }
    bool UnLodMod_CommandReceiverHandler(string[] pararms)
    {
        string path = pararms[0];
        if (UnLoadMod(path))
        {
            GameCommandManager.SetCurrentCommandResult("卸载成功");
            return true;
        }
        return false;
    }
    bool LodModRes_CommandReceiverHandler(string[] pararms)
    {
        string path = pararms[0];
        GameModPackage modPackage;
        if (FindLadedMod(path, out modPackage))
        {
            if (LoadResInMod(modPackage, pararms[1]))
                GameCommandManager.SetCurrentCommandResult("加载成功");
        }
        else GameCommandManager.SetCurrentCommandResult("未找到MOD包：" + path);
        return false;
    }
    bool UnLodModRes_CommandReceiverHandler(string[] pararms)
    {
        string path = pararms[0];
        GameModPackage modPackage;
        if (FindLadedMod(path, out modPackage))
        {
            if (UnLoadResInMod(modPackage, pararms[1]))
                GameCommandManager.SetCurrentCommandResult("卸载成功");
        }
        else GameCommandManager.SetCurrentCommandResult("未找到MOD包：" + path);
        return false;
    }

    //==============================

    //==============================

    private void OnDestroy()
    {
        GameCommandManager.UnRegisterCommand("mods", Mods_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("loadmod", LodMod_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("unloadmod", UnLodMod_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("loadmodrs", LodModRes_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("unloadmodrs", UnLodModRes_CommandReceiverHandler);
    }
    
}