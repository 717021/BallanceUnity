using Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 游戏 MOD 加载器类
 * 
 * 
 * 2018.8.3
 * 2018.10.1
 * 
 */

/// <summary>
/// 游戏 MOD 加载器、管理器
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
        //注册一些调试命令
        GameCommandManager.RegisterCommand("mods", Mods_CommandReceiverHandler, "查看已加载mod", "");
        GameCommandManager.RegisterCommand("loadmod", LodMod_CommandReceiverHandler, "加载mod", "loadmod string:modPath bool:iszip:true/false|loadmod string:modPath bool:isZip:true/false string:assetPath bool:forceReload:true/false", 2);
        GameCommandManager.RegisterCommand("unloadmod", UnLodMod_CommandReceiverHandler, "卸载mod", "unloadmod string:modPathOrName", 1);
        GameCommandManager.RegisterCommand("loadmodrs", LodModRes_CommandReceiverHandler, "加载mod资源包", "loadmod string:modPath string:resPath", 2);
        GameCommandManager.RegisterCommand("unloadmodrs", UnLodModRes_CommandReceiverHandler, "卸载mod资源包", "unloadmod string:modPath string:resPath", 2);
        GameCommandManager.RegisterCommand("vres", VRes_CommandReceiverHandler, "查看已加载 mod 指定 AssetBundle 的资源列表", "vres string:modPathOrName|vres string:modPathOrName string:assetBundleName", 1);
    }

    //==============================

    public static List<GameModPackage> LoadedPackages { get; private set; }

    /// <summary>
    /// 寻找已加载mod包
    /// </summary>
    /// <param name="filePath">路径</param>
    /// <param name="modPackage"></param>
    /// <returns></returns>
    public bool FindLadedMod(string filePath, out GameModPackage modPackage)
    {
        bool rs = false;
        foreach (GameModPackage g in LoadedPackages)
        {
            if (g.Name == filePath || g.FilePath == filePath)
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
                else GameMgr.LogErr("Failed to load mod : {0} , zip error : {1} .", filePath, zipFileReader.LastError);
            }
            else
            {
                modPackage = new GameModPackage(filePath);
                yield return StartCoroutine(modPackage.Initialize(forceReload));
                if (modPackage.Initnaized)
                {
                    LoadedPackages.Add(modPackage);
                    GameMgr.Log("[GameModLoader] mod : {0} initialize successfuly.", filePath);
                }
                else if (modPackage.InitnaizeFailed)
                    GameMgr.LogErr("[GameModLoader] Failed to Initnaize mod : {0} .", filePath);
            }
        }
        yield break;
    }
    /// <summary>
    /// 加载该 Zip MOD 包中的 AssetBundle 至资源池中（仅为zip模式有效）
    /// </summary>
    /// <param name="pk"> Zip MOD 包</param>
    /// <param name="assetpath">AssetBundle 文件路径或名称</param>
    /// <returns>返回是否成功</returns>
    public bool LoadModResPackInZip(GameModPackage pk, string assetpath)
    {
        if (pk.Initnaized)
            return pk.LoadModResPackInZip(assetpath);
        else GameMgr.LogErr("[GameModLoader] Package : {0} not Initnaize.", pk.Name);
        return false;
    }
    /// <summary>
    /// 卸载 MOD 包资源池中的资源包
    /// </summary>
    /// <param name="pk">MOD 包</param>
    /// <param name="assetpath">资源包名称路径</param>
    /// <returns></returns>
    public bool UnLoadResInMod(GameModPackage pk, string assetpath)
    {
        if (pk.Initnaized)
            return pk.UnLoadResPack(assetpath);
        else GameMgr.LogErr("[GameModLoader] Package : {0} not Initnaize.", pk.Name);
        return false;
    }
    /// <summary>
    /// 加载自定义 AssetBundle 至该 MOD 包的资源池中
    /// </summary>
    /// <param name="pk"></param>
    /// <param name="assetpath">资源包名称路径</param>
    /// <returns></returns>
    public IEnumerator LoadResToMod(GameModPackage pk, string assetpath)
    {
        if (pk.Initnaized)
            yield return StartCoroutine(pk.LoadFlieResPack(assetpath));
        else GameMgr.LogErr("[GameModLoader] Package : {0} not Initnaize.", pk.Name);
        yield break;
    }
    /// <summary>
    /// 使用路径卸载 MOD 包
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <returns></returns>
    public bool UnLoadMod(string filePath)
    {
        GameModPackage modPackage;
        if (FindLadedMod(filePath, out modPackage))
            return UnLoadMod(modPackage);
        else
        {
            GameMgr.LogErr("[GameModLoader:UnLoadMod] Not found package : " + filePath);
            return false;
        }
    }
    /// <summary>
    /// 卸载 MOD 包
    /// </summary>
    /// <param name="modPackage">MOD 包</param>
    /// <returns></returns>
    public bool UnLoadMod(GameModPackage modPackage)
    {
        if (modPackage != null)
        {
            modPackage.Dispose();
            if (!GameMgr.GameMgrInstance.GameExiting)
                LoadedPackages.Remove(modPackage);
            modPackage = null;
            return true;
        }
        return false;
    }

    //==============================

    /// <summary>
    /// 退出清理【不可调用】
    /// </summary>
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
            GameBulider.CommandManager.OutPut("没有已加载的 MOD 包");
        else
        {
            bool enumcab = false;
            if (pararms.Length >= 1) enumcab = pararms[0] == "showchild";
            string s = "";
            GameBulider.CommandManager.OutPut("已加载的 MOD 包共 " + LoadedPackages.Count + " 个");
            foreach(GameModPackage g in LoadedPackages)
            {
                s = g.Name;
                s += "\n    AssetBundlePath : " + g.AssetBundlePath;
                s += "\n    FilePath : " + g.FilePath;
                s += "\n    Initnaized : " + g.Initnaized;
                s += "\n    DefaultAssetFindType : " + g.DefaultAssetFindType;
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
        //if(System.IO.File.Exists(path))
        //{
            if (pararms.Length > 3)
                LoadMod(path, pararms[1] == "true", pararms[2], pararms[3] == "true");
            else if (pararms.Length > 2)
                LoadMod(path, pararms[1] == "true", pararms[2]);
            else
                LoadMod(path, pararms[1] == "true", "");
        //}
        //else GameCommandManager.SetCurrentCommandResult("文件不存在：" + path);
        return false;
    }
    bool UnLodMod_CommandReceiverHandler(string[] pararms)
    {
        string path = pararms[0];
        if (UnLoadMod(path))
        {
            GameCommandManager.SetCurrentCommandResult("MOD 包 " + path + " 卸载成功");
            return true;
        }
        else
        {
            return false;
        }
    }
    bool LodModRes_CommandReceiverHandler(string[] pararms)
    {
        string path = pararms[0];
        GameModPackage modPackage;
        if (FindLadedMod(path, out modPackage))
        {
            if (LoadModResPackInZip(modPackage, pararms[1]))
                GameCommandManager.SetCurrentCommandResult("加载成功");
        }
        else GameCommandManager.SetCurrentCommandResult("未找到 MOD 包：" + path);
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
        else GameCommandManager.SetCurrentCommandResult("未找到 MOD 包：" + path);
        return false;
    }
    bool VRes_CommandReceiverHandler(string[] pararms)
    {
        string sp = pararms[0];
        string sa = "";

        GameModPackage modPackage;
        if (FindLadedMod(sp, out modPackage))
        {
            AssetBundle ab = null;
            if (pararms.Length >= 2)
            {
                sa = pararms[1];
                if (!modPackage.HasResPack(sa, out ab))
                { GameMgr.LogErr("未在 MOD 包 {0} 中找到 AssetBundle {1}", sp, sa); return false; }
            }
            else ab = modPackage.BaseAssetPack;

            string[] names = ab.GetAllAssetNames();
            string[] scenes = ab.GetAllScenePaths();

            GameBulider.CommandManager.OutPutInfo("AssetBundle : " + ab.name + " 的所有资源");
            GameBulider.CommandManager.OutPutInfo("All Asset Names (" + names.Length + ")");
            foreach (string s in names)
                GameBulider.CommandManager.OutPut(s);
            GameBulider.CommandManager.OutPutInfo("All Scene Paths (" + scenes.Length + ")");
            foreach (string s in names)
                GameBulider.CommandManager.OutPut(s);
        }
        else GameCommandManager.SetCurrentCommandResult("未找到 MOD 包：" + sp);


        return true;
    }

    //==============================

    //==============================

    private void OnDestroy()
    {
        GameCommandManager.UnRegisterCommand("vres", VRes_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("mods", Mods_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("loadmod", LodMod_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("unloadmod", UnLodMod_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("loadmodrs", LodModRes_CommandReceiverHandler);
        GameCommandManager.UnRegisterCommand("unloadmodrs", UnLodModRes_CommandReceiverHandler);
    }
    
}