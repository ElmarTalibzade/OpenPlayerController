using UnityEngine;

namespace OpenPlayerController.Common
{
    [CreateAssetMenu(fileName = "Movement Data", menuName = "Open Player Controller/Movement Data", order = 0)]
    public class MovementData : ScriptableObject
    {
        public float BaseSpeed = 4.5f;
        public float SprintSpeed = 7.5f;

        public float Gravity = 10.0f;
    }
}