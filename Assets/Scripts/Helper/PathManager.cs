using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Helper
{
    public static class GamePathManager
    {
        public const string DEBUG_PATH = "E:/Game/Ballance2/Debug/";
        public const string DEBUG_MODS_PATH = "E:/Game/Ballance2/Debug/mods/";
        public const string DEBUG_LEVELS_PATH = "E:/Game/Ballance2/Debug/levels/";

        public const string ANDROID_MODS_PATH = "/sdcard/games/com.magical.ballance2/mods/";
        public const string ANDROID_LEVELS_PATH = "/sdcard/games/com.magical.ballance2/levels/";

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
