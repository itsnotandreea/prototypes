using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/ Build AssetBundle")]
    static void BuildAssetBundle()
    {
        string folderName = "AssetBundle";
        string filePath = Path.Combine(Application.streamingAssetsPath, folderName);

        BuildPipeline.BuildAssetBundles(filePath, BuildAssetBundleOptions.ChunkBasedCompression, EditorUserBuildSettings.activeBuildTarget);

        AssetDatabase.Refresh();
    }
    /*
    [MenuItem("Assets/ ChangeBundleName")]
    public static void ChangeBundleName()
    {
        string assetPath = AssetDatabase.GetAssetPath(Selection.activeInstanceID);
        AssetImporter.GetAtPath(assetPath).SetAssetBundleNameAndVariant("artworks", "");
    }
    */
    [MenuItem("Assets/ ChangeBundles")]
    static void List()
    {
        string assetPath = string.Empty;
        string bundleName = string.Empty;

        foreach (var assetGuid in AssetDatabase.FindAssets("", new[] { "Application.streamingAssetsPath/AssetBundle" }))
        {
            assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
            bundleName = AssetImporter.GetAtPath(assetPath).assetBundleName;

            Debug.Log(AssetDatabase.GUIDToAssetPath(assetGuid));

            if (string.IsNullOrEmpty(bundleName))
            {
                continue;
            }
        }
    }

}
