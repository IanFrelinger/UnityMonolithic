using System.Collections.Generic;
using InputController.Templates.InputStrats.Update;
using UnityEngine;

namespace InputController.Managers.Update
{
    public class InputUpdateManager : MonoBehaviour
    {
        private readonly List<IUpdatableInputStrategy> _updatableStrategies = new List<IUpdatableInputStrategy>();

        public void RegisterStrategy(IUpdatableInputStrategy strategy)
        {
            if(strategy != null && !_updatableStrategies.Contains(strategy))
            {
                _updatableStrategies.Add(strategy);
            }
        }

        public void DeregisterStrategy(IUpdatableInputStrategy strategy)
        {
            if(strategy != null)
            {
                _updatableStrategies.Remove(strategy);
            }
        }

        private void Update()
        {
            foreach(var strategy in _updatableStrategies)
            {
                strategy.Tick();
            }
        }
    }
}