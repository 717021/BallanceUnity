using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class AssetBundleMaker
{
    [DllImport("user32.dll")]
    static extern int MessageBoxW(System.IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]string titl, [MarshalAs(UnmanagedType.LPWStr)]string text, int flag);

    [@MenuItem("AssetBundles/Build AssetBundle Test")]
    static void BuildABsPCTTestt()
    {
        Object[] selection2 = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
        for (int i = 0; i < selection2.Length; i++)
        {
            if (MessageBoxW(System.IntPtr.Zero, selection2[i].name, "Info", 0x0001) == 2)
                break;
        }
    }
    [@MenuItem("AssetBundles/Build AssetBundle From Selection PC")]
    static void BuildABsPCSel()
    {
        BuildABsSelC(BuildTarget.StandaloneWindows);
    }
    [@MenuItem("AssetBundles/Build AssetBundle From Selection Mac")]
    static void BuildABsMacSel()
    {
        BuildABsSelC(BuildTarget.StandaloneOSX);
    }
    [@MenuItem("AssetBundles/Build AssetBundle From Selection Android")]
    static void BuildABsSel()
    {
        BuildABsSelC(BuildTarget.Android);
    }
    [@MenuItem("AssetBundles/Build AssetBundle From Selection IOS")]
    static void BuildABsIosSel()
    {
        BuildABsSelC(BuildTarget.iOS);
    }

    static void BuildABsSelC(BuildTarget type)
    {
        string path = "";
        var option = EditorUtility.DisplayDialogComplex(
            "要保存为什么格式?",
            "Please choose one of the following options.",
            "unity3d",
            "assetbundle",
            "Cancel");
        switch (option)
        {
            case 0:
                path = EditorUtility.SaveFilePanel("Save Resource", @"F:\Game\Ballance2\Debug\Temp", "New Resource", "unity3d");
                break;
            case 1:
                path = EditorUtility.SaveFilePanel("Save Resource", @"F:\Game\Ballance2\Debug\Temp", "New Resource", "assetbundle");
                break;
            case 2:
                return;
        }
        if (path.Length != 0)
        {
            Object[] selection2 = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
            Object[] selection = new Object[selection2.Length + 1];
            for (int i = 0; i < selection2.Length; i++)
                selection[i] = selection2[i];
            selection[selection2.Length] = AssetDatabase.LoadAssetAtPath("Assets/Version.txt", typeof(Object));
            BuildPipeline.BuildAssetBundle(Selection.activeObject, selection, path, BuildAssetBundleOptions.CollectDependencies, type);
        }
    }
}
