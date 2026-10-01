using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation
{
    public class GameUICameraView : UIElement
    {
        protected override void OnAdd()
        {
            Element.RegisterCallback<GeometryChangedEvent>(OnAttached);
            
            var root = G.Resolve<UI>().UIRoot;
            var container = root.Q<VisualElement>("CameraViewPanel");
            container.Add(Element);
            
            Element.dataSource = Main.GameData;
        }

        private void OnAttached(GeometryChangedEvent evt)
        {
            var pixelBlockSize = Main.GameData.CameraViewPixelBlockSize;
            
            var el = Element.Q<VisualElement>("CameraView");
            var panelWidth = el.panel.visualTree.worldBound.width;
            
            var scale = Screen.width / panelWidth;
            var pxW = Mathf.RoundToInt(el.worldBound.width * scale);
            var pxH = Mathf.RoundToInt(el.worldBound.height * scale);
            
            var pixelSize = new Vector4(pxW / pixelBlockSize, pxH / pixelBlockSize, 0f, 0f);
            Main.GameData.CameraViewPixelation = pixelSize;
        }

        protected override void OnRemove()
        {
            Element.UnregisterCallback<GeometryChangedEvent>(OnAttached);
            
            var root = G.Resolve<UI>().UIRoot;
            var container = root.Q<VisualElement>("CameraViewPanel");
            container.Remove(Element);
        }
    }
}