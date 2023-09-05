// AR_Scripts.Measurement.Components.Managers.VisualFeedbackManager.cs

using AR_Scripts.Measurement.Components.Data;
using UnityEngine;

namespace AR_Scripts.Measurement.Components.Managers
{
    public class VisualFeedbackManager
    {
        private LineRenderer _lineRenderer;
        private TextMesh _distanceLabel;
        readonly MeasurementSettings _settingsSo;
        public VisualFeedbackManager(MeasurementSettings settingsSo)
        {
            this._settingsSo = settingsSo;
            CreateVisualElements();
            ApplySettings();
        }

        private void CreateVisualElements()
        {
            GameObject lineObject = new GameObject("MeasurementLine");
            _lineRenderer = lineObject.AddComponent<LineRenderer>();

            GameObject labelObject = new GameObject("MeasurementLabel");
            _distanceLabel = labelObject.AddComponent<TextMesh>();
        }

        private void ApplySettings()
        {
            _lineRenderer.material = _settingsSo.LineMaterial;
            _lineRenderer.startWidth = _settingsSo.LineWidth;
            _lineRenderer.endWidth = _settingsSo.LineWidth;

            _distanceLabel.font = _settingsSo.LabelFont;
            _distanceLabel.fontSize = _settingsSo.LabelFontSize;
            _distanceLabel.color = _settingsSo.LabelColor;
        }

        public void DisplayStartPoint(Transform startPoint)
        {
            // Potential enhancements for displaying the start point
        }

        public void DisplayMeasurement(Transform startPoint, Transform endPoint, float distance)
        {
            _lineRenderer.SetPosition(0, startPoint.position);
            _lineRenderer.SetPosition(1, endPoint.position);

            Vector3 midPoint = (startPoint.position + endPoint.position) / 2;
            _distanceLabel.transform.position = midPoint;
            _distanceLabel.text = $"{distance:F2} m";
        }
    }
}