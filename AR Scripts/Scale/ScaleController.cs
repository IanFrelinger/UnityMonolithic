using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

namespace AR_Scripts.Scale
{
    public class ScaleController : MonoBehaviour
    {
        private XROrigin m_ARSessionOrigin;

        public Slider scaleSlider;

        private void Awake()
        {
            m_ARSessionOrigin = GetComponent<XROrigin>();
        }

        // Start is called before the first frame update
        void Start()
        {
            scaleSlider.onValueChanged.AddListener(OnSliderValueScaleChanged);
        }

        public void OnSliderValueScaleChanged(float value)
        {
            if (scaleSlider != null)
            {
                m_ARSessionOrigin.transform.localScale = Vector3.one / value;
            }
        }
    }
}
