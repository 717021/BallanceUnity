#define MULTI_STATE
using UnityEngine;

public static class GameSettings  {
    
    public static bool Debug
    {
        get
        {
#if UNITY_EDITOR
            return true;
#else
            return PlayerPrefs.GetInt("Debug") == 1;
#endif
        }
        set
        {
            PlayerPrefs.SetInt("Debug", value ? 1 : 0);
        }
    }
    public static bool StartInIntro { get; set; }
    public static int CmdLine
    {
        get
        {
            return PlayerPrefs.GetInt("CmdLine");
        }
        set
        {
            PlayerPrefs.SetInt("CmdLine", value);
        }
    }
}
