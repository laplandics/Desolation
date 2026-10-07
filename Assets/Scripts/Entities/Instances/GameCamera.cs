using System.Collections;
using System.Collections.Generic;
using Desolation.EditorTools;
using Unity.Cinemachine;
using UnityEngine;

namespace Desolation
{
    public enum CameraAngles { Left, Center, Right }
    public class GameCamera : Entity
    {
        // Unity serializes dictionaries only with SerializeField attribute
        // ReSharper disable once Unity.RedundantSerializeFieldAttribute
        // ReSharper disable once InconsistentNaming
        // ReSharper disable once CollectionNeverUpdated.Local
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        [SerializeField] private Dictionary<CameraAngles, float> anglesMap = new();
        [SerializeField] private CinemachineOrbitalFollow follow;

        [Header("Camera Preferences")]
        [SerializeField] private float timeToChangeParent;
        
        private Transform _target;
        private Transform _currentParent;
        
        protected override void OnInitialize()
        {
            _target = transform.Find("Target");
            if (_target == null)
            { Debug.Log($"{nameof(GameCamera)}: Target not found"); }

            G.Resolve<Coroutines>().Start(FollowParentRoutine(), this);
        }
        
        public void SetAngle(CameraAngles newAngle) => follow.HorizontalAxis.Value = anglesMap[newAngle];
        public void SetParent(Transform parent) { _currentParent = parent; }

        private IEnumerator FollowParentRoutine()
        {
            while (Main.IsPlaying)
            {
                if (_currentParent != null)
                { _target.position = _currentParent.position; }
                yield return null;
            }
        }
        
        [Button] private void SetAngleLeft() => SetAngle(CameraAngles.Left);
        [Button] private void SetAngleCenter() => SetAngle(CameraAngles.Center);
        [Button] private void SetAngleRight() => SetAngle(CameraAngles.Right);
    }
}