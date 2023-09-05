using System.Collections.Generic;
using InputController.Enums;
using InputController.Templates.ActionCheck;
using InputController.Templates.Data;
using InputController.Templates.InputStrats;
using Scriptable_Objects.Scripts;
using UnityEngine;
using UnityEngine.Events;

namespace InputController.Behaviors
{
    public class InputController : MonoBehaviour
    {
        private IInputStrategy _currentStrategy;
        private List<IActionCheck> _currentActionChecks = new();
        
        [SerializeField]
        private ActionEventsCollectionSo dataObj;
        private IActionEventsCollection actionEventsCollection => dataObj.actionsCollection;
        public void SetInputStrategy(IInputStrategy strategy)
        {
            _currentStrategy = strategy;

            // Clear the existing action checks
            _currentActionChecks.Clear();

            if (_currentStrategy != null)
            {
                // Get action checks from the strategy and assign them to the current action checks list
                _currentActionChecks = _currentStrategy.GetActionChecks();
            }
        }
        private void Update()
        {
            CheckAndInvokeActionEvents(actionEventsCollection.GetUpdateActionEvent);
        }
        private void FixedUpdate()
        {
            CheckAndInvokeActionEvents(actionEventsCollection.GetFixedUpdateActionEvent);
        }
        private void LateUpdate()
        {
            CheckAndInvokeActionEvents(actionEventsCollection.GetLateUpdateActionEvent);
        }
        private void CheckAndInvokeActionEvents(System.Func<ActionType, UnityEvent> getActionEvent)
        {
            if (_currentStrategy == null || _currentActionChecks.Count == 0) return;

            foreach (var actionCheck in _currentActionChecks)
            {
                if (actionCheck.CheckAction())
                {
                    getActionEvent(actionCheck.GetActionType())?.Invoke();
                    return;
                }
            }
        }
    }
}