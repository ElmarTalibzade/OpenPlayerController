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
	}
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.C))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
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
        camera_initPos = fps_camera.transform.localPosition;
        camera_crouchPos = new Vector3(camera_initPos.x, camera_initPos.y - crouchAmount, camera_initPos.z);
        
        fps_camera.transform.position = Vector3.Lerp(fps_camera.transform.position, camera_crouchPos, Time.deltaTime / 0.2f);
    }

    public void StopCrouching()
    {
        camera_initPos = fps_camera.transform.localPosition;
        camera_crouchPos = new Vector3(camera_initPos.x, camera_initPos.y - crouchAmount, camera_initPos.z);

        fps_camera.transform.position = Vector3.Lerp(fps_camera.transform.position, camera_initPos, Time.deltaTime / 0.2f);
    }
}
