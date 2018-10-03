using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaComponent : MonoBehaviour
{
    /// <summary>
    /// Parent GameModPackage
    /// </summary>
    public GameModPackage ModPackage { get; set; }
    /// <summary>
    /// 全局的Lua虚拟机  
    /// </summary>
    public LuaState LuaState;
    /// <summary>
    /// 绑定的LUA脚本路径
    /// </summary>
    [Tooltip("绑定的LUA脚本路径")]
    public TextAsset LuaScript;
    public string LuaScriptAssetPath { get; set; }
    public LuaTable LuaModule
    {
        get;
        private set;
    }

    private LuaFunction m_luaUpdate;    // Lua实现的Update函数，可能为null  
    private LuaFunction m_luaEnable;    // Lua实现的Update函数，可能为null  
    private LuaFunction m_luaDisable;    // Lua实现的Update函数，可能为null  

    /// <summary>  
    /// 找到游戏对象上绑定的LUA组件（Module对象）  
    /// </summary>  
    public static LuaTable GetLuaComponent(GameObject go)
    {
        LuaComponent luaComp = go.GetComponent<LuaComponent>();
        if (luaComp == null)
            return null;
        return luaComp.LuaModule;
    }

    /// <summary>  
    /// 向一个GameObject添加一个LUA组件  
    /// </summary>  
    public static LuaTable AddLuaComponent(GameObject go, TextAsset luaFile)
    {
        LuaComponent luaComp = go.AddComponent<LuaComponent>();
        luaComp.Initilize(luaFile);  // 手动调用脚本运行，以取得LuaTable返回值  
        return luaComp.LuaModule;
    }

    /// <summary>  
    /// 提供给外部手动执行LUA脚本的接口  
    /// </summary>  
    public void Initilize(TextAsset luaFile)
    {
        LuaScript = luaFile;
        RunLuaFile(luaFile);

        LuaGetFuns();
    }

    /// <summary>  
    /// 调用Lua虚拟机，执行一个脚本文件  
    /// </summary>  
    private void RunLuaFile(TextAsset luaFile)
    {
        if (luaFile == null || string.IsNullOrEmpty(luaFile.text))
            return;

        if (LuaState == null) LuaState = new LuaState();

        object[] luaRet = LuaState.DoString<object[]>(luaFile.text, luaFile.name);
        if (luaRet != null && luaRet.Length >= 1)
        {
            // 约定：第一个返回的Table对象作为Lua模块  
            this.LuaModule = luaRet[0] as LuaTable;
        }
        else
        {
            Debug.LogError("Lua脚本没有返回Table对象：" + luaFile.name);
        }
    }
    private void LuaGetFuns()
    {
        //-- 取得常用的函数回调  
        if (this.LuaModule != null)
        {
            m_luaUpdate = this.LuaModule["Update"] as LuaFunction;
            m_luaEnable = this.LuaModule["OnEnable"] as LuaFunction;
            m_luaDisable = this.LuaModule["OnDisable"] as LuaFunction;
        }
    }

    private void OnApplicationQuit()
    {
        CallLuaFunction("OnApplicationQuit", this.LuaModule, this.gameObject);
    }
    private void OnEnable()
    {
        if (m_luaEnable != null)
            m_luaEnable.Call(this.LuaModule, this.gameObject);
    }
    private void OnDisable()
    {
        if (m_luaDisable != null)
            m_luaDisable.Call(this.LuaModule, this.gameObject);
    }
    private void Awake()
    {
        RunLuaFile(LuaScript);
        CallLuaFunction("Awake", this.LuaModule, this.gameObject);
        LuaGetFuns();
    }
    private void Start()
    {
        CallLuaFunction("Start", this.LuaModule, this.gameObject);
    }
    private void Update()
    {
        if (m_luaUpdate != null)
            m_luaUpdate.Call(this.LuaModule, this.gameObject);
    }
    private void OnDestroy()
    {
        CallLuaFunction("OnDestroy", this.LuaModule, this.gameObject);

        if (LuaState != ModPackage.LuaState)
        {
            LuaState.CheckTop();
            LuaState.Dispose();
        }
    }

    /// <summary>  
    /// 调用一个Lua组件中的函数  
    /// </summary>  
    void CallLuaFunction(string funcName, params object[] args)
    {
        if (LuaModule == null)
            return;
        LuaFunction func = this.LuaModule[funcName] as LuaFunction;
        if (func != null) func.Call(args);
    }
}
