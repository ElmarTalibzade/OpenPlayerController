using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Jump : MonoBehaviour {

    public float jumpForce = 2.5f;                                      //determines the force of player's jump; the higher the value, the higher player jumps

    public bool canJump = true;                                         
    public bool isGrounded = true;                                      //boolean that explains if player is grounded

    public float AirLocomotionSpeedDegradation = 0.2f;                  //1 means that speed is not affected at all, finaly speed is calculated by currentSpeed * AirLocomotionSpeedDegradation; e.g if currentSpeed = 10 and AirLocomotionSpeedDegradation = 0.5, then player's airborne speed would be 5 (10 * 0.5)

    void Start()
    {

    }

    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.01f);                   //constantly checks whether or not player collides with cround

        if (Input.GetKeyDown(KeyCode.Space))                                                                                                //check if user has pressed SPACE (holding down SPACE key would count as a single key press)
        {
            if (canJump)                                                                                                                    //check if player can jump
            {
                if (isGrounded)                                                                                                             //check if player is on the ground (unless you want your player to have infinite jumops, you can mess around with this bit)
                {
                    if (GetComponent<FPS_Locomotion>().crouchEnabled)                                                                       //check if crouch feature is enabled
                    {
                        if (!GetComponent<FPS_Crouch>().isCrouching)                                                                        //check if player is currently crouching
                        {
                            Jump();                                                                                                         //given that all conditions above are met, the player will Jump()
                        }
                    }
                }
            }
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);                                                      //set the vertical force to the specified value with a type IMPULSE
    }
}
