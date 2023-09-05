using UnityEngine;

namespace Scriptable_Objects.Scripts
{
    [CreateAssetMenu(menuName = "Color Settings")]
    public class ColorSettingsSo : ScriptableObject
    {
        public Color highlightColor = Color.yellow;
        public Color originalColor = Color.white;
    }
}