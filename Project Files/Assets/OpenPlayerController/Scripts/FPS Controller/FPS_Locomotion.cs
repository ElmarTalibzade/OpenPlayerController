using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]


public class FPS_Locomotion : MonoBehaviour {

    [Header("Movement")]
    public float walkSpeed = 2.5f;                              //specifies player's walk speed
    public float sprintSpeed = 4.5f;                            //specifies player's sprint speed

    float currentSpeed;                                         //an internal variable that determines player's final speed

    [HideInInspector]
    public GameObject fps_camera;                               //player's fps camera


    //Hidden from the inspector, these variables are used to determine whether scripts like FPS_Jump and FPS_Climb are attached to the main player.
    [HideInInspector]
    public bool jumpEnabled = false;                            
    [HideInInspector]
    public bool crouchEnabled = false;
    [HideInInspector]
    public bool climbEnabled = false;

    Vector3 moveDirection;                                      //variable used to store player's move direction
    Vector3 finalVelocity;                                      //variable that stores player's final valocity


    //These modules store other Player's scripts such as FPS_Jump, FPS_Crouch, Rigidbody etc. to increase performance
    Rigidbody RigidbodyModule;
    FPS_Jump JumpModule;
    FPS_Crouch CrouchModule;
    FPS_CameraLook CameraModule;
    FPS_Climb ClimbModule;

    void Awake()
    {
        fps_camera = transform.GetChild(0).gameObject;                  //assign player's first child as a camera

        currentSpeed = walkSpeed;                                       //because the game has just started set current speed to the walk speed

        //start assigning Component Calls to 
        RigidbodyModule = GetComponent<Rigidbody>();                    
        JumpModule = GetComponent<FPS_Jump>();
        CrouchModule = GetComponent<FPS_Crouch>();
        ClimbModule = GetComponent<FPS_Climb>();
        CameraModule = fps_camera.GetComponent<FPS_CameraLook>();

        //check whether or not scripts are missing. features are going to be disabled accordingly
        jumpEnabled = (JumpModule != null);
        crouchEnabled = (CrouchModule != null);
        climbEnabled = (ClimbModule != null);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, CameraModule.currentYRotation, 0);       //set player's Y rotation based on camera's Y rotation value

        if (crouchEnabled)                                                              //check if crouching feature is present in player's script
        {
            if (CrouchModule.isCrouching)                                               //also check if the player is currently crouching
            {
                currentSpeed = CrouchModule.crouchSpeed;                                //set the current speed to crouch speed if the player is crouching
            }
            else
            {
                currentSpeed = walkSpeed;                                               //otherwise set it to the walk speed
            }
        }

        if (climbEnabled)                                                               //check if climbing feature is present in player's script
        {
            if (ClimbModule.isClimbing)                                                 //also check if the player is currently climbing
            {
                //if the player is climbing, then increase the Y velocity of the player, making him go up the climb zone based on the vertical input (aka forward velocity)
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, Input.GetAxis("Vertical") * currentSpeed, Input.GetAxis("Vertical") * currentSpeed);
            }
            else
            {
                //otherwise, player walks as usual
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, -10, Input.GetAxis("Vertical") * currentSpeed);
            }
        }

        moveDirection = transform.TransformDirection(moveDirection);                    //convert move direction to the transform direction

        finalVelocity = RigidbodyModule.velocity;                                       //get player's rigidbody velocity and store it in the finalVelocity

        finalVelocity = moveDirection;                                                  //set final velocity equal to moveDirection
    }

    void FixedUpdate()                                                                  //actual movement occurs in the FixedUpdate()
    {
        if (climbEnabled)                                                               //check if climb feature is present in player
        {       
            if (ClimbModule.isClimbing)                                                 //check whether player is climbing
            {
                //set player's rigidbody velocity equal to the final velocity. Because player is climbing verticallyt, Y axis is affected as well
                RigidbodyModule.velocity = new Vector3(finalVelocity.x, finalVelocity.y, finalVelocity.z);
            }
            else
            {
                //if player is not climbing, then set player's rigidbody velocity to its final velocity. However, Y axis remains unaffected
                RigidbodyModule.velocity = new Vector3(finalVelocity.x, RigidbodyModule.velocity.y, finalVelocity.z);
            }
        }
        else
        {
            //if climbing feature does is disabled entirely, then use default movement (same as above)
            RigidbodyModule.velocity = new Vector3(finalVelocity.x, RigidbodyModule.velocity.y, finalVelocity.z);
        }

        //RigidbodyModule.AddForce(moveDirection);                                      //move player based on AddForce() - experimental and results in sliding behavior
    }
}
