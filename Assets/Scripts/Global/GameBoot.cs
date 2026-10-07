using System.Collections;
using Desolation.UIBinders;
using UnityEngine;

namespace Desolation
{
    public class GameBoot
    {
        public IEnumerator Boot()
        {
            foreach (var entity in Object.FindObjectsByType<Entity>())
            { entity.Initialize(); yield return null; }
            yield return null;
            
            G.Resolve<UI>().NewUIElement(nameof(GameUIMainScreen)).Add();
            G.Resolve<UI>().NewUIElement(nameof(GameUICameraView)).Add();
            yield return null;
            
            yield return G.Resolve<Scenes>().LoadSceneAdditive(new TestScene());
            yield return null;

            G.Resolve<States>().ChangeState<ConsoleState>();
            yield return null;
        }
    }
}