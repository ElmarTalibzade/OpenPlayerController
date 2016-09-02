using UnityEngine;
using System.Collections;

public class FPS_Climb : MonoBehaviour {

    public string ClimbZoneTag = "OPC_ClimbZone";                           //specifies what tag should be registered as a ClimbZone

    public bool isClimbing = false;                                         

    public float climbSpeed = 3.5f;                                         //how fast player moves in climbing mode
    public bool moveSideways = true;                                        //if set true, player would be able to move sideways while climbing

    FPS_Locomotion LocomotionModule;                                        //an internal variable used to store Player's Locomotion Script at runtime

    void Start()
    {
        LocomotionModule = GetComponent<FPS_Locomotion>();                  //assign player's locomotion script to LocomotionModule
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider trig)                                       //Event runs when Player enters the climb zone
    {
        if (trig.tag == ClimbZoneTag)
        {
            isClimbing = true;
        }
    }

    void OnTriggerExit(Collider trig)                                       //Event runs when Player leaves the climb zone
    {
        if (trig.tag == ClimbZoneTag)
        {
            isClimbing = false;
        }
    }

}
