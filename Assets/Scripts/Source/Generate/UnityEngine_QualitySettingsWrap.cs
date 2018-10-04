﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_QualitySettingsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginStaticLibs("QualitySettings");
		L.RegFunction("IncreaseLevel", IncreaseLevel);
		L.RegFunction("DecreaseLevel", DecreaseLevel);
		L.RegFunction("SetQualityLevel", SetQualityLevel);
		L.RegFunction("GetQualityLevel", GetQualityLevel);
		L.RegFunction("__eq", op_Equality);
		L.RegVar("pixelLightCount", get_pixelLightCount, set_pixelLightCount);
		L.RegVar("shadows", get_shadows, set_shadows);
		L.RegVar("shadowProjection", get_shadowProjection, set_shadowProjection);
		L.RegVar("shadowCascades", get_shadowCascades, set_shadowCascades);
		L.RegVar("shadowDistance", get_shadowDistance, set_shadowDistance);
		L.RegVar("shadowResolution", get_shadowResolution, set_shadowResolution);
		L.RegVar("shadowmaskMode", get_shadowmaskMode, set_shadowmaskMode);
		L.RegVar("shadowNearPlaneOffset", get_shadowNearPlaneOffset, set_shadowNearPlaneOffset);
		L.RegVar("shadowCascade2Split", get_shadowCascade2Split, set_shadowCascade2Split);
		L.RegVar("shadowCascade4Split", get_shadowCascade4Split, set_shadowCascade4Split);
		L.RegVar("lodBias", get_lodBias, set_lodBias);
		L.RegVar("anisotropicFiltering", get_anisotropicFiltering, set_anisotropicFiltering);
		L.RegVar("masterTextureLimit", get_masterTextureLimit, set_masterTextureLimit);
		L.RegVar("maximumLODLevel", get_maximumLODLevel, set_maximumLODLevel);
		L.RegVar("particleRaycastBudget", get_particleRaycastBudget, set_particleRaycastBudget);
		L.RegVar("softParticles", get_softParticles, set_softParticles);
		L.RegVar("softVegetation", get_softVegetation, set_softVegetation);
		L.RegVar("vSyncCount", get_vSyncCount, set_vSyncCount);
		L.RegVar("antiAliasing", get_antiAliasing, set_antiAliasing);
		L.RegVar("asyncUploadTimeSlice", get_asyncUploadTimeSlice, set_asyncUploadTimeSlice);
		L.RegVar("asyncUploadBufferSize", get_asyncUploadBufferSize, set_asyncUploadBufferSize);
		L.RegVar("realtimeReflectionProbes", get_realtimeReflectionProbes, set_realtimeReflectionProbes);
		L.RegVar("billboardsFaceCameraPosition", get_billboardsFaceCameraPosition, set_billboardsFaceCameraPosition);
		L.RegVar("resolutionScalingFixedDPIFactor", get_resolutionScalingFixedDPIFactor, set_resolutionScalingFixedDPIFactor);
		L.RegVar("blendWeights", get_blendWeights, set_blendWeights);
		L.RegVar("streamingMipmapsActive", get_streamingMipmapsActive, set_streamingMipmapsActive);
		L.RegVar("streamingMipmapsMemoryBudget", get_streamingMipmapsMemoryBudget, set_streamingMipmapsMemoryBudget);
		L.RegVar("streamingMipmapsRenderersPerFrame", get_streamingMipmapsRenderersPerFrame, set_streamingMipmapsRenderersPerFrame);
		L.RegVar("streamingMipmapsMaxLevelReduction", get_streamingMipmapsMaxLevelReduction, set_streamingMipmapsMaxLevelReduction);
		L.RegVar("streamingMipmapsAddAllCameras", get_streamingMipmapsAddAllCameras, set_streamingMipmapsAddAllCameras);
		L.RegVar("streamingMipmapsMaxFileIORequests", get_streamingMipmapsMaxFileIORequests, set_streamingMipmapsMaxFileIORequests);
		L.RegVar("maxQueuedFrames", get_maxQueuedFrames, set_maxQueuedFrames);
		L.RegVar("names", get_names, null);
		L.RegVar("desiredColorSpace", get_desiredColorSpace, null);
		L.RegVar("activeColorSpace", get_activeColorSpace, null);
		L.EndStaticLibs();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IncreaseLevel(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.QualitySettings.IncreaseLevel();
				return 0;
			}
			else if (count == 1)
			{
				bool arg0 = LuaDLL.luaL_checkboolean(L, 1);
				UnityEngine.QualitySettings.IncreaseLevel(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.QualitySettings.IncreaseLevel");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecreaseLevel(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				UnityEngine.QualitySettings.DecreaseLevel();
				return 0;
			}
			else if (count == 1)
			{
				bool arg0 = LuaDLL.luaL_checkboolean(L, 1);
				UnityEngine.QualitySettings.DecreaseLevel(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.QualitySettings.DecreaseLevel");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetQualityLevel(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				UnityEngine.QualitySettings.SetQualityLevel(arg0);
				return 0;
			}
			else if (count == 2)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				bool arg1 = LuaDLL.luaL_checkboolean(L, 2);
				UnityEngine.QualitySettings.SetQualityLevel(arg0, arg1);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.QualitySettings.SetQualityLevel");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetQualityLevel(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			int o = UnityEngine.QualitySettings.GetQualityLevel();
			LuaDLL.lua_pushinteger(L, o);
			return 1;
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
	static int get_pixelLightCount(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.pixelLightCount);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadows(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.shadows);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowProjection(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.shadowProjection);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascades(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.shadowCascades);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowDistance(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.shadowDistance);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowResolution(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.shadowResolution);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowmaskMode(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.shadowmaskMode);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowNearPlaneOffset(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.shadowNearPlaneOffset);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascade2Split(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.shadowCascade2Split);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_shadowCascade4Split(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.shadowCascade4Split);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_lodBias(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.lodBias);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_anisotropicFiltering(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.anisotropicFiltering);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_masterTextureLimit(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.masterTextureLimit);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maximumLODLevel(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.maximumLODLevel);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_particleRaycastBudget(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.particleRaycastBudget);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_softParticles(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.softParticles);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_softVegetation(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.softVegetation);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_vSyncCount(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.vSyncCount);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_antiAliasing(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.antiAliasing);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asyncUploadTimeSlice(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.asyncUploadTimeSlice);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_asyncUploadBufferSize(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.asyncUploadBufferSize);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_realtimeReflectionProbes(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.realtimeReflectionProbes);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_billboardsFaceCameraPosition(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.billboardsFaceCameraPosition);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resolutionScalingFixedDPIFactor(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.resolutionScalingFixedDPIFactor);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_blendWeights(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.blendWeights);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingMipmapsActive(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.streamingMipmapsActive);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingMipmapsMemoryBudget(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushnumber(L, UnityEngine.QualitySettings.streamingMipmapsMemoryBudget);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingMipmapsRenderersPerFrame(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.streamingMipmapsRenderersPerFrame);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingMipmapsMaxLevelReduction(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.streamingMipmapsMaxLevelReduction);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingMipmapsAddAllCameras(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushboolean(L, UnityEngine.QualitySettings.streamingMipmapsAddAllCameras);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_streamingMipmapsMaxFileIORequests(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.streamingMipmapsMaxFileIORequests);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_maxQueuedFrames(IntPtr L)
	{
		try
		{
			LuaDLL.lua_pushinteger(L, UnityEngine.QualitySettings.maxQueuedFrames);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_names(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.names);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_desiredColorSpace(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.desiredColorSpace);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_activeColorSpace(IntPtr L)
	{
		try
		{
			ToLua.Push(L, UnityEngine.QualitySettings.activeColorSpace);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_pixelLightCount(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.pixelLightCount = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadows(IntPtr L)
	{
		try
		{
			UnityEngine.ShadowQuality arg0 = (UnityEngine.ShadowQuality)ToLua.CheckObject(L, 2, typeof(UnityEngine.ShadowQuality));
			UnityEngine.QualitySettings.shadows = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowProjection(IntPtr L)
	{
		try
		{
			UnityEngine.ShadowProjection arg0 = (UnityEngine.ShadowProjection)ToLua.CheckObject(L, 2, typeof(UnityEngine.ShadowProjection));
			UnityEngine.QualitySettings.shadowProjection = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascades(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.shadowCascades = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowDistance(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.shadowDistance = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowResolution(IntPtr L)
	{
		try
		{
			UnityEngine.ShadowResolution arg0 = (UnityEngine.ShadowResolution)ToLua.CheckObject(L, 2, typeof(UnityEngine.ShadowResolution));
			UnityEngine.QualitySettings.shadowResolution = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowmaskMode(IntPtr L)
	{
		try
		{
			UnityEngine.ShadowmaskMode arg0 = (UnityEngine.ShadowmaskMode)ToLua.CheckObject(L, 2, typeof(UnityEngine.ShadowmaskMode));
			UnityEngine.QualitySettings.shadowmaskMode = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowNearPlaneOffset(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.shadowNearPlaneOffset = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascade2Split(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.shadowCascade2Split = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_shadowCascade4Split(IntPtr L)
	{
		try
		{
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			UnityEngine.QualitySettings.shadowCascade4Split = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_lodBias(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.lodBias = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_anisotropicFiltering(IntPtr L)
	{
		try
		{
			UnityEngine.AnisotropicFiltering arg0 = (UnityEngine.AnisotropicFiltering)ToLua.CheckObject(L, 2, typeof(UnityEngine.AnisotropicFiltering));
			UnityEngine.QualitySettings.anisotropicFiltering = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_masterTextureLimit(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.masterTextureLimit = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maximumLODLevel(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.maximumLODLevel = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_particleRaycastBudget(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.particleRaycastBudget = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_softParticles(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.QualitySettings.softParticles = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_softVegetation(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.QualitySettings.softVegetation = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_vSyncCount(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.vSyncCount = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_antiAliasing(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.antiAliasing = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asyncUploadTimeSlice(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.asyncUploadTimeSlice = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_asyncUploadBufferSize(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.asyncUploadBufferSize = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_realtimeReflectionProbes(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.QualitySettings.realtimeReflectionProbes = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_billboardsFaceCameraPosition(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.QualitySettings.billboardsFaceCameraPosition = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_resolutionScalingFixedDPIFactor(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.resolutionScalingFixedDPIFactor = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_blendWeights(IntPtr L)
	{
		try
		{
			UnityEngine.BlendWeights arg0 = (UnityEngine.BlendWeights)ToLua.CheckObject(L, 2, typeof(UnityEngine.BlendWeights));
			UnityEngine.QualitySettings.blendWeights = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamingMipmapsActive(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.QualitySettings.streamingMipmapsActive = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamingMipmapsMemoryBudget(IntPtr L)
	{
		try
		{
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.streamingMipmapsMemoryBudget = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamingMipmapsRenderersPerFrame(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);

			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamingMipmapsMaxLevelReduction(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.streamingMipmapsMaxLevelReduction = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamingMipmapsAddAllCameras(IntPtr L)
	{
		try
		{
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			UnityEngine.QualitySettings.streamingMipmapsAddAllCameras = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_streamingMipmapsMaxFileIORequests(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.streamingMipmapsMaxFileIORequests = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_maxQueuedFrames(IntPtr L)
	{
		try
		{
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			UnityEngine.QualitySettings.maxQueuedFrames = arg0;
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

