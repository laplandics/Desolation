using UnityEngine;

namespace Desolation
{
    public static class Main
    {
        public static bool IsPlaying { get; private set; }
        public static void BeginGame() => IsPlaying = true;
        public static void EndGame() => IsPlaying = false;
        
        public static bool IsOnHardPause { get; private set; }
        public static void HardPauseGame() => IsOnHardPause = true;
        
        public static bool IsOnSoftPause { get; private set; }
        public static void SoftPauseGame() => IsOnSoftPause = true;
        
        public static void ResumeGame() { IsOnHardPause = false; IsOnSoftPause = false; }

        public static bool IsCursorVisible { get; private set; }
        public static void HideCursor() { IsCursorVisible = false; Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; }
        public static void ShowCursor() { IsCursorVisible = true; Cursor.visible = true; Cursor.lockState = CursorLockMode.None; }
    }
}