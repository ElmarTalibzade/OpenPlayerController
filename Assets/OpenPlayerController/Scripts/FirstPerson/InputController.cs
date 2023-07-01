using UnityEngine;

namespace OpenPlayerController.FirstPerson
{
    [AddComponentMenu("Open Player Controller/First Person/Input Controller")]
    public class InputController : MonoBehaviour
    {
        public CameraLookController CameraLookController;
        public MovementController MovementController;
        public JumpController JumpController;

        private void Update()
        {
            MovementController.Move(new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            ));

            CameraLookController.Look(new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")
            ));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpController.Jump();
            }
        }
    }
}