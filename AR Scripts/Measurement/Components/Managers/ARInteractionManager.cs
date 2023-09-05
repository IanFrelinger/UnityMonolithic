// AR_Scripts.Measurement.Components.Managers.ARInteractionManager.cs
// This class provides functionalities related to interacting with AR elements, 
// primarily through raycasting.

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace AR_Scripts.Measurement.Components.Managers
{
    public class ARInteractionManager
    {
        // AR raycast manager for detecting surfaces.
        readonly ARRaycastManager _raycastManager;

        public ARInteractionManager(ARRaycastManager raycastManager)
        {
            this._raycastManager = raycastManager;
        }

        // Raycast from screen touch position to AR surfaces.
        public bool RaycastFromScreen(Vector2 screenPosition, out ARRaycastHit hitResult)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            _raycastManager.Raycast(screenPosition, hits, TrackableType.PlaneWithinPolygon);

            if (hits.Count > 0)
            {
                hitResult = hits[0];
                return true;
            }

            hitResult = default;
            return false;
        }
    }
}