using UnityEngine;

namespace OpenPlayerController.Legacy.OpenPlayerController.Scripts.FPController
{
    /// <summary>
    /// This component handles all user input, controlling other aspects of FPS Player such as jumping and climbing
    /// </summary>
    public class FPS_InputController : MonoBehaviour
    {
        private FPS_CameraLook component_CameraLook;
        private FPS_Jump component_Jump;
        private FPS_Locomotion component_Locomotion;
        private FPS_Crouch component_Crouch;

        void Start()
        {
            component_CameraLook = transform.GetChild(0).gameObject.GetComponent<FPS_CameraLook>();
            component_Jump = GetComponent<FPS_Jump>();
            component_Locomotion = GetComponent<FPS_Locomotion>();
            component_Crouch = GetComponent<FPS_Crouch>();
        }

        void Update()
        {
            component_Locomotion.Move(new Vector2(
                Input.GetAxis("Horizontal"),
                Input.GetAxis("Vertical")
            ));

            component_CameraLook.Look(new Vector2(
                Input.GetAxis("Mouse X"),
                Input.GetAxis("Mouse Y")
            ));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                component_Jump.Jump();
            }

            component_Crouch.ToggleCrouch(Input.GetKey(KeyCode.LeftControl));
        }
    }
}