using InputController.Factories;
using UnityEngine;

namespace InputController.Managers
{
    /// <summary>
    /// Manager for setting up input strategies based on the platform.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private global::InputController.Behaviors.InputController inputController;

        private void Start()
        {
            if (inputController == null)
            {
                Debug.LogError("InputController reference is missing in InputManager.");
                return;
            }
            
            SetupInputStrategy();
        }

        private void SetupInputStrategy()
        {
            inputController.SetInputStrategy(InputStrategyFactory.CreateStrategy());
        }
    }
}