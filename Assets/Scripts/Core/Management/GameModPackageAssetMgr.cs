using System;
using System.IO;
using UnityEngine;

/*
 * 模组资源、代码管理器类
 * 
 * 2018.10.3
 */

namespace Ballance2
{
    /// <summary>
    /// 模组资源、代码管理器类
    /// </summary>
    public static class GameModPackageAssetMgr
    {
        /// <summary>
        /// 使用资源中的 Perfab 初始化一个新的 GameObject
        /// </summary>
        /// <param name="package">MOD 包</param>
        /// <param name="path">资源路径 (资源路径&lt;GameObject名字)</param>
        /// <param name="name">指定新建的 GameObject 的名字</param>
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
        ///  使用 Perfab 初始化一个新的 GameObject
        /// </summary>
        /// <param name="perfab"> Perfab 资源</param>
        /// <param name="name">指定新建的 GameObject 的名字</param>
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
        /// <param name="path">路径 ([(USEAB/USEZIP):][abpackName:]PATH) 
        /// 比如：USEAB:testscript.lua（使用默认ab包中的testscript.lua代码）
        /// USEAB:package1:testscript.lua（使用名为package1的ab包中的testscript.lua代码）
        /// 而：USEZIP:testscript.lua（则使用默认zip包中的testscript.lua代码）
        /// </param>
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

                if (rs.LuaState == null)
                    rs.LuaState = package.LuaState;

                if (package.LuaLooper)
                {
                    LuaLooper looper = target.AddComponent<LuaLooper>();
                    looper.luaState = rs.LuaState;
                }
            }
            if (rs.LuaScriptAssetPath == path) goto RETURN;

            string name = path;
            string targetAbName = "";
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
                    else GameMgr.LogWarn("[GetPackageCodeAndAttatchLUA] Bad resource pararm : {0}", ss[0]);

                    name = ss[1];
                }
                else if (ss.Length == 3)
                {
                    if (ss[0] == "USEAB")
                    {
                        inab = true;
                        targetAbName = ss[1];
                        name = ss[2];
                    }
                    else GameMgr.LogWarn("[GetPackageCodeAndAttatchLUA] Only USEAB pararm can use 3 pararm.");
                }
                else GameMgr.LogWarn("[GetPackageCodeAndAttatchLUA] Bad resource pararm : " + name);
            }
            if (inab)
            {
                AssetBundle targetAb = package.BaseAssetPack;
                if (targetAbName != "")
                {
                    if (!package.HasResPack(targetAbName, out targetAb))
                    {
                        GameMgr.LogWarn("[GetPackageCode] Get package resource (AssetBundle) {0} failed in package : {1} . \nUse default AssetBundle", targetAbName, package.Name);
                        targetAb = package.BaseAssetPack;
                    }
                }
                if (targetAb != null)
                {
                    TextAsset ta = targetAb.LoadAsset<TextAsset>(name);
                    if (ta != null)
                    {
                        rs.LuaScriptAssetPath = name;
                        rs.Initilize(ta);
                    }
                    else
                    {
                        GameMgr.LogErr("[GetPackageCode] Load TextAsset {0} failed in AssetBundle : {2} .", name, targetAb.name);
                        goto RETURN;
                    }
                }
                else
                {
                    GameMgr.LogErr("[GetPackageCode] The package {0} not load any AssetBundle but you try to use AssetBundle code assets.", package.Name);
                    goto RETURN;
                }
            }
            else if (package.IsZip)
            {
                if (package.ZipFile != null)
                {
                    MemoryStream memoryStream = new MemoryStream();
                    if (package.ZipFile.GetFile(name, memoryStream))
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
                        GameMgr.LogErr("[GetPackageCode] The package {0} failed in loading {1} in zip. Error : {2} .", package.Name, name, package.ZipFile.LastError);
                        goto RETURN;
                    }
                }
                else goto ERRNOZIP;
            }
            else goto ERRNOZIP;
            goto CONLOAD;
            ERRNOZIP:
            GameMgr.LogErr("[GetPackageCode] The package {0} not load any zip pack but you try to use zip code assets.", package.Name);
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
        /// <param name="package">MOD 包</param>
        /// <param name="path">资源路径 或者 资源所在Ab包名称:资源路径</param>
        /// <returns></returns>
        public static TextAsset GetPackageTextAsset(GameModPackage package, string path)
        {
            return GetPackageResource<TextAsset>(package, path);
        }
        /// <summary>
        /// 获取Perfab
        /// </summary>
        /// <param name="package">资源所在 MOD 包</param>
        /// <param name="path">资源路径 或者 资源所在Ab包名称:资源路径</param>
        /// <returns></returns>
        public static GameObject GetPackagePerfab(GameModPackage package, string path)
        {
            return GetPackageResource<GameObject>(package, path);
        }
        /// <summary>
        /// 加载 MOD 包中的资源
        /// </summary>
        /// <typeparam name="T">继承于  并由 Unity 支持的 AssetBundle 资源类型</typeparam>
        /// <param name="package">资源所在 MOD 包</param>
        /// <param name="path">资源路径 或者 资源所在Ab包名称:资源路径</param>
        /// <returns></returns>
        public static T GetPackageResource<T>(GameModPackage package, string path) where T : UnityEngine.Object
        {
            string name = path;
            string targetAbName = "";
            if (package.Type != GameModPackage.GameModType.Resource && path.Contains(":"))
            {
                string[] ss = path.Split(',');
                if (ss.Length == 2)
                {
                    targetAbName = ss[0];
                    name = ss[1];
                }
            }

            AssetBundle targetAb = package.BaseAssetPack;
            if (targetAbName != "")
            {
                if (!package.HasResPack(targetAbName, out targetAb))
                {
                    GameMgr.LogWarn("[GetPackageResource] Get package resource {0} failed in package : {1} .Not found package. \nUse default AssetBundle", targetAbName, package.Name);
                    targetAb = package.BaseAssetPack;
                }
            }
            else targetAbName = package.Name;

            if (targetAb != null)
            {
                T ta = targetAb.LoadAsset<T>(name);
                if (ta != null) return ta;
                else GameMgr.LogErr("[GetPackageResource] Load resource {0} (T is {1}) failed in AssetBundle : {2} \nPath : {3}.", name, typeof(T).Name, targetAbName, path);
            }
            else GameMgr.LogWarn("[GetPackageResource] package : {0} not contain assetbundle.", package.Name);
            return default(T);
        }
    }
}
