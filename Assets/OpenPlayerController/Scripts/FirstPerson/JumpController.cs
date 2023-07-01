using UnityEngine;
using OpenPlayerController.Common;

 namespace OpenPlayerController.FirstPerson
 {
     [RequireComponent(typeof(Rigidbody))]
     [RequireComponent(typeof(Collider))]
     public class JumpController : MonoBehaviour, IMovementMultiplier
     {
         private const float s_GroundedVerticalCheck = 0.01f;

         private Rigidbody _rigidBody;
         private Collider _collider;

         public JumpData Data;

         public bool IsGrounded() => Physics.Raycast(transform.position, -Vector3.up, _collider.bounds.extents.y + s_GroundedVerticalCheck);
         public float GetMovementMultiplier() => IsGrounded() ? 1.0f : Data.AirborneSpeedMultiplier;

         private void Start()
         {
             _collider = GetComponent<Collider>();
             _rigidBody = GetComponent<Rigidbody>();
         }

         public void Jump()
         {
             if (IsGrounded())
             {
                 _rigidBody.AddForce(Vector3.up * Data.JumpForce, ForceMode.Impulse);
             }
         }
     }
 }