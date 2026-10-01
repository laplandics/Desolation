using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Desolation
{
    public class Scenes
    {
        public IEnumerator ToBoot()
        {
            yield return SceneManager.LoadSceneAsync("Boot");
            yield return null;
        }

        public IEnumerator ToScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
            yield return null;
        }
        
        public IEnumerator LoadSceneAdditive(string sceneName, bool makeActive = false)
        {
            var op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            if (op == null) { throw new System.Exception($"Failed to load scene {sceneName}"); }
            
            yield return op;
            yield return null;
            
            if (!makeActive) yield break;
            var loaded = SceneManager.GetSceneByName(sceneName);
            SceneManager.SetActiveScene(loaded);
        }

        public IEnumerator UnLoadAdditiveScene(string sceneName, string mainSceneName = "Game")
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
