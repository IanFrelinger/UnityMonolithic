using InputController.Enums;

namespace InputController.Templates.ActionCheck
{
    /// <summary>
    /// Defines the interface for checking a specific action.
    /// </summary>
    public interface IActionCheck
    {
        bool CheckAction();
        ActionType GetActionType();
    }
}