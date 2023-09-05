using InputController.Enums;
using UnityEngine.Events;

namespace InputController.Templates.Data
{
    public interface IActionEventsCollection
    {
        void InitializeActionEvents();
        UnityEvent GetUpdateActionEvent(ActionType actionType);
        UnityEvent GetFixedUpdateActionEvent(ActionType actionType);
        UnityEvent GetLateUpdateActionEvent(ActionType actionType);
    }
}