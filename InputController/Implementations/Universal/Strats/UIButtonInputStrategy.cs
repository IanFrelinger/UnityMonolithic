using System.Collections.Generic;
using InputController.Templates.ActionCheck;
using InputController.Templates.InputStrats;
using UnityEngine.UI;

namespace InputController.Implementations.Universal.Strats
{
    /// <summary>
    /// Input strategy using UI Buttons for actions.
    /// </summary>
    public class UIButtonInputStrategy : IInputStrategy
    {
        private bool _pickupRequested = false;
        private bool _dropRequested = false;

        public UIButtonInputStrategy(Button pickupButton, Button dropButton)
        {
            pickupButton?.onClick.AddListener(() => _pickupRequested = true);
            dropButton?.onClick.AddListener(() => _dropRequested = true);
        }

        public bool TryGetPickupAction()
        {
            if (_pickupRequested)
            {
                _pickupRequested = false; // Reset the flag
                return true;
            }
            return false;
        }

        public bool TryGetDropAction()
        {
            if (_dropRequested)
            {
                _dropRequested = false; // Reset the flag
                return true;
            }
            return false;
        }

        public List<IActionCheck> GetActionChecks()
        {
            throw new System.NotImplementedException();
        }
    }
}