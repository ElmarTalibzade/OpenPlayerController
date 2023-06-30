using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FPS_Jump : MonoBehaviour
{
    public float jumpForce = 2.5f;                                      //determines the force of player's jump; the higher the value, the higher player jumps

    public bool canJump
    {
        get
        {
            return (isGrounded && GetComponent<FPS_Locomotion>().crouchEnabled && !GetComponent<FPS_Crouch>().isCrouching);
        }
    }

    public bool isGrounded = true;                                      //boolean that explains if player is grounded

    public float AirLocomotionSpeedDegradation = 0.2f;                  //1 means that speed is not affected at all, finaly speed is calculated by currentSpeed * AirLocomotionSpeedDegradation; e.g if currentSpeed = 10 and AirLocomotionSpeedDegradation = 0.5, then player's airborne speed would be 5 (10 * 0.5)

    private void Start()
    {
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, GetComponent<Collider>().bounds.extents.y + 0.01f);                   //constantly checks whether or not player collides with cround
    }

    public void Jump()
    {
        if (canJump)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);                                                      //set the vertical force to the specified value with a type IMPULSE
        }
    }
}