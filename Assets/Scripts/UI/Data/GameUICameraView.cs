using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation.UIBinders
{
    [CreateAssetMenu(fileName = "GameUICameraView", menuName = "Data/GameUICameraViewData")]
    public class GameUICameraView : UIData
    {
        public override VisualElement Root => G.Resolve<UI>().UIRoot.Q<VisualElement>("CameraViewPanel");
    }
}