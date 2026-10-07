using System.Collections;
using Desolation.Tools;
using UnityEngine.InputSystem;

namespace Desolation
{
    public enum KeyboardKeys { Q, W, E, R, T, Y, U, I, O, P, A, S, D, F, G,
        H, J, K, L, Z, X, C, V, B, N, M, Esc, Enter, Backspace }
    
    public class Inputs
    {
        private InputActions _inputs = new();
        
        public readonly Reactive<KeyboardKeys> PressedKey = new();
        
        public void Activate() => G.Resolve<Coroutines>().Start(InputsDetectionRoutine());

        private IEnumerator InputsDetectionRoutine()
        {
            while (Main.IsPlaying)
            {
                var keyBoard = Keyboard.current;
                if (keyBoard == null) { yield return null; continue; }
                
                if (keyBoard.qKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.Q;
                if (keyBoard.wKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.W;
                if (keyBoard.eKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.E;
                if (keyBoard.rKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.R;
                if (keyBoard.tKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.T;
                if (keyBoard.yKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.Y;
                if (keyBoard.uKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.U;
                if (keyBoard.iKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.I;
                if (keyBoard.oKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.O;
                if (keyBoard.pKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.P;
                if (keyBoard.aKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.A;
                if (keyBoard.sKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.S;
                if (keyBoard.dKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.D;
                if (keyBoard.fKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.F;
                if (keyBoard.gKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.G;
                if (keyBoard.hKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.H;
                if (keyBoard.jKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.J;
                if (keyBoard.kKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.K;
                if (keyBoard.lKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.L;
                if (keyBoard.zKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.Z;
                if (keyBoard.xKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.X;
                if (keyBoard.cKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.C;
                if (keyBoard.vKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.V;
                if (keyBoard.bKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.B;
                if (keyBoard.nKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.N;
                if (keyBoard.mKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.M;

                if (keyBoard.escapeKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.Esc;
                if (keyBoard.enterKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.Enter;
                if (keyBoard.backspaceKey.wasPressedThisFrame) PressedKey.Value = KeyboardKeys.Backspace;
                yield return null;
            }
        }
    }
}