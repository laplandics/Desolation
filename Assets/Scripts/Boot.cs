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
            G.Register(new Coroutines());
            
            G.Resolve<Coroutines>().Start(LoadGame());
        }

        private IEnumerator LoadGame()
        {
            yield return G.Resolve<Scenes>().ToBoot();
            yield return G.Resolve<Scenes>().ToScene("Game");
            yield return null;

            yield return G.Resolve<UI>().SetUI();
            yield return null;
            
            var game = new GameBoot();
            yield return game.Boot();
            
            Resources.UnloadUnusedAssets();
            yield return null;
        }
    }
}