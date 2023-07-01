using UnityEngine;

namespace OpenPlayerController.FirstPerson
{
    [RequireComponent(typeof(JumpController))]
    [RequireComponent(typeof(MovementController))]
    [RequireComponent(typeof(CameraLookController))]
    public class InputController : MonoBehaviour
    {
        private CameraLookController _cameraLookController;
        private MovementController _movementController;
        private JumpController _jumpController;

        private void Start()
        {
            _cameraLookController = GetComponent<CameraLookController>();
            _movementController = GetComponent<MovementController>();
            _jumpController = GetComponent<JumpController>();
        }

        private void Update()
        {
            _movementController.Move(new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            ));

            _cameraLookController.Look(new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")
            ));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpController.Jump();
            }
        }
    }
}