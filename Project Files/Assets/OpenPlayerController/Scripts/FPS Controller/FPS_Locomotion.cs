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
    [HideInInspector]
    public bool climbEnabled = false;

    Vector3 moveDirection;
    Vector3 finalVelocity;

    Rigidbody RigidbodyModule;
    FPS_Jump JumpModule;
    FPS_Crouch CrouchModule;
    FPS_CameraLook CameraModule;
    FPS_Climb ClimbModule;

    void Awake()
    {
        fps_camera = transform.GetChild(0).gameObject;

        currentSpeed = walkSpeed;

        RigidbodyModule = GetComponent<Rigidbody>();
        JumpModule = GetComponent<FPS_Jump>();
        CrouchModule = GetComponent<FPS_Crouch>();
        ClimbModule = GetComponent<FPS_Climb>();
        CameraModule = fps_camera.GetComponent<FPS_CameraLook>();

        jumpEnabled = (JumpModule != null);
        crouchEnabled = (CrouchModule != null);
        climbEnabled = (ClimbModule != null);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, CameraModule.currentYRotation, 0);

        if (crouchEnabled)
        {
            if (CrouchModule.isCrouching)
            {
                currentSpeed = CrouchModule.crouchSpeed;
            }
            else
            {
                currentSpeed = walkSpeed;
            }
        }

        if (climbEnabled)
        {
            if (ClimbModule.isClimbing)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * ClimbModule.climbSpeed, (Input.GetAxis("Vertical") * ClimbModule.climbSpeed) + (Input.GetAxis("Horizontal") * ClimbModule.climbSpeed), Input.GetAxis("Vertical") * ClimbModule.climbSpeed);
            }
            else
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -10, Input.GetAxis("Vertical") * currentSpeed);
            }
        }

        moveDirection = transform.TransformDirection(moveDirection);

        finalVelocity = RigidbodyModule.velocity;

        finalVelocity.x = moveDirection.x;
        finalVelocity.y = moveDirection.y;
        finalVelocity.z = moveDirection.z;
    }

    void FixedUpdate()
    {
        if (climbEnabled)
        {
            if (ClimbModule.isClimbing)
            {
                RigidbodyModule.velocity = new Vector3(finalVelocity.x, finalVelocity.y, finalVelocity.z);
            }
            else
            {
                RigidbodyModule.velocity = new Vector3(finalVelocity.x, RigidbodyModule.velocity.y, finalVelocity.z);
            }
        }
        else
        {
            RigidbodyModule.velocity = new Vector3(finalVelocity.x, RigidbodyModule.velocity.y, finalVelocity.z);
        }

        //RigidbodyModule.AddForce(moveDirection);
    }
}
