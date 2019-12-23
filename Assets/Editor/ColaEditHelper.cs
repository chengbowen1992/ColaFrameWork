﻿//----------------------------------------------
//            ColaFramework
// Copyright © 2018-2049 ColaFramework 马三小伙儿
//----------------------------------------------

#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using ColaFramework.Foundation;

/// <summary>
/// ColaFramework 编辑器助手类
/// </summary>
public class ColaEditHelper
{

    /// <summary>
    /// 打开指定文件夹(编辑器模式下)
    /// </summary>
    /// <param name="path"></param>
    public static void OpenDirectory(string path)
    {
        if (string.IsNullOrEmpty(path)) return;

        path = path.Replace("/", "\\");
        if (!Directory.Exists(path))
        {
            Debug.LogError("No Directory: " + path);
            return;
        }

        System.Diagnostics.Process.Start("explorer.exe", path);
    }

    /// <summary>
    /// 合并Lua代码，并复制到StreamingAsset目录中准备打包
    /// </summary>
    public static void BuildLuaToStreamingAsset()
    {
        FileHelper.RmDir(LuaConst.streamingAssetLua);
        FileHelper.CopyDir(LuaConst.toluaDir, LuaConst.streamingAssetLua);
        FileHelper.CopyDir(LuaConst.luaDir, LuaConst.streamingAssetLua);
        AssetDatabase.Refresh();
    }
}

#endif
