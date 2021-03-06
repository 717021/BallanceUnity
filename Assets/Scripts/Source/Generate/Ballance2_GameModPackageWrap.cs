﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class Ballance2_GameModPackageWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(Ballance2.GameModPackage), typeof(System.Object));
		L.RegFunction("Dispose", Dispose);
		L.RegFunction("Initialize", Initialize);
		L.RegFunction("HasResPack", HasResPack);
		L.RegFunction("EnumChildResPacks", EnumChildResPacks);
		L.RegFunction("LoadModResPackInZip", LoadModResPackInZip);
		L.RegFunction("LoadFlieResPack", LoadFlieResPack);
		L.RegFunction("UnLoadResPack", UnLoadResPack);
		L.RegFunction("New", _CreateBallance2_GameModPackage);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("ResPackCount", get_ResPackCount, null);
		L.RegVar("FilePath", get_FilePath, null);
		L.RegVar("Name", get_Name, null);
		L.RegVar("IsZip", get_IsZip, null);
		L.RegVar("ZipFile", get_ZipFile, null);
		L.RegVar("DefaultAssetFindType", get_DefaultAssetFindType, set_DefaultAssetFindType);
		L.RegVar("VisitCount", get_VisitCount, set_VisitCount);
		L.RegVar("Type", get_Type, null);
		L.RegVar("AssetBundlePath", get_AssetBundlePath, null);
		L.RegVar("BaseAssetPack", get_BaseAssetPack, null);
		L.RegVar("LuaState", get_LuaState, null);
		L.RegVar("LuaLooper", get_LuaLooper, set_LuaLooper);
		L.RegVar("NativeMod", get_NativeMod, null);
		L.RegVar("Initnaized", get_Initnaized, null);
		L.RegVar("InitnaizeFailed", get_InitnaizeFailed, null);
		L.RegVar("InitnaizeDefFile", get_InitnaizeDefFile, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateBallance2_GameModPackage(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1 && TypeChecker.CheckTypes<UnityEngine.AssetBundle>(L, 1))
			{
				UnityEngine.AssetBundle arg0 = (UnityEngine.AssetBundle)ToLua.ToObject(L, 1);
				Ballance2.GameModPackage obj = new Ballance2.GameModPackage(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 1 && TypeChecker.CheckTypes<string>(L, 1))
			{
				string arg0 = ToLua.ToString(L, 1);
				Ballance2.GameModPackage obj = new Ballance2.GameModPackage(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 2)
			{
				Ballance2.Utils.ZipFileReader arg0 = (Ballance2.Utils.ZipFileReader)ToLua.CheckObject<Ballance2.Utils.ZipFileReader>(L, 1);
				string arg1 = ToLua.CheckString(L, 2);
				Ballance2.GameModPackage obj = new Ballance2.GameModPackage(arg0, arg1);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: Ballance2.GameModPackage.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dispose(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
			obj.Dispose();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Initialize(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
				bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
				System.Collections.IEnumerator o = obj.Initialize(arg0);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 3)
			{
				Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
				bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				System.Collections.IEnumerator o = obj.Initialize(arg0, arg1);
				ToLua.Push(L, o);
				return 1;
			}
			else if (count == 4)
			{
				Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
				bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				Ballance2.GameModPackage.GameModInitArgs arg2 = (Ballance2.GameModPackage.GameModInitArgs)ToLua.CheckObject<Ballance2.GameModPackage.GameModInitArgs>(L, 4);
				System.Collections.IEnumerator o = obj.Initialize(arg0, arg1, arg2);
				ToLua.Push(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Ballance2.GameModPackage.Initialize");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasResPack(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			UnityEngine.AssetBundle arg1 = null;
			bool o = obj.HasResPack(arg0, out arg1);
			LuaDLL.lua_pushboolean(L, o);
			ToLua.Push(L, arg1);
			return 2;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int EnumChildResPacks(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
			string o = obj.EnumChildResPacks();
			LuaDLL.lua_pushstring(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadModResPackInZip(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			bool o = obj.LoadModResPackInZip(arg0);
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadFlieResPack(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			System.Collections.IEnumerator o = obj.LoadFlieResPack(arg0);
			ToLua.Push(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnLoadResPack(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2)
			{
				Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				bool o = obj.UnLoadResPack(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				Ballance2.GameModPackage obj = (Ballance2.GameModPackage)ToLua.CheckObject<Ballance2.GameModPackage>(L, 1);
				string arg0 = ToLua.CheckString(L, 2);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 3);
				bool o = obj.UnLoadResPack(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: Ballance2.GameModPackage.UnLoadResPack");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ResPackCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			int ret = obj.ResPackCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ResPackCount on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_FilePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			string ret = obj.FilePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index FilePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Name(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			string ret = obj.Name;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Name on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsZip(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
            bool ret = true;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index IsZip on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ZipFile(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			Ballance2.Utils.ZipFileReader ret = obj.ZipFile;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index ZipFile on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DefaultAssetFindType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			Ballance2.GameModPackage.GameModPackageAssetFindType ret = obj.DefaultAssetFindType;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index DefaultAssetFindType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_VisitCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			int ret = obj.VisitCount;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index VisitCount on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Type(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			Ballance2.GameModPackage.GameModType ret = obj.Type;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Type on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AssetBundlePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			string ret = obj.AssetBundlePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index AssetBundlePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BaseAssetPack(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			UnityEngine.AssetBundle ret = obj.BaseAssetPack;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index BaseAssetPack on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaState(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			LuaInterface.LuaState ret = obj.LuaState;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LuaState on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_LuaLooper(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			bool ret = obj.LuaLooper;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LuaLooper on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NativeMod(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			System.Reflection.Assembly ret = obj.NativeMod;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index NativeMod on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Initnaized(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			bool ret = obj.Initnaized;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Initnaized on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitnaizeFailed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			bool ret = obj.InitnaizeFailed;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitnaizeFailed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InitnaizeDefFile(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			Ballance2.Utils.BFSReader ret = obj.InitnaizeDefFile;
			ToLua.PushObject(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index InitnaizeDefFile on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DefaultAssetFindType(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			Ballance2.GameModPackage.GameModPackageAssetFindType arg0 = (Ballance2.GameModPackage.GameModPackageAssetFindType)ToLua.CheckObject(L, 2, typeof(Ballance2.GameModPackage.GameModPackageAssetFindType));
			obj.DefaultAssetFindType = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index DefaultAssetFindType on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_VisitCount(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.VisitCount = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index VisitCount on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_LuaLooper(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			Ballance2.GameModPackage obj = (Ballance2.GameModPackage)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.LuaLooper = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index LuaLooper on a nil value");
		}
	}
}

