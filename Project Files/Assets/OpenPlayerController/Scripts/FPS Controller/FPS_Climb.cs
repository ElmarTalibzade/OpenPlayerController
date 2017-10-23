using UnityEngine;

public class FPS_Climb : MonoBehaviour
{
    public string ClimbZoneTag = "OPC_ClimbZone";                           //specifies what tag should be registered as a ClimbZone

    public bool isClimbing = false;

    public float climbSpeed = 3.5f;                                         //how fast player moves in climbing mode
    public bool moveSideways = true;                                        //if set true, player would be able to move sideways while climbing

    private FPS_Locomotion LocomotionModule;                                        //an internal variable used to store Player's Locomotion Script at runtime

    private void Start()
    {
        LocomotionModule = GetComponent<FPS_Locomotion>();                  //assign player's locomotion script to LocomotionModule
    }

    private void OnTriggerStay(Collider trig)                                       //Event runs when Player enters the climb zone
    {
        if (trig.tag == ClimbZoneTag)
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit(Collider trig)                                       //Event runs when Player leaves the climb zone
    {
        if (trig.tag == ClimbZoneTag)
        {
            isClimbing = false;
        }
    }
}