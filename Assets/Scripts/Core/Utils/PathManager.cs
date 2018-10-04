using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ballance2.Utils
{
    /// <summary>
    /// 全局资源路径解析器
    /// </summary>
    public static class GamePathManager
    {
        /// <summary>
        /// 调试路径（当前目录）<c>（您在调试时请将其更改为自己项目存放目录）</c>
        /// </summary>
        public const string DEBUG_PATH = "E:/Game/BallanceUnity/Debug/";
        /// <summary>
        /// 调试路径（当前模组目录）<c>（您在调试时请将其更改为自己项目存放目录）</c>
        /// </summary>
        public const string DEBUG_MODS_PATH = "E:/Game/BallanceUnity/Debug/mods/";
        /// <summary>
        /// 调试路径（当前关卡目录）<c>（您在调试时请将其更改为自己项目存放目录）</c>
        /// </summary>
        public const string DEBUG_LEVELS_PATH = "E:/Game/BallanceUnity/Debug/levels/";

        /// <summary>
        /// 安卓系统模组目录
        /// </summary>
        public const string ANDROID_MODS_PATH = "/sdcard/games/com.magical.ballance2/mods/";
        /// <summary>
        /// 安卓系统关卡目录
        /// </summary>
        public const string ANDROID_LEVELS_PATH = "/sdcard/games/com.magical.ballance2/levels/";

        /// <summary>
        /// 检测是否是绝对路径
        /// </summary>
        /// <param name="path">路径</param>
        public static bool IsAbsolutePath(string path)
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            if (path.Length > 2)
                return path[1] == ':' && (path[2] == '\\' || path[2] == '/');
#elif UNITY_ANDROID
            return path.StartsWith("/");
#elif UNITY_IOS
            return false;
#endif
            return false;
        }
        /// <summary>
        /// 将资源的相对路径转为资源真实路径
        /// </summary>
        /// <param name="type">资源种类（level：关卡、mod：模组）</param>
        /// <param name="pathorname">相对路径或名称</param>
        /// <param name="replacePlatform">是否替换文件路径中的[Platform]</param>
        /// <returns></returns>
        public static string GetResRealPath(string type, string pathorname, bool replacePlatform = true)
        {
            string pathbuf = "";
            string[] spbuf = null;

            if (replacePlatform && pathorname.Contains("[Platform]"))
                pathorname = pathorname.Replace("[Platform]", GameConst.GamePlatformIdentifier);
            if (type == "level")
                return GetLevelRealPath(pathorname);
            else if (type == "mod")
            {
                if (pathorname.Contains(":"))
                {
                    spbuf = SplitResourceIdentifier(pathorname, out pathbuf);

                    if (IsAbsolutePath(pathbuf)) return pathbuf;
#if UNITY_EDITOR
                    pathbuf = DEBUG_MODS_PATH + pathbuf;
#elif UNITY_STANDALONE
                    pathbuf= Application.dataPath + "/mods/" + pathbuf;
#elif UNITY_ANDROID
                    pathbuf = ANDROID_MODS_PATH + pathbuf;
#elif UNITY_IOS
                    pathbuf = pathbuf;
#endif
                    return ReplacePathInResourceIdentifier(pathbuf, ref spbuf);
                }
                else
                {
#if UNITY_EDITOR
                    return DEBUG_MODS_PATH + pathorname;
#elif UNITY_STANDALONE
                    return Application.dataPath + "/mods/" + pathorname;
#elif UNITY_ANDROID
                    return ANDROID_MODS_PATH + pathorname;
#elif UNITY_IOS
                    return pathorname;
#endif
                }
            }
            else if (type == "core")
            {
                if (pathorname.Contains(":"))
                {
                    spbuf = SplitResourceIdentifier(pathorname, out pathbuf);

                    if (IsAbsolutePath(pathbuf)) return pathbuf;
#if UNITY_EDITOR
                    pathbuf = DEBUG_MODS_PATH + "core/" + pathbuf;
#elif UNITY_STANDALONE || UNITY_ANDROID
                    pathbuf = Application.dataPath + "/core/" + pathbuf;
#elif UNITY_IOS
                    pathbuf = Application.streamingAssetsPath + "/core/" + pathbuf;
#endif
                    return ReplacePathInResourceIdentifier(pathbuf, ref spbuf);
                }
                else
                {
#if UNITY_EDITOR
                    return DEBUG_PATH + "core/" + pathorname;
#elif UNITY_STANDALONE || UNITY_ANDROID
                    return Application.dataPath + "/core/" + pathorname;
#elif UNITY_IOS
                    return Application.streamingAssetsPath + "/core/" + pathorname;
#endif
                }
            }
            return pathorname;
        }
        /// <summary>
        /// 将关卡资源的相对路径转为关卡资源真实路径
        /// </summary>
        /// <param name="pathorname">关卡的相对路径或名称</param>
        /// <returns></returns>
        public static string GetLevelRealPath(string pathorname)
        {
            string pathbuf = "";
            string[] spbuf = null;

            if (pathorname.Contains(":"))
            {
                spbuf =SplitResourceIdentifier(pathorname, out pathbuf);

                if (IsAbsolutePath(pathbuf)) return pathbuf;
#if UNITY_EDITOR
                pathbuf = DEBUG_LEVELS_PATH + pathbuf;
#elif UNITY_STANDALONE
                pathbuf= Application.dataPath + "/levels/" + pathbuf;
#elif UNITY_ANDROID
                pathbuf= ANDROID_LEVELS_PATH + pathbuf;
#elif UNITY_IOS
                pathbuf = pathbuf;
#endif
                return ReplacePathInResourceIdentifier(pathbuf, ref spbuf);
            }
            else
            {
#if UNITY_EDITOR
                return DEBUG_LEVELS_PATH + pathorname;
#elif UNITY_STANDALONE
                return Application.dataPath + "/levels/" + pathorname;
#elif UNITY_ANDROID
                return ANDROID_LEVELS_PATH + pathorname;
#elif UNITY_IOS
                return pathorname;
#endif
            }
        }
        /// <summary>
        /// Replace Path In Resource Identifier (Identifier:Path:Arg0:Arg1)
        /// </summary>
        /// <param name="oldIdentifier">Identifier Want br replace</param>
        /// <param name="newPath"></param>
        /// <param name="buf"></param>
        /// <returns></returns>
        public static string ReplacePathInResourceIdentifier(string newPath, ref string[] buf)
        {
            buf[1] = newPath;
            string s = "";
            foreach (string si in buf)
                s += ":" + si;
            return s.Remove(0, 1);
        }
        /// <summary>
        /// 分割资源标识符
        /// </summary>
        /// <param name="oldIdentifier">资源标识符</param>
        /// <param name="outPath">输出资源路径</param>
        /// <returns></returns>
        public static string[] SplitResourceIdentifier(string oldIdentifier, out string outPath)
        {
            string[] buf = oldIdentifier.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            if (buf.Length > 2)
            {
                if (buf[1].Length == 1 && (buf[2].StartsWith("/") || buf[2].StartsWith("\\")))
                {
                    string[] newbuf = new string[buf.Length - 1];
                    newbuf[0] = buf[0];
                    newbuf[1] = buf[1] + buf[2];
                    for (int i = 2; i < newbuf.Length; i++)
                        newbuf[i] = buf[i + 1];
                    buf = newbuf;
                }
            }
            if (buf.Length > 1)
                outPath = buf[1];

            else outPath = "";
            return buf; 
        }
    }
}
