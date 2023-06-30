using OpenPlayerController.Common;
using UnityEngine;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovementController : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        public PlayerMovementData Data;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector2 direction)
        {
            
        }
    }
}