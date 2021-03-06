﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using UnityEngine;
using LuaInterface;

public static class LuaBinder
{
	public static void Bind(LuaState L)
	{
		float t = Time.realtimeSinceStartup;
		L.BeginModule(null);
		LuaInterface_DebuggerWrap.Register(L);
		LuaProfilerWrap.Register(L);
		L.BeginModule("LuaInterface");
		LuaInterface_LuaInjectionStationWrap.Register(L);
		LuaInterface_InjectTypeWrap.Register(L);
		L.EndModule();
		L.BeginModule("UnityEngine");
		UnityEngine_ComponentWrap.Register(L);
		UnityEngine_TransformWrap.Register(L);
		UnityEngine_MaterialWrap.Register(L);
		UnityEngine_LightWrap.Register(L);
		UnityEngine_CameraWrap.Register(L);
		UnityEngine_AudioSourceWrap.Register(L);
		UnityEngine_BehaviourWrap.Register(L);
		UnityEngine_MonoBehaviourWrap.Register(L);
		UnityEngine_GameObjectWrap.Register(L);
		UnityEngine_TrackedReferenceWrap.Register(L);
		UnityEngine_ApplicationWrap.Register(L);
		UnityEngine_PhysicsWrap.Register(L);
		UnityEngine_ColliderWrap.Register(L);
		UnityEngine_TimeWrap.Register(L);
		UnityEngine_TextureWrap.Register(L);
		UnityEngine_Texture2DWrap.Register(L);
		UnityEngine_ShaderWrap.Register(L);
		UnityEngine_RendererWrap.Register(L);
		UnityEngine_WWWWrap.Register(L);
		UnityEngine_ScreenWrap.Register(L);
		UnityEngine_CameraClearFlagsWrap.Register(L);
		UnityEngine_AudioClipWrap.Register(L);
		UnityEngine_AssetBundleWrap.Register(L);
		UnityEngine_ParticleSystemWrap.Register(L);
		UnityEngine_AsyncOperationWrap.Register(L);
		UnityEngine_LightTypeWrap.Register(L);
		UnityEngine_SleepTimeoutWrap.Register(L);
		UnityEngine_AnimatorWrap.Register(L);
		UnityEngine_InputWrap.Register(L);
		UnityEngine_KeyCodeWrap.Register(L);
		UnityEngine_SkinnedMeshRendererWrap.Register(L);
		UnityEngine_SpaceWrap.Register(L);
		UnityEngine_AnimationBlendModeWrap.Register(L);
		UnityEngine_QueueModeWrap.Register(L);
		UnityEngine_PlayModeWrap.Register(L);
		UnityEngine_WrapModeWrap.Register(L);
		UnityEngine_QualitySettingsWrap.Register(L);
		UnityEngine_RenderSettingsWrap.Register(L);
		UnityEngine_ResourcesWrap.Register(L);
		UnityEngine_AudioBehaviourWrap.Register(L);
		L.BeginModule("EventSystems");
		UnityEngine_EventSystems_EventTriggerWrap.Register(L);
		L.EndModule();
		L.BeginModule("Events");
		L.RegFunction("UnityAction", UnityEngine_Events_UnityAction);
		L.EndModule();
		L.BeginModule("Camera");
		L.RegFunction("CameraCallback", UnityEngine_Camera_CameraCallback);
		L.EndModule();
		L.BeginModule("Application");
		L.RegFunction("AdvertisingIdentifierCallback", UnityEngine_Application_AdvertisingIdentifierCallback);
		L.RegFunction("LowMemoryCallback", UnityEngine_Application_LowMemoryCallback);
		L.RegFunction("LogCallback", UnityEngine_Application_LogCallback);
		L.EndModule();
		L.BeginModule("AudioClip");
		L.RegFunction("PCMReaderCallback", UnityEngine_AudioClip_PCMReaderCallback);
		L.RegFunction("PCMSetPositionCallback", UnityEngine_AudioClip_PCMSetPositionCallback);
		L.EndModule();
		L.EndModule();
		L.BeginModule("Ballance2");
		Ballance2_GameModPackageAssetMgrWrap.Register(L);
		Ballance2_GameSettingsWrap.Register(L);
		Ballance2_GameServicesWrap.Register(L);
		L.BeginModule("GameModPackage");
		Ballance2_GameModPackage_GameModCodeTypeWrap.Register(L);
		Ballance2_GameModPackage_GameModInitArgsWrap.Register(L);
		Ballance2_GameModPackage_GameModPackageAssetFindTypeWrap.Register(L);
		Ballance2_GameModPackage_GameModTypeWrap.Register(L);
		L.EndModule();
		L.BeginModule("Utils");
		Ballance2_Utils_GameConstWrap.Register(L);
		Ballance2_Utils_StringSpliterWrap.Register(L);
		Ballance2_Utils_GamePathManagerWrap.Register(L);
		L.BeginModule("KeyListener");
		L.RegFunction("VoidDelegate", Ballance2_Utils_KeyListener_VoidDelegate);
		L.EndModule();
		L.EndModule();
		L.BeginModule("UI");
		L.BeginModule("Components");
		Ballance2_UI_Components_DialogResultWrap.Register(L);
		L.EndModule();
		L.BeginModule("UIElements");
		L.BeginModule("UIButton");
		L.RegFunction("VoidDelegate", Ballance2_UI_UIElements_UIButton_VoidDelegate);
		L.EndModule();
		L.BeginModule("UIToggle");
		L.RegFunction("VoidDelegate", Ballance2_UI_UIElements_UIToggle_VoidDelegate);
		L.EndModule();
		L.EndModule();
		L.BeginModule("LayoutUI");
		L.EndModule();
		L.BeginModule("Utils");
		L.BeginModule("EventTriggerListener");
		L.RegFunction("VoidDelegate", Ballance2_UI_Utils_EventTriggerListener_VoidDelegate);
		L.EndModule();
		L.EndModule();
		L.EndModule();
		L.BeginModule("GameUIMgr");
		L.EndModule();
		L.BeginModule("GameCommandManager");
		L.RegFunction("CommandReceiverHandler", Ballance2_GameCommandManager_CommandReceiverHandler);
		L.EndModule();
		L.EndModule();
		L.BeginModule("System");
		L.RegFunction("Action", System_Action);
		L.RegFunction("Predicate_int", System_Predicate_int);
		L.RegFunction("Action_int", System_Action_int);
		L.RegFunction("Comparison_int", System_Comparison_int);
		L.RegFunction("Func_int_int", System_Func_int_int);
		L.RegFunction("Func_bool", System_Func_bool);
		L.RegFunction("Action_UnityEngine_AsyncOperation", System_Action_UnityEngine_AsyncOperation);
		L.EndModule();
		L.EndModule();
		L.BeginPreLoad();
		L.AddPreLoad("UnityEngine.MeshRenderer", LuaOpen_UnityEngine_MeshRenderer, typeof(UnityEngine.MeshRenderer));
		L.AddPreLoad("UnityEngine.BoxCollider", LuaOpen_UnityEngine_BoxCollider, typeof(UnityEngine.BoxCollider));
		L.AddPreLoad("UnityEngine.MeshCollider", LuaOpen_UnityEngine_MeshCollider, typeof(UnityEngine.MeshCollider));
		L.AddPreLoad("UnityEngine.SphereCollider", LuaOpen_UnityEngine_SphereCollider, typeof(UnityEngine.SphereCollider));
		L.AddPreLoad("UnityEngine.CharacterController", LuaOpen_UnityEngine_CharacterController, typeof(UnityEngine.CharacterController));
		L.AddPreLoad("UnityEngine.CapsuleCollider", LuaOpen_UnityEngine_CapsuleCollider, typeof(UnityEngine.CapsuleCollider));
		L.AddPreLoad("UnityEngine.Animation", LuaOpen_UnityEngine_Animation, typeof(UnityEngine.Animation));
		L.AddPreLoad("UnityEngine.AnimationClip", LuaOpen_UnityEngine_AnimationClip, typeof(UnityEngine.AnimationClip));
		L.AddPreLoad("UnityEngine.AnimationState", LuaOpen_UnityEngine_AnimationState, typeof(UnityEngine.AnimationState));
		L.AddPreLoad("UnityEngine.BlendWeights", LuaOpen_UnityEngine_BlendWeights, typeof(UnityEngine.BlendWeights));
		L.AddPreLoad("UnityEngine.RenderTexture", LuaOpen_UnityEngine_RenderTexture, typeof(UnityEngine.RenderTexture));
		L.AddPreLoad("UnityEngine.Rigidbody", LuaOpen_UnityEngine_Rigidbody, typeof(UnityEngine.Rigidbody));
		L.AddPreLoad("Ballance2.GameModPackage", LuaOpen_Ballance2_GameModPackage, typeof(Ballance2.GameModPackage));
		L.AddPreLoad("Ballance2.GameModLoader", LuaOpen_Ballance2_GameModLoader, typeof(Ballance2.GameModLoader));
		L.AddPreLoad("Ballance2.GameUIMgr", LuaOpen_Ballance2_GameUIMgr, typeof(Ballance2.GameUIMgr));
		L.AddPreLoad("Ballance2.GameMgr", LuaOpen_Ballance2_GameMgr, typeof(Ballance2.GameMgr));
		L.AddPreLoad("Ballance2.GameBulider", LuaOpen_Ballance2_GameBulider, typeof(Ballance2.GameBulider));
		L.AddPreLoad("Ballance2.GameCommandManager", LuaOpen_Ballance2_GameCommandManager, typeof(Ballance2.GameCommandManager));
		L.AddPreLoad("Ballance2.Utils.BFSReader", LuaOpen_Ballance2_Utils_BFSReader, typeof(Ballance2.Utils.BFSReader));
		L.AddPreLoad("Ballance2.Utils.KeyListener", LuaOpen_Ballance2_Utils_KeyListener, typeof(Ballance2.Utils.KeyListener));
		L.AddPreLoad("Ballance2.Utils.ZipFileReader", LuaOpen_Ballance2_Utils_ZipFileReader, typeof(Ballance2.Utils.ZipFileReader));
		L.AddPreLoad("Ballance2.UI.UIElements.UIDropDown", LuaOpen_Ballance2_UI_UIElements_UIDropDown, typeof(Ballance2.UI.UIElements.UIDropDown));
		L.AddPreLoad("Ballance2.UI.UIElements.UIImage", LuaOpen_Ballance2_UI_UIElements_UIImage, typeof(Ballance2.UI.UIElements.UIImage));
		L.AddPreLoad("Ballance2.UI.UIElements.UIMulitButton", LuaOpen_Ballance2_UI_UIElements_UIMulitButton, typeof(Ballance2.UI.UIElements.UIMulitButton));
		L.AddPreLoad("Ballance2.UI.UIElements.UISlider", LuaOpen_Ballance2_UI_UIElements_UISlider, typeof(Ballance2.UI.UIElements.UISlider));
		L.AddPreLoad("Ballance2.UI.UIElements.UIText", LuaOpen_Ballance2_UI_UIElements_UIText, typeof(Ballance2.UI.UIElements.UIText));
		L.AddPreLoad("Ballance2.UI.UIElements.UIToggle", LuaOpen_Ballance2_UI_UIElements_UIToggle, typeof(Ballance2.UI.UIElements.UIToggle));
		L.AddPreLoad("Ballance2.UI.UIElements.UIButton", LuaOpen_Ballance2_UI_UIElements_UIButton, typeof(Ballance2.UI.UIElements.UIButton));
		L.AddPreLoad("Ballance2.UI.LayoutUI.UIVerticalLayoutMenu", LuaOpen_Ballance2_UI_LayoutUI_UIVerticalLayoutMenu, typeof(Ballance2.UI.LayoutUI.UIVerticalLayoutMenu));
		L.AddPreLoad("Ballance2.UI.LayoutUI.UIAutoLayoutMenu", LuaOpen_Ballance2_UI_LayoutUI_UIAutoLayoutMenu, typeof(Ballance2.UI.LayoutUI.UIAutoLayoutMenu));
		L.AddPreLoad("Ballance2.UI.Utils.EventTriggerListener", LuaOpen_Ballance2_UI_Utils_EventTriggerListener, typeof(Ballance2.UI.Utils.EventTriggerListener));
		L.AddPreLoad("Ballance2.UI.Utils.FadeHlper", LuaOpen_Ballance2_UI_Utils_FadeHlper, typeof(Ballance2.UI.Utils.FadeHlper));
		L.AddPreLoad("Ballance2.UI.UIBallanceClassicalMenu", LuaOpen_Ballance2_UI_UIBallanceClassicalMenu, typeof(Ballance2.UI.UIBallanceClassicalMenu));
		L.AddPreLoad("Ballance2.UI.UIElement", LuaOpen_Ballance2_UI_UIElement, typeof(Ballance2.UI.UIElement));
		L.AddPreLoad("Ballance2.UI.UIMenu", LuaOpen_Ballance2_UI_UIMenu, typeof(Ballance2.UI.UIMenu));
		L.AddPreLoad("Ballance2.UI.UIPage", LuaOpen_Ballance2_UI_UIPage, typeof(Ballance2.UI.UIPage));
		L.AddPreLoad("Ballance2.GameUIMgr.StandardUIMaker", LuaOpen_Ballance2_GameUIMgr_StandardUIMaker, typeof(Ballance2.GameUIMgr.StandardUIMaker));
		L.EndPreLoad();
		Debugger.Log("Register lua type cost time: {0}", Time.realtimeSinceStartup - t);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Events_UnityAction(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.Events.UnityAction>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.Events.UnityAction>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Camera_CameraCallback(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.Camera.CameraCallback>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.Camera.CameraCallback>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Application_AdvertisingIdentifierCallback(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.Application.AdvertisingIdentifierCallback>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.Application.AdvertisingIdentifierCallback>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Application_LowMemoryCallback(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.Application.LowMemoryCallback>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.Application.LowMemoryCallback>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_Application_LogCallback(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.Application.LogCallback>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.Application.LogCallback>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_AudioClip_PCMReaderCallback(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.AudioClip.PCMReaderCallback>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.AudioClip.PCMReaderCallback>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UnityEngine_AudioClip_PCMSetPositionCallback(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<UnityEngine.AudioClip.PCMSetPositionCallback>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<UnityEngine.AudioClip.PCMSetPositionCallback>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ballance2_Utils_KeyListener_VoidDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<Ballance2.Utils.KeyListener.VoidDelegate>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<Ballance2.Utils.KeyListener.VoidDelegate>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ballance2_UI_UIElements_UIButton_VoidDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<Ballance2.UI.UIElements.UIButton.VoidDelegate>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<Ballance2.UI.UIElements.UIButton.VoidDelegate>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ballance2_UI_UIElements_UIToggle_VoidDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<Ballance2.UI.UIElements.UIToggle.VoidDelegate>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<Ballance2.UI.UIElements.UIToggle.VoidDelegate>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ballance2_UI_Utils_EventTriggerListener_VoidDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<Ballance2.UI.Utils.EventTriggerListener.VoidDelegate>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<Ballance2.UI.Utils.EventTriggerListener.VoidDelegate>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Ballance2_GameCommandManager_CommandReceiverHandler(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<Ballance2.GameCommandManager.CommandReceiverHandler>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<Ballance2.GameCommandManager.CommandReceiverHandler>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Action(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Action>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Action>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Predicate_int(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Predicate<int>>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Predicate<int>>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Action_int(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Action<int>>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Action<int>>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Comparison_int(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Comparison<int>>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Comparison<int>>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Func_int_int(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Func<int,int>>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Func<int,int>>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Func_bool(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Func<bool>>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Func<bool>>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int System_Action_UnityEngine_AsyncOperation(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			LuaFunction func = ToLua.CheckLuaFunction(L, 1);

			if (count == 1)
			{
				Delegate arg1 = DelegateTraits<System.Action<UnityEngine.AsyncOperation>>.Create(func);
				ToLua.Push(L, arg1);
			}
			else
			{
				LuaTable self = ToLua.CheckLuaTable(L, 2);
				Delegate arg1 = DelegateTraits<System.Action<UnityEngine.AsyncOperation>>.Create(func, self);
				ToLua.Push(L, arg1);
			}
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_MeshRenderer(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_MeshRendererWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.MeshRenderer));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_BoxCollider(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_BoxColliderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.BoxCollider));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_MeshCollider(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_MeshColliderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.MeshCollider));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_SphereCollider(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_SphereColliderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.SphereCollider));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_CharacterController(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_CharacterControllerWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.CharacterController));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_CapsuleCollider(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_CapsuleColliderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.CapsuleCollider));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_Animation(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_AnimationWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.Animation));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_AnimationClip(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_AnimationClipWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.AnimationClip));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_AnimationState(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_AnimationStateWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.AnimationState));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_BlendWeights(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_BlendWeightsWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.BlendWeights));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_RenderTexture(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_RenderTextureWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.RenderTexture));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_UnityEngine_Rigidbody(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("UnityEngine");
			UnityEngine_RigidbodyWrap.Register(state);
			int reference = state.GetMetaReference(typeof(UnityEngine.Rigidbody));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameModPackage(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2");
			Ballance2_GameModPackageWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameModPackage));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameModLoader(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2");
			Ballance2_GameModLoaderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameModLoader));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameUIMgr(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2");
			Ballance2_GameUIMgrWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameUIMgr));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameMgr(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2");
			Ballance2_GameMgrWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameMgr));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameBulider(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2");
			Ballance2_GameBuliderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameBulider));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameCommandManager(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2");
			Ballance2_GameCommandManagerWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameCommandManager));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_Utils_BFSReader(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.Utils");
			Ballance2_Utils_BFSReaderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.Utils.BFSReader));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_Utils_KeyListener(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.Utils");
			Ballance2_Utils_KeyListenerWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.Utils.KeyListener));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_Utils_ZipFileReader(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.Utils");
			Ballance2_Utils_ZipFileReaderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.Utils.ZipFileReader));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UIDropDown(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UIDropDownWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UIDropDown));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UIImage(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UIImageWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UIImage));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UIMulitButton(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UIMulitButtonWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UIMulitButton));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UISlider(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UISliderWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UISlider));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UIText(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UITextWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UIText));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UIToggle(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UIToggleWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UIToggle));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElements_UIButton(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.UIElements");
			Ballance2_UI_UIElements_UIButtonWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElements.UIButton));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_LayoutUI_UIVerticalLayoutMenu(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.LayoutUI");
			Ballance2_UI_LayoutUI_UIVerticalLayoutMenuWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.LayoutUI.UIVerticalLayoutMenu));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_LayoutUI_UIAutoLayoutMenu(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.LayoutUI");
			Ballance2_UI_LayoutUI_UIAutoLayoutMenuWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.LayoutUI.UIAutoLayoutMenu));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_Utils_EventTriggerListener(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.Utils");
			Ballance2_UI_Utils_EventTriggerListenerWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.Utils.EventTriggerListener));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_Utils_FadeHlper(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI.Utils");
			Ballance2_UI_Utils_FadeHlperWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.Utils.FadeHlper));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIBallanceClassicalMenu(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI");
			Ballance2_UI_UIBallanceClassicalMenuWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIBallanceClassicalMenu));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIElement(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI");
			Ballance2_UI_UIElementWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIElement));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIMenu(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI");
			Ballance2_UI_UIMenuWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIMenu));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_UI_UIPage(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.UI");
			Ballance2_UI_UIPageWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.UI.UIPage));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaOpen_Ballance2_GameUIMgr_StandardUIMaker(IntPtr L)
	{
		try
		{
			LuaState state = LuaState.Get(L);
			state.BeginPreModule("Ballance2.GameUIMgr");
			Ballance2_GameUIMgr_StandardUIMakerWrap.Register(state);
			int reference = state.GetMetaReference(typeof(Ballance2.GameUIMgr.StandardUIMaker));
			state.EndPreModule(L, reference);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

