using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Locomotion : MonoBehaviour {

    [Header("Movement")]
    public float walkSpeed = 2.5f;
    public float sprintSpeed = 4.5f;

    [Header("Jumping States")]
    public bool canJump = true;
    public bool isGrounded = true;

    float currentSpeed;

    [HideInInspector]
    public GameObject fps_camera;

    bool jumpEnabled = false;
    bool crouchEnabled = false;

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
    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -10, Input.GetAxis("Vertical") * currentSpeed);

        moveDirection = transform.TransformDirection(moveDirection);

        Vector3 finalVelocity = transform.GetComponent<Rigidbody>().velocity;

        finalVelocity.x = moveDirection.x;
        finalVelocity.z = moveDirection.z;

        transform.GetComponent<Rigidbody>().velocity = finalVelocity;
    }

}
