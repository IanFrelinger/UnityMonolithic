using Interactions.Raycasting.Templates;
using Scriptable_Objects.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactions.Raycasting.Behaviors
{
    public class Raycaster : MonoBehaviour
    {
        private RaycastStrategy raycastStrategy; 
        [FormerlySerializedAs("settings")] public RaycastSettingsSo settingsSo;

        public void SetRaycastStrategy(RaycastStrategy strategy)
        {
            raycastStrategy = strategy;
        }

        public bool CastRay(out RaycastHit hitInfo)
        {
            if (raycastStrategy == null)
            {
                Debug.LogError("Raycast strategy not set!");
                hitInfo = new RaycastHit();
                return false;
            }
            
            Ray ray = raycastStrategy.GetRay();
            return Physics.Raycast(ray, out hitInfo, settingsSo.maxDistance, settingsSo.layerMask);
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (raycastStrategy == null)
            {
                return;
            }

            Ray ray = raycastStrategy.GetRay();
            Gizmos.DrawRay(ray.origin, ray.direction * settingsSo.maxDistance);
        }
#endif
    }
}