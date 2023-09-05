using UnityEngine;

namespace Scriptable_Objects.Scripts
{
    [CreateAssetMenu(menuName = "Pan Settings")]
    public class PanSettingsSo : ScriptableObject
    {
        public float panSpeed = 0.5f;  // Speed at which the object moves
    }
}