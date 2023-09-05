using UnityEngine;

namespace Scriptable_Objects.Scripts
{
    [CreateAssetMenu(menuName = "Raycast Settings")]
    public class RaycastSettingsSo : ScriptableObject
    {
        public enum RaycastOrigin
        {
            FromMouse,
            CenterOfScreen,
            // Add more options as required.
        }

        public RaycastOrigin raycastOrigin = RaycastOrigin.FromMouse;
        public LayerMask layerMask = ~0;  // Default to all layers.
        public float maxDistance = 100f;  // Default max distance.
    }
}