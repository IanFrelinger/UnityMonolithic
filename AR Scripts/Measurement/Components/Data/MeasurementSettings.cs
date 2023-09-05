// AR_Scripts.Measurement.Components.Data.MeasurementSettings.cs
// This class defines the visual settings for the measurement, 
// such as line material, width, font type, font size, and color.

using System;
using UnityEngine;

namespace AR_Scripts.Measurement.Components.Data
{
    [Serializable]
    public class MeasurementSettings
    {
        // Properties for visual settings.
        [SerializeField]
        private Material lineMaterial;
        public Material LineMaterial => lineMaterial;

        [SerializeField]
        private float lineWidth = 0.01f;
        public float LineWidth => lineWidth;

        [SerializeField]
        private Font labelFont;
        public Font LabelFont => labelFont;

        [SerializeField]
        private int labelFontSize = 50;
        public int LabelFontSize => labelFontSize;
        
        [SerializeField]
        private Color labelColor = Color.white;
        public Color LabelColor => labelColor;
    }
}