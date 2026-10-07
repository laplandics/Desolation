using UnityEngine;
using UnityEngine.UIElements;

namespace Desolation.UIBinders
{
    [CreateAssetMenu(fileName = "GameUIMainScreen", menuName = "Data/GameUIMainScreenData")]
    public class GameUIMainScreen : UIData
    {
        public override VisualElement Root => G.Resolve<UI>().UIRoot;
    }
}