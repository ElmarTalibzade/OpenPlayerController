using UnityEngine;

namespace OpenPlayerController.Common
{
    [CreateAssetMenu(fileName = "Jump Data", menuName = "Open Player Controller/Jump Data", order = 0)]
    public class JumpData : ScriptableObject
    {
        public float JumpForce = 4.5f;
        public float AirborneSpeedMultiplier = 0.2f;
    }
}