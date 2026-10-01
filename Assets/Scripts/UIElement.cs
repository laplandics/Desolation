using System;
using UnityEngine.UIElements;

namespace Desolation
{
    public abstract class UIElement
    {
        protected VisualElement Element;
        private string _id;
        
        public string Add()
        {
            var assetName = GetType().Name;
            var asset = R.UIAssetsLoader.GetAsset(assetName);
            
            if (asset == null) return null;
            var templateContainer = asset.Instantiate();
            Element = templateContainer.Q<VisualElement>("UIElement");
            
            Element.RegisterCallback<DetachFromPanelEvent>(DetachedCallback);
            
            _id = Guid.NewGuid().ToString();
            G.Resolve<UI>().RegisterUIElement(_id, this);
            
            OnAdd();
            return _id;
        }
        
        public void Remove() { UnregisterElement(); ClearCallback(); OnRemove(); }

        private void DetachedCallback(DetachFromPanelEvent evt)
        { UnregisterElement(); ClearCallback(); OnDetached(); }
        
        private void ClearCallback() => Element?.UnregisterCallback<DetachFromPanelEvent>(DetachedCallback);
        private void UnregisterElement() => G.Resolve<UI>().UnregisterUIElement(_id);
        
        protected abstract void OnAdd();
        protected abstract void OnRemove();
        
        protected virtual void OnDetached() {}
    }
}