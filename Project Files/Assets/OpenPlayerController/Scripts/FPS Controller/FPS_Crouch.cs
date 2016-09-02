using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Crouch : MonoBehaviour {

    public float crouchSpeed = 1.5f;                                            //determines player's speed while he is crouching
    public float crouchAmount = 1;                                              //this basically tells how low should player's camera go during crouch mode; for example, if my crouchAmount is 2, then my camera's crouch position would be 2 units lower

    public bool isCrouching = false;                                            //boolean determining whether player is crouching or standing

    public bool AllowCrouchingAirbone = false;                                  //if true, players can crouch while airborne, a perfect example is Team Fortress 2 (although physics here behave differently)

    GameObject fps_camera;                                                      //declare a variable where we'll store player's camera GameObject
	
    Vector3 camera_initPos;                                                     //stores an initial position of player's camera
    Vector3 camera_crouchPos;                                                   //stores the crouch position of player's camera

    FPS_Locomotion LocomotionModule;                                            //stores GetComponent() calls for player's scripts (for the sake of performance)
    CapsuleCollider CapsuleModule;
    FPS_Jump JumpModule;

    void Start ()
    {
        LocomotionModule = GetComponent<FPS_Locomotion>();                      //assign GetComponent() calls to our previously declared variables
        JumpModule = GetComponent<FPS_Jump>();
        CapsuleModule = GetComponent<CapsuleCollider>();

        fps_camera = LocomotionModule.fps_camera;                               //FPS_Locomotion has already defined fps_camera variable, so we're going to store it here

        camera_initPos = fps_camera.transform.localPosition;                    //store player's camera LOCAL position (because our player camera is the child of player object, we must store and modify only LOCAL position)
        camera_crouchPos = new Vector3(camera_initPos.x, camera_initPos.y - crouchAmount, camera_initPos.z);            //based on camera's initial LOCAL position, we calculate and store the position of the camera when player crouches
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftControl))                                  //if player holds LEFT CONTROL (LCTRL)
        {
            if (LocomotionModule.jumpEnabled)                                   //check if player's has FPS_Jump script present
            {
                if (!AllowCrouchingAirbone)                                     //then check if player is allowed to crouch while airborne
                {
                    if (JumpModule.isGrounded)                                  //then check if player is grounded (if crouching while airborne is false)
                    {
                        isCrouching = true;                                     //if all conditions are met, then set isCrouching to true (actual crouching is handled later)
                    }
                }

                isCrouching = true;                                             //if crouching while airborne is allowed, then set crouching to true
            }
            else
            {
                isCrouching = true;                                             
            }
        }
        else                                                                    //if player is not holding down the LEFT CONTROL KEY (LCTRL)
        {
            if (!CheckIfColliderAbove())                                        //ensure that there is no collider above player's head                                   
            {
                isCrouching = false;                                            //if that's the case, player can stop crouching (this is useful when user doesn't have to hold down LCTRL button even if inside of low spaces like vents; assuming that player is not holding down LCTRL button, when he emerges he'll stop crouching automatically
            }
            else
            {
                isCrouching = true;                                             //if there is collider above the player, then make player keep crouching
            }
        }

        //the code here is self-explanatory: run specific function based on whether the player is crouching or not
	    if (isCrouching)
        {
            StartCrouching();                                                  
        }
        else
        {
            StopCrouching();
        }
	}

    public void StartCrouching()
    {
        fps_camera.transform.localPosition = Vector3.Lerp(fps_camera.transform.localPosition, camera_crouchPos, Time.deltaTime / 0.2f);                                 //smoothly lerp FPS camera from its current LOCAL position to the crouch LOCAL position        

        //modify the capsule collider calue to reduce its height to be able to fit low spaces like vents
        CapsuleModule.center = new Vector3(0, -0.5f, 0);
        CapsuleModule.height = 1;
    }

    public void StopCrouching()
    {
        fps_camera.transform.localPosition = Vector3.Lerp(fps_camera.transform.localPosition, camera_initPos, Time.deltaTime / 0.2f);                                   //smoothly lerp FPS camera LOCAL position from its current LOCAL position to its initial LOCAL position, which has been calculated before

        //restore capsule collider to its default state
        CapsuleModule.center = Vector3.zero;
        CapsuleModule.height = 2;
    }

    bool CheckIfColliderAbove()
    {
        return Physics.Raycast(transform.position, Vector3.up, 1);                              //returns true if anything collides with a 1 unit long raycast drawn from player's current position (ultimately checks if something solid is above him)
    }
}
