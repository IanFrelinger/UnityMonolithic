using UnityEngine;

namespace Scriptable_Objects.Scripts
{
    [CreateAssetMenu(menuName = "Zoom Settings")]
    public class ZoomSettingsSo : ScriptableObject
    {
        public float perspectiveZoomSpeed = 0.5f;
        public float orthoZoomSpeed = 0.5f;
        public float minScale = 0.5f;
        public float maxScale = 3.0f;
    }
}