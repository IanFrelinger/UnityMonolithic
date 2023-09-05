// AR_Scripts.Measurement.Behaviors.TapeMeasure.cs
using AR_Scripts.Measurement.Components.Managers;
using Scriptable_Objects.Scripts;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

namespace AR_Scripts.Measurement.Behaviors
{
    public class TapeMeasure : MonoBehaviour
    {
        public Camera arCamera;
        public MeasurementSettingsSo measurementSettingsSo;

        private ARRaycastManager _raycastManager;
        private MeasurementManager _measurementManager;
        private ARInteractionManager _arInteractionManager;
        private VisualFeedbackManager _visualFeedbackManager;

        private Transform _startPoint;
        private Transform _endPoint;
        private bool _hasStartPoint = false;

        private void Awake()
        {
            // Dependency Injection for the raycast manager
            _raycastManager = _raycastManager ?? GetComponent<ARRaycastManager>();
        }

        void Start()
        {
            if (!arCamera)
            {
                Debug.LogError("AR Camera is not set!");
                return;
            }

            _measurementManager = new MeasurementManager();
            _arInteractionManager = new ARInteractionManager(_raycastManager);
            _visualFeedbackManager = new VisualFeedbackManager(measurementSettingsSo.Settings);
        }

        void Update()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    if (_arInteractionManager.RaycastFromScreen(touch.position, out ARRaycastHit hit))
                    {
                        if (!_hasStartPoint)
                        {
                            SetPoint(ref _startPoint, hit.pose.position, "StartPoint");
                        }
                        else
                        {
                            SetPoint(ref _endPoint, hit.pose.position, "EndPoint");
                            float distance = _measurementManager.GetDistance(_startPoint.position, _endPoint.position);
                            _visualFeedbackManager.DisplayMeasurement(_startPoint, _endPoint, distance);
                        }
                    }
                }
            }
        }

        private void SetPoint(ref Transform pointTransform, Vector3 position, string pointName)
        {
            if (pointTransform == null)
            {
                GameObject pointObj = new GameObject(pointName);
                pointTransform = pointObj.transform;
            }

            pointTransform.position = position;
            _hasStartPoint = true;
            _visualFeedbackManager.DisplayStartPoint(pointTransform);
        }
    }
}
