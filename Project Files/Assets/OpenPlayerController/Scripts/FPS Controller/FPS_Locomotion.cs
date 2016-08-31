using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Locomotion : MonoBehaviour {

    [Header("Movement")]
    public float walkSpeed = 2.5f;
    public float sprintSpeed = 4.5f;

    float currentSpeed;

    [HideInInspector]
    public GameObject fps_camera;

    [HideInInspector]
    public bool jumpEnabled = false;
    [HideInInspector]
    public bool crouchEnabled = false;

    void Awake()
    {
        fps_camera = transform.GetChild(0).gameObject;

        currentSpeed = walkSpeed;      
          
        jumpEnabled = (GetComponent<FPS_Jump>() != null);
        crouchEnabled = (GetComponent<FPS_Crouch>() != null);        
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, fps_camera.GetComponent<FPS_CameraLook>().currentYRotation, 0);

        if (crouchEnabled)
        {
            if (GetComponent<FPS_Crouch>().isCrouching)
            {
                currentSpeed = GetComponent<FPS_Crouch>().crouchSpeed;
            }
            else
            {
                currentSpeed = walkSpeed;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 moveDirection;

        if (jumpEnabled)
        {
            if (GetComponent<FPS_Jump>().isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -10, Input.GetAxis("Vertical") * currentSpeed);
            }
            else
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed * GetComponent<FPS_Jump>().AirLocomotionSpeedDegradation, -10, Input.GetAxis("Vertical") * currentSpeed * GetComponent<FPS_Jump>().AirLocomotionSpeedDegradation);
            }
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -10, Input.GetAxis("Vertical") * currentSpeed);
        }

        moveDirection = transform.TransformDirection(moveDirection);

        Vector3 finalVelocity = transform.GetComponent<Rigidbody>().velocity;

        finalVelocity.x = moveDirection.x;
        finalVelocity.z = moveDirection.z;

        transform.GetComponent<Rigidbody>().velocity = finalVelocity;
    }
}
