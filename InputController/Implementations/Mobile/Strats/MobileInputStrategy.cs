using System.Collections.Generic;
using InputController.Templates.ActionCheck;
using InputController.Templates.InputStrats;
using UnityEngine;

namespace InputController.Implementations.Mobile.Strats
{
    /// <summary>
    /// Input strategy for mobile platforms.
    /// </summary>
    public class MobileInputStrategy : IInputStrategy
    {
        public bool TryGetPickupAction()
        {
            // Single tap
            return Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began;
        }

        public bool TryGetDropAction()
        {
            // Double tap
            return Input.touchCount == 1 && Input.GetTouch(0).tapCount == 2 && Input.GetTouch(0).phase == TouchPhase.Began;
        }

        public List<IActionCheck> GetActionChecks()
        {
            throw new System.NotImplementedException();
        }
    }
}