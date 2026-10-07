using System.Collections;
using UnityEngine;

namespace Desolation
{
    public class MainCharacter : Entity
    {
        private GameCamera _camera;
        
        protected override void OnInitialize()
        { G.Resolve<Coroutines>().Start(WaitForCameraRoutine(), this); }

        private IEnumerator WaitForCameraRoutine()
        { yield return new WaitUntil(() => G.Resolve<Entities>().TryGetEntity(out _camera)); SetCameraParent();}

        private void SetCameraParent() => _camera.SetParent(transform);
    }
}