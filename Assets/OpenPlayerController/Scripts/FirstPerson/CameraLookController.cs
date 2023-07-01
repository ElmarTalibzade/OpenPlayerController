using UnityEngine;
using OpenPlayerController.Common;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(Transform))]
    public class CameraLookController : MonoBehaviour
    {
        private float _currentXRotationVelocity;
        private float _currentYRotationVelocity;

        private float _currentXRotation;
        private float _currentYRotation;

        private Transform _transform;

        public CameraLookData Data;

        public Quaternion GetCameraRotation() => _transform.rotation;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }

        public void Look(Vector2 direction)
        {
            var rotationX = direction.x * Data.LookSensitivity;
            var rotationY = Mathf.Clamp(-direction.y * Data.LookSensitivity, Data.MinimumVerticalRotation, Data.MaximumVerticalRotation);

            _currentXRotation = Mathf.SmoothDamp(_currentXRotation, rotationX, ref _currentXRotationVelocity, Data.LookSmoothDamp);
            _currentYRotation = Mathf.SmoothDamp(_currentYRotation, rotationY, ref _currentYRotationVelocity, Data.LookSmoothDamp);
        }

        private void LateUpdate()
        {
            _transform.rotation = Quaternion.Euler(_currentXRotation, _currentYRotation, 0);
        }
    }
}