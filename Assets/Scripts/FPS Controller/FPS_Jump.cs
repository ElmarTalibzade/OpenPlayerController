using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Jump : MonoBehaviour {

    public float jumpForce = 2.5f;

    public bool canJump = true;
    public bool isGrounded = true;

    public float AirLocomotionSpeedDegradation = 0.2f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump)
            {
                if (isGrounded)
                {
                    if (GetComponent<FPS_Locomotion>().crouchEnabled)
                    {
                        if (!GetComponent<FPS_Crouch>().isCrouching)
                        {
                            Jump();
                        }
                    }
                }
            }
        }
    }

    void Jump()
    {
        Debug.Log("Jump!");
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }
}
