using System;
using UnityEngine;
using OpenPlayerController.Common;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(JumpController))]
    [AddComponentMenu("Open Player Controller/First Person/Movement Controller")]
    public class MovementController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private JumpController _jumpController;

        private Vector3 _moveDirection;

        public MovementData Data;
        public CameraLookController CameraLookController;

        private float MoveSpeed => Data.BaseSpeed * _jumpController.GetMovementMultiplier();

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _jumpController = GetComponent<JumpController>();
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector3(_moveDirection.x, _rigidbody.velocity.y, _moveDirection.z);
        }

        private void Update()
        {
            transform.eulerAngles = new Vector3(0, CameraLookController.GetYRotation(), 0);
        }

        public void Move(Vector2 direction)
        {
            _moveDirection = new Vector3(direction.x * MoveSpeed, -Data.Gravity, direction.y * MoveSpeed);
            _moveDirection = transform.TransformDirection(_moveDirection);
        }
    }
}