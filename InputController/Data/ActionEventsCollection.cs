using System;
using InputController.Enums;
using InputController.Templates.Data;
using UnityEngine.Events;

namespace InputController.Data
{
    [Serializable]
    public class ActionEventsCollection : IActionEventsCollection
    {
        //Data Here
        public ActionEventsCollection()
        {
            InitializeActionEvents();
        }
        public void InitializeActionEvents()
        {
            foreach (ActionType action in System.Enum.GetValues(typeof(ActionType)))
            {
                throw new NotImplementedException("InitializeActionEvents");
            }
        }
        public UnityEvent GetUpdateActionEvent(ActionType actionType)
        {
            throw new NotImplementedException("GetUpdateActionEvent");;
        }
        public UnityEvent GetFixedUpdateActionEvent(ActionType actionType)
        {
            throw new NotImplementedException("GetFixedUpdateActionEvent");
        }
        public UnityEvent GetLateUpdateActionEvent(ActionType actionType)
        {
            throw new NotImplementedException("GetLateUpdateActionEvent");
        }
    }
}