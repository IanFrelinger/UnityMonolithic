// AR_Scripts.Measurement.Components.Managers.MeasurementManager.cs
// This class handles calculations related to measurements, such as determining distance.

using UnityEngine;

namespace AR_Scripts.Measurement.Components.Managers
{
    public class MeasurementManager
    {
        // Computes the distance between two points in 3D space.
        public float GetDistance(Vector3 startPoint, Vector3 endPoint)
        {
            return Vector3.Distance(startPoint, endPoint);
        }
    }
}