using UnityEngine;

namespace Desolation
{
    public static class Main
    {
        public static GameData GameData { get; private set; }
        public static void LoadGameData() => GameData = Object.Instantiate(R.GameDataTemplate);
        public static void UnloadGameData() => Object.Destroy(GameData);
        
        public static bool IsPlaying { get; private set; }
        public static void BeginGame() => IsPlaying = true;
        public static void EndGame() => IsPlaying = false;
        
        public static bool IsOnPause { get; private set; }
        public static void PauseGame() => IsOnPause = true;
        public static void ResumeGame() => IsOnPause = false;
    }
}