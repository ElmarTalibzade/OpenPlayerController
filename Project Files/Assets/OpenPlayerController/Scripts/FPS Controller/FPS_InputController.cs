using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This component handles all user input, controlling other aspects of FPS Player such as jumping and climbing
/// </summary>
public class FPS_InputController : MonoBehaviour
{
    private FPS_CameraLook component_CameraLook;
    private FPS_Climb component_Climb;
    private FPS_Jump component_Jump;
    private FPS_Locomotion component_Locomotion;
    private FPS_Crouch component_Crouch;
    
    void Start()
    {
        component_CameraLook = transform.GetChild(0).gameObject.GetComponent<FPS_CameraLook>();
        component_Climb = GetComponent<FPS_Climb>();
        component_Jump = GetComponent<FPS_Jump>();
        component_Locomotion = GetComponent<FPS_Locomotion>();
        component_Crouch = GetComponent<FPS_Crouch>();
    }

    void Update()
    {
        
    }
}