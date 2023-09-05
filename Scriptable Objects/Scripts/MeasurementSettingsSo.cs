using AR_Scripts.Measurement.Components.Data;
using UnityEngine;

namespace Scriptable_Objects.Scripts
{
    [CreateAssetMenu(fileName = "MeasurementSettings", menuName = "AR/MeasurementSettings", order = 0)]
    public class MeasurementSettingsSo : ScriptableObject
    {
        public MeasurementSettings Settings => settings;
        [SerializeField]
        private MeasurementSettings settings;
    }
}