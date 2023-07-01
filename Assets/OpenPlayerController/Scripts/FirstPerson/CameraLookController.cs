using UnityEngine;
using OpenPlayerController.Common;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(Transform))]
    [AddComponentMenu("Open Player Controller/First Person/Camera Look Controller")]
    public class CameraLookController : MonoBehaviour
    {
        private float _currentXRotationVelocity;
        private float _currentYRotationVelocity;

        private Vector2 _desiredRotation;
        private Vector2 _currentRotation;

        private Transform _transform;

        public CameraLookData Data;

        public float GetYRotation() => _currentRotation.y;

        private void Start()
        {
            _transform = GetComponent<Transform>();
        }

        public void Look(Vector2 direction)
        {
            _desiredRotation.x += direction.x * Data.LookSensitivity;
            _desiredRotation.y += Mathf.Clamp(-direction.y * Data.LookSensitivity, Data.MinimumVerticalRotation, Data.MaximumVerticalRotation);

            _currentRotation.x = Mathf.SmoothDamp(_currentRotation.x, _desiredRotation.y, ref _currentXRotationVelocity, Data.LookSmoothDamp);
            _currentRotation.y = Mathf.SmoothDamp(_currentRotation.y, _desiredRotation.x, ref _currentYRotationVelocity, Data.LookSmoothDamp);
        }

        private void LateUpdate()
        {
            _transform.rotation = Quaternion.Euler(_currentRotation.x, _currentRotation.y, 0);
        }
    }
}