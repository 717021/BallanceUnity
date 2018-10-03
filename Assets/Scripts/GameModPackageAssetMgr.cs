using System;
using System.IO;
using UnityEngine;

public static class GameModPackageAssetMgr
{
    /// <summary>
    /// 使用资源中的Perfab初始化GameObject
    /// </summary>
    /// <param name="package">mod包</param>
    /// <param name="path">资源路径 (路径&lt;GameObject名字)</param>
    /// <param name="name">GameObject名字</param>
    /// <returns></returns>
    public static GameObject InitObjWithPackageAsset(GameModPackage package, string path, string name = "")
    {
        GameObject perfab = null;
        if (path.Contains("<"))
        {
            string[] ss = path.Split('<');
            if (ss.Length == 2)
            {
                perfab = GetPackagePerfab(package, ss[0]);
                if (perfab != null)
                    return InitObjWithPerfab(perfab, ss[1]);
                else return null;
            }
        }
        perfab = GetPackagePerfab(package, path);
        if (perfab != null)
            return InitObjWithPerfab(perfab, name);
        else return null;
    }
    /// <summary>
    ///  使用Perfab资源初始化GameObject
    /// </summary>
    /// <param name="perfab">Perfab资源</param>
    /// <param name="name">GameObject名字</param>
    /// <returns></returns>
    public static GameObject InitObjWithPerfab(GameObject perfab, string name = "")
    {
        GameObject gameObject = UnityEngine.Object.Instantiate(perfab);
        if (name != "") gameObject.name = name;
        return gameObject;
    }

    /// <summary>
    /// 添加一个lua脚本至GameObject
    /// </summary>
    /// <param name="package">mod包</param>
    /// <param name="path">路径 (USEAB/USEZIP:PATH)</param>
    /// <param name="target">目标GameObject</param>
    /// <returns></returns>
    public static LuaComponent GetPackageCodeAndAttatchLUA(GameModPackage package, string path, GameObject target)
    {
        bool active = target.activeSelf;
        LuaComponent rs = target.GetComponent<LuaComponent>();
        if (rs == null)
        {
            target.SetActive(false);
            rs = target.AddComponent<LuaComponent>();
        }
        if (rs.LuaScriptAssetPath == path) goto RETURN;
        if (rs.LuaState == null) rs.LuaState = package.LuaState;

        string name = path;
        bool inab = package.DefaultAssetFindType == GameModPackage.GameModPackageAssetFindType.UseAssetBundle;
        if (path.Contains(":"))
        {
            string[] ss = path.Split(',');
            if (ss.Length == 2)
            {
                if (ss[0] == "USEAB")
                    inab = true;
                else if (ss[0] == "USEZIP")
                    inab = false;

                name = ss[1];
            }
        }
        if (inab)
        {
            if (package.BaseAssetPack != null)
            {
                TextAsset ta = package.BaseAssetPack.LoadAsset<TextAsset>(name);
                if (ta != null)
                {
                    rs.LuaScriptAssetPath = name;
                    rs.Initilize(ta);
                }
                else
                {
                    GameMgr.LogErr("The package {0} failed in loading {1} in AssetBundle : {2} .", package.AssetBundlePath, name, package.AssetBundlePath);
                    goto RETURN;
                }
            }
            else
            {
                GameMgr.LogErr("The package {0} not load any AssetBundle but you try to use AssetBundle code assets.", package.AssetBundlePath);
                goto RETURN;
            }
        }
        else if (package.IsZip)
        {
            if (inab && package.BaseAssetPack != null)
            {
                TextAsset ta = package.BaseAssetPack.LoadAsset<TextAsset>(name);
                if (ta != null)
                {
                    rs.LuaScriptAssetPath = name;
                    rs.Initilize(ta);
                }
                else
                {
                    GameMgr.LogErr("The package {0} failed in loading {1} in AssetBundle : {2} .", package.AssetBundlePath, name, package.AssetBundlePath);
                    goto RETURN;
                }
            }
            else if (package.ZipFile != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                if(package.ZipFile.GetFile(name, memoryStream))
                {
                    byte[] b = memoryStream.ToArray();
                    string s = System.Text.Encoding.UTF8.GetString(b, 0, b.Length);
                    if (s != null && s != "")
                    {
                        TextAsset ta = new TextAsset(s);
                        rs.LuaScriptAssetPath = name;
                        rs.Initilize(ta);
                    }
                    memoryStream.Dispose();
                    memoryStream = null;
                    s = null;
                }
                else
                {
                    GameMgr.LogErr("The package {0} failed in loading {1} in zip. Error : {2} .", package.AssetBundlePath, name, package.ZipFile.LastError);
                    goto RETURN;
                }
            }
            else goto ERRNOZIP;
        }
        else goto ERRNOZIP;
        goto CONLOAD;
        ERRNOZIP:
        GameMgr.LogErr("The package {0} not load any zip pack but you try to use zip code assets.", package.AssetBundlePath);
        goto RETURN;
        CONLOAD:
        RETURN:
        target.SetActive(active);
        return rs;
    }
    /// <summary>
    /// 添加一个C#脚本至GameObject
    /// </summary>
    /// <param name="package">mod包</param>
    /// <param name="compotentName">compotentName：c#中的类名（命名空间:类名）</param>
    /// <param name="target">目标GameObject</param>
    /// <returns></returns>
    public static Component GetPackageCodeAndAttatchCs(GameModPackage package, string compotentName, GameObject target)
    {
        Component com = target.GetComponent(compotentName);
        if (com == null)
        {
            if (package.NativeMod != null)
            {
                Type type = package.NativeMod.GetType(compotentName);
                target.AddComponent(type);
                com = target.GetComponent(compotentName);
            }
            else GameMgr.LogErr("package : {0} ({1}) does not contain a NativeMod.", package.AssetBundlePath, compotentName);
        }
        return com;
    }

    /// <summary>
    /// 获取 TextAsset
    /// </summary>
    /// <param name="package">mod包</param>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public static TextAsset GetPackageTextAsset(GameModPackage package, string path)
    {
        TextAsset textAsset = null;
        if (package.BaseAssetPack != null)
        {
            textAsset = package.BaseAssetPack.LoadAsset<TextAsset>(path);
            if (textAsset == null) GameMgr.LogWarn("package : {0} assetbundle does not contain perfab : {1}.", package.Name, path);
        }
        else GameMgr.LogWarn("package : {0} not contain assetbundle.", package.Name);
        return textAsset;
    }
    /// <summary>
    /// 获取Perfab
    /// </summary>
    /// <param name="package">mod包</param>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public static GameObject GetPackagePerfab(GameModPackage package, string path)
    {
        GameObject perfab = null;
        if (package.BaseAssetPack != null)
        {
            perfab = package.BaseAssetPack.LoadAsset<GameObject>(path);
            if (perfab == null) GameMgr.LogWarn("package : {0} assetbundle does not contain perfab : {1}.", package.Name, path);
        }
        else GameMgr.LogWarn("package : {0} not contain assetbundle.", package.Name);
        return perfab;
    }

    public static string[] ResolveAssetPath(string s)
    {

        return null;
    }
}
