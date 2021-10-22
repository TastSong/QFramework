using System.IO;
using UnityEngine;

namespace QFramework
{
    public enum HotfixCodeRunMode
    {
        ILRuntime,
        Reflection,
    }
    
    public class ILRuntimeScriptSetting : ScriptableObject
    {
        private static string ScriptObjectPath => $"Resources/{LoadPath}";
        private const string LoadPath = "Config/ILRuntimeConfig";
        private static ILRuntimeScriptSetting defaultVal;
        public static ILRuntimeScriptSetting Default
        {
            get
            {
                if (defaultVal != null) return defaultVal;
                defaultVal = Resources.Load<ILRuntimeScriptSetting>(LoadPath);
                if (defaultVal != null) return defaultVal;
                defaultVal = CreateInstance<ILRuntimeScriptSetting>();
                Save();
                return defaultVal;
            }
        }

        public static void Save()
        {
#if UNITY_EDITOR
            var filePath = $"{Application.dataPath}/{ScriptObjectPath}.asset";
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                UnityEditor.AssetDatabase.CreateAsset(defaultVal, $"Assets/{ScriptObjectPath}.asset");
            }
            UnityEditor.EditorUtility.SetDirty(Default);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();
#endif
        }

        public HotfixCodeRunMode HotfixRunMode = HotfixCodeRunMode.Reflection;
        public string GenAdaptorPath = "QFramework/Scripting/ScriptKitILRuntime/ILRuntime/Adapter";
        public string GenClrBindPath = "QFrameworkData/ScriptKitILRuntimeCLRBindingCodeGen";
        public string HotfixDllName = "Game@hotfix";
        public string GameDllName = "Game";
        public string DllOutPath = "Assets/Res/Hotfix";
        public string HotfixDllPath => Path.Combine(this.DllOutPath, this.HotfixDllName, ".dll.bytes");
        public string HotfixPdbPath => Path.Combine(this.DllOutPath, this.HotfixDllName, ".pdb.bytes");
        [HideInInspector]
        public bool UsePdb = false;

        public bool AutoCompile = false;
    }
}