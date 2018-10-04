using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 游戏主管理器类
 * 
 * 
 * 2018.10.1
 */

namespace Ballance2
{
    /// <summary>
    /// 游戏主管理器
    /// </summary>
    public class GameMgr : MonoBehaviour, IGameBasePart
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

        private static GameMgr _GameMgrInstance = null;

        /// <summary>
        /// 游戏主管理器类实例
        /// </summary>
        public static GameMgr GameMgrInstance
        {
            get
            {
                return _GameMgrInstance;
            }
            set
            {
                if (_GameMgrInstance == null)
                    _GameMgrInstance = value;
            }
        }

        //==============================

        void Start()
        {
            _GameMgrInstance = this;
            GameCommandManager.RegisterCommand("exit", Exit_CommandReceiverHandler, "退出游戏");
        }

        //==CMD============================

        bool SetSettings_CommandReceiverHandler(string[] pararms)
        {
            GameCommandManager.SetCurrentCommandResult("游戏正在退出。");
            return false;
        }
        bool Exit_CommandReceiverHandler(string[] pararms)
        {
            if (!GameExiting)
            {
                ExitGame();
                return true;
            }
            else GameCommandManager.SetCurrentCommandResult("游戏正在退出。");
            return false;
        }

        //==LOGS============================

        #region LOGS

        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">信息</param>
        public static void Log(string s)
        {
            GameCommandManager.Instance.Log(s);
        }
        /// <summary>
        /// 输出错误信息到控制台
        /// </summary>
        /// <param name="s">信息</param>
        public static void LogErr(string s)
        {
            GameCommandManager.Instance.LogErr(s);
        }
        /// <summary>
        /// 输出警告信息到控制台
        /// </summary>
        /// <param name="s">信息</param>
        public static void LogWarn(string s)
        {
            GameCommandManager.Instance.LogWarn(s);
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">信息</param>
        public static void LogInfo(string s)
        {
            GameCommandManager.Instance.LogInfo(s);
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        public static void Log(string s, object agr1)
        {
            GameCommandManager.Instance.Log(string.Format(s, agr1));
        }
        /// <summary>
        /// 输出错误信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        public static void LogErr(string s, object agr1)
        {
            GameCommandManager.Instance.LogErr(string.Format(s, agr1));
        }
        /// <summary>
        /// 输出警告信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        public static void LogWarn(string s, object agr1)
        {
            GameCommandManager.Instance.LogWarn(string.Format(s, agr1));
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        public static void LogInfo(string s, object agr1)
        {
            GameCommandManager.Instance.LogInfo(string.Format(s, agr1));
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        /// <param name="agr2">字符串格式化参数2</param>
        public static void Log(string s, object agr1, object agr2)
        {
            GameCommandManager.Instance.Log(string.Format(s, agr1, agr2));
        }
        /// <summary>
        /// 输出错误信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        /// <param name="agr2">字符串格式化参数2</param>
        public static void LogErr(string s, object agr1, object agr2)
        {
            GameCommandManager.Instance.LogErr(string.Format(s, agr1, agr2));
        }
        /// <summary>
        /// 输出警告信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        /// <param name="agr2">字符串格式化参数2</param>
        public static void LogWarn(string s, object agr1, object agr2)
        {
            GameCommandManager.Instance.LogWarn(string.Format(s, agr1, agr2));
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="agr1">字符串格式化参数1</param>
        /// <param name="agr2">字符串格式化参数2</param>
        public static void LogInfo(string s, object agr1, object agr2)
        {
            GameCommandManager.Instance.LogInfo(string.Format(s, agr1, agr2));
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="args">字符串格式化参数</param>
        public static void Log(string s, params object[] args)
        {
            GameCommandManager.Instance.Log(string.Format(s, args));
        }
        /// <summary>
        /// 输出错误信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="args">字符串格式化参数</param>
        public static void LogErr(string s, params object[] args)
        {
            GameCommandManager.Instance.LogErr(string.Format(s, args));
        }
        /// <summary>
        /// 输出警告信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="args">字符串格式化参数</param>
        public static void LogWarn(string s, params object[] args)
        {
            GameCommandManager.Instance.LogWarn(string.Format(s, args));
        }
        /// <summary>
        /// 输出信息到控制台
        /// </summary>
        /// <param name="s">格式化字符串</param>
        /// <param name="args">字符串格式化参数</param>
        public static void LogInfo(string s, params object[] args)
        {
            GameCommandManager.Instance.LogInfo(string.Format(s, args));
        }

        #endregion

        //==SOME=PARARMS===========================

        /// <summary>
        /// 获取游戏是否正在退出
        /// </summary>
        public bool GameExiting
        {
            get; private set;
        }

        /// <summary>
        /// 全局退出游戏函数，调用此函数退出游戏
        /// </summary>
        public void ExitGame()
        {
            if (!GameExiting)
            {
                GameExiting = true;
                GameBulider.ExitGame();
            }
        }
        /// <summary>
        /// 退出清理【不可调用】
        /// </summary>
        public void ExitGameClear()
        {

        }



    }
}
