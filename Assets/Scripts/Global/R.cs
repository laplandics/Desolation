using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation
{
    public static class R
    {
        public static void Reload()
        {
            PrefabsLoader.LoadPrefabs();
            UIAssetsLoader.LoadAssets();
            UIBindersLoader.LoadBinders();
        }
        
        public static PanelSettings UISettings => Resources.Load<PanelSettings>("UIAssets/UISettings");
        public static VisualTreeAsset GameUIRoot => Resources.Load<VisualTreeAsset>("UIAssets/GameUIRoot");
        
        public static Shader PixelationUIShader => Resources.Load<Shader>("Shaders/PixelationUIShader");

        public static class PrefabsLoader
        {
            private static readonly Dictionary<string, GameObject> PrefabsMap = new();

            public static void LoadPrefabs()
            {
                PrefabsMap.Clear();
                var prefabs = Resources.LoadAll<GameObject>("Prefabs");
                foreach (var prefab in prefabs)
                { PrefabsMap.Add(prefab.name, prefab); }
            }
            
            public static GameObject GetPrefab(string name) => PrefabsMap[name];
        }
        
        public static class UIAssetsLoader
        {
            private static readonly Dictionary<string, VisualTreeAsset> AssetsMap = new();

            public static void LoadAssets()
            {
                AssetsMap.Clear();
                var assets = Resources.LoadAll<VisualTreeAsset>("UIAssets");
                
                foreach (var asset in assets)
                { AssetsMap.Add(asset.name, asset); }
            }
            
            public static VisualTreeAsset GetAsset(string name) => AssetsMap[name];
        }

        public static class UIBindersLoader
        {
            private static readonly Dictionary<string, UIData> BindersMap = new();

            public static void LoadBinders()
            {
                BindersMap.Clear();
                var binders = Resources.LoadAll<UIData>("Data");
                
                foreach (var binder in binders)
                { BindersMap.Add(binder.name, binder); }
            }
            
            public static UIData GetBinder(string name) => BindersMap[name];
        }
    }
}