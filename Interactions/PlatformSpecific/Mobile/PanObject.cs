using Scriptable_Objects.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions.PlatformSpecific.Mobile
{
    public class PanObject : MonoBehaviour
    {
        [FormerlySerializedAs("settings")] public PanSettingsSo settingsSo;  // Reference to the ScriptableObject

        private Vector3 _touchStart;  // Starting point of the touch

        void Update()
        {
            if (settingsSo == null) return;

            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _touchStart = GetWorldPosition(touch.position);
                        break;

                    case TouchPhase.Moved:
                        Vector3 direction = _touchStart - GetWorldPosition(touch.position);
                        direction.y = 0;  // Keep the y value constant
                        transform.position += direction * settingsSo.panSpeed;
                        break;
                }
            }
        }

        Vector3 GetWorldPosition(Vector2 screenPosition)
        {
            // Convert screen position to world position.
            Ray ray = Camera.main.ScreenPointToRay(screenPosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float distance;
            if (groundPlane.Raycast(ray, out distance))
            {
                return ray.GetPoint(distance);
            }
            return Vector3.zero;
        }
    }
}