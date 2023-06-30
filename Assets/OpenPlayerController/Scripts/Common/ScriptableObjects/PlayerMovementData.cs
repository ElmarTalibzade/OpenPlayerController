using UnityEngine;

namespace OpenPlayerController.Common
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Open Player Controller/Player Movement Data", order = 0)]
    public class PlayerMovementData : ScriptableObject
    {
        public float BaseSpeed = 4.5f;
    }
}