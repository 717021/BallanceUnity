﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GameModPackageAssetMgrWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("GameModPackageAssetMgr");
		L.RegFunction("InitObjWithPackageAsset", InitObjWithPackageAsset);
		L.RegFunction("InitObjWithPerfab", InitObjWithPerfab);
		L.RegFunction("GetPackagePerfab", GetPackagePerfab);
		L.RegFunction("GetPackageCodeAndAttatchLUA", GetPackageCodeAndAttatchLUA);
		L.RegFunction("GetPackageCodeAndAttatchCs", GetPackageCodeAndAttatchCs);
		L.RegFunction("ResolveAssetPath", ResolveAssetPath);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitObjWithPackageAsset(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 1);
				string arg1 = ToLua.CheckString(L, 2);
				UnityEngine.GameObject o = GameModPackageAssetMgr.InitObjWithPackageAsset(arg0, arg1);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else if (count == 3)
			{
				GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 1);
				string arg1 = ToLua.CheckString(L, 2);
				string arg2 = ToLua.CheckString(L, 3);
				UnityEngine.GameObject o = GameModPackageAssetMgr.InitObjWithPackageAsset(arg0, arg1, arg2);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameModPackageAssetMgr.InitObjWithPackageAsset");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int InitObjWithPerfab(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				UnityEngine.GameObject o = GameModPackageAssetMgr.InitObjWithPerfab(arg0);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else if (count == 2)
			{
				UnityEngine.GameObject arg0 = (UnityEngine.GameObject)ToLua.CheckObject(L, 1, typeof(UnityEngine.GameObject));
				string arg1 = ToLua.CheckString(L, 2);
				UnityEngine.GameObject o = GameModPackageAssetMgr.InitObjWithPerfab(arg0, arg1);
				ToLua.PushSealed(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: GameModPackageAssetMgr.InitObjWithPerfab");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPackagePerfab(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			UnityEngine.GameObject o = GameModPackageAssetMgr.GetPackagePerfab(arg0, arg1);
			ToLua.PushSealed(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPackageCodeAndAttatchLUA(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			UnityEngine.GameObject arg2 = (UnityEngine.GameObject)ToLua.CheckObject(L, 3, typeof(UnityEngine.GameObject));
			LuaComponent o = GameModPackageAssetMgr.GetPackageCodeAndAttatchLUA(arg0, arg1, arg2);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPackageCodeAndAttatchCs(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			GameModPackage arg0 = (GameModPackage)ToLua.CheckObject<GameModPackage>(L, 1);
			string arg1 = ToLua.CheckString(L, 2);
			UnityEngine.GameObject arg2 = (UnityEngine.GameObject)ToLua.CheckObject(L, 3, typeof(UnityEngine.GameObject));
			UnityEngine.Component o = GameModPackageAssetMgr.GetPackageCodeAndAttatchCs(arg0, arg1, arg2);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ResolveAssetPath(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			string arg0 = ToLua.CheckString(L, 1);
			string[] o = GameModPackageAssetMgr.ResolveAssetPath(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}
