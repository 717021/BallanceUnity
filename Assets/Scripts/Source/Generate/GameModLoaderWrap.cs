﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GameModLoaderWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GameModLoader), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("FindLadedMod", FindLadedMod);
		L.RegFunction("IsModLaded", IsModLaded);
		L.RegFunction("LoadMod", LoadMod);
		L.RegFunction("LoadResInMod", LoadResInMod);
		L.RegFunction("UnLoadResInMod", UnLoadResInMod);
		L.RegFunction("LoadResToMod", LoadResToMod);
		L.RegFunction("UnLoadMod", UnLoadMod);
		L.RegFunction("ExitGameClear", ExitGameClear);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("GameBulider", get_GameBulider, set_GameBulider);
		L.RegVar("LoadedPackages", get_LoadedPackages, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int FindLadedMod(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			GameModPackage arg1 = null;
			bool o = obj.FindLadedMod(arg0, out arg1);
			LuaDLL.lua_pushboolean(L, o);
			ToLua.PushObject(L, arg1);
			return 2;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsModLaded(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.IsModLaded(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadMod(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 4)
			{
				GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				System.Collections.IEnumerator o = obj.LoadMod(arg0, arg1, arg2);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 5)
			{
				GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				string arg2 = ToLua.CheckString(L, 4);
				bool arg3 = LuaDLL.luaL_checkboolean(L, 5);
				System.Collections.IEnumerator o = obj.LoadMod(arg0, arg1, arg2, arg3);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameModLoader.LoadMod");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadResInMod(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
			GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			bool o = obj.LoadResInMod(arg0, arg1);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnLoadResInMod(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
			GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			bool o = obj.UnLoadResInMod(arg0, arg1);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadResToMod(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
			GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 2);
			string arg1 = ToLua.CheckString(L, 3);
			System.Collections.IEnumerator o = obj.LoadResToMod(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnLoadMod(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<GameModPackage>(L, 2))
			{
				GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
				GameModPackage arg0 = (GameModPackage)ToLua.ToObject(L, 2);
				bool o = obj.UnLoadMod(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2 && TypeChecker.CheckTypes<string>(L, 2))
			{
				GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				bool o = obj.UnLoadMod(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameModLoader.UnLoadMod");
			}
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
			GameModLoader obj = (GameModLoader)ToLua.CheckObject<GameModLoader>(L, 1);
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
			GameModLoader obj = (GameModLoader)o;
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
	static int get_LoadedPackages(IntPtr L)
	{
		try
		{
			ToLua.PushSealed(L, GameModLoader.LoadedPackages);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameBulider(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GameModLoader obj = (GameModLoader)o;
			GameBulider arg0 = (GameBulider)ToLua.CheckObject<GameBulider>(L, 2);
			obj.GameBulider = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index GameBulider on a nil value");
		}
	}
}
