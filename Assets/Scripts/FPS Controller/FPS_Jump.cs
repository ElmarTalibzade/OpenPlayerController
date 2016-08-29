using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Jump : MonoBehaviour {

    public float jumpForce = 2.5f;

    void Start()
    {

    }

    void Update()
    {
        if (GetComponent<FPS_Locomotion>().canJump)
        {
            if (GetComponent<FPS_Locomotion>().isGrounded)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
                }
            }
        }
    }
}
