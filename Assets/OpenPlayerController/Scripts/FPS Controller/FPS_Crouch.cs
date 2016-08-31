using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class FPS_Crouch : MonoBehaviour {

    public float crouchSpeed = 1.5f;
    public float crouchAmount = 1;

    public bool isCrouching = false;

    public bool AllowCrouchingAirbone = false;

    GameObject fps_camera;
	
    Vector3 camera_initPos;
    Vector3 camera_crouchPos;

	void Start ()
    {
        fps_camera = GetComponent<FPS_Locomotion>().fps_camera;

        camera_initPos = fps_camera.transform.localPosition;
        camera_crouchPos = new Vector3(camera_initPos.x, camera_initPos.y - crouchAmount, camera_initPos.z);
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (GetComponent<FPS_Locomotion>().jumpEnabled)
            {
                if (GetComponent<FPS_Jump>().isGrounded)
                {
                    isCrouching = true;
                }
            }
            else
            {
                isCrouching = true;
            }
        }
        else
        {
            if (!CheckIfColliderAbove())
            {
                isCrouching = false;
            }
            else
            {
                isCrouching = true;
            }
        }

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
        fps_camera.transform.localPosition = Vector3.Lerp(fps_camera.transform.localPosition, camera_crouchPos, Time.deltaTime / 0.2f);
        GetComponent<CapsuleCollider>().center = new Vector3(0, -0.5f, 0);
        GetComponent<CapsuleCollider>().height = 1;
    }

    public void StopCrouching()
    {
        fps_camera.transform.localPosition = Vector3.Lerp(fps_camera.transform.localPosition, camera_initPos, Time.deltaTime / 0.2f);

        GetComponent<CapsuleCollider>().center = Vector3.zero;
        GetComponent<CapsuleCollider>().height = 2;
    }

    bool CheckIfColliderAbove()
    {
        return Physics.Raycast(transform.position, Vector3.up, 1);
    }
}
