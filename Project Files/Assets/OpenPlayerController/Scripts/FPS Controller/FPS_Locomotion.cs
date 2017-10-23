using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPS_Locomotion : MonoBehaviour
{
    [Header("Movement")]
    public float walkSpeed = 2.5f;                              //specifies player's walk speed

    public float sprintSpeed = 4.5f;                            //specifies player's sprint speed

    private float currentSpeed;                                         //an internal variable that determines player's final speed

    [HideInInspector]
    public GameObject fps_camera;                               //player's fps camera

    //Hidden from the inspector, these variables are used to determine whether scripts like FPS_Jump and FPS_Climb are attached to the main player.
    [HideInInspector]
    public bool jumpEnabled = false;

    [HideInInspector]
    public bool crouchEnabled = false;

    [HideInInspector]
    public bool climbEnabled = false;

    private Vector3 moveDirection;                                      //variable used to store player's move direction
    private Vector3 finalVelocity;                                      //variable that stores player's final valocity

    //These modules store other Player's scripts such as FPS_Jump, FPS_Crouch, Rigidbody etc. to increase performance
    private Rigidbody RigidbodyModule;

    private FPS_Jump JumpModule;
    private FPS_Crouch CrouchModule;
    private FPS_CameraLook CameraModule;
    private FPS_Climb ClimbModule;

    private void Awake()
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

    public void Move(Vector2 DIR)
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
                moveDirection = new Vector3(DIR.x * currentSpeed, DIR.y * currentSpeed, DIR.y * currentSpeed);
            }
            else
            {
                //otherwise, player walks as usual
                moveDirection = new Vector3(DIR.x * currentSpeed, -10, DIR.y * currentSpeed);
            }
        }

        moveDirection = transform.TransformDirection(moveDirection);                    //convert move direction to the transform direction

        finalVelocity = RigidbodyModule.velocity;                                       //get player's rigidbody velocity and store it in the finalVelocity

        finalVelocity = moveDirection;                                                  //set final velocity equal to moveDirection
    }

    private void FixedUpdate()                                                                  //actual movement occurs in the FixedUpdate()
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