﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Ballance2_GameModPackage_GameModInitArgsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Ballance2.GameModPackage.GameModInitArgs), typeof(System.Object));
		L.RegFunction("New", _CreateBallance2_GameModPackage_GameModInitArgs);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("loader", get_loader, set_loader);
		L.RegVar("InitObjCodeType", get_InitObjCodeType, set_InitObjCodeType);
		L.RegVar("InitObjPerfabPath", get_InitObjPerfabPath, set_InitObjPerfabPath);
		L.RegVar("InitObjCodePath", get_InitObjCodePath, set_InitObjCodePath);
		L.RegVar("InitObjCSNativeDllCodePath", get_InitObjCSNativeDllCodePath, set_InitObjCSNativeDllCodePath);
		L.RegVar("InitObj", get_InitObj, set_InitObj);
		L.RegVar("InitObjAttatchCode", get_InitObjAttatchCode, set_InitObjAttatchCode);
		L.RegVar("InitObjLUACodeUseGlobalLuaState", get_InitObjLUACodeUseGlobalLuaState, set_InitObjLUACodeUseGlobalLuaState);
		L.RegVar("InitObjLUAUseLooper", get_InitObjLUAUseLooper, set_InitObjLUAUseLooper);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateBallance2_GameModPackage_GameModInitArgs(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				Ballance2.GameModPackage.GameModInitArgs obj = new Ballance2.GameModPackage.GameModInitArgs();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Ballance2.GameModPackage.GameModInitArgs.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_loader(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			UnityEngine.MonoBehaviour ret = obj.loader;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index loader on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjCodeType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			Ballance2.GameModPackage.GameModCodeType ret = obj.InitObjCodeType;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjCodeType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjPerfabPath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			string ret = obj.InitObjPerfabPath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjPerfabPath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjCodePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			string ret = obj.InitObjCodePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjCodePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjCSNativeDllCodePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			string ret = obj.InitObjCSNativeDllCodePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjCSNativeDllCodePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObj(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool ret = obj.InitObj;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObj on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjAttatchCode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool ret = obj.InitObjAttatchCode;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjAttatchCode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjLUACodeUseGlobalLuaState(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool ret = obj.InitObjLUACodeUseGlobalLuaState;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjLUACodeUseGlobalLuaState on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitObjLUAUseLooper(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool ret = obj.InitObjLUAUseLooper;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjLUAUseLooper on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_loader(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			UnityEngine.MonoBehaviour arg0 = (UnityEngine.MonoBehaviour)ToLua.CheckObject<UnityEngine.MonoBehaviour>(L, 2);
			obj.loader = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index loader on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjCodeType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			Ballance2.GameModPackage.GameModCodeType arg0 = (Ballance2.GameModPackage.GameModCodeType)ToLua.CheckObject(L, 2, typeof(Ballance2.GameModPackage.GameModCodeType));
			obj.InitObjCodeType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjCodeType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjPerfabPath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.InitObjPerfabPath = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjPerfabPath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjCodePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.InitObjCodePath = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjCodePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjCSNativeDllCodePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.InitObjCSNativeDllCodePath = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjCSNativeDllCodePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObj(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.InitObj = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObj on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjAttatchCode(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.InitObjAttatchCode = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjAttatchCode on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjLUACodeUseGlobalLuaState(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.InitObjLUACodeUseGlobalLuaState = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjLUACodeUseGlobalLuaState on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InitObjLUAUseLooper(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage.GameModInitArgs obj = (Ballance2.GameModPackage.GameModInitArgs)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.InitObjLUAUseLooper = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitObjLUAUseLooper on a nil value");
		}
	}
}

