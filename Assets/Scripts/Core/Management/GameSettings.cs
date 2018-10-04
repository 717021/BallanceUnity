#define MULTI_STATE
using UnityEngine;

/*
 * 游戏设置存储类
 * 
 * 
 */

namespace Ballance2
{
    /// <summary>
    /// 游戏设置存储类
    /// </summary>
    public static class GameSettings
    {

        /// <summary>
        /// 设置_是否是调试模式
        /// </summary>
        public static bool Debug
        {
            get
            {
#if UNITY_EDITOR
                return true;//Editor默认为true
#else
            return GetSettingsBool("Debug");
#endif
            }
            set { SetSettingsBool("Debug", value); }
        }
        /// <summary>
        /// 设置_控制台显示行数
        /// </summary>
        public static int CmdLine
        {
            get { return GetSettingsInt("CmdLine"); }
            set { SetSettingsInt("CmdLine", value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool StartInIntro { get; set; }

        //对 PlayerPrefs 的封装

        public static string GetSettingsString(string str)
        {
            return PlayerPrefs.GetString(str);
        }
        public static void SetSettingsString(string str, string val)
        {
            PlayerPrefs.SetString(str, val);
        }
        public static bool GetSettingsBool(string str)
        {
            return PlayerPrefs.GetInt(str) == 1;
        }
        public static void SetSettingsBool(string str, bool val)
        {
            PlayerPrefs.SetInt(str, val ? 1 : 0);
        }
        public static int GetSettingsInt(string str)
        {
            return PlayerPrefs.GetInt(str);
        }
        public static void SetSettingsInt(string str, int val)
        {
            PlayerPrefs.SetInt(str, val);
        }
        public static float GetSettingsFloat(string str)
        {
            return PlayerPrefs.GetFloat(str);
        }
        public static void SetSettingsFloat(string str, float val)
        {
            PlayerPrefs.SetFloat(str, val);
        }
    }
}
