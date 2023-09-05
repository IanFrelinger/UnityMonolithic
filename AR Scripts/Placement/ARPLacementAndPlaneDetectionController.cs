using CustomDebug.Behaviors;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

namespace AR_Scripts.Placement
{
    public class ARPLacementAndPlaneDetectionController : MonoBehaviour
    {
        private ARPlaneManager _mARPlaneManager;
        private ARPlacementManager _mARPlacementManager;
        public Button placeButton;
        public Button adjustButton;
        public TextMeshProUGUI informUIPanelText;
        public Button quitButton;
        
        private TextMeshProUGUI _buttonText;

        private void Awake()
        {
            SetUp();
        }

        private void SetUp()
        {
            SetDebugSettings();
            SetUpArComponents();
            SetUpButtonText();
            SetUpButton();
        }
        
        private void SetDebugSettings()
        {
            
        }
        
        private void SetUpArComponents()
        {
            if (TryToSetUpArComponents())
            {
                DebugSystem.DebugMessage("Successfully set up AR components.");
            }
            else
            {
                DebugSystem.DebugMessage("Failed to set up AR components.");
            }
        }

        private void SetUpButtonText()
        {
            if (TryToSetUpButtonText())
            {
                DebugSystem.DebugMessage("Successfully set up button text.");
            }
            else
            {
                DebugSystem.DebugMessage("Failed to set up button text.");
            }
        }

        private void SetUpButton()
        {
            if (TryToSetUpButton())
            {
                DebugSystem.DebugMessage("Successfully set up buttons.");
            }
            else
            {
                DebugSystem.DebugMessage("Failed to set up buttons.");
            }
        }

        private bool TryToSetUpArComponents()
        {
            _mARPlacementManager = GetComponent<ARPlacementManager>();
            if (_mARPlacementManager == null)
            {
                DebugSystem.DebugMessage("ARPlacementManager is null.");
                return false;
            }

            _mARPlaneManager = GetComponent<ARPlaneManager>();
            if (_mARPlaneManager == null)
            {
                DebugSystem.DebugMessage("ARPlaneManager is null.");
                return false;
            }

            return true;
        }

        private bool TryToSetUpButtonText()
        {
            _buttonText = placeButton?.GetComponentInChildren<TextMeshProUGUI>();
            if (_buttonText == null)
            {
                DebugSystem.DebugMessage("Button text component is missing.");
                return false;
            }
            return true;
        }

        private bool TryToSetUpButton()
        {
            if (placeButton == null)
            {
                DebugSystem.DebugMessage("Place button is null.");
                return false;
            }

            if (adjustButton == null)
            {
                DebugSystem.DebugMessage("Adjust button is null.");
                return false;
            }

            if (quitButton == null)
            {
                DebugSystem.DebugMessage("Quit button is null.");
                return false;
            }

            return true;
        }

        private void SetButtonText(Button button, string text)
        {
            var TMPRoText = TryToGetTmpro(button.gameObject);
            if (TMPRoText != null)
            {
                TMPRoText.text = text;
            }
        }

        [CanBeNull]
        private TextMeshProUGUI TryToGetTmpro(GameObject go)
        {
            var TMPRoText = go.GetComponent<TextMeshProUGUI>();
            if (TMPRoText == null)
            {
                DebugSystem.DebugMessage("Could not find TextMeshProUGUI component.");
            }
            return TMPRoText;
        }

        private void Start()
        {
            EnableARPlacementAndPlaneDetection();
        }

        public void DisableARPlacementAndPlaneDetection()
        {
            _mARPlaneManager.enabled = false;
            _mARPlacementManager.enabled = false;
            SetAllPlanesActiveOrDeactive(false);

            placeButton.gameObject.SetActive(false);
            adjustButton.gameObject.SetActive(true);

            informUIPanelText.text = "Great! You placed the Arena";
        }

        public void EnableARPlacementAndPlaneDetection()
        {
            _mARPlaneManager.enabled = true;
            _mARPlacementManager.enabled = true;
            SetAllPlanesActiveOrDeactive(true);

            placeButton.gameObject.SetActive(true);
            adjustButton.gameObject.SetActive(false);

            informUIPanelText.text = "Move Phone to detect Planes";
        }

        private void SetAllPlanesActiveOrDeactive(bool value)
        {
            foreach (var plane in _mARPlaneManager.trackables)
            {
                plane.gameObject.SetActive(value);
            }
        }
    }
}
