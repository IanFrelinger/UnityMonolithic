using System.Collections.Generic;
using InputController.Templates.ActionCheck;

namespace InputController.Templates.InputStrats
{
    /// <summary>
    /// Interface defining contracts for input strategies.
    /// </summary>
    public interface IInputStrategy
    {
        bool TryGetPickupAction();
        bool TryGetDropAction();
        List<IActionCheck> GetActionChecks();
    }
}
