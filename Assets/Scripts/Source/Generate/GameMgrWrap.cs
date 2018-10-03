﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GameMgrWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameMgr), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("Log", Log);
		L.RegFunction("LogErr", LogErr);
		L.RegFunction("LogWarn", LogWarn);
		L.RegFunction("LogInfo", LogInfo);
		L.RegFunction("RegisterAction", RegisterAction);
		L.RegFunction("CallAction", CallAction);
		L.RegFunction("RegisterEventLinster", RegisterEventLinster);
		L.RegFunction("UnRegisterEventLinster", UnRegisterEventLinster);
		L.RegFunction("DispatchEvent", DispatchEvent);
		L.RegFunction("DispatchEventToTarget", DispatchEventToTarget);
		L.RegFunction("ExitGame", ExitGame);
		L.RegFunction("ExitGameClear", ExitGameClear);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("GameBulider", get_GameBulider, set_GameBulider);
		L.RegVar("GameMgrInstance", get_GameMgrInstance, set_GameMgrInstance);
		L.RegVar("GameExiting", get_GameExiting, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				GameMgr.Log(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				GameMgr.Log(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, object, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				object arg2 = ToLua.ToVarObject(L, 3);
				GameMgr.Log(arg0, arg1, arg2);
				return 0;
			}
			else if (TypeChecker.CheckTypes<string>(L, 1) && TypeChecker.CheckParamsType<object>(L, 2, count - 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object[] arg1 = ToLua.ToParamsObject(L, 2, count - 1);
				GameMgr.Log(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameMgr.Log");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogErr(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				GameMgr.LogErr(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				GameMgr.LogErr(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, object, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				object arg2 = ToLua.ToVarObject(L, 3);
				GameMgr.LogErr(arg0, arg1, arg2);
				return 0;
			}
			else if (TypeChecker.CheckTypes<string>(L, 1) && TypeChecker.CheckParamsType<object>(L, 2, count - 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object[] arg1 = ToLua.ToParamsObject(L, 2, count - 1);
				GameMgr.LogErr(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameMgr.LogErr");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarn(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				GameMgr.LogWarn(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				GameMgr.LogWarn(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, object, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				object arg2 = ToLua.ToVarObject(L, 3);
				GameMgr.LogWarn(arg0, arg1, arg2);
				return 0;
			}
			else if (TypeChecker.CheckTypes<string>(L, 1) && TypeChecker.CheckParamsType<object>(L, 2, count - 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object[] arg1 = ToLua.ToParamsObject(L, 2, count - 1);
				GameMgr.LogWarn(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameMgr.LogWarn");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogInfo(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				GameMgr.LogInfo(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				GameMgr.LogInfo(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes<string, object, object>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object arg1 = ToLua.ToVarObject(L, 2);
				object arg2 = ToLua.ToVarObject(L, 3);
				GameMgr.LogInfo(arg0, arg1, arg2);
				return 0;
			}
			else if (TypeChecker.CheckTypes<string>(L, 1) && TypeChecker.CheckParamsType<object>(L, 2, count - 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				object[] arg1 = ToLua.ToParamsObject(L, 2, count - 1);
				GameMgr.LogInfo(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameMgr.LogInfo");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterAction(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				Caller.Action arg0 = (Caller.Action)ToLua.CheckObject<Caller.Action>(L, 1);
				Caller.ActionHandler o = GameMgr.RegisterAction(arg0);
				ToLua.PushObject(L, o);
				return 1;
			}
			else if (count == 2)
			{
				Caller.Action arg0 = (Caller.Action)ToLua.CheckObject<Caller.Action>(L, 1);
				string arg1 = ToLua.CheckString(L, 2);
				Caller.ActionHandler o = GameMgr.RegisterAction(arg0, arg1);
				ToLua.PushObject(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameMgr.RegisterAction");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallAction(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				Caller.Action arg0 = (Caller.Action)ToLua.CheckObject<Caller.Action>(L, 1);
				bool o = GameMgr.CallAction(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2)
			{
				Caller.Action arg0 = (Caller.Action)ToLua.CheckObject<Caller.Action>(L, 1);
				string arg1 = ToLua.CheckString(L, 2);
				object o = GameMgr.CallAction(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameMgr.CallAction");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegisterEventLinster(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Caller.EventLinster arg0 = (Caller.EventLinster)ToLua.CheckObject<Caller.EventLinster>(L, 1);
			Caller.EventLinster o = GameMgr.RegisterEventLinster(arg0);
			ToLua.PushObject(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnRegisterEventLinster(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Caller.EventLinster arg0 = (Caller.EventLinster)ToLua.CheckObject<Caller.EventLinster>(L, 1);
			bool o = GameMgr.UnRegisterEventLinster(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DispatchEvent(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			string arg0 = ToLua.CheckString(L, 1);
			object arg1 = ToLua.ToVarObject(L, 2);
			object[] arg2 = ToLua.ToParamsObject(L, 3, count - 2);
			bool o = GameMgr.DispatchEvent(arg0, arg1, arg2);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DispatchEventToTarget(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			string arg0 = ToLua.CheckString(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			object arg2 = ToLua.ToVarObject(L, 3);
			object[] arg3 = ToLua.ToParamsObject(L, 4, count - 3);
			bool o = GameMgr.DispatchEventToTarget(arg0, arg1, arg2, arg3);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExitGame(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameMgr obj = (GameMgr)ToLua.CheckObject<GameMgr>(L, 1);
			obj.ExitGame();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ExitGameClear(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GameMgr obj = (GameMgr)ToLua.CheckObject<GameMgr>(L, 1);
			obj.ExitGameClear();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameBulider(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GameMgr obj = (GameMgr)o;
			GameBulider ret = obj.GameBulider;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index GameBulider on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameMgrInstance(IntPtr L)
	{
		try
		{
			ToLua.Push(L, GameMgr.GameMgrInstance);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameExiting(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GameMgr obj = (GameMgr)o;
			bool ret = obj.GameExiting;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index GameExiting on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameBulider(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GameMgr obj = (GameMgr)o;
			GameBulider arg0 = (GameBulider)ToLua.CheckObject<GameBulider>(L, 2);
			obj.GameBulider = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index GameBulider on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameMgrInstance(IntPtr L)
	{
		try
		{
			GameMgr arg0 = (GameMgr)ToLua.CheckObject<GameMgr>(L, 2);
			GameMgr.GameMgrInstance = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

