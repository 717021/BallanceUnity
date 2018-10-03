using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Helper
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
        /// 获取资源真实路径
        /// </summary>
        /// <param name="type">资源种类（level：关卡、mod：模组）</param>
        /// <param name="pathorname">相对路径或名称</param>
        /// <returns></returns>
        public static string GetResRealPath(string type, string pathorname)
        {
            if (type == "level")
                return GetLevelRealPath(pathorname);
            else if (type == "mod")
            {
#if UNITY_EDITOR
                return DEBUG_MODS_PATH + pathorname;
#elif UNITY_STANDALONE
                return Application.dataPath + "/mods/" + pathorname;
#elif UNITY_ANDROID
                return ANDROID_MODS_PATH + pathorname;
#elif UNITY_IOS
                return "";
#endif
            }
            else if (type == "core")
            {
#if UNITY_EDITOR
                return DEBUG_PATH + "core/" + pathorname;
#elif UNITY_STANDALONE || UNITY_ANDROID
                return Application.dataPath + "/core/" + pathorname;
#elif UNITY_IOS
                return Application.streamingAssetsPath + "/core/" + pathorname;
#endif
            }
            return "";
        }
        /// <summary>
        /// 获取关卡资源真实路径
        /// </summary>
        /// <param name="pathorname">关卡的相对路径或名称</param>
        /// <returns></returns>
        public static string GetLevelRealPath(string pathorname)
        {
#if UNITY_EDITOR
            return DEBUG_LEVELS_PATH + pathorname;
#elif UNITY_STANDALONE
                return Application.dataPath + "/levels/" + pathorname;
#elif UNITY_ANDROID
                return ANDROID_LEVELS_PATH + pathorname;
#elif UNITY_IOS
               return "";
#endif
        }
    }
}
