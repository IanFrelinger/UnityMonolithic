namespace InputController.Templates.InputStrats.Touch
{
    /// <summary>
    /// Extended input interface for touch-based interactions.
    /// </summary>
    public interface ITouchInputStrategy : IInputStrategy
    {
        UnityEngine.Touch? GetSingleTouch();
        (UnityEngine.Touch?, UnityEngine.Touch?) GetPinchTouches();
        bool TryGetSwipeLeftAction();
        bool TryGetSwipeRightAction();
    }
}
