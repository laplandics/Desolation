using System.Collections;
using UnityEngine.SceneManagement;

namespace Desolation
{
    public class Scenes
    {
        private const string BOOT = "Boot";
        private const string GAME = "Game";
        
        public IEnumerator LoadGameScene()
        {
            yield return SceneManager.LoadSceneAsync(BOOT);
            yield return null;

            yield return SceneManager.LoadSceneAsync(GAME);
            yield return null;

            yield return new GameBoot().Boot();
            yield return null;
        }
        
        public IEnumerator LoadSceneAdditive(ISceneBoot sceneBoot)
        {
            var sceneName = sceneBoot.SceneName;
            
            var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (op == null) { throw new System.Exception($"Failed to load scene {sceneName}"); }
            
            yield return op;
            yield return null;
            
            var loaded = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(loaded);
            
            yield return sceneBoot.Boot();
            yield return null;
        }

        public IEnumerator UnLoadAdditiveScene(string sceneName, string mainSceneName = GAME)
        {
            var mainScene = SceneManager.GetSceneByName(mainSceneName);
            SceneManager.SetActiveScene(mainScene);
            
            var op = SceneManager.UnloadSceneAsync(sceneName);
            if (op == null) throw new System.Exception($"Failed to unload scene {sceneName}");
            
            yield return op;
            yield return null;
        }
    }
}
