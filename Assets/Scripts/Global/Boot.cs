using System.Collections;
using UnityEngine;

namespace Desolation
{
    public class Boot
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Bootstrap() => _ = new Boot();

        private Boot()
        {
            G.Reset();
            R.Reload();
            
            G.Register(new UI());
            G.Register(new Scenes());
            G.Register(new Inputs());
            G.Register(new States());
            G.Register(new Entities());
            G.Register(new Coroutines());

            G.Resolve<Coroutines>().Start(LoadGame());
        }

        private IEnumerator LoadGame()
        {
            Main.BeginGame();
            Main.HideCursor();
            yield return null;
            
            G.Resolve<States>().Activate();
            G.Resolve<Inputs>().Activate();
            yield return null;
            
            yield return G.Resolve<UI>().SetUI();
            yield return null;
            
            yield return G.Resolve<Scenes>().LoadGameScene();
            yield return null;
            
            Resources.UnloadUnusedAssets();
            yield return null;
        }
    }
}