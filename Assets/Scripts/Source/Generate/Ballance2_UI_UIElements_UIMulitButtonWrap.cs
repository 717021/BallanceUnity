﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Ballance2_UI_UIElements_UIMulitButtonWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Ballance2.UI.UIElements.UIMulitButton), typeof(Ballance2.UI.UIElements.UIButton));
		L.RegFunction("OnInit", OnInit);
		L.RegFunction("StartSet", StartSet);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("LeftText", get_LeftText, set_LeftText);
		L.RegVar("RightText", get_RightText, set_RightText);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnInit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Ballance2.UI.UIElements.UIMulitButton obj = (Ballance2.UI.UIElements.UIMulitButton)ToLua.CheckObject<Ballance2.UI.UIElements.UIMulitButton>(L, 1);
			obj.OnInit();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int StartSet(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Ballance2.UI.UIElements.UIMulitButton obj = (Ballance2.UI.UIElements.UIMulitButton)ToLua.CheckObject<Ballance2.UI.UIElements.UIMulitButton>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			obj.StartSet(arg0);
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
	static int get_LeftText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.UI.UIElements.UIMulitButton obj = (Ballance2.UI.UIElements.UIMulitButton)o;
			string ret = obj.LeftText;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LeftText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_RightText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.UI.UIElements.UIMulitButton obj = (Ballance2.UI.UIElements.UIMulitButton)o;
			string ret = obj.RightText;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index RightText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LeftText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.UI.UIElements.UIMulitButton obj = (Ballance2.UI.UIElements.UIMulitButton)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.LeftText = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LeftText on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_RightText(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.UI.UIElements.UIMulitButton obj = (Ballance2.UI.UIElements.UIMulitButton)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.RightText = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index RightText on a nil value");
		}
	}
}
