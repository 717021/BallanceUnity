﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class GlobalUI_UIElements_UIToggleWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(GlobalUI.UIElements.UIToggle), typeof(GlobalUI.UIElement));
		L.RegFunction("OnClick", OnClick);
		L.RegFunction("StartSet", StartSet);
		L.RegFunction("Oninit", Oninit);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("isChecked", get_isChecked, set_isChecked);
		L.RegVar("Text", get_Text, set_Text);
		L.RegVar("onCheckChanged", get_onCheckChanged, set_onCheckChanged);
		L.RegFunction("VoidDelegate", GlobalUI_UIElements_UIToggle_VoidDelegate);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnClick(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)ToLua.CheckObject<GlobalUI.UIElements.UIToggle>(L, 1);
			obj.OnClick();
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
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)ToLua.CheckObject<GlobalUI.UIElements.UIToggle>(L, 1);
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
	static int Oninit(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)ToLua.CheckObject<GlobalUI.UIElements.UIToggle>(L, 1);
			obj.Oninit();
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
	static int get_isChecked(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)o;
			bool ret = obj.isChecked;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isChecked on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Text(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)o;
			string ret = obj.Text;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Text on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onCheckChanged(IntPtr L)
	{
		ToLua.Push(L, new EventObject(typeof(GlobalUI.UIElements.UIToggle.VoidDelegate)));
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_isChecked(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.isChecked = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index isChecked on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Text(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.Text = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Text on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onCheckChanged(IntPtr L)
	{
		try
		{
			GlobalUI.UIElements.UIToggle obj = (GlobalUI.UIElements.UIToggle)ToLua.CheckObject(L, 1, typeof(GlobalUI.UIElements.UIToggle));
			EventObject arg0 = null;

			if (LuaDLL.lua_isuserdata(L, 2) != 0)
			{
				arg0 = (EventObject)ToLua.ToObject(L, 2);
			}
			else
			{
				return LuaDLL.luaL_throw(L, "The event 'GlobalUI.UIElements.UIToggle.onCheckChanged' can only appear on the left hand side of += or -= when used outside of the type 'GlobalUI.UIElements.UIToggle'");
			}

			if (arg0.op == EventOp.Add)
			{
				GlobalUI.UIElements.UIToggle.VoidDelegate ev = (GlobalUI.UIElements.UIToggle.VoidDelegate)arg0.func;
				obj.onCheckChanged += ev;
			}
			else if (arg0.op == EventOp.Sub)
			{
				GlobalUI.UIElements.UIToggle.VoidDelegate ev = (GlobalUI.UIElements.UIToggle.VoidDelegate)arg0.func;
				obj.onCheckChanged -= ev;
			}

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GlobalUI_UIElements_UIToggle_VoidDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<GlobalUI.UIElements.UIToggle.VoidDelegate>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<GlobalUI.UIElements.UIToggle.VoidDelegate>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

