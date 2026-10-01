using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation
{
    public class UI
    {
        private bool _isUIReady;
        private VisualElement _root;
        private readonly Dictionary<string, UIElement> _uiElementsMap = new();

        public VisualElement UIRoot => _root.Q<VisualElement>("ROOT");
        
        public IEnumerator SetUI()
        {
            if (_isUIReady) yield break; 
            _isUIReady = false;

            var rendererObject = new GameObject("UI");
            var renderer = rendererObject.AddComponent<PanelRenderer>();
            renderer.panelSettings = R.UISettings;
            renderer.visualTreeAsset = R.GameUIRoot;
            
            renderer.UnregisterUIReloadCallback(OnUIReload);
            renderer.RegisterUIReloadCallback(OnUIReload);
            
            yield return new WaitUntil(() => _isUIReady);
        }

        public UIElement GetUIElement(string id) => _uiElementsMap[id];
        
        public void RegisterUIElement(string id, UIElement element)
        { _uiElementsMap.Add(id, element); }
        
        public void UnregisterUIElement(string id) => _uiElementsMap.Remove(id);
        
        private void OnUIReload(PanelRenderer param0, VisualElement root, int param1)
        { _root = root; _isUIReady = true; }
    }
}