using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation
{
    public static class R
    {
        public static void Reload() { UIAssetsLoader.LoadAssets(); }
        
        public static PanelSettings UISettings => Resources.Load<PanelSettings>("UIAssets/UISettings");
        public static VisualTreeAsset GameUIRoot => Resources.Load<VisualTreeAsset>("UIAssets/GameUIRoot");
        public static GameData GameDataTemplate => Resources.Load<GameData>("Data/GameData");
        public static Shader PixelationUIShader => Resources.Load<Shader>("Shaders/PixelationUIShader");

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
    }
}