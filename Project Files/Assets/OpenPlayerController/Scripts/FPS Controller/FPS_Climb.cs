using UnityEngine;
using System.Collections;

public class FPS_Climb : MonoBehaviour {

    public bool enableClimb = true;

    public string ClimbColliderTag = "OPC_ClimbZone";

    public bool isClimbing = false;

    public float climbSpeed = 3.5f;
    public bool moveSideways = true;

    FPS_Locomotion LocomotionModule;

    void Start()
    {
        LocomotionModule = GetComponent<FPS_Locomotion>();
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider trig)
    {
        if (trig.tag == ClimbColliderTag)
        {
            isClimbing = true;
            Debug.Log("Climbing!");
        }
    }

    void OnTriggerExit(Collider trig)
    {
        if (trig.tag == ClimbColliderTag)
        {
            isClimbing = false;
            Debug.Log("Left Climbing Zone...");
        }
    }

}
