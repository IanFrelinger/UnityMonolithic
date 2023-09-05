using InputController.Implementations.Mobile.Strats;
using InputController.Templates.InputStrats;

namespace InputController.Factories
{
    /// <summary>
    /// Factory for creating input strategies based on platform.
    /// </summary>
    public static class InputStrategyFactory
    {
        public static IInputStrategy CreateStrategy()
        {
            // Here, more conditions can be added based on user preferences or other platforms.
#if UNITY_ANDROID || UNITY_IOS
            return new MobileInputStrategy();
#else
                return new DesktopInputStrategy();
#endif
        }
    }
}