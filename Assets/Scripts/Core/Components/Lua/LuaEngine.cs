using LuaInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Ballance2
{
    class LuaEngine : LuaClient, IGameBasePart
    {
        public static LuaState globalLuaState;

        public GameBulider GameBulider
        {
            get; set;
        }

        protected override LuaFileUtils InitLoader()
        {
            return new LuaResLoader();
        }

        /// <summary>
        /// 可添加或修改搜索 lua 文件的目录
        /// </summary>
        protected override void LoadLuaFiles()
        {
#if UNITY_EDITOR
            // 添加编辑器环境下获取 lua 脚本的路径（Assets/Scripts/lua）
            luaState.AddSearchPath(Application.dataPath + "/Scripts/lua");
#endif
            OnLoadFinished();
        }

        private void Start()
        {

            GameCommandManager.RegisterCommand("runlua", RunLuaCommandReceiverHandler, "运行一段lua代码", "runlua string:scipt|runlua string:scipt string:chunkname", 1);
            GameCommandManager.RegisterCommand("runluaf", RunLuaFCommandReceiverHandler, "运行一个lua脚本文件", "runluaf string:sciptfilepath|runluaf string:sciptfilepath string:searchpath", 1);
        }
        private new void OnDestroy()
        {
            base.OnDestroy();

            GameCommandManager.UnRegisterCommand("runlua", RunLuaCommandReceiverHandler);
            GameCommandManager.UnRegisterCommand("runluaf", RunLuaFCommandReceiverHandler);
        }

        private bool RunLuaCommandReceiverHandler(string[] pararms)
        {
            if (pararms.Length >= 1)
            {
                try
                {
                    if (pararms.Length >= 2)
                        globalLuaState.DoString(pararms[0], pararms[1]);
                    else globalLuaState.DoString(pararms[0]);
                    return true;
                }
                catch (Exception e)
                {
                    luaState.ThrowLuaException(e);
                    GameMgr.LogErr(e.ToString());
                }
            }
            return false;
        }
        private bool RunLuaFCommandReceiverHandler(string[] pararms)
        {
            if (pararms.Length >= 1)
            {
                if (pararms.Length >= 2)
                {
                    try
                    {
                        globalLuaState.AddSearchPath(pararms[1]);
                        globalLuaState.DoFile(pararms[0]);
                        return true;
                    }
                    catch (Exception e)
                    {
                        luaState.ThrowLuaException(e);
                        GameMgr.LogErr(e.ToString());
                    }
                }
                else
                {
                    try
                    {
                        globalLuaState.DoFile(pararms[0]);
                        return true;
                    }
                    catch (Exception e)
                    {
                        luaState.ThrowLuaException(e);
                        GameMgr.LogErr(e.ToString());
                    }
                }
            }
            return false;
        }

        public void InitLua()
        {
            if (globalLuaState == null)
            {
                globalLuaState = GetMainState();
            }

            GameMgr.Log("LuaEngine start");
        }
        public void ExitGameClear()
        {
            if (globalLuaState != null)
            {
                globalLuaState.CheckTop();
                globalLuaState.Dispose();
                globalLuaState = null;
            }
        }
    }
}
