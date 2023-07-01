using UnityEngine;

namespace OpenPlayerController.Common
{
    [CreateAssetMenu(fileName = "Camera Look Data", menuName = "Open Player Controller/Camera Look Data", order = 0)]
    public class CameraLookData : ScriptableObject
    {
        public float LookSensitivity = 2.5f;
        public float LookSmoothDamp = 0.1f;

        public float MinimumVerticalRotation = -90;
        public float MaximumVerticalRotation = 90;
    }
}