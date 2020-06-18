using UnityEngine;

public static class GameConfigs
{
    //资源管理器 加载模式
    public static AssetLoadMode LoadAssetMode = AssetLoadMode.AssetBundler;



#if UNITY_ANDROID
	static string curPlatformName = "android";
#elif UNITY_IPHONE
	static string curPlatformName = "iphone";
#else
    static string curPlatformName = "mac";
#endif

    //当前平台名
    public static string CurPlatformName { get { return curPlatformName; } }



    //资源服务器url
    public static string ResServerUrl = "http://127.0.0.1/ResServer";


    //(该文件夹只能读,打包时被一起写入包内,第一次运行游戏把该文件夹数据拷贝到本地ab包路径下) 
    public static string StreamingAssetABRootPath = Application.streamingAssetsPath + "/" + curPlatformName;
    //streamingasset目录下的manifest文件路径
    public static string StreamingAssetManifestPath = Application.streamingAssetsPath + "/" + curPlatformName + "/" + curPlatformName;

    //游戏资源文件路径
    public static string GameResPath = Application.dataPath + "/GameRes";
    //打包资源的输出文件夹
    public static string GameResExportPath = Application.streamingAssetsPath + "/" + curPlatformName;

    

    //本地ab包根路径(该文件夹可读可写,从资源服务器更新的数据也放在这里)
    public static string LocalABRootPath = Application.persistentDataPath + "/DownLoad/" + curPlatformName;
    // 本地manifest文件路径
    public static string LocalManifestPath = Application.persistentDataPath + "/DownLoad/" + curPlatformName + "/" + curPlatformName;

    
    //资源服务器ab包根路径
    public static string OnlineABRootPath = ResServerUrl + "/" + curPlatformName;
    //资源服务器manifest文件路径
    public static string OnlineManifestPath = ResServerUrl + "/" + curPlatformName + "/"+curPlatformName;
    
    



    //临时数据存放 缓存
    //public static string TmpPath = Application.temporaryCachePath + "/Cache/" + curPlatformName;

    //服务器版本号url
    public static string ServerVersionUrl = "http://127.0.0.1/ResServer/version.txt";









    #region game res path
    private static string assetRoot {
        get {
            if (LoadAssetMode == AssetLoadMode.Editor) { 
                return GameResPath;
            } else {
                return StreamingAssetABRootPath;
            }
        }
    }

    //ui预制体路径
    public static string GetUIPath(string prefabName) {
        string str = "/Prefabs/UI/" + prefabName;
        if (LoadAssetMode != AssetLoadMode.Editor) {
            str = str.ToLower();
        } else {
            str = str + ".prefab";
        }
        return assetRoot + str;
    }

    //图集路径
    public static string GetSpriteAtlasPath(string name) {
        string str = "/Atlas/" + name;
        if (LoadAssetMode != AssetLoadMode.Editor) {
            str = str.ToLower();
        } else {
            str = str + ".spriteatlas";
        }
        return assetRoot + str;
    }

    public static string GetSpritePath(string name) {
        string str = "/textures/" + name;
        if (LoadAssetMode != AssetLoadMode.Editor) {
            str = str.ToLower();
        } else {
            str = str + ".png";
        }
        return assetRoot + str;
    }
    // todo:  扩展...
    
    #endregion
}
