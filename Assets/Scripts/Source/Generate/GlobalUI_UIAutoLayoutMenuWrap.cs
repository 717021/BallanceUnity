﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GlobalUI_UIAutoLayoutMenuWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GlobalUI.UIAutoLayoutMenu), typeof(GlobalUI.UIMenu));
		L.RegFunction("DoLayout", DoLayout);
		L.RegFunction("LockLayout", LockLayout);
		L.RegFunction("UnLockLayout", UnLockLayout);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DoLayout(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GlobalUI.UIAutoLayoutMenu obj = (GlobalUI.UIAutoLayoutMenu)ToLua.CheckObject<GlobalUI.UIAutoLayoutMenu>(L, 1);
			float o = obj.DoLayout();
			LuaDLL.lua_pushnumber(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LockLayout(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GlobalUI.UIAutoLayoutMenu obj = (GlobalUI.UIAutoLayoutMenu)ToLua.CheckObject<GlobalUI.UIAutoLayoutMenu>(L, 1);
			obj.LockLayout();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnLockLayout(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GlobalUI.UIAutoLayoutMenu obj = (GlobalUI.UIAutoLayoutMenu)ToLua.CheckObject<GlobalUI.UIAutoLayoutMenu>(L, 1);
			obj.UnLockLayout();
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
}

