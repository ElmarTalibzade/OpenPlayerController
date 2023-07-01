using UnityEngine;
using OpenPlayerController.Common;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(JumpController))]
    [RequireComponent(typeof(CameraLookController))]
    public class MovementController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private JumpController _jumpController;
        private CameraLookController _cameraLookController;

        private float _currentSpeed;

        private Vector3 _moveDirection;

        public MovementData Data;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _jumpController = GetComponent<JumpController>();
            _cameraLookController = GetComponent<CameraLookController>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);
        }

        public void Move(Vector2 direction)
        {
            transform.eulerAngles = new Vector3(0, _cameraLookController.GetCameraRotation().y, 0);
            _moveDirection = new Vector3(direction.x * _currentSpeed, -Data.Gravity, direction.y * _currentSpeed);
            _moveDirection = transform.TransformDirection(_moveDirection);
        }
    }
}