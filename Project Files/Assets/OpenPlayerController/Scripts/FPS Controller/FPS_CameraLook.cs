using UnityEngine;
using System.Collections;

public class FPS_CameraLook : MonoBehaviour {

    public float lookSensitivity = 5;                                       //how sensitive camera's rotation is to user's mouse input; setting it 0 would render camera static
    public float lookSmoothDamp = 0.1f;                                     //how smoothly camera rotates, the higher the smoother; if set 0 smooth look removed entirely

    //what's the minimum and maximum camera rotation for player?
    public float minXRotation = -90;                                      
    public float maxXRotation = 90;

    //used to store mouse movement input * lookSensitivity
    float XRotation;
    float YRotation;

    float XRotationV;
    float YRotationV;

    //final camera rotations are stored by these variables
    public float currentXRotation;
    public float currentYRotation;
	
	void Update ()
    {
        //store mouse input based on X and Y axis times the look sensitivity
        XRotation += -Input.GetAxis("Mouse Y") * lookSensitivity;
        YRotation += Input.GetAxis("Mouse X") * lookSensitivity;

        //clamp the XRotation of the camera look based on two variables
        XRotation = Mathf.Clamp(XRotation, minXRotation, maxXRotation);

        //this is where camera's X and Y rotation values are stored based on smooth damp, which would basically make camera rotate smoothly to the target value for the current frame (XRotation and YRotation found before)
        currentXRotation = Mathf.SmoothDamp(currentXRotation, XRotation, ref XRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, YRotation, ref YRotationV, lookSmoothDamp);

        //with all calculations done, set camera's X and Y rotation based on values we found earlier; ensure that Z axis stays 0 every frame
        transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
    }
}
