using System.Collections.Generic;
using InputController.Templates.ActionCheck;
using InputController.Templates.InputStrats;
using UnityEngine;

namespace InputController.Implementations.Desktop.Strats
{
    /// <summary>
    /// Input strategy for desktop platforms.
    /// </summary>
    public class DesktopInputStrategy : IInputStrategy
    {
        public bool TryGetPickupAction()
        {
            return Input.GetMouseButtonDown(0);  // Left Mouse Button
        }
        public bool TryGetDropAction()
        {
            return Input.GetMouseButtonDown(1);  // Right Mouse Button
        }
        public List<IActionCheck> GetActionChecks()
        {
            throw new System.NotImplementedException();
        }
    }
}