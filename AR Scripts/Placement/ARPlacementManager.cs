using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace AR_Scripts.Placement
{
    public class ARPlacementManager : MonoBehaviour
    {
        private ARRaycastManager _mARRaycastManager;
        private static List<ARRaycastHit> _raycastHits = new List<ARRaycastHit>();

        public Camera aRCamera;

        public GameObject battleArenaGameObject;
        private void Awake()
        {
            _mARRaycastManager = GetComponent<ARRaycastManager>();
        }
    
        // Update is called once per frame
        void Update()
        {
            Vector3 centerOfScreen = new Vector3(Screen.width / 2, Screen.height / 2);
            Ray ray = aRCamera.ScreenPointToRay(centerOfScreen);

            if (_mARRaycastManager.Raycast(ray, _raycastHits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = _raycastHits[0].pose;

                Vector3 positionToBePlaced = hitPose.position;

                battleArenaGameObject.transform.position = positionToBePlaced;
            }
        }
    }
}
