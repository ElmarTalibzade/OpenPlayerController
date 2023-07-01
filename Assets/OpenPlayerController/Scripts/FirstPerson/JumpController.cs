using UnityEngine;
using OpenPlayerController.Common;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(Rigidbody))]
    public class JumpController : MonoBehaviour, IMovementMultiplier
    {
        private const float s_GroundedVerticalCheck = 0.1f;

        private Rigidbody _rigidBody;

        public JumpData Data;
        public Collider BodyCollider;

        public bool IsGrounded { get; private set; }
        public float GetMovementMultiplier() => IsGrounded ? 1.0f : Data.AirborneSpeedMultiplier;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            IsGrounded = Physics.Raycast(transform.position, -Vector3.up, BodyCollider.bounds.extents.y + s_GroundedVerticalCheck);
        }

        public void Jump()
        {
            if (IsGrounded)
            {
                _rigidBody.AddForce(Vector3.up * Data.JumpForce, ForceMode.Impulse);
            }
        }
    }
}