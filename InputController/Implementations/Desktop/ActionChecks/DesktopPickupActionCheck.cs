using InputController.Enums;
using InputController.Templates.ActionCheck;
using UnityEngine;

namespace InputController.Implementations.Desktop.ActionChecks
{
    /// <summary>
    /// Checks for a pickup action on the desktop platform.
    /// </summary>
    public class DesktopPickupActionCheck : IActionCheck
    {
        /// <summary>
        /// Checks if the action (pickup) has been performed.
        /// </summary>
        public bool CheckAction()
        {
            return Input.GetMouseButtonDown(0);  // Left Mouse Button
        }

        /// <summary>
        /// Returns the type of action this check is responsible for.
        /// </summary>
        public ActionType GetActionType()
        {
            return ActionType.Pickup;
        }
    }
}