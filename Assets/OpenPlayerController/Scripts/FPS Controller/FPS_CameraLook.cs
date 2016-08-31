using UnityEngine;
using System.Collections;

public class FPS_CameraLook : MonoBehaviour {

    public float lookSensitivity = 5;
    public float lookSmoothDamp = 0.1f;

    public float minXRotation = -90;
    public float maxXRotation = 90;

    float XRotation;
    float YRotation;

    float XRotationV;
    float YRotationV;

    public float currentXRotation;
    public float currentYRotation;

	void Start ()
    {
	    
	}
	
	void Update ()
    {
        XRotation += -Input.GetAxis("Mouse Y") * lookSensitivity;
        YRotation += Input.GetAxis("Mouse X") * lookSensitivity;

        XRotation = Mathf.Clamp(XRotation, minXRotation, maxXRotation);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, XRotation, ref XRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, YRotation, ref YRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
    }
}
