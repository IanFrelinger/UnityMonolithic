using Scriptable_Objects.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions.PlatformSpecific.Mobile
{
    public class PinchZoom : MonoBehaviour
    {
        [FormerlySerializedAs("settings")] public ZoomSettingsSo settingsSo;

        private Vector3 _initialScale;

        void Start()
        {
            if (!settingsSo) 
            {
                Debug.LogWarning("No ZoomSettings assigned! Defaulting to object's current scale.");
                return;
            }

            _initialScale = transform.localScale;
        }

        void Update()
        {
            if (!settingsSo) return;

            if (Input.touchCount == 2)
            {
                Touch touchZero = Input.GetTouch(0);
                Touch touchOne = Input.GetTouch(1);

                Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                if (Camera.main.orthographic)
                {
                    Camera.main.orthographicSize += deltaMagnitudeDiff * settingsSo.orthoZoomSpeed;
                    Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
                }
                else
                {
                    Camera.main.fieldOfView += deltaMagnitudeDiff * settingsSo.perspectiveZoomSpeed;
                    Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
                }

                float scaleFactor = 1.0f - deltaMagnitudeDiff * 0.01f;
                transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * scaleFactor, Time.deltaTime * 5f);
                transform.localScale = new Vector3(
                    Mathf.Clamp(transform.localScale.x, _initialScale.x * settingsSo.minScale, _initialScale.x * settingsSo.maxScale),
                    Mathf.Clamp(transform.localScale.y, _initialScale.y * settingsSo.minScale, _initialScale.y * settingsSo.maxScale),
                    Mathf.Clamp(transform.localScale.z, _initialScale.z * settingsSo.minScale, _initialScale.z * settingsSo.maxScale));
            }
        }
    }
}
